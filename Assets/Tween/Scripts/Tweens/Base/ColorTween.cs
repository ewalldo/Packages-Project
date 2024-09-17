using System;
using UnityEngine;

namespace Tween
{
	public abstract class ColorTween : BaseTween
    {
        protected Color initialValue;
        protected Color endValue;

        protected ColorTween(Color initialValue, Color endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
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
            Color newColor = Color.LerpUnclamped(initialValue, endValue, EasingEquations.Evaluate(easingFunction, progress));
            ApplyTween(newColor);
        }

        protected abstract void ApplyTween(Color newColor);
    }
}