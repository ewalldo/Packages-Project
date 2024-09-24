using System;
using UnityEngine;

namespace Tween
{
	public abstract class Vector4Tween : BaseTween
	{
        protected Vector4 initialValue;
        protected Vector4 endValue;

        protected Vector4 from;
        protected Vector4 to;

        public Vector4Tween(Vector4 initialValue, Vector4 endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
            : base(duration, delay, easingFunction, loopType, onComplete)
        {
            this.initialValue = initialValue;
            this.endValue = endValue;
        }

        public Vector4Tween(TweenParameters<Vector4> tweenParameters, Action onComplete)
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
            Vector4 newValue = Vector4.LerpUnclamped(from, to, EasingEquations.Evaluate(easingFunction, progress));
            ApplyTween(newValue);
        }

        protected abstract void ApplyTween(Vector4 newValue);
    }
}