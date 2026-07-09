using GOAP.Sensing;

namespace GOAP.Sample
{
    public class ToolAvailabilitySensor : GoapSensor
    {
        private ToolShed toolShed;

        public override void Initialize(SensorContext context)
        {
            base.Initialize(context);

            toolShed = VillageManager.Instance.ToolShed;
        }

        public override void UpdateSense(SensorContext context)
        {
            context.WorldState.Set(VillageWorldKeys.IsPickaxeAvailable, toolShed.IsToolAvailable(ToolType.Pickaxe));
            context.WorldState.Set(VillageWorldKeys.IsAxeAvailable, toolShed.IsToolAvailable(ToolType.Axe));
            context.WorldState.Set(VillageWorldKeys.IsHoeAvailable, toolShed.IsToolAvailable(ToolType.Hoe));
        }
    }
}