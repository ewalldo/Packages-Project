using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace DialoguePackage
{
    [CustomNodeEditor(typeof(DialogueChoicesNode))]
    public class DialogueChoicesNodeEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            serializedObject.Update();

            DialogueChoicesNode segment = serializedObject.targetObject as DialogueChoicesNode;
            NodeEditorGUILayout.PortField(segment.GetPort("input"));

            NodeEditorGUILayout.DynamicPortList("output", typeof(DialogueSpeechNode), serializedObject, NodePort.IO.Input, Node.ConnectionType.Override, Node.TypeConstraint.None, OnCreateReorderableList);

            serializedObject.ApplyModifiedProperties();
        }

        private void OnCreateReorderableList(ReorderableList list)
        {
            list.elementHeightCallback = (int index) => { return 100; };

            list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                DialogueChoicesNode segment = serializedObject.targetObject as DialogueChoicesNode;

                NodePort port = segment.GetPort("output " + index);

                segment.output[index] = GUI.TextArea(new Rect(rect.x, rect.y + EditorGUIUtility.singleLineHeight, rect.width, rect.height - EditorGUIUtility.singleLineHeight), segment.output[index]);

                if (port != null)
                {
                    Vector2 pos = rect.position + (port.IsOutput ? new Vector2(rect.width + 6, 0) : new Vector2(-36, 0));
                    NodeEditorGUILayout.PortField(pos, port);
                }
            };
        }

        public override Color GetTint()
        {
            return new Color(0.37f, 0.1f, 0.45f);
        }
    } 
}
