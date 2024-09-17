using System;
using UnityEngine;
using UnityEngine.UI;

namespace Tween
{
	public class TweenImageFillAmount : FloatTween
	{
        private Image targetObject;

        public TweenImageFillAmount(Image targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : base(from, to, duration, delay, easingFunction, loopType, onComplete)
        {
            this.targetObject = targetObject;
        }

        public TweenImageFillAmount(Image targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.fillAmount, to, duration, delay, easingFunction, loopType, onComplete) { }

        protected override bool IsTargetObjectNull()
        {
            return targetObject == null;
        }

        protected override void ApplyTween(float newValue)
        {
            newValue = Mathf.Clamp01(newValue);
            targetObject.fillAmount = newValue;
        }
    }
}