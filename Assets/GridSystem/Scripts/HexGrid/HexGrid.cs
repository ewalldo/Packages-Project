using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace GridSystem
{
	public abstract class HexGrid<T>
	{
        protected readonly HexType hexType;
        protected readonly float edgeLength;
        protected readonly Vector3 gridOriginPosition;
        protected Dictionary<AxialCoord, T> hexGrid;

        /// <summary>
        /// Get the edge length of the hex cell's of this grid
        /// </summary>
        public float GetEdgeLength => edgeLength;
        /// <summary>
        /// Get the origin position of the grid
        /// </summary>
        public Vector3 GetGridOriginPosition => gridOriginPosition;

        /// <summary>
        /// Event to be raised when the value of a cell changes
        /// <param name="axialCoord">AxialCoord: the grid position where the value has changed</param>"
        /// <param name="value">T: the new value assigned to the position</param>"
        /// </summary>
        public Action<AxialCoord, T> OnGridPositionValueChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="HexGrid{T}"/> class.
        /// </summary>
        /// <param name="hexType">The hex type of this grid</param>
        /// <param name="edgeLength">The lenght of the edge of each hex cell</param>
        /// <param name="gridOriginPosition">The grid origin position</param>
        public HexGrid(HexType hexType, float edgeLength, Vector3 gridOriginPosition)
        {
            if (edgeLength <= 0)
                throw new ArgumentException("Edge length cannot be zero or negative");

            this.hexType = hexType;
            this.edgeLength = edgeLength;
            this.gridOriginPosition = gridOriginPosition;

            hexGrid = new Dictionary<AxialCoord, T>();
        }

        public T this[int q, int r]
        {
            get => GetGridObjectAtAxialCoord(new AxialCoord(q, r));
            set => SetGridObjectAtAxialCoord(new AxialCoord(q, r), value, true);
        }

        public T this[AxialCoord axialCoord]
        {
            get => GetGridObjectAtAxialCoord(axialCoord);
            set => SetGridObjectAtAxialCoord(axialCoord, value, true);
        }

        public T this[Vector3 worldPosition]
        {
            get => GetGridObjectAtWorldPosition(worldPosition);
            set => SetGridObjectAtWorldPosition(worldPosition, value, true);
        }

        /// <summary>
        /// Returns the elements of the grid
        /// </summary>
        /// <returns>Element of the grid</returns>
        public IEnumerable<T> GetGridObjects()
        {
            foreach (AxialCoord axialCoord in hexGrid.Keys.ToList())
            {
                yield return GetGridObjectAtAxialCoord(axialCoord);
            }
        }

        /// <summary>
        /// Returns the AxialCoords of this grid
        /// </summary>
        /// <returns>AxialCoord of the grid</returns>
        public IEnumerable<AxialCoord> GetGridAxialCoords()
        {
            foreach (AxialCoord axialCoord in hexGrid.Keys.ToList())
            {
                yield return axialCoord;
            }
        }

        /// <summary>
        /// Clear the grid and reset all the positions to their default values
        /// </summary>
        public void ClearGrid()
        {
            foreach (AxialCoord axialCoord in hexGrid.Keys.ToList())
            {
                SetGridObjectAtAxialCoord(axialCoord, default, true);
            }
        }

        /// <summary>
        /// Fill all the positions in the grid with the specific value
        /// </summary>
        /// <param name="value">The value to apply on every position</param>
        public void Fill(T value)
        {
            foreach (AxialCoord axialCoord in hexGrid.Keys.ToList())
            {
                SetGridObjectAtAxialCoord(axialCoord, value, true);
            }
        }

        /// <summary>
        /// Get an element from the grid on a specific AxialCoord
        /// </summary>
        /// <param name="axialCoord">The position to get the element from</param>
        /// <returns>The element at the specified position</returns>
        public T GetGridObjectAtAxialCoord(AxialCoord axialCoord)
        {
            if (hexGrid.ContainsKey(axialCoord))
                return hexGrid[axialCoord];

            throw new ArgumentException("Axial coordinates is out of bounds of the grid");
        }

        /// <summary>
        /// Get an element from the grid based on a world position
        /// </summary>
        /// <param name="worldPosition">The world position to get the element from</param>
        /// <returns>The element at the specified world position</returns>
        public T GetGridObjectAtWorldPosition(Vector3 worldPosition)
        {
            AxialCoord axialCoord = GetAxialCoordFromWorldPosition(worldPosition);
            return GetGridObjectAtAxialCoord(axialCoord);
        }

        /// <summary>
        /// Get an random object from the grid
        /// </summary>
        /// <returns>A random element from the grid</returns>
        public T GetRandomObject()
        {
            System.Random rand = new System.Random();
            List<AxialCoord> coords = hexGrid.Keys.ToList();
            return GetGridObjectAtAxialCoord(coords[rand.Next(coords.Count)]);
        }

        /// <summary>
        /// Gets a random position from the grid
        /// </summary>
        /// <returns>A random position within the grid</returns>
        public AxialCoord GetRandomAxialCoord()
        {
            System.Random rand = new System.Random();
            List<AxialCoord> coords = hexGrid.Keys.ToList();
            return coords[rand.Next(coords.Count)];
        }

        /// <summary>
        /// Set a grid object in a specific grid position
        /// </summary>
        /// <param name="axialCoord">The grid position of the object</param>
        /// <param name="newObject">The new object to set in the position</param>
        /// <param name="replaceIfExistAnObjectAlready">Replace even if the position has already been assigned</param>
        /// <returns>True if the object was successfully assigned, false otherwise</returns>
        public bool SetGridObjectAtAxialCoord(AxialCoord axialCoord, T newObject, bool replaceIfExistAnObjectAlready = true)
        {
            if ((replaceIfExistAnObjectAlready) || // always replace
                (default(T) is null && hexGrid[axialCoord] == null) || // check if it is a nullable type AND if it is, check if the position is null, if yes set the position
                (hexGrid[axialCoord].Equals(default(T)))) // it is a non-nullable type, check if the position is at default value, if yes set the position
            {
                hexGrid[axialCoord] = newObject;
                OnGridPositionValueChanged?.Invoke(axialCoord, newObject);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Set an object in the grid based on a world position
        /// </summary>
        /// <param name="worldPosition">The world position of the object</param>
        /// <param name="newObject">The new object to set in the position</param>
        /// <param name="replaceIfExistAnObjectAlready">Replace even if the position has already been assigned</param>
        /// <returns>True if the object was successfully assigned, false otherwise</returns>
        public bool SetGridObjectAtWorldPosition(Vector3 worldPosition, T newObject, bool replaceIfExistAnObjectAlready = true)
        {
            AxialCoord axialCoord = GetAxialCoordFromWorldPosition(worldPosition);
            return SetGridObjectAtAxialCoord(axialCoord, newObject, replaceIfExistAnObjectAlready);
        }

        /// <summary>
        /// Converts a AxialCoord to a world position
        /// </summary>
        /// <param name="axialCoord">The AxialCoord to convert from</param>
        /// <returns>The position in world coordinates</returns>
        public Vector3 GetWorldPositionFromAxialCoord(AxialCoord axialCoord)
        {
            Vector3 worldPosition = Vector3.zero;

            float x, z;

            switch (hexType)
            {
                case HexType.FlatTop:
                    x = edgeLength * (3f / 2f * axialCoord.Q);
                    z = edgeLength * ((Mathf.Sqrt(3f) / 2f * axialCoord.Q) + (Mathf.Sqrt(3f) * axialCoord.R));
                    worldPosition = new Vector3(x, 0f, z);
                    break;
                case HexType.PointTop:
                    x = edgeLength * ((Mathf.Sqrt(3f) * axialCoord.Q) + (Mathf.Sqrt(3f) / 2f * axialCoord.R));
                    z = edgeLength * (3f / 2f * axialCoord.R);
                    worldPosition = new Vector3(x, 0f, z);
                    break;
                default:
                    break;
            }

            return worldPosition + gridOriginPosition;
        }

        /// <summary>
        /// Try to convert a AxialCoord into a world position
        /// </summary>
        /// <param name="axialCoord">The AxialCoord to convert from</param>
        /// <param name="worldPosition">The position in world coordinates</param>
        /// <returns>True if it is able to convert, false otherwise</returns>
        public bool TryGetWorldPositionFromAxialCoord(AxialCoord axialCoord, out Vector3 worldPosition)
        {
            worldPosition = Vector3.zero;
            if (!IsWithinHexGridBounds(axialCoord))
                return false;

            worldPosition = GetWorldPositionFromAxialCoord(axialCoord);
            return true;
        }

        /// <summary>
        /// Converts a world position into AxialCoord
        /// </summary>
        /// <param name="worldPosition">The world position to convert from</param>
        /// <returns>The AxialCoord corresponding to the world position</returns>
        public AxialCoord GetAxialCoordFromWorldPosition(Vector3 worldPosition)
        {
            Vector3 vectorOffset = worldPosition - gridOriginPosition;
            AxialCoord axialCoord = default;

            float r, q;

            switch (hexType)
            {
                case HexType.FlatTop:
                    q = (2f / 3f * vectorOffset.x) / edgeLength;
                    r = (-1f / 3f * vectorOffset.x) + (Mathf.Sqrt(3f) / 3 * vectorOffset.z) / edgeLength;
                    axialCoord = RoundFrac(q, r);
                    break;
                case HexType.PointTop:
                    q = (Mathf.Sqrt(3f) / 3f * vectorOffset.x) - (1f / 3 * vectorOffset.z) / edgeLength;
                    r = (2f / 3f * vectorOffset.z) / edgeLength;
                    axialCoord = RoundFrac(q, r);
                    break;
                default:
                    break;
            }

            return axialCoord;
        }

        /// <summary>
        /// Try to convert a world position into AxialCoord
        /// </summary>
        /// <param name="worldPosition">The world position to try to convert from</param>
        /// <param name="axialCoord">The corresponding AxialCoord</param>
        /// <returns>True if it is able to convert, false otherwise</returns>
        public bool TryGetAxialCoordFromWorldPosition(Vector3 worldPosition, out AxialCoord axialCoord)
        {
            axialCoord = GetAxialCoordFromWorldPosition(worldPosition);

            if (!IsWithinHexGridBounds(axialCoord))
                return false;

            return true;
        }

        /// <summary>
        /// Get all positions that satisfies a condition
        /// </summary>
        /// <param name="predicate">The condition to check on each position (params T: value at the position)</param>
        /// <returns>A list containing all the positions that satisfies the condition</returns>
        public List<AxialCoord> GetGridPositionsInACertainState(Func<T, bool> predicate)
        {
            List<AxialCoord> axialCoords = new List<AxialCoord>();

            foreach (AxialCoord axialCoord in hexGrid.Keys.ToList())
            {
                if (predicate(GetGridObjectAtAxialCoord(axialCoord)))
                    axialCoords.Add(axialCoord);
            }

            return axialCoords;
        }

        /// <summary>
        /// Execute an action for every position in the grid
        /// </summary>
        /// <param name="action">Action to apply on every grid position (params AxialCoord: grid position, T: value at the position)</param>
        public void IterateOverAllGridPositions(Action<AxialCoord, T> action)
        {
            foreach (AxialCoord axialCoord in hexGrid.Keys.ToList())
            {
                action(axialCoord, GetGridObjectAtAxialCoord(axialCoord));
            }
        }

        /// <summary>
        /// Check if a grid position is within the grid bounds
        /// </summary>
        /// <param name="axialCoord">The AxialCoord to check</param>
        /// <returns>True if the position is within the grid, false otherwise</returns>
        public bool IsWithinHexGridBounds(AxialCoord axialCoord)
        {
            return hexGrid.ContainsKey(axialCoord);
        }

        /// <summary>
        /// Check if a grid position is within the grid bounds
        /// </summary>
        /// <param name="q">The q-coordinate to check</param>
        /// <param name="r">The r-coordinate to check</param>
        /// <returns>True if the position is within the grid, false otherwise</returns>
        public bool IsWithinHexGridBounds(int q, int r)
        {
            return IsWithinHexGridBounds(new AxialCoord(q, r));
        }

        /// <summary>
        /// Check if a world position is within the grid bounds
        /// </summary>
        /// <param name="worldPosition">The world position to check</param>
        /// <returns>True if the position is within the grid, false otherwise</returns>
        public bool IsWithinHexGridBounds(Vector3 worldPosition)
        {
            return TryGetAxialCoordFromWorldPosition(worldPosition, out _);
        }

        /// <summary>
        /// Check if all the grid positions are within the grid bounds
        /// </summary>
        /// <param name="axialCoords">Collection containing all the positions to check</param>
        /// <returns>True if all the position is within the grid, false otherwise</returns>
        public bool IsWithinHexGridBounds(IEnumerable<AxialCoord> axialCoords)
        {
            foreach (AxialCoord axialCoord in axialCoords)
            {
                if (!IsWithinHexGridBounds(axialCoord))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Check if the position is empty (or default value in case of a non-nullable type)
        /// </summary>
        /// <param name="axialCoord">The grid position to check</param>
        /// <returns>True if the position is empty, false otherwise</returns>
        public bool IsPositionEmpty(AxialCoord axialCoord)
        {
            if (default(T) is null)
                return GetGridObjectAtAxialCoord(axialCoord) == null;
            else
                return GetGridObjectAtAxialCoord(axialCoord).Equals(default(T));
        }

        /// <summary>
        /// Check if the position is empty (or default value in case of a non-nullable type)
        /// </summary>
        /// <param name="q">The q-coordinate to check</param>
        /// <param name="r">The r-coordinate to check</param>
        /// <returns>True if the position is empty, false otherwise</returns>
        public bool IsPositionEmpty(int q, int r)
        {
            return IsPositionEmpty(new AxialCoord(q, r));
        }

        /// <summary>
        /// Check if the position is empty (or default value in case of a non-nullable type)
        /// </summary>
        /// <param name="worldPosition">The world position to check</param>
        /// <returns>True if the position is empty, false otherwise</returns>
        public bool IsPositionEmpty(Vector3 worldPosition)
        {
            AxialCoord axialCoord = GetAxialCoordFromWorldPosition(worldPosition);
            return IsPositionEmpty(axialCoord);
        }

        /// <summary>
        /// Get all adjacent neighbours of a specific position
        /// </summary>
        /// <param name="center">The center position to get the neighbours from</param>
        /// <param name="includeCenterPosition">Should include the center position in the return list</param>
        /// <returns>List containing all the neighbour positions of a specific grid position</returns>
        public List<AxialCoord> GetAdjacentNeighbours(AxialCoord center, bool includeCenterPosition = false)
        {
            List<AxialCoord> neighboursList = new List<AxialCoord>();

            foreach (AxialCoord coord in center.Neighbours)
            {
                if (IsWithinHexGridBounds(coord))
                    neighboursList.Add(coord);
            }

            if (includeCenterPosition)
                neighboursList.Add(center);

            return neighboursList;
        }

        /// <summary>
        /// Get all diagonals of a specific position
        /// </summary>
        /// <param name="center">The center position to get the diagonals from</param>
        /// <param name="includeCenterPosition">Should include the center position in the return list</param>
        /// <returns>List containing all the diagonal positions of a specific grid position</returns>
        public List<AxialCoord> GetDiagonalNeighbours(AxialCoord center, bool includeCenterPosition = false)
        {
            List<AxialCoord> diagonalList = new List<AxialCoord>();

            foreach (AxialCoord coord in center.Diagonals)
            {
                if (IsWithinHexGridBounds(coord))
                    diagonalList.Add(coord);
            }

            if (includeCenterPosition)
                diagonalList.Add(center);

            return diagonalList;
        }

        /// <summary>
        /// Get all the grid positions within a range
        /// </summary>
        /// <param name="center">The center position to calculate the range from</param>
        /// <param name="range">The length of the range (in grid units)</param>
        /// <param name="includeCenterPosition">Should include the center position in the return list</param>
        /// <returns>List containing all the positions within the range</returns>
        public List<AxialCoord> GetAxialCoordsFromADistanceRange(AxialCoord center, int range, bool includeCenterPosition = false)
        {
            List<AxialCoord> rangeList = new List<AxialCoord>();

            foreach (AxialCoord coord in center.GetAxialCoordsWithinRange(range))
            {
                if (IsWithinHexGridBounds(coord))
                    rangeList.Add(coord);
            }

            if (includeCenterPosition)
                rangeList.Add(center);

            return rangeList;
        }

        /// <summary>
        /// Given two centers and a range, gets all the grid positions that intersects
        /// </summary>
        /// <param name="center1">The first center position</param>
        /// <param name="center2">The second center position</param>
        /// <param name="range">The length of the range (in grid units)</param>
        /// <returns>List containing all the intersected positions</returns>
        public List<AxialCoord> GetAxialCoordsFromIntersectingRanges(AxialCoord center1, AxialCoord center2, int range)
        {
            List<AxialCoord> intersectingList = new List<AxialCoord>();

            for (int q = Mathf.Max(center1.Q - range, center2.Q - range); q <= Mathf.Min(center1.Q + range, center2.Q + range); q++)
            {
                for (int r = Mathf.Max(Mathf.Max(center1.R - range, center2.R - range), -q - Mathf.Min(center1.S + range, center2.S + range)); r <= Mathf.Min(Mathf.Min(center1.R + range, center2.R + range), -q - Mathf.Max(center1.S - range, center2.S - range)); r++)
                {
                    AxialCoord coord = new AxialCoord(q, r);

                    if (IsWithinHexGridBounds(coord))
                        intersectingList.Add(new AxialCoord(q, r));
                }
            }

            return intersectingList;
        }

        /// <summary>
        /// Get all the positions forming a ring around a specific center
        /// </summary>
        /// <param name="center">The center position to get the ring from</param>
        /// <param name="radius">The radius of the ring (in grid units)</param>
        /// <returns>List containing all the positions forming the ring</returns>
        public List<AxialCoord> GetRing(AxialCoord center, int radius)
        {
            if (radius <= 0)
                throw new ArgumentException($"{nameof(radius)} cannot be zero or negative.");

            List<AxialCoord> ring = new List<AxialCoord>();

            AxialCoord hex = center + (new AxialCoord(-1, +1) * radius);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < radius; j++)
                {
                    if (IsWithinHexGridBounds(hex))
                        ring.Add(hex);
                    hex = hex.GetNeighbour(i);
                }
            }

            return ring;
        }

        /// <summary>
        /// Get all the positions forming a spiral from a specific center
        /// </summary>
        /// <param name="center">The center position of the spiral</param>
        /// <param name="radius">The radius of the spiral (in grid units)</param>
        /// <returns>List containing all the positions forming the spiral</returns>
        public List<AxialCoord> GetSpiral(AxialCoord center, int radius)
        {
            if (radius < 0)
                throw new ArgumentException($"{nameof(radius)} cannot be negative.");

            List<AxialCoord> spiral = new List<AxialCoord>() { center };

            for (int k = 1; k <= radius; k++)
            {
                spiral.AddRange(GetRing(center, k));
            }

            return spiral;
        }

        /// <summary>
        /// Instantiate a game object in a certain grid position
        /// </summary>
        /// <param name="axialCoord">The grid position to instantiate the object on</param>
        /// <param name="gameObjectPrefab">The object to instantiate</param>
        /// <param name="objectParent">The parent transform for the instantiated object</param>
        /// <param name="onGameObjectSpawned">Action to execute when the object is instantiated</param>
        /// <returns>The instantiated game object</returns>
        public GameObject InstantiateGameObjectAtAxialCoord(AxialCoord axialCoord, GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onGameObjectSpawned = null)
        {
            GameObject spawnedGameObject = GameObject.Instantiate(gameObjectPrefab, GetWorldPositionFromAxialCoord(axialCoord), Quaternion.identity, objectParent);

            onGameObjectSpawned?.Invoke(spawnedGameObject);
            return spawnedGameObject;
        }

        /// <summary>
        /// Instantiate a game object on the grid based on a world position
        /// </summary>
        /// <param name="worldPosition">The world position to instantiate the object</param>
        /// <param name="gameObjectPrefab">The object to instantiate</param>
        /// <param name="objectParent">The parent transform for the instantiated object</param>
        /// <param name="onGameObjectSpawned">Action to execute when the object is instantiated</param>
        /// <returns>The instantiated game object</returns>
        public GameObject InstantiateGameObjectAtWorldPosition(Vector3 worldPosition, GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onGameObjectSpawned = null)
        {
            AxialCoord axialCoord = GetAxialCoordFromWorldPosition(worldPosition);
            return InstantiateGameObjectAtAxialCoord(axialCoord, gameObjectPrefab, objectParent, onGameObjectSpawned);
        }

        /// <summary>
        /// Instantiate a game object on every grid position
        /// </summary>
        /// <param name="gameObjectPrefab">The object to instantiate</param>
        /// <param name="objectParent">The parent transform for all objects</param>
        /// <param name="onEachGameObjectSpawned">Action to execute when one object is instantiated (params GameObject: the instantiated game object)</param>
        /// <param name="onAllGameObjectSpawned">Action to execute after all objecta are instantiated (params List<GameObject>: all the instantiated game objects)</param>
        /// <returns>A list containing all the instantiated game objects</returns>
        public List<GameObject> InstantiateGameObjectAtEveryAxialCoord(GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onEachGameObjectSpawned = null, Action<List<GameObject>> onAllGameObjectSpawned = null)
        {
            List<GameObject> spawnedGameObjectList = new List<GameObject>();

            foreach (AxialCoord axialCoord in hexGrid.Keys.ToList())
            {
                GameObject spawnedGameObject = InstantiateGameObjectAtAxialCoord(axialCoord, gameObjectPrefab, objectParent, onEachGameObjectSpawned);
                spawnedGameObjectList.Add(spawnedGameObject);
            }

            onAllGameObjectSpawned?.Invoke(spawnedGameObjectList);

            return spawnedGameObjectList;
        }

        /// <summary>
        /// Save/serialize the grid using a binary formatter (T and its members must be a serializable type)
        /// </summary>
        /// <param name="filename">The file to be opened/created for writing</param>
        /// <returns>True if the save operation was successful, false otherwise</returns>
        public bool Save(string filename)
        {
            try
            {
                using (FileStream stream = File.OpenWrite(filename))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, hexGrid);
                }

                return true;
            }
            catch (Exception e)
            {
                Debug.LogError("Error saving grid: " + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Load/deserialize a grid using a binary formatter (T and its members must be a serializable type)
        /// </summary>
        /// <param name="filename">The file to be opened for reading</param>
        /// <returns>True if the operation was successful, false otherwise</returns>
        public bool Load(string filename)
        {
            try
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    hexGrid = (Dictionary<AxialCoord, T>)formatter.Deserialize(stream);

                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error loading grid: " + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Gets all the AxialCoord that forms a straight line between two positions
        /// </summary>
        /// <param name="start">The start of the line</param>
        /// <param name="end">The end of the line</param>
        /// <param name="includeStartAndEndPositions">Should the start and end positions be included in the return set</param>
        /// <returns>Set containing all the positions forming the line</returns>
        public static HashSet<AxialCoord> GetLine(AxialCoord start, AxialCoord end, bool includeStartAndEndPositions = true)
        {
            HashSet<AxialCoord> linePoints = new HashSet<AxialCoord>();

            int distance = AxialCoord.Distance(start, end);

            for (int i = 0; i < distance; i++)
            {
                AxialCoord coord = Lerp(start, end, (1f / distance * i));
                linePoints.Add(coord);
            }

            if (includeStartAndEndPositions)
            {
                linePoints.Add(start);
                linePoints.Add(end);
            }

            return linePoints;
        }

        private static AxialCoord RoundFrac(float q, float r)
        {
            float s = -q - r;

            int qi = (int)(Math.Round(q));
            int ri = (int)(Math.Round(r));
            int si = (int)(Math.Round(s));

            double q_diff = Math.Abs(qi - q);
            double r_diff = Math.Abs(ri - r);
            double s_diff = Math.Abs(si - s);

            if (q_diff > r_diff && q_diff > s_diff)
                qi = -ri - si;
            else if (r_diff > s_diff)
                ri = -qi - si;

            return new AxialCoord(qi, ri);
        }

        private static AxialCoord Lerp(AxialCoord a, AxialCoord b, float t)
        {
            float q = a.Q + (b.Q - a.Q) * t;
            float r = a.R + (b.R - a.R) * t;

            return RoundFrac(q, r);
        }
    }
}