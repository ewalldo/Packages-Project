namespace LootSystem
{
	public interface IRandomProvider
	{
        /// <summary>
        /// Returns a random float value in the range [0, 1).
        /// </summary>
        /// <returns>Float in the range [0, 1)</returns>
        float NextFloat();

        /// <summary>
        /// Returns a random float value in the range [minInclusive, maxInclusive].
        /// </summary>
        /// <param name="minInclusive">Minimun value of the range (inclusive)</param>
        /// <param name="maxInclusive">Maximum value of the range (inclusive)</param>
        /// <returns></returns>
        float NextFloat(float minInclusive, float maxInclusive);

        /// <summary>
        /// Returns a random int value in the range [minInclusive, maxExclusive).
        /// </summary>
        /// <param name="minInclusive">Minimun value of the range (inclusive)</param>
        /// <param name="maxExclusive">Maximum value of the range (exclusive)</param>
        /// <returns>Int value in the range [minInclusive, maxExclusive)</returns>
        int NextInt(int minInclusive, int maxExclusive);
    }
}