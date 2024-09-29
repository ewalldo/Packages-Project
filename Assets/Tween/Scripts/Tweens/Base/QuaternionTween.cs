using System;
using UnityEngine;

namespace Tween
{
	public abstract class QuaternionTween : BaseTween<Quaternion>
	{
        public QuaternionTween(Quaternion initialValue, Quaternion endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
            : base(initialValue, endValue, duration, delay, easingFunction, loopType, onComplete) { }

        public QuaternionTween(TweenParameters<Quaternion> tweenParameters, Action onComplete)
            : this(tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete) { }

        protected override void AdjustTweenValuesOnLoop()
        {
            (from, to) = loopType.AdjustTweenValues(from, to);
        }

        protected override Quaternion TweenValue(float progress)
        {
            return Quaternion.SlerpUnclamped(from, to, EasingEquations.Evaluate(easingFunction, progress));
        }
    }
}