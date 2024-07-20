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
        /// <param name="headerColor">Color name or its RBG representation in a string format (R, G, B)</param>
        /// <param name="textAnchor">Alignment for the text header</param>
        /// <param name="iconName">Name of the texture in the Resources folder</param>
        public HeaderPlusAttribute(string headerText, string headerColor, TextAnchor textAnchor = TextAnchor.MiddleLeft, string iconName = "")
        {
            HeaderText = headerText;
            HeaderColor = ColorUtils.NameToColor(headerColor);
            HeaderAlignment = textAnchor;
            IconName = iconName;
        }
    }
}