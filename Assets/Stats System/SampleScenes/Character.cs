using UnityEngine;
using TMPro;

namespace StatsSystem
{
    public class Character : MonoBehaviour
    {
        public CharacterStat Attack { get; private set; }
        public CharacterStat Defense { get; private set; }
        public CharacterStat Speed { get; private set; }
        public CharacterStat Magic { get; private set; }
        public CharacterStat Luck { get; private set; }

        [SerializeField] private TextMeshProUGUI attackStatUI;
        [SerializeField] private TextMeshProUGUI defenseStatUI;
        [SerializeField] private TextMeshProUGUI speedStatUI;
        [SerializeField] private TextMeshProUGUI magicStatUI;
        [SerializeField] private TextMeshProUGUI luckStatUI;

        private void Start()
        {
            Attack = new CharacterStat(Random.Range(1, 10), 0, 99);
            Defense = new CharacterStat(Random.Range(1, 10), 0, 99);
            Speed = new CharacterStat(Random.Range(1, 10), 0, 99);
            Magic = new CharacterStat(Random.Range(1, 10), 0, 99);
            Luck = new CharacterStat(Random.Range(1, 10), 0, 99);

            UpdateStatsUI();
        }

        private void UpdateStatsUI()
        {
            attackStatUI.text = Attack.GetFinalValueAfterModifiers.ToString();
            defenseStatUI.text = Defense.GetFinalValueAfterModifiers.ToString();
            speedStatUI.text = Speed.GetFinalValueAfterModifiers.ToString();
            magicStatUI.text = Magic.GetFinalValueAfterModifiers.ToString();
            luckStatUI.text = Luck.GetFinalValueAfterModifiers.ToString();
        }
    }
}
