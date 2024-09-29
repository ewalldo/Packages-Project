using UnityEngine;
using UnityEditor;

namespace IndicatorSystem
{
	[CanEditMultipleObjects]
    [CustomEditor(typeof(Indicator))]
    public class IndicatorEditor : Editor
	{
        protected SerializedProperty hideOnScreenProperty;
        protected SerializedProperty hideOffScreenProperty;

        protected SerializedProperty originObjectProperty;
        protected SerializedProperty renderCanvasProperty;
        protected SerializedProperty renderCameraProperty;
        protected SerializedProperty useBoundBoxOffScreenCheckProperty;

        protected SerializedProperty lenghtUnitTypeProperty;
        protected SerializedProperty decimalPlacesProperty;
        protected SerializedProperty minRangeProperty;
        protected SerializedProperty maxRangeProperty;

        protected SerializedProperty onScreenFadeProperty;
        protected SerializedProperty offScreenFadeProperty;

        protected SerializedProperty onScreenScaleProperty;
        protected SerializedProperty offScreenScaleProperty;

        protected virtual void OnEnable()
        {
            hideOnScreenProperty = serializedObject.FindProperty(Indicator.GetNameOfHideOnScreen);
            hideOffScreenProperty = serializedObject.FindProperty(Indicator.GetNameOfHideOffScreen);

            originObjectProperty = serializedObject.FindProperty(Indicator.GetNameOfOriginObject);
            renderCanvasProperty = serializedObject.FindProperty(Indicator.GetNameOfRenderCanvas);
            renderCameraProperty = serializedObject.FindProperty(Indicator.GetNameOfRenderCamera);
            useBoundBoxOffScreenCheckProperty = serializedObject.FindProperty(Indicator.GetNameOfUseBoundBoxForOffScreenCheck);

            lenghtUnitTypeProperty = serializedObject.FindProperty(Indicator.GetNameOfLengthUnitType);
            decimalPlacesProperty = serializedObject.FindProperty(Indicator.GetNameOfDecimalPlaces);
            minRangeProperty = serializedObject.FindProperty(Indicator.GetNameOfMinRange);
            maxRangeProperty = serializedObject.FindProperty(Indicator.GetNameOfMaxRange);

            onScreenFadeProperty = serializedObject.FindProperty(Indicator.GetNameOfOnScreenFade);
            offScreenFadeProperty = serializedObject.FindProperty(Indicator.GetNameOfOffScreenFade);

            onScreenScaleProperty = serializedObject.FindProperty(Indicator.GetNameOfOnScreenScale);
            offScreenScaleProperty = serializedObject.FindProperty(Indicator.GetNameOfOffScreenScale);
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("<color=white>Display options</color>", new GUIStyle { fontStyle = FontStyle.Bold });
            EditorGUI.indentLevel++;
            bool hideOnScreen = EditorGUILayout.ToggleLeft("Hide indicator while on screen", hideOnScreenProperty.boolValue);
            bool hideOffScreen = EditorGUILayout.ToggleLeft("Hide indicator while off screen", hideOffScreenProperty.boolValue);
            EditorGUI.indentLevel--;

            EditorGUILayout.Space(10);

            EditorGUILayout.LabelField("<color=white>Render options</color>", new GUIStyle { fontStyle = FontStyle.Bold });
            EditorGUI.indentLevel++;
            Transform originObject = (Transform)EditorGUILayout.ObjectField(new GUIContent("Origin object", "The object which the indicator will calculate its distance from"), originObjectProperty.objectReferenceValue, typeof(Transform), true);
            Canvas renderCanvas = (Canvas)EditorGUILayout.ObjectField(new GUIContent("Canvas", "The canvas where the indicator will be instantiated"), renderCanvasProperty.objectReferenceValue, typeof(Canvas), true);
            Camera renderCamera = (Camera)EditorGUILayout.ObjectField(new GUIContent("Camera", "The camera which the indicator will be rendered to"), renderCameraProperty.objectReferenceValue, typeof(Camera), true);
            bool useBoundBoxScreenCheck = EditorGUILayout.Toggle(new GUIContent("Use bound box for on/off screen check?", "If true, the UI Indicator bound box will be used to check if the indicator is on/off screen. If false, will use the transform origin"), useBoundBoxOffScreenCheckProperty.boolValue);
            EditorGUI.indentLevel--;

            EditorGUILayout.Space(10);

            EditorGUILayout.LabelField("<color=white>Distance options</color>", new GUIStyle { fontStyle = FontStyle.Bold });
            EditorGUI.indentLevel++;
            int lenghtUnitTypeIndex = (int)(LengthUnitType)EditorGUILayout.EnumPopup(new GUIContent("Length unit", ""), (LengthUnitType)lenghtUnitTypeProperty.enumValueIndex);
            int decimalPlaces = EditorGUILayout.IntSlider(new GUIContent("Decimal places", "How many decimal places should be used for distance operations"), decimalPlacesProperty.intValue, 0, 32);
            float minRange = EditorGUILayout.FloatField(new GUIContent("Minimum range", "The minimum distance to display the indicator"), minRangeProperty.floatValue);
            float maxRange = EditorGUILayout.FloatField(new GUIContent("Maximum range", "The maximum distance to display the indicator"), maxRangeProperty.floatValue);
            EditorGUI.indentLevel--;

            EditorGUILayout.Space(10);

            EditorGUILayout.LabelField("<color=white>Fade options</color>", new GUIStyle { fontStyle = FontStyle.Bold });
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(onScreenFadeProperty, new GUIContent("On-screen indicator fade", ""));
            EditorGUILayout.Space(5);
            EditorGUILayout.PropertyField(offScreenFadeProperty, new GUIContent("Off-screen indicator fade", ""));
            EditorGUI.indentLevel--;

            EditorGUILayout.Space(10);

            EditorGUILayout.LabelField("<color=white>Scale options</color>", new GUIStyle { fontStyle = FontStyle.Bold });
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(onScreenScaleProperty, new GUIContent("On-screen indicator scale", ""));
            EditorGUILayout.Space(5);
            EditorGUILayout.PropertyField(offScreenScaleProperty, new GUIContent("Off-screen indicator scale", ""));
            EditorGUI.indentLevel--;

            if (EditorGUI.EndChangeCheck())
            {
                hideOnScreenProperty.boolValue = hideOnScreen;
                hideOffScreenProperty.boolValue = hideOffScreen;

                originObjectProperty.objectReferenceValue = originObject;
                renderCanvasProperty.objectReferenceValue = renderCanvas;
                renderCameraProperty.objectReferenceValue = renderCamera;
                useBoundBoxOffScreenCheckProperty.boolValue = useBoundBoxScreenCheck;

                lenghtUnitTypeProperty.enumValueIndex = lenghtUnitTypeIndex;
                decimalPlacesProperty.intValue = decimalPlaces;
                if (minRange < 0)
                    minRange = 0;
                if (maxRange < minRange)
                    maxRange = minRange;
                minRangeProperty.floatValue = minRange;
                maxRangeProperty.floatValue = maxRange;

                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}