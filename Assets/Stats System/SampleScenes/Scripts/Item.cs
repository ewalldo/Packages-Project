using UnityEngine;

namespace StatsSystem
{
	//[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
	public class Item : ScriptableObject
	{
        [SerializeField] private StatsModifier[] statsModifier;
        [SerializeField] private StatTypes[] affectedStats;
		[SerializeField] private EquipmentSlotTypes equipmentSlot;

		public StatsModifier[] StatsModifiers => statsModifier;
		public StatTypes[] AffectedStats => affectedStats;
		public EquipmentSlotTypes EquipmentSlot => equipmentSlot;
	}
}