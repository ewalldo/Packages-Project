using UnityEngine;

namespace ExtraAttributes
{
	/// <summary>
	/// Attribute used to make a int variable be restricted to a specific range and only be modified by a specific step value (int only)
	/// </summary>
	public class IntRangeWithStepAttribute : PropertyAttribute
	{
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public int Step { get; private set; }

        /// <summary>
        /// Attribute used to make a int variable be restricted to a specific range and only be modified by a specific step value (int only)
        /// </summary>
        /// <param name="minValue">The minimum value for the int</param>
        /// <param name="maxValue">The maximum value for the int</param>
        /// <param name="step">Amount that the value should change</param>
        public IntRangeWithStepAttribute(int minValue, int maxValue, int step)
        {
            MinValue = minValue;
            MaxValue = maxValue;

            if (step <= 0)
            {
                Debug.LogError("IntRangeWithStep attribute: step value cannot be zero or negative, setting step to the default value of 1");
                Step = 1;
            }
            else
            {
                Step = step;
            }
        }
    }
}