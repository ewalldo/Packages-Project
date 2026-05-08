using UnityEngine;
using UnityEngine.UI;

namespace EventBusPattern.Sample
{
	public class UIEventsManager : MonoBehaviour
	{
        [Header("Event bus")]
        [SerializeField] private EventBus uiEventBus;
        
        public void ButtonClick(Button button)
        {
            uiEventBus.Invoke<OnButtonClickEvent>(new OnButtonClickEvent { ClickedButton = button });
        }

        public void SliderChangedValue(Slider slider)
        {
            uiEventBus.Invoke<OnSliderValueChangedEvent>(new OnSliderValueChangedEvent { NewValue = slider.value });
        }
    }
}