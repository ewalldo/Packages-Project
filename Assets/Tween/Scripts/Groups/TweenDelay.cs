using System;
using System.Collections;
using UnityEngine;

namespace Tween
{
    public class TweenDelay : ITweener
    {
        private readonly float duration;

        private bool isExecuting;

        public bool IsExecuting => isExecuting;
        public event Action OnComplete;

        public TweenDelay(float duration)
        {
            this.duration = duration;
        }

        public IEnumerator Execute()
        {
            isExecuting = true;
            yield return new WaitForSeconds(duration);

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