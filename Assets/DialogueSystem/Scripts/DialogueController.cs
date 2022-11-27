using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using XNode;

namespace DialoguePackage
{
    public class DialogueController : MonoBehaviour
    {
        [Header("Setup fields")]
        [SerializeField, Tooltip("The dialogue graph for this conversation")]
        private DialogueGraph activeDialogue;
        [SerializeField, Tooltip("The playableDirector with a timeline to be controlled")]
        private PlayableDirector timeline;

        [Header("Dialogue speech fields")]
        [SerializeField, Tooltip("Reference to the text field that holds the dialogue information")]
        private TextMeshProUGUI dialogueText;
        [SerializeField, Tooltip("Reference to the text field that holds the speaker name information")]
        private TextMeshProUGUI nameText;
        [SerializeField, Tooltip("Reference to the image field that holds the portrait of the speaker")]
        private Image speakerPortrait;
        [SerializeField, Tooltip("If the dialogue should be in autoPlay mode or not")]
        private bool isAutoPlay;

        [Header("Choice node related fields")]
        [SerializeField, Tooltip("Button prefab to show the options in a choice node")]
        private GameObject buttonPrefab;
        [SerializeField, Tooltip("Transform where all the button prefabs will be instantiated")]
        private Transform buttonParent;

        [Header("Audio related fields")]
        [SerializeField, Tooltip("An audio source for dialogue voice")]
        private AudioSource voiceAudioSource;
        [SerializeField, Tooltip("An audio source for background music")]
        private AudioSource bgmAudioSource;
        [SerializeField, Tooltip("An audio source for sound effects")]
        private AudioSource seAudioSource;

        private Coroutine displaySentenceCoroutine;

        // Event to be invoked when the dialogue ends
        public static Action OnDialogueEnds;

        private void Start()
        {
            // Find the start node of the graph
            foreach (DialogueBaseNode node in activeDialogue.nodes)
            {
                if (node is DialogueStartNode)
                {
                    activeDialogue.current = node;
                    break;
                }
            }

            StartDialogue();
        }

        /// <summary>
        /// Start the dialogue contained in the graph
        /// </summary>
        private void StartDialogue()
        {
            DisplayNextSentence("output");
        }

        /// <summary>
        /// End the dialogue in the graph
        /// </summary>
        private void EndDialogue()
        {
            Debug.Log("End of conversation.");
            OnDialogueEnds?.Invoke();
        }

        /// <summary>
        /// Display the next sentence in the dialogue
        /// </summary>
        /// <param name="fieldName">The name of the output field of the current node</param>
        private void DisplayNextSentence(string fieldName)
        {
            // Stop the current coroutine if it is executing
            if (displaySentenceCoroutine != null)
            {
                StopCoroutine(displaySentenceCoroutine);
                displaySentenceCoroutine = null;
            }

            // Find the next node
            foreach (NodePort nodePort in activeDialogue.current.Ports)
            {
                if (nodePort.fieldName == fieldName)
                {
                    activeDialogue.current = nodePort.Connection.node as DialogueBaseNode;
                    break;
                }
            }

            DialogueBaseNode currentNode = activeDialogue.current;

            // Execute a different action depending on the node type
            switch (currentNode)
            {
                case DialogueStartNode:
                    DisplayNextSentence("output");
                    break;
                case DialogueSpeechNode:
                    displaySentenceCoroutine = StartCoroutine(TypeSpeechSentence(currentNode as DialogueSpeechNode));
                    break;
                case DialogueChoicesNode:
                    DisplayChoices(currentNode as DialogueChoicesNode);
                    break;
                case DialogueEventsNode:
                    displaySentenceCoroutine = StartCoroutine(HandleDialogueEvents(currentNode as DialogueEventsNode));
                    break;
                case DialogueGameObjectEventsNode:
                    HandleGameObjectEvents(currentNode as DialogueGameObjectEventsNode);
                    break;
                case DialogueSoundEventsNode:
                    HandleSoundEvents(currentNode as DialogueSoundEventsNode);
                    break;
                case DialogueTimelineEventNode:
                    displaySentenceCoroutine = StartCoroutine(HandleTimelineEvents(currentNode as DialogueTimelineEventNode));
                    break;
                case DialogueEndNode:
                    EndDialogue();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Display the text of the current node
        /// </summary>
        /// <param name="curDialogue">The current node in the dialogue graph</param>
        /// <returns></returns>
        private IEnumerator TypeSpeechSentence(DialogueSpeechNode curDialogue)
        {
            // Reset the text display
            dialogueText.text = "";
            string sentence = curDialogue.dialogueText;

            // Update the speaker name
            if (nameText != null && !string.IsNullOrEmpty(curDialogue.speakerName))
            {
                nameText.text = curDialogue.speakerName;
            }

            // Stop the voice if there is one and start the current voice dialogue
            if (voiceAudioSource != null && voiceAudioSource.isPlaying)
            {
                voiceAudioSource.Stop();
            }

            if (voiceAudioSource != null && curDialogue.dialogueTextAudio != null)
            {
                voiceAudioSource.clip = curDialogue.dialogueTextAudio;
                voiceAudioSource.Play();
            }

            // Update the speaker portrait
            if (speakerPortrait != null && curDialogue.speakerPortrait != null)
            {
                speakerPortrait.sprite = curDialogue.speakerPortrait;
            }

            // Type the dialogue sentence character by character
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;

                yield return new WaitForSeconds(0.05f);
            }

            // Finish playing the audio if there is one
            while (voiceAudioSource != null && voiceAudioSource.isPlaying)
            {
                yield return null;
            }

            // If autoplay is on, proceeds to the next sentence
            if (isAutoPlay)
            {
                yield return new WaitForSeconds(0.5f);
                DisplayNextSentence("output");
            }
        }

        /// <summary>
        /// Display the dialogues choices on the screen
        /// </summary>
        /// <param name="curDialogue">The current node in the dialogue graph</param>
        private void DisplayChoices(DialogueChoicesNode curDialogue)
        {
            int answerIdx = 0;
            foreach (string outputValue in curDialogue.output)
            {
                GameObject buttonChoice = Instantiate(buttonPrefab, buttonParent);
                buttonChoice.GetComponent<TextMeshProUGUI>().text = outputValue;

                int index = answerIdx;
                buttonChoice.GetComponent<Button>().onClick.AddListener(() => { DisplayNextSentence("output " + index); });
                answerIdx++;
            }
        }

        /// <summary>
        /// Handle dialogue related events
        /// </summary>
        /// <param name="curDialogue">The current node in the dialogue graph</param>
        /// <returns></returns>
        private IEnumerator HandleDialogueEvents(DialogueEventsNode curDialogue)
        {
            switch (curDialogue.nodeEvent)
            {
                case DialogueEvents.PauseDialogue:
                    yield return new WaitForSeconds(curDialogue.timer);
                    break;
                default:
                    break;
            }

            DisplayNextSentence("output");
        }

        /// <summary>
        /// Handle GameObject related events
        /// </summary>
        /// <param name="curDialogue">The current node in the dialogue graph</param>
        private void HandleGameObjectEvents(DialogueGameObjectEventsNode curDialogue)
        {
            switch (curDialogue.nodeEvent)
            {
                case DialogueGameObjectEvents.ActivateDeactivate:
                    curDialogue.targetGameObject.SetActive(curDialogue.activeStatus);
                    break;
                default:
                    break;
            }

            DisplayNextSentence("output");
        }

        /// <summary>
        /// Handle sound related events
        /// </summary>
        /// <param name="curDialogue"></param>
        private void HandleSoundEvents(DialogueSoundEventsNode curDialogue)
        {
            switch (curDialogue.nodeEvent)
            {
                case DialogueSoundEvents.PlayBGM:
                    if (bgmAudioSource.isPlaying)
                    {
                        bgmAudioSource.Stop();
                    }

                    bgmAudioSource.clip = curDialogue.audioClip;
                    bgmAudioSource.Play();
                    break;
                case DialogueSoundEvents.PlaySE:
                    if (seAudioSource.isPlaying)
                    {
                        seAudioSource.Stop();
                    }

                    seAudioSource.clip = curDialogue.audioClip;
                    seAudioSource.Play();
                    break;
                default:
                    break;
            }

            DisplayNextSentence("output");
        }

        /// <summary>
        /// Handle timeline related events
        /// </summary>
        /// <param name="curDialogue">The current node in the dialogue graph</param>
        /// <returns></returns>
        private IEnumerator HandleTimelineEvents(DialogueTimelineEventNode curDialogue)
        {
            switch (curDialogue.nodeEvent)
            {
                case DialogueTimelineEvents.PlayTimelineSync:
                    timeline.Play();
                    if (curDialogue.timer > 0f)
                    {
                        yield return new WaitForSeconds(curDialogue.timer);
                        timeline.Pause(); 
                    }
                    break;
                case DialogueTimelineEvents.PlayTimelineAsync:
                    timeline.Play();
                    if (curDialogue.timer > 0f)
                    {
                        StartCoroutine(PauseTimeline(curDialogue.timer));
                    }
                    break;
                case DialogueTimelineEvents.PauseTimeline:
                    timeline.Pause();
                    break;
                case DialogueTimelineEvents.RestartTimeline:
                    timeline.time = 0f;
                    break;
                case DialogueTimelineEvents.JumpToTimeline:
                    timeline.time = curDialogue.timer;
                    break;
                default:
                    break;
            }

            DisplayNextSentence("output");
        }

        /// <summary>
        /// Pause the execution of the timeline
        /// </summary>
        /// <param name="timer">How long should it wait before pausing it</param>
        /// <returns></returns>
        private IEnumerator PauseTimeline(float timer)
        {
            yield return new WaitForSeconds(timer);
            timeline.Pause();
        }
    }
}
