using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tween
{
	public class TweenSequencer : ITweenGroup
    {
        private MonoBehaviour owner;
        private readonly List<ITweener> tweens;

        private int curTween;
        private bool isExecuting;

        private Coroutine sequence;

        public bool IsExecuting => isExecuting;
        public event Action OnAllTweensCompleted;

        public TweenSequencer(MonoBehaviour monoBehaviour)
        {
            owner = monoBehaviour;
            tweens = new List<ITweener>();
            curTween = 0;
            isExecuting = false;
        }

        public ITweenGroup AddTween(ITweener tween)
        {
            tweens.Add(tween);
            tween.OnComplete += OnTweenComplete;
            return this;
        }

        public ITweenGroup AddDelay(float duration)
        {
            return AddTween(new TweenDelay(duration));
        }

        public ITweenGroup AddConditional(Func<bool> condition, float checkInterval)
        {
            return AddTween(new TweenConditional(condition, checkInterval));
        }

        public void Execute()
        {
            if (tweens.Count == 0)
                return;

            sequence = owner.StartCoroutine(tweens[curTween].Execute());
            isExecuting = true;
        }

        public void Reset()
        {
            tweens.Clear();
            OnAllTweensCompleted = null;
            curTween = 0;
            isExecuting = false;
        }

        public void Stop(bool forceFinish = false)
        {
            curTween = 0;
            isExecuting = false;

            if (sequence != null)
                owner.StopCoroutine(sequence);

            if (forceFinish)
            {
                foreach (ITweener tween in tweens)
                    tween.ForceFinish();
            }
        }

        private void OnTweenComplete()
        {
            curTween++;

            if (curTween >= tweens.Count)
                AllTweensComplete();
            else
                Execute();
        }

        private void AllTweensComplete()
        {
            curTween = 0;
            OnAllTweensCompleted?.Invoke();
            isExecuting = false;
        }
    }
}