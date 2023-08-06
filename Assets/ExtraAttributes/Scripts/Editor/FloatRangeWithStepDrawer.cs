using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(FloatRangeWithStepAttribute))]
    public class FloatRangeWithStepDrawer : PropertyDrawer
	{
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Float)
            {
                string errorMessage = "FloatRangeWithStep attribute: Must be used with float property type!";

                Debug.LogError(errorMessage);
                EditorGUI.HelpBox(position, errorMessage, MessageType.Error);
                return;
            }

            FloatRangeWithStepAttribute floatRangeWithStepAttribute = attribute as FloatRangeWithStepAttribute;

            float minValue = floatRangeWithStepAttribute.MinValue;
            float maxValue = floatRangeWithStepAttribute.MaxValue;
            float step = floatRangeWithStepAttribute.Step;

            EditorGUI.BeginChangeCheck();

            float newValue = EditorGUI.Slider(position, label, property.floatValue, minValue, maxValue);

            if (EditorGUI.EndChangeCheck())
            {
                newValue = Mathf.Round(newValue / step) * step;
                property.floatValue = Mathf.Clamp(newValue, minValue, maxValue);
            }
        }
    }
}