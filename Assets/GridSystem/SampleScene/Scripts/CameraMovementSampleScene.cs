using UnityEngine;

namespace GridSystem
{
	public class CameraMovementSampleScene : MonoBehaviour
	{
        [SerializeField] private float moveSpeed;

        private void Update()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += moveSpeed * Time.deltaTime * Vector3.forward;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += moveSpeed * Time.deltaTime * -Vector3.right;
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += moveSpeed * Time.deltaTime * -Vector3.forward;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += moveSpeed * Time.deltaTime * Vector3.right;
            }
        }
    }
}