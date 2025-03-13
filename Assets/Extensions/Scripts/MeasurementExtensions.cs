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
            return lengthUnitType switch
            {
                LengthUnitType.Meter => length / METER_VALUE,
                LengthUnitType.Centimeter => length / CENTIMETER_VALUE,
                LengthUnitType.Millimeter => length / MILLIMETER_VALUE,
                LengthUnitType.Kilometer => length / KILOMETER_VALUE,
                LengthUnitType.Inch => length / INCH_VALUE,
                LengthUnitType.Foot => length / FOOT_VALUE,
                LengthUnitType.Yard => length / YARD_VALUE,
                LengthUnitType.Mile => length / MILE_VALUE,
                _ => throw new ArgumentOutOfRangeException(nameof(lengthUnitType), "Unsupported unit of length."),
            };
        }

        /// <summary>
        /// Converts a float value from a specific unit of length to meters
        /// </summary>
        /// <param name="length">The length to convert from</param>
        /// <param name="lengthUnitType">The unit of length to convert from</param>
        /// <returns>Float value representing the distance in meters</returns>
        public static float ToMeters(this float length, LengthUnitType lengthUnitType)
        {
            return lengthUnitType switch
            {
                LengthUnitType.Meter => length * METER_VALUE,
                LengthUnitType.Centimeter => length * CENTIMETER_VALUE,
                LengthUnitType.Millimeter => length * MILLIMETER_VALUE,
                LengthUnitType.Kilometer => length * KILOMETER_VALUE,
                LengthUnitType.Inch => length * INCH_VALUE,
                LengthUnitType.Foot => length * FOOT_VALUE,
                LengthUnitType.Yard => length * YARD_VALUE,
                LengthUnitType.Mile => length * MILE_VALUE,
                _ => throw new ArgumentOutOfRangeException(nameof(lengthUnitType), "Unsupported unit of length."),
            };
        }
        #endregion

        #region Temperature
        private static readonly float KELVIN_VALUE = 273.15f;

        public enum TemperatureUnitType
        {
            Celsius,
            Fahrenheit,
            Kelvin
        }

        /// <summary>
        /// Converts a float value from celsius to a specific unit of temperature
        /// </summary>
        /// <param name="temperature">The temperature in celsius to convert from</param>
        /// <param name="temperatureUnitType">The unit of temperature to convert to</param>
        /// <returns>Float value representing the temperature in the desired unit</returns>
        public static float FromCelsius(this float temperature, TemperatureUnitType temperatureUnitType)
        {
            return temperatureUnitType switch
            {
                TemperatureUnitType.Celsius => temperature,
                TemperatureUnitType.Fahrenheit => (temperature * 9 / 5f) + 32,
                TemperatureUnitType.Kelvin => temperature + KELVIN_VALUE,
                _ => throw new ArgumentOutOfRangeException(nameof(temperatureUnitType), "Unsupported unit of temperature."),
            };
        }

        /// <summary>
        /// Converts a float value from a specific unit of temperature to celsius
        /// </summary>
        /// <param name="temperature">The temperature to convert from</param>
        /// <param name="temperatureUnitType">The unit of temperature to convert from</param>
        /// <returns>Float value representing the temperature in celsius</returns>
        public static float ToCelsius(this float temperature, TemperatureUnitType temperatureUnitType)
        {
            return temperatureUnitType switch
            {
                TemperatureUnitType.Celsius => temperature,
                TemperatureUnitType.Fahrenheit => (temperature - 32) * 5 / 9f,
                TemperatureUnitType.Kelvin => temperature - KELVIN_VALUE,
                _ => throw new ArgumentOutOfRangeException(nameof(temperatureUnitType), "Unsupported unit of temperature."),
            };
        }
        #endregion

        #region Mass
        private static readonly float KILOGRAM_VALUE = 1f;
        private static readonly float GRAM_VALUE = 1000f;
        private static readonly float MILLIGRAM_VALUE = 1000000f;
        private static readonly float TONNE_VALUE = 0.001f;
        private static readonly float POUND_VALUE = 2.2046226218f;
        private static readonly float OUNCE_VALUE = 35.27396195f;

        public enum MassUnitType
        {
            Kilogram,
            Gram,
            Milligram,
            Tonne,
            Pound,
            Ounce
        }

        /// <summary>
        /// Converts a float value from kilograms to a specific unit of mass
        /// </summary>
        /// <param name="mass">The mass in kilograms to convert from</param>
        /// <param name="massUnitType">The unit of mass to convert to</param>
        /// <returns>Float value representing the weight in the desired unit of mass</returns>
        public static float FromKilograms(this float mass, MassUnitType massUnitType)
        {
            return massUnitType switch
            {
                MassUnitType.Kilogram => mass * KILOGRAM_VALUE,
                MassUnitType.Gram => mass * GRAM_VALUE,
                MassUnitType.Milligram => mass * MILLIGRAM_VALUE,
                MassUnitType.Tonne => mass * TONNE_VALUE,
                MassUnitType.Pound => mass * POUND_VALUE,
                MassUnitType.Ounce => mass * OUNCE_VALUE,
                _ => throw new ArgumentOutOfRangeException(nameof(massUnitType), "Unsupported unit of mass."),
            };
        }

        /// <summary>
        /// Converts a float value from a specific unit of mass to kilograms
        /// </summary>
        /// <param name="mass">The weight to convert from</param>
        /// <param name="massUnitType">The unit of mass to convert from</param>
        /// <returns>Float value representing the weight in kilograms</returns>
        public static float ToKilograms(this float mass, MassUnitType massUnitType)
        {
            return massUnitType switch
            {
                MassUnitType.Kilogram => mass / KILOGRAM_VALUE,
                MassUnitType.Gram => mass / GRAM_VALUE,
                MassUnitType.Milligram => mass / MILLIGRAM_VALUE,
                MassUnitType.Tonne => mass / TONNE_VALUE,
                MassUnitType.Pound => mass / POUND_VALUE,
                MassUnitType.Ounce => mass / OUNCE_VALUE,
                _ => throw new ArgumentOutOfRangeException(nameof(massUnitType), "Unsupported unit of mass."),
            };
        }
        #endregion

        #region Speed
        private static readonly float METERSSECOND_VALUE = 1f;
        private static readonly float KILOMETERSHOUR_VALUE = 3.6f;
        private static readonly float MILESHOUR_VALUE = 2.2369362921f;

        public enum SpeedUnitType
        {
            MetersSecond,
            KilometersHour,
            MilesHour,
        }

        /// <summary>
        /// Converts a float value from meters per second to a specific unit of speed
        /// </summary>
        /// <param name="speed">The speed in meters per second to convert from</param>
        /// <param name="speedUnitType">The unit of speed to convert to</param>
        /// <returns>Float value representing the velocity in the desired unit of speed</returns>
        public static float FromMetersSecond(this float speed, SpeedUnitType speedUnitType)
        {
            return speedUnitType switch
            {
                SpeedUnitType.MetersSecond => speed * METERSSECOND_VALUE,
                SpeedUnitType.KilometersHour => speed * KILOMETERSHOUR_VALUE,
                SpeedUnitType.MilesHour => speed * MILESHOUR_VALUE,
                _ => throw new ArgumentOutOfRangeException(nameof(speedUnitType), "Unsupported unit of speed."),
            };
        }

        /// <summary>
        /// Converts a float value from a specific unit of speed to meters per second
        /// </summary>
        /// <param name="speed">The speed to convert from</param>
        /// <param name="speedUnitType">The unit of speed to convert from</param>
        /// <returns>Float value representing the speed in meters per second</returns>
        public static float ToMetersSecond(this float speed, SpeedUnitType speedUnitType)
        {
            return speedUnitType switch
            {
                SpeedUnitType.MetersSecond => speed / METERSSECOND_VALUE,
                SpeedUnitType.KilometersHour => speed / KILOMETERSHOUR_VALUE,
                SpeedUnitType.MilesHour => speed / MILESHOUR_VALUE,
                _ => throw new ArgumentOutOfRangeException(nameof(speedUnitType), "Unsupported unit of speed."),
            };
        }
        #endregion

        #region Time
        private static readonly float SECONDS_VALUE = 1f;
        private static readonly float MILLISECONDS_VALUE = 0.001f;
        private static readonly float MINUTE_VALUE = 60f;
        private static readonly float HOUR_VALUE = 3600f;
        private static readonly float DAY_VALUE = 86400f;
        private static readonly float WEEK_VALUE = 604800f;
        private static readonly float MONTH_VALUE = 2628000f;
        private static readonly float YEAR_VALUE = 31557600f;

        public enum TimeUnitType
        {
            Seconds,
            Milliseconds,
            Minute,
            Hour,
            Day,
            Week,
            Month,
            Year
        }

        /// <summary>
        /// Converts a float value from seconds to a specific unit of time
        /// </summary>
        /// <param name="time">The time in seconds to convert from</param>
        /// <param name="timeUnitType">The unit of time to convert to</param>
        /// <returns>Float value representing the time in the desired unit of time</returns>
        public static float FromSeconds(this float time, TimeUnitType timeUnitType)
        {
            return timeUnitType switch
            {
                TimeUnitType.Seconds => time / SECONDS_VALUE,
                TimeUnitType.Milliseconds => time / MILLISECONDS_VALUE,
                TimeUnitType.Minute => time / MINUTE_VALUE,
                TimeUnitType.Hour => time / HOUR_VALUE,
                TimeUnitType.Day => time / DAY_VALUE,
                TimeUnitType.Week => time / WEEK_VALUE,
                TimeUnitType.Month => time / MONTH_VALUE,
                TimeUnitType.Year => time / YEAR_VALUE,
                _ => throw new ArgumentOutOfRangeException(nameof(timeUnitType), "Unsupported unit of time."),
            };
        }

        /// <summary>
        /// Converts a float value from a specific unit of time to seconds
        /// </summary>
        /// <param name="time">The time to convert from</param>
        /// <param name="timeUnitType">The unit of time to convert from</param>
        /// <returns>Float value representing the time in seconds</returns>
        public static float ToSeconds(this float time, TimeUnitType timeUnitType)
        {
            return timeUnitType switch
            {
                TimeUnitType.Seconds => time * SECONDS_VALUE,
                TimeUnitType.Milliseconds => time * MILLISECONDS_VALUE,
                TimeUnitType.Minute => time * MINUTE_VALUE,
                TimeUnitType.Hour => time * HOUR_VALUE,
                TimeUnitType.Day => time * DAY_VALUE,
                TimeUnitType.Week => time * WEEK_VALUE,
                TimeUnitType.Month => time * MONTH_VALUE,
                TimeUnitType.Year => time * YEAR_VALUE,
                _ => throw new ArgumentOutOfRangeException(nameof(timeUnitType), "Unsupported unit of time."),
            };
        }
        #endregion
    }
}