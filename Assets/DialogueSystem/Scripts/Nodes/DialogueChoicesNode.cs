using System;
using System.Collections.Generic;
using UnityEngine;

namespace DialoguePackage
{
    [NodeWidth(300)]
    public class DialogueChoicesNode : DialogueBaseNode
    {
        [Input] public DialogueBaseNode input;
        [Output(dynamicPortList = true)] public List<string> output;

        public override string GetString()
        {
            return "DialogueChoicesNode";
        }
    }

    [Serializable]
    public class DialogueChoiceOutput
    {
        //public string speakerName;
        //public Sprite speakerPortrait;
        //public string dialogueText;
        //public AudioClip dialogueTextAudio;
        public string output;
    }
}
