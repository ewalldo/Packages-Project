using UnityEngine;
using UnityEditor;
using XNodeEditor;

namespace DialoguePackage
{
    [CustomNodeEditor(typeof(DialogueSpeechNode))]
    public class DialogueSpeechNodeEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            serializedObject.Update();

            DialogueSpeechNode segment = serializedObject.targetObject as DialogueSpeechNode;

            NodeEditorGUILayout.PortField(segment.GetPort("input"));

            GUILayout.Label("Speaker");
            segment.speakerName = GUILayout.TextField(segment.speakerName);

            GUILayout.Space(10);

            GUILayout.Label("Dialogue Text");
            segment.dialogueText = GUILayout.TextArea(segment.dialogueText, new GUILayoutOption[] { GUILayout.MinHeight(100) });

            GUILayout.Space(10);

            segment.dialogueTextAudio = (AudioClip)EditorGUILayout.ObjectField("Audio File", segment.dialogueTextAudio, typeof(AudioClip), false);
            segment.speakerPortrait = (Sprite)EditorGUILayout.ObjectField("Speaker Portrait", segment.speakerPortrait, typeof(Sprite), true, GUILayout.Height(EditorGUIUtility.singleLineHeight));

            GUILayout.Space(10);

            NodeEditorGUILayout.PortField(segment.GetPort("output"));

            serializedObject.ApplyModifiedProperties();
        }

        public override Color GetTint()
        {
            return new Color(0.21f, 0.42f, 0.36f);
        }
    }
}
