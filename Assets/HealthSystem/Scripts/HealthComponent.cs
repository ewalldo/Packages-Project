using System;
using UnityEngine;

namespace HealthSystem
{
	public class HealthComponent : MonoBehaviour, IHealth, IDamageable, IHealable, IHealthStatus
    {
        public string GetNameOfMaxCurrentHealth => nameof(maxHealth);
        public string GetNameOfCurrentHealth => nameof(curHealth);
        public string GetNameOfStartAtMaxHealth => nameof(startAtMaxHealth);
        public string GetNameOfCriticalHealthThreshold => nameof(criticalHealthThreshold);

        [SerializeField]
        private float maxHealth;
        [SerializeField]
        private float curHealth;
        [SerializeField]
        private bool startAtMaxHealth;
        [SerializeField]
        private float criticalHealthThreshold;

        private Health health;

        /// <summary>
        /// Get the current health of the health component
        /// </summary>
        public float GetHealth => health.GetHealth;

        /// <summary>
        /// Get the normalized current health of the health component
        /// </summary>
        public float GetHealthNormalized => health.GetHealthNormalized;
        
        /// <summary>
        /// Get the maxHealth value of this health component
        /// </summary>
        public float GetMaxHealth => health.GetMaxHealth;

        /// <summary>
        /// Check if the current health is zero or below
        /// </summary>
        public bool IsDead => health.IsDead;

        /// <summary>
        /// Check if the current health is on a critical value
        /// </summary>
        public bool IsOnCriticalHealth => health.IsOnCriticalHealth;

        /// <summary>
        /// Check if the current health value is the same as the full health
        /// </summary>
        public bool IsOnFullHealth => health.IsOnFullHealth;

        /// <summary>
        /// Invoked when the current health value changes
        /// Parameters:
        /// changedAmount (float): How much has the health changed (positive value means heal and negative means damage)
        /// healthAfter (float): Amount of health after the change
        /// changeCauser (object): The object who caused the current health to change
        /// </summary>
        /// <param name="changedAmount">How much has the health changed (positive value means heal and negative means damage)</param>
        /// <param name="healthAfter">Amount of health after the change</param>"
        /// <param name="changeCauser">The object who caused the health to change</param>
        public event Action<float, float, object> OnCurrentHealthChanged;

        /// <summary>
        /// Invoked when the max health value changes
        /// Parameters:
        /// changedAmount (float): How much has the max health changed (positive value means increase and negative means decrease)
        /// maxHealthAfter (float): Amount of max health after the change
        /// changeCauser (object): The object who caused the max health to change
        /// </summary>
        /// <param name="changedAmount">How much has the max health changed (positive value means increase and negative means decrease)</param>
        /// <param name="maxHealthAfter">Amount of max health after the change</param>"
        /// <param name="changeCauser">The object who caused the max health to change</param>
        public event Action<float, float, object> OnMaxHealthChanged;

        /// <summary>
        /// Invoked when some damage is applied to the health
        /// Parameters:
        /// damageAmount (float): Amount of damage taken
        /// healthAfter (float): Amount of health after the damage is applied
        /// damageCauser (object): The object who caused damage
        /// </summary>
        /// <param name="damageAmount">Amount of damage taken</param>
        /// <param name="healthAfter">Amount of health after the damage is applied</param>
        /// <param name="damageCauser">The object who caused damage</param> 
        public event Action<float, float, object> OnDamageTaken;

        /// <summary>
        /// Invoked when some healing is applied to the health
        /// Parameters:
        /// healingAmount (float): Amount of healing
        /// healthAfter (float): Amount of health after the healing is applied
        /// healingCauser (object): The object who caused healing
        /// </summary>
        /// <param name="healingAmount">Amount of healing</param>
        /// <param name="healthAfter">Amount of health after the healing is applied</param>
        /// <param name="healingCauser">The object who caused healing</param>
        public event Action<float, float, object> OnDamageHealed;

        /// <summary>
        /// Invoked when the health reaches a critical value
        /// </summary>
        public event Action OnCriticalHealthStarted;

        /// <summary>
        /// Invoked when the health leaves the critical value threshold
        /// </summary>
        public event Action OnCriticalHealthEnded;

        /// <summary>
        /// Invoked when the health reaches 0
        /// Parameters:
        /// deathCauser (object): The object who caused the death
        /// </summary>
        /// <param name="deathCauser">The object who caused the death</param>
        public event Action<object> OnDeath;

        /// <summary>
        /// Invoked when the health goes from 0 to a positive value
        /// Parameters:
        /// healthAfter (float): Amount of health after the revive is applied
        /// reviveCauser (object): The object who caused the revive
        /// </summary>
        /// <param name="healthAfter">Amount of health after the revive is applied</param>
        /// <param name="reviveCauser">The object who caused the revive</param>
        public event Action<float, object> OnRevive;

        private void Awake()
        {
            health = new Health(maxHealth, curHealth, criticalHealthThreshold);

            health.OnCurrentHealthChanged += (changedAmount, healthAfter, changeCauser) => OnCurrentHealthChanged?.Invoke(changedAmount, healthAfter, changeCauser);
            health.OnMaxHealthChanged += (changedAmount, healthAfter, changeCauser) => OnMaxHealthChanged?.Invoke(changedAmount, healthAfter, changeCauser);
            health.OnDamageTaken += (damageAmount, healthAfter, damageCauser) => OnDamageTaken?.Invoke(damageAmount, healthAfter, damageCauser);
            health.OnDamageHealed += (healingAmount, healthAfter, healingCauser) => OnDamageHealed?.Invoke(healingAmount, healthAfter, healingCauser);
            health.OnCriticalHealthStarted += () => OnCriticalHealthStarted?.Invoke();
            health.OnCriticalHealthEnded += () => OnCriticalHealthEnded?.Invoke();
            health.OnDeath += (deathCauser) => OnDeath?.Invoke(deathCauser);
            health.OnRevive += (healthAfter, reviveCauser) => OnRevive?.Invoke(healthAfter, reviveCauser);
        }

        /// <summary>
        /// Apply damage to the healthComponent
        /// </summary>
        /// <param name="amountDamage">Amount of damage to cause</param>
        /// <param name="damageCauser">The object responsible to cause damage to this healthComponent</param>
        public void TakeDamage(float amountDamage, object damageCauser)
        {
            health.TakeDamage(amountDamage, damageCauser);
        }

        /// <summary>
        /// Reduce the health value to zero
        /// </summary>
        /// <param name="deathCauser">The object responsible for the death</param>
        public void Die(object deathCauser)
        {
            health.Die(deathCauser);
        }

        /// <summary>
        /// Apply healing to the healthComponent
        /// </summary>
        /// <param name="amountHeal">Amount of healing</param>
        /// <param name="healingCauser">The object responsible to heal this healthComponent</param>
        public void HealDamage(float amountHeal, object healingCauser)
        {
            health.HealDamage(amountHeal, healingCauser);
        }

        /// <summary>
        /// Heal this healthComponent to its maximum capacity
        /// </summary>
        /// <param name="healingCauser">The object responsible to full heal this healthComponent</param>
        public void HealToFull(object healingCauser)
        {
            health.HealToFull(healingCauser);
        }

        /// <summary>
        /// Update the maxHealth value of this component
        /// </summary>
        /// <param name="newMaxHealth">The new amount of maxHealth for this healthComponent</param>
        /// <param name="updateToFullHealth">Should the health value be replenished to full after modifying the max health?</param>
        /// <param name="changeCauser">The object responsible for modifying the maxHealth of this healthComponent</param>
        public void SetMaxHealth(float newMaxHealth, bool updateToFullHealth, object changeCauser)
        {
            health.SetMaxHealth(newMaxHealth, updateToFullHealth, changeCauser);
        }

        /// <summary>
        /// Set the health to a specific amount
        /// </summary>
        /// <param name="newHealth">The new amount of health this healthComponent will have</param>
        /// <param name="changeCauser">The object responsible for modify the health value of this healthComponent</param>
        public void SetHealth(float newHealth, object changeCauser)
        {
            health.SetHealth(newHealth, changeCauser);
        }
    }
}