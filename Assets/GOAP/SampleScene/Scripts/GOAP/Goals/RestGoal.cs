using GOAP.Goals;
using GOAP.Sensing;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Sample
{
    public class RestGoal : GoapGoal
    {
        [SerializeField] private VillagerStats villagerStats;
        [SerializeField] private float basePriority = 1.5f;

        public override float GetPriority(WorldState currentState, Blackboard blackboard)
        {
            return basePriority;// + (1f - (float)_villagerStats.Energy / _villagerStats.MaxEnergy);
        }

        public override bool IsValid(WorldState currentState)
        {
            bool isEnergyFull = currentState.GetBool(VillageWorldKeys.IsEnergyFull);
            bool isRestaurantFree = currentState.GetBool(VillageWorldKeys.IsRestaurantFree);
            bool isHouseFree = currentState.GetBool(VillageWorldKeys.IsHouseFree);

            return !isEnergyFull && (isRestaurantFree || isHouseFree);
        }

        protected override void BuildDesiredState(WorldState desiredState)
        {
            desiredState.Set(VillageWorldKeys.IsEnergyFull, true);
        }
    }
}