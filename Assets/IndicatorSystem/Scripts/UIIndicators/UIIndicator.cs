using System;
using UnityEngine;
using UnityEngine.UI;

namespace IndicatorSystem
{
	[RequireComponent(typeof(RectTransform))]
	public abstract class UIIndicator : MonoBehaviour
	{
        [SerializeField] protected RectTransform screenIndicatorsContainer;
        [SerializeField] protected Image onScreenIndicator;
        [SerializeField] protected Image offScreenIndicator;

        [Header("Bound box parameters")]
        [SerializeField] protected Vector2 boundBoxSize = new Vector2(100, 100);

        public Vector2 BoundBoxSize => boundBoxSize;

        public event Action OnActivateOnScreenIndicator;
        public event Action OnActivateOffScreenIndicator;

        protected virtual void Awake()
        {
            DeactivateIndicators();

            GetComponent<RectTransform>().sizeDelta = BoundBoxSize;
        }

        /// <summary>
        /// Sets the position and rotation of the screen indicators.
        /// </summary>
        /// <param name="pos">The position of the indicators.</param>
        /// <param name="rot">The rotation of the indicators.</param>
        /// <param name="isLocal">If true, sets local position and rotation; otherwise, sets world position and rotation.</param>
        public void SetScreenIndicatorsPositionAndRotation(Vector3 pos, Quaternion rot, bool isLocal)
        {
            if (screenIndicatorsContainer == null)
                return;

            if (isLocal)
            {
                screenIndicatorsContainer.localPosition = pos;
                screenIndicatorsContainer.localRotation = rot;
            }
            else
            {
                screenIndicatorsContainer.SetPositionAndRotation(pos, rot);
            }
        }

        /// <summary>
        /// Sets the position of the screen indicators.
        /// </summary>
        /// <param name="pos">The position of the indicators.</param>
        /// <param name="isLocal">If true, sets local position; otherwise, sets world position.</param>
        public void SetScreenIndicatorsPosition(Vector3 pos, bool isLocal)
        {
            if (screenIndicatorsContainer == null)
                return;

            if (isLocal)
                screenIndicatorsContainer.localPosition = pos;
            else
                screenIndicatorsContainer.position = pos;
        }

        /// <summary>
        /// Sets the rotation of the screen indicators.
        /// </summary>
        /// <param name="rot">The rotation of the indicators.</param>
        /// <param name="isLocal">If true, sets local rotation; otherwise, sets world rotation.</param>
        public void SetScreenIndicatorsRotation(Quaternion rot, bool isLocal)
        {
            if (screenIndicatorsContainer == null)
                return;

            if (isLocal)
                screenIndicatorsContainer.localRotation = rot;
            else
                screenIndicatorsContainer.rotation = rot;
        }

        /// <summary>
        /// Deactivates both on-screen and off-screen indicators.
        /// </summary>
        public void DeactivateIndicators()
        {
            if (onScreenIndicator != null && onScreenIndicator.gameObject.activeInHierarchy)
                SetActiveIndicator(onScreenIndicator, false);
            if (offScreenIndicator != null && offScreenIndicator.gameObject.activeInHierarchy)
                SetActiveIndicator(offScreenIndicator, false);
        }

        /// <summary>
        /// Activates the on-screen indicator and deactivates the off-screen indicator.
        /// </summary>
        public void SetActiveOnScreenIndicator()
        {
            if (onScreenIndicator != null && onScreenIndicator.gameObject.activeInHierarchy)
                return;

            SetActiveIndicator(onScreenIndicator, true);
            SetActiveIndicator(offScreenIndicator, false);

            OnActivateOnScreenIndicator?.Invoke();
        }

        /// <summary>
        /// Sets the sprite and optional tint color for the on-screen indicator.
        /// </summary>
        /// <param name="onScreenSprite">The sprite to set for the on-screen indicator.</param>
        /// <param name="tintColor">The optional tint color to apply to the sprite.</param>
        public void SetOnScreenIndicatorSprite(Sprite onScreenSprite, Color? tintColor = null)
        {
            SetIndicatorSprite(onScreenIndicator, onScreenSprite, tintColor);
        }

        /// <summary>
        /// Sets the alpha transparency of the on-screen indicator.
        /// </summary>
        /// <param name="alpha">The alpha value to set.</param>
        public void SetOnScreenIndicatorAlpha(float alpha)
        {
            SetIndicatorAlpha(onScreenIndicator, alpha);
        }

        /// <summary>
        /// Configures the transform properties of the on-screen indicator.
        /// </summary>
        /// <param name="indicatorSize">Optional size of the indicator.</param>
        /// <param name="indicatorOffset">Optional position offset of the indicator.</param>
        /// <param name="indicatorRotation">Optional rotation of the indicator.</param>
        /// <param name="indicatorScale">Optional scale of the indicator.</param>
        public void SetOnScreenTransform(Vector2Int? indicatorSize = null, Vector3? indicatorOffset = null, float? indicatorRotation = null, float? indicatorScale = null)
        {
            SetIndicatorTransform(onScreenIndicator, indicatorSize, indicatorOffset, indicatorRotation, indicatorScale);
        }

        /// <summary>
        /// Activates the off-screen indicator and deactivates the on-screen indicator.
        /// </summary>
        public void SetActiveOffScreenIndicator()
        {
            if (offScreenIndicator != null && offScreenIndicator.gameObject.activeInHierarchy)
                return;

            SetActiveIndicator(offScreenIndicator, true);
            SetActiveIndicator(onScreenIndicator, false);

            OnActivateOffScreenIndicator?.Invoke();
        }

        /// <summary>
        /// Sets the sprite and optional tint color for the off-screen indicator.
        /// </summary>
        /// <param name="offScreenSprite">The sprite to set for the off-screen indicator.</param>
        /// <param name="tintColor">The optional tint color to apply to the sprite.</param>
        public void SetOffScreenIndicatorSprite(Sprite offScreenSprite, Color? tintColor = null)
        {
            SetIndicatorSprite(offScreenIndicator, offScreenSprite, tintColor);
        }

        /// <summary>
        /// Sets the alpha transparency of the off-screen indicator.
        /// </summary>
        /// <param name="alpha">The alpha value to set.</param>
        public void SetOffScreenIndicatorAlpha(float alpha)
        {
            SetIndicatorAlpha(offScreenIndicator, alpha);
        }

        /// <summary>
        /// Configures the transform properties of the off-screen indicator.
        /// </summary>
        /// <param name="indicatorSize">Optional size of the indicator.</param>
        /// <param name="indicatorOffset">Optional position offset of the indicator.</param>
        /// <param name="indicatorRotation">Optional rotation of the indicator.</param>
        /// <param name="indicatorScale">Optional scale of the indicator.</param>
        public void SetOffScreenTransform(Vector2Int? indicatorSize = null, Vector3? indicatorOffset = null, float? indicatorRotation = null, float? indicatorScale = null)
        {
            SetIndicatorTransform(offScreenIndicator, indicatorSize, indicatorOffset, indicatorRotation, indicatorScale);
        }

        /// <summary>
        /// Activates or deactivates a specified indicator.
        /// </summary>
        /// <param name="indicator">The indicator to activate or deactivate.</param>
        /// <param name="isActive">True to activate the indicator, false to deactivate.</param>
        protected void SetActiveIndicator(Image indicator, bool isActive)
        {
            if (indicator == null)
                return;

            indicator.gameObject.SetActive(isActive);
        }

        /// <summary>
        /// Sets the sprite and optional tint color for a specified indicator.
        /// </summary>
        /// <param name="indicator">The indicator to modify.</param>
        /// <param name="sprite">The sprite to set.</param>
        /// <param name="tintColor">The optional tint color to apply to the sprite.</param>
        protected void SetIndicatorSprite(Image indicator, Sprite sprite, Color? tintColor)
        {
            if (indicator == null)
                return;

            indicator.sprite = sprite;

            if (tintColor.HasValue)
                indicator.color = new Color(tintColor.Value.r, tintColor.Value.g, tintColor.Value.b, tintColor.Value.a);
        }

        /// <summary>
        /// Sets the alpha transparency for a specified indicator.
        /// </summary>
        /// <param name="indicator">The indicator to modify.</param>
        /// <param name="alpha">The alpha value to set.</param>
        protected void SetIndicatorAlpha(Image indicator, float alpha)
        {
            if (indicator == null)
                return;

            Color newColor = new Color(indicator.color.r, indicator.color.g, indicator.color.b, alpha);
            indicator.color = newColor;
        }

        /// <summary>
        /// Configures the transform properties for a specified indicator.
        /// </summary>
        /// <param name="indicator">The indicator to modify.</param>
        /// <param name="indicatorSize">Optional size of the indicator.</param>
        /// <param name="indicatorOffset">Optional position offset of the indicator.</param>
        /// <param name="indicatorRotation">Optional rotation of the indicator.</param>
        /// <param name="indicatorScale">Optional scale of the indicator.</param>
        protected void SetIndicatorTransform(Image indicator, Vector2Int? indicatorSize = null, Vector3? indicatorOffset = null, float? indicatorRotation = null, float? indicatorScale = null)
        {
            if (indicator == null)
                return;

            if (indicatorSize.HasValue)
                indicator.GetComponent<RectTransform>().sizeDelta = new Vector2(indicatorSize.Value.x, indicatorSize.Value.y);

            if (indicatorOffset.HasValue)
                indicator.GetComponent<RectTransform>().localPosition = new Vector3(indicatorOffset.Value.x, indicatorOffset.Value.y, indicatorOffset.Value.z);

            if (indicatorRotation.HasValue)
                indicator.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0f, 0f, indicatorRotation.Value);

            if (indicatorScale.HasValue)
                indicator.GetComponent<RectTransform>().localScale = new Vector3(indicatorScale.Value, indicatorScale.Value, indicatorScale.Value);
        }

        public static string GetNameOfScreenIndicatorsContainer => nameof(screenIndicatorsContainer);
        public static string GetNameOfOnScreenIndicator => nameof(onScreenIndicator);
        public static string GetNameOfOffScreenIndicator => nameof(offScreenIndicator);
        public static string GetNameOfBoundBoxSize => nameof(boundBoxSize);
    }
}