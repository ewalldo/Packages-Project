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
                for (int i = 0; i < equipment.StatsModifiers.Length; i++)
                {
                    switch (equipment.AffectedStats[i])
                    {
                        case StatTypes.Attack:
                            character.Attack.AddModifier(equipment.StatsModifiers[i]);
                            break;
                        case StatTypes.Defense:
                            character.Defense.AddModifier(equipment.StatsModifiers[i]);
                            break;
                        case StatTypes.Speed:
                            character.Speed.AddModifier(equipment.StatsModifiers[i]);
                            break;
                        case StatTypes.Magic:
                            character.Magic.AddModifier(equipment.StatsModifiers[i]);
                            break;
                        case StatTypes.Luck:
                            character.Luck.AddModifier(equipment.StatsModifiers[i]);
                            break;
                        default:
                            break;
                    }
                }
            }

            equippedItem = equipment;
        }

		public void UnequipItem(Character character)
        {
            if (equippedItem == null)
                return;

            for (int i = 0; i < equippedItem.StatsModifiers.Length; i++)
            {
                switch (equippedItem.AffectedStats[i])
                {
                    case StatTypes.Attack:
                        character.Attack.RemoveModifier(equippedItem.StatsModifiers[i]);
                        break;
                    case StatTypes.Defense:
                        character.Defense.RemoveModifier(equippedItem.StatsModifiers[i]);
                        break;
                    case StatTypes.Speed:
                        character.Speed.RemoveModifier(equippedItem.StatsModifiers[i]);
                        break;
                    case StatTypes.Magic:
                        character.Magic.RemoveModifier(equippedItem.StatsModifiers[i]);
                        break;
                    case StatTypes.Luck:
                        character.Luck.RemoveModifier(equippedItem.StatsModifiers[i]);
                        break;
                    default:
                        break;
                }
            }

			equippedItem = null;
		}
	}
}