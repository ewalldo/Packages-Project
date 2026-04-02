using System;
using UnityEngine;
using UnityEngine.UI;

namespace Tween
{
	public class TweenRawImageFade : FloatTween
	{
		private RawImage targetObject;

        public TweenRawImageFade(RawImage targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : base(from, to, duration, delay, easingFunction, loopType, onComplete)
        {
            this.targetObject = targetObject;
        }

        public TweenRawImageFade(RawImage targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.color.a, to, duration, delay, easingFunction, loopType, onComplete) { }

        public TweenRawImageFade(RawImage targetObject, TweenParameters<float> tweenParameters, Action onComplete = null)
            : base(tweenParameters, onComplete)
        {
            this.targetObject = targetObject;
        }

        protected override bool IsTargetObjectNull()
        {
            return targetObject == null;
        }

        protected override void ApplyTween(float newValue)
        {
            newValue = Mathf.Clamp01(newValue);
            targetObject.color = new Color(targetObject.color.r, targetObject.color.g, targetObject.color.b, newValue);
        }
    }
}