using GridSystem.Pathfinding;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GridSystem
{
	public class AxialCoordSampleScene : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, ITraversalProvider
	{
		[SerializeField] private MeshRenderer meshRenderer;
		[SerializeField] private TextMeshPro singlePositionInfo;

		[SerializeField] private Material defaultMaterial;
		[SerializeField] private Material mouseOverMaterial;
		[SerializeField] private Material pathMaterial;

        private AxialCoord axialCoord;
		private GameObject instanciatedObject;
		private Material currentMaterial;

		public static Action<AxialCoordSampleScene, AxialCoord, PointerEventData.InputButton> OnAnyAxialCoordClicked;

		public bool IsWalkable { get; set; } = true;
		public int MovementCost => 1;

        private void Awake()
        {
			currentMaterial = defaultMaterial;
        }

        public void SetAxialCoord(AxialCoord axialCoord)
        {
			this.axialCoord = axialCoord;

			singlePositionInfo.text = axialCoord.ToString();
        }

		public void SetMaterialAsPath()
		{
			meshRenderer.material = pathMaterial;
			currentMaterial = pathMaterial;
		}

		public void ResetMaterial()
		{
			meshRenderer.material = defaultMaterial;
			currentMaterial = defaultMaterial;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			meshRenderer.material = mouseOverMaterial;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			meshRenderer.material = currentMaterial;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			OnAnyAxialCoordClicked?.Invoke(this, axialCoord, eventData.button);
		}

		public void DestroyGridObject()
		{
			if (instanciatedObject != null)
			{
				Destroy(instanciatedObject);
				instanciatedObject = null;
			}
		}

		public void UpdateGridObject(GameObject newObject)
		{
			instanciatedObject = newObject;
		}
	}
}