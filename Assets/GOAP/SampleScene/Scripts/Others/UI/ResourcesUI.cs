using TMPro;
using UnityEngine;

namespace GOAP.Sample
{
    public class ResourcesUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI woodText;
        [SerializeField] private TextMeshProUGUI oreText;
        [SerializeField] private TextMeshProUGUI cropText;

        private void Update()
        {
            float wood = VillageManager.Instance.GetResourceCount(ResourceType.Wood);
            float ore = VillageManager.Instance.GetResourceCount(ResourceType.Ore);
            float crop = VillageManager.Instance.GetResourceCount(ResourceType.Crop);

            UpdateResourceUI(wood, ore, crop);
        }

        public void UpdateResourceUI(float wood, float ore, float crop)
        {
            woodText.text = wood.ToString("F2");
            oreText.text = ore.ToString("F2");
            cropText.text = crop.ToString("F2");
        }
    }
}