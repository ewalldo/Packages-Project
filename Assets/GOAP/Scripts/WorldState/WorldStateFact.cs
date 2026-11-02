using System;

namespace GOAP.WorldStates
{
    /// <summary>
    /// Represents a single fact: a key paired with a value.
    /// Used to define preconditions and effects on actions,
    /// and as individual entries inside a WorldState.
    /// </summary>
    public readonly struct WorldStateFact : IEquatable<WorldStateFact>
    {
        public readonly WorldStateKey Key;
        public readonly object Value;

        public WorldStateFact(WorldStateKey key, object value)
        {
            Key = key;
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        // - Typed Factory Methods -

        public static WorldStateFact Create(WorldStateKey key, bool value) => new WorldStateFact(key, value);
        public static WorldStateFact Create(WorldStateKey key, int value)   => new WorldStateFact(key, value);
        public static WorldStateFact Create(WorldStateKey key, float value) => new WorldStateFact(key, value);
        public static WorldStateFact Create(WorldStateKey key, string value)=> new WorldStateFact(key, value);

        // - Equality -

        public bool Equals(WorldStateFact other)
        {
            return Key.Equals(other.Key) &&
                   Equals(Value, other.Value);
        }

        public override bool Equals(object obj) => obj is WorldStateFact other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Key, Value);

        public static bool operator ==(WorldStateFact a, WorldStateFact b) => a.Equals(b);
        public static bool operator !=(WorldStateFact a, WorldStateFact b) => !a.Equals(b);

        public override string ToString() => $"[{Key.Name} = {Value}]";
    }
}