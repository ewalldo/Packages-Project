using System;
using UnityEngine;
using UnityEngine.UI;

namespace AnimatedText
{
    public class NextDialogueIconVisual : MonoBehaviour
    {
        [SerializeField] private TextAnimator textAnimator;

        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void Start()
        {
            textAnimator.OnStartedTyping += TextAnimator_OnStartedTyping;
            textAnimator.OnFinishedTyping += TextAnimator_OnFinishedTyping;
        }

        private void Update()
        {
            if (image.enabled)
                image.color = new Color(1f, 1f, 1f, Mathf.Sin(Time.time * 5f) * 0.5f + 0.5f);
        }

        private void TextAnimator_OnStartedTyping()
        {
            image.enabled = false;
        }

        private void TextAnimator_OnFinishedTyping()
        {
            image.enabled = true;
        }
    }
}