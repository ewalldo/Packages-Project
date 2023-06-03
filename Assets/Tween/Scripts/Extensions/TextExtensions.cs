using UnityEngine;
using TMPro;
using System;

namespace Tween
{
	public static class TextExtensions
	{
        public static TMP_Text TweenColor(this TMP_Text targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenTextColor tweenColor = new TweenTextColor(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenColor.Execute());

            return targetObject;
        }

        public static TMP_Text TweenColor(this TMP_Text targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenColor(targetObject, targetObject.color, to, duration, delay, easingFunction, loopType, onComplete);
        }

        public static TMP_Text TweenFade(this TMP_Text targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenTextFade tweenFade = new TweenTextFade(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenFade.Execute());

            return targetObject;
        }

        public static TMP_Text TweenFade(this TMP_Text targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenFade(targetObject, targetObject.alpha, to, duration, delay, easingFunction, loopType, onComplete);
        }
    }
}