namespace GOAP.Agent
{
    /// <summary>
    /// Controls which Unity update loop the GoapAgent uses to tick its subsystems.
    /// Choose based on the nature of the agent's actions and physics requirements.
    /// </summary>
    public enum AgentTickMode
    {
        /// <summary>
        /// Agent ticks in Unity's Update() loop.
        /// Recommended for most agents — aligns with rendering and input.
        /// </summary>
        Update,

        /// <summary>
        /// Agent ticks in Unity's FixedUpdate() loop.
        /// Use when agent actions directly manipulate Rigidbodies.
        /// </summary>
        FixedUpdate,

        /// <summary>
        /// The agent does not tick itself.
        /// An external system (e.g. a manager or ECS bridge) must call Tick() manually.
        /// Useful for batch-updating large numbers of agents.
        /// </summary>
        Manual
    }
}