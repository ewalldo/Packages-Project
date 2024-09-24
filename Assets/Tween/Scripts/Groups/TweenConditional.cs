using System;
using System.Collections;
using UnityEngine;

namespace Tween
{
    public class TweenConditional : ITweener
    {
        private readonly float checkInterval;
        private readonly Func<bool> condition;

        public event Action OnComplete;

        public TweenConditional(Func<bool> condition, float checkInterval)
        {
            this.condition = condition;
            this.checkInterval = checkInterval;
        }

        public IEnumerator Execute()
        {
            while (!condition.Invoke())
            {
                yield return new WaitForSeconds(checkInterval);
            }

            OnComplete?.Invoke();
        }
    }
}