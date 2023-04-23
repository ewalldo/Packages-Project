using System;
using TMPro;
using UnityEngine;

namespace GridSystem
{
	public class GridPositionSampleScene : MonoBehaviour
	{
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private TextMeshPro singlePositionInfo;

        [SerializeField] private Material defaultMaterial;
        [SerializeField] private Material mouseOverMaterial;

        private GridPosition2D gridPosition2D;

        public static Action<GridPositionSampleScene, GridPosition2D> OnAnyGridPositionClicked;

        public void Show(Material material)
        {
            meshRenderer.material = material;
            meshRenderer.enabled = true;
        }

        public void Hide()
        {
            meshRenderer.enabled = false;
        }

        public void SetGridPosition2D(GridPosition2D gridPosition2D)
        {
            this.gridPosition2D = gridPosition2D;

            singlePositionInfo.text = gridPosition2D.ToString();
        }

        private void OnMouseEnter()
        {
            meshRenderer.material = mouseOverMaterial;
        }

        private void OnMouseExit()
        {
            meshRenderer.material = defaultMaterial;
        }

        private void OnMouseDown()
        {
            OnAnyGridPositionClicked?.Invoke(this, gridPosition2D);
        }
    }
}