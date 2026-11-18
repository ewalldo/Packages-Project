using UnityEngine;

namespace LootSystem
{
    /// <summary>
    /// Class to hold reference to one entry in the LootPool.
    /// It contains information about their drop chance, the specific reward, and how many of the reward the pool should give if selected
    /// </summary>
    [System.Serializable]
    public class LootPoolItem
    {
        /// <summary>
        /// The chance of this item being pulled from the pool
        /// </summary>
        [Range(0f, 1f)] public float weight;
        /// <summary>
        /// The GameObject representing this item
        /// </summary>
        public GameObject item;
        /// <summary>
        /// The minimum amount of copies it should reward when pulled from the pool
        /// </summary>
        public int minCountItem;
        /// <summary>
        /// The maximum amount of copies it should reward when pulled from the pool
        /// </summary>
        public int maxCountItem;

        /// <summary>
        /// Instantiate a new loot item with the default values
        /// </summary>
        public LootPoolItem()
            : this(0, null, 1, 1) { }

        /// <summary>
        /// Instantiate a new loot item
        /// </summary>
        /// <param name="weight">The chance of this item being pulled from the pool</param>
        /// <param name="item">The GameObject representing this item</param>
        /// <param name="minCountItem">The minimum amount of copies it should reward when pulled from the pool</param>
        /// <param name="maxCountItem">The maximum amount of copies it should reward when pulled from the pool</param>
        public LootPoolItem(float weight, GameObject item, int minCountItem, int maxCountItem)
        {
            this.weight = Mathf.Clamp01(weight);
            this.item = item;
            this.minCountItem = minCountItem >= 0 ? minCountItem : 0;
            this.maxCountItem = maxCountItem >= 0 ? maxCountItem : 0;

            if (this.minCountItem > this.maxCountItem)
            {
                this.maxCountItem = this.minCountItem;
            }
        }
    }
}
