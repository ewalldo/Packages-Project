using UnityEditor;

namespace StatsSystem
{
	[CustomEditor(typeof(StatTypeSet))]
	public class StatTypeSetEditor : Editor
	{
        private StatTypeSet statTypeSet;

        private void OnEnable()
        {
            statTypeSet = target as StatTypeSet;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            StatType[] statTypes = statTypeSet.GetStatTypeSet;

            if (statTypes == null || statTypes.Length == 0)
            {
                EditorGUILayout.HelpBox("Stat type set is empty", MessageType.Warning);
                return;
            }

            // Null check
            bool hasnull = false;
            for (int i = 0; i < statTypes.Length; i++)
            {
                if (statTypes[i] == null)
                {
                    EditorGUILayout.HelpBox($"Entry [{i}] is null", MessageType.Error);
                    hasnull = true;
                }
            }

            if (hasnull)
                return;

            // Duplicate check
            for (int i = 0; i < statTypes.Length; i++)
            {
                for (int j = i + 1; j < statTypes.Length; j++)
                {
                    if (statTypes[i] == statTypes[j])
                    {
                        EditorGUILayout.HelpBox($"Duplicate detected: Entry [{i}] is equal to Entry [{j}]", MessageType.Error);
                    }
                }
            }
        }
	}
}