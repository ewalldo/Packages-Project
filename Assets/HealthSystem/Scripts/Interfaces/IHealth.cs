using System;

namespace HealthSystem
{
	public interface IHealth
	{
		float GetHealth { get; }
		float GetHealthNormalized { get; }
		float GetMaxHealth { get; }
		bool IsDead { get; }
		bool IsOnCriticalHealth { get; }
		bool IsOnFullHealth { get; }

		event Action<float, float, object> OnCurrentHealthChanged;
		event Action<float, float, object> OnMaxHealthChanged;
		event Action<float, float, object> OnDamageTaken;
		event Action<float, float, object> OnDamageHealed;
		event Action OnCriticalHealthStarted;
		event Action OnCriticalHealthEnded;
		event Action<object> OnDeath;
		event Action<float, object> OnRevive;

		void TakeDamage(float amountDamage, object damageCauser);
		void Die(object deathCauser);
		void HealDamage(float amountHeal, object healingCauser);
		void HealToFull(object healingCauser);
		void SetMaxHealth(float newMaxHealth, bool updateToFullHealth, object changeCauser);
		void SetHealth(float newHealth, object changeCauser);
	}
}