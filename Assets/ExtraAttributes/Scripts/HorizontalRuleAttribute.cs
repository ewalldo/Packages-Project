using UnityEngine;

namespace ExtraAttributes
{
    /// <summary>
    /// Draw a horizontal line on the inspector (Similar to the <hr /> tag in HTML)
    /// </summary>
    public class HorizontalRuleAttribute : PropertyAttribute
    {
        public float HRHeight { get; private set; }
        public Color HRColor { get; private set; }

        /// <summary>
        /// Draw a horizontal line on the inspector (Similar to the <hr /> tag in HTML)
        /// </summary>
        /// <param name="rulerHeight">The height of the horizontal line</param>
        /// <param name="rulerColor">The color of the line in a float[3] (RGB) or float[4] (RGBA) format</param>
        public HorizontalRuleAttribute(float rulerHeight = 3f, float[] rulerColor = null)
        {
            Color convertedColor = Color.white;
            if (rulerColor != null && rulerColor.Length >= 3 && rulerColor.Length <= 4)
            {
                convertedColor = rulerColor.Length == 3 ? new Color(rulerColor[0], rulerColor[1], rulerColor[2], 1) : new Color(rulerColor[0], rulerColor[1], rulerColor[2], rulerColor[3]);
            }

            HRHeight = Mathf.Max(0, rulerHeight);
            HRColor = convertedColor;
        }
    }
}
