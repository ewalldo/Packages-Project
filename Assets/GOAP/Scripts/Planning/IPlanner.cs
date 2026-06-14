using System.Collections.Generic;
using GOAP.Actions;
using GOAP.Goals;
using GOAP.WorldStates;

namespace GOAP.Planning
{
    /// <summary>
    /// Defines the contract for any GOAP planner implementation.
    /// Accepts the current world state, the desired goal, and the available
    /// action set, then returns an ordered plan.
    ///
    /// This interface allows the GoapAgent to swap planner implementations
    /// (e.g. A*, Dijkstra, hierarchical GOAP) without any changes to other layers.
    /// </summary>
    public interface IPlanner
    {
        /// <summary>
        /// Attempts to find a plan: a sequence of actions that, when executed in order,
        /// will transition <paramref name="currentState"/> into a state
        /// that satisfies <paramref name="goal"/>.
        /// </summary>
        /// <param name="currentState">The agent's current real world state.</param>
        /// <param name="goal">The goal whose DesiredState the plan must satisfy.</param>
        /// <param name="availableActions">All actions the agent can potentially perform.</param>
        /// <returns>
        /// A valid <see cref="GoapPlan"/> if one was found, or null if no plan exists.
        /// </returns>
        GoapPlan CreatePlan(WorldState currentState, IGoal goal, IReadOnlyList<IAction> availableActions);
    }
}