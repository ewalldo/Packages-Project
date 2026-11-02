using System;

namespace ChronoTools
{
    /// <summary>
    /// Convenience class to create timers that keep running forever.
    /// It is a <see cref="CountdownTimer"/> preconfigured to run indefinitely.
    /// </summary>
	public class PeriodicTimer : CountdownTimer
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="PeriodicTimer"/> class with the specified period time
        /// </summary>
        /// <param name="value">The period length, in seconds</param>
        public PeriodicTimer(float value)
            : base(value, loops:0)
        {
            if (value < 0f)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Period length must be greater than zero.");
        }

        /// <summary>
        /// Creates a <see cref="PeriodicTimer"/> from a frequency, i.e. how many periods should elapse per second.
        /// </summary>
        /// <param name="frequencyPerSecond">The number of periods per second</param>
        /// <returns>A new <see cref="PeriodicTimer"/> whose period length is 1 / <paramref name="frequencyPerSecond"/>.</returns>
        public static PeriodicTimer FromFrequency(float frequencyPerSecond)
        {
            if (frequencyPerSecond < 0)
                throw new ArgumentOutOfRangeException(nameof(frequencyPerSecond), frequencyPerSecond, "Frequency must be greater than zero.");

            return new PeriodicTimer(1f / frequencyPerSecond);
        }
    }
}