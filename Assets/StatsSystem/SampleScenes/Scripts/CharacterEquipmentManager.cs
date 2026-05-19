using UnityEngine;

namespace StatsSystem
{
    [RequireComponent(typeof(StatsSheetComponent))]
    public class CharacterEquipmentManager : MonoBehaviour
    {
        private StatsSheetComponent characterStats;

        private EquipmentSlot weaponSlot;
        private EquipmentSlot helmetSlot;
        private EquipmentSlot armorSlot;

        private void Awake()
        {
            characterStats = GetComponent<StatsSheetComponent>();

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
                    weaponSlot.EquipItem(equipmentItem, characterStats);
                    break;
                case EquipmentSlotTypes.HelmetSlot:
                    helmetSlot.EquipItem(equipmentItem, characterStats);
                    break;
                case EquipmentSlotTypes.ArmorSlot:
                    armorSlot.EquipItem(equipmentItem, characterStats);
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
