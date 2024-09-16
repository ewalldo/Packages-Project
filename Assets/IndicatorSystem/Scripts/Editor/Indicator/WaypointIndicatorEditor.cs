using UnityEngine;
using UnityEditor;

namespace IndicatorSystem
{
	[CanEditMultipleObjects]
    [CustomEditor(typeof(WaypointIndicator))]
    public class WaypointIndicatorEditor : IndicatorEditor
	{
        private SerializedProperty uiIndicatorPrefabProperty;

        private SerializedProperty showDistanceTextWhileOnScreenProperty;
        private SerializedProperty showDistanceTextWhileOffScreenProperty;
        private SerializedProperty showIndicatorTextWhileOnScreenProperty;
        private SerializedProperty showIndicatorTextWhileOffScreenProperty;
        private SerializedProperty indicatorTextProperty;

        protected override void OnEnable()
        {
            base.OnEnable();

            uiIndicatorPrefabProperty = serializedObject.FindProperty(WaypointIndicator.GetNameOfUIIndicatorPrefab);

            showDistanceTextWhileOnScreenProperty = serializedObject.FindProperty(WaypointIndicator.GetNameOfShowDistanceTextWhileOnScreen);
            showDistanceTextWhileOffScreenProperty = serializedObject.FindProperty(WaypointIndicator.GetNameOfShowDistanceTextWhileOffScreen);
            showIndicatorTextWhileOnScreenProperty = serializedObject.FindProperty(WaypointIndicator.GetNameOfShowIndicatorTextWhileOnScreen);
            showIndicatorTextWhileOffScreenProperty = serializedObject.FindProperty(WaypointIndicator.GetNameOfShowIndicatorTextWhileOffScreen);
            indicatorTextProperty = serializedObject.FindProperty(WaypointIndicator.GetNameOfIndicatorText);
        }

        public override void OnInspectorGUI()
        {
            using (new EditorGUI.DisabledScope(true))
                EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((MonoBehaviour)target), GetType(), false);

            EditorGUILayout.Space(10);

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("<color=white>UI Indicator prefab</color>", new GUIStyle { fontStyle = FontStyle.Bold });
            EditorGUI.indentLevel++;
            UIWaypointIndicator uiWaypointIdicator = (UIWaypointIndicator)EditorGUILayout.ObjectField(uiIndicatorPrefabProperty.objectReferenceValue, typeof(UIWaypointIndicator), true);
            EditorGUI.indentLevel--;

            if (EditorGUI.EndChangeCheck())
            {
                uiIndicatorPrefabProperty.objectReferenceValue = uiWaypointIdicator;

                serializedObject.ApplyModifiedProperties();
            }

            EditorGUILayout.Space(10);

            base.OnInspectorGUI();

            EditorGUILayout.Space(10);

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("<color=white>Text options</color>", new GUIStyle { fontStyle = FontStyle.Bold });
            EditorGUI.indentLevel++;
            bool showDistanceTextWhileOnScreen = EditorGUILayout.ToggleLeft("Display distance text while indicator is on screen", showDistanceTextWhileOnScreenProperty.boolValue);
            bool showIndicatorTextWhileOnScreen = EditorGUILayout.ToggleLeft("Display indicator text while indicator is on screen", showIndicatorTextWhileOnScreenProperty.boolValue);

            bool showDistanceTextWhileOffScreen = EditorGUILayout.ToggleLeft("Display distance text while indicator is off screen", showDistanceTextWhileOffScreenProperty.boolValue);
            bool showIndicatorTextWhileOffScreen = EditorGUILayout.ToggleLeft("Display indicator text while indicator is off screen", showIndicatorTextWhileOffScreenProperty.boolValue);
            string indicatorText = EditorGUILayout.TextField(new GUIContent("Indicator text", "Text to be displayed on the indicator"), indicatorTextProperty.stringValue);
            EditorGUI.indentLevel--;

            if (EditorGUI.EndChangeCheck())
            {
                showDistanceTextWhileOnScreenProperty.boolValue = showDistanceTextWhileOnScreen;
                showDistanceTextWhileOffScreenProperty.boolValue = showDistanceTextWhileOffScreen;
                showIndicatorTextWhileOnScreenProperty.boolValue = showIndicatorTextWhileOnScreen;
                showIndicatorTextWhileOffScreenProperty.boolValue = showIndicatorTextWhileOffScreen;
                indicatorTextProperty.stringValue = indicatorText;

                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}