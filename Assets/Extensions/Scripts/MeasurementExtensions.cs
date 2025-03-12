using System;
using UnityEngine;

namespace Extensions
{
    /// <summary>
    /// Extension methods for conversion of measurements
    /// </summary>
	public static class MeasurementExtensions
	{
        #region Length
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