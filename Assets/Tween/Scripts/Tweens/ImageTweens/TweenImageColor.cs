using System;
using UnityEngine;
using UnityEngine.UI;

namespace Tween
{
	public class TweenImageColor : ColorTween
    {
        private Image targetObject;

        public TweenImageColor(Image targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            this.targetObject = targetObject;
            initialValue = from;
            endValue = to;
            this.duration = duration;
            this.delay = delay;
            this.easingFunction = easingFunction == null ? new LinearEasing() : easingFunction;
            this.loopType = loopType;

            OnComplete += onComplete;
        }

        public TweenImageColor(Image targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.color, to, duration, delay, easingFunction, loopType, onComplete) { }

        protected override bool IsTargetObjectNull()
        {
            return targetObject == null;
        }

        protected override void ApplyTween(Color newColor)
        {
            targetObject.color = newColor;
        }
    }
}