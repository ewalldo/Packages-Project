using System;
using UnityEngine;

namespace Tween
{
	public static class CanvasGroupExtensions
	{
        public static CanvasGroup TweenFade(this CanvasGroup targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenCanvasGroupFade tweenFade = new TweenCanvasGroupFade(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenFade.Execute());

            return targetObject;
        }

        public static CanvasGroup TweenFade(this CanvasGroup targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenFade(targetObject, targetObject.alpha, to, duration, delay, easingFunction, loopType, onComplete);
        }
    }
}