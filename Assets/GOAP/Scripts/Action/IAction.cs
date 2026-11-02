using System.Collections.Generic;
using GOAP.WorldStates;

namespace GOAP.Actions
{
    /// <summary>
    /// Defines the contract for any action in the GOAP system.
    ///
    /// An action represents a single step an agent can take to change
    /// the world state. The planner chains actions together to form a
    /// plan that transitions from the current state to a goal state.
    ///
    /// Lifecycle per action execution:
    ///   IsExecutable() Å® OnStart() Å® OnTick() [loop] Å® OnStop()
    /// </summary>
    public interface IAction
    {
        // - Identity -

        /// <summary>Human-readable name used for debugging and editor tooling.</summary>
        string Name { get; }

        // - Planning Data -

        /// <summary>
        /// The world state facts that must be true for this action to be
        /// considered by the planner.
        /// The planner checks these against a simulated world state during search.
        /// </summary>
        IReadOnlyList<WorldStateFact> Preconditions { get; }

        /// <summary>
        /// The world state facts this action will produce when it completes.
        /// The planner applies these to simulate the resulting state.
        /// The PlanExecutor applies these to the real state after completion.
        /// </summary>
        IReadOnlyList<WorldStateFact> Effects { get; }

        /// <summary>
        /// The cost of executing this action.
        /// The planner uses this to find the lowest-cost plan.
        /// Accepts the current world state so cost can be dynamic.
        /// Example: a MoveToAction could return the actual distance to target as cost.
        /// </summary>
        float GetCost(WorldState currentState);

        // - Runtime Validity -

        /// <summary>
        /// A runtime check performed just before execution begins.
        /// Unlike preconditions (which are evaluated by the planner on simulated state),
        /// this is checked against the real world state at execution time.
        ///
        /// Use this to catch edge cases that the planner's simulation could not foresee.
        /// Example: checking if a path to a target is actually reachable.
        ///
        /// If this returns false after a plan is formed, the PlanExecutor
        /// will treat it as a failure and request a replan.
        /// </summary>
        bool IsExecutable(WorldState currentState);

        // - Execution Lifecycle -

        /// <summary>
        /// Called once when the PlanExecutor starts this action.
        /// Use for one-time setup: playing animations, reserving resources, etc.
        /// </summary>
        void OnStart(ActionContext context);

        /// <summary>
        /// Called every frame while this action is active.
        /// Return Continue() to continue, Complete() to signal success,
        /// or Fail() to trigger a replan.
        /// </summary>
        ActionStatus OnTick(ActionContext context);

        /// <summary>
        /// Called once when the action is stopped, for any reason.
        /// Use for cleanup: stopping animations, releasing resources, etc.
        /// The reason tells the action whether it finished normally or was cut short.
        /// </summary>
        void OnStop(ActionContext context, ActionStopReason reason);
    }
}