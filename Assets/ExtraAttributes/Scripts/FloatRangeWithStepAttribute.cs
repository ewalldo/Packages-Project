using UnityEngine;

namespace ExtraAttributes
{
	/// <summary>
	/// Attribute used to make a float variable be restricted to a specific range and only be modified by a specific step value (float only)
	/// </summary>
	public class FloatRangeWithStepAttribute : PropertyAttribute
	{
        public float MinValue { get; private set; }
        public float MaxValue { get; private set; }
        public float Step { get; private set; }

        /// <summary>
        /// Attribute used to make a float variable be restricted to a specific range and only be modified by a specific step value (float only)
        /// </summary>
        /// <param name="minValue">The minimum value for the float</param>
        /// <param name="maxValue">The maximum value for the float</param>
        /// <param name="step">Amount that the value should change</param>
        public FloatRangeWithStepAttribute(float minValue, float maxValue, float step)
        {
            MinValue = minValue;
            MaxValue = maxValue;

            if (step <= 0)
            {
                Debug.LogError("FloatRangeWithStep attribute: step value cannot be zero or negative, setting step to the default value of 0.001");
                Step = 0.001f;
            }
            else
            {
                Step = step;
            }
        }
    }
}