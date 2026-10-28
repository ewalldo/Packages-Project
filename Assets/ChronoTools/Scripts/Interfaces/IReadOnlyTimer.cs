namespace ChronoTools
{
	public interface IReadOnlyTimer
	{
        float CurrentTime { get; }

        bool IsRunning { get; }

        bool IsPaused { get; }

        float Progress { get; }
    }
}