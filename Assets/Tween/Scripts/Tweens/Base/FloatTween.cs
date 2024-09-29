using System;
using UnityEngine;

namespace Tween
{
    public abstract class FloatTween : BaseTween<float>
	{
        public FloatTween(float initialValue, float endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
            : base(initialValue, endValue, duration, delay, easingFunction, loopType, onComplete) { }

        public FloatTween(TweenParameters<float> tweenParameters, Action onComplete)
            : this(tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete) { }

        protected override void AdjustTweenValuesOnLoop()
        {
            (from, to) = loopType.AdjustTweenValues(from, to);
        }

        protected override float TweenValue(float progress)
        {
            return Mathf.LerpUnclamped(from, to, EasingEquations.Evaluate(easingFunction, progress));
        }
    }
}