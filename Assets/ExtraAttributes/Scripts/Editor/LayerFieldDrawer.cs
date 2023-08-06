using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(LayerFieldAttribute))]
    public class LayerFieldDrawer : PropertyDrawer
	{
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Integer)
            {
                string errorMessage = "LayerField attribute: Must be used with integer property type!";

                Debug.LogError(errorMessage);
                EditorGUI.HelpBox(position, errorMessage, MessageType.Error);
                return;
            }

            property.intValue = EditorGUI.LayerField(position, label, property.intValue);
        }
    }
}