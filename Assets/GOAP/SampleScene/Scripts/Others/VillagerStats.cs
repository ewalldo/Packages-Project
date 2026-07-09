using UnityEngine;

namespace GOAP.Sample
{
    public class VillagerStats : MonoBehaviour
    {
        [SerializeField, Min(1f)] private float maxEnergy = 100f;
        [SerializeField, Min(0f)] private float startingEnergy = 100f;

        [SerializeField, Min(0f)] private float energyLowThreshold = 30f;
        [SerializeField, Min(0f)] private float energyFullThreshold = 90f;

        private float currentEnergy;
        private ToolType heldTool = ToolType.None;

        public float Energy => currentEnergy;
        public float MaxEnergy => maxEnergy;
        public bool IsEnergyLow => currentEnergy <= energyLowThreshold;
        public bool IsEnergyFull => currentEnergy >= energyFullThreshold;

        public ToolType HeldTool => heldTool;
        public bool IsHoldingTool => heldTool != ToolType.None;

        private void Awake()
        {
            currentEnergy = Mathf.Clamp(startingEnergy, 0f, maxEnergy);
        }

        public void ConsumeEnergy(float amount)
        {
            currentEnergy = Mathf.Max(0f, currentEnergy - amount);
        }

        public void RecoverEnergy(float amount)
        {
            currentEnergy = Mathf.Min(maxEnergy, currentEnergy + amount);
        }

        public void SetHeldTool(ToolType tool) => heldTool = tool;
    }
}
