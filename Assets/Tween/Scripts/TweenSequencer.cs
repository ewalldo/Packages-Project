using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tween
{
	public class TweenSequencer
	{
        private MonoBehaviour owner;
        private readonly List<ITweener> tweens;

        private int completedTweens;
        private int curTween;

        public Action OnAllTweensCompleted;

        public TweenSequencer(MonoBehaviour monoBehaviour)
        {
            owner = monoBehaviour;
            tweens = new List<ITweener>();
            curTween = 0;
        }

        public TweenSequencer AddTween(ITweener tween)
        {
            tweens.Add(tween);
            tween.OnComplete += OnTweenComplete;
            return this;
        }

        public void Execute()
        {
            owner.StopAllCoroutines();
            owner.StartCoroutine(tweens[curTween].Execute());
        }

        private void OnTweenComplete()
        {
            completedTweens++;
            curTween++;
            //tween.OnComplete -= OnTweenComplete;

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