namespace GOAP.Agent
{
    /// <summary>
    /// Describes the GoapAgent's current high-level operational state.
    /// Drives which subsystems are ticked each frame and what decisions
    /// the agent is allowed to make.
    ///
    /// Distinct from ExecutorState (which describes the plan executor's
    /// internal state) and PlanStatus (which describes a plan's outcome).
    /// This describes what the agent as a whole is doing.
    /// </summary>
    public enum AgentState
    {
        /// <summary>
        /// The agent has been created but not yet initialized.
        /// No subsystems are running.
        /// </summary>
        Uninitialized,

        /// <summary>
        /// The agent is fully operational.
        /// Sensors tick, goals are evaluated, plans are formed and executed.
        /// </summary>
        Active,

        /// <summary>
        /// Sensors and goal selection are running, but planning and
        /// execution are paused. Useful for cutscenes or dialogue.
        /// </summary>
        SensingOnly,

        /// <summary>
        /// The agent found no valid, unsatisfied goal to pursue.
        /// Sensors continue ticking. Planning resumes when a goal becomes valid.
        /// </summary>
        Idle,

        /// <summary>
        /// The agent is currently waiting for the planner to return a result.
        /// Sensors continue ticking. Execution is paused.
        /// </summary>
        Planning,

        /// <summary>
        /// The planner failed to find any plan for the active goal after
        /// exhausting all retry attempts defined in GoapAgentConfig.
        /// The agent waits for the world state to change before trying again.
        /// </summary>
        PlanningFailed,

        /// <summary>
        /// All agent activity is suspended. No subsystems tick.
        /// Set this when the agent is dead, stunned, or otherwise inactive.
        /// </summary>
        Disabled
    }
}