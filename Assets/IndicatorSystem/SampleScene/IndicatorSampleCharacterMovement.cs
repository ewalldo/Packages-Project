using UnityEngine;
using UnityEngine.InputSystem;

namespace IndicatorSystem
{
	public class IndicatorSampleCharacterMovement : MonoBehaviour
	{
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float mouseSensitivity = 10f;

        [SerializeField] private Indicator runtimeIndicatorPrefab;
        [SerializeField] private Transform indicatorParent;
        [SerializeField] private Canvas indicatorCanvas;

        private float xRotation = 0f;

        private InputAction moveAction;
        private Vector2 moveValue;

        private Vector2 mouseDelta;

        private void Awake()
        {
            moveAction = InputSystem.actions.FindAction("Player/Move");
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            MovePlayer();
            LookAround();
            SpawnIndicator();
            ResetIndicators();
        }

        private void MovePlayer()
        {
            moveValue = moveAction.ReadValue<Vector2>();
            Vector3 moveDirection = transform.right * moveValue.x + transform.forward * moveValue.y;

            transform.Translate(moveSpeed * Time.deltaTime * moveDirection, Space.World);
        }

        private void LookAround()
        {
            mouseDelta = Mouse.current.delta.ReadValue();
            mouseDelta *= mouseSensitivity * Time.deltaTime;

            xRotation -= mouseDelta.y;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            transform.Rotate(Vector3.up * mouseDelta.x);
        }

        private void SpawnIndicator()
        {
            if (!Keyboard.current.spaceKey.wasPressedThisFrame)
                return;

            Indicator spawnedIndicator = Instantiate(runtimeIndicatorPrefab,
                transform.position + (transform.forward * 10f/* new Vector3(0f, 0f, 0f)*/),
                Quaternion.identity,
                indicatorParent);

            spawnedIndicator.SetupIndicator(indicatorCanvas, playerCamera, playerCamera.transform);
        }

        private void ResetIndicators()
        {
            if (!Keyboard.current.rKey.wasPressedThisFrame)
                return;

            foreach (Transform child in indicatorParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
}