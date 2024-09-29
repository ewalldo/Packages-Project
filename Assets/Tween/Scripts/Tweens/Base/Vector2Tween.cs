using System;
using UnityEngine;

namespace Tween
{
	public abstract class Vector2Tween : BaseTween<Vector2>
	{
        public Vector2Tween(Vector2 initialValue, Vector2 endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
            : base(initialValue, endValue, duration, delay, easingFunction, loopType, onComplete) { }

        public Vector2Tween(TweenParameters<Vector2> tweenParameters, Action onComplete)
            : this(tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete) { }

        protected override void AdjustTweenValuesOnLoop()
        {
            (from, to) = loopType.AdjustTweenValues(from, to);
        }

        protected override Vector2 TweenValue(float progress)
        {
            return Vector2.LerpUnclamped(from, to, EasingEquations.Evaluate(easingFunction, progress));
        }
    }
}