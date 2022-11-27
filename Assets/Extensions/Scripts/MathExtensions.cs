using System;

namespace Extensions
{
    /// <summary>
    /// Extension methods for math operations
    /// </summary>
    public static class MathExtensions
    {
        /// <summary>
        /// Returns if the value is within the min and max values
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>Whether the value is within the range</returns>
        public static bool InRange(this int value, int min, int max) => value >= min && value <= max;

        /// <summary>
        /// Normalize a value between 0 and 1
        /// </summary>
        /// <param name="value">The value to be normalized</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>The normalized value</returns>
        public static float Normalize(this float value, float min, float max)
        {
            if (max <= min)
                throw new ArgumentException("Max value should be higher than min value");

            if (value < min || value > max)
                throw new ArgumentException("Value should be in between min and max values");

            return (value - min) / (max - min);
        }

        /// <summary>
        /// Map a value to a new range
        /// </summary>
        /// <param name="value">The value to be mapped</param>
        /// <param name="min">The current minimum range</param>
        /// <param name="max">The current maximum range</param>
        /// <param name="targetMin">The new target minimum range</param>
        /// <param name="targetMax">The new target maximum range</param>
        /// <returns>The mapped value</returns>
        public static float Map(this float value, float min, float max, float targetMin, float targetMax)
        {
            if (max <= min)
                throw new ArgumentException("Max value should be higher than min value");

            if (targetMax <= targetMin)
                throw new ArgumentException("Target max value should be higher than target min value");

            if (value < min || value > max)
                throw new ArgumentException("Value should be in between min and max values");

            return (value - min) * ((targetMax - targetMin) / (max - min)) + targetMin;
        }

        /// <summary>
        /// Return the complement of a value (1 - value)
        /// </summary>
        /// <param name="value">The value to calculate its complement</param>
        /// <returns>The complement of the value</returns>
        public static float Complement(this float value)
        {
            if (value < 0f || value > 1f)
                throw new ArgumentOutOfRangeException(nameof(value), "Value was out of range [0...1]");

            return 1f - value;
        }

        /// <summary>
        /// Inverse the signal of a value
        /// </summary>
        /// <param name="value">The value to inverse</param>
        /// <returns>The inverted value</returns>
        public static float Inverse(this float value) => value * -1;

        /// <summary>
        /// Inverse the signal of a value
        /// </summary>
        /// <param name="value">The value to inverse</param>
        /// <returns>The inverted value</returns>
        public static int Inverse(this int value) => value * -1;
    }
}
