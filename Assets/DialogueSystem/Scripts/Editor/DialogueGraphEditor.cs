using System;
using UnityEngine;
using XNodeEditor;

namespace DialoguePackage
{
    [CustomNodeGraphEditor(typeof(DialogueGraph))]
    public class DialogueGraphEditor : NodeGraphEditor
    {
        public override Color GetTypeColor(Type type)
        {
            if (type == typeof(DialogueBaseNode))
            {
                return Color.green;
            }
            else
            {
                return base.GetTypeColor(type);
            }
        }

        public override void OnDropObjects(UnityEngine.Object[] objects)
        {
            //base.OnDropObjects(objects);
        }
    } 
}
