using System.Collections.Generic;
using UnityEngine;

namespace LootSystem
{
    [CreateAssetMenu(fileName = "Loot Pool", menuName = "Scriptable Objects/Loot Pool")]
    public class LootPool : ScriptableObject
    {
        public List<LootItem> independentLootPool = new List<LootItem>();
        public List<LootItem> dependentLootPool = new List<LootItem>();

        /// <summary>
        /// Pull loot from a list in an independent way (each item in the list has its own chance of being pulled)
        /// </summary>
        /// <param name="lootItems">The independent list to pull items from</param>
        /// <param name="independentPulls">How many times it should pull from the list</param>
        /// <returns>List of GameObjects containing the pulled items</returns>
        public static List<GameObject> PullIndependentLoot(List<LootItem> lootItems, int independentPulls)
        {
            List<GameObject> lootList = new List<GameObject>();

            for (int pulls = 0; pulls < independentPulls; pulls++)
            {
                for (int i = 0; i < lootItems.Count; i++)
                {
                    float value = Random.Range(0f, 1f);

                    if (value <= lootItems[i].weight)
                    {
                        int count = Random.Range(lootItems[i].minCountItem, lootItems[i].maxCountItem + 1);
                        for (int j = 0; j < count; j++)
                        {
                            if (lootItems[i].item != null)
                                lootList.Add(lootItems[i].item);
                        }
                    }
                }
            }

            return lootList;
        }

        /// <summary>
        /// Pull loot from the independent list
        /// </summary>
        /// <param name="independentPulls">How many times it should pull from the list</param>
        /// <returns>List of GameObjects containing the pulled items</returns>
        public List<GameObject> PullIndependentLoot(int independentPulls)
        {
            return PullIndependentLoot(independentLootPool, independentPulls);
        }

        /// <summary>
        /// Pull loot from a list in a dependent way (the chance of a item being pulled depends on the other items in the list)
        /// </summary>
        /// <param name="lootItems">The dependent list to pull items from</param>
        /// <param name="dependentPulls">How many times it should pull from the list</param>
        /// <returns>List of GameObjects containing the pulled items</returns>
        public static List<GameObject> PullDependentLoot(List<LootItem> lootItems, int dependentPulls)
        {
            List<GameObject> lootList = new List<GameObject>();

            for (int pulls = 0; pulls < dependentPulls; pulls++)
            {
                float value = Random.Range(0f, 1f);
                float curSum = 0;

                for (int i = 0; i < lootItems.Count; i++)
                {
                    curSum += lootItems[i].weight;
                    if (curSum >= value)
                    {
                        int count = Random.Range(lootItems[i].minCountItem, lootItems[i].maxCountItem + 1);
                        for (int j = 0; j < count; j++)
                        {
                            if (lootItems[i].item != null)
                                lootList.Add(lootItems[i].item);
                        }
                        break;
                    }
                }
            }

            return lootList;
        }

        /// <summary>
        /// Pull loot from the dependent list
        /// </summary>
        /// <param name="dependentPulls">How many times it should pull from the list</param>
        /// <returns>List of GameObjects containing the pulled items</returns>
        public List<GameObject> PullDependentLoot(int dependentPulls)
        {
            return PullDependentLoot(dependentLootPool, dependentPulls);
        }

        /// <summary>
        /// Pull loot from the loot pool
        /// </summary>
        /// <param name="independentPulls">How many times it should pull from the independent list</param>
        /// <param name="dependentPulls">How many times it should pull from the dependent list</param>
        /// <returns></returns>
        public List<GameObject> PullLoot(int independentPulls, int dependentPulls)
        {
            List<GameObject> pulledLoot = PullIndependentLoot(independentPulls);
            pulledLoot.AddRange(PullDependentLoot(dependentPulls));

            return pulledLoot;
        }

        /// <summary>
        /// Spawn the loot pulled from the loot pool
        /// </summary>
        /// <param name="spawnPosition">The central position where the loot will be spawned</param>
        /// <param name="offsetRange">The offset range from the <paramref name="spawnPosition"/> (calculated independent for each item)</param>
        /// <param name="independentPulls">How many times it should pull from the independent list</param>
        /// <param name="dependentPulls">How many times it should pull from the dependent list</param>
        public void SpawnDrop(Transform spawnPosition, Vector3 offsetRange, int independentPulls = 1, int dependentPulls = 1)
        {
            List<GameObject> pulledLoot = PullLoot(independentPulls, dependentPulls);

            for (int i = 0; i < pulledLoot.Count; i++)
            {
                Instantiate(pulledLoot[i], new Vector3(spawnPosition.position.x + Random.Range(-offsetRange.x, offsetRange.x), spawnPosition.position.y + Random.Range(-offsetRange.y, offsetRange.y), spawnPosition.position.z + Random.Range(-offsetRange.z, offsetRange.z)), Quaternion.identity);
            }
        }

        /// <summary>
        /// Spawn the loot pulled from the loot pool
        /// </summary>
        /// <param name="spawnPosition">The central position where the loot will be spawned</param>
        /// <param name="offsetRange">The offset range from the <paramref name="spawnPosition"/> (calculated independent for each item)</param>
        /// <param name="independentPulls">How many times it should pull from the independent list</param>
        /// <param name="dependentPulls">How many times it should pull from the dependent list</param>
        public void SpawnDrop(Transform spawnPosition, float offsetRange, int independentPulls = 1, int dependentPulls = 1)
        {
            SpawnDrop(spawnPosition, new Vector3(offsetRange, offsetRange, offsetRange), independentPulls, dependentPulls);
        }

        /// <summary>
        /// Spawn the loot pulled from the loot pool
        /// </summary>
        /// <param name="spawnPosition">The central position where the loot will be spawned</param>
        /// <param name="independentPulls">How many times it should pull from the independent list</param>
        /// <param name="dependentPulls">How many times it should pull from the dependent list</param>
        public void SpawnDrop(Transform spawnPosition, int independentPulls = 1, int dependentPulls = 1)
        {
            SpawnDrop(spawnPosition, Vector3.zero, independentPulls, dependentPulls);
        }

        /// <summary>
        /// Spawn the loot pulled from a loot pool
        /// </summary>
        /// <param name="lootItems">The pool of items to pull from</param>
        /// <param name="spawnPosition">The central position where the loot will be spawned</param>
        /// <param name="offsetRange">The offset range from the <paramref name="spawnPosition"/> (calculated independent for each item)</param>
        /// <param name="numberPulls">How many times it should pull from the list</param>
        /// <param name="isIndependentLoot">True if the list composed of independent items, false otherwise</param>
        public static void SpawnDrop(List<LootItem> lootItems, Transform spawnPosition, Vector3 offsetRange, int numberPulls = 1, bool isIndependentLoot = true)
        {
            List<GameObject> pulledLoot;

            if (isIndependentLoot)
                pulledLoot = PullIndependentLoot(lootItems, numberPulls);
            else
                pulledLoot = PullDependentLoot(lootItems, numberPulls);

            for (int i = 0; i < pulledLoot.Count; i++)
            {
                Instantiate(pulledLoot[i], new Vector3(spawnPosition.position.x + Random.Range(-offsetRange.x, offsetRange.x), spawnPosition.position.y + Random.Range(-offsetRange.y, offsetRange.y), spawnPosition.position.z + Random.Range(-offsetRange.z, offsetRange.z)), Quaternion.identity);
            }
        }

        /// <summary>
        /// Spawn the loot pulled from a loot pool
        /// </summary>
        /// <param name="lootItems">The pool of items to pull from</param>
        /// <param name="spawnPosition">The central position where the loot will be spawned</param>
        /// <param name="offsetRange">The offset range from the <paramref name="spawnPosition"/> (calculated independent for each item)</param>
        /// <param name="numberPulls">How many times it should pull from the list</param>
        /// <param name="isIndependentLoot">True if the list composed of independent items, false otherwise</param>
        public static void SpawnDrop(List<LootItem> lootItems, Transform spawnPosition, float offsetRange, int numberPulls = 1, bool isIndependentLoot = true)
        {
            SpawnDrop(lootItems, spawnPosition, new Vector3(offsetRange, offsetRange, offsetRange), numberPulls, isIndependentLoot);
        }

        /// <summary>
        /// Spawn the loot pulled from a loot pool
        /// </summary>
        /// <param name="lootItems">The pool of items to pull from</param>
        /// <param name="spawnPosition">The central position where the loot will be spawned</param>
        /// <param name="numberPulls">How many times it should pull from the list</param>
        /// <param name="isIndependentLoot">True if the list composed of independent items, false otherwise</param>
        public static void SpawnDrop(List<LootItem> lootItems, Transform spawnPosition, int numberPulls = 1, bool isIndependentLoot = true)
        {
            SpawnDrop(lootItems, spawnPosition, Vector3.zero, numberPulls, isIndependentLoot);
        }

        private void OnValidate()
        {
            ValidateMinMax(independentLootPool);
            ValidateMinMax(dependentLootPool);
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

        /// <summary>
        /// Validate the weights of the dependent pool list
        /// </summary>
        /// <param name="changedIndex">The index of the item which had the weight changed</param>
        /// <param name="newWeight">The new weight value of the item</param>
        public void ValidateWeights(int changedIndex, float newWeight)
        {
            float maxAllowed = CalculateMaxAllowed(changedIndex);

            dependentLootPool[changedIndex].weight = newWeight;

            if (newWeight > maxAllowed)
            {
                float diff = newWeight - maxAllowed;
                AdjustOtherWeights(changedIndex, diff);
            }
        }

        /// <summary>
        /// Calculate the max value which a weight should be allowed to change
        /// </summary>
        /// <param name="changedIndex">The index of the item which had the weight changed</param>
        /// <returns>The max allowed value for the weight in the <paramref name="changedIndex"/> index</returns>
        private float CalculateMaxAllowed(int changedIndex)
        {
            float maxAllowed = 1f;

            for (int i = 0; i < dependentLootPool.Count; i++)
            {
                if (changedIndex == i)
                    continue;

                maxAllowed -= dependentLootPool[i].weight;
            }

            return maxAllowed;
        }

        /// <summary>
        /// Adjust the weight of the other indexes in the dependent list
        /// </summary>
        /// <param name="changedIndex">The index of the item which had the weight changed</param>
        /// <param name="amountToSubtract">The total amount which the other weights has to be adjusted</param>
        private void AdjustOtherWeights(int changedIndex, float amountToSubtract)
        {
            float amountForEach = amountToSubtract / ValidIndexCount(changedIndex);
            float remmaining = 0f;

            for (int i = 0; i < dependentLootPool.Count; i++)
            {
                if (changedIndex == i || dependentLootPool[i].weight <= 0f)
                    continue;

                dependentLootPool[i].weight -= amountForEach;

                if (dependentLootPool[i].weight < 0f)
                {
                    remmaining += Mathf.Abs(dependentLootPool[i].weight);
                    dependentLootPool[i].weight = 0f;
                }
            }

            if (remmaining > 0f)
                AdjustOtherWeights(changedIndex, remmaining);
        }

        /// <summary>
        /// Calculate how many items in the dependent list can have their weight changed
        /// </summary>
        /// <param name="changedIndex">The index of the item which had the weight changed</param>
        /// <returns>The number of the items which can have their weight changed</returns>
        private int ValidIndexCount(int changedIndex)
        {
            int count = 0;

            for (int i = 0; i < dependentLootPool.Count; i++)
            {
                if (changedIndex == i || dependentLootPool[i].weight <= 0f)
                    continue;

                count++;
            }

            return count;
        }
    }
}
