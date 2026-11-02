using System;
using GOAP.Sensing;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Actions
{
    /// <summary>
    /// Carries all runtime data an action needs during execution.
    /// Created once per plan execution cycle and passed to every
    /// OnStart(), OnTick(), and OnStop() call.
    ///
    /// Actions should read from this context rather than caching
    /// direct references to agent internals, keeping actions decoupled.
    /// </summary>
    public class ActionContext
    {
        // - Agent References -

        /// <summary>The GameObject that owns the GoapAgent running this action.</summary>
        public GameObject AgentObject { get; }

        /// <summary>The Transform of the agent. Convenience shortcut to AgentObject.transform.</summary>
        public Transform AgentTransform { get; }

        // - State -

        /// <summary>
        /// The agent's live world state.
        /// Actions can read from this during execution.
        /// They should NOT write to it directly, effects are applied
        /// by the PlanExecutor after OnTick() returns Completed.
        /// </summary>
        public WorldState CurrentWorldState { get; }

        /// <summary>
        /// A shared key-value store for passing data between sensors,
        /// actions, and goals without direct coupling.
        /// Example: a sensor writes "NearestEnemy" to the blackboard,
        /// and a MoveToEnemy action reads it from here.
        /// </summary>
        public Blackboard Blackboard { get; }

        // - Timing -

        /// <summary>Time in seconds since the current action was started.</summary>
        public float TimeSinceActionStarted { get; private set; }

        /// <summary>
        /// The delta time for the current tick.
        /// Provided here so actions don't need to call Time.deltaTime directly,
        /// making them easier to test.
        /// </summary>
        public float DeltaTime { get; private set; }

        // - Constructor -

        public ActionContext(GameObject agentObject, WorldState currentWorldState, Blackboard blackboard)
        {
            AgentObject = agentObject ?? throw new ArgumentNullException(nameof(agentObject));
            CurrentWorldState = currentWorldState ?? throw new ArgumentNullException(nameof(currentWorldState));
            Blackboard = blackboard ?? throw new ArgumentNullException(nameof(blackboard));
            AgentTransform = agentObject.transform;
        }

        // - Internal Tick API (called by PlanExecutor) -

        /// <summary>
        /// Updates timing data. Called by the PlanExecutor once per frame,
        /// before OnTick() is called on the active action.
        /// </summary>
        internal void Tick(float deltaTime)
        {
            DeltaTime = deltaTime;
            TimeSinceActionStarted += deltaTime;
        }

        /// <summary>
        /// Resets the elapsed time counter.
        /// Called by the PlanExecutor each time a new action is started.
        /// </summary>
        internal void ResetTimer()
        {
            DeltaTime = 0f;
            TimeSinceActionStarted = 0f;
        }
    }
}