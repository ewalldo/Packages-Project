using UnityEngine;

namespace GenericNamespace
{
	public class LookAtCamera : MonoBehaviour
	{
        [SerializeField] private Camera lookCamera;
        [SerializeField] private Mode mode;

        private enum Mode
        {
            LookAt,
            LookAtInverted,
            CameraForward,
            CameraForwardInverted
        }

        private void Awake()
        {
            if (lookCamera == null)
                lookCamera = Camera.main;
        }

        private void LateUpdate()
        {
            if (lookCamera == null)
                return;

            switch (mode)
            {
                case Mode.LookAt:
                    transform.LookAt(lookCamera.transform);
                    break;
                case Mode.LookAtInverted:
                    Vector3 dirFromCamera = transform.position - lookCamera.transform.position;
                    transform.LookAt(transform.position + dirFromCamera);
                    break;
                case Mode.CameraForward:
                    transform.forward = lookCamera.transform.forward;
                    break;
                case Mode.CameraForwardInverted:
                    transform.forward = -lookCamera.transform.forward;
                    break;
                default:
                    break;
            }
        }

        public void SetCamera(Camera lookCamera)
        {
            this.lookCamera = lookCamera;
        }
    }
}