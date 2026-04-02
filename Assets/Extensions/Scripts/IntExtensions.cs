using System;
using UnityEngine;

namespace Extensions
{
    /// <summary>
    /// Extension methods for int types
    /// </summary>
	public static class IntExtensions
	{
        /// <summary>
        /// Clamp the value between a min and max
        /// </summary>
        /// <param name="value">The value to be clamped</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>The clamped value</returns>
        public static int Clamp(this int value, int min, int max)
        {
            return Mathf.Clamp(value, min, max);
        }

        /// <summary>
        /// Get a random number between min and max (both inclusive) where the probability of said number is biased towards the lower or higher end of the range
        /// </summary>
        /// <param name="min">The mininum possible value for the random number</param>
        /// <param name="max">The maximum possible value for the random number</param>
        /// <param name="power">The probability distribution of the generated number.<br/>
        ///     A value lower than 1 will result in a higher likelihood of larger numbers being generated. The closer to 0, the bigger the chance of a large number.<br/>
        ///     A value higher than 1 will result in a higher likelihood of smaller numbers being generated. The higher the number, the bigger the chance of a smaller number.<br/>
        ///     A value equals to 1 will result in a uniform distribution, where all values are equallly likely to occur.
        /// </param>
        /// <returns>The generated random number</returns>
        public static int GetBiasedRandomNumber(int min, int max, double power = 1)
        {
            if (max <= min)
                throw new ArgumentException("Max value should be higher than min value");

            if (power <= 0)
                throw new ArgumentOutOfRangeException(nameof(power), "Value has to be higher than zero");

            System.Random rand = new System.Random();

            double u = rand.NextDouble();
            double randNum = Math.Floor(min + (max + 1 - min) * (Math.Pow(u, power)));

            return (int)randNum;
        }

        /// <summary>
        /// Returns true if the value is within the min and max values, false otherwise
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>True if the value is within the range, false otherwise</returns>
        public static bool InRange(this int value, int min, int max) => value >= min && value <= max;

        /// <summary>
        /// Inverse the signal of a value
        /// </summary>
        /// <param name="value">The value to inverse</param>
        /// <returns>The inverted value</returns>
        public static int Inverse(this int value) => value * -1;

        /// <summary>
        /// Gets the maximum between two values
        /// </summary>
        /// <param name="a">The first value</param>
        /// <param name="b">The second value</param>
        /// <returns>The maximum between two values</returns>
        public static int Maximum(this int a, int b)
        {
            return (a > b) ? a : b;
        }

        /// <summary>
        /// Gets the maximum value in a set of values
        /// </summary>
        /// <param name="values">The set of values</param>
        /// <returns>The maximum value of the set</returns>
        public static int Maximum(params int[] values)
        {
            if (values.Length <= 0)
                throw new ArgumentException("Values should contain at least one element");

            int max = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                max = max.Maximum(values[i]);
            }

            return max;
        }

        /// <summary>
        /// Gets the minimum between two values
        /// </summary>
        /// <param name="a">The first value</param>
        /// <param name="b">The second value</param>
        /// <returns>The minimum between two values</returns>
        public static int Minimum(this int a, int b)
        {
            return (a < b) ? a : b;
        }

        /// <summary>
        /// Gets the minimum value in a set of values
        /// </summary>
        /// <param name="values">The set of values</param>
        /// <returns>The minimum value of the set</returns>
        public static int Minimum(params int[] values)
        {
            if (values.Length <= 0)
                throw new ArgumentException("Values should contain at least one element");

            int min = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                min = min.Minimum(values[i]);
            }

            return min;
        }
    }
}