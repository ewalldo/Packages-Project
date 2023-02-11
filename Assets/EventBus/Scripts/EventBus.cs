using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventBusPattern
{
	public static class EventBus
	{
		private static Dictionary<EventType, List<Delegate>> events = new Dictionary<EventType, List<Delegate>>();

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

		public static void Register(EventType eventType, Action callback)
        {
			RegisterEvent(eventType, callback);
        }

		public static void Register<T0>(EventType eventType, Action<T0> callback)
		{
			RegisterEvent(eventType, callback);
		}

		public static void Register<T0, T1>(EventType eventType, Action<T0, T1> callback)
		{
			RegisterEvent(eventType, callback);
		}

		public static void Register<T0, T1, T2>(EventType eventType, Action<T0, T1, T2> callback)
		{
			RegisterEvent(eventType, callback);
		}

		public static void Register<T0, T1, T2, T3>(EventType eventType, Action<T0, T1, T2, T3> callback)
		{
			RegisterEvent(eventType, callback);
		}

		public static void Register<T0, T1, T2, T3, T4>(EventType eventType, Action<T0, T1, T2, T3, T4> callback)
		{
			RegisterEvent(eventType, callback);
		}

		public static void Unregister(EventType eventType, Action callback)
        {
			UnregisterEvent(eventType, callback);
        }

		public static void Unregister<T0>(EventType eventType, Action<T0> callback)
		{
			UnregisterEvent(eventType, callback);
		}

		public static void Unregister<T0, T1>(EventType eventType, Action<T0, T1> callback)
		{
			UnregisterEvent(eventType, callback);
		}

		public static void Unregister<T0, T1, T2>(EventType eventType, Action<T0, T1, T2> callback)
		{
			UnregisterEvent(eventType, callback);
		}

		public static void Unregister<T0, T1, T2, T3>(EventType eventType, Action<T0, T1, T2, T3> callback)
		{
			UnregisterEvent(eventType, callback);
		}

		public static void Unregister<T0, T1, T2, T3, T4>(EventType eventType, Action<T0, T1, T2, T3, T4> callback)
		{
			UnregisterEvent(eventType, callback);
		}

		public static void UnregisterAllEvents()
        {
			events.Clear();
        }

		private static List<Delegate> GetActions(EventType eventType)
        {
			List<Delegate> actions = null;

			if (events.ContainsKey(eventType))
				events.TryGetValue(eventType, out actions);

			return actions;
        }

		public static void Invoke(EventType eventType)
        {
			List<Delegate> actions = GetActions(eventType);

			foreach (var action in actions)
			{
				action.DynamicInvoke();
			}
		}

		public static void Invoke<T0>(EventType eventType, T0 arg0)
		{
			List<Delegate> actions = GetActions(eventType);

			foreach (var action in actions)
			{
				action.DynamicInvoke(arg0);
			}
		}

		public static void Invoke<T0, T1>(EventType eventType, T0 arg0, T1 arg1)
		{
			List<Delegate> actions = GetActions(eventType);

			foreach (var action in actions)
			{
				action.DynamicInvoke(arg0, arg1);
			}
		}

		public static void Invoke<T0, T1, T2>(EventType eventType, T0 arg0, T1 arg1, T2 arg2)
		{
			List<Delegate> actions = GetActions(eventType);

			foreach (var action in actions)
			{
				action.DynamicInvoke(arg0, arg1, arg2);
			}
		}

		public static void Invoke<T0, T1, T2, T3>(EventType eventType, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
		{
			List<Delegate> actions = GetActions(eventType);

			foreach (var action in actions)
			{
				action.DynamicInvoke(arg0, arg1, arg2, arg3);
			}
		}

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