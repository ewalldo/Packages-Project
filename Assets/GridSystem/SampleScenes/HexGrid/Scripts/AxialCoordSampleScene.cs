using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GridSystem
{
	public class AxialCoordSampleScene : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
	{
		[SerializeField] private MeshRenderer meshRenderer;
		[SerializeField] private TextMeshPro singlePositionInfo;

		[SerializeField] private Material defaultMaterial;
		[SerializeField] private Material mouseOverMaterial;

		private AxialCoord axialCoord;

		public static Action<AxialCoordSampleScene, AxialCoord> OnAnyAxialCoordClicked;

		public void Show(Material material)
		{
			meshRenderer.material = material;
			meshRenderer.enabled = true;
		}

		public void Hide()
		{
			meshRenderer.enabled = false;
		}

		public void SetAxialCoord(AxialCoord axialCoord)
        {
			this.axialCoord = axialCoord;

			singlePositionInfo.text = axialCoord.ToString();
        }

		public void OnPointerEnter(PointerEventData eventData)
		{
			meshRenderer.material = mouseOverMaterial;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			meshRenderer.material = defaultMaterial;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			OnAnyAxialCoordClicked?.Invoke(this, axialCoord);
		}
	}
}