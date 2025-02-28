using System;
using UnityEngine;
using UnityEngine.Events;

namespace EasierAnimations
{
	[Serializable]
	public class AnimationEvent
	{
		public string EventName;
		public UnityEvent OnAnimationEvent;

		public static string GetNameOfEventName => nameof(EventName);
		public static string GetNameOfOnAnimationEvent => nameof(OnAnimationEvent);
	}
}