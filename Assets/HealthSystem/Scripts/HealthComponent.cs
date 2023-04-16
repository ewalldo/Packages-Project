using System;
using UnityEngine;

namespace HealthSystem
{
	public class HealthComponent : MonoBehaviour
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

        private bool isCurrentlyAtCriticalHealth;

        /// <summary>
        /// Get the current health of the health component
        /// </summary>
        public float GetHealth => curHealth;

        /// <summary>
        /// Get the normalized current health of the health component
        /// </summary>
        public float GetHealthNormalized => curHealth / maxHealth;
        
        /// <summary>
        /// Get the maxHealth value of this health component
        /// </summary>
        public float GetMaxHealth => maxHealth;

        /// <summary>
        /// Check if the current health is zero or below
        /// </summary>
        public bool IsDead => curHealth <= 0f;

        /// <summary>
        /// Check if the current health is on a critical value
        /// </summary>
        public bool IsOnCriticalHealth => GetHealthNormalized <= criticalHealthThreshold;

        /// <summary>
        /// Check if the current health value is the same as the full health
        /// </summary>
        public bool IsOnFullHealth => curHealth == maxHealth;

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
            isCurrentlyAtCriticalHealth = IsOnCriticalHealth;
        }

        /// <summary>
        /// Apply damage to the healthComponent
        /// </summary>
        /// <param name="amountDamage">Amount of damage to cause</param>
        /// <param name="damageCauser">The object responsible to cause damage to this healthComponent</param>
        public void TakeDamage(float amountDamage, object damageCauser)
        {
            if (amountDamage < 0f)
                throw new ArgumentException("amountDamage cannot be a negative number");

            if (IsDead)
                return;

            SetHealth(curHealth - amountDamage, damageCauser);

            OnDamageTaken?.Invoke(amountDamage, curHealth, damageCauser);
        }

        /// <summary>
        /// Reduce the health value to zero
        /// </summary>
        /// <param name="deathCauser">The object responsible for the death</param>
        public void Die(object deathCauser)
        {
            curHealth = 0f;
            isCurrentlyAtCriticalHealth = false;
            OnDeath?.Invoke(deathCauser);
        }

        /// <summary>
        /// Apply healing to the healthComponent
        /// </summary>
        /// <param name="amountHeal">Amount of healing</param>
        /// <param name="healingCauser">The object responsible to heal this healthComponent</param>
        public void HealDamage(float amountHeal, object healingCauser)
        {
            if (amountHeal < 0f)
                throw new ArgumentException("amountHeal cannot be a negative number");

            SetHealth(curHealth + amountHeal, healingCauser);

            OnDamageHealed?.Invoke(amountHeal, curHealth, healingCauser);
        }

        /// <summary>
        /// Heal this healthComponent to its maximum capacity
        /// </summary>
        /// <param name="healingCauser">The object responsible to full heal this healthComponent</param>
        public void HealToFull(object healingCauser)
        {
            HealDamage(maxHealth - curHealth, healingCauser);
        }

        /// <summary>
        /// Update the maxHealth value of this component
        /// </summary>
        /// <param name="newMaxHealth">The new amount of maxHealth for this healthComponent</param>
        /// <param name="updateToFullHealth">Should the health value be replenished to full after modifying the max health?</param>
        /// <param name="changeCauser">The object responsible for modifying the maxHealth of this healthComponent</param>
        public void SetMaxHealth(float newMaxHealth, bool updateToFullHealth, object changeCauser)
        {
            if (newMaxHealth < 0f)
                throw new ArgumentException("newMaxHealth cannot be a negative number");

            if (maxHealth == newMaxHealth)
                return;

            float previousMaxHealth = maxHealth;

            maxHealth = newMaxHealth;

            if (updateToFullHealth || curHealth > newMaxHealth)
            {
                SetHealth(newMaxHealth, changeCauser);
            }

            CheckForCriticalChange();
            OnMaxHealthChanged?.Invoke(newMaxHealth - previousMaxHealth, newMaxHealth, changeCauser);
        }

        /// <summary>
        /// Set the health to a specific amount
        /// </summary>
        /// <param name="newHealth">The new amount of health this healthComponent will have</param>
        /// <param name="changeCauser">The object responsible for modify the health value of this healthComponent</param>
        public void SetHealth(float newHealth, object changeCauser)
        {
            if (curHealth == newHealth)
                return;

            float previousHealth = curHealth;

            curHealth = newHealth;

            if (curHealth > maxHealth)
            {
                curHealth = maxHealth;
            }
            else if (curHealth <= 0f)
            {
                Die(changeCauser);
            }

            if (previousHealth <= 0f && curHealth > 0f)
                OnRevive?.Invoke(curHealth, changeCauser);

            if (!IsDead)
                CheckForCriticalChange();

            OnCurrentHealthChanged?.Invoke(curHealth - previousHealth, curHealth, changeCauser);
        }

        private void CheckForCriticalChange()
        {
            if (isCurrentlyAtCriticalHealth && !IsOnCriticalHealth)
            {
                isCurrentlyAtCriticalHealth = IsOnCriticalHealth;
                OnCriticalHealthEnded?.Invoke();
            }
            else if (!isCurrentlyAtCriticalHealth && IsOnCriticalHealth)
            {
                isCurrentlyAtCriticalHealth = IsOnCriticalHealth;
                OnCriticalHealthStarted?.Invoke();
            }
        }
    }
}