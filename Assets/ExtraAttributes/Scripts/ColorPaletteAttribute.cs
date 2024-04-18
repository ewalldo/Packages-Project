using UnityEngine;

namespace ExtraAttributes
{
    /// <summary>
    /// Restrict the color field to a limited set of options (Color only)
    /// </summary>
    public class ColorPaletteAttribute : PropertyAttribute
    {
        public (Color, string)[] Colors { get; private set; }

        /// <summary>
        /// Restrict the color field to a limited set of options (Color only)
        /// </summary>
        /// <param name="colorNames">Color name or its RBG representation in a string format (R, G, B). Ex: [ColorPalette("Red", "Green", "Blue")] or [ColorPalette("(1, 0, 0)", "(0, 1, 0)", "(0, 0, 1)")]</param>
        public ColorPaletteAttribute(params string[] colorNames)
        {
            Colors = StringMappingToColor(colorNames);
        }

        private (Color, string)[] StringMappingToColor(string[] colorNames)
        {
            (Color, string)[] mappedColors = new (Color, string)[colorNames.Length];

            for (int i = 0; i < colorNames.Length; i++)
            {
                switch (colorNames[i].ToLower())
                {
                    case "white":
                        mappedColors[i] = (Color.white, "White");
                        break;
                    case "black":
                        mappedColors[i] = (Color.black, "Black");
                        break;
                    case "red":
                        mappedColors[i] = (Color.red, "Red");
                        break;
                    case "green":
                        mappedColors[i] = (Color.green, "Green");
                        break;
                    case "blue":
                        mappedColors[i] = (Color.blue, "Blue");
                        break;
                    case "cyan":
                        mappedColors[i] = (Color.cyan, "Cyan");
                        break;
                    case "yellow":
                        mappedColors[i] = (Color.yellow, "Yellow");
                        break;
                    case "magenta":
                        mappedColors[i] = (Color.magenta, "Magenta");
                        break;
                    case "gray":
                    case "grey":
                        mappedColors[i] = (Color.gray, "Gray/Grey");
                        break;
                    default:
                        if (!TryConvertStringToColor(colorNames[i].ToLower(), out Color mappedColor))
                        {
                            Debug.LogError("ColorPalette attribute: Can't convert string to color, using the default value of White!");
                        }
                        mappedColors[i] = (mappedColor, mappedColor.ToString());
                        break;
                }
            }

            return mappedColors;
        }

        private bool TryConvertStringToColor(string colorString, out Color colorValue)
        {
            string[] values = colorString.Split('(', ')');
            string[] rgba = values[1].Split(new string[] { ", " }, System.StringSplitOptions.RemoveEmptyEntries);

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