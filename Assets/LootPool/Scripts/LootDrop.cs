using UnityEngine;

namespace LootSystem
{
	public readonly struct LootDrop
	{
		public readonly GameObject Reward;

		public readonly int Amount;

        public LootDrop(GameObject reward, int amount)
        {
            Reward = reward;
            Amount = amount;
        }
    }
}