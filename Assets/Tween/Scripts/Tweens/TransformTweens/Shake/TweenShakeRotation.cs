using System;
using UnityEngine;

namespace Tween
{
	public class TweenShakeRotation : ShakeTween
	{
        private Transform targetObject;
        private bool isLocalRotation;

        public TweenShakeRotation(Transform targetObject, Vector3 from, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalRotation = false, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null)
            : base(speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise)
        {
            this.targetObject = targetObject;
            initialValue = from;
            endValue = direction.normalized;
            this.duration = duration;
            this.delay = delay;
            this.isLocalRotation = isLocalRotation;
            this.easingFunction = easingFunction == null ? new LinearEasing() : easingFunction;
            this.loopType = loopType;

            OnComplete += onComplete;
        }

        public TweenShakeRotation(Transform targetObject, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalRotation = false, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null)
            : this(targetObject, isLocalRotation ? targetObject.localRotation.eulerAngles : targetObject.rotation.eulerAngles, direction, duration, delay, speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise, isLocalRotation, easingFunction, loopType, onComplete) { }

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