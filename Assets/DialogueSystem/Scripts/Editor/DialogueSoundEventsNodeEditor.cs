using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace DialoguePackage
{
    [CustomNodeEditor(typeof(DialogueSoundEventsNode))]
    public class DialogueSoundEventsNodeEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            serializedObject.Update();

            DialogueSoundEventsNode segment = serializedObject.targetObject as DialogueSoundEventsNode;
            NodeEditorGUILayout.PortField(segment.GetPort("input"));

            GUILayout.Label("Sound Event");
            segment.nodeEvent = (DialogueSoundEvents)EditorGUILayout.EnumPopup(segment.nodeEvent);

            GUILayout.Space(10);

            GUILayout.Label("Song Name");
            segment.audioClip = (AudioClip)EditorGUILayout.ObjectField("Audio Clip", segment.audioClip, typeof(AudioClip), false);

            NodeEditorGUILayout.PortField(segment.GetPort("output"));

            serializedObject.ApplyModifiedProperties();
        }

        public override Color GetTint()
        {
            return new Color(0.22f, 0.49f, 0.74f);
        }
    }
}
