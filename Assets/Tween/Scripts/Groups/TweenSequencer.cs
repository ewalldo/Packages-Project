using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tween
{
	public class TweenSequencer : ITweenGroup
    {
        private MonoBehaviour owner;
        private readonly List<ITweener> tweens;

        private int completedTweens;
        private int curTween;

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

        public void Execute()
        {
            owner.StartCoroutine(tweens[curTween].Execute());
        }

        public void Reset()
        {
            tweens.Clear();
            OnAllTweensCompleted = null;
            curTween = 0;
        }

        private void OnTweenComplete()
        {
            completedTweens++;
            curTween++;

            if (completedTweens >= tweens.Count)
                AllTweensComplete();
            else
                Execute();
        }

        private void AllTweensComplete()
        {
            completedTweens = 0;
            curTween = 0;
            OnAllTweensCompleted?.Invoke();
        }
    }
}