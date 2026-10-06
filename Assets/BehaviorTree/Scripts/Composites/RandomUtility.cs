using System;
using System.Collections.Generic;

namespace BehaviorTree
{
    /// <summary>Shuffling helper shared by composite nodes that requires randomness</summary>
    internal static class RandomUtility
    {
        /// <summary>Single RNG instance shared by every random composite, rather than one per node instance.</summary>
        private static readonly Random Rng = new Random();

        /// <summary>Shuffles a list in place using Fisher-Yates</summary>
        /// <typeparam name="T">The list's element type.</typeparam>
        /// <param name="list">The list to shuffle in place.</param>
        internal static void Shuffle<T>(IList<T> list)
        {
            for (var i = list.Count - 1; i > 0; i--)
            {
                var j = Rng.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}