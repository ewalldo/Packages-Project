using UnityEngine;

namespace ChronoTools
{
	public class StopwatchTimer : Timer
	{
        /// <summary>
        /// Gets the progress of the stopwatch as the current time (no upper limit)
        /// </summary>
        public override float Progress => CurrentTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="StopwatchTimer"/> class
        /// </summary>
        public StopwatchTimer()
            : base(0f) { }

        /// <summary>
        /// Updates the stopwatch timer by incrementing the time each tick
        /// </summary>
        public override void Tick()
        {
            if (IsRunning)
                CurrentTime += Time.deltaTime;
        }

        public override void Reset(float newTime)
        {
            Reset();
        }
    }
}