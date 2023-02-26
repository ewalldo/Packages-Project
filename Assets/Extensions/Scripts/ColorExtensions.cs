using UnityEngine;

namespace Extensions
{
    public static class ColorExtensions
	{
		/// <summary>
		/// Converts a Color to a hexadecimal string representation
		/// </summary>
		/// <param name="color">The color to be converted</param>
		/// <returns>The hex string representation of the color</returns>
		public static string ToHexString(this Color color)
		{
			return "#" + ColorUtility.ToHtmlStringRGBA(color);
		}

		/// <summary>
		/// Converts the Color to a hex uint representation
		/// </summary>
		/// <param name="color">The color to be converted</param>
		/// <returns>The uint representation of a color</returns>
		public static uint ToHexUInt(this Color color)
		{
			uint r = (uint)(color.r * 255) << 24;
			uint g = (uint)(color.g * 255) << 16;
			uint b = (uint)(color.b * 255) << 8;
			uint a = (uint)(color.a * 255);
			return r + g + b + a;
		}
	}
}