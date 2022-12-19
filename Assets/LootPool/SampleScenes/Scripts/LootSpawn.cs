using UnityEngine;

namespace LootSystem
{
    public class LootSpawn : MonoBehaviour
    {
        [SerializeField][Tooltip("Loot pool where the loot will be pulled from")]
        private LootPool lootPool;
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

        private void OnMouseDown()
        {
            if (spriteRenderer.enabled)
            {
                lootPool.SpawnDrop(transform, offsetRange, numIndependentPulls, numDependentPulls);
                spriteRenderer.enabled = false;

                GameObject explosion = Instantiate(particleSystemSimpleExplosion);
                Destroy(explosion, 4f);
            }
        }

        private void CheckForReset()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                spriteRenderer.enabled = true;
            }
        }
    }
}
