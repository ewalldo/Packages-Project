using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace DialoguePackage
{
    [CustomNodeEditor(typeof(DialogueGameObjectEventsNode))]
    public class DialogueGameObjectEventsNodeEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            serializedObject.Update();

            DialogueGameObjectEventsNode segment = serializedObject.targetObject as DialogueGameObjectEventsNode;
            NodeEditorGUILayout.PortField(segment.GetPort("input"));

            GUILayout.Label("GameObject Event");
            segment.nodeEvent = (DialogueGameObjectEvents)EditorGUILayout.EnumPopup(segment.nodeEvent);

            GUILayout.Space(10);

            switch (segment.nodeEvent)
            {
                case DialogueGameObjectEvents.ActivateDeactivate:
                    segment.targetGameObject = (GameObject)EditorGUILayout.ObjectField("Target", segment.targetGameObject, typeof(GameObject), true);
                    segment.activeStatus = EditorGUILayout.Toggle(segment.activeStatus);
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
