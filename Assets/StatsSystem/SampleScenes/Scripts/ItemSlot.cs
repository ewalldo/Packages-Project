using System;
using UnityEngine;

namespace StatsSystem
{
	public class ItemSlot : MonoBehaviour
	{
		[SerializeField] private Item equipmentItem;

		public static Action<Item> OnTryEquip;

		public void TryEquip(bool tryEquip)
        {
			if (tryEquip)
				OnTryEquip?.Invoke(equipmentItem);
        }
	}
}