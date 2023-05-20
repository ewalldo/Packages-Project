using UnityEngine;
using TMPro;
using System;
using System.Collections;

namespace Tween
{
	public class TweenTextFade : FloatTween
	{
        private TMP_Text targetObject;

        public override event Action OnComplete;

        public TweenTextFade(TMP_Text targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
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

        public TweenTextFade(TMP_Text targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.color.a, to, duration, delay, easingFunction, loopType, onComplete) { }

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
                float newAlpha = Mathf.LerpUnclamped(initialValue, endValue, EasingEquations.Evaluate(easingFunction, progress));
                newAlpha = Mathf.Clamp01(newAlpha);

                targetObject.alpha = newAlpha;

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