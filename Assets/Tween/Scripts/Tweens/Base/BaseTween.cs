using System;
using System.Collections;
using UnityEngine;

namespace Tween
{
	public abstract class BaseTween<T> : ITweener
        where T : struct
	{
        protected T initialValue;
        protected T endValue;
        protected float duration;
        protected float delay;
        protected EasingFunction easingFunction;
        protected ILoopType loopType;

        protected T from;
        protected T to;

        public event Action OnComplete;

        public BaseTween(T initialValue, T endValue, float duration, float delay, EasingFunction easingFunction, ILoopType loopType, Action onComplete)
        {
            this.initialValue = initialValue;
            this.endValue = endValue;
            this.duration = duration;
            this.delay = delay;
            this.easingFunction = easingFunction ?? new LinearEasing();
            this.loopType = loopType;

            OnComplete += onComplete;
        }

        public IEnumerator Execute()
        {
            SaveInitialTweenValues();

            int curLoops = 0;

            float progress = 0f;
            float startTime = Time.time + delay;

            while (Time.time < startTime)
                yield return null;

            while (progress < 1f)
            {
                if (IsTargetObjectNull())
                    yield break;

                progress = Mathf.Clamp01((Time.time - startTime) / duration);
                T newValue = TweenValue(progress);
                ApplyTween(newValue);

                yield return null;

                if (progress >= 1f && loopType != null && !loopType.EarlyExitCondition())
                {
                    if (loopType.IsInfiniteLoop || curLoops < loopType.NumLoops)
                    {
                        progress = 0f;
                        loopType.OnOneLoopCompleted?.Invoke();
                        startTime = Time.time + loopType.DelayBetweenLoops;

                        while (Time.time < startTime)
                            yield return null;

                        AdjustTweenValuesOnLoop();

                        if (!loopType.IsInfiniteLoop)
                            curLoops++;
                    }
                }
            }

            OnComplete?.Invoke();
        }

        protected void SaveInitialTweenValues()
        {
            from = initialValue;
            to = endValue;
        }

        protected abstract bool IsTargetObjectNull();
        protected abstract T TweenValue(float progress);
        protected abstract void ApplyTween(T newValue);
        protected abstract void AdjustTweenValuesOnLoop();
    }
}