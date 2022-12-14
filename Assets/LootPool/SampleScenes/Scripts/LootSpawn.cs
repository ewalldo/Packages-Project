using UnityEngine;

namespace LootSystem
{
    public class LootSpawn : MonoBehaviour
    {
        [SerializeField]
        private LootPool lootPool;
        [SerializeField]
        private int numIndependentPulls;
        [SerializeField]
        private int numDependentPulls;
        [SerializeField]
        private Vector3 offsetRange;

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
