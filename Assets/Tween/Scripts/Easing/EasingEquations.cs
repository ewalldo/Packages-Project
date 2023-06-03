using UnityEngine;

namespace Tween
{
	public static class EasingEquations
	{
        /// <summary>
        /// Evaluate an <see cref="EasingFunction"/> at a determined <paramref name="value"/>.
        /// </summary>
        /// <param name="easingFunction">The EasingFunction to be evaluated</param>
        /// <param name="value">The value for the easing function</param>
        /// <param name="start">The start point for the easing function</param>
        /// <param name="end">The end point for the easing function</param>
        /// <returns>The evaluated result at the <paramref name="value"/></returns>
        public static float Evaluate(EasingFunction easingFunction, float value, float start = 0f, float end = 1f)
        {
            return easingFunction.Evaluate(start, end, value);
        }

        /// <summary>
        /// Evaluate an <see cref="EasingFunction"/> at a determined <paramref name="value"/>.
        /// </summary>
        /// <param name="easingFunction">The EasingFunction to be evaluated</param>
        /// <param name="value">The value for the easing function</param>
        /// <param name="start">The start point for the easing function</param>
        /// <param name="end">The end point for the easing function</param>
        /// <returns>The evaluated result at the <paramref name="value"/></returns>
        public static Vector3 Evaluate(EasingFunction easingFunction, float value, Vector3 start, Vector3 end)
        {
            return easingFunction.Evaluate(start, end, value);
        }

        /// <summary>
        /// Evaluate an <see cref="EasingFunction"/> at a determined <paramref name="value"/>.
        /// </summary>
        /// <param name="easingFunction">The EasingFunction to be evaluated</param>
        /// <param name="value">The value for the easing function</param>
        /// <param name="start">The start point for the easing function</param>
        /// <param name="end">The end point for the easing function</param>
        /// <returns>The evaluated result at the <paramref name="value"/></returns>
        public static Vector4 Evaluate(EasingFunction easingFunction, float value, Vector4 start, Vector4 end)
        {
            return easingFunction.Evaluate(start, end, value);
        }
    }
}