namespace GOAP.Sensing
{
    /// <summary>
    /// Defines when a sensor performs its update logic.
    /// Set per-sensor in the Inspector to balance accuracy vs performance.
    /// </summary>
    public enum SensorUpdateMode
    {
        /// <summary>
        /// The sensor updates every single frame.
        /// Use for time-critical perceptions that cannot afford any delay.
        /// Example: a sensor tracking a projectile in flight.
        /// Most expensive option.
        /// </summary>
        EveryFrame,

        /// <summary>
        /// The sensor updates at a fixed time interval defined by UpdateInterval.
        /// The recommended default for most sensors.
        /// Example: an enemy visibility sensor that checks every 0.2s.
        /// </summary>
        Interval,

        /// <summary>
        /// The sensor only updates when UpdateSensor() is called explicitly
        /// from outside (e.g. triggered by a physics event or animation event).
        /// Use when perception is event-driven rather than polling-based.
        /// Example: a noise sensor triggered by an OnTriggerEnter callback.
        /// </summary>
        Manual
    }
}