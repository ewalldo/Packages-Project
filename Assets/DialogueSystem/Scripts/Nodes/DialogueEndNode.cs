using UnityEngine;

namespace DialoguePackage
{
    public class DialogueEndNode : DialogueBaseNode
    {
        [Input] public DialogueBaseNode input;

        public override string GetString()
        {
            return "EndNode";
        }
    } 
}
