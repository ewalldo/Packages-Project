using UnityEngine;
using UnityEngine.UI;

namespace GOAP.Sample
{
    public class EnergyUI : MonoBehaviour
    {
        [SerializeField] private VillagerStats villagerStats;
        [SerializeField] private Image energyBarFill;

        private void Update()
        {
            float energyRatio = villagerStats.Energy / villagerStats.MaxEnergy;
            energyBarFill.fillAmount = energyRatio;
        }
    }
}