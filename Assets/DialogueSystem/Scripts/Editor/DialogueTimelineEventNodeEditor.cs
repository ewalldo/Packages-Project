using UnityEngine;
using UnityEditor;
using XNodeEditor;

namespace DialoguePackage
{
    [CustomNodeEditor(typeof(DialogueTimelineEventNode))]
    public class DialogueTimelineEventNodeEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            serializedObject.Update();

            DialogueTimelineEventNode segment = serializedObject.targetObject as DialogueTimelineEventNode;
            NodeEditorGUILayout.PortField(segment.GetPort("input"));

            GUILayout.Label("Timeline Event");
            segment.nodeEvent = (DialogueTimelineEvents)EditorGUILayout.EnumPopup(segment.nodeEvent);

            GUILayout.Space(10);

            switch (segment.nodeEvent)
            {
                case DialogueTimelineEvents.PlayTimelineSync:
                case DialogueTimelineEvents.PlayTimelineAsync:
                case DialogueTimelineEvents.JumpToTimeline:
                    GUILayout.Label("Timer (seconds)");
                    segment.timer = EditorGUILayout.FloatField(segment.timer);
                    break;
                case DialogueTimelineEvents.PauseTimeline:
                    break;
                case DialogueTimelineEvents.RestartTimeline:
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
