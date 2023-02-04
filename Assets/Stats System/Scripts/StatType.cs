using UnityEngine;

namespace StatsSystem
{
	[CreateAssetMenu(fileName = "StatType", menuName = "Scriptable Objects/Stats System/Stat Type")]
	public class StatType : ScriptableObject
	{
		[SerializeField] private string statName;

		public string GetStatName => statName;
	}
}