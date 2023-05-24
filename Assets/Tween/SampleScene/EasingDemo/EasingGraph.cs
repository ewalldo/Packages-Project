using UnityEngine;

namespace Tween
{
	public class EasingGraph : MonoBehaviour
	{
		private const float GRAPH_SIZE = 150f;

		[SerializeField] private RectTransform graphPoint;
		[SerializeField] private TrailRenderer trailRenderer;
		[SerializeField] private EasingType easingType;

		private EasingFunction easingFunction;

        private void Awake()
        {
			easingFunction = EasingFactory.GetEasing(easingType);
        }

		public void UpdateGraph(float progress)
        {
			graphPoint.anchoredPosition = new Vector2(progress * GRAPH_SIZE, Mathf.LerpUnclamped(0f, GRAPH_SIZE, EasingEquations.Evaluate(easingFunction, progress)));
		}

		public void ResetGraph()
        {
			graphPoint.anchoredPosition = Vector2.zero;
			trailRenderer.Clear();
		}
    }
}