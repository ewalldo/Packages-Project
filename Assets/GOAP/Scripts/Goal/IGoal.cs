using GOAP.Sensing;
using GOAP.WorldStates;

namespace GOAP.Goals
{
    /// <summary>
    /// Defines the contract for any goal in the GOAP system.
    /// A goal represents a desired world state the agent wants to achieve.
    /// Goals are evaluated every planning cycle to determine which one
    /// the agent should pursue.
    /// </summary>
    public interface IGoal
    {
        // - Identity -

        /// <summary>Human-readable name, used for debugging and editor tooling.</summary>
        string Name { get; }

        // - Planning Data -

        /// <summary>
        /// The desired world state this goal wants to achieve.
        /// The planner will search for an action sequence that transitions
        /// the current WorldState into one that satisfies this.
        /// </summary>
        WorldState DesiredState { get; }

        /// <summary>
        /// Priority score of this goal. Higher values win during goal selection.
        /// Can be static or dynamically computed based on the current world state or blackboard values.
        /// </summary>
        /// <param name="currentState">The agent's current world state at evaluation time.</param>
        /// <param name="blackboard">The agent's current blackboard at evaluation time.</param>
        float GetPriority(WorldState currentState, Blackboard blackboard);

        // - Validity -

        /// <summary>
        /// Whether this goal is currently relevant and eligible to be selected.
        /// An invalid goal is never selected, regardless of its priority.
        /// Example: a "FindAmmo" goal is only valid when the agent has low ammo.
        /// </summary>
        /// <param name="currentState">The agent's current world state at evaluation time.</param>
        bool IsValid(WorldState currentState);

        /// <summary>
        /// Whether this goal has already been satisfied by the current world state.
        /// A satisfied goal should not be re-planned for.
        /// </summary>
        /// <param name="currentState">The agent's current world state at evaluation time.</param>
        bool IsSatisfied(WorldState currentState);

        // - Lifecycle -

        /// <summary>
        /// Called by the GoalSelector when this goal becomes the active goal.
        /// Use for setup, animations, or logging.
        /// </summary>
        void OnGoalActivated();

        /// <summary>
        /// Called by the GoalSelector when this goal is no longer the active goal.
        /// Reason is provided so the goal can react differently to success vs interruption.
        /// </summary>
        /// <param name="reason">Why the goal was deactivated.</param>
        void OnGoalDeactivated(GoalDeactivationReason reason);
    }
}