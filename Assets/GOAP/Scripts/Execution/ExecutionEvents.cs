using System;
using GOAP.Actions;
using GOAP.Planning;

namespace GOAP.Execution
{
    /// <summary>
    /// Centralised event hub for plan and action lifecycle notifications.
    /// One instance lives on each GoapAgent and is shared between the
    /// PlanExecutor and any external listeners (UI, audio, debug tools).
    ///
    /// Subscribe to these from GoapAgent, animator controllers,
    /// debug visualizers, or any other observer — without coupling
    /// them directly to the executor.
    /// </summary>
    public class ExecutionEvents
    {
        // - Plan Events -

        /// <summary>
        /// Raised when a new plan is accepted and execution begins.
        /// Carries the full plan for inspection.
        /// </summary>
        public event Action<GoapPlan> OnPlanStarted;

        /// <summary>
        /// Raised when every action in a plan has completed successfully.
        /// </summary>
        public event Action<GoapPlan> OnPlanSucceeded;

        /// <summary>
        /// Raised when execution is aborted due to an action failure.
        /// Carries the plan that failed and the action that caused it.
        /// </summary>
        public event Action<GoapPlan, IAction> OnPlanFailed;

        /// <summary>
        /// Raised when execution is cancelled externally
        /// (e.g. the goal changed, the agent was disabled).
        /// Carries the plan that was interrupted and the reason.
        /// </summary>
        public event Action<GoapPlan, PlanInterruptReason> OnPlanInterrupted;

        // - Action Events -

        /// <summary>
        /// Raised just after an action's OnStart() is called.
        /// </summary>
        public event Action<IAction> OnActionStarted;

        /// <summary>
        /// Raised just after an action's OnStop() is called with Completed reason.
        /// </summary>
        public event Action<IAction> OnActionCompleted;

        /// <summary>
        /// Raised just after an action's OnStop() is called with Failed reason.
        /// </summary>
        public event Action<IAction> OnActionFailed;

        // - Internal Raise Methods (called only by PlanExecutor) -

        internal void RaisePlanStarted(GoapPlan plan) => OnPlanStarted?.Invoke(plan);

        internal void RaisePlanSucceeded(GoapPlan plan) => OnPlanSucceeded?.Invoke(plan);

        internal void RaisePlanFailed(GoapPlan plan, IAction failedAction) => OnPlanFailed?.Invoke(plan, failedAction);

        internal void RaisePlanInterrupted(GoapPlan plan, PlanInterruptReason reason) => OnPlanInterrupted?.Invoke(plan, reason);

        internal void RaiseActionStarted(IAction action) => OnActionStarted?.Invoke(action);

        internal void RaiseActionCompleted(IAction action) => OnActionCompleted?.Invoke(action);

        internal void RaiseActionFailed(IAction action) => OnActionFailed?.Invoke(action);
    }
}