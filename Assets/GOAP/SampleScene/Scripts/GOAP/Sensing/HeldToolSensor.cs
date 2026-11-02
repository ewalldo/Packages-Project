using GOAP.Sensing;
using UnityEngine;

namespace GOAP.Sample
{
    public class HeldToolSensor : GoapSensor
    {
        [SerializeField] private VillagerStats villagerStats;

        public override void UpdateSense(SensorContext context)
        {
            context.WorldState.Set(VillageWorldKeys.IsHoldingTool, villagerStats.IsHoldingTool);
            context.WorldState.Set(VillageWorldKeys.HeldToolType, (int)villagerStats.HeldTool);
        }
    }
}