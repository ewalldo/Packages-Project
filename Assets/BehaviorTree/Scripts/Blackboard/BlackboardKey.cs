using System;

namespace BehaviorTree
{
    public readonly struct BlackboardKey : IEquatable<BlackboardKey>
    {
        /// <summary>The key's name</summary>
        public string Name { get; }

        private readonly int hash;

        /// <summary>Creates a key with the given name</summary>
        /// <param name="name">The key's name. Must not be null</param>
        public BlackboardKey(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            hash = name.GetHashCode();
        }

        public bool Equals(BlackboardKey other) => hash == other.hash && Name == other.Name;

        public override bool Equals(object obj) => obj is BlackboardKey other && Equals(other);

        public override int GetHashCode() => hash;

        public override string ToString() => Name;

        /// <summary>Implicitly wraps a string as a key</summary>
        /// <param name="name">The key's name. Must not be null.</param>
        public static implicit operator BlackboardKey(string name) => new BlackboardKey(name);
    }
}