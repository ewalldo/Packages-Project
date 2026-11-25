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
        /// <param name="random">The source for the random number generator, defaults to <see cref="UnityRandomProvider"/> when null</param>
        /// <returns>List of GameObjects containing the pulled items</returns>
        public override List<LootDrop> PullLoot(int numberOfPulls = 1, IRandomProvider random = null)
        {
            List<LootDrop> pulledLoot = new List<LootDrop>();
            List<int> hits;

            IRandomProvider rng = random ?? UnityRandomProvider.Shared;

            for (int pulls = 0; pulls < numberOfPulls; pulls++)
            {
                hits = SelectHits(lootPool, rng);

                foreach (int hit in hits)
                {
                    LootPoolItem pulledItem = lootPool[hit];
                    int amount = rng.NextInt(pulledItem.minCountItem, pulledItem.maxCountItem + 1);
                    pulledLoot.Add(new LootDrop(pulledItem.item, amount));
                }
            }

            return pulledLoot;
        }

        protected override List<int> SelectHits(List<LootPoolItem> lootItems, IRandomProvider random)
        {
            List<int> hits = new List<int>();

            float value = random.NextFloat();
            float curSum = 0;

            for (int i = 0; i < lootItems.Count; i++)
            {
                curSum += lootItems[i].weight;
                if (curSum >= value)
                {
                    hits.Add(i);
                    break;
                }
            }

            return hits;
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
