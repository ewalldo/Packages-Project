using UnityEngine;

namespace GOAP.Sample
{
    public class WorkStation : MonoBehaviour
    {
        [SerializeField] private LocationType stationType;
        [SerializeField] private ToolType requiredTool;
        [SerializeField] private ResourceType producedResource;
        [SerializeField] private Transform waypoint;
        [SerializeField, Min(0f)] private float energyCost = 20f;

        public LocationType StationType => stationType;
        public ToolType RequiredTool => requiredTool;
        public ResourceType ProducedResource => producedResource;
        public Transform Waypoint => waypoint;
        public float EnergyCost => energyCost;
    }
}
