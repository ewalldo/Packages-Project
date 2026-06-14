using System;

namespace GOAP.WorldStates
{
    /// <summary>
    /// A lightweight, hashable key used to identify a fact inside a WorldState.
    /// Comparisons are done via pre-computed hash for performance.
    /// Intended to be stored as static readonly fields to avoid repeated allocations.
    /// </summary>
    /// <example>
    /// public static readonly WorldStateKey IsEnemyVisible = new WorldStateKey("IsEnemyVisible");
    /// </example>
    public readonly struct WorldStateKey : IEquatable<WorldStateKey>
    {
        private readonly int hash;

        public readonly string Name;

        public WorldStateKey(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("WorldStateKey name cannot be null or empty.", nameof(name));

            Name = name;
            hash = name.GetHashCode(StringComparison.Ordinal);
        }

        public bool Equals(WorldStateKey other)
        {
            // Compare hash first (cheap), then name (safe against collisions)
            return hash == other.hash &&
                   string.Equals(Name, other.Name, StringComparison.Ordinal);
        }

        public override bool Equals(object obj) => obj is WorldStateKey other && Equals(other);
        public override int GetHashCode() => hash;
        public override string ToString() => Name;

        public static bool operator ==(WorldStateKey a, WorldStateKey b) => a.Equals(b);
        public static bool operator !=(WorldStateKey a, WorldStateKey b) => !a.Equals(b);
    }
}