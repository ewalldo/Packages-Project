using UnityEngine;
using XNodeEditor;

namespace DialoguePackage
{
    [CustomNodeEditor(typeof(DialogueStartNode))]
    public class DialogueStartNodeEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            serializedObject.Update();

            DialogueStartNode segment = serializedObject.targetObject as DialogueStartNode;

            NodeEditorGUILayout.PortField(segment.GetPort("output"));

            serializedObject.ApplyModifiedProperties();
        }

        public override Color GetTint()
        {
            return new Color(0.64f, 0.26f, 0.15f);
        }
    } 
}
