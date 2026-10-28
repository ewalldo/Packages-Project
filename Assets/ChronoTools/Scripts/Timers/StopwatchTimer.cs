using System;
using System.Collections.Generic;

namespace ChronoTools
{
	public class StopwatchTimer : Timer
	{
        private readonly List<float> laps = new List<float>();
        private float lastLapTime;

        /// <summary>
        /// Gets the elapsed time of the stopwatch, in seconds.
        /// </summary>
        public override float Progress => CurrentTime;

        /// <summary>
        /// Gets the recorded laps as split times, i.e. each entry is the time elapsed since the previous lap.
        /// </summary>
        public IReadOnlyList<float> Laps => laps;

        /// <summary>
        /// Gets the number of laps recorded since the last Start or Reset.
        /// </summary>
        public int LapCount => laps.Count;

        /// <summary>
        /// Raised each time a lap is recorded, passing the split time for that lap.
        /// </summary>
        public event Action<float> OnLap;

        /// <summary>
        /// Initializes a new instance of the <see cref="StopwatchTimer"/> class
        /// </summary>
        public StopwatchTimer()
            : base(0f) { }

        /// <summary>
        /// Advances the stopwatch by the given delta
        /// </summary>
        /// <param name="deltaTime">The amount of time to advance, in seconds</param>
        protected override void OnTick(float deltaTime)
        {
            if (!IsRunning)
                return;

            CurrentTime += deltaTime;
        }

        /// <summary>
        /// Records a lap and returns its split time (the elapsed time since the previous lap).
        /// </summary>
        /// <returns>The split time for the recorded lap, in seconds</returns>
        public float Lap()
        {
            float split = CurrentTime - lastLapTime;
            lastLapTime = CurrentTime;

            laps.Add(split);
            OnLap?.Invoke(split);

            return split;
        }

        /// <summary>
        /// Returns the recorded laps as cumulative totals, i.e. each entry is the total elapsed time at the moment that lap was recorded.
        /// This list is a snapshot, it is not updated afterwards.
        /// </summary>
        /// <returns>A new list of cumulative lap times, in seconds</returns>
        public List<float> GetCumulativeLaps()
        {
            List<float> cumulative = new List<float>(laps.Count);
            float running = 0f;

            foreach (float split in laps)
            {
                running += split;
                cumulative.Add(running);
            }

            return cumulative;
        }

        /// <inheritdoc/>
        public override void Reset()
        {
            laps.Clear();
            lastLapTime = 0f;
            base.Reset();
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            base.Dispose();
            OnLap = null;
        }
    }
}