using System;

namespace ChronoTools
{
    public abstract class Timer : IDisposable
	{
        protected float initialTime;

        /// <summary>
        /// Gets the current time of the timer
        /// </summary>
        public float CurrentTime { get; protected set; }
        /// <summary>
        /// Gets a value indicating whether the timer is currently running
        /// </summary>
        public bool IsRunning { get; private set; }

        public event Action OnTimerStart;
        public event Action OnTimerStop;
        public event Action OnTimerPaused;
        public event Action OnTimerResumed;

        public Timer(float value)
        {
            initialTime = value;
            CurrentTime = value;
        }

        /// <summary>
        /// Starts the timer execution
        /// </summary>
        public void Start()
        {
            CurrentTime = initialTime;
            IsRunning = true;
            OnTimerStart?.Invoke();
        }

        /// <summary>
        /// Stops the timer execution
        /// </summary>
        public void Stop()
        {
            IsRunning = false;
            OnTimerStop?.Invoke();
        }

        /// <summary>
        /// Resets the timer to its initial time
        /// </summary>
        public virtual void Reset() => CurrentTime = initialTime;
        /// <summary>
        /// Resets the timer to a new time value
        /// </summary>
        /// <param name="newTime">The new time value to reset the timer to</param>
        public virtual void Reset(float newTime)
        {
            initialTime = newTime;
            Reset();
        }

        /// <summary>
        /// Resumes the timer execution from a paused state
        /// </summary>
        public void Resume()
        {
            IsRunning = true;
            OnTimerResumed?.Invoke();
        }

        /// <summary>
        /// Pauses the timer execution
        /// </summary>
        public void Pause()
        {
            IsRunning = false;
            OnTimerPaused?.Invoke();
        }

        public abstract void Tick();
        public abstract float Progress { get; }

        public virtual void Dispose()
        {
            OnTimerStart = null;
            OnTimerStop = null;
            OnTimerPaused = null;
            OnTimerResumed = null;
        }
    }
}