using System;
using GOAP.WorldStates;
using UnityEngine;

namespace GOAP.Sensing
{
    /// <summary>
    /// Carries all runtime data a sensor needs during its update.
    /// Passed into every UpdateSense() call by the GoapAgent.
    ///
    /// Mirrors ActionContext from the Action layer — sensors should
    /// read from and write to this context rather than caching
    /// direct references to agent internals.
    /// </summary>
    public class SensorContext
    {
        // - Agent References -

        /// <summary>The GameObject that owns the GoapAgent running this sensor.</summary>
        public GameObject AgentObject { get; }

        /// <summary>Convenience shortcut to AgentObject.transform.</summary>
        public Transform AgentTransform { get; }

        // - Shared Data -

        /// <summary>
        /// The agent's live world state.
        /// Sensors write perception results here as typed facts.
        /// Example: state.Set(WorldKeys.IsEnemyVisible, true)
        /// </summary>
        public WorldState WorldState { get; }

        /// <summary>
        /// Shared key-value store for passing rich data (e.g. Transform references,
        /// distances, lists of targets) that cannot be expressed as WorldState facts.
        /// Sensors write here; actions and goals read from here.
        /// Example: blackboard.Set("NearestEnemy", enemyTransform)
        /// </summary>
        public Blackboard Blackboard { get; }

        // - Timing -

        /// <summary>
        /// The delta time for the current update tick.
        /// Provided so sensors do not call Time.deltaTime directly,
        /// making them easier to test.
        /// </summary>
        public float DeltaTime { get; private set; }

        /// <summary>Total time elapsed since this agent was started.</summary>
        public float TotalTime { get; private set; }

        // - Constructor -

        public SensorContext(GameObject agentObject, WorldState worldState, Blackboard blackboard)
        {
            AgentObject = agentObject ?? throw new ArgumentNullException(nameof(agentObject));
            WorldState = worldState  ?? throw new ArgumentNullException(nameof(worldState));
            Blackboard = blackboard  ?? throw new ArgumentNullException(nameof(blackboard));
            AgentTransform = agentObject.transform;
        }

        // - Internal Tick API (called by GoapAgent) -

        /// <summary>
        /// Updates timing data. Called once per frame by the GoapAgent
        /// before ticking any sensors.
        /// </summary>
        internal void Tick(float deltaTime, float totalTime)
        {
            DeltaTime = deltaTime;
            TotalTime = totalTime;
        }
    }
}