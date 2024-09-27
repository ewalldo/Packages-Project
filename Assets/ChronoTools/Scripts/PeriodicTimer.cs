using System;
using UnityEngine;

namespace ChronoTools
{
	public class PeriodicTimer : Timer
	{
        /// <summary>
        /// Gets the current progress of the period
        /// </summary>
        public override float Progress => 1f - Mathf.Clamp01(CurrentTime / initialTime);

        public event Action OnPeriodEnd;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeriodicTimer"/> class with the specified period time
        /// </summary>
        /// <param name="value">The initial period time value</param>
        public PeriodicTimer(float value)
            : base(value) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PeriodicTimer"/> class with a specified number of ticks per second
        /// </summary>
        /// <param name="ticksPerSecond">The number of ticks the timer will perform per second</param>
        public PeriodicTimer(int frequencyPerSecond)
            : base(1f / frequencyPerSecond) { }

        /// <summary>
        /// Updates the periodic timer by decrementing the time each tick. Resets and restarts the timer at the end of each period.
        /// </summary>
        public override void Tick()
        {
            if (IsRunning && CurrentTime > 0)
                CurrentTime -= Time.deltaTime;

            if (IsRunning && CurrentTime <= 0)
            {
                OnPeriodEnd?.Invoke();
                Reset();
                Start();
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            OnPeriodEnd = null;
        }
    }
}