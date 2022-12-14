using UnityEngine;

namespace LootSystem
{
    public class LootBehaviour : MonoBehaviour
    {
        private Rigidbody lootRigidbody;

        private void Awake()
        {
            lootRigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            lootRigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }

        private void Update()
        {
            CheckForReset();
        }

        private void CheckForReset()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Destroy(gameObject);
            }
        }
    }
}
