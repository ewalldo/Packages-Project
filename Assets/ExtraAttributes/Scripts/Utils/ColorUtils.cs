using System;
using UnityEngine;

namespace ExtraAttributes
{
	public static class ColorUtils
	{
        /// <summary>
        /// Converts a strings to its color representation
        /// </summary>
        /// <param name="colorName">The color in a string format</param>
        /// <returns>The corresponding color of the string</returns>
        public static Color NameToColor(string colorName)
        {
            switch (colorName.ToLower())
            {
                case "white":
                    return Color.white;
                case "black":
                    return Color.black;
                case "red":
                    return Color.red;
                case "green":
                    return Color.green;
                case "blue":
                    return Color.blue;
                case "cyan":
                    return Color.cyan;
                case "yellow":
                    return Color.yellow;
                case "magenta":
                    return Color.magenta;
                case "gray":
                case "grey":
                    return Color.gray;
                default:
                    if (!TryConvertStringToColor(colorName.ToLower(), out Color mappedColor))
                    {
                        Debug.LogError("ColorPalette attribute: Can't convert string to color, using the default value of White!");
                    }
                    return mappedColor;
            }
        }

        /// <summary>
        /// Convert a color to its string representation
        /// </summary>
        /// <param name="color">The color to get the name from</param>
        /// <returns>The string representation of the color</returns>
        public static string ColorToName(Color color)
        {
            if (color == Color.white)
            {
                return "White";
            }
            else if (color == Color.black)
            {
                return "Black";
            }
            else if (color == Color.red)
            {
                return "Red";
            }
            else if (color == Color.green)
            {
                return "Green";
            }
            else if (color == Color.blue)
            {
                return "Blue";
            }
            else if (color == Color.cyan)
            {
                return "Cyan";
            }
            else if (color == Color.yellow)
            {
                return "Yellow";
            }
            else if (color == Color.magenta)
            {
                return "Magenta";
            }
            else if (color == Color.gray)
            {
                return "Gray/Grey";
            }

            return color.ToString();
        }

        private static bool TryConvertStringToColor(string colorString, out Color colorValue)
        {
            string[] rgba = colorString.Split(new string[] { "(", ")", ",", " " }, StringSplitOptions.RemoveEmptyEntries);

            if (rgba.Length == 3)
            {
                colorValue = new Color(float.Parse(rgba[0]), float.Parse(rgba[1]), float.Parse(rgba[2]), 1);
                return true;
            }
            else if (rgba.Length == 4)
            {
                colorValue = new Color(float.Parse(rgba[0]), float.Parse(rgba[1]), float.Parse(rgba[2]), float.Parse(rgba[3]));
                return true;
            }
            else
            {
                colorValue = Color.white;
                return false;
            }
        }
    }
}