using System;
using UnityEngine;

namespace Tween
{
	public class TweenShakeScale : ShakeTween
	{
        private Transform targetObject;

        public TweenShakeScale(Transform targetObject, Vector3 from, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null)
            : base(from, direction.normalized, duration, delay, speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise, easingFunction, loopType, onComplete)
        {
            this.targetObject = targetObject;
        }

        public TweenShakeScale(Transform targetObject, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.localScale, direction, duration, delay, speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise, easingFunction, loopType, onComplete) { }

        protected override bool IsTargetObjectNull()
        {
            return targetObject == null;
        }

        protected override void ApplyTween(Vector3 newValue)
        {
            targetObject.localScale = newValue;
        }
    }
}