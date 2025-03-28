using System;
using UnityEngine;
using UnityEngine.UI;

namespace Tween
{
	public static class RawImageExtensions
	{
		public static RawImage TweenColor(this RawImage targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
			if (easingFunction == null)
				easingFunction = new LinearEasing();
			TweenRawImageColor tweenColor = new TweenRawImageColor(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
			TweenCoroutineStarter.Instance.StartCoroutine(tweenColor.Execute());

			return targetObject;
        }

		public static RawImage TweenColor(this RawImage targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
			return TweenColor(targetObject, targetObject.color, to, duration, delay, easingFunction, loopType, onComplete);
        }

		public static RawImage TweenColor(this RawImage targetObject, TweenParameters<Color> tweenParameters, Action onComplete = null)
		{
			return TweenColor(targetObject, tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete);
		}

        public static RawImage TweenFade(this RawImage targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenRawImageFade tweenFade = new TweenRawImageFade(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenFade.Execute());

            return targetObject;
        }

        public static RawImage TweenFade(this RawImage targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenFade(targetObject, targetObject.color.a, to, duration, delay, easingFunction, loopType, onComplete);
        }

        public static RawImage TweenFade(this RawImage targetObject, TweenParameters<float> tweenParameters, Action onComplete = null)
        {
            return TweenFade(targetObject, tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete);
        }
    }
}