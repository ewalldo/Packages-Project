using UnityEngine;

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

		private RectangleHexGrid<AxialCoordSampleScene> hexGrid;
		private GameObject character;

        private void Awake()
        {
            hexGrid = new RectangleHexGrid<AxialCoordSampleScene>(HexType.FlatTop, HexAlignment.FlatTopUp, leftOffset, rightOffset, topOffset, bottomOffset, edgeLength);

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

        private void AxialCoordSampleScene_OnAnyAxialCoordClicked(AxialCoordSampleScene clickedPosition, AxialCoord axialCoord)
        {
            if (character == null)
            {
                character = Instantiate(characterPrefab, Vector3.zero, Quaternion.identity);
            }

            character.transform.position = hexGrid.GetWorldPositionFromAxialCoord(axialCoord);
        }
    }
}