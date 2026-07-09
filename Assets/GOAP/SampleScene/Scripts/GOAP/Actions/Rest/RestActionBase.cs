using System.Collections.Generic;
using GOAP.Actions;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Sample
{
    public abstract class RestActionBase : VillageActionBase
    {
        protected abstract LocationType TargetLocation { get; }

        private RestPlace restPlace;

        public override bool IsExecutable(WorldState currentState)
        {
            RestPlace place = VillageManager.Instance.GetRestPlace(TargetLocation);
            return !place.IsOccupied;
        }

        protected override void BuildEffects(List<WorldStateFact> effects)
        {
            effects.Add(WorldStateFact.Create(VillageWorldKeys.IsEnergyFull, true));
        }

        protected override void BuildPreconditions(List<WorldStateFact> preconditions)
        {
            preconditions.Add(WorldStateFact.Create(VillageWorldKeys.IsHoldingTool, false));
            BuildRestPlacePrecondition(preconditions);
        }

        protected override Transform GetTargetWaypoint()
        {
            restPlace = VillageManager.Instance.GetRestPlace(TargetLocation);
            return restPlace.Waypoint;
        }

        protected override ActionStatus OnArrived(ActionContext context)
        {
            if (restPlace == null || !restPlace.TryOccupy(VillagerStats))
                return Fail();

            return Continue();
        }

        protected override ActionStatus OnActTick(ActionContext context)
        {
            if (restPlace == null)
                return Fail();

            VillagerStats.RecoverEnergy(restPlace.EnergyRecoveryRate * context.DeltaTime);

            if (VillagerStats.IsEnergyFull)
            {
                return Complete();
            }

            return Continue();
        }

        protected override void OnActionStop(ActionContext context, ActionStopReason reason)
        {
            restPlace.Vacate(VillagerStats);
        }

        protected abstract void BuildRestPlacePrecondition(List<WorldStateFact> preconditions);
    }
}