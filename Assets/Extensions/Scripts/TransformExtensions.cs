using System;
using UnityEngine;

namespace Extensions
{
    /// <summary>
    /// Extend methods for transform instances
    /// </summary>
    public static class TransformExtensions
    {
        /// <summary>
        /// Returns the first child transform of a gameObject, returns null if there is no children
        /// </summary>
        /// <param name="transform">The transform to get the child from</param>
        /// <returns>The first child</returns>
        public static Transform FirstChild(this Transform transform)
        {
            if (transform == null)
                throw new ArgumentNullException(nameof(transform));

            if (transform.childCount == 0)
                return null;

            return transform.GetChild(0);
        }

        /// <summary>
        /// Returns the last child transform of a gameObject, returns null if there is no children
        /// </summary>
        /// <param name="transform">The transform to get the child from</param>
        /// <returns>The last child</returns>
        public static Transform LastChild(this Transform transform)
        {
            if (transform == null)
                throw new ArgumentNullException(nameof(transform));

            if (transform.childCount == 0)
                return null;

            return transform.GetChild(transform.childCount - 1);
        }

        /// <summary>
        /// Destroy all children of a transform
        /// </summary>
        /// <param name="transform">The transform to have the children destroyed</param>
        public static void DestroyAllChildren(this Transform transform)
        {
            if (transform == null)
                throw new ArgumentNullException(nameof(transform));

            foreach (Transform child in transform)
            {
                UnityEngine.Object.Destroy(child.gameObject);
            }
        }

        /// <summary>
        /// Activate/deactivate all children of a transform
        /// </summary>
        /// <param name="transform">The transform to have the children activated/deactivated</param>
        /// <param name="status">True activate all the children, false deactivate all of them</param>
        public static void SetActiveAllChildren(this Transform transform, bool status)
        {
            if (transform == null)
                throw new ArgumentNullException(nameof(transform));

            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(status);
            }
        }

        /// <summary>
        /// Reset the transform to its default values
        /// </summary>
        /// <param name="transform">The transform to reset</param>
        /// <param name="isLocal">True if the local values should be reset, false if the global ones</param>
        /// <param name="resetPosition">Should reset the position?</param>
        /// <param name="resetRotation">Should reset the rotation?</param>
        /// <param name="resetScale">Should reset the scale?</param>
        public static void ResetTransform(this Transform transform, bool isLocal = true, bool resetPosition = true, bool resetRotation = true, bool resetScale = true)
        {
            if (transform == null)
                throw new ArgumentNullException(nameof(transform));

            if (resetPosition)
            {
                if (isLocal)
                    transform.localPosition = Vector3.zero;
                else
                    transform.position = Vector3.zero;
            }
            if (resetRotation)
            {
                if (isLocal)
                    transform.localRotation = Quaternion.identity;
                else
                    transform.rotation = Quaternion.identity;
            }
            if (resetScale)
                transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Set the object to a new parent and reset the transform values
        /// </summary>
        /// <param name="child">The transform to be moved</param>
        /// <param name="parent">The parent to be attached to</param>
        /// <param name="resetPosition">Should reset the position?</param>
        /// <param name="resetRotation">Should reset the rotation?</param>
        /// <param name="resetScale">Should reset the scale?</param>
        public static void SetParentAndReset(this Transform child, Transform parent, bool resetPosition = true, bool resetRotation = true, bool resetScale = true)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child));

            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            child.SetParent(parent);
            child.ResetTransform(true, resetPosition, resetRotation, resetScale);
        }

        /// <summary>
        /// Rotate the transform towards a target
        /// </summary>
        /// <param name="transform">The transform to be rotated</param>
        /// <param name="target">The target value to be rotated towards</param>
        /// <param name="speed">The speed of the rotation</param>
        public static void RotateTowards(this Transform transform, Vector3 target, float speed)
        {
            Vector3 direction = (target - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }

        /// <summary>
        /// Calculates the distance of this transform in relation to another one
        /// </summary>
        /// <param name="transform">The transform starting point</param>
        /// <param name="other">The transform end point</param>
        /// <returns>The distance between the two transforms</returns>
        public static float DistanceTo(this Transform transform, Transform other)
        {
            return Vector3.Distance(transform.position, other.position);
        }
    }
}
