using System;
using UnityEngine;

namespace Extensions
{
    public static class ColorExtensions
	{
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
		/// Brighten the color by a specified amount
		/// </summary>
		/// <param name="color">The color to brigthen</param>
		/// <param name="amount">The amount to bright</param>
		/// <returns>The brighten color based on the specified amount</returns>
		public static Color Brighten(this Color color, float amount)
		{
			Color.RGBToHSV(color, out float hue, out float saturation, out float value);
			return Color.HSVToRGB(hue, saturation, Mathf.Clamp01(value + amount)).WithAlpha(color.a);
		}

		/// <summary>
		/// Darken the color by a specified amount
		/// </summary>
		/// <param name="color">The color to darken</param>
		/// <param name="amount">The amount to dark</param>
		/// <returns>The darken color based on the specified amount</returns>
		public static Color Darken(this Color color, float amount)
		{
			return color.Brighten(-amount);
		}

        /// <summary>
        /// Desaturate the color by a specified amount
        /// </summary>
        /// <param name="color">The color to desaturate</param>
        /// <param name="amount">The amount to desaturate</param>
        /// <returns>The desaturated color based on the specified amount</returns>
        public static Color Desaturate(this Color color, float amount)
        {
            return color.Saturate(-amount);
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

        /// <summary>
        /// Saturate the color by a specified amount
        /// </summary>
        /// <param name="color">The color to saturate</param>
        /// <param name="amount">The amount to saturate</param>
        /// <returns>The saturated color based on the specified amount</returns>
        public static Color Saturate(this Color color, float amount)
		{
            Color.RGBToHSV(color, out float hue, out float saturation, out float value);
            return Color.HSVToRGB(hue, Mathf.Clamp01(saturation + amount), value).WithAlpha(color.a);
        }

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
		/// Returns a new Color with the specified components replaced.
		/// </summary>
		/// <param name="color">The original Color</param>
		/// <param name="r">Optional R component. If null, the original R component is used.</param>
		/// <param name="g">Optional G component. If null, the original G component is used.</param>
		/// <param name="b">Optional B component. If null, the original B component is used.</param>
		/// <param name="a">Optional A component. If null, the original A component is used.</param>
		/// <returns>A new Color with the specified components replaced.</returns>
		public static Color With(this Color color, float? r = null, float? g = null, float? b = null, float? a = null)
		{
			return new Color(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);
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

			return color.With(a: alpha);
		}

		/// <summary>
		/// Returns a new Color with the B component replaced.
		/// </summary>
		/// <param name="color">The original Color</param>
		/// <param name="bValue">The new B component.</param>
		/// <returns>A new Color with the B component replaced.</returns>
		public static Color WithBlue(this Color color, float bValue) => color.With(b: bValue);

		/// <summary>
		/// Returns a new Color with the G component replaced.
		/// </summary>
		/// <param name="color">The original Color</param>
		/// <param name="gValue">The new G component.</param>
		/// <returns>A new Color with the G component replaced.</returns>
		public static Color WithGreen(this Color color, float gValue) => color.With(g: gValue);

		/// <summary>
		/// Returns a new Color with the R component replaced.
		/// </summary>
		/// <param name="color">The original Color</param>
		/// <param name="rValue">The new R component.</param>
		/// <returns>A new Color with the R component replaced.</returns>
		public static Color WithRed(this Color color, float rValue) => color.With(r: rValue);
	}
}