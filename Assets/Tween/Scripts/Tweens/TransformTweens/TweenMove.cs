using System;
using UnityEngine;

namespace Tween
{
    public class TweenMove : Vector3Tween
	{
        private Transform targetObject;
        private bool isLocalPosition;

        public TweenMove(Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, bool isLocalPosition = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            this.targetObject = targetObject;
            initialValue = from;
            endValue = to;
            this.duration = duration;
            this.delay = delay;
            this.isLocalPosition = isLocalPosition;
            this.easingFunction = easingFunction == null ? new LinearEasing() : easingFunction;
            this.loopType = loopType;

            OnComplete += onComplete;
        }

        public TweenMove(Transform targetObject, Vector3 to, float duration, float delay = 0f, bool isLocalPosition = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, isLocalPosition ? targetObject.localPosition : targetObject.position, to, duration, delay, isLocalPosition, easingFunction, loopType, onComplete) { }

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