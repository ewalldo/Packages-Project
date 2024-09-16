using UnityEngine;

namespace IndicatorSystem
{
	public static class LengthUnitTypeExtensions
	{
        private static readonly float METER_VALUE = 1f;
        private static readonly float CENTIMETER_VALUE = 0.01f;
        private static readonly float MILLIMETER_VALUE = 0.001f;
        private static readonly float KILOMETER_VALUE = 1000f;
        private static readonly float INCH_VALUE = 0.0254f;
        private static readonly float FOOT_VALUE = 0.3048f;
        private static readonly float YARD_VALUE = 0.9144f;
        private static readonly float MILE_VALUE = 1609.34f;

        /// <summary>
        /// Get the string representation of the LengthUnitType
        /// </summary>
        /// <param name="lengthUnitType">The LengthUnitType to get the representation from</param>
        /// <returns>The string representation of the type</returns>
        public static string LengthUnitSymbol(this LengthUnitType lengthUnitType)
        {
            switch (lengthUnitType)
            {
                case LengthUnitType.Meter:
                    return "m";
                case LengthUnitType.Centimeter:
                    return "cm";
                case LengthUnitType.Millimeter:
                    return "mm";
                case LengthUnitType.Kilometer:
                    return "km";
                case LengthUnitType.Inch:
                    return "in";
                case LengthUnitType.Foot:
                    return "ft";
                case LengthUnitType.Yard:
                    return "yd";
                case LengthUnitType.Mile:
                    return "mi";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Convert the length from meters to a different LengthUnitType
        /// </summary>
        /// <param name="lengthUnitType">The LengthUnitType to convert to</param>
        /// <param name="length">The length to convert to meters</param>
        /// <returns>The converted length</returns>
        public static float ConvertFromMeters(this LengthUnitType lengthUnitType, float length)
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
                    return 0f;
            }
        }

        /// <summary>
        /// Convert the length from a different LengthUnitType to meters
        /// </summary>
        /// <param name="lengthUnitType">The LengthUnitType to convert from</param>
        /// <param name="length">The length to convert</param>
        /// <returns>The length in meters</returns>
        public static float ConvertToMeters(this LengthUnitType lengthUnitType, float length)
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
                    return 0f;
            }
        }
    }
}