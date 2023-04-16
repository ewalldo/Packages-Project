using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace EventBusPattern
{
	public class UIInfoManager : MonoBehaviour
	{
        [Header("UI Fields")]
        [SerializeField] private TextMeshProUGUI uiCharacterInfoSpeedUGUI;
        [SerializeField] private TextMeshProUGUI uiCharacterInfoMovementUGUI;
        [SerializeField] private TextMeshProUGUI uiEventsInfoUGUI;

        [Header("Event Types")]
        [SerializeField] private EventType buttonClicked;
        [SerializeField] private EventType sliderChangedValue;
        [SerializeField] private EventType characterMovement;

        private void OnEnable()
        {
            EventBus.Register<Button>(buttonClicked, OnButtonClicked);
            EventBus.Register<float>(sliderChangedValue, OnSliderChanged);
            EventBus.Register<bool>(characterMovement, OnCharacterMovement);
        }

        private void OnDisable()
        {
            EventBus.Unregister<Button>(buttonClicked, OnButtonClicked);
            EventBus.Unregister<float>(sliderChangedValue, OnSliderChanged);
            EventBus.Unregister<bool>(characterMovement, OnCharacterMovement);
        }

        private void UpdateUIEventsInfo(string newInfo)
        {
            uiEventsInfoUGUI.text = newInfo;
        }

        private void OnButtonClicked(Button clickedButton)
        {
            TextMeshProUGUI buttonText = clickedButton.GetComponentInChildren<TextMeshProUGUI>();
            UpdateUIEventsInfo("The \"" + buttonText.text + "\" was clicked");
        }

        private void OnSliderChanged(float newSliderValue)
        {
            UpdateUIEventsInfo("Slider value changed to " + newSliderValue.ToString());
            uiCharacterInfoSpeedUGUI.text = "Speed: " + newSliderValue.ToString();
        }

        private void OnCharacterMovement(bool isMoving)
        {
            uiCharacterInfoMovementUGUI.text = "Is Moving: " + isMoving;
        }
    }
}