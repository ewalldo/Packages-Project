using System;
using System.Collections;
using UnityEngine;

namespace Tween
{
    public class TweenMove : Vector3Tween
	{
        private Transform targetObject;
        private bool isLocalPosition;

        public override event Action OnComplete;

        public TweenMove(Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, bool isLocalPosition = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            this.targetObject = targetObject;
            initialValue = from;
            endValue = to;
            this.duration = duration;
            this.delay = delay;
            this.isLocalPosition = isLocalPosition;
            this.easingFunction = easingFunction == null ? new LinearEasing() : easingFunction;
            this.loopType = loopType;

            OnComplete += onComplete;
        }

        public TweenMove(Transform targetObject, Vector3 to, float duration, float delay = 0f, bool isLocalPosition = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, isLocalPosition ? targetObject.localPosition : targetObject.position, to, duration, delay, isLocalPosition, easingFunction, loopType, onComplete) { }

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
                Vector3 newPosition = Vector3.LerpUnclamped(initialValue, endValue, EasingEquations.Evaluate(easingFunction, progress));

                if (isLocalPosition)
                    targetObject.localPosition = newPosition;
                else
                    targetObject.position = newPosition;

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