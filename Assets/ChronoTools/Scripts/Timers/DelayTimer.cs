using System;

namespace ChronoTools
{
    /// <summary>
    /// Convenience class to create timers that invokes a callback once, after the given delay elapses.
    /// It is a <see cref="CountdownTimer"/> preconfigured to run a single time, with the callback wired to <see cref="CountdownTimer.OnComplete"/>.
    /// </summary>
    public class DelayTimer : CountdownTimer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DelayTimer"/> class
        /// </summary>
        /// <param name="value">The delay, in seconds, before the callback fires</param>
        /// <param name="onComplete">Optional callback invoked once when the delay elapses</param>
        public DelayTimer(float value, Action onComplete = null)
            : base(value, loops: 1)
        {
            if (onComplete != null)
                OnComplete += onComplete;
        }
    }
}