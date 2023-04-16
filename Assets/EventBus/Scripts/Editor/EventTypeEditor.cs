using UnityEngine;
using UnityEditor;
using System.IO;

namespace EventBusPattern
{
    [CustomEditor(typeof(EventType))]
    public class EventTypeEditor : Editor
	{
		private EventType eventType;

		private SerializedProperty eventNameProperty;

        private void OnEnable()
        {
            eventType = target as EventType;

            eventNameProperty = serializedObject.FindProperty(eventType.GetNameOfEventName);
        }

        public override void OnInspectorGUI()
        {
            if (string.IsNullOrEmpty(eventType.GetEventName))
            {
                string filepath = AssetDatabase.GetAssetPath(eventType);
                string filename = Path.GetFileNameWithoutExtension(filepath);

                eventNameProperty.stringValue = filename;
                serializedObject.ApplyModifiedProperties();
            }

            GUI.enabled = false;
            EditorGUILayout.TextField("Event Type", eventType.GetEventName);
            GUI.enabled = true;
        }
    }
}