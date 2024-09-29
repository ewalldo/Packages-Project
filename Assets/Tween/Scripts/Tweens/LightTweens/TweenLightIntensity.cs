using System;
using UnityEngine;

namespace Tween
{
	public class TweenLightIntensity : FloatTween
	{
        private Light targetObject;

        public TweenLightIntensity(Light targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : base(from, to, duration, delay, easingFunction, loopType, onComplete)
        {
            this.targetObject = targetObject;
        }

        public TweenLightIntensity(Light targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.intensity, to, duration, delay, easingFunction, loopType, onComplete) { }

        public TweenLightIntensity(Light targetObject, TweenParameters<float> tweenParameters, Action onComplete = null)
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
            if (newValue < 0f)
                newValue = 0f;

            targetObject.intensity = newValue;
        }
    }
}