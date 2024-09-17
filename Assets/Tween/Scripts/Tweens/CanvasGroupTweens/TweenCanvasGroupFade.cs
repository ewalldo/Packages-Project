using System;
using UnityEngine;

namespace Tween
{
	public class TweenCanvasGroupFade : FloatTween
	{
        private CanvasGroup targetObject;

        public TweenCanvasGroupFade(CanvasGroup targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : base(from, to, duration, delay, easingFunction, loopType, onComplete)
        {
            this.targetObject = targetObject;
        }

        public TweenCanvasGroupFade(CanvasGroup targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.alpha, to, duration, delay, easingFunction, loopType, onComplete) { }

        protected override bool IsTargetObjectNull()
        {
            return targetObject == null;
        }

        protected override void ApplyTween(float newValue)
        {
            newValue = Mathf.Clamp01(newValue);
            targetObject.alpha = newValue;
        }
    }
}