using System;

namespace LootSystem
{
    /// <summary>
    /// Deterministic provider backed by <see cref="System.Random"/>.
    /// The same seed always produces the same sequence of pulls.
    /// </summary>
	public class SeededRandomProvider : IRandomProvider
	{
        private readonly Random random;

        public SeededRandomProvider(int seed)
        {
            random = new Random(seed);
        }

        public float NextFloat() => (float)random.NextDouble();

        public float NextFloat(float minInclusive, float maxInclusive) => NextFloat() * (maxInclusive - minInclusive) + minInclusive;

        public int NextInt(int minInclusive, int maxExclusive)
        {
            if (maxExclusive <= minInclusive)
                return minInclusive;

            return random.Next(minInclusive, maxExclusive);
        }
    }
}