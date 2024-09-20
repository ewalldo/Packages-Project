using System;
using UnityEngine;

namespace Tween
{
	public static class MaterialExtensions
	{
		public static Material TweenColor(this Material targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
			if (easingFunction == null)
				easingFunction = new LinearEasing();
			TweenMaterialColor tweenColor = new TweenMaterialColor(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
			TweenCoroutineStarter.Instance.StartCoroutine(tweenColor.Execute());

			return targetObject;
		}

		public static Material TweenColor(this Material targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
		{
			return TweenColor(targetObject, targetObject.color, to, duration, delay, easingFunction, loopType, onComplete);
		}

		public static Material TweenColor(this Material targetObject, TweenParameters<Color> tweenParameters, Action onComplete = null)
        {
			return TweenColor(targetObject, tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete);
		}

		public static Material TweenFade(this Material targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
		{
			if (easingFunction == null)
				easingFunction = new LinearEasing();
			TweenMaterialFade tweenFade = new TweenMaterialFade(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
			TweenCoroutineStarter.Instance.StartCoroutine(tweenFade.Execute());

			return targetObject;
		}

		public static Material TweenFade(this Material targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
		{
			return TweenFade(targetObject, targetObject.color.a, to, duration, delay, easingFunction, loopType, onComplete);
		}

		public static Material TweenFade(this Material targetObject, TweenParameters<float> tweenParameters, Action onComplete = null)
        {
			return TweenFade(targetObject, tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete);
		}
	}
}