using UnityEngine;

namespace GOAP.Sample
{
    public class VillagerNavigator : MonoBehaviour
    {
        [SerializeField, Min(0.1f)] private float moveSpeed = 3f;
        [SerializeField, Min(0.1f)] private float rotateSpeed = 5f;
        [SerializeField, Min(0.01f)] private float stoppingDistance = 0.15f;

        private Vector3 destination;
        private bool isMoving;

        public bool IsMoving => isMoving;

        private void Update()
        {
            if (!isMoving)
                return;

            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            transform.forward = Vector3.Slerp(transform.forward, destination - transform.position, rotateSpeed * Time.deltaTime);

            if (HasReachedDestination())
            {
                Stop();
            }
        }

        public void MoveTo(Vector3 newDestination)
        {
            destination = newDestination;
            isMoving = true;
        }

        public bool HasReachedDestination()
        {
            if (!isMoving)
                return true;

            float sqrDist = (transform.position - destination).sqrMagnitude;
            return sqrDist <= stoppingDistance * stoppingDistance;
        }

        public void Stop()
        {
            isMoving = false;
            destination = transform.position;
        }
    }
}