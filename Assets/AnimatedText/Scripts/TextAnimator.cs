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

        private Coroutine typingCoroutine;
        public float DefaultTypingSpeed { get; set; }

        public Action<char> OnCharTyped;
        public Action OnStartedTyping;
        public Action OnFinishedTyping;
        public Action<string> OnDialogueAction;

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

                Vector3[] sourceVertices = textMeshProUGUI.textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

                foreach (ITextAnimator textAnimation in indexAnimationPair.charAnimationsArray)
                {
                    int materialIndex = charInfo.materialReferenceIndex;
                    int vertexIndex = charInfo.vertexIndex;

                    Vector2 charMidBasline = (sourceVertices[vertexIndex + 0] + sourceVertices[vertexIndex + 2]) / 2;
                    Vector3 offset = charMidBasline;

                    Vector3[] destinationVertices = textMeshProUGUI.textInfo.meshInfo[materialIndex].vertices;

                    for (int j = 0; j < 4; j++)
                    {
                        destinationVertices[vertexIndex + j] = sourceVertices[vertexIndex + j] - offset;

                        Matrix4x4 matrix = textAnimation.GenerateTranformMatrix(indexAnimationPair.index);

                        destinationVertices[vertexIndex + j] = matrix.MultiplyPoint3x4(destinationVertices[vertexIndex + j]);
                        destinationVertices[vertexIndex + j] += offset;
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
                        for (int j = displayText.Length - subTexts[i].Length - richtagOffset; j < displayText.Length - richtagOffset; j++)
                        {
                            animatedCharList.Add(new IndexAnimationPair(j, currentlyTextAnimationList.ToArray()));
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
        /// "Type" each character on screen
        /// </summary>
        /// <param name="subTexts">Array containing the text information to be typed</param>
        /// <returns></returns>
        private IEnumerator TypewriterCoroutine(string[] subTexts)
        {
            int subCounter = 0;
            int visibleCounter = 0;

            typingSpeed = DefaultTypingSpeed;
            OnStartedTyping?.Invoke();

            while (subCounter < subTexts.Length)
            {
                if (subCounter % 2 == 0) // text without a tag
                {
                    while (visibleCounter < subTexts[subCounter].Length)
                    {
                        OnCharTyped?.Invoke(subTexts[subCounter][visibleCounter]);

                        visibleCounter++;
                        textMeshProUGUI.maxVisibleCharacters++;

                        yield return new WaitForSeconds(typingSpeed);
                    }
                    visibleCounter = 0;
                }
                else // tagged text
                {
                    yield return EvaluateTag(subTexts[subCounter]);
                }

                subCounter++;
            }

            OnFinishedTyping?.Invoke();
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
            if (tag.StartsWith(TagsUtils.WAVE_ANIMATION_START_TAG))
            {
                string parameters = tag.Split('=')[1];
                float frequency = float.Parse(parameters.Split(',')[0]);
                float amplitude = float.Parse(parameters.Split(',')[1]);
                TextWaveAnimation textWaveAnimation = new TextWaveAnimation(frequency, amplitude);
                return textWaveAnimation;
            }
            else if (tag.StartsWith(TagsUtils.SHAKE_ANIMATION_START_TAG))
            {
                float radius = float.Parse(tag.Split('=')[1]);
                TextShakeAnimation textShakeAnimation = new TextShakeAnimation(radius);
                return textShakeAnimation;
            }
            else if (tag.StartsWith(TagsUtils.PULSE_ANIMATION_START_TAG))
            {
                string parameters = tag.Split('=')[1];
                float speed = float.Parse(parameters.Split(',')[0]);
                float variance = float.Parse(parameters.Split(',')[1]);
                float baseValue = float.Parse(parameters.Split(',')[2]);
                TextPulseAnimation textPulseAnimation = new TextPulseAnimation(speed, variance, baseValue);
                return textPulseAnimation;
            }
            else if (tag.StartsWith(TagsUtils.ROTATE_ANIMATION_START_TAG))
            {
                float speed = float.Parse(tag.Split('=')[1]);
                TextRotateAnimation textRotateAnimation = new TextRotateAnimation(speed);
                return textRotateAnimation;
            }
            else
            {
                return null;
            }
        }
    }
}