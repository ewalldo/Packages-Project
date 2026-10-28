using System;

namespace ChronoTools
{
	public interface ITimer : IReadOnlyTimer, IDisposable
    {
        TimeMode Mode { get; set; }
        float TimeScale { get; set; }

        event Action OnTimerStart;
        event Action OnTimerStop;
        event Action OnTimerPaused;
        event Action OnTimerResumed;

        void Start();
        void Stop();
        void Pause();
        void Resume();
        void Reset();
        void Reset(float newTime);

        void Tick(float deltaTime);
        void Tick();
    }
}