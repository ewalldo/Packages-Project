using System.Collections;
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
        public override List<GameObject> PullLoot(int numberOfPulls = 1)
        {
            return PullLoot(lootPool, numberOfPulls);
        }

        /// <summary>
        /// Pull loot from a list in an independent way (each item in the list has its own chance of being pulled)
        /// </summary>
        /// <param name="lootItems">The independent list to pull items from</param>
        /// <param name="numberOfPulls">How many times it should pull from the list</param>
        /// <returns>List of GameObjects containing the pulled items</returns>
        public static List<GameObject> PullLoot(List<LootItem> lootItems, int numberOfPulls)
        {
            List<GameObject> lootList = new List<GameObject>();

            for (int pulls = 0; pulls < numberOfPulls; pulls++)
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
    }
}
