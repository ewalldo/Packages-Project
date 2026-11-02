using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GridSystem
{
	public abstract class HexGrid<T> : IEnumerable<T>
	{
        protected readonly HexType hexType;
        protected readonly float edgeLength;
        protected readonly Vector3 gridOriginPosition;
        protected Dictionary<AxialCoord, T> hexGrid;

        protected static int RandomInt(int max) => UnityEngine.Random.Range(0, max);

        private static readonly float Sqrt3 = Mathf.Sqrt(3f);
        private static readonly float Sqrt3Over2 = Mathf.Sqrt(3f) / 2f;
        private static readonly float Sqrt3Over3 = Mathf.Sqrt(3f) / 3f;

        /// <summary>
        /// Get the hex type of this grid
        /// </summary>
        public HexType HexGridType => hexType;
        /// <summary>
        /// Get the edge length of the hex cell's of this grid
        /// </summary>
        public float EdgeLength => edgeLength;
        /// <summary>
        /// Get the origin position of the grid
        /// </summary>
        public Vector3 GridOriginPosition => gridOriginPosition;
        /// <summary>
        /// Get the number of positions in the grid
        /// </summary>
        public int Count => hexGrid.Count;

        /// <summary>
        /// Event to be raised when the value of a cell changes
        /// <param name="axialCoord">AxialCoord: the grid position where the value has changed</param>"
        /// <param name="value">T: the new value assigned to the position</param>"
        /// </summary>
        public event Action<AxialCoord, T> OnGridPositionValueChanged;

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
        public IEnumerator<T> GetEnumerator()
        {
            foreach (AxialCoord axialCoord in hexGrid.Keys)
            {
                yield return GetGridObjectAtAxialCoord(axialCoord);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Returns the AxialCoords of this grid
        /// </summary>
        /// <returns>AxialCoord of the grid</returns>
        public IEnumerable<AxialCoord> GetGridAxialCoords()
        {
            foreach (AxialCoord axialCoord in hexGrid.Keys)
            {
                yield return axialCoord;
            }
        }

        /// <summary>
        /// Returns the elements of the grid with their respective positions
        /// </summary>
        /// <returns>Element of the grid and the respective position</returns>
        public IEnumerable<(AxialCoord Coord, T Value)> GetGridObjectsWithPositions()
        {
            foreach (AxialCoord axialCoord in hexGrid.Keys)
            {
                yield return (axialCoord, GetGridObjectAtAxialCoord(axialCoord));
            }
        }

        /// <summary>
        /// Clear the grid and reset all the positions to their default values
        /// </summary>
        public void ClearGrid()
        {
            List<AxialCoord> keys = new List<AxialCoord>(hexGrid.Keys);
            foreach (AxialCoord axialCoord in keys)
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
            List<AxialCoord> keys = new List<AxialCoord>(hexGrid.Keys);
            foreach (AxialCoord axialCoord in keys)
            {
                SetGridObjectAtAxialCoord(axialCoord, value, true);
            }
        }

        /// <summary>
        /// Swap the values of two positions in the grid
        /// </summary>
        /// <param name="a">The first position</param>
        /// <param name="b">The second position</param>
        public void Swap(AxialCoord a, AxialCoord b)
        {
            if (!IsWithinHexGridBounds(a))
                throw new ArgumentException($"There is no grid position {a} in this grid");
            if (!IsWithinHexGridBounds(b))
                throw new ArgumentException($"There is no grid position {b} in this grid");

            T temp = GetGridObjectAtAxialCoord(a);
            SetGridObjectAtAxialCoord(a, GetGridObjectAtAxialCoord(b), true);
            SetGridObjectAtAxialCoord(b, temp, true);
        }

        /// <summary>
        /// Get an element from the grid on a specific AxialCoord
        /// </summary>
        /// <param name="axialCoord">The position to get the element from</param>
        /// <returns>The element at the specified position</returns>
        public T GetGridObjectAtAxialCoord(AxialCoord axialCoord)
        {
            if (hexGrid.TryGetValue(axialCoord, out T value))
                return value;

            throw new ArgumentException("Axial coordinates is out of bounds of the grid");
        }

        /// <summary>
        /// Attempts to retrieve the object of type <typeparamref name="T"/> located at the specified AxialCoord
        /// </summary>
        /// <param name="axialCoord">The position from which to retrieve the object</param>
        /// <param name="value">When this method returns, contains the object of type <typeparamref name="T"/> at the specified grid position if found, otherwise the default value for the type</param>
        /// <returns>True if an object exists at the specified grid position, false otherwise</returns>
        public bool TryGetGridObjectAtAxialCoord(AxialCoord axialCoord, out T value)
        {
            value = default(T);
            if (!IsWithinHexGridBounds(axialCoord))
                return false;

            value = GetGridObjectAtAxialCoord(axialCoord);
            return true;
        }

        /// <summary>
        /// Get an element from the grid based on a world position
        /// </summary>
        /// <param name="worldPosition">The world position to get the element from</param>
        /// <returns>The element at the specified world position</returns>
        public T GetGridObjectAtWorldPosition(Vector3 worldPosition)
        {
            if (TryGetAxialCoordFromWorldPosition(worldPosition, out AxialCoord axialCoord))
                return GetGridObjectAtAxialCoord(axialCoord);
            else
                throw new ArgumentException($"The world position {worldPosition} is out of the grid bounds");
        }

        /// <summary>
        /// Attempts to retrieve the object of type <typeparamref name="T"/> located at the specified world position
        /// </summary>
        /// <param name="worldPosition">The world position to retrieve the object</param>
        /// <param name="value">When this method returns, contains the object of type <typeparamref name="T"/> at the specified world position if found, otherwise the default value for the type</param>
        /// <returns>True if an object exists at the specified world position, false otherwise</returns>
        public bool TryGetGridObjectAtWorldPosition(Vector3 worldPosition, out T value)
        {
            value = default(T);
            if (!TryGetAxialCoordFromWorldPosition(worldPosition, out AxialCoord axialCoord))
                return false;
            value = GetGridObjectAtAxialCoord(axialCoord);
            return true;
        }

        /// <summary>
        /// Get a random object from the grid
        /// </summary>
        /// <returns>A random element from the grid</returns>
        public T GetRandomObject()
        {
            int index = RandomInt(hexGrid.Count);
            return hexGrid.Values.ElementAt(index);
        }

        /// <summary>
        /// Gets a random position from the grid
        /// </summary>
        /// <returns>A random position within the grid</returns>
        public AxialCoord GetRandomAxialCoord()
        {
            int index = RandomInt(hexGrid.Count);
            return hexGrid.Keys.ElementAt(index);
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
            if (!hexGrid.ContainsKey(axialCoord))
                throw new ArgumentException($"There is no axial coord {axialCoord} in this grid");

            if ((replaceIfExistAnObjectAlready) || // always replace
                (EqualityComparer<T>.Default.Equals(GetGridObjectAtAxialCoord(axialCoord), default))) // only replace if the position is empty (or default value in case of a non-nullable type)
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
            if (!IsWithinHexGridBounds(axialCoord))
                throw new ArgumentException("Axial coordinates is out of bounds of the grid");

            Vector3 worldPosition = Vector3.zero;

            float x, z;

            switch (hexType)
            {
                case HexType.FlatTop:
                    x = EdgeLength * (3f / 2f * axialCoord.Q);
                    z = EdgeLength * ((Sqrt3Over2 * axialCoord.Q) + (Sqrt3 * axialCoord.R));
                    worldPosition = new Vector3(x, 0f, z);
                    break;
                case HexType.PointTop:
                    x = EdgeLength * ((Sqrt3 * axialCoord.Q) + (Sqrt3Over2 * axialCoord.R));
                    z = EdgeLength * (3f / 2f * axialCoord.R);
                    worldPosition = new Vector3(x, 0f, z);
                    break;
                default:
                    break;
            }

            return worldPosition + GridOriginPosition;
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
            Vector3 vectorOffset = worldPosition - GridOriginPosition;
            AxialCoord axialCoord = default;

            float r, q;

            switch (hexType)
            {
                case HexType.FlatTop:
                    q = (2f / 3f * vectorOffset.x) / EdgeLength;
                    r = ((-1f / 3f * vectorOffset.x) + (Sqrt3Over3 * vectorOffset.z)) / EdgeLength;
                    axialCoord = RoundFrac(q, r);
                    break;
                case HexType.PointTop:
                    q = ((Sqrt3Over3 * vectorOffset.x) - (1f / 3 * vectorOffset.z)) / EdgeLength;
                    r = (2f / 3f * vectorOffset.z) / EdgeLength;
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

            return IsWithinHexGridBounds(axialCoord);
        }

        /// <summary>
        /// Check if any of the grid positions satisfies a condition
        /// </summary>
        /// <param name="predicate">The condition to check on each position</param>
        /// <returns>True if any position satisfies the condition, false otherwise</returns>
        public bool Any(Func<T, bool> predicate)
        {
            foreach (AxialCoord axialCoord in hexGrid.Keys)
            {
                if (predicate(GetGridObjectAtAxialCoord(axialCoord)))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Check if all grid positions satisfies a condition
        /// </summary>
        /// <param name="predicate">The condition to check on each position</param>
        /// <returns>True if all positions satisfies the condition, false otherwise</returns>
        public bool All(Func<T, bool> predicate)
        {
            foreach (AxialCoord axialCoord in hexGrid.Keys)
            {
                if (!predicate(GetGridObjectAtAxialCoord(axialCoord)))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Get all positions that satisfies a condition
        /// </summary>
        /// <param name="predicate">The condition to check on each position (params T: value at the position)</param>
        /// <returns>A list containing all the positions that satisfies the condition</returns>
        public List<AxialCoord> Where(Func<T, bool> predicate)
        {
            List<AxialCoord> axialCoords = new List<AxialCoord>();

            foreach (AxialCoord axialCoord in hexGrid.Keys)
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
            List<AxialCoord> keys = new List<AxialCoord>(hexGrid.Keys);
            foreach (AxialCoord axialCoord in keys)
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
            return EqualityComparer<T>.Default.Equals(GetGridObjectAtAxialCoord(axialCoord), default);
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

            foreach (AxialCoord coord in center.GetAxialCoordsWithinRange(range, includeCenterPosition))
            {
                if (IsWithinHexGridBounds(coord))
                    rangeList.Add(coord);
            }

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
                    hex = hex.Neighbours[i];
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
        /// Gets all the AxialCoord that forms a straight line between two positions in the grid
        /// </summary>
        /// <param name="start">The start of the line</param>
        /// <param name="end">The end of the line</param>
        /// <param name="includeStartAndEndPositions">Should the start and end positions be included in the return set</param>
        /// <returns>Set containing all the positions in the grid that forms the line</returns>
        public HashSet<AxialCoord> GetLineWithinBounds(AxialCoord start, AxialCoord end, bool includeStartAndEndPositions = true)
        {
            HashSet<AxialCoord> line = GetLine(start, end, includeStartAndEndPositions);
            line.IntersectWith(hexGrid.Keys);

            return line;
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

            if (distance == 0)
            {
                if (includeStartAndEndPositions)
                    linePoints.Add(start);
                return linePoints;
            }

            int startIndex = includeStartAndEndPositions ? 0 : 1;
            int endIndex = includeStartAndEndPositions ? distance : distance - 1;

            for (int i = startIndex; i <= endIndex; i++)
            {
                linePoints.Add(Lerp(start, end, (float)i / distance));
            }

            return linePoints;
        }

        /// <summary>
        /// Save a grid as JSON string (T and its members must be a serializable type)
        /// </summary>
        /// <param name="grid">The grid to save</param>
        /// <returns>The grid in a string JSON format</returns>
        public static string Save<TResult>(HexGrid<TResult> grid)
        {
            SerializableHexGrid<TResult> gridData = new SerializableHexGrid<TResult>(grid);
            string json = JsonUtility.ToJson(gridData);
            return json;
        }

        /// <summary>
        /// Load a grid from a JSON string (T and its members must be a serializable type)
        /// </summary>
        /// <param name="jsonData">The JSON string containing the serialized grid</param>
        /// <returns>The loaded grid</returns>
        public static SerializableHexGrid<TResult> Load<TResult>(string jsonData)
        {
            SerializableHexGrid<TResult> gridData = JsonUtility.FromJson<SerializableHexGrid<TResult>>(jsonData);

            return gridData;
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