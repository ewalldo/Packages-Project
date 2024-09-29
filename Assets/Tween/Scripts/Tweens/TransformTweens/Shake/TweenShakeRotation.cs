using System;
using UnityEngine;

namespace Tween
{
	public class TweenShakeRotation : ShakeTween
	{
        private Transform targetObject;
        private bool isLocalRotation;

        public TweenShakeRotation(Transform targetObject, Vector3 from, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalRotation = true, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null)
            : base(from, direction.normalized, duration, delay, speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise, easingFunction, loopType, onComplete)
        {
            this.targetObject = targetObject;
            this.isLocalRotation = isLocalRotation;
        }

        public TweenShakeRotation(Transform targetObject, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalRotation = true, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null)
            : this(targetObject, isLocalRotation ? targetObject.localRotation.eulerAngles : targetObject.rotation.eulerAngles, direction, duration, delay, speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise, isLocalRotation, easingFunction, loopType, onComplete) { }

        public TweenShakeRotation(Transform targetObject, ShakeParameters shakeParameters, bool isLocalRotation = true, Action onComplete = null)
            : base(shakeParameters, onComplete)
        {
            this.targetObject = targetObject;
            this.isLocalRotation = isLocalRotation;
        }

        protected override bool IsTargetObjectNull()
        {
            return targetObject == null;
        }

        protected override void ApplyTween(Vector3 newValue)
        {
            if (isLocalRotation)
                targetObject.localRotation = Quaternion.Euler(newValue);
            else
                targetObject.rotation = Quaternion.Euler(newValue);
        }
    }
}