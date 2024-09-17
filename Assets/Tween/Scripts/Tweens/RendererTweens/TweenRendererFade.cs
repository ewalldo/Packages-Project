using System;
using UnityEngine;

namespace Tween
{
	public class TweenRendererFade : FloatTween
	{
        private Renderer targetObject;
        private int materialIndex;

        public TweenRendererFade(Renderer targetObject, float from, float to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : base(from, to, duration, delay, easingFunction, loopType, onComplete)
        {
            if (materialIndex < 0 || materialIndex >= targetObject.materials.Length)
                throw new IndexOutOfRangeException("MaterialIndex was out of range");

            this.targetObject = targetObject;
            this.materialIndex = materialIndex;
        }

        public TweenRendererFade(Renderer targetObject, float to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.materials[materialIndex].color.a, to, duration, delay, materialIndex, easingFunction, loopType, onComplete) { }

        protected override bool IsTargetObjectNull()
        {
            return targetObject == null;
        }

        protected override void ApplyTween(float newValue)
        {
            newValue = Mathf.Clamp01(newValue);
            Color newColor = new Color(targetObject.materials[materialIndex].color.r, targetObject.materials[materialIndex].color.g, targetObject.materials[materialIndex].color.b, newValue);
            targetObject.materials[materialIndex].color = newColor;
        }
    }
}