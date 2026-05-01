using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CameraSystem
{
	public class CameraController : MonoBehaviour
	{
        [SerializeField] private CinemachineCamera cinemachineCamera;
        [SerializeField] private CameraSettings cameraSettings;

        private CameraSystemInputActions cameraActions;
        private InputAction keyboardMovement;
        private InputAction keyboardRotation;

        private Vector3 followOffset;

        private CinemachineFollow cinemachineFollow;

        private void Awake()
        {
            cinemachineFollow = cinemachineCamera.GetComponent<CinemachineFollow>();
            if (cinemachineFollow == null)
                Debug.LogError("[CameraController] CinemachineFollow component not found!", this);

            cameraActions = new CameraSystemInputActions();

            if (cameraSettings.OverrideCameraInitialOffset)
                cinemachineFollow.FollowOffset = cameraSettings.CinemachineVirtualCameraInitialOffset;
            followOffset = cinemachineFollow.FollowOffset;
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

            if (cameraSettings.UseZoom)
                HandleCameraZoom();
        }

        /// <summary>
        /// Set a new camera settings to this controller
        /// </summary>
        /// <param name="cameraSettings">The new camera settings</param>
        public void SetCameraSettings(CameraSettings cameraSettings)
        {
            this.cameraSettings = cameraSettings;
            followOffset = cinemachineFollow.FollowOffset;
        }

        /// <summary>
        /// Handle camera movement based on player input (WASD, arrow keys, left stick,...)
        /// </summary>
        private void HandleCameraMovement()
        {
            Vector2 keyboardValue = keyboardMovement.ReadValue<Vector2>();
            Vector3 inputDir = new Vector3(keyboardValue.x, 0f, keyboardValue.y);

            if (inputDir.sqrMagnitude > 0f)
                ApplyMovement(inputDir);
        }

        /// <summary>
        /// Handle camera movement related to edge scrolling 
        /// </summary>
        private void HandleCameraMovementEdgeScrolling()
        {
            if (!cameraSettings.UseEdgeScrollingWhenHoveringUI && UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                return;

            Vector3 inputDir = Vector3.zero;
            Vector2 mousePosition = Mouse.current.position.ReadValue();

            if (mousePosition.x < (Screen.width * cameraSettings.EdgeScrollSizeX))
                inputDir.x += -1f;
            if (mousePosition.y < (Screen.height * cameraSettings.EdgeScrollSizeY))
                inputDir.z += -1f;
            if (mousePosition.x > (Screen.width * (1f - cameraSettings.EdgeScrollSizeX)))
                inputDir.x += +1f;
            if (mousePosition.y > (Screen.height * (1f - cameraSettings.EdgeScrollSizeY)))
                inputDir.z += +1f;

            if (inputDir.sqrMagnitude > 0f)
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

            if (inputDir.sqrMagnitude > 0f)
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
        /// Handle the camera zoom by changing the follow offset of the cinemachine virtual camera, this is called every frame when zoom is active to make the zoom smooth, the follow offset is changed in the HandleCameraZoom_FollowOffsetZoom method when the player scrolls the mouse wheel
        /// </summary>
        private void HandleCameraZoom()
        {
            cinemachineFollow.FollowOffset = Vector3.Lerp(cinemachineFollow.FollowOffset, followOffset, Time.deltaTime * cameraSettings.ZoomCameraSpeed);
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

            float scrollY = inputAction.ReadValue<Vector2>().y;
            if (scrollY == 0)
                return;

            if (scrollY > 0)
                followOffset -= zoomDir * cameraSettings.ZoomCameraAmount;
            if (scrollY < 0)
                followOffset += zoomDir * cameraSettings.ZoomCameraAmount;

            float mag = followOffset.magnitude;
            if (mag < cameraSettings.FollowOffsetMin)
                followOffset = zoomDir * cameraSettings.FollowOffsetMin;
            else if (mag > cameraSettings.FollowOffsetMax)
                followOffset = zoomDir * cameraSettings.FollowOffsetMax;
        }
    }
}