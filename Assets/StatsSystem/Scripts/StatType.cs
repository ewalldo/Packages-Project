using UnityEngine;

namespace StatsSystem
{
	[CreateAssetMenu(fileName = "StatType", menuName = "Scriptable Objects/Stats System/Stat Type")]
	public class StatType : ScriptableObject
	{
		[SerializeField] private string statName;

		public string GetNameOfStatName => nameof(statName);

		/// <summary>
		/// Get the name of this stat
		/// </summary>
		public string GetStatName => statName;
	}
}