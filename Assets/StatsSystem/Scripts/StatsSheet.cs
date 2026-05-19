using System;
using System.Collections.Generic;
using UnityEngine;

namespace StatsSystem
{
	[Serializable]
	public class StatsSheet
	{
        [SerializeField] private StatTypeSet statTypeSet;
        // Per-StatType override: If a StatType is listed here, it will uses it's values instead for initialization instead of the StatSheet defauls
        [SerializeField] private SingleStatConfig[] statsOverrides;
        [SerializeField] private float defaultBaseValue = 1f;
        [SerializeField] private float defaultMinValue = 1f;
        [SerializeField] private float defaultMaxValue = 100f;

        private Dictionary<StatType, SingleStat> stats = new Dictionary<StatType, SingleStat>();
        private bool isInitialized = false;

        /// <summary>
        /// Invoked when the value of the stat has changed (stattype, base value, final value)
        /// </summary>
        public event Action<StatType, float, float> OnStatChanged;

        public StatsSheet() {}

        /// <summary>
        /// Creates a new instance of the StatsSheet class
        /// </summary>
        /// <param name="statTypeSet">The StatsTypeSet which contains the StatType to be created</param>
        /// <param name="defaultBaseValue">The base value for all stats in the set</param>
        /// <param name="defaultMinValue">The minimum value for all stats</param>
        /// <param name="defaultMaxValue">The maximum value for all stats</param>
        /// <param name="statsOverride">Overrides for each individual StatType</param>
        public StatsSheet(StatTypeSet statTypeSet, float defaultBaseValue, float defaultMinValue, float defaultMaxValue, SingleStatConfig[] statsOverride = null)
        {
            this.statTypeSet = statTypeSet;
            this.defaultBaseValue = defaultBaseValue;
            this.defaultMinValue = defaultMinValue;
            this.defaultMaxValue = defaultMaxValue;
            this.statsOverrides = statsOverride ?? Array.Empty<SingleStatConfig>();

            Initialize();
        }

        /// <summary>
        /// Initialize the individual stats of this StatsSheet
        /// </summary>
        public void Initialize()
        {
            if (isInitialized)
            {
                Debug.LogWarning("[StatsSheet] Already initialized");
                return;
            }

            if (statTypeSet == null)
            {
                Debug.LogError("[StatsSheet] No StatTypeSet assigned");
                return;
            }

            stats = new Dictionary<StatType, SingleStat>();

            Dictionary<StatType, SingleStatConfig> overrideLookup = new Dictionary<StatType, SingleStatConfig>();
            foreach (SingleStatConfig config in statsOverrides)
            {
                if (config.Type != null)
                    overrideLookup[config.Type] = config;
            }

            foreach (StatType statType in statTypeSet.GetStatTypeSet)
            {
                SingleStat stat;

                if (overrideLookup.TryGetValue(statType, out SingleStatConfig overrideConfig))
                    stat = new SingleStat(statType, overrideConfig.BaseValue, overrideConfig.MinValue, overrideConfig.MaxValue);
                else
                    stat = new SingleStat(statType, defaultBaseValue, defaultMinValue, defaultMaxValue);

                stat.OnModifierListModified += (baseValue, finalValue) => OnStatChanged?.Invoke(statType, baseValue, finalValue);
                stat.OnSingleStatBaseValueChange += (baseValue, finalValue) => OnStatChanged?.Invoke(statType, baseValue, finalValue);

                stats[statType] = stat;
            }

            isInitialized = true;
        }

        /// <summary>
        /// Returns the SingleStat for the given type
        /// </summary>
        /// <param name="statType">The StatType to get the SingleStat from</param>
        /// <returns>The corresponding SingleStat, or null if not found</returns>
        public SingleStat GetStat(StatType statType)
        {
            AssertInitialized();

            if (stats.ContainsKey(statType))
                return stats[statType];

            Debug.LogWarning($"[StatsSheet] does not contain stat: {statType.GetStatName}");
            return null;
        }

        /// <summary>
        /// Returns the base value of a stat
        /// </summary>
        /// <param name="statType">The StatType to get the base value from</param>
        /// <returns>The base value of the stat</returns>
        public float GetBaseValue(StatType statType) => GetStat(statType)?.StatBaseValue ?? 0f;

        /// <summary>
        /// Returns the final calculated value of a stat
        /// </summary>
        /// <param name="statType">The StatType to get the final value from</param>
        /// <returns>Value of the stat after applying all modifiers</returns>
        public float GetFinalValue(StatType statType) => GetStat(statType)?.GetFinalValue() ?? 0f;

        /// <summary>
        /// Add a modifier to a specific stat
        /// </summary>
        /// <param name="statsModifier">The modifier to be added</param>
        public void AddModifier(StatsModifier statsModifier) => GetStat(statsModifier.StatTypeTarget)?.AddModifier(statsModifier);

        /// <summary>
        /// Remove a specific modifier from a stat
        /// </summary>
        /// <param name="statsModifier">The modifier to be removed</param>
        /// <returns>True if the modifier was removed successufully, false otherwise</returns>
        public bool RemoveModifier(StatsModifier statsModifier) => GetStat(statsModifier.StatTypeTarget)?.RemoveModifier(statsModifier) ?? false;

        /// <summary>
        /// Remove all modifiers from a specific source
        /// </summary>
        /// <param name="source">The source of the modifiers to be removed</param>
        /// <returns>True if at least one modifier was removed, false otherwise</returns>
        public bool RemoveAllModifiersBySource(UnityEngine.Object source)
        {
            AssertInitialized();

            bool anyRemoved = false;
            foreach (SingleStat stat in stats.Values)
                anyRemoved |= stat.RemoveModifiersBySource(source);

            return anyRemoved;
        }

        private void AssertInitialized()
        {
            if (!isInitialized)
                throw new InvalidOperationException("[StatsSheet] not initialized. Call Initialize() before use");
        }

        public static string GetNameOfStatTypeSet => nameof(statTypeSet);
        public static string GetNameOfStatsOverrides => nameof(statsOverrides);
    }
}