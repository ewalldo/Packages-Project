namespace GOAP.Execution
{
    /// <summary>
    /// Describes why a plan was interrupted before it could complete naturally.
    /// Passed to OnPlanInterrupted and used internally when stopping actions
    /// mid-execution so they can clean up appropriately.
    /// </summary>
    public enum PlanInterruptReason
    {
        /// <summary>
        /// The active goal changed, making the current plan irrelevant.
        /// The agent will immediately request a new plan for the new goal.
        /// </summary>
        GoalChanged,

        /// <summary>
        /// The world state changed so significantly that the remaining
        /// actions can no longer be expected to reach the goal.
        /// The agent will request a replan for the same goal.
        /// </summary>
        WorldStateInvalidated,

        /// <summary>
        /// A new plan was computed for the same goal and is replacing this one.
        /// </summary>
        Replanned,

        /// <summary>
        /// The agent was disabled or destroyed mid-execution.
        /// </summary>
        AgentStopped
    }
}