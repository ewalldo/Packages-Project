using System;
using UnityEngine;

namespace Tween
{
	public class TweenShakePosition : ShakeTween
	{
		private Transform targetObject;
		private bool isLocalPosition;

        public TweenShakePosition(Transform targetObject, Vector3 from, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalPosition = false, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null)
            : base(speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise)
        {
            this.targetObject = targetObject;
            initialValue = from;
            endValue = direction.normalized;
            this.duration = duration;
            this.delay = delay;
            this.isLocalPosition = isLocalPosition;
            this.easingFunction = easingFunction == null ? new LinearEasing() : easingFunction;
            this.loopType = loopType;

            OnComplete += onComplete;
        }

        public TweenShakePosition(Transform targetObject, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalPosition = false, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null)
            : this(targetObject, isLocalPosition ? targetObject.localPosition : targetObject.position, direction, duration, delay, speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise, isLocalPosition, easingFunction, loopType, onComplete) { }

        protected override bool IsTargetObjectNull()
        {
            return targetObject == null;
        }

        protected override void ApplyTween(Vector3 newValue)
        {
            if (isLocalPosition)
                targetObject.localPosition = newValue;
            else
                targetObject.position = newValue;
        }
    }
}