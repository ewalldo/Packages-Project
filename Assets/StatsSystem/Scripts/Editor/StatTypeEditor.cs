using UnityEngine;
using UnityEditor;
using System.IO;

namespace StatsSystem
{
    [CustomEditor(typeof(StatType))]
    public class StatTypeEditor : Editor
	{
		private StatType statType;

        private SerializedProperty statNameProperty;

        private void OnEnable()
        {
            statType = target as StatType;

            statNameProperty = serializedObject.FindProperty(statType.GetNameOfStatName);
        }

        public override void OnInspectorGUI()
        {
            if (string.IsNullOrEmpty(statType.GetStatName))
            {
                string filepath = AssetDatabase.GetAssetPath(statType);
                string filename = Path.GetFileNameWithoutExtension(filepath);

                statNameProperty.stringValue = filename;
                serializedObject.ApplyModifiedProperties();
            }

            GUI.enabled = false;
            EditorGUILayout.TextField("Stat Type", statType.GetStatName);
            GUI.enabled = true;
        }
    }
}