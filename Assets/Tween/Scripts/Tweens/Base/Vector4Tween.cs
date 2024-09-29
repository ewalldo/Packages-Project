using System;
using UnityEngine;

namespace Tween
{
	public abstract class Vector4Tween : BaseTween<Vector4>
	{
        public Vector4Tween(Vector4 initialValue, Vector4 endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
            : base(initialValue, endValue, duration, delay, easingFunction, loopType, onComplete) { }

        public Vector4Tween(TweenParameters<Vector4> tweenParameters, Action onComplete)
            : this(tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete) { }

        protected override void AdjustTweenValuesOnLoop()
        {
            (from, to) = loopType.AdjustTweenValues(from, to);
        }

        protected override Vector4 TweenValue(float progress)
        {
            return Vector4.LerpUnclamped(from, to, EasingEquations.Evaluate(easingFunction, progress));
        }
    }
}