using UnityEngine;

namespace Tween
{
	public abstract class QuaternionTween : BaseTween
	{
        protected Quaternion initialValue;
        protected Quaternion endValue;

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