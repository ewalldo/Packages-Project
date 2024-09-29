using System;
using TMPro;
using UnityEngine;

namespace Tween
{
    public class TweenTextFade : FloatTween
	{
        private TMP_Text targetObject;

        public TweenTextFade(TMP_Text targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : base(from, to, duration, delay, easingFunction, loopType, onComplete)
        {
            this.targetObject = targetObject;
        }

        public TweenTextFade(TMP_Text targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.color.a, to, duration, delay, easingFunction, loopType, onComplete) { }

        public TweenTextFade(TMP_Text targetObject, TweenParameters<float> tweenParameters, Action onComplete = null)
            : base(tweenParameters, onComplete)
        {
            this.targetObject = targetObject;
        }

        protected override bool IsTargetObjectNull()
        {
            return targetObject == null;
        }

        protected override void ApplyTween(float newValue)
        {
            newValue = Mathf.Clamp01(newValue);
            targetObject.alpha = newValue;
        }
    }
}