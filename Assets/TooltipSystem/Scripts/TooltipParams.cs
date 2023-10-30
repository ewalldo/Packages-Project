using System.Collections.Generic;
using UnityEngine;

namespace TooltipSystem
{
	public class TooltipParams
	{
        /// <summary>
        /// The tooltip texts
        /// </summary>
        public Dictionary<string, string> TooltipTexts { get; private set; }
        /// <summary>
        /// The tooltip sprites
        /// </summary>
        public Dictionary<string, Sprite> TooltipSprites { get; private set; }
        /// <summary>
        /// The tooltip display position
        /// </summary>
        public TooltipPosition TooltipPosition { get; private set; }
        /// <summary>
        /// Transform the tooltip should be displayed at (if the TooltipPosition was set to transform)
        /// </summary>
        public Transform TooltipTransform { get; private set; }
        /// <summary>
        /// Vector3 the tooltip should be displayed at (if the TooltipPosition was set to vector3)
        /// </summary>
        public Vector3 TooltipVector { get; private set; }

        /// <summary>
        /// Instantiate a new instance of the TooltipParams class
        /// </summary>
        /// <param name="tooltipTexts">The tooltip texts</param>
        /// <param name="tooltipSprites">The tooltip sprites</param>
        /// <param name="tooltipPosition">The tooltip display position</param>
        /// <param name="tooltipTransform">Which transform the tooltip should be displayed at (if the TooltipPosition was set to transform)</param>
        /// <param name="tooltipVector">Which Vector3 the tooltip should be displayed at (if the TooltipPosition was set to vector3)</param>
        public TooltipParams(Dictionary<string, string> tooltipTexts, Dictionary<string, Sprite> tooltipSprites, TooltipPosition tooltipPosition, Transform tooltipTransform, Vector3 tooltipVector)
        {
            TooltipTexts = tooltipTexts;
            TooltipSprites = tooltipSprites;
            TooltipPosition = tooltipPosition;
            TooltipTransform = tooltipTransform;
            TooltipVector = tooltipVector;
        }
    }
}