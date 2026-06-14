using GOAP.WorldStates;

namespace GOAP.Planning
{
    /// <summary>
    /// Defines a heuristic function used by the GoapPlanner during A* search.
    /// The heuristic estimates how far a given simulated state is from the goal state.
    ///
    /// The default implementation (UnsatisfiedConditionsHeuristic) counts how many
    /// facts in the goal state are not yet satisfied by the current state.
    ///
    /// Inject a custom implementation into GoapPlanner for domain-specific guidance.
    /// </summary>
    public interface IPlannerHeuristic
    {
        /// <summary>
        /// Estimates the cost from <paramref name="simulatedState"/> to <paramref name="goalState"/>.
        /// Must never overestimate the true cost to remain admissible for optimal A*.
        /// </summary>
        float Compute(WorldState simulatedState, WorldState goalState);
    }
}