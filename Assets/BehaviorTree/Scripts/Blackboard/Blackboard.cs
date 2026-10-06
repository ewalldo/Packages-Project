using System;
using System.Collections.Generic;

namespace BehaviorTree
{
    public class Blackboard
    {
        private readonly Dictionary<BlackboardKey, object> blackboardValues = new Dictionary<BlackboardKey, object>();

        /// <summary>
        /// Raised when a value is set or it changes on this blackboard
        /// </summary>
        public event Action<BlackboardKey, object> OnValueChanged;

        /// <summary>
        /// The keys set on this blackboard
        /// </summary>
        public IReadOnlyCollection<BlackboardKey> Keys => blackboardValues.Keys;

        public Blackboard() {}

        /// <summary>Sets a value in the blackboard</summary>
        /// <typeparam name="T">The value's type</typeparam>
        /// <param name="key">The key to write</param>
        /// <param name="value">The value to store</param>
        public void SetValue<T>(BlackboardKey key, T value)
        {
            bool hadOldValue = blackboardValues.TryGetValue(key, out object oldValue);
            blackboardValues[key] = value;

            if (!hadOldValue || !Equals(oldValue, value))
                OnValueChanged?.Invoke(key, value);
        }

        /// <summary>
        /// Try to get a value of type <typeparamref name="T"/> from the blackboard
        /// </summary>
        /// <typeparam name="T">The expected value type.</typeparam>
        /// <param name="key">The key to look up</param>
        /// <param name="value">The found value, or default if not found</param>
        /// <returns>True if a value of type <typeparamref name="T"/> was found, false otherwise</returns>
        public bool TryGetValue<T>(BlackboardKey key, out T value)
        {
            if (blackboardValues.TryGetValue(key, out object raw) && raw is T typed)
            {
                value = typed;
                return true;
            }

            value = default;
            return false;
        }

        /// <summary>Looks up a value and returns it, if not found, the fallback is returned instead</summary>
        /// <typeparam name="T">The expected value type</typeparam>
        /// <param name="key">The key to look up</param>
        /// <param name="fallback">The value to return if the key isn't found</param>
        /// <returns>The value associated with the key, or <paramref name="fallback"/> if not found</returns>
        public T GetValueOrDefault<T>(BlackboardKey key, T fallback = default)
        {
            return TryGetValue(key, out T value) ? value : fallback;
        }

        /// <summary>Check if the blackboard has a specific key</summary>
        /// <param name="key">The key to check</param>
        /// <returns>True if the blackboard has the key, false otherwise</returns>
        public bool HasKey(BlackboardKey key)
        {
            return blackboardValues.ContainsKey(key);
        }

        /// <summary>Removes a key from the blackboard</summary>
        /// <param name="key">The key to remove</param>
        /// <returns>True if the key was present and removed</returns>
        public bool Remove(BlackboardKey key)
        {
            return blackboardValues.Remove(key);
        }

        /// <summary>Removes all entries from the blackboard</summary>
        public void Clear()
        {
            blackboardValues.Clear();
        }
    }
}