namespace GOAP.Goals
{
    /// <summary>
    /// Describes why a goal was deactivated.
    /// Passed to OnGoalDeactivated so goals can react to context.
    /// </summary>
    public enum GoalDeactivationReason
    {
        /// <summary>The goal was successfully completed (its desired state is satisfied).</summary>
        Completed,

        /// <summary>A higher priority goal took over.</summary>
        Interrupted,

        /// <summary>The goal became invalid mid-execution (e.g. conditions changed).</summary>
        Invalidated,

        /// <summary>The planner failed to find any plan to achieve this goal.</summary>
        PlanFailed
    }
}