using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Extensions
{
	/// <summary>
	/// Extension methods for string types
	/// </summary>
	public static class StringExtensions
	{
        private static readonly Dictionary<Type, Func<string[], object>> vectorConstructors = new Dictionary<Type, Func<string[], object>>()
        {
            { typeof(Vector2), parts => new Vector2(float.Parse(parts[0]), float.Parse(parts[1])) },
            { typeof(Vector2Int), parts => new Vector2Int(int.Parse(parts[0]), int.Parse(parts[1])) },
            { typeof(Vector3), parts => new Vector3(float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2])) },
            { typeof(Vector3Int), parts => new Vector3Int(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2])) },
            { typeof(Vector4), parts => new Vector4(float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2]), float.Parse(parts[3])) }
        };

        /// <summary>
        /// Checks if a string is null or empty
        /// </summary>
        /// <param name="input">The string to check</param>
        /// <returns>True, if null or empty, false otherwise</returns>
        public static bool IsNullOrEmpty(this string input) => string.IsNullOrEmpty(input);

        /// <summary>
        /// Checks if a string is null or composed of white space
        /// </summary>
        /// <param name="input">The string to check</param>
        /// <returns>True, if null or composed of white spaces, false otherwise</returns>
        public static bool IsNullOrWhiteSpace(this string input) => string.IsNullOrWhiteSpace(input);

        /// <summary>
        /// Checks if a string has a value, i.e. not null, not empty and not white spaces only
        /// </summary>
        /// <param name="input">The string to check</param>
        /// <returns>True, if the string has value, false otherwise</returns>
        public static bool HasValue(this string input) => !(input.IsNullOrEmpty() || input.IsNullOrWhiteSpace());

        /// <summary>
        /// Gets the value of a string or an empty if the string is null
        /// </summary>
        /// <param name="input">The string to get the value from</param>
        /// <returns>The string value or an empty string if null</returns>
        public static string ValueOrEmpty(this string input) => input ?? string.Empty;

        /// <summary>
        /// Converts a string representation to a Vector
        /// </summary>
        /// <typeparam name="T">The type of Vector to convert to (2, 2Int, 3, 3Int, 4)</typeparam>
        /// <param name="input">The string in Vector format (x,y,z) or (x, y, z)</param>
        /// <returns>The Vector representation of the string</returns>
        public static T ToVector<T>(this string input) where T : struct
        {
            string[] values = input.Split(new char[] { '(', ')', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (vectorConstructors.TryGetValue(typeof(T), out Func<string[], object> constructor))
            {
                try
                {
                    return (T)constructor(values);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Error converting string to {typeof(T)}: {ex.Message}", ex);
                }
            }
            else
            {
                throw new ArgumentException($"Unsupported type: {typeof(T)}");
            }
        }

        /// <summary>
        /// Converts a string representation (in RGBA color format "RGBA(r, g, b, a)" or RGB color format "RGB(r, g, b)) to a Color
        /// </summary>
        /// <param name="input">The string in RGBA color format "RGBA(r, g, b, a)" or RGB color format "RGB(r, g, b)"</param>
        /// <returns>The Color representation of the string</returns>
        public static Color ToColor(this string input)
        {
            string[] values = input.Split(new string[] { "RGBA", "RGB", "(", ")", ",", " " }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                if (values.Length == 4)
                    return new Color(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]), float.Parse(values[3]));
                else if (values.Length == 3)
                    return new Color(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]), 1f);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Can't convert string '{input}' to Color: {ex.Message}", ex);
            }

            throw new ArgumentException($"Can't convert string '{input}' to Color");
        }

        /// <summary>
        /// Converts a hex string into a Color
        /// </summary>
        /// <param name="hexInput">The hex string to convert from</param>
        /// <returns>The Color represented by the hex string</returns>
        public static Color FromHexString(this string hexInput)
        {
            if (ColorUtility.TryParseHtmlString(hexInput, out Color color))
                return color;

            throw new ArgumentException($"Can't convert string '{hexInput}' to Color");
        }

        /// <summary>
        /// Gets the file extension of a file in a string format (ex: audio.mp3 will return mp3)
        /// </summary>
        /// <param name="input">The file in a string format</param>
        /// <returns>The corresponding file extension</returns>
        public static string GetFileExtension(this string input)
        {
            string[] values = input.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);

            if (values.Length == 0)
                throw new ArgumentException($"Can't get file extension from string '{input}'");

            return values.Last();
        }

        /// <summary>
        /// Shortens a string to a specified maxLength. If the string is smaller, the original string is returned
        /// </summary>
        /// <param name="input">The string to shorten</param>
        /// <param name="maxLength">The max length of the new string</param>
        /// <returns>The shortened string</returns>
        public static string Shorten(this string input, int maxLength)
        {
            return (input.Length <= maxLength) ? input : input.Substring(0, maxLength);
        }

        /// <summary>
        /// Converts a string to an int value
        /// </summary>
        /// <param name="input">String to be converted</param>
        /// <returns>The int value represented by the string</returns>
        public static int ToInt(this string input)
        {
            if (Int32.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                return result;

            throw new ArgumentException($"Can't convert string '{input}' to Int");
        }

        /// <summary>
        /// Converts a string to a float value
        /// </summary>
        /// <param name="input">String to be converted</param>
        /// <returns>The float value represented by the string</returns>
        public static float ToFloat(this string input)
        {
            if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float result))
                return result;

            throw new ArgumentException($"Can't convert string '{input}' to float");
        }
    }
}