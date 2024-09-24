using System;
using UnityEngine;

namespace Tween
{
	public abstract class QuaternionTween : BaseTween
	{
        protected Quaternion initialValue;
        protected Quaternion endValue;

        protected Quaternion from;
        protected Quaternion to;

        public QuaternionTween(Quaternion initialValue, Quaternion endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
            : base(duration, delay, easingFunction, loopType, onComplete)
        {
            this.initialValue = initialValue;
            this.endValue = endValue;
        }

        public QuaternionTween(TweenParameters<Quaternion> tweenParameters, Action onComplete)
            : this(tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete) { }

        protected override void SaveInitialTweenValues()
        {
            from = initialValue;
            to = endValue;
        }

        protected override void AdjustTweenValuesOnLoop()
        {
            (from, to) = loopType.AdjustTweenValues(from, to);
        }

        protected override void TweenValue(float progress)
        {
            Quaternion newQuaternion = Quaternion.SlerpUnclamped(from, to, EasingEquations.Evaluate(easingFunction, progress));
            ApplyTween(newQuaternion);
        }

        protected abstract void ApplyTween(Quaternion newQuaternion);
    }
}