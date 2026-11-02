using System;

namespace EventBusPattern
{
	public interface IEventBus
	{
		/// <summary>
		/// Register a callback for a specific event type
		/// </summary>
		/// <typeparam name="T">Event type</typeparam>
		/// <param name="callback">Callback for the event</param>
		void Register<T>(Action<T> callback) where T : struct;

		/// <summary>
		/// Unregister a callback for a specific event type
		/// </summary>
		/// <typeparam name="T">Event type</typeparam>
		/// <param name="callback">Callback for the event</param>
		void Unregister<T>(Action<T> callback) where T : struct;

		/// <summary>
		/// Unregister all callbacks from all event types
		/// </summary>
		void UnregisterAll();

		/// <summary>
		/// Invoke all callbacks registered to a specific event type
		/// </summary>
		/// <typeparam name="T">Event type</typeparam>
		/// <param name="eventData">Event data</param>
		void Invoke<T>(T eventData) where T : struct;
	}
}