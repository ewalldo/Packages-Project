using System;
using System.Collections.Generic;
using System.Text;

namespace GOAP.Sensing
{
    /// <summary>
    /// A generic key-value store shared across sensors, actions, and goals
    /// on a single agent. Allows data sharing without direct coupling.
    ///
    /// Sensors are the primary writers, actions and goals are the primary readers.
    ///
    /// Example flow:
    ///   EnemySensor     Å® writes "NearestEnemy"  (Transform)
    ///   EnemySensor     Å® writes "EnemyDistance" (float)
    ///   MoveToAction    Å® reads  "NearestEnemy"  to get movement destination
    ///   AttackAction    Å® reads  "NearestEnemy"  to select attack target
    ///   KillEnemyGoal   Å® reads  "EnemyDistance" to compute dynamic priority
    ///
    /// Lives on the GoapAgent and is passed through both SensorContext
    /// and ActionContext so all subsystems share the same instance.
    /// </summary>
    public class Blackboard
    {
        // - Storage -

        private readonly Dictionary<string, object> data = new Dictionary<string, object>();

        // - Events -

        /// <summary>
        /// Raised when any value on the blackboard changes.
        /// Key is the changed entry's key, value is the new value.
        /// Useful for reactive systems that want to respond to specific changes.
        /// </summary>
        public event Action<string, object> OnValueChanged;

        // - Constructor -

        public Blackboard(int capacity = 16)
        {
            data = new Dictionary<string, object>(capacity, StringComparer.Ordinal);
        }

        // - Write API -

        /// <summary>
        /// Writes a value to the blackboard under the given key.
        /// Raises OnValueChanged if the value differs from the current one.
        /// </summary>
        public void Set<T>(string key, T value)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Blackboard key cannot be null or empty.", nameof(key));

            bool hasExisting = data.TryGetValue(key, out object existing);
            bool changed     = !hasExisting || !Equals(existing, value);

            data[key] = value;

            if (changed)
                OnValueChanged?.Invoke(key, value);
        }

        /// <summary>Removes an entry from the blackboard if it exists.</summary>
        public void Remove(string key)
        {
            if (data.Remove(key))
                OnValueChanged?.Invoke(key, null);
        }

        /// <summary>Removes all entries from the blackboard.</summary>
        public void Clear()
        {
            data.Clear();
            OnValueChanged?.Invoke(string.Empty, null);
        }

        // - Read API -

        /// <summary>Returns true if the given key exists in the blackboard.</summary>
        public bool Has(string key) => data.ContainsKey(key);

        /// <summary>
        /// Tries to retrieve a value by key, casting it to the expected type T.
        /// Returns false if the key is missing or the type does not match.
        /// </summary>
        public bool TryGet<T>(string key, out T value)
        {
            if (data.TryGetValue(key, out object raw) && raw is T typed)
            {
                value = typed;
                return true;
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Returns the value for a key, or a default value if not found.
        /// </summary>
        public T Get<T>(string key, T defaultValue = default) => TryGet(key, out T val) ? val : defaultValue;

        /// <summary>
        /// Returns all currently stored keys.
        /// Useful for debugging and editor tooling.
        /// </summary>
        public IEnumerable<string> GetKeys() => data.Keys;

        // - Debug -

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Blackboard {");
            foreach (KeyValuePair<string, object> kvp in data)
                sb.AppendLine($"  \"{kvp.Key}\" = {kvp.Value}");
            sb.Append("}");

            return sb.ToString();
        }
    }
}