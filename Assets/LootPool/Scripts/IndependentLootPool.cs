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
        /// <returns>List of GameObjects containing the pulled items</returns>
        public override List<LootDrop> PullLoot(int numberOfPulls = 1)
        {
            List<LootDrop> pulledLoot = new List<LootDrop>();
            List<int> hits;

            for (int pulls = 0; pulls < numberOfPulls; pulls++)
            {
                hits = SelectHits(lootPool);

                foreach(int hit in hits)
                {
                    LootPoolItem pulledItem = lootPool[hit];
                    int amount = Random.Range(pulledItem.minCountItem, pulledItem.maxCountItem + 1);
                    pulledLoot.Add(new LootDrop(pulledItem.item, amount));
                }
            }

            return pulledLoot;
        }

        protected override List<int> SelectHits(List<LootPoolItem> lootItems)
        {
            List<int> hits = new List<int>();

            for (int i = 0; i < lootItems.Count; i++)
            {
                float value = Random.Range(0f, 1f);

                if (value <= lootItems[i].weight)
                    hits.Add(i);
            }

            return hits;
        }
    }
}
