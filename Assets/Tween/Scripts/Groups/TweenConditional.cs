using System;
using System.Collections;
using UnityEngine;

namespace Tween
{
    public class TweenConditional : ITweener
    {
        private readonly float checkInterval;
        private readonly Func<bool> condition;

        private bool isExecuting;

        public bool IsExecuting => isExecuting;
        public event Action OnComplete;

        public TweenConditional(Func<bool> condition, float checkInterval)
        {
            this.condition = condition;
            this.checkInterval = checkInterval;
        }

        public IEnumerator Execute()
        {
            isExecuting = true;

            while (!condition.Invoke())
            {
                yield return new WaitForSeconds(checkInterval);
            }

            OnComplete?.Invoke();
            isExecuting = false;
        }

        public void ForceFinish()
        {
            isExecuting = false;
            return;
        }
    }
}