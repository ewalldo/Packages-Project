using UnityEngine;
using TMPro;
using EventBusPattern.Sample;

namespace EventBusPattern.Sample
{
	public class UIInfoManager : MonoBehaviour
	{
        [Header("UI Fields")]
        [SerializeField] private TextMeshProUGUI uiCharacterInfoSpeedUGUI;
        [SerializeField] private TextMeshProUGUI uiCharacterInfoMovementUGUI;
        [SerializeField] private TextMeshProUGUI uiEventsInfoUGUI;

        [Header("Event buses")]
        [SerializeField] private EventBus uiEventBus;
        [SerializeField] private EventBus gameplayEventBus;

        private void OnEnable()
        {
            uiEventBus.Register<OnButtonClickEvent>(OnButtonClicked);
            uiEventBus.Register<OnSliderValueChangedEvent>(OnSliderChanged);
            gameplayEventBus.Register<OnCharacterMoveEvent>(OnCharacterMovement);
        }

        private void OnDisable()
        {
            uiEventBus.Unregister<OnButtonClickEvent>(OnButtonClicked);
            uiEventBus.Unregister<OnSliderValueChangedEvent>(OnSliderChanged);
            gameplayEventBus.Unregister<OnCharacterMoveEvent>(OnCharacterMovement);
        }

        private void UpdateUIEventsInfo(string newInfo)
        {
            uiEventsInfoUGUI.text = newInfo;
        }

        private void OnButtonClicked(OnButtonClickEvent onButtonClickEvent)
        {
            TextMeshProUGUI buttonText = onButtonClickEvent.ClickedButton.GetComponentInChildren<TextMeshProUGUI>();
            UpdateUIEventsInfo("The \"" + buttonText.text + "\" was clicked");
        }

        private void OnSliderChanged(OnSliderValueChangedEvent onSliderValueChangedEvent)
        {
            UpdateUIEventsInfo("Slider value changed to " + onSliderValueChangedEvent.NewValue.ToString());
            uiCharacterInfoSpeedUGUI.text = "Speed: " + onSliderValueChangedEvent.NewValue.ToString();
        }

        private void OnCharacterMovement(OnCharacterMoveEvent onCharacterMoveEvent)
        {
            uiCharacterInfoMovementUGUI.text = "Is Moving: " + onCharacterMoveEvent.IsMoving;
        }
    }
}