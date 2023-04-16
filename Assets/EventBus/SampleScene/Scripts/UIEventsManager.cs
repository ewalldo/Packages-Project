using UnityEngine;
using UnityEngine.UI;

namespace EventBusPattern
{
	public class UIEventsManager : MonoBehaviour
	{
        [Header("Event Types")]
        [SerializeField] private EventType buttonClick;
		[SerializeField] private EventType sliderChangedValue;

        public void ButtonClick(Button button)
        {
            EventBus.Invoke<Button>(buttonClick, button);
        }

        public void SliderChangedValue(Slider slider)
        {
            EventBus.Invoke<float>(sliderChangedValue, slider.value);
        }
    }
}