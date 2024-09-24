using System;
using System.Collections;
using UnityEngine;

namespace Tween
{
    public class TweenDelay : ITweener
    {
        private readonly float duration;

        public event Action OnComplete;

        public TweenDelay(float duration)
        {
            this.duration = duration;
        }

        public IEnumerator Execute()
        {
            yield return new WaitForSeconds(duration);

            OnComplete?.Invoke();
        }
    }
}