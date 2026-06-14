namespace GOAP.Agent
{
    /// <summary>
    /// Contract for any subsystem that can be registered with and driven by a GoapAgent.
    ///
    /// Implementing this interface allows custom subsystems to hook into the
    /// agent's lifecycle (initialize, tick, shutdown) without coupling them
    /// directly to GoapAgent's implementation.
    ///
    /// Built-in implementations: GoalSelector, GoapPlanner, PlanExecutor.
    /// Custom implementations: inventory systems, squad coordinators, etc.
    ///
    /// Registered via GoapAgent.RegisterComponent().
    /// </summary>
    public interface IAgentComponent
    {
        /// <summary>
        /// Called once when the GoapAgent initializes.
        /// Use to cache references and perform one-time setup.
        /// </summary>
        /// <param name="agent">The agent that owns this component.</param>
        void Initialize(GoapAgent agent);

        /// <summary>
        /// Called every frame (or FixedUpdate) when the agent is Active.
        /// Implement per-frame logic here.
        /// deltaTime is provided explicitly for testability.
        /// </summary>
        void Tick(float deltaTime);

        /// <summary>
        /// Called when the agent transitions into a new AgentState.
        /// Allows components to pause, resume, or reset based on agent context.
        /// </summary>
        void OnAgentStateChanged(AgentState previousState, AgentState newState);

        /// <summary>
        /// Called once when the GoapAgent is destroyed or permanently disabled.
        /// Release all resources and unsubscribe from all events here.
        /// </summary>
        void Shutdown();
    }
}