using System;
using UnityEngine;

namespace Tween
{
	public class TweenRendererColor : ColorTween
    {
        private Renderer targetObject;
        private int materialIndex;

        public TweenRendererColor(Renderer targetObject, Color from, Color to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : base(from, to, duration, delay, easingFunction, loopType, onComplete)
        {
            if (materialIndex < 0 || materialIndex >= targetObject.materials.Length)
                throw new IndexOutOfRangeException("MaterialIndex was out of range");

            this.targetObject = targetObject;
            this.materialIndex = materialIndex;
        }

        public TweenRendererColor(Renderer targetObject, Color to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
            : this(targetObject, targetObject.materials[materialIndex].color, to, duration, delay, materialIndex, easingFunction, loopType, onComplete) { }

        public TweenRendererColor(Renderer targetObject, TweenParameters<Color> tweenParameters, int materialIndex = 0, Action onComplete = null)
            : base(tweenParameters, onComplete)
        {
            if (materialIndex < 0 || materialIndex >= targetObject.materials.Length)
                throw new IndexOutOfRangeException("MaterialIndex was out of range");

            this.targetObject = targetObject;
            this.materialIndex = materialIndex;
        }

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