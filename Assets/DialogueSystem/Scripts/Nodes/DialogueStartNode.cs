using UnityEngine;

namespace DialoguePackage
{
    public class DialogueStartNode : DialogueBaseNode
    {
        [Output] public DialogueBaseNode output;

        public override string GetString()
        {
            return "StartNode";
        }
    } 
}
