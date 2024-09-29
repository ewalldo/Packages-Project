using TMPro;
using UnityEngine;

namespace Extensions
{
	/// <summary>
	/// Extension methods for TMPro types
	/// </summary>
	public static class TMProExtensions
	{
        /// <summary>
        /// Resize the rectTransform of the TMP_Text to match the text size
        /// </summary>
        /// <param name="text">The TMP_Text component containing the text to match the rectTransform</param>
        /// <param name="shouldResizeHorizontal">Should resize the rectTransform horizontally?</param>
        /// <param name="shouldResizeVertical">Should resize the rectTransform vertically?</param>
        /// <param name="minSize">The minimum size of the rectTransform</param>
        /// <param name="maxSize">The maximum size of the rectTransform</param>
        /// <param name="padding">Amount of padding to be added to the rectTransform</param>
        public static void ResizeRectTransformToMatchText(this TMP_Text text, bool shouldResizeHorizontal, bool shouldResizeVertical, Vector2 minSize, Vector2 maxSize, Vector2 padding)
        {
            if (!shouldResizeHorizontal && !shouldResizeVertical)
                return;

            float minX = shouldResizeHorizontal ? minSize.x : text.rectTransform.rect.width - padding.x;
            float maxX = shouldResizeHorizontal ? maxSize.x : text.rectTransform.rect.width - padding.x;

            float minY = shouldResizeVertical ? minSize.y : text.rectTransform.rect.height - padding.y;
            float maxY = shouldResizeVertical ? maxSize.y : text.rectTransform.rect.height - padding.y;

            Vector2 preferredSize = text.GetPreferredValues(maxX, maxY);
            preferredSize.x = Mathf.Clamp(preferredSize.x, minX, maxX);
            preferredSize.y = Mathf.Clamp(preferredSize.y, minY, maxY);
            preferredSize += padding;

            if (shouldResizeHorizontal)
            {
                text.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, preferredSize.x);
            }

            if (shouldResizeVertical)
            {
                text.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, preferredSize.y);
            }
        }
    }
}