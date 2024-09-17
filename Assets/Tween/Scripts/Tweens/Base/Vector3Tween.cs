using System;
using UnityEngine;

namespace Tween
{
	public abstract class Vector3Tween : BaseTween
	{
        protected Vector3 initialValue;
        protected Vector3 endValue;

        protected Vector3Tween(Vector3 initialValue, Vector3 endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
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
            Vector3 newValue = Vector3.LerpUnclamped(initialValue, endValue, EasingEquations.Evaluate(easingFunction, progress));
            ApplyTween(newValue);
        }

        protected abstract void ApplyTween(Vector3 newValue);
    }
}