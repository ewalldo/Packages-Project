using UnityEngine;
using UnityEditor;

namespace IndicatorSystem
{
	[CanEditMultipleObjects]
    [CustomEditor(typeof(RadialIndicator))]
    public class RadialIndicatorEditor : IndicatorEditor
    {
        private SerializedProperty uiIndicatorPrefabProperty;

        protected override void OnEnable()
        {
            base.OnEnable();

            uiIndicatorPrefabProperty = serializedObject.FindProperty(RadialIndicator.GetNameOfUIIndicatorPrefab);
        }

        public override void OnInspectorGUI()
        {
            using (new EditorGUI.DisabledScope(true))
                EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((MonoBehaviour)target), GetType(), false);

            EditorGUILayout.Space(10);

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("<color=white>UI Indicator prefab</color>", new GUIStyle { fontStyle = FontStyle.Bold });
            EditorGUI.indentLevel++;
            UIRadialIndicator uIRadialIndicator = (UIRadialIndicator)EditorGUILayout.ObjectField(uiIndicatorPrefabProperty.objectReferenceValue, typeof(UIRadialIndicator), true);
            EditorGUI.indentLevel--;

            if (EditorGUI.EndChangeCheck())
            {
                uiIndicatorPrefabProperty.objectReferenceValue = uIRadialIndicator;

                serializedObject.ApplyModifiedProperties();
            }

            EditorGUILayout.Space(10);

            base.OnInspectorGUI();
        }
    }
}