using System;
using UnityEngine;
using UnityEngine.UI;

namespace IndicatorSystem
{
	public abstract class Indicator : MonoBehaviour
	{
        protected UIIndicator instantiatedUIIndicator;

        [Header("Display parameters")]
        [SerializeField] protected bool hideOnScreenIndicator;
        [SerializeField] protected bool hideOffScreenIndicator;

        [Header("Distance parameters")]
        [SerializeField] protected Transform originObject;
        [SerializeField] protected LengthUnitType lengthUnitType;
        [SerializeField] protected int distanceDecimalPlaces;
        [SerializeField] protected float minRangeDisplay = 1f;
        [SerializeField] protected float maxRangeDisplay = 100f;

        [SerializeField] protected IndicatorFader onScreenFade;
        [SerializeField] protected IndicatorFader offScreenFade;

        [SerializeField] protected IndicatorScaler onScreenScale;
        [SerializeField] protected IndicatorScaler offScreenScale;

        [SerializeField] protected bool useBoundBoxForOffScreenCheck;

        [Header("Canvas")]
        [SerializeField] protected Canvas renderCanvas;
        protected RectTransform renderCanvasRect;
        protected Vector2 canvasReferenceResolution;

        [Header("Camera")]
        [SerializeField] protected Camera renderCamera;

        protected float curDistance;
        protected bool isOnScreen;

        protected OffScreenLocations curOffScreenLocation;

        /// <summary>
        /// Gets the UI indicator associated with this indicator.
        /// </summary>
        public UIIndicator InstantiatedUIIndicator => instantiatedUIIndicator;

        /// <summary>
        /// Gets or sets the origin object used for distance calculations.
        /// </summary>
        public Transform OriginObject
        {
            get { return originObject; }
            set { originObject = value; }
        }

        /// <summary>
        /// Gets or sets the canvas used to render the indicator.
        /// </summary>
        public Canvas RenderCanvas
        {
            get { return renderCanvas; }
            set
            {
                RenderCanvasRect = value.GetComponent<RectTransform>();
                canvasReferenceResolution = value.GetComponent<CanvasScaler>().referenceResolution;
                renderCanvas = value;
            }
        }

        /// <summary>
        /// Gets the RectTransform of the render canvas.
        /// </summary>
        public RectTransform RenderCanvasRect
        {
            get { return renderCanvasRect; }
            private set { renderCanvasRect = value; }
        }

        /// <summary>
        /// Gets or sets the camera used for rendering the indicator/check for on/off-screen.
        /// </summary>
        public Camera RenderCamera
        {
            get { return renderCamera; }
            set { renderCamera = value; }
        }

        /// <summary>
        /// Gets or sets whether the on-screen indicator should be hidden.
        /// </summary>
        public bool HideOnScreenIndicator
        {
            get { return hideOnScreenIndicator; }
            set { hideOnScreenIndicator = value; }
        }

        /// <summary>
        /// Gets or sets whether the off-screen indicator should be hidden.
        /// </summary>
        public bool HideOffScreenIndicator
        {
            get { return hideOffScreenIndicator; }
            set { hideOffScreenIndicator = value; }
        }

        private void Awake()
        {
            if (RenderCanvas != null)
            {
                RenderCanvasRect = RenderCanvas.GetComponent<RectTransform>();
                canvasReferenceResolution = RenderCanvas.GetComponent<CanvasScaler>().referenceResolution;

                InstantiateWaypoint();
            }
        }

        private void OnEnable()
        {
            if (InstantiatedUIIndicator && !InstantiatedUIIndicator.gameObject.activeInHierarchy)
                InstantiatedUIIndicator.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            if (InstantiatedUIIndicator && InstantiatedUIIndicator.gameObject.activeInHierarchy)
                InstantiatedUIIndicator.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            if (InstantiatedUIIndicator)
                Destroy(InstantiatedUIIndicator.gameObject);
        }

        protected virtual void LateUpdate()
        {
            if (RenderCamera == null || RenderCanvas == null)
                return;

            curDistance = CalculateDistance(distanceDecimalPlaces);

            if (curDistance < minRangeDisplay || curDistance > maxRangeDisplay)
            {
                InstantiatedUIIndicator.DeactivateIndicators();
                return;
            }

            switch (RenderCanvas.renderMode)
            {
                case RenderMode.ScreenSpaceOverlay:
                    ScreenSpaceOverlayUpdate();
                    break;
                case RenderMode.ScreenSpaceCamera:
                    ScreenSpaceCameraUpdate();
                    break;
                case RenderMode.WorldSpace:
                    WorldSpaceUpdate();
                    break;
                default:
                    break;
            }

            if (onScreenFade.FadeWithRange && isOnScreen)
            {
                float alpha = onScreenFade.CalculateAlpha(curDistance);
                InstantiatedUIIndicator.SetOnScreenIndicatorAlpha(alpha);
            }
            else if (offScreenFade.FadeWithRange && !isOnScreen)
            {
                float alpha = offScreenFade.CalculateAlpha(curDistance);
                InstantiatedUIIndicator.SetOffScreenIndicatorAlpha(alpha);
            }

            if (onScreenScale.ScaleWithRange && isOnScreen)
            {
                float scale = onScreenScale.CalculateScale(curDistance);
                InstantiatedUIIndicator.SetOnScreenTransform(indicatorScale: scale);
            }
            else if (offScreenScale.ScaleWithRange && !isOnScreen)
            {
                float scale = offScreenScale.CalculateScale(curDistance);
                InstantiatedUIIndicator.SetOffScreenTransform(indicatorScale: scale);
            }
        }

        protected abstract void InstantiateWaypoint();
        protected abstract void ScreenSpaceOverlayUpdate();
        protected abstract void ScreenSpaceCameraUpdate();
        protected abstract void WorldSpaceUpdate();

        /// <summary>
        /// Sets up the indicator with the specified canvas, camera, and origin object.
        /// </summary>
        /// <param name="canvas">The canvas used for rendering the indicator.</param>
        /// <param name="camera">The camera used for rendering the indicator.</param>
        /// <param name="newOriginObject">The origin object for distance calculations.</param>
        public void SetupIndicator(Canvas canvas, Camera camera, Transform newOriginObject)
        {
            RenderCanvas = canvas;
            SwitchCamera(camera, newOriginObject);

            InstantiateWaypoint();
        }

        /// <summary>
        /// Switches the camera used for rendering the indicator.
        /// </summary>
        /// <param name="newCamera">The new camera to use.</param>
        /// <param name="newOriginObject">Optional. The new origin object for distance calculations.</param>
        public void SwitchCamera(Camera newCamera, Transform newOriginObject = null)
        {
            if (newCamera == null)
                throw new ArgumentNullException(nameof(newCamera), "Camera cannot be null");

            if (newOriginObject != null)
                OriginObject = newOriginObject;

            RenderCamera = newCamera;
        }

        /// <summary>
        /// Calculates the distance from the indicator to the origin object, rounded to the specified number of decimal places.
        /// </summary>
        /// <param name="decimalPlaces">The number of decimal places to round the distance to.</param>
        /// <returns>The calculated distance.</returns>
        protected float CalculateDistance(int decimalPlaces = 0)
        {
            float distance = Vector3.Distance(transform.position, OriginObject.position);
            float convertedDistance = lengthUnitType.ConvertFromMeters(distance);

            return (float)Math.Round(convertedDistance, decimalPlaces);
        }

        /// <summary>
        /// Determines if the indicator is on-screen in screen space overlay mode.
        /// </summary>
        /// <param name="indicatorPosition">The position of the indicator.</param>
        /// <returns>True if the indicator is on-screen, false otherwise.</returns>
        protected bool IsOnScreenScreenSpaceOverlay(Vector3 indicatorPosition)
        {
            Vector2 boundBox = useBoundBoxForOffScreenCheck ? InstantiatedUIIndicator.BoundBoxSize : new Vector2(0f, 0f);

            return (indicatorPosition.z > 0 &&
            indicatorPosition.x > (0 + (boundBox.x / 2)) &&
            indicatorPosition.x < (Screen.width - (boundBox.x / 2)) &&
            indicatorPosition.y > (0 + (boundBox.y / 2)) &&
            indicatorPosition.y < (Screen.height - (boundBox.y / 2)));
        }

        /// <summary>
        /// Determines if the indicator is on-screen in screen space camera mode.
        /// </summary>
        /// <param name="indicatorPosition">The position of the indicator</param>
        /// <returns>True if the indicator is on-screen, false otherwise</returns>
        protected bool IsOnScreenScreenSpaceCamera(Vector3 indicatorPosition)
        {
            Vector2 boundBox = useBoundBoxForOffScreenCheck ? InstantiatedUIIndicator.BoundBoxSize : new Vector2(0f, 0f);

            return (indicatorPosition.z > 0 &&
            indicatorPosition.x > (0 + (boundBox.x / 2)) &&
            indicatorPosition.x < (RenderCanvas.worldCamera.pixelWidth - (boundBox.x / 2)) &&
            indicatorPosition.y > (0 + (boundBox.y / 2)) &&
            indicatorPosition.y < (RenderCanvas.worldCamera.pixelHeight - (boundBox.y / 2)));
        }

        /// <summary>
        /// Determines if the indicator is on-screen in world space mode.
        /// </summary>
        /// <param name="indicatorPosition">The position of the indicator.</param>
        /// <param name="proportionalPosition">The proportional position of the indicator on the canvas.</param>
        /// <returns>True if the indicator is on-screen, false otherwise</returns>
        protected bool IsOnScreenWorldSpace(Vector3 indicatorPosition, Vector3 proportionalPosition)
        {
            Vector2 boundBox = useBoundBoxForOffScreenCheck ? InstantiatedUIIndicator.BoundBoxSize : new Vector2(0f, 0f);

            return (indicatorPosition.z > 0 &&
            proportionalPosition.x > (0 + (boundBox.x / 2)) &&
            proportionalPosition.x < (RenderCanvasRect.sizeDelta.x - (boundBox.x / 2)) &&
            proportionalPosition.y > (0 + (boundBox.y / 2)) &&
            proportionalPosition.y < (RenderCanvasRect.sizeDelta.y - (boundBox.y / 2)));
        }

        /// <summary>
        /// Updates the off-screen flags for the indicator in screen space overlay mode.
        /// </summary>
        /// <param name="indicatorPosition">The position of the indicator.</param>
        protected void UpdateOffScreenFlagsScreenSpaceOverlay(Vector3 indicatorPosition)
        {
            curOffScreenLocation = OffScreenLocations.None;

            if (indicatorPosition.z <= 0)
                return;

            Vector2 boundBox = useBoundBoxForOffScreenCheck ? InstantiatedUIIndicator.BoundBoxSize : new Vector2(0f, 0f);

            if (indicatorPosition.x <= (0 + (boundBox.x / 2)))
                curOffScreenLocation |= OffScreenLocations.Left;
            else if (indicatorPosition.x >= (Screen.width - (boundBox.x / 2)))
                curOffScreenLocation |= OffScreenLocations.Right;

            if (indicatorPosition.y <= (boundBox.y / 2))
                curOffScreenLocation |= OffScreenLocations.Bottom;
            else if (indicatorPosition.y >= (Screen.height - (boundBox.y / 2)))
                curOffScreenLocation |= OffScreenLocations.Top;
        }

        /// <summary>
        /// Updates the off-screen flags for the indicator in screen space camera mode.
        /// </summary>
        /// <param name="indicatorPosition">The position of the indicator.</param>
        protected void UpdateOffScreenFlagsScreenSpaceCamera(Vector3 indicatorPosition)
        {
            curOffScreenLocation = OffScreenLocations.None;

            if (indicatorPosition.z <= 0)
                return;

            Vector2 boundBox = useBoundBoxForOffScreenCheck ? InstantiatedUIIndicator.BoundBoxSize : new Vector2(0f, 0f);

            if (indicatorPosition.x <= (0 + (boundBox.x / 2)))
                curOffScreenLocation |= OffScreenLocations.Left;
            else if (indicatorPosition.x >= (RenderCanvas.worldCamera.pixelWidth - (boundBox.x / 2)))
                curOffScreenLocation |= OffScreenLocations.Right;

            if (indicatorPosition.y <= (boundBox.y / 2))
                curOffScreenLocation |= OffScreenLocations.Bottom;
            else if (indicatorPosition.y >= (RenderCanvas.worldCamera.pixelHeight - (boundBox.y / 2)))
                curOffScreenLocation |= OffScreenLocations.Top;
        }

        /// <summary>
        /// Updates the off-screen flags for the indicator in world space mode.
        /// </summary>
        /// <param name="indicatorPosition">The position of the indicator.</param>
        /// <param name="proportionalPosition">The proportional position of the indicator on the canvas.</param>
        protected void UpdateOffScreenFlagsScreenWorldSpace(Vector3 indicatorPosition, Vector3 proportionalPosition)
        {
            curOffScreenLocation = OffScreenLocations.None;

            if (indicatorPosition.z <= 0)
                return;

            Vector2 boundBox = useBoundBoxForOffScreenCheck ? InstantiatedUIIndicator.BoundBoxSize : new Vector2(0f, 0f);

            if (proportionalPosition.x <= (0 + (boundBox.x / 2)))
                curOffScreenLocation |= OffScreenLocations.Left;
            else if (proportionalPosition.x >= (RenderCanvasRect.sizeDelta.x - (boundBox.x / 2)))
                curOffScreenLocation |= OffScreenLocations.Right;

            if (proportionalPosition.y <= (boundBox.y / 2))
                curOffScreenLocation |= OffScreenLocations.Bottom;
            else if (proportionalPosition.y >= (RenderCanvasRect.sizeDelta.y - (boundBox.y / 2)))
                curOffScreenLocation |= OffScreenLocations.Top;
        }

        /// <summary>
        /// Calculates the angle and slope of the indicator relative to its position.
        /// </summary>
        /// <param name="indicatorPosition">The position of the indicator.</param>
        /// <param name="angle">The calculated angle.</param>
        /// <param name="slope">The calculated slope.</param>
        protected void CalculateAngleAndSlope(Vector3 indicatorPosition, out float angle, out float slope)
        {
            angle = Mathf.Atan2(indicatorPosition.y, indicatorPosition.x);
            slope = Mathf.Tan(angle);
        }

        public static string GetNameOfHideOnScreen => nameof(hideOnScreenIndicator);
        public static string GetNameOfHideOffScreen => nameof(hideOffScreenIndicator);

        public static string GetNameOfOriginObject => nameof(originObject);
        public static string GetNameOfRenderCanvas => nameof(renderCanvas);
        public static string GetNameOfRenderCamera => nameof(renderCamera);
        public static string GetNameOfUseBoundBoxForOffScreenCheck => nameof(useBoundBoxForOffScreenCheck);

        public static string GetNameOfLengthUnitType => nameof(lengthUnitType);
        public static string GetNameOfDecimalPlaces => nameof(distanceDecimalPlaces);
        public static string GetNameOfMinRange => nameof(minRangeDisplay);
        public static string GetNameOfMaxRange => nameof(maxRangeDisplay);

        public static string GetNameOfOnScreenFade => nameof(onScreenFade);
        public static string GetNameOfOffScreenFade => nameof(offScreenFade);

        public static string GetNameOfOnScreenScale => nameof(onScreenScale);
        public static string GetNameOfOffScreenScale => nameof(offScreenScale);
    }
}