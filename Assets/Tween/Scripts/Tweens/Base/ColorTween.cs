using UnityEngine;

namespace Tween
{
	public abstract class ColorTween : BaseTween
    {
        protected Color initialValue;
        protected Color endValue;

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