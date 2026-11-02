using UnityEngine;

namespace StatsSystem
{
    [RequireComponent(typeof(StatsSheetComponent))]
    public class VehicleEquipmentManager : MonoBehaviour
	{
        private StatsSheetComponent vehicleStats;

        private EquipmentSlot attachmentSlot;

        private void Awake()
        {
            vehicleStats = GetComponent<StatsSheetComponent>();

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
                    attachmentSlot.EquipItem(equipmentItem, vehicleStats);
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