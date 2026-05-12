using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AnimatedText
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class TextAnimator : MonoBehaviour
	{
        [Tooltip("The pause between characters (in seconds) when typing the text on screen")]
        [SerializeField] private float typingSpeed = 0.04f;

        private TextMeshProUGUI textMeshProUGUI;

        private List<IndexAnimationPair> animatedCharList;
        private class IndexAnimationPair
        {
            public int index;
            public ITextAnimator[] charAnimationsArray;

            public IndexAnimationPair(int index, ITextAnimator[] charAnimationsArray)
            {
                this.index = index;
                this.charAnimationsArray = charAnimationsArray;
            }
        }
        private Stack<ITextAnimator> currentlyTextAnimationList;
        private readonly Vector3[] vertexCache = new Vector3[4];

        private Coroutine typingCoroutine;
        private string[] currentSubTexts;
        private int currentSubTextIndex;
        //private bool isPaused;

        public float DefaultTypingSpeed { get; set; }
        public bool IsTyping { get; private set; }

        public event Action<char> OnCharTyped;
        public event Action OnStartedTyping;
        public event Action OnFinishedTyping;
        public event Action<string> OnDialogueAction;

        private void Awake()
        {
            textMeshProUGUI = GetComponent<TextMeshProUGUI>();
            DefaultTypingSpeed = typingSpeed;
        }

        private void LateUpdate()
        {
            if (animatedCharList == null || animatedCharList.Count == 0)
                return;

            textMeshProUGUI.ForceMeshUpdate();

            foreach (IndexAnimationPair indexAnimationPair in animatedCharList)
            {
                TMP_CharacterInfo charInfo = textMeshProUGUI.textInfo.characterInfo[indexAnimationPair.index];

                if (!charInfo.isVisible)
                    continue;

                int materialIndex = charInfo.materialReferenceIndex;
                int vertexIndex = charInfo.vertexIndex;
                Vector3[] meshVertices = textMeshProUGUI.textInfo.meshInfo[materialIndex].vertices;

                // Cache original positions before any animation modifies them
                for (int j = 0; j < 4; j++)
                    vertexCache[j] = meshVertices[vertexIndex + j];

                Vector2 charMidBasline = (vertexCache[0] + vertexCache[2]) / 2;

                foreach (ITextAnimator textAnimation in indexAnimationPair.charAnimationsArray)
                {
                    if (textAnimation == null)
                        continue;

                    Matrix4x4 matrix = textAnimation.GenerateTransformMatrix(indexAnimationPair.index);

                    for (int j = 0; j < 4; j++)
                    {
                        Vector3 v = meshVertices[vertexIndex + j] - (Vector3)charMidBasline;
                        meshVertices[vertexIndex + j] = matrix.MultiplyPoint3x4(v) + (Vector3)charMidBasline;
                    }
                }
            }

            for (int i = 0; i < textMeshProUGUI.textInfo.meshInfo.Length; i++)
            {
                TMP_MeshInfo meshInfo = textMeshProUGUI.textInfo.meshInfo[i];
                meshInfo.mesh.vertices = meshInfo.vertices;
                textMeshProUGUI.UpdateGeometry(meshInfo.mesh, i);
            }
        }

        /// <summary>
        /// Start typing the text on screen
        /// </summary>
        /// <param name="textToType">The text to be typed</param>
        public void TypeText(string textToType)
        {
            textMeshProUGUI.text = string.Empty;

            animatedCharList = new List<IndexAnimationPair>();
            currentlyTextAnimationList = new Stack<ITextAnimator>();
            int richtagOffset = 0;

            // even index are text, odd are tags
            string[] subTexts = textToType.Split('<', '>');

            string displayText = "";

            for (int i = 0; i < subTexts.Length; i++)
            {
                if (i % 2 == 0)
                {
                    displayText += subTexts[i];

                    if (currentlyTextAnimationList.Count > 0)
                    {
                        ITextAnimator[] currentAnimations = currentlyTextAnimationList.ToArray();
                        for (int j = displayText.Length - subTexts[i].Length - richtagOffset; j < displayText.Length - richtagOffset; j++)
                        {
                            animatedCharList.Add(new IndexAnimationPair(j, currentAnimations));
                        }
                    }
                }
                else if (!TagsUtils.IsCustomTag(subTexts[i]))
                {
                    displayText += $"<{subTexts[i]}>";
                    richtagOffset += subTexts[i].Length + 2;
                }
                else if (TagsUtils.IsReplaceTag(subTexts[i]))
                {
                    subTexts[i + 1] = ReplaceTagParser.ParseKey(subTexts[i].Split('=')[1]) + subTexts[i + 1];
                }
                else if (TagsUtils.IsStartAnimationTag(subTexts[i]))
                {
                    currentlyTextAnimationList.Push(GetTextAnimationFromTag(subTexts[i]));
                }
                else if (TagsUtils.IsEndAnimationTag(subTexts[i]))
                {
                    currentlyTextAnimationList.Pop();
                }
            }

            textMeshProUGUI.text = displayText;
            textMeshProUGUI.maxVisibleCharacters = 0;

            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);
            typingCoroutine = StartCoroutine(TypewriterCoroutine(subTexts));
        }

        /// <summary>
        /// Instantly reveals all characters, skipping the typewriter effect
        /// </summary>
        public void SkipTyping()
        {
            if (typingCoroutine == null)
                return;

            StopCoroutine(typingCoroutine);
            typingCoroutine = null;

            ProcessRemainingTags();

            textMeshProUGUI.maxVisibleCharacters = textMeshProUGUI.textInfo.characterCount;

            FinishTyping();
        }

        /// <summary>
        /// Pauses the typewriter effect, keeping the current visible characters on screen
        /// </summary>
        public void PauseTyping()
        {
            if (!IsTyping)
                return;

            IsTyping = false;
        }

        /// <summary>
        /// Resumes the typewriter effect from the current visible characters on screen
        /// </summary>
        public void ResumeTyping()
        {
            if (IsTyping)
                return;

            IsTyping = true;
        }

        /// <summary>
        /// "Type" each character on screen
        /// </summary>
        /// <param name="subTexts">Array containing the text information to be typed</param>
        /// <returns></returns>
        private IEnumerator TypewriterCoroutine(string[] subTexts)
        {
            currentSubTexts = subTexts;
            currentSubTextIndex = 0;
            int visibleCounter = 0;

            typingSpeed = DefaultTypingSpeed;
            IsTyping = true;
            OnStartedTyping?.Invoke();

            while (currentSubTextIndex < subTexts.Length)
            {
                if (currentSubTextIndex % 2 == 0) // text without a tag
                {
                    while (visibleCounter < subTexts[currentSubTextIndex].Length)
                    {
                        while (!IsTyping)
                            yield return null;

                        OnCharTyped?.Invoke(subTexts[currentSubTextIndex][visibleCounter]);

                        visibleCounter++;
                        textMeshProUGUI.maxVisibleCharacters++;

                        yield return new WaitForSeconds(typingSpeed);
                    }
                    visibleCounter = 0;
                }
                else // tagged text
                {
                    yield return EvaluateTag(subTexts[currentSubTextIndex]);
                }

                currentSubTextIndex++;
            }

            FinishTyping();
        }

        /// <summary>
        /// Evaluate a runtime tag
        /// </summary>
        /// <param name="tag">The tag to be evaluated</param>
        /// <returns></returns>
        private IEnumerator EvaluateTag(string tag)
        {
            if (tag.Length == 0)
                yield break;

            if (!TagsUtils.IsCustomTag(tag))
                yield break;

            if (TagsUtils.IsStartAnimationTag(tag) || TagsUtils.IsEndAnimationTag(tag))
                yield break;

            if (tag.StartsWith(TagsUtils.SPEED_TAG))
            {
                typingSpeed = float.Parse(tag.Split('=')[1]);
            }
            else if (tag.StartsWith(TagsUtils.PAUSE_TAG))
            {
                yield return new WaitForSeconds(float.Parse(tag.Split('=')[1]));
            }
            else if (tag.StartsWith(TagsUtils.ACTION_TAG))
            {
                OnDialogueAction?.Invoke(tag.Split('=')[1]);
            }
            else
            {
                yield return null;
            }
        }

        /// <summary>
        /// Instantiate an ITextAnimator class based on a tag value
        /// </summary>
        /// <param name="tag">The string containing the tag information</param>
        /// <returns>An ITextAnimator created based on the tag parameter</returns>
        private ITextAnimator GetTextAnimationFromTag(string tag)
        {
            if (tag.StartsWith(TextWaveAnimation.START_ANIMATION_TAG))
            {
                string parameters = tag.Split('=')[1];
                string[] parts = parameters.Split(',');
                float frequency = float.Parse(parts[0]);
                float amplitude = float.Parse(parts[1]);
                TextWaveAnimation textWaveAnimation = new TextWaveAnimation(frequency, amplitude);
                return textWaveAnimation;
            }
            else if (tag.StartsWith(TextShakeAnimation.START_ANIMATION_TAG))
            {
                float radius = float.Parse(tag.Split('=')[1]);
                TextShakeAnimation textShakeAnimation = new TextShakeAnimation(radius);
                return textShakeAnimation;
            }
            else if (tag.StartsWith(TextPulseAnimation.START_ANIMATION_TAG))
            {
                string parameters = tag.Split('=')[1];
                string[] parts = parameters.Split(',');
                float speed = float.Parse(parts[0]);
                float variance = float.Parse(parts[1]);
                float baseValue = float.Parse(parts[2]);
                TextPulseAnimation textPulseAnimation = new TextPulseAnimation(speed, variance, baseValue);
                return textPulseAnimation;
            }
            else if (tag.StartsWith(TextRotateAnimation.START_ANIMATION_TAG))
            {
                float speed = float.Parse(tag.Split('=')[1]);
                TextRotateAnimation textRotateAnimation = new TextRotateAnimation(speed);
                return textRotateAnimation;
            }
            else
            {
                Debug.LogWarning($"[TextAnimator] Unknown animation tag: {tag}");
                return null;
            }
        }

        private void FinishTyping()
        {
            typingCoroutine = null;
            IsTyping = false;
            OnFinishedTyping?.Invoke();
        }

        private void ProcessRemainingTags()
        {
            if (currentSubTexts == null || currentSubTexts.Length == 0)
                return;

            for (int i = currentSubTextIndex + 1; i < currentSubTexts.Length; i++)
            {
                if (i % 2 == 0) // text segment, does not have a tag
                    continue;

                string tag = currentSubTexts[i];

                if (tag.StartsWith(TagsUtils.ACTION_TAG)) // handle action tag
                {
                    OnDialogueAction?.Invoke(tag.Split('=')[1]);
                }
                // the remaining tags [SPEED_TAG][PAUSE_TAG] does not need to be processed on skip
            }
        }
    }
}