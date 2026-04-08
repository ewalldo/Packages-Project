using System;
using UnityEngine;

namespace GridSystem
{
	public class Grid2DSampleScene : MonoBehaviour
	{
		[SerializeField] private GameObject gridPositionPrefab;
		[SerializeField] private int gridWidth;
		[SerializeField] private int gridHeight;
		[SerializeField] private float gridCellSize;

        [SerializeField] private GameObject characterPrefab;

		private Grid2D<GridPositionSampleScene> grid2D;
        private GameObject character;

        private void Awake()
        {
			grid2D = new Grid2D<GridPositionSampleScene>(gridWidth, gridHeight, gridCellSize);

			SetUpAllGridPositions();
        }

        private void Start()
        {
            GridPositionSampleScene.OnAnyGridPositionClicked += GridPositionSampleScene_OnAnyGridPositionClicked;
        }

        private void SetUpAllGridPositions()
        {
            for (int x = 0; x < grid2D.GetWidth; x++)
            {
                for (int z = 0; z < grid2D.GetHeight; z++)
                {
                    GridPosition2D gridPosition2D = new GridPosition2D(x, z);

                    GameObject spawnedGridVisual = grid2D.InstantiateGameObjectAtGridPosition(gridPosition2D, gridPositionPrefab, transform);
                    GridPositionSampleScene gridPositionSampleScene = spawnedGridVisual.GetComponent<GridPositionSampleScene>();
                    gridPositionSampleScene.SetGridPosition2D(gridPosition2D);
                    grid2D[gridPosition2D] = gridPositionSampleScene;
                }
            }
        }

        private void GridPositionSampleScene_OnAnyGridPositionClicked(GridPositionSampleScene clickedGridPosition, GridPosition2D gridPosition2D)
        {
            if (character == null)
            {
                character = Instantiate(characterPrefab, Vector3.zero, Quaternion.identity);
            }

            character.transform.position = grid2D.GetWorldPositionFromCenterGridPosition2D(gridPosition2D);
        }

    }
}