using UnityEngine;
using UnityEditor;

namespace MeasurementTool
{
    [CustomEditor(typeof(EditorMeasurementTool))]
    public class EditorMeasurementToolEditor : Editor
	{
        private EditorMeasurementTool measuringTool;

        private SerializedProperty measurementUnitProperty;
        private SerializedProperty rulerSizeProperty;

        private SerializedProperty displayTextColorProperty;
        private SerializedProperty displayTextSizeProperty;
        private SerializedProperty displayLineColorProperty;

        private SerializedProperty displayAxisMeasurementsProperty;
        private SerializedProperty displayXAxisProperty;
        private SerializedProperty displayYAxisProperty;
        private SerializedProperty displayZAxisProperty;

        private SerializedProperty sourceObjectProperty;
        private SerializedProperty targetObjectsProperty;

        private SerializedProperty displayInBetweenDistanceProperty;
        private SerializedProperty displayAnglesMeasurementsProperty;
        private SerializedProperty displayMainPlanesAnglesProperty;
        private SerializedProperty displayReversePlanesAnglesProperty;

        private void OnEnable()
        {
            measuringTool = target as EditorMeasurementTool;

            measurementUnitProperty = serializedObject.FindProperty(measuringTool.NameOfLengthUnitType);
            rulerSizeProperty = serializedObject.FindProperty(measuringTool.NameOfRulerSize);

            displayTextColorProperty = serializedObject.FindProperty(measuringTool.NameOfTextColor);
            displayTextSizeProperty = serializedObject.FindProperty(measuringTool.NameOfTextSize);
            displayLineColorProperty = serializedObject.FindProperty(measuringTool.NameOfLineColor);

            displayAxisMeasurementsProperty = serializedObject.FindProperty(measuringTool.NameOfDisplayAxisMeasurements);
            displayXAxisProperty = serializedObject.FindProperty(measuringTool.NameOfDisplayXAxis);
            displayYAxisProperty = serializedObject.FindProperty(measuringTool.NameOfDisplayYAxis);
            displayZAxisProperty = serializedObject.FindProperty(measuringTool.NameOfDisplayZAxis);

            sourceObjectProperty = serializedObject.FindProperty(measuringTool.NameOfSourceObject);
            targetObjectsProperty = serializedObject.FindProperty(measuringTool.NameOfTargetObject);

            displayInBetweenDistanceProperty = serializedObject.FindProperty(measuringTool.NameOfDisplayInBetweenDistanceValues);
            displayAnglesMeasurementsProperty = serializedObject.FindProperty(measuringTool.NameOfDisplayAnglesInfo);
            displayMainPlanesAnglesProperty = serializedObject.FindProperty(measuringTool.NameOfDisplayMainPlanesAnglesInfo);
            displayReversePlanesAnglesProperty = serializedObject.FindProperty(measuringTool.NameOfDisplayReversePlanesAnglesInfo);
        }

        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(measurementUnitProperty, new GUIContent("Measurement Unit"));
            EditorGUILayout.PropertyField(rulerSizeProperty, new GUIContent("Ruler Size"));

            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);

            EditorGUILayout.LabelField("Axis Measurements");
            displayAxisMeasurementsProperty.boolValue = EditorGUILayout.ToggleLeft("Display axis measurements", displayAxisMeasurementsProperty.boolValue);

            if (displayAxisMeasurementsProperty.boolValue)
            {
                EditorGUI.indentLevel++;
                displayXAxisProperty.boolValue = EditorGUILayout.ToggleLeft("X-Axis", displayXAxisProperty.boolValue);
                displayYAxisProperty.boolValue = EditorGUILayout.ToggleLeft("Y-Axis", displayYAxisProperty.boolValue);
                displayZAxisProperty.boolValue = EditorGUILayout.ToggleLeft("Z-Axis", displayZAxisProperty.boolValue);
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);

            EditorGUILayout.LabelField("Object-Object info");
            EditorGUILayout.PropertyField(sourceObjectProperty, new GUIContent("Source Object"));
            EditorGUILayout.PropertyField(targetObjectsProperty, new GUIContent("Target Object(s)"));

            EditorGUILayout.LabelField("Distance Measurements");
            displayInBetweenDistanceProperty.boolValue = EditorGUILayout.ToggleLeft("Display In-Between distance values", displayInBetweenDistanceProperty.boolValue);

            EditorGUILayout.LabelField("Angle Measurements");
            displayAnglesMeasurementsProperty.boolValue = EditorGUILayout.ToggleLeft("Display angle measurements", displayAnglesMeasurementsProperty.boolValue);

            if (displayAnglesMeasurementsProperty.boolValue)
            {
                EditorGUI.indentLevel++;
                displayMainPlanesAnglesProperty.boolValue = EditorGUILayout.ToggleLeft("Main planes (XY, XZ and ZY)", displayMainPlanesAnglesProperty.boolValue);
                displayReversePlanesAnglesProperty.boolValue = EditorGUILayout.ToggleLeft("Reverse planes (YX, ZX and YZ)", displayReversePlanesAnglesProperty.boolValue);
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);

            EditorGUILayout.LabelField("Display text properties");
            EditorGUILayout.PropertyField(displayTextColorProperty, new GUIContent("Text Color"));
            EditorGUILayout.PropertyField(displayTextSizeProperty, new GUIContent("Text Size"));
            EditorGUILayout.PropertyField(displayLineColorProperty, new GUIContent("Line Color"));

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}