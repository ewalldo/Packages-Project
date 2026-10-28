using System;

namespace ChronoTools
{
	public class CountdownTimer : Timer
	{
        private int completedLoops;

        /// <summary>
        /// Gets or sets how many times the countdown runs.
        /// 1 runs it once. A value greater than 1 runs the countdown that many times. A value of 0 or less makes it loop forever.
        /// </summary>
        public int Loops { get; set; }

        /// <summary>
        /// True if the CountdownTimer is infinite (keep looping forever), false otherwise.
        /// </summary>
        public bool IsInfinite => Loops <= 0;

        /// <summary>
        /// Gets the number of completed loops since the last Start or Reset.
        /// </summary>
        public int CompletedLoops => completedLoops;

        /// <summary>
        /// Raised each time the countdown reaches zero (once per loop).
        /// </summary>
        public event Action OnCountdownEnd;

        /// <summary>
        /// Raised once when all loops have finished. Never raised on an infinite countdown.
        /// </summary>
        public event Action OnComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountdownTimer"/> class with the specified countdown time
        /// </summary>
        /// <param name="value">The initial countdown time value</param>
        /// <param name="loops">The amount of times the countdown should run. 1 = once (default); 0 or less = loop forever.</param>
        public CountdownTimer(float value, int loops = 1)
            : base(value)
        {
            if (value < 0f)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Countdown time must be greater than zero.");

            Loops = loops;
        }

        /// <summary>
        /// Advances the countdown by the given delta
        /// </summary>
        /// <param name="deltaTime">The amount of time to advance, in seconds</param>
        protected override void OnTick(float deltaTime)
        {
            if (!IsRunning)
                return;

            CurrentTime -= deltaTime;

            // while instead of if, for situations where deltaTime is big enough for multiple loops
            while (IsRunning && CurrentTime <= 0f)
            {
                completedLoops++;
                bool isFinalLoop = !IsInfinite && completedLoops >= Loops;

                if (isFinalLoop)
                    CurrentTime = 0f;

                OnCountdownEnd?.Invoke();

                if (isFinalLoop)
                {
                    Stop();
                    OnComplete?.Invoke();
                    return;
                }

                CurrentTime += initialTime; // roll over overshoot for the next loop
            }
        }

        /// <inheritdoc/>
        public override void Reset()
        {
            completedLoops = 0;
            base.Reset();
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            base.Dispose();
            OnCountdownEnd = null;
            OnComplete = null;
        }
    }
}