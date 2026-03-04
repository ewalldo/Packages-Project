using UnityEngine;
using UnityEngine.InputSystem;

namespace EventBusPattern
{
	public class Character : MonoBehaviour
	{
        [Header("Event Types")]
        [SerializeField] private EventType sliderChangedValue;
        [SerializeField] private EventType characterMovementEvent;


        private float characterSpeed = 5f;
        private float rotateSpeed = 10f;

        private void OnEnable()
        {
            EventBus.Register<float>(sliderChangedValue, UpdateSpeed);
        }

        private void OnDisable()
        {
            EventBus.Unregister<float>(sliderChangedValue, UpdateSpeed);
        }

        private void Update()
        {
            Vector2 inputDirection = GetInputDirectionNormalized();

            if (inputDirection == Vector2.zero)
            {
                EventBus.Invoke<bool>(characterMovementEvent, false);
                return;
            }

            Vector3 moveDirection = new Vector3(inputDirection.x, 0f, inputDirection.y);
            transform.position += characterSpeed * Time.deltaTime * moveDirection;
            transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
            EventBus.Invoke<bool>(characterMovementEvent, true);
        }

        private Vector2 GetInputDirectionNormalized()
        {
            Vector2 inputDirection = Vector2.zero;

            if (Keyboard.current.wKey.isPressed) inputDirection.y = +1;
            if (Keyboard.current.sKey.isPressed) inputDirection.y = -1;
            if (Keyboard.current.dKey.isPressed) inputDirection.x = +1;
            if (Keyboard.current.aKey.isPressed) inputDirection.x = -1;

            inputDirection = inputDirection.normalized;

            return inputDirection;
        }

        private void UpdateSpeed(float newSpeed)
        {
            characterSpeed = newSpeed;
        }
    }
}