using System;
using UnityEngine;
using UnityEngine.UI;

namespace Tween
{
	public static class ImageExtensions
	{
        public static Image TweenColor(this Image targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenImageColor tweenColor = new TweenImageColor(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenColor.Execute());

            return targetObject;
        }

        public static Image TweenColor(this Image targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenColor(targetObject, targetObject.color, to, duration, delay, easingFunction, loopType, onComplete);
        }

        public static Image TweenColor(this Image targetObject, TweenParameters<Color> tweenParameters, Action onComplete = null)
        {
            return TweenColor(targetObject, tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete);
        }

        public static Image TweenFade(this Image targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenImageFade tweenFade = new TweenImageFade(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenFade.Execute());

            return targetObject;
        }

        public static Image TweenFade(this Image targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenFade(targetObject, targetObject.color.a, to, duration, delay, easingFunction, loopType, onComplete);
        }

        public static Image TweenFade(this Image targetObject, TweenParameters<float> tweenParameters, Action onComplete = null)
        {
            return TweenFade(targetObject, tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete);
        }

        public static Image TweenFillAmount(this Image targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenImageFillAmount tweenFillAmount = new TweenImageFillAmount(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenFillAmount.Execute());

            return targetObject;
        }

        public static Image TweenFillAmount(this Image targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenFillAmount(targetObject, targetObject.fillAmount, to, duration, delay, easingFunction, loopType, onComplete);
        }

        public static Image TweenFillAmount(this Image targetObject, TweenParameters<float> tweenParameters, Action onComplete = null)
        {
            return TweenFillAmount(targetObject, tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete);
        }
    }
}