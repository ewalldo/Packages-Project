using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventBusPattern
{
	[CreateAssetMenu(fileName = "EventBus", menuName = "Scriptable Objects/Event Bus")]
	public class EventBus: ScriptableObject, IEventBus
	{
		private Dictionary<Type, List<Delegate>> events = new Dictionary<Type, List<Delegate>>();

        private void OnDisable()
        {
            events.Clear();
        }

        /// <inheritdoc/>
        public void Register<T>(Action<T> callback) where T : struct
        {
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

             Type eventType = typeof(T);

            if (!events.TryGetValue(eventType, out List<Delegate> actions))
            {
                actions = new List<Delegate>();
                events[eventType] = actions;
            }

            actions.Add(callback);
        }

        /// <inheritdoc/>
        public void Unregister<T>(Action<T> callback) where T : struct
        {
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            Type eventType = typeof(T);

            if (!events.TryGetValue(eventType, out List<Delegate> actions))
                return;

            actions.Remove(callback);
            if (actions.Count == 0)
                events.Remove(eventType);
        }

        /// <inheritdoc/>
        public void UnregisterAll()
        {
            events.Clear();
        }

        /// <inheritdoc/>
        public void Invoke<T>(T eventData) where T : struct
        {
            Type eventType = typeof(T);

            if (!events.TryGetValue(eventType, out List<Delegate> actions))
                return;

            // To avoid potential issues with modifying the list while iterating, we can create a copy of the list before invoking the actions.
            foreach (var action in actions.ToArray())
                ((Action<T>)action).Invoke(eventData);
        }

        public IReadOnlyDictionary<Type, List<Delegate>> GetRegisteredEvents() => events;
    }
}