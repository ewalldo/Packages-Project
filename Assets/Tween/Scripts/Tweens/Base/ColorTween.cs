using System;
using UnityEngine;

namespace Tween
{
	public abstract class ColorTween : BaseTween<Color>
    {
        public ColorTween(Color initialValue, Color endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
            : base(initialValue, endValue, duration, delay, easingFunction, loopType, onComplete) { }

        public ColorTween(TweenParameters<Color> tweenParameters, Action onComplete)
            : this(tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete) { }

        protected override void AdjustTweenValuesOnLoop()
        {
            (from, to) = loopType.AdjustTweenValues(from, to);
        }

        protected override Color TweenValue(float progress)
        {
            return Color.LerpUnclamped(from, to, EasingEquations.Evaluate(easingFunction, progress));
        }
    }
}