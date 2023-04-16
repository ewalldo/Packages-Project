using UnityEngine;

namespace EventBusPattern
{
    [CreateAssetMenu(fileName = "EventType", menuName = "Scriptable Objects/Event Bus/Event Type")]
    public class EventType : ScriptableObject
	{
		[SerializeField] private string eventName;

		public string GetNameOfEventName => nameof(eventName);

		/// <summary>
		/// Get the name of this event
		/// </summary>
		public string GetEventName => eventName;
	}
}