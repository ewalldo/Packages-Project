using UnityEngine;
using UnityEditor;

namespace StatsSystem
{
	[CustomEditor(typeof(StatsSheetComponent))]
	public class StatsSheetEditor : Editor
	{
        private StatsSheetComponent statsSheet;

        private void OnEnable()
        {
            statsSheet = target as StatsSheetComponent;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space();

            if (!Application.isPlaying)
                DrawEditModeValidation();
            else
                DrawRuntimeStats();
        }

        private void DrawEditModeValidation()
        {
            SerializedProperty statsTypeSetProperty = serializedObject.FindProperty(StatsSheetComponent.GetNameOfStatsSheet).FindPropertyRelative(StatsSheet.GetNameOfStatTypeSet);
            SerializedProperty overridesProperty = serializedObject.FindProperty(StatsSheetComponent.GetNameOfStatsSheet).FindPropertyRelative(StatsSheet.GetNameOfStatsOverrides);

            StatTypeSet statTypeSet = statsTypeSetProperty.objectReferenceValue as StatTypeSet;

            if (statTypeSet == null)
            {
                EditorGUILayout.HelpBox("No StatTypeSet assigned", MessageType.Error);
                return;
            }

            if (statTypeSet.GetStatTypeSet == null || statTypeSet.GetStatTypeSet.Length == 0)
            {
                EditorGUILayout.HelpBox("Assigned StatTypeSet is empty", MessageType.Warning);
                return;
            }

            // Check if the overrides assigned exists in the assigned StatTypeSet
            for (int i = 0; i < overridesProperty.arraySize; i++)
            {
                SerializedProperty overrideEntry = overridesProperty.GetArrayElementAtIndex(i);
                SerializedProperty statTypeProperty = overrideEntry.FindPropertyRelative(SingleStatConfig.GetNameOfStatType);
                StatType overrideStatType = statTypeProperty.objectReferenceValue as StatType;

                if (overrideStatType == null)
                    continue;

                bool found = false;
                foreach (StatType statType in statTypeSet.GetStatTypeSet)
                {
                    if (statType == overrideStatType)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    EditorGUILayout.HelpBox($"Override [{i}] references '{overrideStatType.GetStatName}' which is not in the assigned StatTypeSet", MessageType.Warning);
                }
            }

            EditorGUILayout.LabelField("Editor Mode Preview", EditorStyles.boldLabel);
            GUI.enabled = false;
            foreach (StatType statType in statTypeSet.GetStatTypeSet)
            {
                if (statType == null)
                {
                    EditorGUILayout.HelpBox("StatTypeSet has null value", MessageType.Error);
                    continue;
                }

                EditorGUILayout.LabelField(statType.GetStatName, "Will be initialized on Awake");
            }
            GUI.enabled = true;
        }

        private void DrawRuntimeStats()
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);

            SerializedProperty statsTypeSetProperty = serializedObject.FindProperty(StatsSheetComponent.GetNameOfStatsSheet).FindPropertyRelative(StatsSheet.GetNameOfStatTypeSet);
            StatTypeSet statTypeSet = statsTypeSetProperty.objectReferenceValue as StatTypeSet;

            if (statTypeSet == null)
                return;

            // Header
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Stat", EditorStyles.boldLabel, GUILayout.Width(100));
            EditorGUILayout.LabelField("Base", EditorStyles.boldLabel, GUILayout.Width(60));
            EditorGUILayout.LabelField("Final", EditorStyles.boldLabel, GUILayout.Width(60));
            EditorGUILayout.LabelField("Modifiers", EditorStyles.boldLabel);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Separator();

            foreach (StatType statType in statTypeSet.GetStatTypeSet)
            {
                SingleStat singleStat = statsSheet.GetStat(statType);
                
                if (singleStat == null)
                    continue;

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(statType.GetStatName, GUILayout.Width(100));
                EditorGUILayout.LabelField(singleStat.StatBaseValue.ToString("F1"), GUILayout.Width(60));
                EditorGUILayout.LabelField(singleStat.GetFinalValue().ToString("F1"), GUILayout.Width(60));
                EditorGUILayout.LabelField($"{singleStat.StatsModifiers.Count} active");
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndVertical();

            if (Application.isPlaying)
                Repaint();
        }
    }
}