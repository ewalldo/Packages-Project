using System;
using UnityEngine;

namespace ChronoTools
{
	public class CountdownTimer : Timer
	{
        /// <summary>
        /// Gets the current progress of the countdown
        /// </summary>
        public override float Progress => 1f - Mathf.Clamp01(CurrentTime / initialTime);

        public event Action OnCountdownEnd;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountdownTimer"/> class with the specified countdown time
        /// </summary>
        /// <param name="value">The initial countdown time value</param>
        public CountdownTimer(float value)
            : base(value) { }

        /// <summary>
        /// Updates the countdown timer by decrementing the time each tick
        /// </summary>
        public override void Tick()
        {
            if (IsRunning && CurrentTime > 0)
                CurrentTime -= Time.deltaTime;

            if (IsRunning && CurrentTime <= 0)
            {
                Stop();
                OnCountdownEnd?.Invoke();
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            OnCountdownEnd = null;
        }
    }
}