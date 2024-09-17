using System;
using UnityEngine;

namespace Tween
{
	public abstract class QuaternionTween : BaseTween
	{
        protected Quaternion initialValue;
        protected Quaternion endValue;

        protected QuaternionTween(Quaternion initialValue, Quaternion endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
            : base(duration, delay, easingFunction, loopType, onComplete)
        {
            this.initialValue = initialValue;
            this.endValue = endValue;
        }

        protected override void AdjustTweenValuesOnLoop()
        {
            (initialValue, endValue) = loopType.AdjustTweenValues(initialValue, endValue);
        }

        protected override void TweenValue(float progress)
        {
            Quaternion newQuaternion = Quaternion.SlerpUnclamped(initialValue, endValue, EasingEquations.Evaluate(easingFunction, progress));
            ApplyTween(newQuaternion);
        }

        protected abstract void ApplyTween(Quaternion newQuaternion);
    }
}