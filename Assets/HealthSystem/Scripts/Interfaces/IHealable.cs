using System;

namespace HealthSystem
{
	public interface IHealable
	{
		event Action<float, float, object> OnDamageHealed;
		event Action<float, object> OnRevive;

		void HealDamage(float amountHeal, object healingCauser);
		void HealToFull(object healingCauser);
	}
}