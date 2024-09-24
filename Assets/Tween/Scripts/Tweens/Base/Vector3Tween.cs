using System;
using UnityEngine;

namespace Tween
{
	public abstract class Vector3Tween : BaseTween
	{
        protected Vector3 initialValue;
        protected Vector3 endValue;

        protected Vector3 from;
        protected Vector3 to;

        public Vector3Tween(Vector3 initialValue, Vector3 endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
            : base(duration, delay, easingFunction, loopType, onComplete)
        {
            this.initialValue = initialValue;
            this.endValue = endValue;
        }

        public Vector3Tween(TweenParameters<Vector3> tweenParameters, Action onComplete)
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
            Vector3 newValue = Vector3.LerpUnclamped(from, to, EasingEquations.Evaluate(easingFunction, progress));
            ApplyTween(newValue);
        }

        protected abstract void ApplyTween(Vector3 newValue);
    }
}