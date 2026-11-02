using System.Collections.Generic;
using GOAP.Actions;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Sample
{
    public class PickupToolAction : VillageActionBase
    {
        [SerializeField] private ToolType toolType;

        private ToolVisualController toolVisualController;

        public override bool IsExecutable(WorldState currentState)
        {
            return VillageManager.Instance.ToolShed.IsToolAvailable(toolType);
        }

        protected override void BuildEffects(List<WorldStateFact> effects)
        {
            effects.Add(WorldStateFact.Create(VillageWorldKeys.IsHoldingTool, true));
            effects.Add(WorldStateFact.Create(VillageWorldKeys.HeldToolType, (int)toolType));
        }

        protected override void BuildPreconditions(List<WorldStateFact> preconditions)
        {
            preconditions.Add(WorldStateFact.Create(VillageWorldKeys.IsHoldingTool, false));
            preconditions.Add(WorldStateFact.Create(GetAvailabilityKey(toolType), true));
        }

        protected override Transform GetTargetWaypoint()
        {
            return VillageManager.Instance.ToolShed.Waypoint;
        }

        protected override ActionStatus OnArrived(ActionContext context)
        {
            if (!VillageManager.Instance.ToolShed.TryClaimTool(toolType, VillagerStats))
                return Fail();

            VillagerStats.SetHeldTool(toolType);
            return Continue();
        }

        protected override ActionStatus OnActTick(ActionContext context)
        {
            return Complete();
        }

        private static WorldStateKey GetAvailabilityKey(ToolType tool)
        {
            return tool switch
            {
                ToolType.Pickaxe => VillageWorldKeys.IsPickaxeAvailable,
                ToolType.Axe => VillageWorldKeys.IsAxeAvailable,
                ToolType.Hoe => VillageWorldKeys.IsHoeAvailable,
                _ => throw new System.ArgumentOutOfRangeException(nameof(tool), tool, null)
            };
        }

        protected override void OnActionStop(ActionContext context, ActionStopReason reason)
        {
            if (reason != ActionStopReason.Completed)
                return;

            if (toolVisualController == null)
                toolVisualController = context.AgentObject.GetComponent<ToolVisualController>();

            toolVisualController.ToggleToolVisual(toolType, true);
        }
    }
}