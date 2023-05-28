using System;
using System.Collections;
using UnityEngine;

namespace Tween
{
	public class TweenRotateVector3 : Vector3Tween
	{
        private Transform targetObject;
        private bool isLocalRotation;

        public override event Action OnComplete;

        public TweenRotateVector3(Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            this.targetObject = targetObject;
            initialValue = from;
            endValue = to;
            this.duration = duration;
            this.delay = delay;
            this.isLocalRotation = isLocalRotation;
            this.easingFunction = easingFunction == null ? new LinearEasing() : easingFunction;
            this.loopType = loopType;

            OnComplete += onComplete;
        }

        public TweenRotateVector3(Transform targetObject, Vector3 to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, isLocalRotation ? targetObject.localRotation.eulerAngles : targetObject.rotation.eulerAngles, to, duration, delay, isLocalRotation, easingFunction, loopType, onComplete) { }

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
                Vector3 newRotation = Vector3.LerpUnclamped(initialValue, endValue, EasingEquations.Evaluate(easingFunction, progress));

                if (isLocalRotation)
                    targetObject.localRotation = Quaternion.Euler(newRotation);
                else
                    targetObject.rotation = Quaternion.Euler(newRotation);

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