using UnityEngine;

namespace ExtraAttributes
{
	/// <summary>
	/// Attribute used to add a header above fields in the inspector, can be customized with an icon and/or text color
	/// </summary>
	public class HeaderPlusAttribute : PropertyAttribute
	{
        public string HeaderText { get; private set; }
        public Color HeaderColor { get; private set; }
        public string IconName { get; private set; }
        public TextAnchor HeaderAlignment { get; private set; }

        /// <summary>
        /// Attribute used to add a header above fields in the inspector, can be customized with an icon and/or text color
        /// </summary>
        /// <param name="headerText">The text for the header</param>
        /// <param name="headerColor">The color for the text in a float[3] (RGB) or float[4] (RGBA) format</param>
        /// <param name="textAnchor">Alignment for the text header</param>
        /// <param name="iconName">Name of the texture in the Resources folder</param>
        public HeaderPlusAttribute(string headerText, float[] headerColor = null, TextAnchor textAnchor = TextAnchor.MiddleLeft, string iconName = "")
        {
            Color convertedColor = Color.white;
            if (headerColor != null && headerColor.Length >= 3 && headerColor.Length <= 4)
            {
                convertedColor = headerColor.Length == 3 ? new Color(headerColor[0], headerColor[1], headerColor[2], 1) : new Color(headerColor[0], headerColor[1], headerColor[2], headerColor[3]);
            }

            HeaderText = headerText;
            HeaderColor = convertedColor;
            HeaderAlignment = textAnchor;
            IconName = iconName;
        }
    }
}