using GOAP.Sensing;

namespace GOAP.Sample
{
    public class RestPlaceAvailabilitySensor : GoapSensor
    {
        private RestPlace restaurant;
        private RestPlace house;

        public override void Initialize(SensorContext context)
        {
            base.Initialize(context);

            VillageManager villageManager = VillageManager.Instance;

            restaurant = villageManager.GetRestPlace(LocationType.Restaurant);
            house = villageManager.GetRestPlace(LocationType.House);
        }

        public override void UpdateSense(SensorContext context)
        {
            context.WorldState.Set(VillageWorldKeys.IsRestaurantFree, !restaurant.IsOccupied);
            context.WorldState.Set(VillageWorldKeys.IsHouseFree, !house.IsOccupied);
        }
    }
}