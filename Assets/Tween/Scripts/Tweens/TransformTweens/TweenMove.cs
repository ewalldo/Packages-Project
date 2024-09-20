using System;
using UnityEngine;

namespace Tween
{
    public class TweenMove : Vector3Tween
	{
        private Transform targetObject;
        private bool isLocalPosition;

        public TweenMove(Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, bool isLocalPosition = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : base(from, to, duration, delay, easingFunction, loopType, onComplete)
        {
            this.targetObject = targetObject;
            this.isLocalPosition = isLocalPosition;
        }

        public TweenMove(Transform targetObject, Vector3 to, float duration, float delay = 0f, bool isLocalPosition = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, isLocalPosition ? targetObject.localPosition : targetObject.position, to, duration, delay, isLocalPosition, easingFunction, loopType, onComplete) { }

        public TweenMove(Transform targetObject, TweenParameters<Vector3> tweenParameters, bool isLocalPosition = false, Action onComplete = null)
            : base(tweenParameters, onComplete)
        {
            this.targetObject = targetObject;
            this.isLocalPosition = isLocalPosition;
        }

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