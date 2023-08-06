using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(IntRangeWithStepAttribute))]
    public class IntRangeWithStepDrawer : PropertyDrawer
	{
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.Integer)
            {
                string errorMessage = "IntRangeWithStep attribute: Must be used with integer property type!";

                Debug.LogError(errorMessage);
                EditorGUI.HelpBox(position, errorMessage, MessageType.Error);
                return;
            }

            IntRangeWithStepAttribute intRangeWithStepAttribute = attribute as IntRangeWithStepAttribute;

            int minValue = intRangeWithStepAttribute.MinValue;
            int maxValue = intRangeWithStepAttribute.MaxValue;
            int step = intRangeWithStepAttribute.Step;

            EditorGUI.BeginChangeCheck();

            int newValue = EditorGUI.IntSlider(position, label, property.intValue, minValue, maxValue);

            if (EditorGUI.EndChangeCheck())
            {
                int distanceFromMin = newValue - minValue;
                int stepsFromMin = Mathf.RoundToInt((float)distanceFromMin / step);
                property.intValue = minValue + stepsFromMin * step;
            }
        }
    }
}