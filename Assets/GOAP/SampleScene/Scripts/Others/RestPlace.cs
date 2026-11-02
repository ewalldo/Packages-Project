using UnityEngine;

namespace GOAP.Sample
{
    public class RestPlace : MonoBehaviour
    {
        [SerializeField] private LocationType placeType;
        [SerializeField] private Transform waypoint;
        [SerializeField, Min(0f)] private float energyRecoveryRate = 10f;

        private VillagerStats currentOccupant;

        public LocationType PlaceType => placeType;
        public Transform Waypoint => waypoint;
        public float EnergyRecoveryRate => energyRecoveryRate;
        public bool IsOccupied => currentOccupant != null;

        public bool TryOccupy(VillagerStats villager)
        {
            if (currentOccupant != null)
            {
                return currentOccupant == villager;
            }

            currentOccupant = villager;

            return true;
        }
        public void Vacate(VillagerStats villager)
        {
            if (currentOccupant != villager)
            {
                return;
            }

            currentOccupant = null;
        }
    }
}