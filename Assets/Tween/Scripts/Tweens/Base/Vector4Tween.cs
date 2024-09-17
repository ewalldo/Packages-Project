using System;
using UnityEngine;

namespace Tween
{
	public abstract class Vector4Tween : BaseTween
	{
        protected Vector4 initialValue;
        protected Vector4 endValue;

        protected Vector4Tween(Vector4 initialValue, Vector4 endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
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
            Vector4 newValue = Vector4.LerpUnclamped(initialValue, endValue, EasingEquations.Evaluate(easingFunction, progress));
            ApplyTween(newValue);
        }

        protected abstract void ApplyTween(Vector4 newValue);
    }
}