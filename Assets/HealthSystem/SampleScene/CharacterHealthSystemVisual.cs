using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HealthSystem
{
	public class CharacterHealthSystemVisual : MonoBehaviour
	{
		[SerializeField] private HealthComponent healthComponent;
        [SerializeField] private Image healthBar;
        [SerializeField] private GameObject numberIndicator;

        [SerializeField] private GameObject aliveEyes;
        [SerializeField] private GameObject deadEyes;

        private Animator animator;

        private bool shouldAnimateHealthBar;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            healthComponent.OnDamageTaken += HealthComponent_OnDamageTaken;
            healthComponent.OnDamageHealed += HealthComponent_OnDamageHealed;
            
            healthComponent.OnDeath += HealthComponent_OnDeath;
            healthComponent.OnRevive += HealthComponent_OnRevive;

            healthComponent.OnCriticalHealthStarted += HealthComponent_OnCriticalHealthStarted;
            healthComponent.OnCriticalHealthEnded += HealthComponent_OnCriticalHealthEnded;

            UpdateHealthBar(healthComponent.GetHealthNormalized);
            shouldAnimateHealthBar = healthComponent.IsOnCriticalHealth;
        }

        private void Update()
        {
            if (shouldAnimateHealthBar)
            {
                float speed = 10f;
                float variance = 0.25f;
                float baseValue = 0.75f;
                float healthBarAlpha = Mathf.Sin(Time.time * speed) * variance + baseValue;
                healthBar.color = new Color(healthBar.color.r, healthBar.color.g, healthBar.color.b, healthBarAlpha);
            }
        }

        private void HealthComponent_OnCriticalHealthEnded()
        {
            healthBar.color = new Color(healthBar.color.r, healthBar.color.g, healthBar.color.b, 1f);
            shouldAnimateHealthBar = false;
            animator.speed = 1f;
        }

        private void HealthComponent_OnCriticalHealthStarted()
        {
            shouldAnimateHealthBar = true;
            animator.speed = 2f;
        }

        private void HealthComponent_OnRevive(float arg1, object arg2)
        {
            aliveEyes.SetActive(true);
            deadEyes.SetActive(false);

            animator.enabled = true;
        }

        private void HealthComponent_OnDeath(object obj)
        {
            aliveEyes.SetActive(false);
            deadEyes.SetActive(true);

            animator.enabled = false;
        }

        private void HealthComponent_OnDamageTaken(float damageAmount, float healthAfter, object damageCauser)
        {
            UpdateHealthBar(healthComponent.GetHealthNormalized);

            CreateNumberIndicator("-" + damageAmount.ToString(), Color.red, true, new Vector3(1f, 1f, 0f), 2.5f);
        }

        private void HealthComponent_OnDamageHealed(float healingAmount, float healthAfter, object healingCauser)
        {
            UpdateHealthBar(healthComponent.GetHealthNormalized);

            CreateNumberIndicator("+" + healingAmount.ToString(), Color.green, false, new Vector3(0f, 1f, 0f), 1f);
        }

        private void UpdateHealthBar(float amount)
        {
            healthBar.fillAmount = amount;
        }

        private void CreateNumberIndicator(string text, Color indicatorColor, bool useGravity, Vector3 launchDirection, float launchSpeed)
        {
            GameObject spawnedNumberIndicator = Instantiate(numberIndicator, transform);
            float yOffset = 0.25f;
            spawnedNumberIndicator.transform.position = healthBar.transform.position + (Vector3.up * yOffset);
            spawnedNumberIndicator.GetComponent<TextMeshPro>().text = text;
            spawnedNumberIndicator.GetComponent<TextMeshPro>().color = indicatorColor;

            spawnedNumberIndicator.GetComponent<Rigidbody>().useGravity = useGravity;
            spawnedNumberIndicator.GetComponent<Rigidbody>().AddForce(launchDirection * launchSpeed, ForceMode.VelocityChange);
            Destroy(spawnedNumberIndicator, 0.5f);
        }
    }
}