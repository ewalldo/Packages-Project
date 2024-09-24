using System;
using UnityEngine;

namespace Tween
{
	public abstract class ColorTween : BaseTween
    {
        protected Color initialValue;
        protected Color endValue;

        protected Color from;
        protected Color to;

        public ColorTween(Color initialValue, Color endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
            : base(duration, delay, easingFunction, loopType, onComplete)
        {
            this.initialValue = initialValue;
            this.endValue = endValue;
        }

        public ColorTween(TweenParameters<Color> tweenParameters, Action onComplete)
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
            Color newColor = Color.LerpUnclamped(from, to, EasingEquations.Evaluate(easingFunction, progress));
            ApplyTween(newColor);
        }

        protected abstract void ApplyTween(Color newColor);
    }
}