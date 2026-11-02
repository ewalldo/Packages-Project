using UnityEngine;

namespace GOAP.Sensing
{
    /// <summary>
    /// Abstract MonoBehaviour base class for all GOAP sensors.
    /// Inherit from this to create concrete sensors and attach them
    /// as components on a GoapAgent's GameObject.
    ///
    /// Subclasses must implement:
    ///   - UpdateSense() : read from the world, write to WorldState and/or Blackboard
    ///
    /// Subclasses may optionally override:
    ///   - Initialize()       : cache references or subscribe to events
    ///   - OnSensorEnabled()  : resume after being re-enabled
    ///   - OnSensorDisabled() : pause or release when disabled
    ///   - Teardown()         : full cleanup on agent destruction
    /// </summary>
    public abstract class GoapSensor : MonoBehaviour, ISensor
    {
        // - Inspector -

        [Header("Sensor Settings")]
        [Tooltip("Human-readable name for this sensor. Defaults to class name if left empty.")]
        [SerializeField] private string sensorName;

        [Tooltip("Whether this sensor is active. Disabled sensors are fully skipped by the agent.")]
        [SerializeField] private bool isEnabled = true;

        [Tooltip("Controls when this sensor performs its update.")]
        [SerializeField] private SensorUpdateMode updateMode = SensorUpdateMode.Interval;

        [Tooltip("Seconds between updates when UpdateMode is Interval. Ignored otherwise.")]
        [SerializeField, Min(0f)] private float updateInterval = 0.2f;

        [Tooltip("If enabled, this sensor will log lifecycle and update events to the console.")]
        [SerializeField] private bool debugLog = false;

        // - Internal State -

        private float timeSinceLastUpdate;
        private bool isInitialized;

        // - ISensor: Identity -

        public string Name => string.IsNullOrEmpty(sensorName) ? GetType().Name : sensorName;

        // - ISensor: Configuration -

        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                if (isEnabled == value)
                    return;

                isEnabled = value;

                if (isEnabled)
                    OnSensorEnabled();
                else
                    OnSensorDisabled();
            }
        }

        public SensorUpdateMode UpdateMode => updateMode;
        public float UpdateInterval => updateInterval;

        // - ISensor: Lifecycle -

        /// <summary>
        /// Called once on agent initialization.
        /// Override to cache references or pre-allocate buffers.
        /// Always call base.Initialize() when overriding.
        /// </summary>
        public virtual void Initialize(SensorContext context)
        {
            timeSinceLastUpdate = 0f;
            isInitialized = true;

            if (debugLog)
                Debug.Log($"[GOAP][Sensor] Initialized: {Name}", this);
        }

        /// <summary>
        /// Entry point called by the GoapAgent each frame for active sensors.
        /// Handles interval logic internally — subclasses only implement UpdateSense().
        /// </summary>
        public void UpdateSensor(SensorContext context)
        {
            if (!isEnabled)
                return;

            if (!isInitialized)
            {
                Debug.LogWarning($"[GOAP][Sensor] {Name} was ticked before Initialize() was called.", this);
                return;
            }

            switch (updateMode)
            {
                case SensorUpdateMode.EveryFrame:
                    RunUpdate(context);
                    break;

                case SensorUpdateMode.Interval:
                    timeSinceLastUpdate += context.DeltaTime;
                    if (timeSinceLastUpdate >= updateInterval)
                    {
                        timeSinceLastUpdate = 0f;
                        RunUpdate(context);
                    }
                    break;

                case SensorUpdateMode.Manual:
                    // Manual sensors only update when ForceUpdate() is called explicitly
                    break;
            }
        }

        /// <summary>
        /// Forces an immediate sensor update regardless of UpdateMode or interval.
        /// Use this when an external event (physics, animation) should trigger perception.
        /// Only works when the sensor is enabled and initialized.
        /// </summary>
        public void ForceUpdate(SensorContext context)
        {
            if (!isEnabled || !isInitialized)
                return;

            timeSinceLastUpdate = 0f;
            RunUpdate(context);
        }

        /// <summary>
        /// <inheritdoc/>
        /// Always call base.OnSensorEnabled() when overriding.
        /// </summary>
        public virtual void OnSensorEnabled()
        {
            if (debugLog)
                Debug.Log($"[GOAP][Sensor] Enabled: {Name}", this);
        }

        /// <summary>
        /// <inheritdoc/>
        /// Always call base.OnSensorDisabled() when overriding.
        /// </summary>
        public virtual void OnSensorDisabled()
        {
            if (debugLog)
                Debug.Log($"[GOAP][Sensor] Disabled: {Name}", this);
        }

        /// <summary>
        /// <inheritdoc/>
        /// Always call base.Teardown() when overriding.
        /// </summary>
        public virtual void Teardown()
        {
            isInitialized = false;

            if (debugLog)
                Debug.Log($"[GOAP][Sensor] Torn down: {Name}", this);
        }

        // - Protected API -

        /// <summary>
        /// Override this to implement the actual perception logic for this sensor.
        /// Read from the game world and write results into context.WorldState and/or context.Blackboard.
        /// </summary>
        /// <example>
        /// protected override void UpdateSense(SensorContext context)
        /// {
        ///     bool canSeeEnemy = Physics.Linecast(context.AgentTransform.position, _enemy.position);
        ///     context.WorldState.Set(WorldKeys.IsEnemyVisible, canSeeEnemy);
        ///     context.Blackboard.Set("NearestEnemy", canSeeEnemy ? _enemy : null);
        /// }
        /// </example>
        public abstract void UpdateSense(SensorContext context);

        // - Private Helpers -

        private void RunUpdate(SensorContext context)
        {
            if (debugLog)
                Debug.Log($"[GOAP][Sensor] Updating: {Name} at t={context.TotalTime:F2}", this);

            UpdateSense(context);
        }
    }
}