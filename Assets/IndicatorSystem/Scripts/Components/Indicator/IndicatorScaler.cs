using UnityEngine;

namespace IndicatorSystem
{
	[System.Serializable]
	public class IndicatorScaler
	{
        [SerializeField] private bool scaleWithRange;
        [SerializeField] private float minScaleDistance = 0f;
        [SerializeField] private float maxScaleDistance = 100f;
        [SerializeField] private float scaleAtMinDistance = 0f;
        [SerializeField] private float scaleAtMaxDistance = 1f;

        /// <summary>
        /// Whether the indicator scales with distance.
        /// </summary>
        public bool ScaleWithRange
        {
            get { return scaleWithRange; }
            set { scaleWithRange = value; }
        }

        /// <summary>
        /// Gets or sets the minimum distance at which the indicator scale will be at the lowest value.
        /// </summary>
        public float MinScaleDistance
        {
            get { return minScaleDistance; }
            set { minScaleDistance = Mathf.Max(0, value); }
        }

        /// <summary>
        /// Gets or sets the maximum distance at which the indicator scale will be at the highest value.
        /// </summary>
        public float MaxScaleDistance
        {
            get { return maxScaleDistance; }
            set { maxScaleDistance = Mathf.Max(0, value); }
        }

        /// <summary>
        /// Gets or sets the scale value at the minimum distance or lower.
        /// </summary>
        public float ScaleAtMinDistance
        {
            get { return scaleAtMinDistance; }
            set { scaleAtMinDistance = Mathf.Max(0, value); }
        }

        /// <summary>
        /// Gets or sets the scale value at the maximum distance or higher.
        /// </summary>
        public float ScaleAtMaxDistance
        {
            get { return scaleAtMaxDistance; }
            set { scaleAtMaxDistance = Mathf.Max(0, value); }
        }

        public IndicatorScaler()
        {
            scaleWithRange = false;
            minScaleDistance = 0f;
            maxScaleDistance = 100f;
            scaleAtMinDistance = 0f;
            scaleAtMaxDistance = 1f;
        }

        /// <summary>
        /// Calculates the scale value based on the given distance.
        /// </summary>
        /// <param name="distance">The distance to the target.</param>
        /// <returns>The calculated scale value.</returns>
        public float CalculateScale(float distance)
        {
            if (distance <= MinScaleDistance)
                return ScaleAtMinDistance;

            if (distance >= MaxScaleDistance)
                return ScaleAtMaxDistance;

            float proportion = (distance - MinScaleDistance) / (MaxScaleDistance - MinScaleDistance);

            return Mathf.Lerp(ScaleAtMinDistance, ScaleAtMaxDistance, proportion);
        }

        public static string GetNameOfScaleWithRange => nameof(scaleWithRange);
        public static string GetNameOfMinScaleDistance => nameof(minScaleDistance);
        public static string GetNameOfMaxScaleDistance => nameof(maxScaleDistance);
        public static string GetNameOfScaleAtMinDistance => nameof(scaleAtMinDistance);
        public static string GetNameOfScaleAtMaxDistance => nameof(scaleAtMaxDistance);
    }
}