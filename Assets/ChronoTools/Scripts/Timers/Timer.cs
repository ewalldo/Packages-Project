using System;
using UnityEngine;

namespace ChronoTools
{
    public abstract class Timer : ITimer
	{
        protected float initialTime;

        /// <summary>
        /// Gets the current time of the timer, in seconds
        /// </summary>
        public float CurrentTime { get; protected set; }
        /// <summary>
        /// Gets a value indicating whether the timer is currently running
        /// </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the timer is currently paused
        /// </summary>
        public bool IsPaused { get; private set; }

        /// <summary>
        /// Gets or sets which delta time to use when invoking the parameterless <see cref="Tick()"/> method.
        /// Ignored when advancing the timer with the parameter version <see cref="Tick(float)"/>
        /// </summary>
        public TimeMode Mode { get; set; } = TimeMode.Scaled;

        /// <summary>
        /// Gets or sets a speed multiplier applied to the delta on every tick.
        /// 1 = normal speed, 2 = twice as fast, 0.5 = half speed, 0 = frozen.
        /// Applies to both the parameterless <see cref="Tick()"/> and the parameter one <see cref="Tick(float)"/>.
        /// </summary>
        public float TimeScale { get; set; } = 1f;

        /// <summary>
        /// Gets the progress of the timer, normalized between 0 (just started) and 1 (finished)
        /// </summary>
        public virtual float Progress => initialTime <= 0f ? 1f : 1f - Mathf.Clamp01(CurrentTime / initialTime);

        public event Action OnTimerStart;
        public event Action OnTimerStop;
        public event Action OnTimerPaused;
        public event Action OnTimerResumed;

        /// <summary>
        /// Initializes a new instance of the Timer class
        /// </summary>
        /// <param name="value">The initial time value in seconds. Cannot be negative</param>
        public Timer(float value)
        {
            if (value < 0f)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Initial time cannot be negative.");

            initialTime = value;
            CurrentTime = value;
        }

        /// <summary>
        /// Starts (or restarts) the timer execution, resetting the timer to its initial state
        /// </summary>
        public void Start()
        {
            Reset();
            IsRunning = true;
            IsPaused = false;
            OnTimerStart?.Invoke();
        }

        /// <summary>
        /// Stops the timer execution. Does nothing if the timer is neither running nor paused
        /// </summary>
        public void Stop()
        {
            if (!IsRunning && !IsPaused)
                return;

            IsRunning = false;
            IsPaused = false;
            OnTimerStop?.Invoke();
        }

        /// <summary>
        /// Resets the timer to its initial time
        /// </summary>
        public virtual void Reset() => CurrentTime = initialTime;

        /// <summary>
        /// Resets the timer to a new time value
        /// </summary>
        /// <param name="newTime">The new time value to reset the timer to. Cannot be negative</param>
        public virtual void Reset(float newTime)
        {
            if (newTime < 0f)
                throw new ArgumentOutOfRangeException(nameof(newTime), newTime, "Reset time cannot be negative.");

            initialTime = newTime;
            Reset();
        }

        /// <summary>
        /// Resumes the timer execution from a paused state. Does nothing if the timer is not paused
        /// </summary>
        public void Resume()
        {
            if (!IsPaused)
                return;

            IsRunning = true;
            IsPaused = false;
            OnTimerResumed?.Invoke();
        }

        /// <summary>
        /// Pauses the timer execution. Does nothing if the timer is not currently running
        /// </summary>
        public void Pause()
        {
            if (!IsRunning)
                return;

            IsRunning = false;
            IsPaused = true;
            OnTimerPaused?.Invoke();
        }

        /// <summary>
        /// Advances the timer by the given amount of time, scaled by TimeScale
        /// </summary>
        /// <param name="deltaTime">The amount of time to advance in seconds</param>
        public void Tick(float deltaTime) => OnTick(deltaTime * TimeScale);

        /// <summary>
        /// Advances the timer using the delta time selected by Mode.
        /// Convenience overload intended to be called once per frame from a MonoBehaviour's Update.
        /// </summary>
        public void Tick() => Tick(GetDeltaTime());

        /// <summary>
        /// Releases the timer's event subscriptions
        /// </summary>
        public virtual void Dispose()
        {
            OnTimerStart = null;
            OnTimerStop = null;
            OnTimerPaused = null;
            OnTimerResumed = null;
        }

        /// <summary>
        /// Core per-tick update implemented by each timer type
        /// </summary>
        /// <param name="deltaTime">The already-scaled amount of time to advance in seconds</param>
        protected abstract void OnTick(float deltaTime);

        private float GetDeltaTime() => Mode == TimeMode.Unscaled ? Time.unscaledDeltaTime : Time.deltaTime;
    }
}