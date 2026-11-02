using GOAP.WorldStates;

namespace GOAP.Sample
{
    public static class VillageWorldKeys
    {
        // Energy
        public static readonly WorldStateKey IsEnergyLow = new WorldStateKey("IsEnergyLow");
        public static readonly WorldStateKey IsEnergyFull = new WorldStateKey("IsEnergyFull");

        // Location
        public static readonly WorldStateKey IsAtRestaurant = new WorldStateKey("IsAtRestaurant");
        public static readonly WorldStateKey IsAtHouse = new WorldStateKey("IsAtHouse");
        public static readonly WorldStateKey IsAtToolShed = new WorldStateKey("IsAtToolShed");
        public static readonly WorldStateKey IsAtMine = new WorldStateKey("IsAtMine");
        public static readonly WorldStateKey IsAtForest = new WorldStateKey("IsAtForest");
        public static readonly WorldStateKey IsAtFarm = new WorldStateKey("IsAtFarm");

        // Tools
        public static readonly WorldStateKey IsHoldingTool = new WorldStateKey("IsHoldingTool");
        public static readonly WorldStateKey HeldToolType = new WorldStateKey("HeldToolType");

        public static readonly WorldStateKey IsPickaxeAvailable = new WorldStateKey("IsPickaxeAvailable");
        public static readonly WorldStateKey IsAxeAvailable = new WorldStateKey("IsAxeAvailable");
        public static readonly WorldStateKey IsHoeAvailable = new WorldStateKey("IsHoeAvailable");

        // Rest
        public static readonly WorldStateKey IsRestaurantFree = new WorldStateKey("IsRestaurantFree");
        public static readonly WorldStateKey IsHouseFree = new WorldStateKey("IsHouseFree");

        // Work
        public static readonly WorldStateKey HasWorked = new WorldStateKey("HasWorked");

        // Wait
        public static readonly WorldStateKey IsWaiting = new WorldStateKey("IsWaiting");
    }
}