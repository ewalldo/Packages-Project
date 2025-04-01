using System;

namespace HealthSystem
{
	public interface IDamageable
	{
		event Action<float, float, object> OnDamageTaken;
		event Action<object> OnDeath;

		void TakeDamage(float amountDamage, object damageCauser);
		void Die(object deathCauser);
	}
}