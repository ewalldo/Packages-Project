using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace LootSystem
{
    public class LootSpawn : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField][Tooltip("Loot pool where the loot will be pulled from")]
        private LootPool independentLootPool;
        [SerializeField][Tooltip("Loot pool where the loot will be pulled from")]
        private LootPool dependentLootPool;
        [SerializeField][Tooltip("Number of pulls from the independent list")]
        private int numIndependentPulls;
        [SerializeField][Tooltip("Number of pulls from the dependent list")]
        private int numDependentPulls;
        [SerializeField][Tooltip("The offset range from this object transform")]
        private Vector3 offsetRange;
        [SerializeField][Tooltip("Effect to play when the loot is spawned")]
        private GameObject particleSystemSimpleExplosion;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            CheckForReset();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (spriteRenderer.enabled)
            {
                independentLootPool.SpawnDrop(transform.position, offsetRange, numIndependentPulls);
                dependentLootPool.SpawnDrop(transform.position, offsetRange, numDependentPulls);
                spriteRenderer.enabled = false;

                GameObject explosion = Instantiate(particleSystemSimpleExplosion);
                Destroy(explosion, 4f);
            }
        }

        private void CheckForReset()
        {
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                spriteRenderer.enabled = true;
            }
        }
    }
}
