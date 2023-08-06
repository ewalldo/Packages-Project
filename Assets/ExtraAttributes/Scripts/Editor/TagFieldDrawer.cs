using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(TagFieldAttribute))]
    public class TagFieldDrawer : PropertyDrawer
	{
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                string errorMessage = "TagField attribute: Must be used with string property type!";

                Debug.LogError(errorMessage);
                EditorGUI.HelpBox(position, errorMessage, MessageType.Error);
                return;
            }

            if (string.IsNullOrEmpty(property.stringValue))
                property.stringValue = UnityEditorInternal.InternalEditorUtility.tags[0];

            property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
        }
    }
}