using System;
using System.Collections;
using UnityEngine;

namespace Tween
{
	public abstract class BaseTween : ITweener
	{
        protected float duration;
        protected float delay;
        protected EasingFunction easingFunction;
        protected ILoopType loopType;

        public event Action OnComplete;

        public IEnumerator Execute()
        {
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
                TweenValue(progress);

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

        protected abstract bool IsTargetObjectNull();
        protected abstract void TweenValue(float progress);
        protected abstract void AdjustTweenValuesOnLoop();
    }
}