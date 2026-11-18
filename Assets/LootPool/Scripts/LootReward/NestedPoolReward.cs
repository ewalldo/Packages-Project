using System;
using UnityEngine;

namespace LootSystem
{
    /// <summary>
    /// Concrete implementation of a LootReward.
    /// Pulls from another loot pool, enabling composable/hierarchical loot tables.
    /// </summary>
    [Serializable]
    public class NestedPoolReward : LootReward
    {
        public LootPool pool;
        [Min(1)] public int pulls = 1;

        public override string DisplayName => pool != null ? $"{pool.name} (nested)" : "(missing pool)";

        public override bool IsValid => pool != null;
    }
}