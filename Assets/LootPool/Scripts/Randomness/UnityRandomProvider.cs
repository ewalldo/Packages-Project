using UnityEngine;

namespace LootSystem
{
    /// <summary>
    /// Default random provider backed by <see cref="Random"/>.
    /// </summary>
	public class UnityRandomProvider : IRandomProvider
	{
        public static readonly UnityRandomProvider Shared = new UnityRandomProvider();

        public float NextFloat() => Random.value;

        public float NextFloat(float minInclusive, float maxInclusive) => Random.Range(minInclusive, maxInclusive);

        public int NextInt(int minInclusive, int maxExclusive) => Random.Range(minInclusive, maxExclusive);
    }
}