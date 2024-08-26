using System;
using UnityEngine;

namespace Tween
{
    public class TweenCameraFOV : FloatTween
    {
        private Camera targetObject;

        public TweenCameraFOV(Camera targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
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

        public TweenCameraFOV(Camera targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.fieldOfView, to, duration, delay, easingFunction, loopType, onComplete) { }

        protected override bool IsTargetObjectNull()
        {
            return targetObject == null;
        }

        protected override void ApplyTween(float newValue)
        {
            newValue = Mathf.Clamp(newValue, 1e-05f, 179f);
            targetObject.fieldOfView = newValue;
        }
    }
}