using UnityEngine;

namespace DialoguePackage
{
    [NodeWidth(300)]
    public class DialogueSpeechNode : DialogueBaseNode
    {
        [Input] public DialogueBaseNode input;
        public string speakerName;
        public Sprite speakerPortrait;
        public string dialogueText;
        public AudioClip dialogueTextAudio;
        [Output] public DialogueBaseNode output;

        public override string GetString()
        {
            return "SpeechNode";
        }
    } 
}
