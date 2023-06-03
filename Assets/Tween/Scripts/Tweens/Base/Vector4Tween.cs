using System;
using System.Collections;
using UnityEngine;

namespace Tween
{
	public abstract class Vector4Tween : ITweener
	{
        protected Vector4 initialValue;
        protected Vector4 endValue;
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