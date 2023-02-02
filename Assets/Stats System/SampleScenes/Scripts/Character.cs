using UnityEngine;
using TMPro;

namespace StatsSystem
{
    public class Character : MonoBehaviour
    {
        public SingleStat Attack { get; private set; }
        public SingleStat Defense { get; private set; }
        public SingleStat Speed { get; private set; }
        public SingleStat Magic { get; private set; }
        public SingleStat Luck { get; private set; }

        [SerializeField] private TextMeshProUGUI attackStatUI;
        [SerializeField] private TextMeshProUGUI defenseStatUI;
        [SerializeField] private TextMeshProUGUI speedStatUI;
        [SerializeField] private TextMeshProUGUI magicStatUI;
        [SerializeField] private TextMeshProUGUI luckStatUI;

        private void Awake()
        {
            Attack = new SingleStat(Random.Range(1, 10), 0, 99);
            Defense = new SingleStat(Random.Range(1, 10), 0, 99);
            Speed = new SingleStat(Random.Range(1, 10), 0, 99);
            Magic = new SingleStat(Random.Range(1, 10), 0, 99);
            Luck = new SingleStat(Random.Range(1, 10), 0, 99);

            UpdateStatsUI();
        }

        private void OnEnable()
        {
            Attack.OnModifierListModified += SingleStat_OnModifierListModified;
            Defense.OnModifierListModified += SingleStat_OnModifierListModified;
            Speed.OnModifierListModified += SingleStat_OnModifierListModified;
            Magic.OnModifierListModified += SingleStat_OnModifierListModified;
            Luck.OnModifierListModified += SingleStat_OnModifierListModified;
        }

        private void OnDisable()
        {
            Attack.OnModifierListModified -= SingleStat_OnModifierListModified;
            Defense.OnModifierListModified -= SingleStat_OnModifierListModified;
            Speed.OnModifierListModified -= SingleStat_OnModifierListModified;
            Magic.OnModifierListModified -= SingleStat_OnModifierListModified;
            Luck.OnModifierListModified -= SingleStat_OnModifierListModified;
        }

        private void SingleStat_OnModifierListModified(float baseStat, float modifiedStat)
        {
            UpdateStatsUI();
        }

        public void UpdateStatsUI()
        {
            attackStatUI.text = Attack.GetFinalValueAfterModifiers.ToString();
            defenseStatUI.text = Defense.GetFinalValueAfterModifiers.ToString();
            speedStatUI.text = Speed.GetFinalValueAfterModifiers.ToString();
            magicStatUI.text = Magic.GetFinalValueAfterModifiers.ToString();
            luckStatUI.text = Luck.GetFinalValueAfterModifiers.ToString();
        }
    }
}
