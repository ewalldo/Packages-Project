using System;
using System.Collections;
using UnityEngine;

namespace Tween
{
	public abstract class Vector3Tween : ITweener
	{
        protected Vector3 initialValue;
        protected Vector3 endValue;
        protected float duration;
        protected float delay;
        protected EasingFunction easingFunction;
        protected ILoopType loopType;

        public virtual event Action OnComplete;

        public virtual IEnumerator Execute()
        {
            yield return null;

            OnComplete?.Invoke();
        }
    }
}