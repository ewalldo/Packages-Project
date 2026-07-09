using System.Collections.Generic;
using UnityEngine;

namespace GOAP.Sample
{
    public class VillageManager : MonoBehaviour
    {
        [SerializeField] private ToolShed toolShed;
        [SerializeField] private List<RestPlace> restPlaces = new List<RestPlace>();
        [SerializeField] private List<WorkStation> workStations = new List<WorkStation>();

        private readonly Dictionary<ResourceType, float> resourceCounts = new Dictionary<ResourceType, float>();

        public ToolShed ToolShed => toolShed;
        public IReadOnlyList<RestPlace> GetAllRestPlaces() => restPlaces;
        public IReadOnlyList<WorkStation> GetAllWorkStations() => workStations;

        public static VillageManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogWarning("[VillageManager] Duplicate instance destroyed.", this);
                Destroy(gameObject);
                return;
            }

            Instance = this;
            InitializeResourceCounts();
        }

        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
        }

        public RestPlace GetRestPlace(LocationType locationType)
        {
            foreach (RestPlace place in restPlaces)
            {
                if (place.PlaceType == locationType)
                    return place;
            }

            Debug.LogWarning($"[VillageManager] No RestPlace found for LocationType: {locationType}");
            return null;
        }

        public WorkStation GetWorkStation(LocationType locationType)
        {
            foreach (WorkStation station in workStations)
            {
                if (station.StationType == locationType)
                    return station;
            }

            Debug.LogWarning($"[VillageManager] No WorkStation found for LocationType: {locationType}");
            return null;
        }

        public WorkStation GetWorkStationForTool(ToolType toolType)
        {
            foreach (WorkStation station in workStations)
            {
                if (station.RequiredTool == toolType)
                    return station;
            }

            Debug.LogWarning($"[VillageManager] No WorkStation found for ToolType: {toolType}");
            return null;
        }

        public void RegisterGatheredResource(ResourceType resource, float amount = 1)
        {
            if (resource == ResourceType.None)
                return;

            resourceCounts[resource] += amount;
        }

        public float GetResourceCount(ResourceType resource)
        {
            return resourceCounts.TryGetValue(resource, out float count) ? count : 0;
        }

        private void InitializeResourceCounts()
        {
            resourceCounts[ResourceType.Ore] = 0;
            resourceCounts[ResourceType.Wood] = 0;
            resourceCounts[ResourceType.Crop] = 0;
        }
    }
}
