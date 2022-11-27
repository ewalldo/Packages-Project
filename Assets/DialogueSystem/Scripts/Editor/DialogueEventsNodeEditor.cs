using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace DialoguePackage
{
    [CustomNodeEditor(typeof(DialogueEventsNode))]
    public class DialogueEventsNodeEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            serializedObject.Update();

            DialogueEventsNode segment = serializedObject.targetObject as DialogueEventsNode;
            NodeEditorGUILayout.PortField(segment.GetPort("input"));

            GUILayout.Label("Dialogue Event");
            segment.nodeEvent = (DialogueEvents)EditorGUILayout.EnumPopup(segment.nodeEvent);

            GUILayout.Space(10);

            switch (segment.nodeEvent)
            {
                case DialogueEvents.PauseDialogue:
                    GUILayout.Label("Timer (seconds)");
                    segment.timer = EditorGUILayout.FloatField(segment.timer);
                    break;
                default:
                    break;
            }

            NodeEditorGUILayout.PortField(segment.GetPort("output"));

            serializedObject.ApplyModifiedProperties();
        }

        public override Color GetTint()
        {
            return new Color(0.22f, 0.49f, 0.74f);
        }
    }
}
