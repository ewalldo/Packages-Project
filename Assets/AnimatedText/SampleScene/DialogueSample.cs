using System.Collections.Generic;
using UnityEngine;

namespace AnimatedText
{
	public class DialogueSample : MonoBehaviour
	{
		[SerializeField] private GameObject speechBubble;
		[SerializeField] private TextAnimator textAnimator;
        [TextArea]
        [SerializeField] private List<string> dialogueSequence;

        [SerializeField] private GameObject chestImage;
        [SerializeField] private GameObject explosionParticleEffect;
        [SerializeField] private AudioSource chestSoundEffect;

        [SerializeField] private AudioSource characterAudio;
        [SerializeField] private AudioClip[] audioClips;

        private int currentDialogue;

        private void Start()
        {
            textAnimator.OnDialogueAction += TextAnimator_OnDialogueAction;
            textAnimator.OnCharTyped += TextAnimator_OnCharTyped;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                currentDialogue++;

                if (currentDialogue >= dialogueSequence.Count)
                {
                    speechBubble.SetActive(false);
                    return;
                }

                textAnimator.TypeText(dialogueSequence[currentDialogue]);
            }
        }

        public void RegisterName(string name)
        {
            ReplaceTagParser.AddEntry("name", name);
        }

        public void StartDialogue()
        {
            currentDialogue = 0;
            textAnimator.TypeText(dialogueSequence[currentDialogue]);
        }

        private void TextAnimator_OnDialogueAction(string actionName)
        {
            if (actionName == "spawnChest")
            {
                explosionParticleEffect.SetActive(true);
                Destroy(explosionParticleEffect, 3f);
                chestSoundEffect.time = 0.3f;
                chestSoundEffect.Play();
                chestImage.SetActive(true);
            }
            else if (actionName == "destroyChest")
            {
                chestSoundEffect.time = 0.3f;
                chestSoundEffect.Play();
                chestImage.SetActive(false);
            }
        }

        private void TextAnimator_OnCharTyped(char typedChar)
        {
            if (!char.IsLetterOrDigit(typedChar))
                return;

            characterAudio.clip = audioClips[Random.Range(0, audioClips.Length)];
            characterAudio.Play();
        }
    }
}