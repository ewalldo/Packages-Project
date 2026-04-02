using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tween
{
	public class TweenBuilder : ITweenGroup
    {
        private MonoBehaviour owner;
        private readonly List<ITweener> tweens;

        private int completedTweens;
        private bool isExecuting;

        private Dictionary<Coroutine, ITweener> group;

        public bool IsExecuting => isExecuting;
        public event Action OnAllTweensCompleted;

        public TweenBuilder(MonoBehaviour monoBehaviour)
        {
            owner = monoBehaviour;
            tweens = new List<ITweener>();
            group = new Dictionary<Coroutine, ITweener>();
            isExecuting = false;
        }

        public ITweenGroup AddTween(ITweener tween)
        {
            tweens.Add(tween);
            tween.OnComplete += OnTweenComplete;
            return this;
        }

        public void Execute()
        {
            if (tweens.Count == 0)
                return;

            completedTweens = 0;
            isExecuting = true;
            group.Clear();

            foreach (ITweener tween in tweens)
            {
                Coroutine coroutine = owner.StartCoroutine(tween.Execute());
                group.Add(coroutine, tween);
            }
        }

        public void Reset()
        {
            tweens.Clear();
            group.Clear();
            OnAllTweensCompleted = null;
            completedTweens = 0;
            isExecuting = false;
        }

        public void Stop(bool forceFinish = false)
        {
            completedTweens = 0;
            isExecuting = false;

            foreach (KeyValuePair<Coroutine, ITweener> coroutineTweenPair in group)
            {
                owner.StopCoroutine(coroutineTweenPair.Key);

                if (forceFinish && coroutineTweenPair.Value.IsExecuting)
                    coroutineTweenPair.Value.ForceFinish();
            }
        }

        private void OnTweenComplete()
        {
            completedTweens++;

            if (completedTweens >= tweens.Count)
            {
                OnAllTweensCompleted?.Invoke();
                isExecuting = false;
            }
        }
    }
}