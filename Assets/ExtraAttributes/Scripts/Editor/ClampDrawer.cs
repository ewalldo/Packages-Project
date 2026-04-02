using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(ClampAttribute))]
    public class ClampDrawer : PropertyDrawer
	{
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Integer && property.propertyType != SerializedPropertyType.Float)
            {
                string errorMessage = "Clamp attribute: Must be used with integer or float property type!";

                Debug.LogError(errorMessage);
                EditorGUI.HelpBox(position, errorMessage, MessageType.Error);
                return;
            }

            ClampAttribute clampAttribute = attribute as ClampAttribute;

            float minValue = clampAttribute.MinValue;
            float maxValue = clampAttribute.MaxValue;

            EditorGUI.BeginProperty(position, label, property);

            if (property.propertyType == SerializedPropertyType.Integer)
                DrawPropertyForInteger((int)minValue, (int)maxValue, position, property, label);
            else if (property.propertyType == SerializedPropertyType.Float)
                DrawPropertyForFloat(minValue, maxValue, position, property, label);

            EditorGUI.EndProperty();
        }

        private void DrawPropertyForInteger(int minValue, int maxValue, Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();

            int newValue = EditorGUI.IntField(position, label, property.intValue);

            if (EditorGUI.EndChangeCheck())
                property.intValue = Mathf.Clamp(newValue, minValue, maxValue);
        }

        private void DrawPropertyForFloat(float minValue, float maxValue, Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();

            float newValue = EditorGUI.FloatField(position, label, property.floatValue);

            if (EditorGUI.EndChangeCheck())
                property.floatValue = Mathf.Clamp(newValue, minValue, maxValue);
        }
    }
}