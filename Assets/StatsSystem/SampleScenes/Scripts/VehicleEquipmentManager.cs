using UnityEngine;

namespace StatsSystem
{
    [RequireComponent(typeof(Character))]
    public class VehicleEquipmentManager : MonoBehaviour
	{
        private Character character;

        private EquipmentSlot attachmentSlot;

        private void Awake()
        {
            character = GetComponent<Character>();

            attachmentSlot = new EquipmentSlot();
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
                case EquipmentSlotTypes.AttachmentSlot:
                    attachmentSlot.EquipItem(equipmentItem, character);
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