using System.Collections.Generic;
using UnityEngine;

namespace Tween
{
	public class EasingDemo : MonoBehaviour
	{
		[SerializeField] private EasingGraph[] easingGraphs;

        private float curTimer;
        private float maxTimer;

        private void Start()
        {
            curTimer = 0f;
            maxTimer = 3f;
        }

        private void Update()
        {
            curTimer += Time.deltaTime;
            float progress = curTimer / maxTimer;

            foreach (EasingGraph easingGraph in easingGraphs)
            {
                easingGraph.UpdateGraph(progress);
            }

            if (curTimer > maxTimer)
            {
                curTimer = 0f;

                foreach (EasingGraph easingGraph in easingGraphs)
                {
                    easingGraph.ResetGraph();
                }
            }
        }
    }
}