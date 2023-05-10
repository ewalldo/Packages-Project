using System;
using System.Collections;
using UnityEngine;

namespace Tween
{
	public class TweenRendererColor : Vector4Tween
	{
        private Renderer targetObject;

        public override event Action OnComplete;

        public TweenRendererColor(Renderer targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            this.targetObject = targetObject;
            initialValue = from;
            endValue = to;
            this.duration = duration;
            this.delay = delay;
            this.easingFunction = easingFunction == null ? new LinearEasing() : easingFunction;
            this.loopType = loopType;

            OnComplete += onComplete;
        }

        public TweenRendererColor(Renderer targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.material.color, to, duration, delay, easingFunction, loopType, onComplete) { }

        public override IEnumerator Execute()
        {
            int curLoops = 0;

            float progress = 0f;
            float startTime = Time.time + delay;

            while (Time.time < startTime)
                yield return null;

            while (progress < 1f)
            {
                if (targetObject == null)
                    yield break;

                progress = Mathf.Clamp01((Time.time - startTime) / duration);
                Vector4 newColor = EasingEquations.Evaluate(easingFunction, progress, initialValue, endValue);
                newColor = new Vector4(Mathf.Clamp01(newColor.x), Mathf.Clamp01(newColor.y), Mathf.Clamp01(newColor.z), Mathf.Clamp01(newColor.w));

                targetObject.material.color = newColor;

                yield return null;

                if (progress >= 1f && loopType != null && !loopType.EarlyExitCondition())
                {
                    if (loopType.IsInfiniteLoop || curLoops < loopType.NumLoops)
                    {
                        progress = 0f;
                        startTime = Time.time + loopType.DelayBetweenLoops;

                        while (Time.time < startTime)
                            yield return null;

                        (initialValue, endValue) = loopType.AdjustTweenValues(initialValue, endValue);

                        if (!loopType.IsInfiniteLoop)
                            curLoops++;
                    }
                }
            }

            OnComplete?.Invoke();
        }
    }
}