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
                Color mappedColor = ColorUtils.NameToColor(colorNames[i].ToLower());
                string colorName = ColorUtils.ColorToName(mappedColor);
                mappedColors[i] = (mappedColor, colorName);
            }

            return mappedColors;
        }
    }
}