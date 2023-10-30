using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TooltipSystem
{
	public class TooltipController : MonoBehaviour
	{
        [SerializeField] private List<Tooltip> tooltipsPrefab;
        [SerializeField] private bool disableTooltips;
        [SerializeField] private bool useFadeIn;
        [SerializeField] private float fadeInTime;
        [SerializeField] private EasingType fadeInEasingType;
        [SerializeField] private bool useFadeOut;
        [SerializeField] private float fadeOutTime;
        [SerializeField] private EasingType fadeOutEasingType;

        private Dictionary<TooltipStyle, Tooltip> styleTooltipDictionary;

        private static TooltipController instance;

        public static TooltipController Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject instantiatedGameObject = new GameObject(nameof(TooltipController));
                    instance = instantiatedGameObject.AddComponent<TooltipController>();
                }

                return instance;
            }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
                Destroy(this.gameObject);
            else
                instance = this;

            InitializeTooltipController();
        }

        /// <summary>
        /// Show a tooltip
        /// </summary>
        /// <param name="style">The style of the tooltip to show</param>
        /// <param name="tooltipParams">The parameters for the tooltip</param>
        public void Show(TooltipStyle style, TooltipParams tooltipParams)
        {
            if (!styleTooltipDictionary.ContainsKey(style) || disableTooltips)
                return;

            styleTooltipDictionary[style].SetTooltipValues(tooltipParams);
            styleTooltipDictionary[style].SetTooltipPosition();

            if (useFadeIn && styleTooltipDictionary[style].GetCanvasGroup != null)
                FadeInTooltip(styleTooltipDictionary[style]);
            else
                styleTooltipDictionary[style].gameObject.SetActive(true);
        }

        /// <summary>
        /// Hide a tooltip
        /// </summary>
        /// <param name="style">The style of the tooltip to hide</param>
        public void Hide(TooltipStyle style)
        {
            if (!styleTooltipDictionary.ContainsKey(style))
                return;

            if (useFadeOut && styleTooltipDictionary[style].GetCanvasGroup != null)
                FadeOutTooltip(styleTooltipDictionary[style]);
            else
                styleTooltipDictionary[style].gameObject.SetActive(false);
        }

        /// <summary>
        /// Update a tooltip values
        /// </summary>
        /// <param name="style">The style of the tooltip to update</param>
        /// <param name="tooltipParams">The updated parameters for the tooltip</param>
        public void UpdateTooltipValues(TooltipStyle style, TooltipParams tooltipParams)
        {
            if (!styleTooltipDictionary.ContainsKey(style) || disableTooltips)
                return;

            styleTooltipDictionary[style].SetTooltipValues(tooltipParams);
        }

        /// <summary>
        /// Initialize the tooltip controller
        /// </summary>
        public void InitializeTooltipController()
        {
            styleTooltipDictionary = new Dictionary<TooltipStyle, Tooltip>();

            if (tooltipsPrefab == null)
                tooltipsPrefab = new List<Tooltip>();

            foreach (Tooltip tooltip in tooltipsPrefab)
            {
                AddTooltip(tooltip);
            }
        }

        /// <summary>
        /// Add a tooltip to the controller
        /// </summary>
        /// <param name="newTooltip">The tooltip to be added</param>
        public void AddTooltip(Tooltip newTooltip)
        {
            Tooltip instantiatedTooltip = Instantiate(newTooltip, transform);
            instantiatedTooltip.SetupTooltip();
            instantiatedTooltip.gameObject.SetActive(false);

            styleTooltipDictionary[instantiatedTooltip.GetTooltipStyle] = instantiatedTooltip;
        }

        /// <summary>
        /// Remove a tooltip from the controller
        /// </summary>
        /// <param name="toDestroyTooltip">The tooltip to be removed</param>
        public void RemoveTooltip(Tooltip toDestroyTooltip)
        {
            TooltipStyle style = toDestroyTooltip.GetTooltipStyle;

            if (!styleTooltipDictionary.ContainsKey(style))
                return;

            Destroy(styleTooltipDictionary[style].gameObject);
            styleTooltipDictionary.Remove(style);
        }

        /// <summary>
        /// Set if the controller should display/hide the tooltips
        /// </summary>
        /// <param name="value">True if tooltips should be displayed, false otherwise</param>
        public void EnableDisableTooltips(bool value)
        {
            disableTooltips = value;
        }

        /// <summary>
        /// Close a specific tooltip
        /// </summary>
        /// <param name="tooltipToClose">The tooltip to close</param>
        public void CloseTooltip(Tooltip tooltipToClose)
        {
            Hide(tooltipToClose.GetTooltipStyle);
        }

        /// <summary>
        /// Close a specific tooltip based on its style
        /// </summary>
        /// <param name="style">The tooltip style to close</param>
        public void CloseTooltip(TooltipStyle style)
        {
            Hide(style);
        }

        /// <summary>
        /// Close all tooltips
        /// </summary>
        public void CloseAllTooltips()
        {
            foreach (TooltipStyle style in styleTooltipDictionary.Keys)
            {
                Hide(style);
            }
        }

        /// <summary>
        /// Fade-in a specific tooltip
        /// </summary>
        /// <param name="tooltip">The tooltip to fade-in</param>
        private void FadeInTooltip(Tooltip tooltip)
        {
            tooltip.GetCanvasGroup.alpha = 0;
            tooltip.gameObject.SetActive(true);

            StartCoroutine(ExecuteFade(fadeInTime, 0f, 1f, tooltip.GetCanvasGroup, fadeInEasingType));
        }

        /// <summary>
        /// Fade-out a specific tooltip
        /// </summary>
        /// <param name="tooltip">The tooltip to fade-out</param>
        private void FadeOutTooltip(Tooltip tooltip)
        {
            tooltip.GetCanvasGroup.alpha = 1;

            StartCoroutine(ExecuteFade(fadeOutTime, 1f, 0f, tooltip.GetCanvasGroup, fadeOutEasingType, () =>
            {
                tooltip.gameObject.SetActive(false);
                tooltip.GetCanvasGroup.alpha = 1;
            }));
        }

        /// <summary>
        /// Execute fade in a tooltip
        /// </summary>
        /// <param name="duration">How long should fade last</param>
        /// <param name="initialValue">The initial value for the alpha</param>
        /// <param name="endValue">The final value for the alpha</param>
        /// <param name="targetObject">The target CanvasGroup</param>
        /// <param name="easingType">The type of easing to be applied to the fade</param>
        /// <param name="onComplete">Function to be invoked when fade is complete</param>
        /// <returns></returns>
        private IEnumerator ExecuteFade(float duration, float initialValue, float endValue, CanvasGroup targetObject, EasingType easingType, Action onComplete = null)
        {
            float progress = 0f;
            float startTime = Time.time;

            EasingFunction easingFunction = EasingFactory.GetEasing(easingType);

            while (progress < 1f)
            {
                progress = Mathf.Clamp01((Time.time - startTime) / duration);
                float newAlpha = easingFunction.Evaluate(initialValue, endValue, progress);
                newAlpha = Mathf.Clamp01(newAlpha);

                targetObject.alpha = newAlpha;

                yield return null;
            }

            onComplete?.Invoke();
        }

        public static string GetNameOfTooltipsPrefab => nameof(tooltipsPrefab);
        public static string GetNameOfDisableTooltips => nameof(disableTooltips);
        public static string GetNameOfUseFadeIn => nameof(useFadeIn);
        public static string GetNameOfFadeInTime => nameof(fadeInTime);
        public static string GetNameOfFadeInEasingType => nameof(fadeInEasingType);
        public static string GetNameOfUseFadeOut => nameof(useFadeOut);
        public static string GetNameOfFadeOutTime => nameof(fadeOutTime);
        public static string GetNameOfFadeOutEasingType => nameof(fadeOutEasingType);
    }
}