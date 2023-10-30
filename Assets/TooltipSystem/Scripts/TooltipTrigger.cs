using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TooltipSystem
{
	public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
        [SerializeField] private TooltipStyle tooltipStyle;
        [SerializeField] private List<IDElementPair<string>> tooltipTextsPair;
        [SerializeField] private List<IDElementPair<Sprite>> tooltipSpritesPair;

        [SerializeField] private TooltipPosition tooltipPosition;
        [SerializeField] private Transform tooltipTransformPosition;
        [SerializeField] private Vector3 tooltipVectorPosition;

        [SerializeField] private float delay;

        private Coroutine delayCoroutine;

        private Dictionary<string, string> tooltipTexts;
        private Dictionary<string, Sprite> tooltipSprites;

        public TooltipStyle GetTooltipStyle => tooltipStyle;

        private void Awake()
        {
            SetupTrigger();
        }

        /// <summary>
        /// Setup the trigger dictionaries
        /// </summary>
        private void SetupTrigger()
        {
            tooltipTexts = new Dictionary<string, string>();
            tooltipSprites = new Dictionary<string, Sprite>();

            foreach (IDElementPair<string> pair in tooltipTextsPair)
            {
                tooltipTexts[pair.ID] = pair.element;
            }

            foreach (IDElementPair<Sprite> pair in tooltipSpritesPair)
            {
                tooltipSprites[pair.ID] = pair.element;
            }
        }

        /// <summary>
        /// Update one of the texts for this trigger
        /// </summary>
        /// <param name="textID">The text ID</param>
        /// <param name="newText">The value of the new text</param>
        public void UpdateText(string textID, string newText)
        {
            if (!tooltipTexts.ContainsKey(textID))
                return;

            tooltipTexts[textID] = newText;
            TooltipParams tooltipParams = new TooltipParams(tooltipTexts, tooltipSprites, tooltipPosition, tooltipTransformPosition, tooltipVectorPosition);
            TooltipController.Instance.UpdateTooltipValues(GetTooltipStyle, tooltipParams);
        }

        /// <summary>
        /// Update one of the sprites for this trigger
        /// </summary>
        /// <param name="spriteID">The sprite ID</param>
        /// <param name="newSprite">The value of the new sprite</param>
        public void UpdateSprite(string spriteID, Sprite newSprite)
        {
            if (!tooltipSprites.ContainsKey(spriteID))
                return;

            tooltipSprites[spriteID] = newSprite;
            TooltipParams tooltipParams = new TooltipParams(tooltipTexts, tooltipSprites, tooltipPosition, tooltipTransformPosition, tooltipVectorPosition);
            TooltipController.Instance.UpdateTooltipValues(GetTooltipStyle, tooltipParams);
        }

        /// <summary>
        /// Get all the keys associated with this trigger
        /// </summary>
        /// <returns>Trigger's keys</returns>
        public IEnumerator<string> GetTriggerKeys()
        {
            foreach (string id in tooltipTexts.Keys)
                yield return id;

            foreach (string id in tooltipSprites.Keys)
                yield return id;
        }

        /// <summary>
        /// Get all the text keys asssociated with this trigger
        /// </summary>
        /// <returns>Trigger's text keys</returns>
        public IEnumerator<string> GetTriggerTextKeys()
        {
            foreach (string id in tooltipTexts.Keys)
                yield return id;
        }

        /// <summary>
        /// Get all the sprite keys associated with this trigger
        /// </summary>
        /// <returns>Trigger's sprite keys</returns>
        public IEnumerator<string> GetTriggerSpriteKeys()
        {
            foreach (string id in tooltipSprites.Keys)
                yield return id;
        }

        /// <summary>
        /// Invoked when mouse enter a collider
        /// </summary>
        private void OnMouseEnter()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            delayCoroutine = StartCoroutine(Delay());
        }

        /// <summary>
        /// Invoked when mouse leaves a collider
        /// </summary>
        private void OnMouseExit()
        {
            StopCoroutine(delayCoroutine);
            TooltipController.Instance.Hide(GetTooltipStyle);
        }

        /// <summary>
        /// Invoked when mouse enter an UI element
        /// </summary>
        /// <param name="eventData">The eventData</param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            delayCoroutine = StartCoroutine(Delay());
        }

        /// <summary>
        /// Invoked when mouse leaves an UI element
        /// </summary>
        /// <param name="eventData">The eventData</param>
        public void OnPointerExit(PointerEventData eventData)
        {
            StopCoroutine(delayCoroutine);
            TooltipController.Instance.Hide(GetTooltipStyle);
        }

        /// <summary>
        /// Delay the display of the tooltip
        /// </summary>
        /// <returns></returns>
        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(delay);
            TooltipParams tooltipParams = new TooltipParams(tooltipTexts, tooltipSprites, tooltipPosition, tooltipTransformPosition, tooltipVectorPosition);
            TooltipController.Instance.Show(GetTooltipStyle, tooltipParams);
        }

        /// <summary>
        /// Reset the trigger
        /// </summary>
        public void ResetTooltip()
        {
            tooltipTextsPair = new List<IDElementPair<string>>();
            tooltipSpritesPair = new List<IDElementPair<Sprite>>();

            if (tooltipStyle == null)
                return;

            foreach (string id in tooltipStyle.GetTextFieldsIds)
            {
                tooltipTextsPair.Add(new IDElementPair<string>(id, null));
            }

            foreach (string id in tooltipStyle.GetImageFieldsIds)
            {
                tooltipSpritesPair.Add(new IDElementPair<Sprite>(id, null));
            }
        }

        public static string GetNameOfStyle => nameof(tooltipStyle);
        public static string GetNameOfTextsPair => nameof(tooltipTextsPair);
        public static string GetNameOfSpritesPair => nameof(tooltipSpritesPair);
        public static string GetNameOfPosition => nameof(tooltipPosition);
        public static string GetNameOfTransform => nameof(tooltipTransformPosition);
        public static string GetNameOfVector => nameof(tooltipVectorPosition);
        public static string GetNameOfDelay => nameof(delay);
    }
}