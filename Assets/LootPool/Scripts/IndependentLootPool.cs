using System.Collections.Generic;
using UnityEngine;

namespace LootSystem
{
    [CreateAssetMenu(fileName = "IndependentLootPool", menuName = "Scriptable Objects/Loot System/Independent Loot Pool")]
    public class IndependentLootPool : LootPool
    {
        /// <summary>
        /// Pull loot from the independent list
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

                foreach(int hit in hits)
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

            for (int i = 0; i < lootItems.Count; i++)
            {
                float value = random.NextFloat();

                if (value <= lootItems[i].weight)
                    hits.Add(i);
            }

            return hits;
        }
    }
}
