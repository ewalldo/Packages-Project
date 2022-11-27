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
    }
}
