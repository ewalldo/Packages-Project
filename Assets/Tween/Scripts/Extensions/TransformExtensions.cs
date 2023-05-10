using System;
using UnityEngine;

namespace Tween
{
	public static class TransformExtensions
	{
        // Move

        public static Transform TweenMove(this Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, bool isLocalPosition = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenMove tweenMove = new TweenMove(targetObject, from, to, duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenMove.Execute());

            return targetObject;
        }

        public static Transform TweenMove(this Transform targetObject, Vector3 to, float duration, float delay = 0f, bool isLocalPosition = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalPosition)
                return TweenMove(targetObject, targetObject.localPosition, to, duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
            else
                return TweenMove(targetObject, targetObject.position, to, duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
        }

        public static Transform TweenMoveX(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalPosition = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalPosition)
                return TweenMove(targetObject, new Vector3(from, targetObject.localPosition.y, targetObject.localPosition.z), new Vector3(to, targetObject.localPosition.y, targetObject.localPosition.z), duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
            else
                return TweenMove(targetObject, new Vector3(from, targetObject.position.y, targetObject.position.z), new Vector3(to, targetObject.position.y, targetObject.position.z), duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
        }

        public static Transform TweenMoveX(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalPosition = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalPosition)
                return TweenMove(targetObject, targetObject.localPosition, new Vector3(to, targetObject.localPosition.y, targetObject.localPosition.z), duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
            else
                return TweenMove(targetObject, targetObject.position, new Vector3(to, targetObject.position.y, targetObject.position.z), duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
        }

        public static Transform TweenMoveY(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalPosition = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalPosition)
                return TweenMove(targetObject, new Vector3(targetObject.localPosition.x, from, targetObject.localPosition.z), new Vector3(targetObject.localPosition.x, to, targetObject.localPosition.z), duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
            else
                return TweenMove(targetObject, new Vector3(targetObject.position.x, from, targetObject.position.z), new Vector3(targetObject.position.x, to, targetObject.position.z), duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
        }

        public static Transform TweenMoveY(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalPosition = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalPosition)
                return TweenMove(targetObject, targetObject.localPosition, new Vector3(targetObject.localPosition.x, to, targetObject.localPosition.z), duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
            else
                return TweenMove(targetObject, targetObject.position, new Vector3(targetObject.position.x, to, targetObject.position.z), duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
        }

        public static Transform TweenMoveZ(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalPosition = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalPosition)
                return TweenMove(targetObject, new Vector3(targetObject.localPosition.x, targetObject.localPosition.y, from), new Vector3(targetObject.localPosition.x, targetObject.localPosition.y, to), duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
            else
                return TweenMove(targetObject, new Vector3(targetObject.position.x, targetObject.position.y, from), new Vector3(targetObject.position.x, targetObject.position.y, to), duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
        }

        public static Transform TweenMoveZ(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalPosition = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalPosition)
                return TweenMove(targetObject, targetObject.localPosition, new Vector3(targetObject.localPosition.x, targetObject.localPosition.y, to), duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
            else
                return TweenMove(targetObject, targetObject.position, new Vector3(targetObject.position.x, targetObject.position.y, to), duration, delay, isLocalPosition, easingFunction, loopType, onComplete);
        }

        // Scale

        public static Transform TweenScale(this Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenScale tweenScale = new TweenScale(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenScale.Execute());

            return targetObject;
        }

        public static Transform TweenScale(this Transform targetObject, Vector3 to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenScale(targetObject, targetObject.localScale, to, duration, delay, easingFunction, loopType, onComplete);
        }

        public static Transform TweenScaleX(this Transform targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenScale(targetObject, new Vector3(from, targetObject.localScale.y, targetObject.localScale.z), new Vector3(to, targetObject.localScale.y, targetObject.localScale.z), duration, delay, easingFunction, loopType, onComplete);
        }

        public static Transform TweenScaleX(this Transform targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenScale(targetObject, targetObject.localScale, new Vector3(to, targetObject.localScale.y, targetObject.localScale.z), duration, delay, easingFunction, loopType, onComplete);
        }

        public static Transform TweenScaleY(this Transform targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenScale(targetObject, new Vector3(targetObject.localScale.x, from, targetObject.localScale.z), new Vector3(targetObject.localScale.x, to, targetObject.localScale.z), duration, delay, easingFunction, loopType, onComplete);
        }

        public static Transform TweenScaleY(this Transform targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenScale(targetObject, targetObject.localScale, new Vector3(targetObject.localScale.x, to, targetObject.localScale.z), duration, delay, easingFunction, loopType, onComplete);
        }

        public static Transform TweenScaleZ(this Transform targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenScale(targetObject, new Vector3(targetObject.localScale.x, targetObject.localScale.y, from), new Vector3(targetObject.localScale.x, targetObject.localScale.y, to), duration, delay, easingFunction, loopType, onComplete);
        }

        public static Transform TweenScaleZ(this Transform targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenScale(targetObject, targetObject.localScale, new Vector3(targetObject.localScale.x, targetObject.localScale.y, to), duration, delay, easingFunction, loopType, onComplete);
        }

        // Rotate

        public static Transform TweenRotate(this Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenRotate tweenRotate = new TweenRotate(targetObject, from, to, duration, delay, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenRotate.Execute());

            return targetObject;
        }

        public static Transform TweenRotate(this Transform targetObject, Vector3 to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenRotate(targetObject, targetObject.rotation.eulerAngles, to, duration, delay, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateX(this Transform targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenRotate(targetObject, new Vector3(from, targetObject.rotation.eulerAngles.y, targetObject.rotation.eulerAngles.z), new Vector3(to, targetObject.rotation.eulerAngles.y, targetObject.rotation.eulerAngles.z), duration, delay, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateX(this Transform targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenRotate(targetObject, targetObject.rotation.eulerAngles, new Vector3(to, targetObject.rotation.eulerAngles.y, targetObject.rotation.eulerAngles.z), duration, delay, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateY(this Transform targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenRotate(targetObject, new Vector3(targetObject.rotation.eulerAngles.x, from, targetObject.rotation.eulerAngles.z), new Vector3(targetObject.rotation.eulerAngles.x, to, targetObject.rotation.eulerAngles.z), duration, delay, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateY(this Transform targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenRotate(targetObject, targetObject.rotation.eulerAngles, new Vector3(targetObject.rotation.eulerAngles.x, to, targetObject.rotation.eulerAngles.z), duration, delay, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateZ(this Transform targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenRotate(targetObject, new Vector3(targetObject.rotation.eulerAngles.x, targetObject.rotation.eulerAngles.y, from), new Vector3(targetObject.rotation.eulerAngles.x, targetObject.rotation.eulerAngles.y, to), duration, delay, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateZ(this Transform targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            return TweenRotate(targetObject, targetObject.rotation.eulerAngles, new Vector3(targetObject.rotation.eulerAngles.x, targetObject.rotation.eulerAngles.y, to), duration, delay, easingFunction, loopType, onComplete);
        }
    }
}