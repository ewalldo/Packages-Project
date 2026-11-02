using System;
using UnityEngine;

namespace StatsSystem
{
	public class EquipmentSlot
	{
		private Item equippedItem;

        public EquipmentSlot()
        {
			equippedItem = null;
        }

		public void EquipItem(Item equipment, StatsSheetComponent statsSheet)
        {
			if (equippedItem != null)
				UnequipItem(statsSheet);

            if (equipment != null)
            {
                foreach (StatsModifier statsModifier in equipment.StatsModifiers)
                {
                    statsSheet.AddModifier(statsModifier);
                }
            }

            equippedItem = equipment;
        }

		public void UnequipItem(StatsSheetComponent statsSheet)
        {
            if (equippedItem == null)
                return;

            foreach (StatsModifier statsModifier in equippedItem.StatsModifiers)
            {
                statsSheet.RemoveModifier(statsModifier);
            }

			equippedItem = null;
		}
	}
}