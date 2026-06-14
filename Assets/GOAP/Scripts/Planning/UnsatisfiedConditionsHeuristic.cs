using GOAP.WorldStates;

namespace GOAP.Planning
{
    /// <summary>
    /// Default GOAP heuristic.
    /// Counts the number of goal facts not yet satisfied by the simulated state.
    /// This is admissible — it never overestimates — making A* produce optimal plans.
    /// </summary>
    public class UnsatisfiedConditionsHeuristic : IPlannerHeuristic
    {
        public float Compute(WorldState simulatedState, WorldState goalState)
        {
            float unsatisfied = 0f;

            foreach (WorldStateFact goalFact in goalState.GetAllFacts())
            {
                if (!simulatedState.TryGet(goalFact.Key, out object currentValue) || !Equals(currentValue, goalFact.Value))
                {
                    unsatisfied++;
                }
            }

            return unsatisfied;
        }
    }
}