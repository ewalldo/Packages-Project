using UnityEngine;

namespace ExtraAttributes
{
	/// <summary>
	/// Attribute to add customization to the label part of a field
	/// </summary>
	public class PrettyFieldAttribute : PropertyAttribute
	{
        public string FieldText { get; private set; }
        public Color FieldColor { get; private set; }
        public string IconName { get; private set; }

        /// <summary>
        /// Attribute to add customization to the label part of a field
        /// </summary>
        /// <param name="fieldText">The text for the label</param>
        /// <param name="fieldColor">Color name or its RBG representation in a string format (R, G, B)</param>
        /// <param name="iconName">Name of the texture in the Resources folder</param>
        public PrettyFieldAttribute(string fieldText = "", string fieldColor = "", string iconName = "")
        {
            FieldText = fieldText;
            FieldColor = ColorUtils.NameToColor(fieldColor);
            IconName = iconName;
        }
    }
}