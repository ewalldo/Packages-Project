using UnityEngine;

namespace LootSystem
{
    public class LootBehaviour : MonoBehaviour
    {
        private Rigidbody2D lootRigidbody;

        private void Awake()
        {
            lootRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            // Push the loot up when instantiated
            lootRigidbody.AddForce(Vector2.up * 7.5f, ForceMode2D.Impulse);
            Destroy(gameObject, 3f);
        }
    }
}
