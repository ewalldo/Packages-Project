using System;
using UnityEngine;
using TMPro;

namespace StatsSystem
{
	public class StatusUI : MonoBehaviour
	{
		[SerializeField] private StatType statType;
        [SerializeField] private TextMeshProUGUI statText;

        private void OnEnable()
        {
            Character.OnStatUpdated += Character_OnStatUpdated;
        }

        private void OnDisable()
        {
            Character.OnStatUpdated -= Character_OnStatUpdated;
        }

        private void Character_OnStatUpdated(StatType type, float value)
        {
            if (type == statType)
                statText.text = value.ToString();
        }
    }
}