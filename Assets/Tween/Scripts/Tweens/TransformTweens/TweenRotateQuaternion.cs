using System;
using UnityEngine;

namespace Tween
{
	public class TweenRotateQuaternion : QuaternionTween
	{
        private Transform targetObject;
        private bool isLocalRotation;

        public TweenRotateQuaternion(Transform targetObject, Quaternion from, Quaternion to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : base(from, to, duration, delay, easingFunction, loopType, onComplete)
        {
            this.targetObject = targetObject;
            this.isLocalRotation = isLocalRotation;
        }

        public TweenRotateQuaternion(Transform targetObject, Quaternion to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, isLocalRotation ? targetObject.localRotation : targetObject.rotation, to, duration, delay, isLocalRotation, easingFunction, loopType, onComplete) { }

        protected override bool IsTargetObjectNull()
        {
            return targetObject == null;
        }

        protected override void ApplyTween(Quaternion newQuaternion)
        {
            if (isLocalRotation)
                targetObject.localRotation = newQuaternion;
            else
                targetObject.rotation = newQuaternion;
        }
    }
}