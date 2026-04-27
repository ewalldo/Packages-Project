using GridSystem.Pathfinding;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GridSystem
{
	public class GridPositionSampleScene : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, ITraversalProvider
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private TextMeshPro singlePositionInfo;

        [SerializeField] private Material defaultMaterial;
        [SerializeField] private Material mouseOverMaterial;
        [SerializeField] private Material pathMaterial;

        private GridPosition2D gridPosition2D;
        private GameObject instanciatedObject;

        public static Action<GridPositionSampleScene, GridPosition2D, PointerEventData.InputButton> OnAnyGridPositionClicked;

        public bool IsWalkable { get; set; } = true;
        private Material currentMaterial;

        public int MovementCost => 1;

        private void Awake()
        {
            currentMaterial = defaultMaterial;
        }

        public void SetGridPosition2D(GridPosition2D gridPosition2D)
        {
            this.gridPosition2D = gridPosition2D;

            singlePositionInfo.text = gridPosition2D.ToString();
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
            OnAnyGridPositionClicked?.Invoke(this, gridPosition2D, eventData.button);
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