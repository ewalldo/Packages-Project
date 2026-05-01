using UnityEngine;

namespace CameraSystem
{
    [CreateAssetMenu(fileName = "CameraSettings", menuName = "Scriptable Objects/Camera System/Camera Settings")]
    public class CameraSettings : ScriptableObject
	{
        /// <summary>
        /// Should override the initial offset of the cinemachineCamera at the awake?
        /// </summary>
        public bool OverrideCameraInitialOffset;
        /// <summary>
        /// The initial offset for the cinemachine virtual camera
        /// </summary>
        public Vector3 CinemachineVirtualCameraInitialOffset;

        /// <summary>
        /// The camera movement speed
        /// </summary>
        public float MoveCameraSpeed;
        /// <summary>
        /// Should edge scrolling be active or not
        /// </summary>
        public bool UseEdgeScrolling;
        /// <summary>
        /// Should edge scrolling be active when hovering UI elements or not, if false edge scrolling will only be active when not hovering any UI element
        /// </summary>
        public bool UseEdgeScrollingWhenHoveringUI;
        /// <summary>
        /// Percentage of the screen width where the edge scroll will be active (0.1 means that will be active on the 10% of the screen)
        /// </summary>
        public float EdgeScrollSizeX;
        /// <summary>
        /// Percentage of the screen height where the edge scroll will be active (0.1 means that will be active on the 10% of the screen)
        /// </summary>
        public float EdgeScrollSizeY;
        /// <summary>
        /// Should drag pan be active or not, if active camera can be moved with right-mouse click
        /// </summary>
        public bool UseDragPan;
        /// <summary>
        /// The multiplier speed when using drag pan
        /// </summary>
        public float DragPanSpeedMultiplier;

        /// <summary>
        /// The camera rotation speed
        /// </summary>
        public float RotateCameraSpeed;
        /// <summary>
        /// Should drag rotation be active or not, if active camera can be rotated with middle-mouse click
        /// </summary>
        public bool UseDragRotation;
        /// <summary>
        /// The multiplier speed when using drag rotation
        /// </summary>
        public float DragRotationSpeedMultiplier;

        /// <summary>
        /// Should camera zoom be active or not, if active camera can be zoomed with middle-mouse scroll
        /// </summary>
        public bool UseZoom;
        /// <summary>
        /// The camera zoom speed
        /// </summary>
        public float ZoomCameraSpeed;
        /// <summary>
        /// The camera step size when zooming
        /// </summary>
        public float ZoomCameraAmount;
        /// <summary>
        /// The minimum amount of offset the camera should keep when zooming
        /// </summary>
        public float FollowOffsetMin;
        /// <summary>
        /// The maximum amount of offset the camera should keep when zooming
        /// </summary>
        public float FollowOffsetMax;

        /// <summary>
        /// Reset all the settings to their default values
        /// </summary>
        public void ResetToDefault()
        {
            OverrideCameraInitialOffset = false;
            CinemachineVirtualCameraInitialOffset = new Vector3(0, 10, -10);
            MoveCameraSpeed = 25f;
            UseEdgeScrolling = false;
            UseEdgeScrollingWhenHoveringUI = false;
            EdgeScrollSizeX = 0.1f;
            EdgeScrollSizeY = 0.1f;
            UseDragPan = false;
            DragPanSpeedMultiplier = 1f;
            RotateCameraSpeed = 100f;
            UseDragRotation = false;
            DragRotationSpeedMultiplier = 0.75f;
            UseZoom = true;
            ZoomCameraSpeed = 10f;
            ZoomCameraAmount = 5f;
            FollowOffsetMin = 5f;
            FollowOffsetMax = 50f;
        }

        /// <summary>
        /// Convert this CameraSettings to a json string
        /// </summary>
        /// <returns>The string containing the settings in a json format</returns>
        public string ConvertSettingsToJSONString()
        {
            string json = JsonUtility.ToJson(this, true);
            return json;
        }

        /// <summary>
        /// Load camera settings based on a json string
        /// </summary>
        /// <param name="json">The string containing the camera settings</param>
        public void LoadSettingsFromJson(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }

        /// <summary>
        /// Save this camera settings to playerPrefs
        /// </summary>
        public void SaveSettingsToPlayerPrefs()
        {
            PlayerPrefs.SetInt(OverrideCameraInitialOffsetKey, OverrideCameraInitialOffset ? 1 : 0);
            PlayerPrefs.SetFloat(CinemachineVirtualCameraInitialOffsetXKey, CinemachineVirtualCameraInitialOffset.x);
            PlayerPrefs.SetFloat(CinemachineVirtualCameraInitialOffsetYKey, CinemachineVirtualCameraInitialOffset.y);
            PlayerPrefs.SetFloat(CinemachineVirtualCameraInitialOffsetZKey, CinemachineVirtualCameraInitialOffset.z);

            PlayerPrefs.SetFloat(MoveCameraSpeedKey, MoveCameraSpeed);
            PlayerPrefs.SetInt(UseEdgeScrollingKey, UseEdgeScrolling ? 1 : 0);
            PlayerPrefs.SetInt(UseEdgeScrollingWhenHoveringUIKey, UseEdgeScrollingWhenHoveringUI ? 1 : 0);
            PlayerPrefs.SetFloat(EdgeScrollSizeXKey, EdgeScrollSizeX);
            PlayerPrefs.SetFloat(EdgeScrollSizeYKey, EdgeScrollSizeY);
            PlayerPrefs.SetInt(UseDragPanKey, UseDragPan ? 1 : 0);
            PlayerPrefs.SetFloat(DragPanSpeedMultiplierKey, DragPanSpeedMultiplier);

            PlayerPrefs.SetFloat(RotateCameraSpeedKey, RotateCameraSpeed);
            PlayerPrefs.SetInt(UseDragRotationKey, UseDragRotation ? 1 : 0);
            PlayerPrefs.SetFloat(DragRotationSpeedMultiplierKey, DragRotationSpeedMultiplier);

            PlayerPrefs.SetFloat(ZoomCameraSpeedKey, ZoomCameraSpeed);
            PlayerPrefs.SetFloat(ZoomCameraAmountKey, ZoomCameraAmount);
            PlayerPrefs.SetInt(UseZoomKey, UseZoom ? 1 : 0);
            PlayerPrefs.SetFloat(FollowOffsetMinKey, FollowOffsetMin);
            PlayerPrefs.SetFloat(FollowOffsetMaxKey, FollowOffsetMax);
        }

        /// <summary>
        /// Load the camera settings from playerPrefs
        /// </summary>
        public void LoadSettingsFromPlayerPrefs()
        {
            OverrideCameraInitialOffset = PlayerPrefs.GetInt(OverrideCameraInitialOffsetKey) == 1;
            CinemachineVirtualCameraInitialOffset.x = PlayerPrefs.GetFloat(CinemachineVirtualCameraInitialOffsetXKey);
            CinemachineVirtualCameraInitialOffset.y = PlayerPrefs.GetFloat(CinemachineVirtualCameraInitialOffsetYKey);
            CinemachineVirtualCameraInitialOffset.z = PlayerPrefs.GetFloat(CinemachineVirtualCameraInitialOffsetZKey);

            MoveCameraSpeed = PlayerPrefs.GetFloat(MoveCameraSpeedKey);
            UseEdgeScrolling = PlayerPrefs.GetInt(UseEdgeScrollingKey) == 1;
            UseEdgeScrollingWhenHoveringUI = PlayerPrefs.GetInt(UseEdgeScrollingWhenHoveringUIKey) == 1;
            EdgeScrollSizeX = PlayerPrefs.GetFloat(EdgeScrollSizeXKey);
            EdgeScrollSizeY = PlayerPrefs.GetFloat(EdgeScrollSizeYKey);
            UseDragPan = PlayerPrefs.GetInt(UseDragPanKey) == 1;
            DragPanSpeedMultiplier = PlayerPrefs.GetFloat(DragPanSpeedMultiplierKey);

            RotateCameraSpeed = PlayerPrefs.GetFloat(RotateCameraSpeedKey);
            UseDragRotation = PlayerPrefs.GetInt(UseDragRotationKey) == 1;
            DragRotationSpeedMultiplier = PlayerPrefs.GetFloat(DragRotationSpeedMultiplierKey);

            ZoomCameraSpeed = PlayerPrefs.GetFloat(ZoomCameraSpeedKey);
            ZoomCameraAmount = PlayerPrefs.GetFloat(ZoomCameraAmountKey);
            UseZoom = PlayerPrefs.GetInt(UseZoomKey) == 1;
            FollowOffsetMin = PlayerPrefs.GetFloat(FollowOffsetMinKey);
            FollowOffsetMax = PlayerPrefs.GetFloat(FollowOffsetMaxKey);
        }

        private const string OverrideCameraInitialOffsetKey = "_cameraSettings_overrideCameraInitialOffset";
        private const string CinemachineVirtualCameraInitialOffsetXKey = "_cameraSettings_cinemachineVirtualCameraInitialOffset_X";
        private const string CinemachineVirtualCameraInitialOffsetYKey = "_cameraSettings_cinemachineVirtualCameraInitialOffset_Y";
        private const string CinemachineVirtualCameraInitialOffsetZKey = "_cameraSettings_cinemachineVirtualCameraInitialOffset_Z";
        private const string MoveCameraSpeedKey = "_cameraSettings_moveCameraSpeed";
        private const string UseEdgeScrollingKey = "_cameraSettings_useEdgeScrolling";
        private const string UseEdgeScrollingWhenHoveringUIKey = "_cameraSettings_useEdgeScrollingWhenHoveringUI";
        private const string EdgeScrollSizeXKey = "_cameraSettings_edgeScrollSizeX";
        private const string EdgeScrollSizeYKey = "_cameraSettings_edgeScrollSizeY";
        private const string UseDragPanKey = "_cameraSettings_useDragPan";
        private const string DragPanSpeedMultiplierKey = "_cameraSettings_dragPanSpeedMultiplier";
        private const string RotateCameraSpeedKey = "_cameraSettings_rotateCameraSpeed";
        private const string UseDragRotationKey = "_cameraSettings_useDragRotation";
        private const string DragRotationSpeedMultiplierKey = "_cameraSettings_dragRotationSpeedMultiplier";
        private const string ZoomCameraSpeedKey = "_cameraSettings_zoomCameraSpeed";
        private const string ZoomCameraAmountKey = "_cameraSettings_zoomCameraAmount";
        private const string UseZoomKey = "_cameraSettings_useZoom";
        private const string FollowOffsetMinKey = "_cameraSettings_followOffsetMin";
        private const string FollowOffsetMaxKey = "_cameraSettings_followOffsetMax";
    }
}