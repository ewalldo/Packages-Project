using System;
using System.Collections.Generic;
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
            string[] values = input.Split(new string[] { "RGB", "RGBA", "(", ")", ",", " " }, StringSplitOptions.RemoveEmptyEntries);

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
    }
}