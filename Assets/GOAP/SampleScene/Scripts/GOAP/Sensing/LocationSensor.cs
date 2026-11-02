using GOAP.Sensing;
using UnityEngine;

namespace GOAP.Sample
{
    public class LocationSensor : GoapSensor
    {
        [SerializeField, Min(0.1f)] private float arrivalThreshold = 0.5f;

        private VillageManager villageManager;

        private Transform restaurantWaypoint;
        private Transform houseWaypoint;
        private Transform toolShedWaypoint;
        private Transform mineWaypoint;
        private Transform forestWaypoint;
        private Transform farmWaypoint;

        public override void Initialize(SensorContext context)
        {
            base.Initialize(context);

            villageManager = VillageManager.Instance;

            restaurantWaypoint = villageManager.GetRestPlace(LocationType.Restaurant).Waypoint;
            houseWaypoint = villageManager.GetRestPlace(LocationType.House).Waypoint;
            toolShedWaypoint = villageManager.ToolShed.Waypoint;
            mineWaypoint = villageManager.GetWorkStation(LocationType.Mine).Waypoint;
            forestWaypoint = villageManager.GetWorkStation(LocationType.Forest).Waypoint;
            farmWaypoint = villageManager.GetWorkStation(LocationType.Farm).Waypoint;
        }

        public override void UpdateSense(SensorContext context)
        {
            Vector3 position = context.AgentTransform.position;

            context.WorldState.Set(VillageWorldKeys.IsAtRestaurant, IsNear(position, restaurantWaypoint));
            context.WorldState.Set(VillageWorldKeys.IsAtHouse, IsNear(position, houseWaypoint));
            context.WorldState.Set(VillageWorldKeys.IsAtToolShed, IsNear(position, toolShedWaypoint));
            context.WorldState.Set(VillageWorldKeys.IsAtMine, IsNear(position, mineWaypoint));
            context.WorldState.Set(VillageWorldKeys.IsAtForest, IsNear(position, forestWaypoint));
            context.WorldState.Set(VillageWorldKeys.IsAtFarm, IsNear(position, farmWaypoint));
        }

        private bool IsNear(Vector3 position, Transform waypoint)
        {
            //return Vector3.Distance(position, waypoint.position) <= _arrivalThreshold;
            float sqrThreshold = arrivalThreshold * arrivalThreshold;
            return (position - waypoint.position).sqrMagnitude <= sqrThreshold;
        }
    }
}