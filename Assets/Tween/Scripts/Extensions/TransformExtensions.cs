using System;
using UnityEngine;

namespace Tween
{
	public static class TransformExtensions
	{
        #region Position

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

        #endregion

        #region Scale

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

        #endregion

        #region Rotation (Quaternion)

        public static Transform TweenRotate(this Transform targetObject, Quaternion from, Quaternion to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenRotateQuaternion tweenRotate = new TweenRotateQuaternion(targetObject, from, to, duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenRotate.Execute());

            return targetObject;
        }

        public static Transform TweenRotate(this Transform targetObject, Quaternion to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenRotate(targetObject, targetObject.localRotation, to, duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenRotate(targetObject, targetObject.rotation, to, duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateXQuaternion(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenRotate(targetObject, Quaternion.Euler(from, targetObject.localRotation.eulerAngles.y, targetObject.localRotation.eulerAngles.z), Quaternion.Euler(to, targetObject.localRotation.eulerAngles.y, targetObject.localRotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenRotate(targetObject, Quaternion.Euler(from, targetObject.rotation.eulerAngles.y, targetObject.rotation.eulerAngles.z), Quaternion.Euler(to, targetObject.rotation.eulerAngles.y, targetObject.rotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateXQuaternion(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenRotate(targetObject, targetObject.localRotation, Quaternion.Euler(to, targetObject.localRotation.eulerAngles.y, targetObject.localRotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenRotate(targetObject, targetObject.rotation, Quaternion.Euler(to, targetObject.rotation.eulerAngles.y, targetObject.rotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateYQuaternion(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenRotate(targetObject, Quaternion.Euler(targetObject.localRotation.eulerAngles.x, from, targetObject.localRotation.eulerAngles.z), Quaternion.Euler(targetObject.localRotation.eulerAngles.x, to, targetObject.localRotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenRotate(targetObject, Quaternion.Euler(targetObject.rotation.eulerAngles.x, from, targetObject.rotation.eulerAngles.z), Quaternion.Euler(targetObject.rotation.eulerAngles.x, to, targetObject.rotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateYQuaternion(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenRotate(targetObject, targetObject.localRotation, Quaternion.Euler(targetObject.localRotation.eulerAngles.x, to, targetObject.localRotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenRotate(targetObject, targetObject.rotation, Quaternion.Euler(targetObject.rotation.eulerAngles.x, to, targetObject.rotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateZQuaternion(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenRotate(targetObject, Quaternion.Euler(targetObject.localRotation.eulerAngles.x, targetObject.localRotation.eulerAngles.y, from), Quaternion.Euler(targetObject.localRotation.eulerAngles.x, targetObject.localRotation.eulerAngles.y, to), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenRotate(targetObject, Quaternion.Euler(targetObject.rotation.eulerAngles.x, targetObject.rotation.eulerAngles.y, from), Quaternion.Euler(targetObject.rotation.eulerAngles.x, targetObject.rotation.eulerAngles.y, to), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateZQuaternion(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenRotate(targetObject, targetObject.localRotation, Quaternion.Euler(targetObject.localRotation.eulerAngles.x, targetObject.localRotation.eulerAngles.y, to), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenRotate(targetObject, targetObject.rotation, Quaternion.Euler(targetObject.rotation.eulerAngles.x, targetObject.rotation.eulerAngles.y, to), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
        }

        #endregion

        #region Rotation (Vector3)

        public static Transform TweenRotate(this Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (easingFunction == null)
                easingFunction = new LinearEasing();
            TweenRotateVector3 tweenRotate = new TweenRotateVector3(targetObject, from, to, duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenRotate.Execute());

            return targetObject;
        }

        public static Transform TweenRotate(this Transform targetObject, Vector3 to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenRotate(targetObject, targetObject.localRotation.eulerAngles, to, duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenRotate(targetObject, targetObject.rotation.eulerAngles, to, duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateXVector3(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenRotate(targetObject, new Vector3(from, targetObject.localRotation.eulerAngles.y, targetObject.localRotation.eulerAngles.z), new Vector3(to, targetObject.localRotation.eulerAngles.y, targetObject.localRotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenRotate(targetObject, new Vector3(from, targetObject.rotation.eulerAngles.y, targetObject.rotation.eulerAngles.z), new Vector3(to, targetObject.rotation.eulerAngles.y, targetObject.rotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateXVector3(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenRotate(targetObject, targetObject.localRotation.eulerAngles, new Vector3(to, targetObject.localRotation.eulerAngles.y, targetObject.localRotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenRotate(targetObject, targetObject.rotation.eulerAngles, new Vector3(to, targetObject.rotation.eulerAngles.y, targetObject.rotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateYVector3(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenRotate(targetObject, new Vector3(targetObject.localRotation.eulerAngles.x, from, targetObject.localRotation.eulerAngles.z), new Vector3(targetObject.localRotation.eulerAngles.x, to, targetObject.localRotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenRotate(targetObject, new Vector3(targetObject.rotation.eulerAngles.x, from, targetObject.rotation.eulerAngles.z), new Vector3(targetObject.rotation.eulerAngles.x, to, targetObject.rotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateYVector3(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenRotate(targetObject, targetObject.localRotation.eulerAngles, new Vector3(targetObject.localRotation.eulerAngles.x, to, targetObject.localRotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenRotate(targetObject, targetObject.rotation.eulerAngles, new Vector3(targetObject.rotation.eulerAngles.x, to, targetObject.rotation.eulerAngles.z), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateZVector3(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenRotate(targetObject, new Vector3(targetObject.localRotation.eulerAngles.x, targetObject.localRotation.eulerAngles.y, from), new Vector3(targetObject.localRotation.eulerAngles.x, targetObject.localRotation.eulerAngles.y, to), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenRotate(targetObject, new Vector3(targetObject.rotation.eulerAngles.x, targetObject.rotation.eulerAngles.y, from), new Vector3(targetObject.rotation.eulerAngles.x, targetObject.rotation.eulerAngles.y, to), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
        }

        public static Transform TweenRotateZVector3(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalRotation = false, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenRotate(targetObject, targetObject.localRotation.eulerAngles, new Vector3(targetObject.localRotation.eulerAngles.x, targetObject.localRotation.eulerAngles.y, to), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenRotate(targetObject, targetObject.rotation.eulerAngles, new Vector3(targetObject.rotation.eulerAngles.x, targetObject.rotation.eulerAngles.y, to), duration, delay, isLocalRotation, easingFunction, loopType, onComplete);
        }

        #endregion

        #region Shake

        public static Transform TweenShakePosition(this Transform targetObject, Vector3 from, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalPosition = false, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null)
        {
            TweenShakePosition tweenShake = new TweenShakePosition(targetObject, from, direction, duration, delay, speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise, isLocalPosition, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenShake.Execute());

            return targetObject;
        }

        public static Transform TweenShakePosition(this Transform targetObject, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalPosition = false, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null)
        {
            if (isLocalPosition)
                return TweenShakePosition(targetObject, targetObject.localPosition, direction, duration, delay, speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise, isLocalPosition, easingFunction, loopType, onComplete);
            else
                return TweenShakePosition(targetObject, targetObject.position, direction, duration, delay, speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise, isLocalPosition, easingFunction, loopType, onComplete);
        }

        public static Transform TweenShakeRotation(this Transform targetObject, Vector3 from, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalRotation = false, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null)
        {
            TweenShakeRotation tweenShake = new TweenShakeRotation(targetObject, from, direction, duration, delay, speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise, isLocalRotation, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenShake.Execute());

            return targetObject;
        }

        public static Transform TweenShakeRotation(this Transform targetObject, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalRotation = false, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null)
        {
            if (isLocalRotation)
                return TweenShakeRotation(targetObject, targetObject.localRotation.eulerAngles, direction, duration, delay, speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise, isLocalRotation, easingFunction, loopType, onComplete);
            else
                return TweenShakeRotation(targetObject, targetObject.rotation.eulerAngles, direction, duration, delay, speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise, isLocalRotation, easingFunction, loopType, onComplete);
        }

        public static Transform TweenShakeScale(this Transform targetObject, Vector3 from, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null)
        {
            TweenShakeScale tweenShake = new TweenShakeScale(targetObject, from, direction, duration, delay, speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise, easingFunction, loopType, onComplete);
            TweenCoroutineStarter.Instance.StartCoroutine(tweenShake.Execute());

            return targetObject;
        }

        public static Transform TweenShakeScale(this Transform targetObject, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null)
        {
            return TweenShakeScale(targetObject, targetObject.localScale, direction, duration, delay, speed, maxMagnitude, noiseMagnitude, ignoreAxisNoise, easingFunction, loopType, onComplete);
        }

        #endregion
    }
}