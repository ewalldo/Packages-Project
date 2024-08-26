using UnityEngine;

namespace Tween
{
	public abstract class Vector4Tween : BaseTween
	{
        protected Vector4 initialValue;
        protected Vector4 endValue;

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