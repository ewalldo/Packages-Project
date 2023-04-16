using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CameraSystem
{
	public class CameraController : MonoBehaviour
	{
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
        [SerializeField] private CameraSettings cameraSettings;

        private CameraSystemInputActions cameraActions;
        private InputAction keyboardMovement;
        private InputAction keyboardRotation;

        private Vector3 followOffset;

        private CinemachineTransposer cinemachineTransposer;

        private void Awake()
        {
            cinemachineTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            cameraActions = new CameraSystemInputActions();

            if (cameraSettings.OverrideCameraInitialOffset)
                cinemachineTransposer.m_FollowOffset = cameraSettings.CinemachineVirtualCameraInitialOffset;
            followOffset = cinemachineTransposer.m_FollowOffset;
        }

        private void OnEnable()
        {
            cameraActions.Camera.Enable();

            keyboardMovement = cameraActions.Camera.KeyboardMovement;
            keyboardRotation = cameraActions.Camera.KeyboardRotation;

            cameraActions.Camera.MouseZoom.performed += HandleCameraZoom_FollowOffsetZoom;
        }

        private void OnDisable()
        {
            cameraActions.Camera.Disable();

            cameraActions.Camera.MouseZoom.performed -= HandleCameraZoom_FollowOffsetZoom;
        }

        private void Update()
        {
            HandleCameraMovement();

            if (cameraSettings.UseEdgeScrolling)
                HandleCameraMovementEdgeScrolling();

            if (cameraSettings.UseDragPan)
                HandleCameraMovementDragPan();

            HandleCameraRotation();

            if (cameraSettings.UseDragRotation)
                HandleCameraRotationDragRotation();
        }

        /// <summary>
        /// Set a new camera settings to this controller
        /// </summary>
        /// <param name="cameraSettings">The new camera settings</param>
        public void SetCameraSettings(CameraSettings cameraSettings)
        {
            this.cameraSettings = cameraSettings;
        }

        /// <summary>
        /// Handle camera movement based on player input (WASD, arrow keys, left stick,...)
        /// </summary>
        private void HandleCameraMovement()
        {
            Vector2 keyboardValue = keyboardMovement.ReadValue<Vector2>();
            Vector3 inputDir = new Vector3(keyboardValue.x, 0f, keyboardValue.y);

            if (inputDir.magnitude != 0)
                ApplyMovement(inputDir);
        }

        /// <summary>
        /// Handle camera movement related to edge scrolling 
        /// </summary>
        private void HandleCameraMovementEdgeScrolling()
        {
            Vector3 inputDir = Vector3.zero;
            Vector2 mousePosition = Mouse.current.position.ReadValue();

            if (mousePosition.x < (Screen.width * cameraSettings.EdgeScrollSizeX)) inputDir.x += -1f;
            if (mousePosition.y < (Screen.height * cameraSettings.EdgeScrollSizeY)) inputDir.z += -1f;
            if (mousePosition.x > (Screen.width * (1f - cameraSettings.EdgeScrollSizeX))) inputDir.x += +1f;
            if (mousePosition.y > (Screen.height * (1f - cameraSettings.EdgeScrollSizeY))) inputDir.z += +1f;

            if (inputDir.magnitude != 0)
                ApplyMovement(inputDir);
        }

        /// <summary>
        /// Handle camera movement related to drag
        /// </summary>
        private void HandleCameraMovementDragPan()
        {
            if (!Mouse.current.rightButton.isPressed)
                return;

            Vector2 mouseMovementDelta = cameraActions.Camera.MouseDelta.ReadValue<Vector2>();

            Vector3 inputDir = Vector3.zero;
            inputDir.x = -mouseMovementDelta.x * cameraSettings.DragPanSpeedMultiplier;
            inputDir.z = -mouseMovementDelta.y * cameraSettings.DragPanSpeedMultiplier;

            if (inputDir.magnitude != 0)
                ApplyMovement(inputDir);
        }

        /// <summary>
        /// Apply movement to the camera
        /// </summary>
        /// <param name="inputDir"></param>
        private void ApplyMovement(Vector3 inputDir)
        {
            Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;
            transform.position += cameraSettings.MoveCameraSpeed * Time.deltaTime * moveDir;
        }

        /// <summary>
        /// Handle camera rotation based on the player input (Q and E keys, ...)
        /// </summary>
        private void HandleCameraRotation()
        {
            float rotateDir = keyboardRotation.ReadValue<float>();

            if (rotateDir != 0)
                ApplyRotation(rotateDir);
        }

        /// <summary>
        /// Handle camera rotation related to drag
        /// </summary>
        private void HandleCameraRotationDragRotation()
        {
            if (!Mouse.current.middleButton.isPressed)
                return;

            float rotateDir = cameraActions.Camera.MouseDelta.ReadValue<Vector2>().x * cameraSettings.DragRotationSpeedMultiplier;

            if (rotateDir != 0)
                ApplyRotation(rotateDir);
        }

        /// <summary>
        /// Apply rotation to the camera
        /// </summary>
        /// <param name="rotateDir"></param>
        private void ApplyRotation(float rotateDir)
        {
            transform.eulerAngles += new Vector3(0f, rotateDir * cameraSettings.RotateCameraSpeed * Time.deltaTime, 0f);
        }

        /// <summary>
        /// Handle the camera zoom
        /// </summary>
        /// <param name="inputAction"></param>
        private void HandleCameraZoom_FollowOffsetZoom(InputAction.CallbackContext inputAction)
        {
            if (!cameraSettings.UseZoom)
                return;

            Vector3 zoomDir = followOffset.normalized;

            if (inputAction.ReadValue<Vector2>().y > 0) followOffset -= zoomDir * cameraSettings.ZoomCameraAmount;
            if (inputAction.ReadValue<Vector2>().y < 0) followOffset += zoomDir * cameraSettings.ZoomCameraAmount;

            if (followOffset.magnitude < cameraSettings.FollowOffsetMin) followOffset = zoomDir * cameraSettings.FollowOffsetMin;
            if (followOffset.magnitude > cameraSettings.FollowOffsetMax) followOffset = zoomDir * cameraSettings.FollowOffsetMax;

            cinemachineTransposer.m_FollowOffset = Vector3.Lerp(cinemachineTransposer.m_FollowOffset, followOffset, Time.deltaTime * cameraSettings.ZoomCameraSpeed);
        }

        //private void HandleCameraZoom_LowerY()
        //{
        //    if (cameraActions.Camera.MouseZoom.ReadValue<Vector2>().y > 0) followOffset.y -= cameraSettings.ZoomCameraAmount;
        //    if (cameraActions.Camera.MouseZoom.ReadValue<Vector2>().y < 0) followOffset.y += cameraSettings.ZoomCameraAmount;

        //    followOffset.y = Mathf.Clamp(followOffset.y, cameraSettings.FollowOffsetMinY, cameraSettings.FollowOffsetMaxY);

        //    cinemachineTransposer.m_FollowOffset = Vector3.Lerp(cinemachineTransposer.m_FollowOffset, followOffset, Time.deltaTime * cameraSettings.ZoomCameraSpeed);
        //}
    }
}