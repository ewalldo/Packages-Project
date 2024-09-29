using UnityEngine;

namespace IndicatorSystem
{
	public class UIRadialIndicator : UIIndicator
	{
        [Header("Radial parameters")]
        [SerializeField] private float diameterLength = 500f;

        /// <summary>
        /// Gets the diameter of the radial indicator
        /// </summary>
        public float DiameterLength => diameterLength;

        public static string GetNameOfDiameterLength => nameof(diameterLength);
    }
}