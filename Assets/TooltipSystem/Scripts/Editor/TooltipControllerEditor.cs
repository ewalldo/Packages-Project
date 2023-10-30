using UnityEngine;
using UnityEditor;

namespace TooltipSystem
{
    [CustomEditor(typeof(TooltipController))]
    public class TooltipControllerEditor : Editor
	{
        private TooltipController tooltipController;

        private SerializedProperty tooltipsPrefabProperty;
        private SerializedProperty disableTooltipsProperty;
        private SerializedProperty useFadeInProperty;
        private SerializedProperty fadeInTimeProperty;
        private SerializedProperty useFadeOutProperty;
        private SerializedProperty fadeOutTimeProperty;

        private void OnEnable()
        {
            tooltipController = target as TooltipController;

            tooltipsPrefabProperty = serializedObject.FindProperty(TooltipController.GetNameOfTooltipsPrefab);
            disableTooltipsProperty = serializedObject.FindProperty(TooltipController.GetNameOfDisableTooltips);
            useFadeInProperty = serializedObject.FindProperty(TooltipController.GetNameOfUseFadeIn);
            fadeInTimeProperty = serializedObject.FindProperty(TooltipController.GetNameOfFadeInTime);
            useFadeOutProperty = serializedObject.FindProperty(TooltipController.GetNameOfUseFadeOut);
            fadeOutTimeProperty = serializedObject.FindProperty(TooltipController.GetNameOfFadeOutTime);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(tooltipsPrefabProperty);
            EditorGUILayout.PropertyField(disableTooltipsProperty);

            EditorGUILayout.Space(10f);

            useFadeInProperty.boolValue = EditorGUILayout.ToggleLeft(new GUIContent("Use fade-in", ToggleFadeTooltipMessage("fade-in")), useFadeInProperty.boolValue);
            if (useFadeInProperty.boolValue)
            {
                EditorGUILayout.BeginHorizontal();
                fadeInTimeProperty.floatValue = EditorGUILayout.Slider(fadeInTimeProperty.floatValue, 0.001f, 5f);
                EditorGUILayout.PropertyField(serializedObject.FindProperty(TooltipController.GetNameOfFadeInEasingType), GUIContent.none);
                EditorGUILayout.EndHorizontal();
            }

            useFadeOutProperty.boolValue = EditorGUILayout.ToggleLeft(new GUIContent("Use fade-out", ToggleFadeTooltipMessage("fade-out")), useFadeOutProperty.boolValue);
            if (useFadeOutProperty.boolValue)
            {
                EditorGUILayout.BeginHorizontal();
                fadeOutTimeProperty.floatValue = EditorGUILayout.Slider(fadeOutTimeProperty.floatValue, 0.001f, 5f);
                EditorGUILayout.PropertyField(serializedObject.FindProperty(TooltipController.GetNameOfFadeOutEasingType), GUIContent.none);
                EditorGUILayout.EndHorizontal();
            }

            serializedObject.ApplyModifiedProperties();
        }

        private string ToggleFadeTooltipMessage(string fadeType)
        {
            return $"Should the tooltip {fadeType} or appear instantaneously? (time in seconds)\n" +
                $"NOTE: To use {fadeType}, the tooltip must contain a CanvasGroup component";
        }
    }
}