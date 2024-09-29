using System;
using UnityEngine;

namespace Tween
{
	public class TweenMaterialColor : ColorTween
	{
		private Material targetObject;

        public TweenMaterialColor(Material targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : base(from, to, duration, delay, easingFunction, loopType, onComplete)
        {
            this.targetObject = targetObject;
        }

        public TweenMaterialColor(Material targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.color, to, duration, delay, easingFunction, loopType, onComplete) { }

        public TweenMaterialColor(Material targetObject, TweenParameters<Color> tweenParameters, Action onComplete = null)
            : base(tweenParameters, onComplete)
        {
            this.targetObject = targetObject;
        }

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