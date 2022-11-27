using UnityEngine;

namespace DialoguePackage
{
    [NodeWidth(300)]
    public class DialogueEventsNode : DialogueBaseNode
    {
        [Input] public DialogueBaseNode input;
        public DialogueEvents nodeEvent;
        public float timer;
        [Output] public DialogueBaseNode output;

        public override string GetString()
        {
            return "DialogueEvent";
        }
    }
}
