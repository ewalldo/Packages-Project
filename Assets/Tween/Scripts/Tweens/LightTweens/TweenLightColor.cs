using System;
using UnityEngine;

namespace Tween
{
	public class TweenLightColor : ColorTween
    {
        private Light targetObject;

        public TweenLightColor(Light targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : base(from, to, duration, delay, easingFunction, loopType, onComplete)
        {
            this.targetObject = targetObject;
        }

        public TweenLightColor(Light targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
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