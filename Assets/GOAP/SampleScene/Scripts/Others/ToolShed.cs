using System.Collections.Generic;
using UnityEngine;

namespace GOAP.Sample
{
    public class ToolShed : MonoBehaviour
    {
        [SerializeField] private Transform waypoint;
        [SerializeField] private Transform pickAxeAvailabilityVisual;
        [SerializeField] private Transform axeAvailabilityVisual;
        [SerializeField] private Transform hoeAvailabilityVisual;

        private readonly Dictionary<ToolType, VillagerStats> toolOwners = new Dictionary<ToolType, VillagerStats>
    {
        { ToolType.Pickaxe, null },
        { ToolType.Axe,     null },
        { ToolType.Hoe,     null }
    };

        public Transform Waypoint => waypoint;

        public bool IsToolAvailable(ToolType tool)
        {
            if (tool == ToolType.None)
            {
                Debug.LogWarning("[ToolShed] IsToolAvailable called with ToolType.None.", this);
                return false;
            }

            return toolOwners.TryGetValue(tool, out VillagerStats owner) && owner == null;
        }

        public bool TryClaimTool(ToolType tool, VillagerStats villager)
        {
            if (tool == ToolType.None)
                return false;

            if (!toolOwners.TryGetValue(tool, out VillagerStats currentOwner))
            {
                Debug.LogWarning($"[ToolShed] Unknown tool type: {tool}", this);
                return false;
            }

            if (currentOwner != null)
            {
                // Allow the same villager to re-claim (handles replanning)
                return currentOwner == villager;
            }

            toolOwners[tool] = villager;

            if (currentOwner == null)
                ToggleToolAvailabilityVisual(tool, false);

            return true;
        }

        public void ReturnTool(ToolType tool, VillagerStats villager)
        {
            if (tool == ToolType.None)
                return;

            if (!toolOwners.TryGetValue(tool, out VillagerStats currentOwner))
            {
                Debug.LogWarning($"[ToolShed] Tried to return unknown tool type: {tool}", this);
                return;
            }

            if (currentOwner != villager)
            {
                Debug.LogWarning($"[ToolShed] {villager.name} tried to return {tool} " +
                    $"but the owner is {currentOwner?.name ?? "nobody"}.", this);
                return;
            }

            toolOwners[tool] = null;
            ToggleToolAvailabilityVisual(tool, true);
        }

        public VillagerStats GetToolOwner(ToolType tool)
        {
            return toolOwners.TryGetValue(tool, out VillagerStats owner) ? owner : null;
        }

        private void ToggleToolAvailabilityVisual(ToolType tool, bool availability)
        {
            Transform visual = tool switch
            {
                ToolType.Pickaxe => pickAxeAvailabilityVisual,
                ToolType.Axe     => axeAvailabilityVisual,
                ToolType.Hoe     => hoeAvailabilityVisual,
                _ => null
            };
            if (visual != null)
                visual.gameObject.SetActive(availability);
        }
    }
}