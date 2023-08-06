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
        /// <param name="fieldColor">The color for the text in a float[3] (RGB) or float[4] (RGBA) format</param>
        /// <param name="iconName">Name of the texture in the Resources folder</param>
        public PrettyFieldAttribute(string fieldText = "", float[] fieldColor = null, string iconName = "")
        {
            Color convertedColor = Color.white;
            if (fieldColor != null && fieldColor.Length >= 3 && fieldColor.Length <= 4)
            {
                convertedColor = fieldColor.Length == 3 ? new Color(fieldColor[0], fieldColor[1], fieldColor[2], 1) : new Color(fieldColor[0], fieldColor[1], fieldColor[2], fieldColor[3]);
            }

            FieldText = fieldText;
            FieldColor = convertedColor;
            IconName = iconName;
        }
    }
}