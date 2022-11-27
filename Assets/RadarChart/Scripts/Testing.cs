using UnityEngine;

namespace RadarChart
{
    public class Testing : MonoBehaviour
    {
        [SerializeField] private RadarChart radarChart;

        private void Start()
        {
            //Stats stats = new Stats(10, 15, 5, 17, 8);
            Stats stats = new Stats(20, 19, 20, 19, 20);

            radarChart.SetStats(stats);
        }
    }
}
