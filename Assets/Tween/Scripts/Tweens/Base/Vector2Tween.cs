using System;
using UnityEngine;

namespace Tween
{
	public abstract class Vector2Tween : BaseTween
	{
        protected Vector2 initialValue;
        protected Vector2 endValue;

        protected Vector2 from;
        protected Vector2 to;

        public Vector2Tween(Vector2 initialValue, Vector2 endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
            : base(duration, delay, easingFunction, loopType, onComplete)
        {
            this.initialValue = initialValue;
            this.endValue = endValue;
        }

        public Vector2Tween(TweenParameters<Vector2> tweenParameters, Action onComplete)
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
            Vector2 newValue = Vector2.LerpUnclamped(from, to, EasingEquations.Evaluate(easingFunction, progress));
            ApplyTween(newValue);
        }

        protected abstract void ApplyTween(Vector2 newValue);
    }
}