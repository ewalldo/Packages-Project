using System;
using UnityEngine;

namespace Tween
{
    public abstract class FloatTween : BaseTween
	{
        protected float initialValue;
        protected float endValue;

        protected FloatTween(float initialValue, float endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
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
            float newValue = Mathf.LerpUnclamped(initialValue, endValue, EasingEquations.Evaluate(easingFunction, progress));
            ApplyTween(newValue);
        }

        protected abstract void ApplyTween(float newValue);
    }
}