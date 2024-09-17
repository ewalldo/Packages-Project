using System;
using UnityEngine;

namespace Tween
{
	public class TweenRotateVector3 : Vector3Tween
	{
        private Transform targetObject;
        private bool isLocalRotation;

        public TweenRotateVector3(Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : base(from, to, duration, delay, easingFunction, loopType, onComplete)
        {
            this.targetObject = targetObject;
            this.isLocalRotation = isLocalRotation;
        }

        public TweenRotateVector3(Transform targetObject, Vector3 to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, isLocalRotation ? targetObject.localRotation.eulerAngles : targetObject.rotation.eulerAngles, to, duration, delay, isLocalRotation, easingFunction, loopType, onComplete) { }

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