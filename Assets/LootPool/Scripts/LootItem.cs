using UnityEngine;

namespace LootSystem
{
    [System.Serializable]
    public class LootItem
    {
        /// <summary>
        /// The chance of this item being pulled from the pool
        /// </summary>
        public float weight;
        /// <summary>
        /// The GameObject representing this item
        /// </summary>
        public GameObject item;
        /// <summary>
        /// The minimum amount it should instantiate when pulled from the pool
        /// </summary>
        public int minCountItem;
        /// <summary>
        /// The maximum amount it should instantiate when pulled from the pool
        /// </summary>
        public int maxCountItem;

        /// <summary>
        /// Instantiate a new loot item with the default values
        /// </summary>
        public LootItem()
            : this(0, null, 1, 1) { }

        /// <summary>
        /// Instantiate a new loot item
        /// </summary>
        /// <param name="weight">The chance of this item being pulled from the pool</param>
        /// <param name="item">The GameObject representing this item</param>
        /// <param name="minCountItem">The minimum amount it should instantiate when pulled from the pool</param>
        /// <param name="maxCountItem">The maximum amount it should instantiate when pulled from the pool</param>
        public LootItem(float weight, GameObject item, int minCountItem, int maxCountItem)
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
