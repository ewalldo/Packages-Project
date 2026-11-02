namespace GOAP.Actions
{
    /// <summary>
    /// Represents the current execution state of a GoapAction.
    /// Returned by OnTick() every frame to communicate progress
    /// back to the PlanExecutor.
    /// </summary>
    public enum ActionStatus
    {
        /// <summary>The action has not been started yet.</summary>
        Idle,

        /// <summary>The action is currently executing. Return this from OnTick() to continue.</summary>
        Running,

        /// <summary>
        /// The action finished successfully and applied its effects.
        /// The PlanExecutor will advance to the next action in the plan.
        /// </summary>
        Completed,

        /// <summary>
        /// The action encountered an error or its conditions were no longer met.
        /// The PlanExecutor will abort the current plan and request a replan.
        /// </summary>
        Failed
    }
}