using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasierAnimations
{
	[RequireComponent(typeof(Animator))]
	public class AnimationEventReceiver : MonoBehaviour
	{
		[SerializeField] private List<AnimationEvent> animationEvents = new List<AnimationEvent>();

		public event Action<AnimationEvent> OnAnimationEventTriggered;

		public void TriggerAnimationEvent(string eventName)
        {
			AnimationEvent animationEvent = animationEvents.Find((ae) => ae.EventName == eventName);

			animationEvent?.OnAnimationEvent?.Invoke();
			OnAnimationEventTriggered?.Invoke(animationEvent);
        }
	}
}