using UnityEngine;
using UnityEngine.InputSystem;

namespace GridSystem
{
	public class CameraMovementSampleScene : MonoBehaviour
	{
        [SerializeField] private float moveSpeed;

        private void Update()
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            {
                transform.position += moveSpeed * Time.deltaTime * Vector3.forward;
            }

            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                transform.position += moveSpeed * Time.deltaTime * -Vector3.right;
            }

            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            {
                transform.position += moveSpeed * Time.deltaTime * -Vector3.forward;
            }

            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                transform.position += moveSpeed * Time.deltaTime * Vector3.right;
            }
        }
    }
}