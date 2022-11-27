using UnityEngine;

namespace DialoguePackage
{
    [NodeWidth(300)]
    public class DialogueSoundEventsNode : DialogueBaseNode
    {
        [Input] public DialogueBaseNode input;
        public DialogueSoundEvents nodeEvent;
        public AudioClip audioClip;
        [Output] public DialogueBaseNode output;

        public override string GetString()
        {
            return "DialogueSoundEvent";
        }
    }
}
