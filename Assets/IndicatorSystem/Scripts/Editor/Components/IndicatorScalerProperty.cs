using UnityEngine;
using UnityEditor;

namespace IndicatorSystem
{
    [CustomPropertyDrawer(typeof(IndicatorScaler))]
    public class IndicatorScalerProperty : PropertyDrawer
	{
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            bool scaleWithRange = property.FindPropertyRelative(IndicatorScaler.GetNameOfScaleWithRange).boolValue;

            if (scaleWithRange)
            {
                return (EditorGUIUtility.singleLineHeight * 6) + (EditorGUIUtility.standardVerticalSpacing * 4);
            }

            return EditorGUIUtility.singleLineHeight * 2;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty scaleWithRangeProperty = property.FindPropertyRelative(IndicatorScaler.GetNameOfScaleWithRange);
            SerializedProperty minScaleDistanceProperty = property.FindPropertyRelative(IndicatorScaler.GetNameOfMinScaleDistance);
            SerializedProperty maxScaleDistanceProperty = property.FindPropertyRelative(IndicatorScaler.GetNameOfMaxScaleDistance);
            SerializedProperty scaleAtMinDistanceProperty = property.FindPropertyRelative(IndicatorScaler.GetNameOfScaleAtMinDistance);
            SerializedProperty scaleAtMaxDistanceProperty = property.FindPropertyRelative(IndicatorScaler.GetNameOfScaleAtMaxDistance);

            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.BeginChangeCheck();

            float curHeight = position.y;

            EditorGUI.LabelField(new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight), property.displayName);
            curHeight += EditorGUIUtility.singleLineHeight;
            EditorGUI.indentLevel++;

            bool scaleWithRange = EditorGUI.ToggleLeft(new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight), "Scale the indicator based on distance?", scaleWithRangeProperty.boolValue);
            curHeight += EditorGUIUtility.singleLineHeight;
            float minScaleDistance = minScaleDistanceProperty.floatValue;
            float maxScaleDistance = maxScaleDistanceProperty.floatValue;
            float scaleAtMinDistance = scaleAtMinDistanceProperty.floatValue;
            float scaleAtMaxDistance = scaleAtMaxDistanceProperty.floatValue;
            if (scaleWithRange)
            {
                curHeight += EditorGUIUtility.standardVerticalSpacing;
                minScaleDistance = EditorGUI.FloatField(new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight), new GUIContent("Minimum distance", "Distance at which the scale will be at the lowest value"), minScaleDistanceProperty.floatValue);
                curHeight += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
                maxScaleDistance = EditorGUI.FloatField(new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight), new GUIContent("Maximum distance", "Distance at which the scale will be at the highest value"), maxScaleDistanceProperty.floatValue);
                curHeight += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;

                scaleAtMinDistance = EditorGUI.FloatField(new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight), new GUIContent("Scale at min distance", "The value of scale at min distance or lower"), scaleAtMinDistanceProperty.floatValue);
                curHeight += EditorGUIUtility.standardVerticalSpacing + EditorGUIUtility.singleLineHeight;
                scaleAtMaxDistance = EditorGUI.FloatField(new Rect(position.x, curHeight, position.width, EditorGUIUtility.singleLineHeight), new GUIContent("Scale at max distance", "The value of scale at max distance of higher"), scaleAtMaxDistanceProperty.floatValue);
            }
            EditorGUI.indentLevel--;

            if (EditorGUI.EndChangeCheck())
            {
                scaleWithRangeProperty.boolValue = scaleWithRange;

                minScaleDistance = Mathf.Max(0, minScaleDistance);
                minScaleDistanceProperty.floatValue = minScaleDistance;

                if (maxScaleDistance < minScaleDistance)
                    maxScaleDistance = minScaleDistance;
                maxScaleDistanceProperty.floatValue = maxScaleDistance;

                scaleAtMinDistanceProperty.floatValue = Mathf.Max(0, scaleAtMinDistance);
                scaleAtMaxDistanceProperty.floatValue = Mathf.Max(0, scaleAtMaxDistance);
            }

            EditorGUI.EndProperty();
        }
    }
}