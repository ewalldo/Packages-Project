using System;
using UnityEngine;

namespace StatsSystem
{
	[Serializable]
	public struct SingleStatConfig
	{
		[SerializeField] private StatType statType;
		[SerializeField] private float baseValue;
		[SerializeField] private float minValue;
		[SerializeField] private float maxValue;

        public SingleStatConfig(StatType statType, float baseValue, float minValue, float maxValue)
        {
            this.statType = statType;
			this.baseValue = baseValue;
			this.minValue = minValue;
			this.maxValue = maxValue;
        }

		public readonly StatType Type => statType;
		public readonly float BaseValue => baseValue;
		public readonly float MinValue => minValue;
		public readonly float MaxValue => maxValue;

        public static string GetNameOfStatType => nameof(statType);
    }
}