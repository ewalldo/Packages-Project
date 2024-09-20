using System;
using UnityEngine;

namespace Tween
{
    public class TweenCameraFOV : FloatTween
    {
        private Camera targetObject;

        public TweenCameraFOV(Camera targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : base(from, to, duration, delay, easingFunction, loopType, onComplete)
        {
            this.targetObject = targetObject;
        }

        public TweenCameraFOV(Camera targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.fieldOfView, to, duration, delay, easingFunction, loopType, onComplete) { }

        public TweenCameraFOV(Camera targetObject, TweenParameters<float> tweenParameters, Action onComplete = null)
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
            newValue = Mathf.Clamp(newValue, 1e-05f, 179f);
            targetObject.fieldOfView = newValue;
        }
    }
}