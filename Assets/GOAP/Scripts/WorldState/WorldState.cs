using System;
using System.Collections.Generic;
using System.Text;

namespace GOAP.WorldStates
{
    /// <summary>
    /// A mutable key-value store representing a snapshot of facts about the world.
    /// Used as the current agent state, goal desired state, and simulated states during planning.
    /// Supports cloning, merging, diffing, and goal satisfaction checks.
    /// </summary>
    public class WorldState
    {
        private readonly Dictionary<WorldStateKey, object> facts;

        public int Count => facts.Count;

        // - Constructors -

        public WorldState()
        {
            facts = new Dictionary<WorldStateKey, object>();
        }

        public WorldState(int capacity)
        {
            facts = new Dictionary<WorldStateKey, object>(capacity);
        }

        /// <summary>Private constructor used by Clone().</summary>
        private WorldState(Dictionary<WorldStateKey, object> source)
        {
            facts = new Dictionary<WorldStateKey, object>(source);
        }

        // - Write API -

        public void Set(WorldStateKey key, bool value)   => facts[key] = value;
        public void Set(WorldStateKey key, int value)    => facts[key] = value;
        public void Set(WorldStateKey key, float value)  => facts[key] = value;
        public void Set(WorldStateKey key, string value) => facts[key] = value;

        /// <summary>
        /// Sets a value using a pre-built WorldStateFact.
        /// Useful when applying action effects in bulk.
        /// </summary>
        public void Apply(WorldStateFact fact) => facts[fact.Key] = fact.Value;

        /// <summary>Applies a collection of facts (e.g. action effects) onto this state.</summary>
        public void ApplyRange(IEnumerable<WorldStateFact> facts)
        {
            foreach (WorldStateFact fact in facts)
                Apply(fact);
        }

        public void Remove(WorldStateKey key) => facts.Remove(key);

        public void Clear() => facts.Clear();

        // - Read API -

        public bool Has(WorldStateKey key) => facts.ContainsKey(key);

        public bool TryGet<T>(WorldStateKey key, out T value)
        {
            if (facts.TryGetValue(key, out object raw) && raw is T typed)
            {
                value = typed;
                return true;
            }

            value = default;
            return false;
        }

        public bool GetBool(WorldStateKey key, bool defaultValue = false) => TryGet(key, out bool val) ? val : defaultValue;

        public int GetInt(WorldStateKey key, int defaultValue = 0) => TryGet(key, out int val) ? val : defaultValue;

        public float GetFloat(WorldStateKey key, float defaultValue = 0f) => TryGet(key, out float val) ? val : defaultValue;

        public string GetString(WorldStateKey key, string defaultValue = "") => TryGet(key, out string val) ? val : defaultValue;

        // - State Operations -

        /// <summary>
        /// Returns a deep copy of this WorldState.
        /// Used by the planner to simulate state transitions without mutating the original.
        /// </summary>
        public WorldState Clone() => new WorldState(facts);

        /// <summary>
        /// Copies all facts from another WorldState into this one.
        /// Existing keys are overwritten, keys only in this state are preserved.
        /// </summary>
        public void MergeWith(WorldState other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            foreach (KeyValuePair<WorldStateKey, object> kvp in other.facts)
                facts[kvp.Key] = kvp.Value;
        }

        /// <summary>
        /// Checks whether this WorldState satisfies all facts defined in the given goal state.
        /// A state is satisfied if for every fact in the goal, this state contains the same key
        /// with an equal value. Extra facts in this state are ignored.
        /// </summary>
        /// <param name="goalState">The desired state to check against.</param>
        public bool Satisfies(WorldState goalState)
        {
            if (goalState == null)
                throw new ArgumentNullException(nameof(goalState));

            foreach (KeyValuePair<WorldStateKey, object> goal in goalState.facts)
            {
                // Key missing entirely
                if (!facts.TryGetValue(goal.Key, out object currentValue))
                    return false;

                // Key present but value doesn't match
                if (!Equals(currentValue, goal.Value))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Returns all facts that differ between this state and another.
        /// A fact is included if: the key is missing in the other state,
        /// or the value for the same key is different.
        /// </summary>
        public IReadOnlyList<WorldStateFact> GetDiff(WorldState other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            List<WorldStateFact> diff = new List<WorldStateFact>();

            foreach (KeyValuePair<WorldStateKey, object> kvp in facts)
            {
                if (!other.facts.TryGetValue(kvp.Key, out object otherValue) || !Equals(kvp.Value, otherValue))
                {
                    diff.Add(new WorldStateFact(kvp.Key, kvp.Value));
                }
            }

            return diff;
        }

        /// <summary>Enumerate all current facts. Useful for sensors and debug tooling.</summary>
        public IEnumerable<WorldStateFact> GetAllFacts()
        {
            foreach (KeyValuePair<WorldStateKey, object> kvp in facts)
                yield return new WorldStateFact(kvp.Key, kvp.Value);
        }

        // - Debug -

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("WorldState {");
            foreach (KeyValuePair<WorldStateKey, object> kvp in facts)
                sb.AppendLine($"  {kvp.Key.Name} = {kvp.Value}");
            sb.Append("}");

            return sb.ToString();
        }
    }
}