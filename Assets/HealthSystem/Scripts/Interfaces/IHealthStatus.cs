using System;

namespace HealthSystem
{
	public interface IHealthStatus
	{
		float GetHealth { get; }
		float GetHealthNormalized { get; }
		float GetMaxHealth { get; }
		bool IsDead { get; }
		bool IsOnCriticalHealth { get; }
		bool IsOnFullHealth { get; }

		event Action OnCriticalHealthStarted;
		event Action OnCriticalHealthEnded;
	}
}