using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventBusPattern
{
	public static class EventBus
	{
		private static Dictionary<EventType, List<Delegate>> events = new Dictionary<EventType, List<Delegate>>();

		/// <summary>
		/// Register an event to the dictionary
		/// </summary>
		/// <param name="eventType">The type of the event</param>
		/// <param name="callback">The event to be registered</param>
		private static void RegisterEvent(EventType eventType, Delegate callback)
        {
			List<Delegate> actions = null;

            if (events.TryGetValue(eventType, out actions))
            {
				actions.Add(callback);
            }
			else
            {
				actions = new List<Delegate>();
				actions.Add(callback);
				events.Add(eventType, actions);
            }
        }

		/// <summary>
		/// Unregister an event to the dictionary
		/// </summary>
		/// <param name="eventType">The type of the event</param>
		/// <param name="callback">The event to be unregistered</param>
		private static void UnregisterEvent(EventType eventType, Delegate callback)
        {
			List<Delegate> actions = null;

            if (events.TryGetValue(eventType, out actions))
            {
				actions.Remove(callback);

				if (actions.Count == 0)
					events.Remove(eventType);
            }
        }

		/// <summary>
		/// Register an event in the event bus
		/// </summary>
		/// <param name="eventType">The type of the event</param>
		/// <param name="callback">The event to be registered</param>
		public static void Register(EventType eventType, Action callback)
        {
			RegisterEvent(eventType, callback);
        }

		/// <summary>
		/// Register an event in the event bus
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <param name="eventType">The type of the event</param>
		/// <param name="callback">The event to be registered</param>
		public static void Register<T0>(EventType eventType, Action<T0> callback)
		{
			RegisterEvent(eventType, callback);
		}

		/// <summary>
		/// Register an event in the event bus
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <typeparam name="T1">Second parameter type of the event</typeparam>
		/// <param name="eventType">The type of the event</param>
		/// <param name="callback">The event to be registered</param>
		public static void Register<T0, T1>(EventType eventType, Action<T0, T1> callback)
		{
			RegisterEvent(eventType, callback);
		}

		/// <summary>
		/// Register an event in the event bus
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <typeparam name="T1">Second parameter type of the event</typeparam>
		/// <typeparam name="T2">Third parameter type of the event</typeparam>
		/// <param name="eventType">The type of the event</param>
		/// <param name="callback">The event to be registered</param>
		public static void Register<T0, T1, T2>(EventType eventType, Action<T0, T1, T2> callback)
		{
			RegisterEvent(eventType, callback);
		}

		/// <summary>
		/// Register an event in the event bus
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <typeparam name="T1">Second parameter type of the event</typeparam>
		/// <typeparam name="T2">Third parameter type of the event</typeparam>
		/// <typeparam name="T3">Fourth parameter type of the event</typeparam>
		/// <param name="eventType">The type of the event</param>
		/// <param name="callback">The event to be registered</param>
		public static void Register<T0, T1, T2, T3>(EventType eventType, Action<T0, T1, T2, T3> callback)
		{
			RegisterEvent(eventType, callback);
		}

		/// <summary>
		/// Register an event in the event bus
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <typeparam name="T1">Second parameter type of the event</typeparam>
		/// <typeparam name="T2">Third parameter type of the event</typeparam>
		/// <typeparam name="T3">Fourth parameter type of the event</typeparam>
		/// <typeparam name="T4">Fifth parameter type of the event</typeparam>
		/// <param name="eventType">The type of the event</param>
		/// <param name="callback">The event to be registered</param>
		public static void Register<T0, T1, T2, T3, T4>(EventType eventType, Action<T0, T1, T2, T3, T4> callback)
		{
			RegisterEvent(eventType, callback);
		}

		/// <summary>
		/// Unregister an event from the event bus
		/// </summary>
		/// <param name="eventType">The type of the event</param>
		/// <param name="callback">The event to be unregistered</param>
		public static void Unregister(EventType eventType, Action callback)
        {
			UnregisterEvent(eventType, callback);
        }

		/// <summary>
		/// Unregister an event from the event bus
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <param name="eventType">The type of the event</param>
		/// <param name="callback">The event to be unregistered</param>
		public static void Unregister<T0>(EventType eventType, Action<T0> callback)
		{
			UnregisterEvent(eventType, callback);
		}

		/// <summary>
		/// Unregister an event from the event bus
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <typeparam name="T1">Second parameter type of the event</typeparam>
		/// <param name="eventType">The type of the event</param>
		/// <param name="callback">The event to be unregistered</param>
		public static void Unregister<T0, T1>(EventType eventType, Action<T0, T1> callback)
		{
			UnregisterEvent(eventType, callback);
		}

		/// <summary>
		/// Unregister an event from the event bus
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <typeparam name="T1">Second parameter type of the event</typeparam>
		/// <typeparam name="T2">Third parameter type of the event</typeparam>
		/// <param name="eventType">The type of the event</param>
		/// <param name="callback">The event to be unregistered</param>
		public static void Unregister<T0, T1, T2>(EventType eventType, Action<T0, T1, T2> callback)
		{
			UnregisterEvent(eventType, callback);
		}

		/// <summary>
		/// Unregister an event from the event bus
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <typeparam name="T1">Second parameter type of the event</typeparam>
		/// <typeparam name="T2">Third parameter type of the event</typeparam>
		/// <typeparam name="T3">Fourth parameter type of the event</typeparam>
		/// <param name="eventType">The type of the event</param>
		/// <param name="callback">The event to be unregistered</param>
		public static void Unregister<T0, T1, T2, T3>(EventType eventType, Action<T0, T1, T2, T3> callback)
		{
			UnregisterEvent(eventType, callback);
		}

		/// <summary>
		/// Unregister an event from the event bus
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <typeparam name="T1">Second parameter type of the event</typeparam>
		/// <typeparam name="T2">Third parameter type of the event</typeparam>
		/// <typeparam name="T3">Fourth parameter type of the event</typeparam>
		/// <typeparam name="T4">Fifth parameter type of the event</typeparam>
		/// <param name="eventType">The type of the event</param>
		/// <param name="callback">The event to be unregistered</param>
		public static void Unregister<T0, T1, T2, T3, T4>(EventType eventType, Action<T0, T1, T2, T3, T4> callback)
		{
			UnregisterEvent(eventType, callback);
		}

		/// <summary>
		/// Unregister all the events from the event bus
		/// </summary>
		public static void UnregisterAllEvents()
        {
			events.Clear();
        }

		/// <summary>
		/// Get a list of the actions related to an event
		/// </summary>
		/// <param name="eventType">The event type</param>
		/// <returns>A list containing all events related to the event type parameter</returns>
		private static List<Delegate> GetActions(EventType eventType)
        {
			List<Delegate> actions = null;

			if (events.ContainsKey(eventType))
				events.TryGetValue(eventType, out actions);

			return actions;
        }

		/// <summary>
		/// Invoke all events registered to an event type
		/// </summary>
		/// <param name="eventType">The event type</param>
		public static void Invoke(EventType eventType)
        {
			List<Delegate> actions = GetActions(eventType);

			foreach (var action in actions)
			{
				action.DynamicInvoke();
			}
		}

		/// <summary>
		/// Invoke all events registered to an event type
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <param name="eventType">The event type</param>
		/// <param name="arg0">First parameter of the event</param>
		public static void Invoke<T0>(EventType eventType, T0 arg0)
		{
			List<Delegate> actions = GetActions(eventType);

			foreach (var action in actions)
			{
				action.DynamicInvoke(arg0);
			}
		}

		/// <summary>
		/// Invoke all events registered to an event type
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <typeparam name="T1">Second parameter type of the event</typeparam>
		/// <param name="eventType">The event type</param>
		/// <param name="arg0">First parameter of the event</param>
		/// <param name="arg1">Second parameter of the event</param>
		public static void Invoke<T0, T1>(EventType eventType, T0 arg0, T1 arg1)
		{
			List<Delegate> actions = GetActions(eventType);

			foreach (var action in actions)
			{
				action.DynamicInvoke(arg0, arg1);
			}
		}

		/// <summary>
		/// Invoke all events registered to an event type
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <typeparam name="T1">Second parameter type of the event</typeparam>
		/// <typeparam name="T2">Third parameter type of the event</typeparam>
		/// <param name="eventType">The event type</param>
		/// <param name="arg0">First parameter of the event</param>
		/// <param name="arg1">Second parameter of the event</param>
		/// <param name="arg2">Third parameter of the event</param>
		public static void Invoke<T0, T1, T2>(EventType eventType, T0 arg0, T1 arg1, T2 arg2)
		{
			List<Delegate> actions = GetActions(eventType);

			foreach (var action in actions)
			{
				action.DynamicInvoke(arg0, arg1, arg2);
			}
		}

		/// <summary>
		/// Invoke all events registered to an event type
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <typeparam name="T1">Second parameter type of the event</typeparam>
		/// <typeparam name="T2">Third parameter type of the event</typeparam>
		/// <typeparam name="T3">Fourth parameter type of the event</typeparam>
		/// <param name="eventType">The event type</param>
		/// <param name="arg0">First parameter of the event</param>
		/// <param name="arg1">Second parameter of the event</param>
		/// <param name="arg2">Third parameter of the event</param>
		/// <param name="arg3">Fourth parameter of the event</param>
		public static void Invoke<T0, T1, T2, T3>(EventType eventType, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
		{
			List<Delegate> actions = GetActions(eventType);

			foreach (var action in actions)
			{
				action.DynamicInvoke(arg0, arg1, arg2, arg3);
			}
		}

		/// <summary>
		/// Invoke all events registered to an event type
		/// </summary>
		/// <typeparam name="T0">First parameter type of the event</typeparam>
		/// <typeparam name="T1">Second parameter type of the event</typeparam>
		/// <typeparam name="T2">Third parameter type of the event</typeparam>
		/// <typeparam name="T3">Fourth parameter type of the event</typeparam>
		/// <typeparam name="T4">Fifth parameter type of the event</typeparam>
		/// <param name="eventType">The event type</param>
		/// <param name="arg0">First parameter of the event</param>
		/// <param name="arg1">Second parameter of the event</param>
		/// <param name="arg2">Third parameter of the event</param>
		/// <param name="arg3">Fourth parameter of the event</param>
		/// <param name="arg4">Fifth parameter of the event</param>
		public static void Invoke<T0, T1, T2, T3, T4>(EventType eventType, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			List<Delegate> actions = GetActions(eventType);

			foreach (var action in actions)
			{
				action.DynamicInvoke(arg0, arg1, arg2, arg3, arg4);
			}
		}
	}
}