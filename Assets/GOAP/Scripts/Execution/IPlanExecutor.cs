using GOAP.Actions;
using GOAP.Planning;

namespace GOAP.Execution
{
    /// <summary>
    /// Defines the contract for any plan executor in the GOAP system.
    ///
    /// A plan executor is responsible for:
    ///   - Accepting a GoapPlan and stepping through its actions in order
    ///   - Calling the correct lifecycle methods on each action
    ///   - Applying action effects to the WorldState on completion
    ///   - Detecting action failures and signalling back to the agent
    ///   - Supporting external interruption cleanly
    ///
    /// The executor is driven externally by the GoapAgent — it does not
    /// own its own update loop.
    /// </summary>
    public interface IPlanExecutor
    {
        // - State -

        /// <summary>The plan currently being executed. Null if no plan is loaded.</summary>
        GoapPlan CurrentPlan { get; }

        /// <summary>The action currently being executed. Null if no action is active.</summary>
        IAction CurrentAction { get; }

        /// <summary>The context used on all actions on the current plan being executed.</summary>
        ActionContext CurrentActionContext { get; }

        /// <summary>The executor's current internal state.</summary>
        ExecutorState State { get; }

        /// <summary>Events hub for external listeners to subscribe to.</summary>
        ExecutionEvents Events { get; }

        /// <summary>Whether the executor currently has an active plan running.</summary>
        bool IsRunning { get; }

        // - Plan Control -

        /// <summary>
        /// Loads a new plan and begins execution on the next Tick().
        /// If a plan is already running it will be interrupted first.
        /// </summary>
        /// <param name="plan">The plan to execute.</param>
        /// <param name="interruptReason">
        /// The reason given to the current plan if one is already running.
        /// </param>
        void StartPlan(GoapPlan plan, PlanInterruptReason interruptReason = PlanInterruptReason.Replanned);

        /// <summary>
        /// Advances execution by one frame.
        /// Must be called every frame by the GoapAgent while a plan is active.
        /// </summary>
        void Tick();

        /// <summary>
        /// Aborts the current plan and stops the active action immediately.
        /// Safe to call when no plan is running.
        /// </summary>
        void InterruptPlan(PlanInterruptReason reason);

        /// <summary>
        /// Resets the executor fully back to Idle state.
        /// Called after a plan ends (success or failure) before starting a new one.
        /// </summary>
        void Reset();
    }
}