using GridSystem.Pathfinding;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GridSystem
{
	public class Grid2DSampleScene : MonoBehaviour
	{
		[SerializeField] private GameObject gridPositionPrefab;
		[SerializeField] private int gridWidth;
		[SerializeField] private int gridHeight;
		[SerializeField] private float gridCellSize;

        [SerializeField] private GameObject characterPrefab;
        [SerializeField] private GameObject wallPrefab;

        private Grid2D<GridPositionSampleScene> grid2D;
        private Pathfinder2D<GridPositionSampleScene> pathfinder;

        private GameObject character;

        private GridPosition2D characterPos;

        private void Awake()
        {
			grid2D = new Grid2D<GridPositionSampleScene>(gridWidth, gridHeight, gridCellSize);
            pathfinder = Pathfinder2D<GridPositionSampleScene>.CreateFromTraversalProvider(grid2D, new PathfindingOptions2D(
                false,
                false,
                true,
                PathfindingOptions2D.PathfindingHeuristic.Manhattan
                ));

			SetUpAllGridPositions();
        }

        private void Start()
        {
            GridPositionSampleScene.OnAnyGridPositionClicked += GridPositionSampleScene_OnAnyGridPositionClicked;
        }

        private void SetUpAllGridPositions()
        {
            for (int x = 0; x < grid2D.Width; x++)
            {
                for (int z = 0; z < grid2D.Height; z++)
                {
                    GridPosition2D gridPosition2D = new GridPosition2D(x, z);

                    GameObject spawnedGridVisual = grid2D.InstantiateGameObjectAtGridPosition(gridPosition2D, gridPositionPrefab, transform);
                    GridPositionSampleScene gridPositionSampleScene = spawnedGridVisual.GetComponent<GridPositionSampleScene>();
                    gridPositionSampleScene.SetGridPosition2D(gridPosition2D);
                    grid2D[gridPosition2D] = gridPositionSampleScene;
                }
            }
        }

        private void GridPositionSampleScene_OnAnyGridPositionClicked(GridPositionSampleScene clickedObject, GridPosition2D clickedGridPosition, PointerEventData.InputButton inputButton)
        {
            grid2D.IterateOverAllGridPositions((_, cell) => cell.ResetMaterial());

            if (inputButton == PointerEventData.InputButton.Left) // Update character
            {
                clickedObject.DestroyGridObject(); // remove any object in the position, if any

                if (character == null)
                {
                    character = Instantiate(characterPrefab, Vector3.zero, Quaternion.identity);
                }

                character.transform.position = grid2D.GetWorldPositionFromCenterGridPosition2D(clickedGridPosition);
                characterPos = clickedGridPosition;

                clickedObject.IsWalkable = true;
            }
            else if (inputButton == PointerEventData.InputButton.Right) // Create wall
            {
                if (clickedObject.IsWalkable) // current empty space or occupied by character, create wall
                {
                    GameObject wall = Instantiate(wallPrefab, Vector3.zero, Quaternion.identity);
                    wall.transform.position = grid2D.GetWorldPositionFromCenterGridPosition2D(clickedGridPosition);
                    clickedObject.UpdateGridObject(wall);

                    clickedObject.IsWalkable = false;

                    if (clickedGridPosition == characterPos) // Replace character
                    {
                        Destroy(character);
                        character = null;
                    }
                }
                else // wall already exists, destroy it
                {
                    clickedObject.DestroyGridObject();
                    clickedObject.IsWalkable = true;
                }
            }
            else if (inputButton == PointerEventData.InputButton.Middle && character != null) // Calculate path between character and clicked position
            {
                if (clickedGridPosition == characterPos)
                    return;

                PathfindingResult<GridPosition2D> path = pathfinder.FindPath(characterPos, clickedGridPosition);

                if (!path.Success)
                {
                    Debug.Log($"Cannot reach {clickedGridPosition} from {characterPos}.");
                }

                foreach (GridPosition2D pos in path.Path)
                {
                    grid2D[pos].SetMaterialAsPath();
                }
            }
        }

    }
}