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
            PlayerPrefs.SetInt("_cameraSettings_overrideCameraInitialOffset", OverrideCameraInitialOffset ? 1 : 0);
            PlayerPrefs.SetFloat("_cameraSettings_cinemachineVirtualCameraInitialOffset_X", CinemachineVirtualCameraInitialOffset.x);
            PlayerPrefs.SetFloat("_cameraSettings_cinemachineVirtualCameraInitialOffset_Y", CinemachineVirtualCameraInitialOffset.y);
            PlayerPrefs.SetFloat("_cameraSettings_cinemachineVirtualCameraInitialOffset_Z", CinemachineVirtualCameraInitialOffset.z);

            PlayerPrefs.SetFloat("_cameraSettings_moveCameraSpeed", MoveCameraSpeed);
            PlayerPrefs.SetInt("_cameraSettings_useEdgeScrolling", UseEdgeScrolling ? 1 : 0);
            PlayerPrefs.SetFloat("_cameraSettings_edgeScrollSizeX", EdgeScrollSizeX);
            PlayerPrefs.SetFloat("_cameraSettings_edgeScrollSizeY", EdgeScrollSizeY);
            PlayerPrefs.SetInt("_cameraSettings_useDragPan", UseDragPan ? 1 : 0);
            PlayerPrefs.SetFloat("_cameraSettings_dragPanSpeedMultiplier", DragPanSpeedMultiplier);

            PlayerPrefs.SetFloat("_cameraSettings_rotateCameraSpeed", RotateCameraSpeed);
            PlayerPrefs.SetInt("_cameraSettings_useDragRotation", UseDragRotation ? 1 : 0);
            PlayerPrefs.SetFloat("_cameraSettings_dragRotationSpeedMultiplier", DragRotationSpeedMultiplier);

            PlayerPrefs.SetFloat("_cameraSettings_zoomCameraSpeed", ZoomCameraSpeed);
            PlayerPrefs.SetFloat("_cameraSettings_zoomCameraAmount", ZoomCameraAmount);
            PlayerPrefs.SetInt("_cameraSettings_useZoom", UseZoom ? 1 : 0);
            PlayerPrefs.SetFloat("_cameraSettings_followOffsetMin", FollowOffsetMin);
            PlayerPrefs.SetFloat("_cameraSettings_followOffsetMax", FollowOffsetMax);
        }

        /// <summary>
        /// Load the camera settings from playerPrefs
        /// </summary>
        public void LoadSettingsFromPlayerPrefs()
        {
            OverrideCameraInitialOffset = PlayerPrefs.GetInt("_cameraSettings_overrideCameraInitialOffset") == 1;
            CinemachineVirtualCameraInitialOffset.x = PlayerPrefs.GetFloat("_cameraSettings_cinemachineVirtualCameraInitialOffset_X");
            CinemachineVirtualCameraInitialOffset.y = PlayerPrefs.GetFloat("_cameraSettings_cinemachineVirtualCameraInitialOffset_Y");
            CinemachineVirtualCameraInitialOffset.z = PlayerPrefs.GetFloat("_cameraSettings_cinemachineVirtualCameraInitialOffset_Z");

            MoveCameraSpeed = PlayerPrefs.GetFloat("_cameraSettings_moveCameraSpeed");
            UseEdgeScrolling = PlayerPrefs.GetInt("_cameraSettings_useEdgeScrolling") == 1;
            EdgeScrollSizeX = PlayerPrefs.GetFloat("_cameraSettings_edgeScrollSizeX");
            EdgeScrollSizeY = PlayerPrefs.GetFloat("_cameraSettings_edgeScrollSizeY");
            UseDragPan = PlayerPrefs.GetInt("_cameraSettings_useDragPan") == 1;
            DragPanSpeedMultiplier = PlayerPrefs.GetFloat("_cameraSettings_dragPanSpeedMultiplier");

            RotateCameraSpeed = PlayerPrefs.GetFloat("_cameraSettings_rotateCameraSpeed");
            UseDragRotation = PlayerPrefs.GetInt("_cameraSettings_useDragRotation") == 1;
            DragRotationSpeedMultiplier = PlayerPrefs.GetFloat("_cameraSettings_dragRotationSpeedMultiplier");

            ZoomCameraSpeed = PlayerPrefs.GetFloat("_cameraSettings_zoomCameraSpeed");
            ZoomCameraAmount = PlayerPrefs.GetFloat("_cameraSettings_zoomCameraAmount");
            UseZoom = PlayerPrefs.GetInt("_cameraSettings_useZoom") == 1;
            FollowOffsetMin = PlayerPrefs.GetFloat("_cameraSettings_followOffsetMin");
            FollowOffsetMax = PlayerPrefs.GetFloat("_cameraSettings_followOffsetMax");
        }
    }
}