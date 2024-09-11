using UnityEngine;

namespace GenericNamespace
{
	public class SelectionByClick<T>
	{
		// TODO: Rewrite class

		private Plane plane;
		private float distance;

        public SelectionByClick()
        {
			plane = new Plane(Vector3.up, 0);
		}

		public bool TrySelectByPhysicsRaycast(Vector3 testPosition, out T selectable)
        {
			selectable = default;
			Ray ray = Camera.main.ScreenPointToRay(testPosition);

			if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue))
            {
				if (raycastHit.transform.TryGetComponent(out T hitObject))
                {
					selectable = hitObject;
					return true;
				}
			}

			// Untested
			//RaycastHit[] hits = Physics.RaycastAll(ray, float.MaxValue);
			//if (hits.Length > 0)
			//{
			//	foreach (RaycastHit hit in hits)
			//	{
			//		if (hit.transform.TryGetComponent(out T hitObject))
			//		{
			//			selectable = hitObject;
			//			return true;
			//		}
			//	}
			//}

			return false;
		}

		public bool TryGetWorldPositionFromMouseScreenPosition(Vector2 mouseScreenPosition, out Vector3 worldPosition)
        {
			// testPosition = Mouse.current.position.ReadValue();

			worldPosition = default;
			Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);

			if (plane.Raycast(ray, out distance))
            {
				worldPosition = ray.GetPoint(distance);
				return true;
			}

			return false;
		}
	}
}