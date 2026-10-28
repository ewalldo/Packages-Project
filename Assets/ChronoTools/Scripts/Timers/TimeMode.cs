namespace ChronoTools
{
    /// <summary>
    /// Selects which delta time to use on the parameterless <see cref="Timer.Tick()"/> method
    /// </summary>
    public enum TimeMode
	{
        /// <summary>
        /// >Uses <see cref="UnityEngine.Time.deltaTime"/>
        /// </summary>
		Scaled,

        /// <summary>
        /// Uses <see cref="UnityEngine.Time.unscaledDeltaTime"/>
        /// </summary>
        Unscaled
    }
}