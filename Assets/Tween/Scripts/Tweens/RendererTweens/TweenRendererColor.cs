using System;
using UnityEngine;

namespace Tween
{
	public class TweenRendererColor : ColorTween
    {
        private Renderer targetObject;
        private int materialIndex;

        public TweenRendererColor(Renderer targetObject, Color from, Color to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (materialIndex < 0 || materialIndex >= targetObject.materials.Length)
                throw new IndexOutOfRangeException("MaterialIndex was out of range");

            this.targetObject = targetObject;
            initialValue = from;
            endValue = to;
            this.duration = duration;
            this.delay = delay;
            this.materialIndex = materialIndex;
            this.easingFunction = easingFunction == null ? new LinearEasing() : easingFunction;
            this.loopType = loopType;

            OnComplete += onComplete;
        }

        public TweenRendererColor(Renderer targetObject, Color to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.materials[materialIndex].color, to, duration, delay, materialIndex, easingFunction, loopType, onComplete) { }

        protected override bool IsTargetObjectNull()
        {
            return targetObject == null;
        }

        protected override void ApplyTween(Color newColor)
        {
            targetObject.materials[materialIndex].color = newColor;
        }
    }
}