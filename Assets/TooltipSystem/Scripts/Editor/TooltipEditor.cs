using UnityEngine;
using UnityEditor;

namespace TooltipSystem
{
    [CustomEditor(typeof(Tooltip))]
    [CanEditMultipleObjects]
    public class TooltipEditor : Editor
	{
        private Tooltip tooltip;

        private SerializedProperty tooltipStyleProperty;
        private SerializedProperty tooltipTextsPairProperty;
        private SerializedProperty tooltipImagesPairProperty;
        private SerializedProperty tooltipLayoutElementProperty;
        private SerializedProperty tooltipMinTextSizeProperty;
        private SerializedProperty tooltipMaxTextSizeProperty;

        private GUIStyle labelStyle;

        private void OnEnable()
        {
            tooltip = target as Tooltip;

            tooltipStyleProperty = serializedObject.FindProperty(Tooltip.GetNameOfStyle);
            tooltipTextsPairProperty = serializedObject.FindProperty(Tooltip.GetNameOfTextsPair);
            tooltipImagesPairProperty = serializedObject.FindProperty(Tooltip.GetNameOfImagesPair);
            tooltipLayoutElementProperty = serializedObject.FindProperty(Tooltip.GetNameOfLayoutElement);
            tooltipMinTextSizeProperty = serializedObject.FindProperty(Tooltip.GetNameOfMinTextSize);
            tooltipMaxTextSizeProperty = serializedObject.FindProperty(Tooltip.GetNameOfMaxTextSize);

            labelStyle = new GUIStyle()
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = 15,
                richText = true,
                fontStyle = FontStyle.Bold
            };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(tooltipStyleProperty);

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                tooltip.ResetTooltip();
            }

            EditorGUILayout.Space(10f);
            EditorGUI.indentLevel++;
            DrawListTextFields();
            EditorGUILayout.Space(10f);
            DrawListImageFields();
            EditorGUI.indentLevel--;
            EditorGUILayout.Space(10f);

            EditorGUILayout.PropertyField(tooltipLayoutElementProperty);

            EditorGUI.indentLevel++;
            EditorGUI.BeginChangeCheck();
            float minTextSize = EditorGUILayout.FloatField(new GUIContent("Min Text Size"), tooltipMinTextSizeProperty.floatValue);
            float maxTextSize = EditorGUILayout.FloatField(new GUIContent("Max Text Size"), tooltipMaxTextSizeProperty.floatValue);
            if (EditorGUI.EndChangeCheck())
            {
                tooltipMinTextSizeProperty.floatValue = Mathf.Min(minTextSize, maxTextSize);
                tooltipMaxTextSizeProperty.floatValue = Mathf.Max(minTextSize, maxTextSize);
            }
            EditorGUI.indentLevel--;

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawListTextFields()
        {
            if (tooltipTextsPairProperty.arraySize > 0)
            {
                EditorGUILayout.LabelField("<color=white>Text Fields</color>", labelStyle);
            }

            for (int i = 0; i < tooltipTextsPairProperty.arraySize; i++)
            {
                SerializedProperty textPairProperty = tooltipTextsPairProperty.GetArrayElementAtIndex(i);

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(textPairProperty.FindPropertyRelative(IDElementPair<string>.GetNameOfID).stringValue);
                EditorGUILayout.PropertyField(textPairProperty.FindPropertyRelative(IDElementPair<string>.GetNameOfElement), GUIContent.none);
                EditorGUILayout.EndHorizontal();
            }
        }

        private void DrawListImageFields()
        {
            if (tooltipImagesPairProperty.arraySize > 0)
            {
                EditorGUILayout.LabelField("<color=white>Image Fields</color>", labelStyle);
            }

            for (int i = 0; i < tooltipImagesPairProperty.arraySize; i++)
            {
                SerializedProperty imagePairProperty = tooltipImagesPairProperty.GetArrayElementAtIndex(i);

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(imagePairProperty.FindPropertyRelative(IDElementPair<string>.GetNameOfID).stringValue);
                EditorGUILayout.PropertyField(imagePairProperty.FindPropertyRelative(IDElementPair<string>.GetNameOfElement), GUIContent.none);
                EditorGUILayout.EndHorizontal();
            }
        }
    }
}