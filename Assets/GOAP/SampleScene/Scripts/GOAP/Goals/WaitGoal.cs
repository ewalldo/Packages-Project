using GOAP.Goals;
using GOAP.Sensing;
using GOAP.WorldStates;

namespace GOAP.Sample
{
    public class WaitGoal : GoapGoal
    {
        public override float GetPriority(WorldState currentState, Blackboard blackboard)
        {
            return 1f;
        }

        public override bool IsValid(WorldState currentState)
        {
            return true;
        }

        protected override void BuildDesiredState(WorldState desiredState)
        {
            desiredState.Set(VillageWorldKeys.IsWaiting, true);
        }
    }
}