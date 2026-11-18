using System;
using UnityEngine;

namespace LootSystem
{
    /// <summary>
    /// Concrete implementation of a LootReward.
    /// Used for situations where currenct can be a reward from a loot pool
    /// </summary>
    [Serializable]
	public class CurrencyReward : LootReward
	{
        public string currencyId = "gold";
        [Min(0)] public int amount = 1;

        public override string DisplayName => $"{amount} {currencyId}";

        public override bool IsValid => !string.IsNullOrEmpty(currencyId);
    }
}