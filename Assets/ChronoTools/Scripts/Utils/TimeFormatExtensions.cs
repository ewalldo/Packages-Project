using System;

namespace ChronoTools
{
	public static class TimeFormatExtensions
	{
        /// <summary>
        /// Formats a duration in seconds using one of the predefined <see cref="ClockFormat"/> layouts.
        /// </summary>
        /// <param name="seconds">The duration to format, in seconds</param>
        /// <param name="format">The clock layout to use</param>
        /// <returns>The formatted clock string</returns>
        public static string ToClock(this float seconds, ClockFormat format = ClockFormat.Seconds)
        {
            if (float.IsNaN(seconds) || seconds < 0f)
                throw new ArgumentException(nameof(seconds), "Value cannot be converted to a clock representation.");

            TimeSpan t = TimeSpan.FromSeconds(seconds);

            switch (format)
            {
                case ClockFormat.Seconds:
                    return ((int)t.TotalSeconds).ToString();
                case ClockFormat.MinutesSeconds:
                    return string.Format("{0:00}:{1:00}", (int)t.TotalMinutes, t.Seconds);
                case ClockFormat.MinutesSecondsMillis:
                    return string.Format("{0:00}:{1:00}.{2:000}", (int)t.TotalMinutes, t.Seconds, t.Milliseconds);
                case ClockFormat.HoursMinutesSeconds:
                    return string.Format("{0:00}:{1:00}:{2:00}", (int)t.TotalHours, t.Minutes, t.Seconds);
                default:
                    throw new ArgumentException(nameof(format), "The clock format is not supported.");
            }
        }

        /// <summary>
        /// Formats a timer's <see cref="IReadOnlyTimer.CurrentTime"/> using a predefined <see cref="ClockFormat"/>.
        /// </summary>
        /// <param name="timer">The timer to format</param>
        /// <param name="format">The clock layout to use</param>
        /// <returns>The formatted clock string</returns>
        public static string ToClock(this IReadOnlyTimer timer, ClockFormat format = ClockFormat.Seconds) => timer.CurrentTime.ToClock(format);

        /// <summary>
        /// Formats a duration in seconds using a custom .NET <c>TimeSpan</c> format string (for example <c>@"mm\:ss\:fff"</c>).
        /// </summary>
        /// <param name="seconds">The duration to format, in seconds</param>
        /// <param name="format">A standard or custom <c>TimeSpan</c> format string</param>
        /// <returns>The formatted clock string</returns>
        public static string ToClock(this float seconds, string format)
        {
            if (float.IsNaN(seconds) || seconds < 0f)
                throw new ArgumentException(nameof(seconds), "Value cannot be converted to a clock representation.");

            return TimeSpan.FromSeconds(seconds).ToString(format);
        }
    }
}