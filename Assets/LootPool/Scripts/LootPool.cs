using System.Collections.Generic;
using UnityEngine;

namespace LootSystem
{
    public abstract class LootPool : ScriptableObject
    {
        [SerializeField] protected List<LootItem> lootPool = new List<LootItem>();

        public IReadOnlyList<LootItem> LootPoolList => lootPool;

        public abstract List<GameObject> PullLoot(int numberOfPulls = 1);

        /// <summary>
        /// Pulls and spawn the loot from the loot pool
        /// </summary>
        /// <param name="spawnPosition">The central position where the loot will be spawned</param>
        /// <param name="offsetRange">The offset range from the <paramref name="spawnPosition"/> (calculated independent for each item)</param>
        /// <param name="numberOfPulls">How many times it should pull from the loot list</param>
        /// <param name="spawnParent">The transform parent for the spawned loot</param>
        public void SpawnDrop(Vector3 spawnPosition, Vector3 offsetRange, int numberOfPulls = 1, Transform spawnParent = null)
        {
            List<GameObject> pulledLoot = PullLoot(numberOfPulls);

            for (int i = 0; i < pulledLoot.Count; i++)
            {
                GameObject spawnedLoot = Instantiate(pulledLoot[i], spawnParent);
                spawnedLoot.transform.position = new Vector3(spawnPosition.x + Random.Range(-offsetRange.x, offsetRange.x), spawnPosition.y + Random.Range(-offsetRange.y, offsetRange.y), spawnPosition.z + Random.Range(-offsetRange.z, offsetRange.z));
                spawnedLoot.transform.rotation = Quaternion.identity;
            }
        }

        /// <summary>
        /// Pulls and spawn the loot from the loot pool
        /// </summary>
        /// <param name="spawnPosition">The central position where the loot will be spawned</param>
        /// <param name="offsetRange">The offset range from the <paramref name="spawnPosition"/> (calculated independent for each item)</param>
        /// <param name="numberOfPulls">How many times it should pull from the loot list</param>
        /// <param name="spawnParent">The transform parent for the spawned loot</param>
        public void SpawnDrop(Vector3 spawnPosition, float offsetRange, int numberOfPulls = 1, Transform spawnParent = null)
        {
            SpawnDrop(spawnPosition, new Vector3(offsetRange, offsetRange, offsetRange), numberOfPulls, spawnParent);
        }

        /// <summary>
        /// Pulls and spawn the loot from the loot pool
        /// </summary>
        /// <param name="spawnPosition">The central position where the loot will be spawned</param>
        /// <param name="numberOfPulls">How many times it should pull from the loot list</param>
        /// <param name="spawnParent">The transform parent for the spawned loot</param>
        public void SpawnDrop(Vector3 spawnPosition, int numberOfPulls = 1, Transform spawnParent = null)
        {
            SpawnDrop(spawnPosition, Vector3.zero, numberOfPulls, spawnParent);
        }

        private void OnValidate()
        {
            ValidateMinMax(lootPool);
        }

        /// <summary>
        /// Validate changes on the min/max of each item (number can't be negative and min can be larger than max)
        /// </summary>
        /// <param name="lootItems">The list of pool items to validate</param>
        private void ValidateMinMax(List<LootItem> lootItems)
        {
            foreach (LootItem item in lootItems)
            {
                if (item.minCountItem < 0)
                    item.minCountItem = 0;
                if (item.maxCountItem < 0)
                    item.maxCountItem = 0;

                if (item.minCountItem > item.maxCountItem)
                {
                    item.maxCountItem = item.minCountItem;
                }
            }
        }

        public static string GetNameOfLootPool => nameof(lootPool);
    }
}
