using GOAP.Goals;
using GOAP.Sensing;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Sample
{
    public class WorkGoal : GoapGoal
    {
        [SerializeField] private float priority = 2f;

        public override float GetPriority(WorldState currentState, Blackboard blackboard)
        {
            return priority;
        }

        public override bool IsValid(WorldState currentState)
        {
            bool isEnergyLow = currentState.GetBool(VillageWorldKeys.IsEnergyLow);

            bool pickaxeAvailable = currentState.GetBool(VillageWorldKeys.IsPickaxeAvailable);
            bool axeAvailable = currentState.GetBool(VillageWorldKeys.IsAxeAvailable);
            bool hoeAvailable = currentState.GetBool(VillageWorldKeys.IsHoeAvailable);
            bool anyToolAvailable = pickaxeAvailable || axeAvailable || hoeAvailable;

            bool isHoldingTool = currentState.GetBool(VillageWorldKeys.IsHoldingTool);
            bool hasAnyToolInPossessionOrAvailable = isHoldingTool || anyToolAvailable;

            return !isEnergyLow && hasAnyToolInPossessionOrAvailable;
        }

        protected override void BuildDesiredState(WorldState desiredState)
        {
            desiredState.Set(VillageWorldKeys.HasWorked, true);
        }
    }
}