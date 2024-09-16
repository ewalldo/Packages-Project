using UnityEngine;
using UnityEditor;
using TMPro;

namespace IndicatorSystem
{
	[CanEditMultipleObjects]
    [CustomEditor(typeof(UIWaypointIndicator))]
    public class UIWaypointIndicatorEditor : UIIndicatorEditor
	{
        private SerializedProperty offScreenRotatesProperty;

        private SerializedProperty textsContainerProperty;
        private SerializedProperty distanceTextProperty;
        private SerializedProperty distanceOffsetProperty;
        private SerializedProperty indicatorTextProperty;
        private SerializedProperty indicatorOffsetProperty;

        private const string OFFSET_TOOLTIP = "The offset to be applied to the text when the indicator is off-screen\n" +
            "If it is out from the left, it will push the text 'Left' units to the right\n" +
            "If it is out from the right, it will push the text 'Right' units to the left\n" +
            "If it is out from the top, it will push the text 'Top' units down\n" +
            "If it is out from the bottom, it will push the text 'Bottom' units up";

        protected override void OnEnable()
        {
            base.OnEnable();

            offScreenRotatesProperty = serializedObject.FindProperty(UIWaypointIndicator.GetNameOfOffScreenSpriteRotates);

            textsContainerProperty = serializedObject.FindProperty(UIWaypointIndicator.GetNameOfTextsContainer);
            distanceTextProperty = serializedObject.FindProperty(UIWaypointIndicator.GetNameOfDistanceText);
            distanceOffsetProperty = serializedObject.FindProperty(UIWaypointIndicator.GetNameOfDistanceOffset);
            indicatorTextProperty = serializedObject.FindProperty(UIWaypointIndicator.GetNameOfIndicatorText);
            indicatorOffsetProperty = serializedObject.FindProperty(UIWaypointIndicator.GetNameOfIndicatorOffset);
        }

        public override void OnInspectorGUI()
        {
            using (new EditorGUI.DisabledScope(true))
                EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((MonoBehaviour)target), GetType(), false);

            EditorGUILayout.Space(10);

            base.OnInspectorGUI();

            EditorGUILayout.Space(10);

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("<color=white>Waypoint options</color>", new GUIStyle { fontStyle = FontStyle.Bold });
            EditorGUI.indentLevel++;
            bool offScreenRotates = EditorGUILayout.ToggleLeft(new GUIContent("Off-screen indicator rotates?", "Should the off-screen indicator rotates to match the indicator direction?"), offScreenRotatesProperty.boolValue);
            EditorGUI.indentLevel--;

            EditorGUILayout.Space(10);

            EditorGUILayout.LabelField("<color=white>Text options</color>", new GUIStyle { fontStyle = FontStyle.Bold });
            EditorGUI.indentLevel++;
            RectTransform textsParent = (RectTransform)EditorGUILayout.ObjectField(new GUIContent("Texts parent", "The parent rectTransform containing the texts"), textsContainerProperty.objectReferenceValue, typeof(RectTransform), true);
            TextMeshProUGUI distanceText = (TextMeshProUGUI)EditorGUILayout.ObjectField(new GUIContent("Distance text", "The text object used to display the distance between the indicator and the point of origin"), distanceTextProperty.objectReferenceValue, typeof(TextMeshProUGUI), true);
            if (distanceText != null)
            {
                EditorGUILayout.PropertyField(distanceOffsetProperty, new GUIContent("Off-screen distance text offset", OFFSET_TOOLTIP));
            }

            EditorGUILayout.Space(5);

            TextMeshProUGUI indicatorText = (TextMeshProUGUI)EditorGUILayout.ObjectField(new GUIContent("Indicator text", "The text object used to display the indicator text"), indicatorTextProperty.objectReferenceValue, typeof(TextMeshProUGUI), true);
            if (indicatorText != null)
            {
                EditorGUILayout.PropertyField(indicatorOffsetProperty, new GUIContent("Off-screen indicator text offset", OFFSET_TOOLTIP));
            }
            EditorGUI.indentLevel--;

            if (EditorGUI.EndChangeCheck())
            {
                offScreenRotatesProperty.boolValue = offScreenRotates;

                textsContainerProperty.objectReferenceValue = textsParent;
                distanceTextProperty.objectReferenceValue = distanceText;
                indicatorTextProperty.objectReferenceValue = indicatorText;

                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}