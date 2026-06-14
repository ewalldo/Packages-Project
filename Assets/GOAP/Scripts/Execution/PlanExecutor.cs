using System;
using GOAP.Actions;
using GOAP.Planning;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Execution
{
    /// <summary>
    /// Concrete plan executor that steps through a GoapPlan's action sequence.
    ///
    /// Execution flow per action:
    ///   1. Dequeue next action from the plan
    ///   2. Check IsExecutable() against the live world state
    ///      → If false: abort plan with Failed status
    ///   3. Call action.OnStart()
    ///   4. Call action.OnTick() every frame
    ///      → Running   : continue ticking
    ///      → Completed : apply effects, call OnStop(Completed), advance to next action
    ///      → Failed    : call OnStop(Failed), abort plan
    ///   5. When all actions complete: plan succeeds
    ///
    /// This is a pure C# class (no MonoBehaviour).
    /// It is owned and ticked by the GoapAgent.
    /// </summary>
    public class PlanExecutor : IPlanExecutor
    {
        // - State -

        private GoapPlan currentPlan;
        private IAction currentAction;
        private ActionContext context;
        private ExecutorState state;

        // - Debugging -

        private bool debugLog = false;

        // - IPlanExecutor: Properties -

        public GoapPlan CurrentPlan => currentPlan;
        public IAction CurrentAction => currentAction;
        public ActionContext CurrentActionContext => context;
        public ExecutorState State => state;
        public ExecutionEvents Events { get; }
        public bool IsRunning => state is ExecutorState.StartingAction
            or ExecutorState.RunningAction
            or ExecutorState.CompletingAction;

        // - Constructor -

        public PlanExecutor(ActionContext actionContext, bool debugLog = false)
        {
            if (actionContext == null)
                throw new ArgumentNullException(nameof(actionContext));

            Events = new ExecutionEvents();
            context = actionContext;
            state = ExecutorState.Idle;
            this.debugLog = debugLog;
        }

        // - IPlanExecutor: Plan Control -

        /// <inheritdoc/>
        public void StartPlan(GoapPlan plan, PlanInterruptReason interruptReason = PlanInterruptReason.Replanned)
        {
            if (plan == null)
                throw new ArgumentNullException(nameof(plan));

            // Clean up any currently running plan first
            if (IsRunning)
                InterruptCurrentAction(interruptReason);

            currentPlan = plan;
            currentAction = null;

            currentPlan.Status = PlanStatus.Running;
            state = ExecutorState.StartingAction;

            Events.RaisePlanStarted(currentPlan);
        }

        /// <inheritdoc/>
        public void Tick()
        {
            // Update the context's timing data
            context.Tick(Time.deltaTime);

            switch (state)
            {
                case ExecutorState.Idle:
                case ExecutorState.PlanSucceeded:
                case ExecutorState.PlanFailed:
                    return;

                case ExecutorState.StartingAction:
                    TickStartingAction();
                    break;

                case ExecutorState.RunningAction:
                    TickRunningAction();
                    break;

                case ExecutorState.CompletingAction:
                    TickCompletingAction();
                    break;
            }
        }

        /// <inheritdoc/>
        public void InterruptPlan(PlanInterruptReason reason)
        {
            if (!IsRunning && currentPlan == null)
                return;

            InterruptCurrentAction(reason);

            if (currentPlan != null)
            {
                currentPlan.Status = PlanStatus.Interrupted;
                Events.RaisePlanInterrupted(currentPlan, reason);
            }

            ClearPlanState();
        }

        /// <inheritdoc/>
        public void Reset()
        {
            currentPlan = null;
            currentAction = null;
            state = ExecutorState.Idle;
        }

        // - State Machine Ticks -

        /// <summary>
        /// StartingAction state: dequeue next action, validate it, and call OnStart().
        /// </summary>
        private void TickStartingAction()
        {
            // Check if plan is exhausted
            if (currentPlan.IsEmpty)
            {
                CompletePlan();
                return;
            }

            IAction next = currentPlan.Dequeue();

            // - Runtime executability check -
            if (!next.IsExecutable(context.CurrentWorldState))
            {
                HandleActionFailure(next, $"Action '{next.Name}' failed IsExecutable() check before starting.");
                return;
            }

            currentAction = next;

            // Reset context timer for the new action
            context.ResetTimer();

            // Start the action
            currentAction.OnStart(context);
            state = ExecutorState.RunningAction;

            Events.RaiseActionStarted(currentAction);
        }

        /// <summary>
        /// RunningAction state: tick the current action and react to its returned status.
        /// </summary>
        private void TickRunningAction()
        {
            if (currentAction == null)
            {
                // Safety: should never happen but guard against corrupt state
                state = ExecutorState.StartingAction;
                return;
            }

            ActionStatus status = currentAction.OnTick(context);

            switch (status)
            {
                case ActionStatus.Running:
                    // Nothing to do — keep ticking
                    break;

                case ActionStatus.Completed:
                    state = ExecutorState.CompletingAction;
                    break;

                case ActionStatus.Failed:
                    HandleActionFailure(currentAction, $"Action '{currentAction.Name}' returned Failed from OnTick().");
                    break;

                default:
                    if (debugLog)
                        Debug.LogWarning($"[PlanExecutor] Unexpected ActionStatus '{status}' " + $"returned from '{currentAction.Name}'. Treating as Running.");
                    break;
            }
        }

        /// <summary>
        /// CompletingAction state: apply effects, fire events, and advance to next action.
        /// Separated into its own state to allow exactly one frame of transition
        /// between actions, giving external systems time to react to OnActionCompleted.
        /// </summary>
        private void TickCompletingAction()
        {
            // Apply this action's effects to the live world state
            ApplyActionEffects(currentAction, context.CurrentWorldState);

            // Stop the action cleanly
            currentAction.OnStop(context, ActionStopReason.Completed);

            Events.RaiseActionCompleted(currentAction);

            currentAction = null;

            // Advance to next action (or finish if plan is empty)
            state = ExecutorState.StartingAction;
        }

        // - Plan Terminal States -

        /// <summary>Called when the plan's action queue is exhausted successfully.</summary>
        private void CompletePlan()
        {
            currentPlan.Status = PlanStatus.Succeeded;
            state = ExecutorState.PlanSucceeded;

            Events.RaisePlanSucceeded(currentPlan);
        }

        /// <summary>
        /// Called when an action fails either via IsExecutable() or OnTick() returning Failed.
        /// Stops the action, marks the plan as failed, and fires the appropriate events.
        /// </summary>
        private void HandleActionFailure(IAction action, string logMessage)
        {
            if (debugLog)
                Debug.LogWarning($"[PlanExecutor] {logMessage}");

            // Stop the action if it had already started
            if (state == ExecutorState.RunningAction)
                action.OnStop(context, ActionStopReason.Failed);

            Events.RaiseActionFailed(action);

            currentPlan.Status = PlanStatus.Failed;
            state = ExecutorState.PlanFailed;

            Events.RaisePlanFailed(currentPlan, action);

            currentAction = null;
        }

        // - Helpers -

        /// <summary>
        /// Applies a completed action's effects to the live world state.
        /// This is the only place in the system where the executor writes to WorldState.
        /// </summary>
        private static void ApplyActionEffects(IAction action, WorldState worldState)
        {
            worldState.ApplyRange(action.Effects);
        }

        /// <summary>
        /// Stops the currently running action due to an external interruption.
        /// Maps PlanInterruptReason to the appropriate ActionStopReason.
        /// </summary>
        private void InterruptCurrentAction(PlanInterruptReason reason)
        {
            if (currentAction == null || context == null)
                return;

            ActionStopReason stopReason = reason switch
            {
                PlanInterruptReason.AgentStopped => ActionStopReason.ForcedStop,
                PlanInterruptReason.GoalChanged => ActionStopReason.PlanAborted,
                PlanInterruptReason.WorldStateInvalidated => ActionStopReason.PlanAborted,
                PlanInterruptReason.Replanned => ActionStopReason.PlanAborted,
                _ => ActionStopReason.ForcedStop
            };

            currentAction.OnStop(context, stopReason);
            currentAction = null;
        }

        /// <summary>Clears all plan-related state without raising events.</summary>
        private void ClearPlanState()
        {
            currentPlan   = null;
            currentAction = null;
            state = ExecutorState.Idle;
        }
    }
}