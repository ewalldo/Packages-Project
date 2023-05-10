using System;
using System.Collections;

namespace Tween
{
    public abstract class FloatTween : ITweener
	{
        protected float initialValue;
        protected float endValue;
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