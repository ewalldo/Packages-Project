using UnityEngine;
using UnityEditor;

namespace IndicatorSystem
{
	[CanEditMultipleObjects]
    [CustomEditor(typeof(UIRadialIndicator))]
    public class UIRadialIndicatorEditor : UIIndicatorEditor
	{
        private SerializedProperty diameterLengthProperty;

        protected override void OnEnable()
        {
            base.OnEnable();

            diameterLengthProperty = serializedObject.FindProperty(UIRadialIndicator.GetNameOfDiameterLength);
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
            float diameter = EditorGUILayout.FloatField(new GUIContent("Diameter length", "The diameter of the radial indicator"), diameterLengthProperty.floatValue);
            EditorGUI.indentLevel--;

            if (EditorGUI.EndChangeCheck())
            {
                diameterLengthProperty.floatValue = diameter;

                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}