using System;
using UnityEngine;

namespace Tween
{
	public static class LightExtensions
	{
		public static Light TweenColor(this Light targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenLightColor tweenColor = new TweenLightColor(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenColor.Execute());

            return targetObject;
        }

        public static Light TweenColor(this Light targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenColor(targetObject, targetObject.color, to, duration, delay, easingFunction, loopType, onComplete);
        }

        public static Light TweenIntensity(this Light targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenLightIntensity tweenIntensity = new TweenLightIntensity(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenIntensity.Execute());

            return targetObject;
        }

        public static Light TweenIntensity(this Light targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenIntensity(targetObject, targetObject.intensity, to, duration, delay, easingFunction, loopType, onComplete);
        }
    }
}