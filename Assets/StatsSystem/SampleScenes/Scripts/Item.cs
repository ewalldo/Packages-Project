using UnityEngine;

namespace StatsSystem
{
	//[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
	public class Item : ScriptableObject
	{
        [SerializeField] private StatsModifier[] statsModifier;
		[SerializeField] private EquipmentSlotTypes equipmentSlot;

		public StatsModifier[] StatsModifiers => statsModifier;
		public EquipmentSlotTypes EquipmentSlot => equipmentSlot;
	}
}