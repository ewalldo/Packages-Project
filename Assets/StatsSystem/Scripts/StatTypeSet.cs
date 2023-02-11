using UnityEngine;

namespace StatsSystem
{
	[CreateAssetMenu(fileName = "StatTypeSet", menuName = "Scriptable Objects/Stats System/Stat Type Set")]
	public class StatTypeSet : ScriptableObject
	{
		[SerializeField] private StatType[] statTypeSet;

		public StatType[] GetStatTypeSet => statTypeSet;
	}
}