using System;
using UnityEngine;

namespace StatsSystem
{
	public class StatsSheetComponent : MonoBehaviour
	{
        [SerializeField] private StatsSheet statsSheet;

        public StatsSheet GetStatsSheet => statsSheet;

        /// <summary>
        /// Invoked when the value of the stat has changed (stattype, base value, final value)
        /// </summary>
        public event Action<StatType, float, float> OnStatChanged
        {
            add => statsSheet.OnStatChanged += value;
            remove => statsSheet.OnStatChanged -= value;
        }

        private void Awake()
        {
            statsSheet.Initialize();
        }

        /// <summary>
        /// Returns the SingleStat for the given type
        /// </summary>
        /// <param name="statType">The StatType to get the SingleStat from</param>
        /// <returns>The corresponding SingleStat, or null if not found</returns>
        public SingleStat GetStat(StatType statType) => statsSheet.GetStat(statType);

        /// <summary>
        /// Returns the base value of a stat
        /// </summary>
        /// <param name="statType">The StatType to get the base value from</param>
        /// <returns>The base value of the stat</returns>
        public float GetBaseValue(StatType statType) => statsSheet.GetBaseValue(statType);

        /// <summary>
        /// Returns the final calculated value of a stat
        /// </summary>
        /// <param name="statType">The StatType to get the final value from</param>
        /// <returns>Value of the stat after applying all modifiers</returns>
        public float GetFinalValue(StatType statType) => statsSheet.GetFinalValue(statType);

        /// <summary>
        /// Add a modifier to a specific stat
        /// </summary>
        /// <param name="statsModifier">The modifier to be added</param>
        public void AddModifier(StatsModifier statsModifier) => statsSheet.AddModifier(statsModifier);

        /// <summary>
        /// Remove a specific modifier from a stat
        /// </summary>
        /// <param name="statsModifier">The modifier to be removed</param>
        /// <returns>True if the modifier was removed successufully, false otherwise</returns>
        public bool RemoveModifier(StatsModifier statsModifier) => statsSheet.RemoveModifier(statsModifier);

        /// <summary>
        /// Remove all modifiers from a specific source
        /// </summary>
        /// <param name="source">The source of the modifiers to be removed</param>
        /// <returns>True if at least one modifier was removed, false otherwise</returns>
        public bool RemoveAllModifiersBySource(UnityEngine.Object source) => statsSheet.RemoveAllModifiersBySource(source);

        public static string GetNameOfStatsSheet => nameof(statsSheet);
    }
}