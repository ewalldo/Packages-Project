using UnityEngine;

namespace Tween
{
	public static class EasingEquations
	{
        public static float Evaluate(EasingFunction easingFunction, float value, float start = 0f, float end = 1f)
        {
            return easingFunction.Evaluate(start, end, value);
        }

        public static Vector3 Evaluate(EasingFunction easingFunction, float value, Vector3 start, Vector3 end)
        {
            return easingFunction.Evaluate(start, end, value);
        }

        public static Vector4 Evaluate(EasingFunction easingFunction, float value, Vector4 start, Vector4 end)
        {
            return easingFunction.Evaluate(start, end, value);
        }
    }
}