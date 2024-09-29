using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(AssetPreviewAttribute))]
    public class AssetPreviewDrawer : PropertyDrawer
    {
        private const int SPACING = 5;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.ObjectReference && property.objectReferenceValue == null)
            {
                return base.GetPropertyHeight(property, label) * 2;
            }

            return base.GetPropertyHeight(property, label) + SPACING + GetPreviewHeight();
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            AssetPreviewAttribute assetPreviewAttribute = attribute as AssetPreviewAttribute;

            if (property.propertyType == SerializedPropertyType.ObjectReference && property.objectReferenceValue == null)
            {
                float halfPropertySize = GetPropertyHeight(property, label) / 2f;

                EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, halfPropertySize), property, label);
                Rect helpBoxRect = new Rect(position.x, position.y + halfPropertySize, position.width, halfPropertySize);
                EditorGUI.HelpBox(helpBoxRect, "Can't show asset preview on a null field!", MessageType.Warning);
            }
            else
            {
                EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), property, label);

                Rect previewRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + SPACING, position.width, assetPreviewAttribute.PreviewHeight);
                Texture2D previewTexture = GetPreviewTexture(property);
                GUI.Label(previewRect, previewTexture);
            }

            EditorGUI.EndProperty();
        }

        private float GetPreviewHeight()
        {
            AssetPreviewAttribute assetPreviewAttribute = attribute as AssetPreviewAttribute;

            return assetPreviewAttribute.PreviewHeight;
        }

        private Texture2D GetPreviewTexture(SerializedProperty property)
        {
            return AssetPreview.GetAssetPreview(property.objectReferenceValue);
        }
    }
}
