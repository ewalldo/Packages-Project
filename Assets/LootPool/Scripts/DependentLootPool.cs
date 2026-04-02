using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LootSystem
{
    [CreateAssetMenu(fileName = "DependentLootPool", menuName = "Scriptable Objects/Loot System/Dependent Loot Pool")]
    public class DependentLootPool : LootPool
    {
        /// <summary>
        /// Pull loot from the dependent list
        /// </summary>
        /// <param name="numberOfPulls">How many times it should pull from the list</param>
        /// <returns>List of GameObjects containing the pulled items</returns>
        public override List<GameObject> PullLoot(int numberOfPulls = 1)
        {
            return PullLoot(lootPool, numberOfPulls);
        }

        /// <summary>
        /// Pull loot from a list in a dependent way (the chance of a item being pulled depends on the other items in the list)
        /// </summary>
        /// <param name="lootItems">The dependent list to pull items from</param>
        /// <param name="numberOfPulls">How many times it should pull from the list</param>
        /// <returns>List of GameObjects containing the pulled items</returns>
        public static List<GameObject> PullLoot(List<LootItem> lootItems, int numberOfPulls)
        {
            List<GameObject> lootList = new List<GameObject>();

            for (int pulls = 0; pulls < numberOfPulls; pulls++)
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
        /// Validate the weights of the dependent pool list
        /// </summary>
        /// <param name="changedIndex">The index of the item which had the weight changed</param>
        /// <param name="newWeight">The new weight value of the item</param>
        public void ValidateWeights(int changedIndex, float newWeight)
        {
            float maxAllowed = CalculateMaxAllowed(changedIndex);

            lootPool[changedIndex].weight = newWeight;

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

            for (int i = 0; i < lootPool.Count; i++)
            {
                if (changedIndex == i)
                    continue;

                maxAllowed -= lootPool[i].weight;
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

            for (int i = 0; i < lootPool.Count; i++)
            {
                if (changedIndex == i || lootPool[i].weight <= 0f)
                    continue;

                lootPool[i].weight -= amountForEach;

                if (lootPool[i].weight < 0f)
                {
                    remmaining += Mathf.Abs(lootPool[i].weight);
                    lootPool[i].weight = 0f;
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

            for (int i = 0; i < lootPool.Count; i++)
            {
                if (changedIndex == i || lootPool[i].weight <= 0f)
                    continue;

                count++;
            }

            return count;
        }
    }
}
