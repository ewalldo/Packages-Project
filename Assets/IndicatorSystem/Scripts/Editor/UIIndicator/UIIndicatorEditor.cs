using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace IndicatorSystem
{
	[CanEditMultipleObjects]
    [CustomEditor(typeof(UIIndicator))]
    public class UIIndicatorEditor : Editor
	{
        protected SerializedProperty screenIndicatorsContainerProperty;
        protected SerializedProperty onScreenIndicatorProperty;
        protected SerializedProperty offScreenIndicatorProperty;

        protected SerializedProperty boundBoxProperty;

        protected virtual void OnEnable()
        {
            screenIndicatorsContainerProperty = serializedObject.FindProperty(UIIndicator.GetNameOfScreenIndicatorsContainer);
            onScreenIndicatorProperty = serializedObject.FindProperty(UIIndicator.GetNameOfOnScreenIndicator);
            offScreenIndicatorProperty = serializedObject.FindProperty(UIIndicator.GetNameOfOffScreenIndicator);

            boundBoxProperty = serializedObject.FindProperty(UIIndicator.GetNameOfBoundBoxSize);
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("<color=white>Indicator options</color>", new GUIStyle { fontStyle = FontStyle.Bold });
            EditorGUI.indentLevel++;
            RectTransform indicatorsParent = (RectTransform)EditorGUILayout.ObjectField(new GUIContent("Indicators parent", "The parent rectTransform containing the indicators"), screenIndicatorsContainerProperty.objectReferenceValue, typeof(RectTransform), true);
            if (indicatorsParent == null)
                EditorGUILayout.HelpBox("No indicators parent assigned, indicators may not behave correctly!", MessageType.Error, true);

            Image onScreenIndicator = (Image)EditorGUILayout.ObjectField(new GUIContent("On-screen indicator", "The indicator to display when the object is on-screen"), onScreenIndicatorProperty.objectReferenceValue, typeof(Image), true);
            Image offScreenIndicator = (Image)EditorGUILayout.ObjectField(new GUIContent("Off-screen indicator", "The indicator to display when the object is off-screen"), offScreenIndicatorProperty.objectReferenceValue, typeof(Image), true);

            if (onScreenIndicator == null && offScreenIndicator == null)
            {
                EditorGUILayout.HelpBox("No indicators were assigned, please assign at least one of them", MessageType.Warning, true);
            }
            EditorGUI.indentLevel--;

            EditorGUILayout.Space(10);

            EditorGUILayout.LabelField("<color=white>Boundbox options</color>", new GUIStyle { fontStyle = FontStyle.Bold });
            Vector2 boundBox = EditorGUILayout.Vector2Field(new GUIContent("Bound box", "Bound box to be used for on/off-screen detection if the option is turned on in the Indicator script"), boundBoxProperty.vector2Value);

            if (EditorGUI.EndChangeCheck())
            {
                screenIndicatorsContainerProperty.objectReferenceValue = indicatorsParent;
                onScreenIndicatorProperty.objectReferenceValue = onScreenIndicator;
                offScreenIndicatorProperty.objectReferenceValue = offScreenIndicator;

                boundBoxProperty.vector2Value = boundBox;

                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}