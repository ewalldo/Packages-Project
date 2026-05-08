using UnityEngine;
using UnityEngine.InputSystem;

namespace EventBusPattern.Sample
{
	public class Character : MonoBehaviour
	{
        [Header("Event bus")]
        [SerializeField] private EventBus uiEventBus;
        [SerializeField] private EventBus gameplayEventBus;


        private float characterSpeed = 5f;
        private float rotateSpeed = 10f;

        private void OnEnable()
        {
            uiEventBus.Register<OnSliderValueChangedEvent>(UpdateSpeed);
        }

        private void OnDisable()
        {
            uiEventBus.Unregister<OnSliderValueChangedEvent>(UpdateSpeed);
        }

        private void Update()
        {
            Vector2 inputDirection = GetInputDirectionNormalized();

            if (inputDirection == Vector2.zero)
            {
                gameplayEventBus.Invoke<OnCharacterMoveEvent>(new OnCharacterMoveEvent { IsMoving = false });
                return;
            }

            Vector3 moveDirection = new Vector3(inputDirection.x, 0f, inputDirection.y);
            transform.position += characterSpeed * Time.deltaTime * moveDirection;
            transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
            gameplayEventBus.Invoke<OnCharacterMoveEvent>(new OnCharacterMoveEvent { IsMoving = true });
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

        private void UpdateSpeed(OnSliderValueChangedEvent onSliderValueChangedEvent)
        {
            characterSpeed = onSliderValueChangedEvent.NewValue;
        }
    }
}