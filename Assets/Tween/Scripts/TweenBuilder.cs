using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tween
{
	public class TweenBuilder
	{
        private MonoBehaviour owner;
        private readonly List<ITweener> tweens;

        private int completedTweens;

        public Action OnAllTweensCompleted;

        public TweenBuilder(MonoBehaviour monoBehaviour)
        {
            owner = monoBehaviour;
            tweens = new List<ITweener>();
        }

        public TweenBuilder AddTween(ITweener tween)
        {
            tweens.Add(tween);
            tween.OnComplete += OnTweenComplete;
            return this;
        }

        public void Execute()
        {
            completedTweens = 0;
            owner.StopAllCoroutines();
            foreach (ITweener tween in tweens)
            {
                owner.StartCoroutine(tween.Execute());
            }
        }

        public void Reset()
        {
            tweens.Clear();
        }

        private void OnTweenComplete()
        {
            completedTweens++;
            //tween.OnComplete -= OnTweenComplete;

            if (completedTweens >= tweens.Count)
                OnAllTweensCompleted?.Invoke();
        }
    }
}