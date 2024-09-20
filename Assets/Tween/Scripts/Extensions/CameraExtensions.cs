using System;
using UnityEngine;

namespace Tween
{
	public static class CameraExtensions
	{
		public static Camera TweenFOV(this Camera targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
			if (easingFunction == null)
				easingFunction = new LinearEasing();
			TweenCameraFOV tweenFOV = new TweenCameraFOV(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
			TweenCoroutineStarter.Instance.StartCoroutine(tweenFOV.Execute());

			return targetObject;
        }

		public static Camera TweenFOV(this Camera targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
			return TweenFOV(targetObject, targetObject.fieldOfView, to, duration, delay, easingFunction, loopType, onComplete);
        }

		public static Camera TweenFOV(this Camera targetObject, TweenParameters<float> tweenParameters, Action onComplete = null)
        {
			return TweenFOV(targetObject, tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete);
		}
	}
}