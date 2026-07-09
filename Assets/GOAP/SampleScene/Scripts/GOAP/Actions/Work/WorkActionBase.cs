using System.Collections.Generic;
using GOAP.Actions;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Sample
{
    public abstract class WorkActionBase : VillageActionBase
    {
        protected abstract LocationType TargetStation { get; }

        private WorkStation station;

        protected override void BuildEffects(List<WorldStateFact> effects)
        {
            effects.Add(WorldStateFact.Create(VillageWorldKeys.HasWorked, true));
        }

        protected override void BuildPreconditions(List<WorldStateFact> preconditions)
        {
            preconditions.Add(WorldStateFact.Create(VillageWorldKeys.IsEnergyLow, false));

            preconditions.Add(WorldStateFact.Create(VillageWorldKeys.IsHoldingTool, true));
            preconditions.Add(WorldStateFact.Create(VillageWorldKeys.HeldToolType, (int)GetExpectedTool()));
        }

        protected override Transform GetTargetWaypoint()
        {
            station = VillageManager.Instance.GetWorkStation(TargetStation);
            return station.Waypoint;
        }

        protected override ActionStatus OnArrived(ActionContext context)
        {
            if (station == null)
                return Fail();

            return Continue();
        }

        protected override ActionStatus OnActTick(ActionContext context)
        {
            if (VillagerStats.IsEnergyLow)
                return Complete();

            VillagerStats.ConsumeEnergy(station.EnergyCost * context.DeltaTime);
            VillageManager.Instance.RegisterGatheredResource(station.ProducedResource, context.DeltaTime);

            return Continue();
        }

        private static WorldStateKey GetLocationKey(LocationType location)
        {
            return location switch
            {
                LocationType.Mine => VillageWorldKeys.IsAtMine,
                LocationType.Forest => VillageWorldKeys.IsAtForest,
                LocationType.Farm => VillageWorldKeys.IsAtFarm,
                _ => throw new System.ArgumentOutOfRangeException(nameof(location), location, null)
            };
        }

        protected override void OnActionStop(ActionContext context, ActionStopReason reason)
        {
            base.OnActionStop(context, reason);
            if (reason == ActionStopReason.Completed)
                context.CurrentWorldState.Set(VillageWorldKeys.HasWorked, false);
        }

        protected abstract ToolType GetExpectedTool();
    }
}