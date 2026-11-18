using System;
using UnityEngine;

namespace LootSystem
{
    /// <summary>
    /// Concrete implementation of a LootReward.
    /// Drops a prefab as reward.
    /// </summary>
    [Serializable]
	public class PrefabReward : LootReward
	{
		public GameObject prefab;

		public override string DisplayName => prefab != null ? prefab.name : "(missing prefab)";

        public override bool IsValid => prefab != null;
    }
}