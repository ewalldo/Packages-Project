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

		public void EquipItem(Item equipment, Character character)
        {
			if (equippedItem != null)
				UnequipItem(character);

            if (equipment != null)
            {
                foreach (StatsModifier statsModifier in equipment.StatsModifiers)
                {
                    character.AddModifierToStat(statsModifier.StatTypeTarget, statsModifier);
                }
            }

            equippedItem = equipment;
        }

		public void UnequipItem(Character character)
        {
            if (equippedItem == null)
                return;

            foreach (StatsModifier statsModifier in equippedItem.StatsModifiers)
            {
                character.RemoveModifierFromStat(statsModifier.StatTypeTarget, statsModifier);
            }

			equippedItem = null;
		}
	}
}