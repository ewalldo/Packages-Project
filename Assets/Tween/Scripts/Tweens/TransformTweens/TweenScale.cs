using System;
using UnityEngine;

namespace Tween
{
	public class TweenScale : Vector3Tween
	{
        private Transform targetObject;

        public TweenScale(Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
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

        public TweenScale(Transform targetObject, Vector3 to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.localScale, to, duration, delay, easingFunction, loopType, onComplete) { }

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