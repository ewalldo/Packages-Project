using UnityEngine;

namespace AnimatedText
{
    public class NextDialogueIconVisual : MonoBehaviour
    {
        [SerializeField] private TextAnimator textAnimator;

        private CanvasGroup canvasGroup;
        private bool shouldAnimateIcon;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            shouldAnimateIcon = false;
        }

        private void Start()
        {
            textAnimator.OnStartedTyping += TextAnimator_OnStartedTyping;
            textAnimator.OnFinishedTyping += TextAnimator_OnFinishedTyping;
        }

        private void Update()
        {
            if (shouldAnimateIcon)
                canvasGroup.alpha = Mathf.Sin(Time.time * 5f) * 0.5f + 0.5f;
        }

        private void TextAnimator_OnStartedTyping()
        {
            canvasGroup.alpha = 0f;
            shouldAnimateIcon = false;
        }

        private void TextAnimator_OnFinishedTyping()
        {
            canvasGroup.alpha = 1f;
            shouldAnimateIcon = true;
        }
    }
}