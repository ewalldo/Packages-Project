namespace GOAP.Actions
{
    /// <summary>
    /// Describes why an action was stopped.
    /// Passed to OnStop() so actions can clean up appropriately
    /// depending on whether they finished naturally or were interrupted.
    /// </summary>
    public enum ActionStopReason
    {
        /// <summary>The action completed successfully on its own.</summary>
        Completed,

        /// <summary>
        /// The action was stopped because the plan it belonged to was aborted.
        /// Example: the active goal changed mid-execution.
        /// </summary>
        PlanAborted,

        /// <summary>
        /// The action failed during execution and triggered a replan.
        /// </summary>
        Failed,

        /// <summary>
        /// The action was forcibly stopped from the outside.
        /// Example: the agent was disabled or destroyed.
        /// </summary>
        ForcedStop
    }
}