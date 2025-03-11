using System;
using UnityEngine;

namespace Extensions
{
    /// <summary>
    /// Extension methods for math operations
    /// </summary>
    public static class MathExtensions
    {
        /// <summary>
        /// Returns true if the value is within the min and max values, false otherwise
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>True if the value is within the range, false otherwise</returns>
        public static bool InRange(this int value, int min, int max) => value >= min && value <= max;

        /// <summary>
        /// Returns true if the value is within the min and max values, false otherwise
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>True if the value is within the range, false otherwise</returns>
        public static bool InRange(this float value, float min, float max) => value >= min && value <= max;

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
        /// Map a value currently in the (<paramref name="min"/>, <paramref name="max"/>) range to a range between (<paramref name="newMin"/>, <paramref name="newMax"/>)
        /// </summary>
        /// <param name="value">The value to be mapped</param>
        /// <param name="min">The current minimum value of the range</param>
        /// <param name="max">The current maximum value of the range</param>
        /// <param name="newMin">The minimum value of the new range</param>
        /// <param name="newMax">The maximum value of the new range</param>
        /// <returns>The mapped value</returns>
        public static float Map(this float value, float min, float max, float newMin, float newMax)
        {
            if (value < min || value > max)
                throw new ArgumentException("Value should be in between min and max values");

            return value.MapUnclamped(min, max, newMin, newMax);
        }

        /// <summary>
        /// Map a value currently in the (<paramref name="min"/>, <paramref name="max"/>) range to a range between (<paramref name="newMin"/>, <paramref name="newMax"/>)
        /// without clamping it.
        /// </summary>
        /// <param name="value">The value to be mapped</param>
        /// <param name="min">The current minimum value of the range</param>
        /// <param name="max">The current maximum value of the range</param>
        /// <param name="newMin">The minimum value of the new range</param>
        /// <param name="newMax">The maximum value of the new range</param>
        /// <returns>The mapped value</returns>
        public static float MapUnclamped(this float value, float min, float max, float newMin, float newMax)
        {
            if (max <= min)
                throw new ArgumentException("Max value should be higher than min value");

            if (newMax <= newMin)
                throw new ArgumentException("Target max value should be higher than target min value");

            return (value - min) * ((newMax - newMin) / (max - min)) + newMin;
        }

        /// <summary>
        /// Map a value currently in the (<paramref name="min"/>, <paramref name="max"/>) range to a range between (<paramref name="newMin"/>, <paramref name="newMax"/>)
        /// and clamp it between <paramref name="newMin"/> and <paramref name="newMax"/>.
        /// </summary>
        /// <param name="value">The value to be mapped</param>
        /// <param name="min">The current minimum value of the range</param>
        /// <param name="max">The current maximum value of the range</param>
        /// <param name="newMin">The minimum value of the new range</param>
        /// <param name="newMax">The maximum value of the new range</param>
        /// <returns>The mapped value</returns>
        public static float MapClamped(this float value, float min, float max, float newMin, float newMax)
        {
            float newValue = value.MapUnclamped(min, max, newMin, newMax);

            return Mathf.Clamp(newValue, newMin, newMax);
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

        /// <summary>
        /// Clamp the value between a min and max
        /// </summary>
        /// <param name="value">The value to be clamped</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>The clamped value</returns>
        public static float Clamp(this float value, float min, float max)
        {
            return Mathf.Clamp(value, min, max);
        }

        /// <summary>
        /// Clamp the value between 0 and 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The clamped value</returns>
        public static float Clamp01(this float value)
        {
            return Mathf.Clamp(value, 0f, 1f);
        }

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
        /// Gets the minimum between two values
        /// </summary>
        /// <param name="a">The first value</param>
        /// <param name="b">The second value</param>
        /// <returns>The minimum between two values</returns>
        public static float Minimum(this float a, float b)
        {
            return (a < b) ? a : b;
        }

        /// <summary>
        /// Gets the minimum value in a set of values
        /// </summary>
        /// <param name="values">The set of values</param>
        /// <returns>The minimum value of the set</returns>
        public static float Minimum(params float[] values)
        {
            if (values.Length <= 0)
                throw new ArgumentException("Values should contain at least one element");

            float min = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                min = min.Minimum(values[i]);
            }

            return min;
        }

        /// <summary>
        /// Gets the maximum between two values
        /// </summary>
        /// <param name="a">The first value</param>
        /// <param name="b">The second value</param>
        /// <returns>The maximum between two values</returns>
        public static float Maximum(this float a, float b)
        {
            return (a > b) ? a : b;
        }

        /// <summary>
        /// Gets the maximum value in a set of values
        /// </summary>
        /// <param name="values">The set of values</param>
        /// <returns>The maximum value of the set</returns>
        public static float Maximum(params float[] values)
        {
            if (values.Length <= 0)
                throw new ArgumentException("Values should contain at least one element");

            float max = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                max = max.Maximum(values[i]);
            }

            return max;
        }

        /// <summary>
        /// Converts a value to its representation in percentage (between 0 and 100%)
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <param name="total">The value which represents 100%</param>
        /// <returns>The value representation in percentage</returns>
        public static float ToPercentage(this float value, float total = 1f)
        {
            if (total <= 0)
                throw new ArgumentOutOfRangeException(nameof(total), "Value should positive and higher than zero.");

            return (value / total) * 100f;
        }

        #region LengthUnitTypes
        private static readonly float METER_VALUE = 1f;
        private static readonly float CENTIMETER_VALUE = 0.01f;
        private static readonly float MILLIMETER_VALUE = 0.001f;
        private static readonly float KILOMETER_VALUE = 1000f;
        private static readonly float INCH_VALUE = 0.0254f;
        private static readonly float FOOT_VALUE = 0.3048f;
        private static readonly float YARD_VALUE = 0.9144f;
        private static readonly float MILE_VALUE = 1609.34f;

        public enum LengthUnitType
        {
            Meter,
            Centimeter,
            Millimeter,
            Kilometer,
            Inch,
            Foot,
            Yard,
            Mile
        }

        /// <summary>
        /// Converts a float value from meters to a specific unit of length
        /// </summary>
        /// <param name="length">The length in meters to convert from</param>
        /// <param name="lengthUnitType">The unit of length to convert to</param>
        /// <returns>Float value representing the distance in the desired unit of length</returns>
        public static float FromMeters(this float length, LengthUnitType lengthUnitType)
        {
            switch (lengthUnitType)
            {
                case LengthUnitType.Meter:
                    return length / METER_VALUE;
                case LengthUnitType.Centimeter:
                    return length / CENTIMETER_VALUE;
                case LengthUnitType.Millimeter:
                    return length / MILLIMETER_VALUE;
                case LengthUnitType.Kilometer:
                    return length / KILOMETER_VALUE;
                case LengthUnitType.Inch:
                    return length / INCH_VALUE;
                case LengthUnitType.Foot:
                    return length / FOOT_VALUE;
                case LengthUnitType.Yard:
                    return length / YARD_VALUE;
                case LengthUnitType.Mile:
                    return length / MILE_VALUE;
                default:
                    throw new ArgumentOutOfRangeException(nameof(lengthUnitType), "Unsupported unit of lengths.");
            }
        }

        /// <summary>
        /// Converts a float value from a specific unit of length to meters
        /// </summary>
        /// <param name="length">The length to convert from</param>
        /// <param name="lengthUnitType">The unit of length to convert from</param>
        /// <returns>Float value representing the distance in meters</returns>
        public static float ToMeters(this float length, LengthUnitType lengthUnitType)
        {
            switch (lengthUnitType)
            {
                case LengthUnitType.Meter:
                    return length * METER_VALUE;
                case LengthUnitType.Centimeter:
                    return length * CENTIMETER_VALUE;
                case LengthUnitType.Millimeter:
                    return length * MILLIMETER_VALUE;
                case LengthUnitType.Kilometer:
                    return length * KILOMETER_VALUE;
                case LengthUnitType.Inch:
                    return length * INCH_VALUE;
                case LengthUnitType.Foot:
                    return length * FOOT_VALUE;
                case LengthUnitType.Yard:
                    return length * YARD_VALUE;
                case LengthUnitType.Mile:
                    return length * MILE_VALUE;
                default:
                    throw new ArgumentOutOfRangeException(nameof(lengthUnitType), "Unsupported unit of lengths.");
            }
        }
        #endregion
    }
}
