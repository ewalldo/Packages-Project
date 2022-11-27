using UnityEngine;

namespace DialoguePackage
{
    [NodeWidth(300)]
    public class DialogueTimelineEventNode : DialogueBaseNode
    {
        [Input] public DialogueBaseNode input;
        public DialogueTimelineEvents nodeEvent;
        public float timer;
        [Output] public DialogueBaseNode output;

        public override string GetString()
        {
            return "DialogueTimelineEvent";
        }
    }
}
