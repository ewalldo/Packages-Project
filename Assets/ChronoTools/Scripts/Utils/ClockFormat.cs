namespace ChronoTools
{
	public enum ClockFormat
	{
        /// <summary>
        /// Total whole seconds, e.g. "90"
        /// </summary>
		Seconds,

        /// <summary>
        /// Minutes and seconds, e.g. "01:30"
        /// </summary>
        MinutesSeconds,

        /// <summary>
        /// Minutes, seconds and milliseconds, e.g. "01:30.250"
        /// </summary>
        MinutesSecondsMillis,

        /// <summary>
        /// Hours, minutes and seconds, e.g. "01:01:01"
        /// </summary>
		HoursMinutesSeconds
    }
}