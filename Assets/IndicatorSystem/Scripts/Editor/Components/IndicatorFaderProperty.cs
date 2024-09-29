using UnityEngine;
using UnityEditor;

namespace IndicatorSystem
{
    [CustomPropertyDrawer(typeof(IndicatorFader))]
    public class IndicatorFaderProperty : PropertyDrawer
	{
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            bool fadeWithRange = property.FindPropertyRelative(IndicatorFader.GetNameOfFadeWithRange).boolValue;

            if (fadeWithRange)
            {
                return (EditorGUIUtility.singleLineHeight * 6) + (EditorGUIUtility.standardVerticalSpacing * 4);
            }

            return EditorGUIUtility.singleLineHeight * 2;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty fadeWithRangeProperty = property.FindPropertyRelative(IndicatorFader.GetNameOfFadeWithRange);
            SerializedProperty minAlphaDistanceProperty = property.FindPropertyRelative(IndicatorFader.GetNameOfMinAlphaDistance);
            SerializedProperty maxAlphaDistanceProperty = property.FindPropertyRelative(IndicatorFader.GetNameOfMaxAlphaDistance);
            SerializedProperty alphaAtMinDistanceProperty = property.FindPropertyRelative(IndicatorFader.GetNameOfAlphaAtMinDistance);
            SerializedProperty alphaAtMaxDistanceProperty = property.FindPropertyRelative(IndicatorFader.GetNameOfAlphaAtMaxDistance);

            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.BeginChangeCheck();

            float curHeight = position.y;

            EditorGUI.LabelField(new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight), property.displayName);
            curHeight += EditorGUIUtility.singleLineHeight;
            EditorGUI.indentLevel++;

            bool fadeWithRange = EditorGUI.ToggleLeft(new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight), "Fade the indicator based on distance?", fadeWithRangeProperty.boolValue);
            curHeight += EditorGUIUtility.singleLineHeight;
            float minAlphaDistance = minAlphaDistanceProperty.floatValue;
            float maxAlphaDistance = maxAlphaDistanceProperty.floatValue;
            float alphaAtMinDistance = alphaAtMinDistanceProperty.floatValue;
            float alphaAtMaxDistance = alphaAtMaxDistanceProperty.floatValue;
            if (fadeWithRange)
            {
                curHeight += EditorGUIUtility.standardVerticalSpacing;
                minAlphaDistance = EditorGUI.FloatField(new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight), new GUIContent("Minimum distance", "Distance at which the alpha will be at the lowest value"), minAlphaDistanceProperty.floatValue);
                curHeight += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
                maxAlphaDistance = EditorGUI.FloatField(new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight), new GUIContent("Maximum distance", "Distance at which the alpha will be at the highest value"), maxAlphaDistanceProperty.floatValue);
                curHeight += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;

                alphaAtMinDistance = EditorGUI.FloatField(new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight), new GUIContent("Alpha at min distance", "The value of alpha at min distance or lower"), alphaAtMinDistanceProperty.floatValue);
                curHeight += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
                alphaAtMaxDistance = EditorGUI.FloatField(new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight), new GUIContent("Alpha at max distance", "The value of alpha at max distance of higher"), alphaAtMaxDistanceProperty.floatValue);
            }
            EditorGUI.indentLevel--;

            if (EditorGUI.EndChangeCheck())
            {
                fadeWithRangeProperty.boolValue = fadeWithRange;

                minAlphaDistance = Mathf.Max(0, minAlphaDistance);
                minAlphaDistanceProperty.floatValue = minAlphaDistance;

                if (maxAlphaDistance < minAlphaDistance)
                    maxAlphaDistance = minAlphaDistance;
                maxAlphaDistanceProperty.floatValue = maxAlphaDistance;

                alphaAtMinDistanceProperty.floatValue = Mathf.Clamp01(alphaAtMinDistance);
                alphaAtMaxDistanceProperty.floatValue = Mathf.Clamp01(alphaAtMaxDistance);
            }

            EditorGUI.EndProperty();
        }
    }
}