using System;
using UnityEngine;

namespace Tween
{
	public class TweenLightIntensity : FloatTween
	{
        private Light targetObject;

        public TweenLightIntensity(Light targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            this.targetObject = targetObject;
            initialValue = from;
            endValue = to;
            this.duration = duration;
            this.delay = delay;
            this.easingFunction = easingFunction == null ? new LinearEasing() : easingFunction;
            this.loopType = loopType;

            OnComplete += onComplete;
        }

        public TweenLightIntensity(Light targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.intensity, to, duration, delay, easingFunction, loopType, onComplete) { }

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