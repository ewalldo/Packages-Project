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

        public event Action OnAllTweensCompleted;

        public TweenBuilder(MonoBehaviour monoBehaviour)
        {
            owner = monoBehaviour;
            tweens = new List<ITweener>();
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
            
            foreach (ITweener tween in tweens)
            {
                owner.StartCoroutine(tween.Execute());
            }
        }

        public void Reset()
        {
            tweens.Clear();
            OnAllTweensCompleted = null;
            completedTweens = 0;
        }

        private void OnTweenComplete()
        {
            completedTweens++;

            if (completedTweens >= tweens.Count)
                OnAllTweensCompleted?.Invoke();
        }
    }
}