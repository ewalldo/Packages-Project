using System;
using UnityEngine;

namespace Tween
{
	public static class RendererExtensions
	{
        public static Renderer TweenColor(this Renderer targetObject, Color from, Color to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenRendererColor tweenColor = new TweenRendererColor(targetObject, from, to, duration, delay, materialIndex, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenColor.Execute());

            return targetObject;
        }

        public static Renderer TweenColor(this Renderer targetObject, Color to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenColor(targetObject, targetObject.materials[materialIndex].color, to, duration, delay, materialIndex, easingFunction, loopType, onComplete);
        }

        public static Renderer TweenColor(this Renderer targetObject, TweenParameters<Color> tweenParameters, int materialIndex = 0, Action onComplete = null)
        {
            return TweenColor(targetObject, tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, materialIndex, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete);
        }

        public static Renderer TweenFade(this Renderer targetObject, float from, float to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenRendererFade tweenFade = new TweenRendererFade(targetObject, from, to, duration, delay, materialIndex, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenFade.Execute());

            return targetObject;
        }

        public static Renderer TweenFade(this Renderer targetObject, float to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenFade(targetObject, targetObject.materials[materialIndex].color.a, to, duration, delay, materialIndex, easingFunction, loopType, onComplete);
        }

        public static Renderer TweenFade(this Renderer targetObject, TweenParameters<float> tweenParameters, int materialIndex = 0, Action onComplete = null)
        {
            return TweenFade(targetObject, tweenParameters.GetInitialValue, tweenParameters.GetEndValue, tweenParameters.GetDuration, tweenParameters.GetDelay, materialIndex, tweenParameters.GetEasing, tweenParameters.GetLoop, onComplete);
        }
    }
}