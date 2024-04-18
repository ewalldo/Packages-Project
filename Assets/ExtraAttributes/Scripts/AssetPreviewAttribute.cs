using UnityEngine;

namespace ExtraAttributes
{
    /// <summary>
    /// Attribute to display a preview of the asset in the inspector
    /// </summary>
    public class AssetPreviewAttribute : PropertyAttribute
    {
        public int PreviewHeight { get; private set; }

        /// <summary>
        /// Attribute to display a preview of the asset in the inspector
        /// </summary>
        /// <param name="height">The height of the preview</param>
        public AssetPreviewAttribute(int height = 32)
        {
            PreviewHeight = height;
        }
    }
}
