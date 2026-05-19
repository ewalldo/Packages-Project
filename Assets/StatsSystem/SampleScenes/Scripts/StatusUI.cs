using TMPro;
using UnityEngine;

namespace StatsSystem
{
	public class StatusUI : MonoBehaviour
	{
        [SerializeField] private StatsSheetComponent statsSheet;
		[SerializeField] private StatType statType;
        [SerializeField] private TextMeshProUGUI statText;

        private void OnEnable()
        {
            statsSheet.OnStatChanged += StatsSheet_OnStatChanged;
        }

        private void OnDisable()
        {
            statsSheet.OnStatChanged -= StatsSheet_OnStatChanged;
        }

        private void Start()
        {
            statText.text = statsSheet.GetStat(statType).GetFinalValue().ToString();
        }

        private void StatsSheet_OnStatChanged(StatType type, float baseValue, float finalValue)
        {
            if (type == statType)
                statText.text = finalValue.ToString();
        }
    }
}