using UnityEngine;

namespace IndicatorSystem
{
	public class IndicatorSampleCharacterMovement : MonoBehaviour
	{
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float mouseSensitivity = 100f;

        [SerializeField] private Indicator runtimeIndicatorPrefab;
        [SerializeField] private Transform indicatorParent;
        [SerializeField] private Canvas indicatorCanvas;

        float xRotation = 0f;

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
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }

        private void LookAround()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            transform.Rotate(Vector3.up * mouseX);
        }

        private void SpawnIndicator()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
                return;

            Indicator spawnedIndicator = Instantiate(runtimeIndicatorPrefab,
                transform.position + (transform.forward * 10f/* new Vector3(0f, 0f, 0f)*/),
                Quaternion.identity,
                indicatorParent);

            spawnedIndicator.SetupIndicator(indicatorCanvas, playerCamera, playerCamera.transform);
        }

        private void ResetIndicators()
        {
            if (!Input.GetKeyDown(KeyCode.R))
                return;

            foreach (Transform child in indicatorParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
}