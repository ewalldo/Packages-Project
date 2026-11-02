namespace GOAP.Execution
{
    /// <summary>
    /// Describes the internal state of the PlanExecutor's own state machine.
    /// Distinct from PlanStatus (which describes the plan's outcome) —
    /// this describes what the executor is actively doing right now.
    /// </summary>
    public enum ExecutorState
    {
        /// <summary>No plan is loaded. The executor is idle and waiting.</summary>
        Idle,

        /// <summary>
        /// An action has been dequeued and is about to have OnStart() called.
        /// Lasts only one tick.
        /// </summary>
        StartingAction,

        /// <summary>
        /// An action is actively running. OnTick() is being called every frame.
        /// </summary>
        RunningAction,

        /// <summary>
        /// The active action completed and the executor is transitioning
        /// to the next one. Lasts only one tick.
        /// </summary>
        CompletingAction,

        /// <summary>The plan finished successfully. Terminal state until reset.</summary>
        PlanSucceeded,

        /// <summary>The plan failed. Terminal state until reset.</summary>
        PlanFailed
    }
}