using UnityEngine;

namespace IndicatorSystem
{
	public class RadialIndicator : Indicator
	{
        [Header("Setup parameters")]
        [SerializeField] private UIRadialIndicator uiIndicatorPrefab;

        private UIRadialIndicator instantiatedUIRadialIndicator;

        /// <summary>
        /// Instantiates the waypoint indicator and set its position according to the specified diameter length.
        /// </summary>
        protected override void InstantiateWaypoint()
        {
            instantiatedUIIndicator = Instantiate(uiIndicatorPrefab, RenderCanvas.transform);

            instantiatedUIRadialIndicator = InstantiatedUIIndicator as UIRadialIndicator;
            InstantiatedUIIndicator.SetOnScreenTransform(indicatorOffset: new Vector3(instantiatedUIRadialIndicator.DiameterLength / 2, 0f, 0f));
            InstantiatedUIIndicator.SetOffScreenTransform(indicatorOffset: new Vector3(instantiatedUIRadialIndicator.DiameterLength / 2, 0f, 0f));
        }

        /// <summary>
        /// Updates the indicator's position and visibility in Screen Space Overlay mode.
        /// </summary>
        protected override void ScreenSpaceOverlayUpdate()
        {
            Vector3 radialPosition = RenderCamera.WorldToScreenPoint(transform.position);
            isOnScreen = IsOnScreenScreenSpaceOverlay(radialPosition);

            if ((isOnScreen && HideOnScreenIndicator) || (!isOnScreen && HideOffScreenIndicator))
            {
                InstantiatedUIIndicator.DeactivateIndicators();
                return;
            }

            UpdateIndicatorsState(isOnScreen);

            Vector3 screenCenter = new Vector3(Screen.width, Screen.height, 0) / 2f;
            radialPosition -= screenCenter;

            if (radialPosition.z < 0)
                radialPosition *= -1;

            CalculateAngleAndSlope(radialPosition, out float angle, out _);

            InstantiatedUIIndicator.SetScreenIndicatorsRotation(Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg), false);
        }

        /// <summary>
        /// Updates the indicator's position and visibility in Screen Space Camera mode.
        /// </summary>
        protected override void ScreenSpaceCameraUpdate()
        {
            Vector3 radialPosition = RenderCamera.WorldToScreenPoint(transform.position);
            isOnScreen = IsOnScreenScreenSpaceCamera(radialPosition);

            if ((isOnScreen && HideOnScreenIndicator) || (!isOnScreen && HideOffScreenIndicator))
            {
                InstantiatedUIIndicator.DeactivateIndicators();
                return;
            }

            UpdateIndicatorsState(isOnScreen);

            Vector3 screenCenter = new Vector3(RenderCanvas.worldCamera.pixelWidth, RenderCanvas.worldCamera.pixelHeight, 0) / 2f;
            radialPosition -= screenCenter;

            if (radialPosition.z < 0)
                radialPosition *= -1;

            CalculateAngleAndSlope(radialPosition, out float angle, out _);

            InstantiatedUIIndicator.SetScreenIndicatorsRotation(Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg), true);
        }

        /// <summary>
        /// Updates the indicator's position and visibility in World Space mode.
        /// </summary>
        protected override void WorldSpaceUpdate()
        {
            Vector3 viewportPosition = RenderCamera.WorldToViewportPoint(transform.position);
            Vector3 proportionalPosition = new Vector3(viewportPosition.x * RenderCanvasRect.sizeDelta.x, viewportPosition.y * RenderCanvasRect.sizeDelta.y, 0f);
            isOnScreen = IsOnScreenWorldSpace(viewportPosition, proportionalPosition);

            if ((isOnScreen && HideOnScreenIndicator) || (!isOnScreen && HideOffScreenIndicator))
            {
                InstantiatedUIIndicator.DeactivateIndicators();
                return;
            }

            UpdateIndicatorsState(isOnScreen);

            Vector3 screenCenter = new Vector3(RenderCanvasRect.rect.width, RenderCanvasRect.rect.height, 0) / 2f;
            proportionalPosition -= screenCenter;

            if (viewportPosition.z < 0)
                proportionalPosition *= -1;

            CalculateAngleAndSlope(proportionalPosition, out float angle, out _);

            InstantiatedUIIndicator.SetScreenIndicatorsRotation(Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg), true);
        }

        /// <summary>
        /// Updates the state of the UI elements, activating or deactivating them based on the specified parameter.
        /// </summary>
        /// <param name="isOnScreen">If true, activate the on-screen indicator; otherwise, activates the off-screen one.</param>
        private void UpdateIndicatorsState(bool isOnScreen)
        {
            if (isOnScreen)
            {
                InstantiatedUIIndicator.SetActiveOnScreenIndicator();
            }
            else
            {
                InstantiatedUIIndicator.SetActiveOffScreenIndicator();
            }
        }

        public static string GetNameOfUIIndicatorPrefab => nameof(uiIndicatorPrefab);
    }
}