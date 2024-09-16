using TMPro;
using UnityEngine;

namespace IndicatorSystem
{
	public class UIWaypointIndicator : UIIndicator
	{
        [Header("Waypoint parameters")]
        [SerializeField] private bool offScreenSpriteRotates;

        [Header("Text parameters")]
        [SerializeField] private RectTransform textsContainer;
        [SerializeField] private TextMeshProUGUI distanceText;
        [SerializeField] private TextOffset offScreenDistanceTextOffset;
        [SerializeField] private TextMeshProUGUI indicatorText;
        [SerializeField] private TextOffset offScreenIndicatorTextOffset;

        private Vector3 distanceTextOgPosition;
        private Vector3 indicatorTextOgPosition;

        /// <summary>
        /// Gets the distance text element.
        /// </summary>
        public TextMeshProUGUI DistanceText => distanceText;

        /// <summary>
        /// Gets the indicator text element.
        /// </summary>
        public TextMeshProUGUI IndicatorText => indicatorText;

        /// <summary>
        /// Gets or sets a value indicating whether the off-screen sprite rotates.
        /// </summary>
        public bool OffScreenSpriteRotates
        {
            get { return offScreenSpriteRotates; }
            private set { offScreenSpriteRotates = value; }
        }

        protected override void Awake()
        {
            base.Awake();

            if (distanceText != null)
                distanceTextOgPosition = distanceText.transform.localPosition;
            if (indicatorText != null)
                indicatorTextOgPosition = indicatorText.transform.localPosition;

            DeactivateTexts();
        }

        /// <summary>
        /// Sets the position of the text elements, adjusting for off-screen locations.
        /// </summary>
        /// <param name="pos">The position to set the texts to.</param>
        /// <param name="isLocal">If true, sets local position; otherwise, sets world position.</param>
        /// <param name="offScreenLocations">The text currently off-screen locations.</param>
        public void SetTextsPosition(Vector3 pos, bool isLocal, OffScreenLocations offScreenLocations)
        {
            if (textsContainer == null)
                return;

            if (isLocal)
                textsContainer.localPosition = pos;
            else
                textsContainer.position = pos;

            AdjustOffScreenTextPosition(distanceText, distanceTextOgPosition, offScreenLocations, offScreenDistanceTextOffset);
            AdjustOffScreenTextPosition(indicatorText, indicatorTextOgPosition, offScreenLocations, offScreenIndicatorTextOffset);
        }

        /// <summary>
        /// Sets the text for the distance text element.
        /// </summary>
        /// <param name="distance">The distance value to display.</param>
        public void SetDistanceText(string distance)
        {
            if (distanceText == null)
                return;

            distanceText.text = distance;
        }

        /// <summary>
        /// Sets the text for the indicator text element.
        /// </summary>
        /// <param name="text">The indicator text to display.</param>
        public void SetIndicatorText(string text)
        {
            if (indicatorText == null)
                return;

            indicatorText.text = text;
        }

        /// <summary>
        /// Updates the state of the text elements, activating or deactivating them based on the specified parameters.
        /// </summary>
        /// <param name="displayDistanceText">If true, displays the distance text; otherwise, hides it.</param>
        /// <param name="displayIndicatorText">If true, displays the indicator text; otherwise, hides it.</param>
        public void UpdateTextsState(bool displayDistanceText, bool displayIndicatorText)
        {
            if (displayDistanceText)
                ActivateDistanceText();
            else
                DeactivateDistanceText();

            if (displayIndicatorText)
                ActivateIndicatorText();
            else
                DeactivateIndicatorText();
        }

        /// <summary>
        /// Activates the specified text elements.
        /// </summary>
        /// <param name="displayDistanceText">If true, activates the distance text.</param>
        /// <param name="displayIndicatorText">If true, activates the indicator text.</param>
        public void ActivateTexts(bool displayDistanceText, bool displayIndicatorText)
        {
            if (displayDistanceText)
                ActivateDistanceText();
            if (displayIndicatorText)
                ActivateIndicatorText();
        }

        /// <summary>
        /// Activates the distance text element.
        /// </summary>
        public void ActivateDistanceText()
        {
            if (distanceText != null && !distanceText.gameObject.activeInHierarchy)
                distanceText.gameObject.SetActive(true);
        }

        /// <summary>
        /// Activates the indicator text element.
        /// </summary>
        public void ActivateIndicatorText()
        {
            if (indicatorText != null && !indicatorText.gameObject.activeInHierarchy)
                indicatorText.gameObject.SetActive(true);
        }

        /// <summary>
        /// Deactivates all text elements.
        /// </summary>
        public void DeactivateTexts()
        {
            DeactivateDistanceText();
            DeactivateIndicatorText();
        }

        /// <summary>
        /// Deactivates the distance text element.
        /// </summary>
        public void DeactivateDistanceText()
        {
            if (distanceText != null && distanceText.gameObject.activeInHierarchy)
                distanceText.gameObject.SetActive(false);
        }

        /// <summary>
        /// Deactivates the indicator text element.
        /// </summary>
        public void DeactivateIndicatorText()
        {
            if (indicatorText != null && indicatorText.gameObject.activeInHierarchy)
                indicatorText.gameObject.SetActive(false);
        }

        /// <summary>
        /// Sets the off-screen offset for both the distance text and the indicator text.
        /// </summary>
        /// <param name="newDistanceTextOffset">The new offset for the distance text.</param>
        /// <param name="newIndicatorTextOffset">The new offset for the indicator text.</param>
        public void SetTextOffScreenOffset(TextOffset newDistanceTextOffset, TextOffset newIndicatorTextOffset)
        {
            SetDistanceTextOffScreenOffset(newDistanceTextOffset);
            SetIndicatorTextOffScreenOffset(newIndicatorTextOffset);
        }

        /// <summary>
        /// Sets the off-screen offset for the distance text element.
        /// </summary>
        /// <param name="newTextOffset">The new offset to apply to the distance text.</param>
        public void SetDistanceTextOffScreenOffset(TextOffset newTextOffset)
        {
            offScreenDistanceTextOffset = newTextOffset;
        }

        /// <summary>
        /// Sets the off-screen offset for the indicator text element.
        /// </summary>
        /// <param name="newTextOffset">The new offset to apply to the indicator text.</param>
        public void SetIndicatorTextOffScreenOffset(TextOffset newTextOffset)
        {
            offScreenIndicatorTextOffset = newTextOffset;
        }

        /// <summary>
        /// Adjusts the position of a text element based on its original position and off-screen location settings.
        /// </summary>
        /// <param name="tmPro">The TextMeshProUGUI component to adjust.</param>
        /// <param name="ogPosition">The original position of the text element.</param>
        /// <param name="offScreenLocations">The text currently off-screen locations.</param>
        /// <param name="textOffset">The offset to apply when the text is off-screen.</param>
        private void AdjustOffScreenTextPosition(TextMeshProUGUI tmPro, Vector3 ogPosition, OffScreenLocations offScreenLocations, TextOffset textOffset)
        {
            if (tmPro == null)
                return;

            tmPro.transform.localPosition = ogPosition;

            if (offScreenLocations.HasFlag(OffScreenLocations.Top))
                tmPro.transform.localPosition += new Vector3(0f, textOffset.Top, 0f);
            if (offScreenLocations.HasFlag(OffScreenLocations.Bottom))
                tmPro.transform.localPosition += new Vector3(0f, textOffset.Bottom, 0f);
            if (offScreenLocations.HasFlag(OffScreenLocations.Left))
                tmPro.transform.localPosition += new Vector3(textOffset.Left, 0f, 0f);
            if (offScreenLocations.HasFlag(OffScreenLocations.Right))
                tmPro.transform.localPosition += new Vector3(textOffset.Right, 0f, 0f);
        }

        public static string GetNameOfOffScreenSpriteRotates => nameof(offScreenSpriteRotates);
        public static string GetNameOfTextsContainer => nameof(textsContainer);
        public static string GetNameOfDistanceText => nameof(distanceText);
        public static string GetNameOfDistanceOffset => nameof(offScreenDistanceTextOffset);
        public static string GetNameOfIndicatorText => nameof(indicatorText);
        public static string GetNameOfIndicatorOffset => nameof(offScreenIndicatorTextOffset);
    }
}