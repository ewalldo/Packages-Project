using UnityEngine;

namespace IndicatorSystem
{
	[System.Serializable]
	public class IndicatorFader
	{
        [SerializeField] private bool fadeWithRange;
        [SerializeField] private float minAlphaDistance = 0f;
        [SerializeField] private float maxAlphaDistance = 100f;
        [SerializeField] private float alphaAtMinDistance = 0f;
        [SerializeField] private float alphaAtMaxDistance = 1f;

        /// <summary>
        /// Whether the indicator fades with distance.
        /// </summary>
        public bool FadeWithRange
        {
            get { return fadeWithRange; }
            set { fadeWithRange = value; }
        }

        /// <summary>
        /// Gets or sets the minimum distance at which the indicator alpha will be at the lowest value.
        /// </summary>
        public float MinAlphaDistance
        {
            get { return minAlphaDistance; }
            set { minAlphaDistance = Mathf.Max(0, value); }
        }

        /// <summary>
        /// Gets or sets the maximum distance at which the indicator alpha will be at the highest value.
        /// </summary>
        public float MaxAlphaDistance
        {
            get { return maxAlphaDistance; }
            set { maxAlphaDistance = Mathf.Max(0, value); }
        }

        /// <summary>
        /// Gets or sets the alpha value at the minimum distance or lower.
        /// </summary>
        public float AlphaAtMinDistance
        {
            get { return alphaAtMinDistance; }
            set { alphaAtMinDistance = Mathf.Clamp01(value); }
        }

        /// <summary>
        /// Gets or sets the alpha value at the maximum distance or higher.
        /// </summary>
        public float AlphaAtMaxDistance
        {
            get { return alphaAtMaxDistance; }
            set { alphaAtMaxDistance = Mathf.Clamp01(value); }
        }

        public IndicatorFader()
        {
            fadeWithRange = false;
            minAlphaDistance = 0f;
            maxAlphaDistance = 100f;
            alphaAtMinDistance = 0f;
            alphaAtMaxDistance = 1f;
        }

        /// <summary>
        /// Calculates the alpha value based on the given distance.
        /// </summary>
        /// <param name="distance">The distance to the target.</param>
        /// <returns>The calculated alpha value.</returns>
        public float CalculateAlpha(float distance)
        {
            if (distance <= MinAlphaDistance)
                return AlphaAtMinDistance;

            if (distance >= MaxAlphaDistance)
                return AlphaAtMaxDistance;

            float proportion = (distance - MinAlphaDistance) / (MaxAlphaDistance - MinAlphaDistance);

            return Mathf.Lerp(AlphaAtMinDistance, AlphaAtMaxDistance, proportion);
        }

        public static string GetNameOfFadeWithRange => nameof(fadeWithRange);
        public static string GetNameOfMinAlphaDistance => nameof(minAlphaDistance);
        public static string GetNameOfMaxAlphaDistance => nameof(maxAlphaDistance);
        public static string GetNameOfAlphaAtMinDistance => nameof(alphaAtMinDistance);
        public static string GetNameOfAlphaAtMaxDistance => nameof(alphaAtMaxDistance);
    }
}