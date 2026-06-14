namespace GOAP.Planning
{
    /// <summary>
    /// Represents the current lifecycle state of a GoapPlan.
    /// Tracked by the PlanExecutor as it works through the action sequence.
    /// </summary>
    public enum PlanStatus
    {
        /// <summary>The plan has been created but execution has not started.</summary>
        Idle,

        /// <summary>The plan is currently being executed.</summary>
        Running,

        /// <summary>All actions in the plan completed successfully.</summary>
        Succeeded,

        /// <summary>An action in the plan failed, triggering a replan.</summary>
        Failed,

        /// <summary>The plan was cancelled externally (e.g. goal changed).</summary>
        Interrupted
    }
}