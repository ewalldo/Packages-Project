using System;
using UnityEngine;

namespace Tween
{
	public static class RendererExtensions
	{
        public static Renderer TweenColor(this Renderer targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenRendererColor tweenColor = new TweenRendererColor(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenColor.Execute());

            return targetObject;
        }

        public static Renderer TweenColor(this Renderer targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenColor(targetObject, targetObject.material.color, to, duration, delay, easingFunction, loopType, onComplete);
        }
    }
}