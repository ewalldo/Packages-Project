using UnityEngine;

namespace DialoguePackage
{
    [NodeWidth(300)]
    public class DialogueGameObjectEventsNode : DialogueBaseNode
    {
        [Input] public DialogueBaseNode input;
        public DialogueGameObjectEvents nodeEvent;
        public GameObject targetGameObject;
        public bool activeStatus;
        [Output] public DialogueBaseNode output;

        public override string GetString()
        {
            return "DialogueGameObjectEvent";
        }
    } 
}
