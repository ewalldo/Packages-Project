using System.Collections.Generic;
using UnityEngine;

namespace LootSystem
{
    public abstract class LootPool : ScriptableObject
    {
        [SerializeField] protected List<LootPoolItem> lootPool = new List<LootPoolItem>();

        public IReadOnlyList<LootPoolItem> LootPoolList => lootPool;

        public abstract List<LootDrop> PullLoot(int numberOfPulls = 1);

        /// <summary>
        /// Pulls and spawn the loot from the loot pool
        /// </summary>
        /// <param name="spawnPosition">The central position where the loot will be spawned</param>
        /// <param name="offsetRange">The offset range from the <paramref name="spawnPosition"/> (calculated independent for each item)</param>
        /// <param name="numberOfPulls">How many times it should pull from the loot list</param>
        /// <param name="spawnParent">The transform parent for the spawned loot</param>
        public void SpawnDrop(Vector3 spawnPosition, Vector3 offsetRange, int numberOfPulls = 1, Transform spawnParent = null)
        {
            List<LootDrop> pulledLoot = PullLoot(numberOfPulls);

            foreach (LootDrop drop in pulledLoot)
            {
                for (int i = 0; i < drop.Amount; i++)
                {
                    GameObject spawnedLoot = Instantiate(drop.Reward, spawnParent);
                    spawnedLoot.transform.position = new Vector3(
                        spawnPosition.x + Random.Range(-offsetRange.x, offsetRange.x),
                        spawnPosition.y + Random.Range(-offsetRange.y, offsetRange.y),
                        spawnPosition.z + Random.Range(-offsetRange.z, offsetRange.z));
                    spawnedLoot.transform.rotation = Quaternion.identity;
                }
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
        private void ValidateMinMax(List<LootPoolItem> lootItems)
        {
            foreach (LootPoolItem item in lootItems)
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

        /// <summary>
        /// Selects the item indices that dropped for a single pull
        /// </summary>
        /// <returns>List containing the selected item indices</returns>
        protected abstract List<int> SelectHits(List<LootPoolItem> lootItems);

        public static string GetNameOfLootPool => nameof(lootPool);
    }
}
