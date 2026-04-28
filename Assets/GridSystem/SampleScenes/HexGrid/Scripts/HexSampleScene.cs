using GridSystem.Pathfinding;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GridSystem
{
	public class HexSampleScene : MonoBehaviour
	{
        [SerializeField] private GameObject axisCoordPrefab;
        [SerializeField] private int leftOffset;
        [SerializeField] private int rightOffset;
        [SerializeField] private int topOffset;
        [SerializeField] private int bottomOffset;
        [SerializeField] private float edgeLength;

        [SerializeField] private GameObject characterPrefab;
        [SerializeField] private GameObject wallPrefab;

		private RectangleHexGrid<AxialCoordSampleScene> hexGrid;
        private PathfinderHex<AxialCoordSampleScene> pathfinder;

		private GameObject character;

        private AxialCoord characterPos;

        private void Awake()
        {
            hexGrid = new RectangleHexGrid<AxialCoordSampleScene>(HexType.FlatTop, HexAlignment.FlatTopUp, leftOffset, rightOffset, topOffset, bottomOffset, edgeLength);
            pathfinder = PathfinderHex<GridPositionSampleScene>.CreateFromTraversalProvider(hexGrid);

            SetUpAllHexPositions();
        }

        private void Start()
        {
            AxialCoordSampleScene.OnAnyAxialCoordClicked += AxialCoordSampleScene_OnAnyAxialCoordClicked;
        }

        private void SetUpAllHexPositions()
        {
            hexGrid.IterateOverAllGridPositions((axialCoord, _) =>
            {
                GameObject spawnedGridVisual = hexGrid.InstantiateGameObjectAtAxialCoord(axialCoord, axisCoordPrefab, transform);
                AxialCoordSampleScene axialCoordSampleScene = spawnedGridVisual.GetComponent<AxialCoordSampleScene>();
                axialCoordSampleScene.SetAxialCoord(axialCoord);
                hexGrid[axialCoord] = axialCoordSampleScene;
            });
        }

        private void AxialCoordSampleScene_OnAnyAxialCoordClicked(AxialCoordSampleScene clickedObject, AxialCoord clickedGridPosition, PointerEventData.InputButton inputButton)
        {
            hexGrid.IterateOverAllGridPositions((_, cell) => cell.ResetMaterial());

            if (inputButton == PointerEventData.InputButton.Left) // Update character
            {
                clickedObject.DestroyGridObject(); // remove any object in the position, if any

                if (character == null)
                {
                    character = Instantiate(characterPrefab, Vector3.zero, Quaternion.identity);
                }

                character.transform.position = hexGrid.GetWorldPositionFromAxialCoord(clickedGridPosition);
                characterPos = clickedGridPosition;

                clickedObject.IsWalkable = true;
            }
            else if (inputButton == PointerEventData.InputButton.Right) // Create wall
            {
                if (clickedObject.IsWalkable) // current empty space or occupied by character, create wall
                {
                    GameObject wall = Instantiate(wallPrefab, Vector3.zero, Quaternion.identity);
                    wall.transform.position = hexGrid.GetWorldPositionFromAxialCoord(clickedGridPosition);
                    clickedObject.UpdateGridObject(wall);

                    clickedObject.IsWalkable = false;

                    if (clickedGridPosition == characterPos) // Replace character
                    {
                        Destroy(character);
                        character = null;
                    }
                }
            }
            else if (inputButton == PointerEventData.InputButton.Middle && character != null) // Calculate path between character and clicked position
            {
                if (clickedGridPosition == characterPos)
                    return;

                PathfindingResult<AxialCoord> path = pathfinder.FindPath(characterPos, clickedGridPosition);

                if (!path.Success)
                {
                    Debug.Log($"Cannot reach {clickedGridPosition} from {characterPos}.");
                }

                foreach (AxialCoord pos in path.Path)
                {
                    hexGrid[pos].SetMaterialAsPath();
                }
            }
        }
    }
}