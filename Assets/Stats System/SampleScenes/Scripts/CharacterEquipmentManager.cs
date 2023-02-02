using UnityEngine;

namespace StatsSystem
{
    [RequireComponent(typeof(Character))]
    public class CharacterEquipmentManager : MonoBehaviour
    {
        private Character character;

        private EquipmentSlot weaponSlot;
        private EquipmentSlot helmetSlot;
        private EquipmentSlot armorSlot;

        private void Awake()
        {
            character = GetComponent<Character>();

            weaponSlot = new EquipmentSlot();
            helmetSlot = new EquipmentSlot();
            armorSlot = new EquipmentSlot();
        }

        private void OnEnable()
        {
            ItemSlot.OnTryEquip += ItemSlot_OnTryEquip;
        }

        private void OnDisable()
        {
            ItemSlot.OnTryEquip -= ItemSlot_OnTryEquip;
        }

        private void EquipItem(Item equipmentItem)
        {
            switch (equipmentItem.EquipmentSlot)
            {
                case EquipmentSlotTypes.WeaponSlot:
                    weaponSlot.EquipItem(equipmentItem, character);
                    break;
                case EquipmentSlotTypes.HelmetSlot:
                    helmetSlot.EquipItem(equipmentItem, character);
                    break;
                case EquipmentSlotTypes.ArmorSlot:
                    armorSlot.EquipItem(equipmentItem, character);
                    break;
                default:
                    break;
            }
        }

        private void ItemSlot_OnTryEquip(Item item)
        {
            EquipItem(item);
        }
    }
}
