using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace CameraSystem
{
	public class CameraSettingsChanger : MonoBehaviour
	{
		[SerializeField] private CameraController cameraController;

		[SerializeField] private CameraSettings defaultCameraSettings;
		[SerializeField] private CameraSettings slowMovingCameraSettings;
		[SerializeField] private CameraSettings fastMovingCameraSettings;
		[SerializeField] private CameraSettings dragMoveRotateZoomCameraSettings;

		[SerializeField] private TextMeshProUGUI currentCameraInfo;

		private Vector3 defaultPosition;

        private void Start()
        {
			defaultPosition = cameraController.gameObject.transform.position;

			currentCameraInfo.text = "Current: " + defaultCameraSettings.name;
        }

        private void Update()
        {
			if (Keyboard.current.digit1Key.wasPressedThisFrame)
            {
				cameraController.SetCameraSettings(defaultCameraSettings);
				currentCameraInfo.text = "Current: " + defaultCameraSettings.name;
			}
			if (Keyboard.current.digit2Key.wasPressedThisFrame)
            {
				cameraController.SetCameraSettings(slowMovingCameraSettings);
				currentCameraInfo.text = "Current: " + slowMovingCameraSettings.name;
			}
			if (Keyboard.current.digit3Key.wasPressedThisFrame)
            {
				cameraController.SetCameraSettings(fastMovingCameraSettings);
				currentCameraInfo.text = "Current: " + fastMovingCameraSettings.name;
			}
			if (Keyboard.current.digit4Key.wasPressedThisFrame)
            {
				cameraController.SetCameraSettings(dragMoveRotateZoomCameraSettings);
				currentCameraInfo.text = "Current: " + dragMoveRotateZoomCameraSettings.name;
			}

			if (Keyboard.current.rKey.wasPressedThisFrame)
				cameraController.gameObject.transform.position = defaultPosition;
		}
    }
}