using System.Collections.Generic;
using GOAP.Actions;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Sample
{
    public class ReturnToolAction : VillageActionBase
    {
        [SerializeField] private ToolType toolType;

        private ToolVisualController toolVisualController;

        protected override void BuildEffects(List<WorldStateFact> effects)
        {
            effects.Add(WorldStateFact.Create(VillageWorldKeys.IsHoldingTool, false));
        }

        protected override void BuildPreconditions(List<WorldStateFact> preconditions)
        {
            preconditions.Add(WorldStateFact.Create(VillageWorldKeys.IsHoldingTool, true));
            preconditions.Add(WorldStateFact.Create(VillageWorldKeys.HeldToolType, (int)toolType));
        }

        protected override Transform GetTargetWaypoint()
        {
            return VillageManager.Instance.ToolShed.Waypoint;
        }

        protected override ActionStatus OnArrived(ActionContext context)
        {
            VillageManager.Instance.ToolShed.ReturnTool(toolType, VillagerStats);
            VillagerStats.SetHeldTool(ToolType.None);
            return Continue();
        }

        protected override ActionStatus OnActTick(ActionContext context)
        {
            return Complete();
        }

        protected override void OnActionStop(ActionContext context, ActionStopReason reason)
        {
            if (reason != ActionStopReason.Completed)
                return;

            if (toolVisualController == null)
                toolVisualController = context.AgentObject.GetComponent<ToolVisualController>();

            toolVisualController.ToggleToolVisual(toolType, false);
        }
    }
}