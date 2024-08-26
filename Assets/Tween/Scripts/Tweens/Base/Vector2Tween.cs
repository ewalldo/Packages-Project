using UnityEngine;

namespace Tween
{
	public abstract class Vector2Tween : BaseTween
	{
        protected Vector2 initialValue;
        protected Vector2 endValue;

        protected override void AdjustTweenValuesOnLoop()
        {
            (initialValue, endValue) = loopType.AdjustTweenValues(initialValue, endValue);
        }

        protected override void TweenValue(float progress)
        {
            Vector2 newValue = Vector2.LerpUnclamped(initialValue, endValue, EasingEquations.Evaluate(easingFunction, progress));
            ApplyTween(newValue);
        }

        protected abstract void ApplyTween(Vector2 newValue);
    }
}