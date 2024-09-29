using System;
using UnityEngine;

namespace Tween
{
	public abstract class Vector3Tween : BaseTween<Vector3>
	{
        public Vector3Tween(Vector3 initialValue, Vector3 endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
            : base(initialValue, endValue, duration, delay, easingFunction, loopType, onComplete) { }

        public Vector3Tween(TweenParameters<Vector3> tweenParameters, Action onComplete)
            : this(tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete) { }

        protected override void AdjustTweenValuesOnLoop()
        {
            (from, to) = loopType.AdjustTweenValues(from, to);
        }

        protected override Vector3 TweenValue(float progress)
        {
            return Vector3.LerpUnclamped(from, to, EasingEquations.Evaluate(easingFunction, progress));
        }
    }
}