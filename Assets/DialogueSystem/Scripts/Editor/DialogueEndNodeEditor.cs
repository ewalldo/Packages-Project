using UnityEngine;
using XNodeEditor;

namespace DialoguePackage
{
    [CustomNodeEditor(typeof(DialogueEndNode))]
    public class DialogueEndNodeEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            serializedObject.Update();

            DialogueEndNode segment = serializedObject.targetObject as DialogueEndNode;

            NodeEditorGUILayout.PortField(segment.GetPort("input"));

            serializedObject.ApplyModifiedProperties();
        }

        public override Color GetTint()
        {
            return new Color(0.64f, 0.26f, 0.15f);
        }
    } 
}
