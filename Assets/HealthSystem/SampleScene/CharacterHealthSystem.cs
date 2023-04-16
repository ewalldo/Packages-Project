using System.Collections.Generic;
using UnityEngine;

namespace HealthSystem
{
	public class CharacterHealthSystem : MonoBehaviour
	{
        [SerializeField] private List<Collider> hitBoxes;
        [SerializeField] private float damageAmount;
        [SerializeField] private float healingAmount;

        private Camera gameCamera;

        private HealthComponent healthComponent;
        private enum ClickType { DamageClick, HealClick }

        private void Awake()
        {
            gameCamera = Camera.main;
            healthComponent = GetComponent<HealthComponent>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckForCollision(ClickType.DamageClick);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                CheckForCollision(ClickType.HealClick);
            }
        }

        private void CheckForCollision(ClickType clickType)
        {
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hitBoxes.Contains(hit.collider))
                {
                    switch (clickType)
                    {
                        case ClickType.DamageClick:
                            healthComponent.TakeDamage(damageAmount, this);
                            break;
                        case ClickType.HealClick:
                            healthComponent.HealDamage(healingAmount, this);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}