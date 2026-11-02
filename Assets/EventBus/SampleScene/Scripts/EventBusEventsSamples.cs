using UnityEngine.UI;

namespace EventBusPattern.Sample
{
	public struct OnCharacterMoveEvent
    {
        public bool IsMoving;
    }

    public struct OnButtonClickEvent
    {
        public Button ClickedButton;
    }

    public struct OnSliderValueChangedEvent
    {
        public float NewValue;
    }
}