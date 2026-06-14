namespace GOAP.Sensing
{
    /// <summary>
    /// Defines the contract for any sensor in the GOAP system.
    ///
    /// A sensor is responsible for reading data from the game world
    /// and writing perception results into the agent's WorldState and Blackboard.
    /// Sensors are the only layer that should write to the WorldState at runtime —
    /// all other layers only read from it.
    ///
    /// Sensor lifecycle per agent tick:
    ///   IsEnabled check → interval check → UpdateSense() → writes to WorldState/Blackboard
    /// </summary>
    public interface ISensor
    {
        // - Identity -

        /// <summary>Human-readable name used for debugging and editor tooling.</summary>
        string Name { get; }

        // - Configuration -

        /// <summary>
        /// Whether this sensor is currently active and should be ticked.
        /// Disabled sensors are skipped entirely by the GoapAgent.
        /// </summary>
        bool IsEnabled { get; set; }

        /// <summary>
        /// How this sensor decides when to run its update logic.
        /// </summary>
        SensorUpdateMode UpdateMode { get; }

        /// <summary>
        /// How many seconds between updates when UpdateMode is Interval.
        /// Ignored for EveryFrame and Manual modes.
        /// </summary>
        float UpdateInterval { get; }

        // - Lifecycle -

        /// <summary>
        /// Called once by the GoapAgent when the agent initializes.
        /// Use to cache references, pre-allocate buffers, or subscribe to events.
        /// </summary>
        void Initialize(SensorContext context);

        /// <summary>
        /// Performs the actual perception logic.
        /// Reads from the game world and writes results into
        /// context.WorldState and/or context.Blackboard.
        /// Called by the GoapAgent according to the sensor's UpdateMode.
        /// </summary>
        void UpdateSense(SensorContext context);

        /// <summary>
        /// Called when this sensor is enabled after being disabled.
        /// Use to resume subscriptions or reset stale state.
        /// </summary>
        void OnSensorEnabled();

        /// <summary>
        /// Called when this sensor is disabled.
        /// Use to pause subscriptions or release resources.
        /// </summary>
        void OnSensorDisabled();

        /// <summary>
        /// Called once by the GoapAgent when it is destroyed or disabled permanently.
        /// Use to release all resources and unsubscribe from all events.
        /// </summary>
        void Teardown();
    }
}