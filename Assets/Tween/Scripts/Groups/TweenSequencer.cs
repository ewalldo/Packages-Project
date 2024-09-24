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

        private Coroutine sequence;

        public event Action OnAllTweensCompleted;

        public TweenSequencer(MonoBehaviour monoBehaviour)
        {
            owner = monoBehaviour;
            tweens = new List<ITweener>();
            curTween = 0;
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
            sequence = owner.StartCoroutine(tweens[curTween].Execute());
        }

        public void Reset()
        {
            tweens.Clear();
            OnAllTweensCompleted = null;
            curTween = 0;
        }

        public void Stop()
        {
            curTween = 0;
            owner.StopCoroutine(sequence);
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
        }
    }
}