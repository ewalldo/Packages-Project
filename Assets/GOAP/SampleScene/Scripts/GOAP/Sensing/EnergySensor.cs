using GOAP.Sensing;
using UnityEngine;

namespace GOAP.Sample
{
    public class EnergySensor : GoapSensor
    {
        [SerializeField] private VillagerStats villagerStats;

        public override void UpdateSense(SensorContext context)
        {
            context.WorldState.Set(VillageWorldKeys.IsEnergyLow, villagerStats.IsEnergyLow);
            context.WorldState.Set(VillageWorldKeys.IsEnergyFull, villagerStats.IsEnergyFull);
        }
    }
}