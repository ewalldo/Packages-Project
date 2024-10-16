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

        private List<Coroutine> group;

        public event Action OnAllTweensCompleted;

        public TweenBuilder(MonoBehaviour monoBehaviour)
        {
            owner = monoBehaviour;
            tweens = new List<ITweener>();
            group = new List<Coroutine>();
        }

        public ITweenGroup AddTween(ITweener tween)
        {
            tweens.Add(tween);
            tween.OnComplete += OnTweenComplete;
            return this;
        }

        public void Execute()
        {
            completedTweens = 0;
            group.Clear();

            foreach (ITweener tween in tweens)
            {
                Coroutine coroutine = owner.StartCoroutine(tween.Execute());
                group.Add(coroutine);
            }
        }

        public void Reset()
        {
            tweens.Clear();
            group.Clear();
            OnAllTweensCompleted = null;
            completedTweens = 0;
        }

        public void Stop()
        {
            completedTweens = 0;

            foreach (Coroutine coroutine in group)
            {
                owner.StopCoroutine(coroutine);
            }
        }

        private void OnTweenComplete()
        {
            completedTweens++;

            if (completedTweens >= tweens.Count)
                OnAllTweensCompleted?.Invoke();
        }
    }
}