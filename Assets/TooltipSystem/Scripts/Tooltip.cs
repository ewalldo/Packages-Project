using System.Collections.Generic;
using TMPro;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
using UnityEngine.UI;

namespace TooltipSystem
{
	public class Tooltip : MonoBehaviour
	{
        [SerializeField] private TooltipStyle tooltipStyle;
        [SerializeField] private List<IDElementPair<TMP_Text>> tooltipTextsPair;
        [SerializeField] private List<IDElementPair<Image>> tooltipImagesPair;

        [SerializeField] private LayoutElement mainTextLayoutElement;
        [SerializeField] private float minTextSize;
        [SerializeField] private float maxTextSize;

        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;

        private Dictionary<string, TMP_Text> tooltipTexts;
        private Dictionary<string, Image> tooltipImages;
        private TooltipParams tooltipParams;

        /// <summary>
        /// Get the tooltip style associated with this tooltip
        /// </summary>
        public TooltipStyle GetTooltipStyle => tooltipStyle;
        /// <summary>
        /// Get the CanvasGroup associated with this tooltip
        /// </summary>
        public CanvasGroup GetCanvasGroup => canvasGroup;

        private void Update()
        {
            UpdateTooltipPosition();
        }

        /// <summary>
        /// Setup the tooltip dictionaries and get references to the tooltip rectTransform and CanvasGroup
        /// </summary>
        public void SetupTooltip()
        {
            tooltipTexts = new Dictionary<string, TMP_Text>();
            tooltipImages = new Dictionary<string, Image>();

            foreach (IDElementPair<TMP_Text> pair in tooltipTextsPair)
            {
                tooltipTexts[pair.ID] = pair.element;
            }

            foreach (IDElementPair<Image> pair in tooltipImagesPair)
            {
                tooltipImages[pair.ID] = pair.element;
            }

            rectTransform = GetComponent<RectTransform>();
            TryGetComponent<CanvasGroup>(out canvasGroup);
        }

        /// <summary>
        /// Set the values for this tooltip
        /// </summary>
        /// <param name="tooltipParams">The TooltipParams containing this tooltip information</param>
        public void SetTooltipValues(TooltipParams tooltipParams)
        {
            if (mainTextLayoutElement != null)
                mainTextLayoutElement.preferredWidth = minTextSize;

            foreach (string textID in tooltipParams.TooltipTexts.Keys)
            {
                if (tooltipTexts.ContainsKey(textID))
                {
                    tooltipTexts[textID].text = tooltipParams.TooltipTexts[textID];

                    if (mainTextLayoutElement != null)
                        mainTextLayoutElement.preferredWidth = Mathf.Max(minTextSize, Mathf.Min(maxTextSize, tooltipTexts[textID].preferredWidth));
                }
            }

            foreach (string spriteID in tooltipParams.TooltipSprites.Keys)
            {
                if (tooltipImages.ContainsKey(spriteID))
                    tooltipImages[spriteID].sprite = tooltipParams.TooltipSprites[spriteID];
            }

            this.tooltipParams = tooltipParams;
        }

        /// <summary>
        /// Reset the tooltip
        /// </summary>
        public void ResetTooltip()
        {
            tooltipTextsPair = new List<IDElementPair<TMP_Text>>();
            tooltipImagesPair = new List<IDElementPair<Image>>();

            if (tooltipStyle == null)
                return;

            foreach (string id in tooltipStyle.GetTextFieldsIds)
            {
                tooltipTextsPair.Add(new IDElementPair<TMP_Text>(id, null));
            }

            foreach (string id in tooltipStyle.GetImageFieldsIds)
            {
                tooltipImagesPair.Add(new IDElementPair<Image>(id, null));
            }
        }

        /// <summary>
        /// Set the tooltip initial position
        /// </summary>
        public void SetTooltipPosition()
        {
            switch (tooltipParams.TooltipPosition)
            {
                case TooltipPosition.AtMouseCursor:
                case TooltipPosition.FollowMouseCursor:
                    Vector2 mousePosition = GetMouseLocation();
                    AdjustPivot(mousePosition);
                    transform.position = mousePosition;
                    break;
                case TooltipPosition.AtTransform:
                    AdjustPivot(tooltipParams.TooltipTransform.position);
                    transform.position = tooltipParams.TooltipTransform.position;
                    break;
                case TooltipPosition.AtVector3:
                    AdjustPivot(tooltipParams.TooltipVector);
                    transform.position = tooltipParams.TooltipVector;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Update the tooltip position based on its TooltiPosition associated with it
        /// </summary>
        private void UpdateTooltipPosition()
        {
            switch (tooltipParams.TooltipPosition)
            {
                case TooltipPosition.FollowMouseCursor:
                    Vector2 mousePosition = GetMouseLocation();
                    AdjustPivot(mousePosition);
                    transform.position = mousePosition;
                    break;
                case TooltipPosition.AtTransform:
                    AdjustPivot(tooltipParams.TooltipTransform.position);
                    transform.position = tooltipParams.TooltipTransform.position;
                    break;
                case TooltipPosition.AtMouseCursor:
                case TooltipPosition.AtVector3:
                default:
                    break;
            }
        }

        /// <summary>
        /// Get the current mouse location
        /// </summary>
        /// <returns>The current mouse location</returns>
        private Vector2 GetMouseLocation()
        {
#if !ENABLE_INPUT_SYSTEM
            return Input.mousePosition;
#else
            return Mouse.current.position.ReadValue();
#endif
        }

        /// <summary>
        /// Adjust the tooltip pivot based on the a Vector2 position
        /// </summary>
        /// <param name="screenPosition"></param>
        private void AdjustPivot(Vector2 screenPosition)
        {
            float pivotX = screenPosition.x / Screen.width;
            float pivotY = screenPosition.y / Screen.height;

            if (pivotX < 0.5f) //mouse on left side
                pivotX = 0f;// -0.1f;
            else
                pivotX = 1f;// 1.01f;

            if (pivotY < 0.5f) //mouse on the bottom side
                pivotY = 0;
            else
                pivotY = 1f;

            rectTransform.pivot = new Vector2(pivotX, pivotY);
        }

        public static string GetNameOfStyle => nameof(tooltipStyle);
        public static string GetNameOfTextsPair => nameof(tooltipTextsPair);
        public static string GetNameOfImagesPair => nameof(tooltipImagesPair);
        public static string GetNameOfLayoutElement => nameof(mainTextLayoutElement);
        public static string GetNameOfMinTextSize => nameof(minTextSize);
        public static string GetNameOfMaxTextSize => nameof(maxTextSize);
    }
}