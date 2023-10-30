using UnityEngine;
using UnityEditor;

namespace TooltipSystem
{
    [CustomEditor(typeof(TooltipTrigger))]
    [CanEditMultipleObjects]
    public class TooltipTriggerEditor : Editor
	{
        private TooltipTrigger tooltipTrigger;

        private SerializedProperty tooltipTriggerStyleProperty;
        private SerializedProperty tooltipTriggerTextsPairProperty;
        private SerializedProperty tooltipTriggerSpritesPairProperty;
        private SerializedProperty tooltipTriggerPositionProperty;
        private SerializedProperty tooltipTriggerTransformProperty;
        private SerializedProperty tooltipTriggerVectorProperty;
        private SerializedProperty tooltipTriggerDelayProperty;

        private GUIStyle labelStyle;

        private void OnEnable()
        {
            tooltipTrigger = target as TooltipTrigger;

            tooltipTriggerStyleProperty = serializedObject.FindProperty(TooltipTrigger.GetNameOfStyle);
            tooltipTriggerTextsPairProperty = serializedObject.FindProperty(TooltipTrigger.GetNameOfTextsPair);
            tooltipTriggerSpritesPairProperty = serializedObject.FindProperty(TooltipTrigger.GetNameOfSpritesPair);
            tooltipTriggerPositionProperty = serializedObject.FindProperty(TooltipTrigger.GetNameOfPosition);
            tooltipTriggerTransformProperty = serializedObject.FindProperty(TooltipTrigger.GetNameOfTransform);
            tooltipTriggerVectorProperty = serializedObject.FindProperty(TooltipTrigger.GetNameOfVector);
            tooltipTriggerDelayProperty = serializedObject.FindProperty(TooltipTrigger.GetNameOfDelay);

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

            EditorGUILayout.PropertyField(tooltipTriggerStyleProperty);

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
                tooltipTrigger.ResetTooltip();
            }

            EditorGUILayout.Space(10f);
            EditorGUI.indentLevel++;
            DrawListTextFields();
            EditorGUILayout.Space(10f);
            DrawListImageFields();
            EditorGUI.indentLevel--;
            EditorGUILayout.Space(10f);

            EditorGUILayout.PropertyField(tooltipTriggerPositionProperty);
            EditorGUI.indentLevel++;
            DrawPositionOptions((TooltipPosition)tooltipTriggerPositionProperty.enumValueIndex);
            EditorGUI.indentLevel--;

            EditorGUILayout.PropertyField(tooltipTriggerDelayProperty);

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawListTextFields()
        {
            if (tooltipTriggerTextsPairProperty.arraySize > 0)
            {
                EditorGUILayout.LabelField("<color=white>Text Fields</color>", labelStyle);
            }

            for (int i = 0; i < tooltipTriggerTextsPairProperty.arraySize; i++)
            {
                SerializedProperty textPairProperty = tooltipTriggerTextsPairProperty.GetArrayElementAtIndex(i);

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(textPairProperty.FindPropertyRelative(IDElementPair<string>.GetNameOfID).stringValue);
                textPairProperty.FindPropertyRelative(IDElementPair<string>.GetNameOfElement).stringValue = EditorGUILayout.TextArea(textPairProperty.FindPropertyRelative(IDElementPair<string>.GetNameOfElement).stringValue, GUILayout.MinHeight(EditorGUIUtility.singleLineHeight * 3f), GUILayout.ExpandHeight(true));
                EditorGUILayout.EndHorizontal();
            }
        }

        private void DrawListImageFields()
        {
            if (tooltipTriggerSpritesPairProperty.arraySize > 0)
            {
                EditorGUILayout.LabelField("<color=white>Image Fields</color>", labelStyle);
            }

            for (int i = 0; i < tooltipTriggerSpritesPairProperty.arraySize; i++)
            {
                SerializedProperty spritePairProperty = tooltipTriggerSpritesPairProperty.GetArrayElementAtIndex(i);

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(spritePairProperty.FindPropertyRelative(IDElementPair<string>.GetNameOfID).stringValue);
                EditorGUILayout.PropertyField(spritePairProperty.FindPropertyRelative(IDElementPair<string>.GetNameOfElement), GUIContent.none);
                EditorGUILayout.EndHorizontal();
            }
        }

        private void DrawPositionOptions(TooltipPosition tooltipPosition)
        {
            switch (tooltipPosition)
            {
                case TooltipPosition.AtMouseCursor:
                    break;
                case TooltipPosition.FollowMouseCursor:
                    break;
                case TooltipPosition.AtTransform:
                    EditorGUILayout.PropertyField(tooltipTriggerTransformProperty, GUIContent.none);
                    break;
                case TooltipPosition.AtVector3:
                    EditorGUILayout.PropertyField(tooltipTriggerVectorProperty, GUIContent.none);
                    break;
                default:
                    break;
            }
        }
    }
}