using System;
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

		/// <summary>
		/// Returns a new Color with the alpha component replaced
		/// </summary>
		/// <param name="color">The original color</param>
		/// <param name="alpha">The new alpha value</param>
		/// <returns>A new Color with the alpha component replaced</returns>
		public static Color WithAlpha(this Color color, float alpha)
		{
			if (!alpha.InRange(0f, 1f))
				throw new ArgumentException("Alpha value should be between the range [0, 1]");

			return new Color(color.r, color.g, color.b, alpha);
		}

		/// <summary>
		/// Blend two colors based on a specified ratio
		/// </summary>
		/// <param name="color1">The first color of the blend</param>
		/// <param name="color2">The second color of the blend</param>
		/// <param name="ratio">The blend ratio of the colors</param>
		/// <returns>The blended color based on the specified ratio</returns>
		public static Color Blend(this Color color1, Color color2, float ratio)
		{
			if (!ratio.InRange(0f, 1f))
				throw new ArgumentException("Ratio value should be between the range [0, 1]");

			return new Color(
				(color1.r * ratio) + (color2.r * (1 - ratio)),
				(color1.g * ratio) + (color2.g * (1 - ratio)),
				(color1.b * ratio) + (color2.b * (1 - ratio)),
				(color1.a * ratio) + (color2.a * (1 - ratio)));
		}

		/// <summary>
		/// Inverts the color
		/// </summary>
		/// <param name="color">The color to be inverted</param>
		/// <returns>The inverted color</returns>
		public static Color Invert(this Color color)
		{
			return new Color(1 - color.r, 1 - color.g, 1 - color.b, color.a);
		}
	}
}