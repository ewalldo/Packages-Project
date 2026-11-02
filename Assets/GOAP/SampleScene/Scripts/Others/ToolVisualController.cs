using UnityEngine;

namespace GOAP.Sample
{
    public class ToolVisualController : MonoBehaviour
    {
        [SerializeField] private Transform pickAxeVisual;
        [SerializeField] private Transform axeVisual;
        [SerializeField] private Transform hoeVisual;

        public void ToggleToolVisual(ToolType tool, bool visualActive)
        {
            Transform visual = tool switch
            {
                ToolType.Pickaxe => pickAxeVisual,
                ToolType.Axe     => axeVisual,
                ToolType.Hoe     => hoeVisual,
                _ => null
            };
            if (visual != null)
                visual.gameObject.SetActive(visualActive);
        }
    }
}
