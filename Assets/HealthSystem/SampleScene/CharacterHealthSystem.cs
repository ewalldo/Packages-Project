using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                CheckForCollision(ClickType.DamageClick);
            }
            else if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                CheckForCollision(ClickType.HealClick);
            }
        }

        private void CheckForCollision(ClickType clickType)
        {
            Ray ray = gameCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
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