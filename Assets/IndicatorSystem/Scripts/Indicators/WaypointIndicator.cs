using UnityEngine;

namespace IndicatorSystem
{
	public class WaypointIndicator : Indicator
	{
        [Header("Setup parameters")]
        [SerializeField] private UIWaypointIndicator uiIndicatorPrefab;

        [Header("Text parameters")]
        [SerializeField] private bool showDistanceTextWhileOnScreen;
        [SerializeField] private bool showDistanceTextWhileOffScreen;
        [SerializeField] private bool showIndicatorTextWhileOnScreen;
        [SerializeField] private bool showIndicatorTextWhileOffScreen;
        [SerializeField] private string indicatorText;

        private UIWaypointIndicator instantiatedUIWaypointIndicator;

        protected override void LateUpdate()
        {
            base.LateUpdate();

            if (curDistance < minRangeDisplay || curDistance > maxRangeDisplay)
                instantiatedUIWaypointIndicator.DeactivateTexts();
            else
            {
                instantiatedUIWaypointIndicator.UpdateTextsState(isOnScreen ? showDistanceTextWhileOnScreen : showDistanceTextWhileOffScreen,
                    isOnScreen ? showIndicatorTextWhileOnScreen : showIndicatorTextWhileOffScreen);
            }

            instantiatedUIWaypointIndicator.SetDistanceText(curDistance + lengthUnitType.LengthUnitSymbol());
        }

        /// <summary>
        /// Instantiates the waypoint indicator and initializes it with the specified text.
        /// </summary>
        protected override void InstantiateWaypoint()
        {
            instantiatedUIIndicator = Instantiate(uiIndicatorPrefab, RenderCanvas.transform);

            instantiatedUIWaypointIndicator = InstantiatedUIIndicator as UIWaypointIndicator;
            instantiatedUIWaypointIndicator.SetIndicatorText(indicatorText);
        }

        /// <summary>
        /// Updates the indicator's position and visibility in Screen Space Overlay mode.
        /// </summary>
        protected override void ScreenSpaceOverlayUpdate()
        {
            Vector3 waypointPosition = RenderCamera.WorldToScreenPoint(transform.position);
            isOnScreen = IsOnScreenScreenSpaceOverlay(waypointPosition);
            UpdateOffScreenFlagsScreenSpaceOverlay(waypointPosition);

            if ((isOnScreen && HideOnScreenIndicator) || (!isOnScreen && HideOffScreenIndicator))
            {
                InstantiatedUIIndicator.DeactivateIndicators();
            }
            else if (isOnScreen)
            {
                InstantiatedUIIndicator.SetActiveOnScreenIndicator();
                InstantiatedUIIndicator.SetScreenIndicatorsPositionAndRotation(waypointPosition, Quaternion.identity, false);
                instantiatedUIWaypointIndicator.SetTextsPosition(waypointPosition, false, OffScreenLocations.None);
            }
            else
            {
                InstantiatedUIIndicator.SetActiveOffScreenIndicator();

                Vector3 screenCenter = new Vector3(Screen.width, Screen.height, 0) / 2f;
                Vector3 screenBounds = GetScreenBounds(screenCenter);

                waypointPosition -= screenCenter;

                if (waypointPosition.z < 0)
                    waypointPosition *= -1;

                CalculateAngleAndSlope(waypointPosition, out float angle, out float slope);

                waypointPosition = CalculatePositionWithinBounds(waypointPosition, screenBounds, slope);
                waypointPosition += screenCenter;

                InstantiatedUIIndicator.SetScreenIndicatorsPositionAndRotation(waypointPosition,
                    instantiatedUIWaypointIndicator.OffScreenSpriteRotates ? Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg) : Quaternion.identity,
                    false);
                instantiatedUIWaypointIndicator.SetTextsPosition(waypointPosition, false, curOffScreenLocation);
            }
        }

        /// <summary>
        /// Updates the indicator's position and visibility in Screen Space Camera mode.
        /// </summary>
        protected override void ScreenSpaceCameraUpdate()
        {
            Vector3 waypointPosition = RenderCamera.WorldToScreenPoint(transform.position);
            isOnScreen = IsOnScreenScreenSpaceCamera(waypointPosition);
            UpdateOffScreenFlagsScreenSpaceCamera(waypointPosition);

            if ((isOnScreen && HideOnScreenIndicator) || (!isOnScreen && HideOffScreenIndicator))
            {
                InstantiatedUIIndicator.DeactivateIndicators();
            }
            else if (isOnScreen)
            {
                InstantiatedUIIndicator.SetActiveOnScreenIndicator();

                Vector3 waypointPositionInScreenSpaceCamera = RenderCamera.ScreenToWorldPoint(new Vector3(waypointPosition.x, waypointPosition.y, RenderCanvas.planeDistance));
                InstantiatedUIIndicator.SetScreenIndicatorsPosition(waypointPositionInScreenSpaceCamera, false);
                InstantiatedUIIndicator.SetScreenIndicatorsRotation(Quaternion.identity, true);
                instantiatedUIWaypointIndicator.SetTextsPosition(waypointPositionInScreenSpaceCamera, false, OffScreenLocations.None);
            }
            else
            {
                InstantiatedUIIndicator.SetActiveOffScreenIndicator();

                Vector3 screenCenter = new Vector3(RenderCanvas.worldCamera.pixelWidth, RenderCanvas.worldCamera.pixelHeight, 0) / 2f;
                Vector3 screenBounds = GetScreenBounds(screenCenter);

                waypointPosition -= screenCenter;

                if (waypointPosition.z < 0)
                    waypointPosition *= -1;

                CalculateAngleAndSlope(waypointPosition, out float angle, out float slope);

                waypointPosition = CalculatePositionWithinBounds(waypointPosition, screenBounds, slope);
                waypointPosition += screenCenter;

                Vector3 waypointPositionInScreenSpaceCamera = RenderCamera.ScreenToWorldPoint(new Vector3(waypointPosition.x, waypointPosition.y, RenderCanvas.planeDistance));
                InstantiatedUIIndicator.SetScreenIndicatorsPosition(waypointPositionInScreenSpaceCamera, false);
                InstantiatedUIIndicator.SetScreenIndicatorsRotation(instantiatedUIWaypointIndicator.OffScreenSpriteRotates ? Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg) : Quaternion.identity, true);
                instantiatedUIWaypointIndicator.SetTextsPosition(waypointPositionInScreenSpaceCamera, false, curOffScreenLocation);
            }
        }

        /// <summary>
        /// Updates the indicator's position and visibility in World Space mode.
        /// </summary>
        protected override void WorldSpaceUpdate()
        {
            Vector3 uiOffset = new Vector3(RenderCanvasRect.sizeDelta.x, RenderCanvasRect.sizeDelta.y, 0f) / 2f;
            Vector3 viewportPosition = RenderCamera.WorldToViewportPoint(transform.position);
            Vector3 proportionalPosition = new Vector3(viewportPosition.x * RenderCanvasRect.sizeDelta.x, viewportPosition.y * RenderCanvasRect.sizeDelta.y, 0f);
            isOnScreen = IsOnScreenWorldSpace(viewportPosition, proportionalPosition);
            UpdateOffScreenFlagsScreenWorldSpace(viewportPosition, proportionalPosition);

            if ((isOnScreen && HideOnScreenIndicator) || (!isOnScreen && HideOffScreenIndicator))
            {
                InstantiatedUIIndicator.DeactivateIndicators();
            }
            else if (isOnScreen)
            {
                InstantiatedUIIndicator.SetActiveOnScreenIndicator();

                Vector3 waypointPositionInWorldSpace = proportionalPosition - uiOffset;
                InstantiatedUIIndicator.SetScreenIndicatorsPositionAndRotation(waypointPositionInWorldSpace, Quaternion.identity, true);
                instantiatedUIWaypointIndicator.SetTextsPosition(waypointPositionInWorldSpace, true, OffScreenLocations.None);
            }
            else
            {
                InstantiatedUIIndicator.SetActiveOffScreenIndicator();

                Vector3 screenCenter = new Vector3(RenderCanvasRect.rect.width, RenderCanvasRect.rect.height, 0) / 2f;
                Vector3 screenBounds = GetScreenBounds(screenCenter);

                proportionalPosition -= screenCenter;

                if (viewportPosition.z < 0)
                    proportionalPosition *= -1;

                CalculateAngleAndSlope(proportionalPosition, out float angle, out float slope);

                proportionalPosition = CalculatePositionWithinBounds(proportionalPosition, screenBounds, slope);
                proportionalPosition += screenCenter;

                Vector3 waypointPositionInWorldSpace = proportionalPosition - uiOffset;
                InstantiatedUIIndicator.SetScreenIndicatorsPositionAndRotation(waypointPositionInWorldSpace,
                    instantiatedUIWaypointIndicator.OffScreenSpriteRotates ? Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg) : Quaternion.identity,
                    true);
                instantiatedUIWaypointIndicator.SetTextsPosition(waypointPositionInWorldSpace, true, curOffScreenLocation);
            }
        }

        /// <summary>
        /// Calculates the screen bounds based on the screen center.
        /// </summary>
        /// <param name="screenCenter">The center of the screen.</param>
        /// <returns>The calculated screen bounds.</returns>
        private Vector3 GetScreenBounds(Vector3 screenCenter)
        {
            Vector3 screenBounds = screenCenter;
            screenBounds.x *= (.999f - (InstantiatedUIIndicator.BoundBoxSize.x * (1 / canvasReferenceResolution.x)));
            screenBounds.y *= (.999f - (InstantiatedUIIndicator.BoundBoxSize.y * (1 / canvasReferenceResolution.y)));
            return screenBounds;
        }

        /// <summary>
        /// Calculates the position of the indicator within the screen bounds.
        /// </summary>
        /// <param name="indicatorPosition">The position of the indicator.</param>
        /// <param name="screenBounds">The screen bounds.</param>
        /// <param name="slope">The slope of the indicator's position.</param>
        /// <returns>The calculated position within the bounds.</returns>
        private Vector3 CalculatePositionWithinBounds(Vector3 indicatorPosition, Vector3 screenBounds, float slope)
        {
            if (indicatorPosition.x > 0)
                indicatorPosition = new Vector3(screenBounds.x, screenBounds.x * slope, 0);
            else
                indicatorPosition = new Vector3(-screenBounds.x, -screenBounds.x * slope, 0);

            if (indicatorPosition.y > screenBounds.y)
                indicatorPosition = new Vector3(screenBounds.y / slope, screenBounds.y, 0);
            else if (indicatorPosition.y < -screenBounds.y)
                indicatorPosition = new Vector3(-screenBounds.y / slope, -screenBounds.y, 0);

            return indicatorPosition;
        }

        public static string GetNameOfUIIndicatorPrefab => nameof(uiIndicatorPrefab);
        public static string GetNameOfShowDistanceTextWhileOnScreen => nameof(showDistanceTextWhileOnScreen);
        public static string GetNameOfShowDistanceTextWhileOffScreen => nameof(showDistanceTextWhileOffScreen);
        public static string GetNameOfShowIndicatorTextWhileOnScreen => nameof(showIndicatorTextWhileOnScreen);
        public static string GetNameOfShowIndicatorTextWhileOffScreen => nameof(showIndicatorTextWhileOffScreen);
        public static string GetNameOfIndicatorText => nameof(indicatorText);
    }
}