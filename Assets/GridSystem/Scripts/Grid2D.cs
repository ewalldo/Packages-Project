using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace GridSystem
{
	public class Grid2D<T>
	{
        private int width;
        private int height;
        private float cellSizeX;
        private float cellSizeZ;
        private Vector3 gridOriginPosition;
        private T[,] gridObjectArray;

        /// <summary>
        /// Get the width of the grid
        /// </summary>
        public int GetWidth => width;
        /// <summary>
        /// Get the height of the grid
        /// </summary>
        public int GetHeight => height;
        /// <summary>
        /// Get the width of the grid's cell
        /// </summary>
        public float GetCellSizeX => cellSizeX;
        /// <summary>
        /// Get the height of the grid's cell
        /// </summary>
        public float GetCellSizeZ => cellSizeZ;
        /// <summary>
        /// Get the origin position of the grid
        /// </summary>
        public Vector3 GetGridOriginPosition => gridOriginPosition;
        /// <summary>
        /// Check if is a square grid (width == height)
        /// </summary>
        public bool IsSquareGrid => width == height;
        /// <summary>
        /// Check if the grid has square cells (cell's width == cell's height)
        /// </summary>
        public bool IsSquareGridCellSize => cellSizeX == cellSizeZ;

        /// <summary>
        /// Event to be raised when the value of a cell changes
        /// <param name="gridPosition2D">GridPosition2D: the grid position where the value has changed</param>"
        /// <param name="value">T: the new value assigned to the position</param>"
        /// </summary>
        public Action<GridPosition2D, T> OnGridPositionValueChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid{T}"/> class.
        /// </summary>
        /// <param name="width">The width of the grid</param>
        /// <param name="height">The height of the grid</param>
        /// <param name="cellSizeX">The width of the grid's cell</param>
        /// <param name="cellSizeZ">The height of the grid's cell</param>
        /// <param name="gridOriginPosition">The grid origin position</param>
        /// <param name="gridObjectInitializer">The initialize function for each grid element (Func<Grid2D<T>, GridPosition2D, T> where Grid2D<T> references this grid object and GridPosition2D references the position in the grid for the object)</param>
        public Grid2D(int width, int height, float cellSizeX, float cellSizeZ, Vector3 gridOriginPosition, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null)
        {
            if (width <= 0)
                throw new ArgumentException("Grid width cannot be zero or negative");
            if (height <= 0)
                throw new ArgumentException("Grid height cannot be zero or negative");
            if (cellSizeX <= 0)
                throw new ArgumentException("Grid cell size width cannot be zero or negative");
            if (cellSizeZ <= 0)
                throw new ArgumentException("Grid cell size height cannot be zero or negative");

            this.width = width;
            this.height = height;
            this.cellSizeX = cellSizeX;
            this.cellSizeZ = cellSizeZ;
            this.gridOriginPosition = gridOriginPosition;

            gridObjectArray = new T[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    GridPosition2D gridPosition2D = new GridPosition2D(x, z);

                    // ex: grid2D = new Grid2D<GridObject>(width, height, cellSize, cellSize, Vector3.Zero, (Grid2D<GridObject> g, GridPosition gridPosition) => new GridObject(g, gridPosition));
                    if (gridObjectInitializer != null)
                        gridObjectArray[x, z] = gridObjectInitializer(this, gridPosition2D);
                    else
                        gridObjectArray[x, z] = default(T);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid{T}"/> class.
        /// </summary>
        /// <param name="width">The width of the grid</param>
        /// <param name="height">The height of the grid</param>
        /// <param name="cellSizeX">The width of the grid's cell</param>
        /// <param name="cellSizeZ">The height of the grid's cell</param>
        /// <param name="gridObjectInitializer">The initialize function for each grid element (Func<Grid2D<T>, GridPosition2D, T> where Grid2D<T> references this grid object and GridPosition2D references the position in the grid for the object)</param>
        public Grid2D(int width, int height, float cellSizeX, float cellSizeZ, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null)
            : this(width, height, cellSizeX, cellSizeZ, Vector3.zero, gridObjectInitializer) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid{T}"/> class.
        /// </summary>
        /// <param name="width">The width of the grid</param>
        /// <param name="height">The height of the grid</param>
        /// <param name="cellSize">The size of each cell in the grid</param>
        /// <param name="gridOriginPosition">The grid origin position</param>
        /// <param name="gridObjectInitializer">The initialize function for each grid element (Func<Grid2D<T>, GridPosition2D, T> where Grid2D<T> references this grid object and GridPosition2D references the position in the grid for the object)</param>
        public Grid2D(int width, int height, float cellSize, Vector3 gridOriginPosition, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null)
            : this(width, height, cellSize, cellSize, gridOriginPosition, gridObjectInitializer) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid{T}"/> class.
        /// </summary>
        /// <param name="width">The width of the grid</param>
        /// <param name="height">The height of the grid</param>
        /// <param name="cellSize">The size of each cell in the grid</param>
        /// <param name="gridObjectInitializer">The initialize function for each grid element (Func<Grid2D<T>, GridPosition2D, T> where Grid2D<T> references this grid object and GridPosition2D references the position in the grid for the object)</param>
        public Grid2D(int width, int height, float cellSize, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null)
            : this(width, height, cellSize, cellSize, Vector3.zero, gridObjectInitializer) { }

        public T this[int x, int z]
        {
            get
            {
                GridPosition2D gridPosition2D = new GridPosition2D(x, z);

                return GetGridObjectAtGridPosition2D(gridPosition2D);
            }
            set
            {
                GridPosition2D gridPosition2D = new GridPosition2D(x, z);

                SetGridObjectAtGridPosition2D(gridPosition2D, value, true);
            }
        }

        public T this[GridPosition2D gridPosition2D]
        {
            get
            {
                return GetGridObjectAtGridPosition2D(gridPosition2D);
            }
            set
            {
                SetGridObjectAtGridPosition2D(gridPosition2D, value, true);
            }
        }

        public T this[Vector3 worldPosition]
        {
            get
            {
                return GetGridObjectAtWorldPosition(worldPosition);
            }
            set
            {
                SetGridObjectAtWorldPosition(worldPosition, value, true);
            }
        }

        /// <summary>
        /// Returns the elements of the grid
        /// </summary>
        /// <returns>Element of the grid</returns>
        public IEnumerable<T> GetGridObjects()
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    yield return GetGridObjectAtGridPosition2D(new GridPosition2D(x, z));
                }
            }
        }

        /// <summary>
        /// Returns the elements of a specific row
        /// </summary>
        /// <param name="rowIndex">The row to get the elements from</param>
        /// <returns>Element of the row</returns>
        public IEnumerable<T> GetRow(int rowIndex)
        {
            for (int z = 0; z < height; z++)
            {
                yield return GetGridObjectAtGridPosition2D(new GridPosition2D(rowIndex, z));
            }
        }

        /// <summary>
        /// Returns the elements of a specific column
        /// </summary>
        /// <param name="colIndex">The column to get the elements from</param>
        /// <returns>Element of the column</returns>
        public IEnumerable<T> GetCol(int colIndex)
        {
            for (int x = 0; x < width; x++)
            {
                yield return GetGridObjectAtGridPosition2D(new GridPosition2D(x, colIndex));
            }
        }

        /// <summary>
        /// Clear the grid and reset all the positions to their default values
        /// </summary>
        public void ClearGrid()
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    SetGridObjectAtGridPosition2D(new GridPosition2D(x, z), default(T), true);
                }
            }
        }

        /// <summary>
        /// Fill all the positions in the grid with a specific value
        /// </summary>
        /// <param name="value">The value to apply to every position</param>
        public void Fill(T value)
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    SetGridObjectAtGridPosition2D(new GridPosition2D(x, z), value, true);
                }
            }
        }

        /// <summary>
        /// Get an element from the grid based on a grid position
        /// </summary>
        /// <param name="gridPosition2D">The position to get the element from</param>
        /// <returns>The element at the specified grid position</returns>
        public T GetGridObjectAtGridPosition2D(GridPosition2D gridPosition2D)
        {
            return gridObjectArray[gridPosition2D.X, gridPosition2D.Z];
        }

        /// <summary>
        /// Get an element from the grid based on a world position
        /// </summary>
        /// <param name="worldPosition">The world position to get the element from</param>
        /// <returns>The element at the specified world position</returns>
        public T GetGridObjectAtWorldPosition(Vector3 worldPosition)
        {
            GridPosition2D gridPosition2D = GetGridPosition2DFromWorldPosition(worldPosition);

            return GetGridObjectAtGridPosition2D(gridPosition2D);
        }

        /// <summary>
        /// Get an random object from the grid
        /// </summary>
        /// <returns>A random element from the grid</returns>
        public T GetRandomGridObject()
        {
            System.Random random = new System.Random();
            int x = random.Next(width);
            int z = random.Next(height);
            return GetGridObjectAtGridPosition2D(new GridPosition2D(x, z));
        }

        // inclusive range
        /// <summary>
        /// Get a sub-grid from the original grid (inclusive interval)
        /// </summary>
        /// <param name="startRow">The start row of the subgrid</param>
        /// <param name="endRow">The end row of the subgrid (inclusive)</param>
        /// <param name="startColumn">The start column of the subgrid</param>
        /// <param name="endColumn">The end column of the subgrid</param>
        /// <param name="newGridOriginPosition">The original position for the subgrid</param>
        /// <returns>A subgrid containing the elements of the original grid</returns>
        public Grid2D<T> GetSubGrid(int startRow, int endRow, int startColumn, int endColumn, Vector3 newGridOriginPosition)
        {
            Grid2D<T> subGrid = new Grid2D<T>(endRow - startRow + 1, endColumn - startColumn + 1, cellSizeX, cellSizeZ, newGridOriginPosition);

            for (int x = startRow; x <= endRow; x++)
            {
                for (int z = startColumn; z <= endColumn; z++)
                {
                    GridPosition2D originalGridPosition2D = new GridPosition2D(x, z);
                    subGrid.SetGridObjectAtGridPosition2D(new GridPosition2D(x, z) - originalGridPosition2D, GetGridObjectAtGridPosition2D(originalGridPosition2D), true);
                }
            }

            return subGrid;
        }

        /// <summary>
        /// Gets a random position from the grid
        /// </summary>
        /// <returns>A random position within the grid</returns>
        public GridPosition2D GetRandomGridPosition()
        {
            System.Random random = new System.Random();
            int x = random.Next(width);
            int z = random.Next(height);
            return new GridPosition2D(x, z);
        }

        /// <summary>
        /// Set a grid object in a determined grid position
        /// </summary>
        /// <param name="gridPosition2D">The grid position of the object</param>
        /// <param name="newObject">The new object to set in the position</param>
        /// <param name="replaceIfExistAnObjectAlready">Replace even if the position already has been assigned</param>
        /// <returns>The new object was set successfully or not</returns>
        public bool SetGridObjectAtGridPosition2D(GridPosition2D gridPosition2D, T newObject, bool replaceIfExistAnObjectAlready = true)
        {
            if (replaceIfExistAnObjectAlready) // always replace
            {
                gridObjectArray[gridPosition2D.X, gridPosition2D.Z] = newObject;
                OnGridPositionValueChanged?.Invoke(gridPosition2D, newObject);
                return true;
            }
            // replace if empty position only
            else if (default(T) is null && gridObjectArray[gridPosition2D.X, gridPosition2D.Z] == null) // check if it is a nullable type AND if it is, check if the position is null, if yes set the position
            {
                gridObjectArray[gridPosition2D.X, gridPosition2D.Z] = newObject;
                OnGridPositionValueChanged?.Invoke(gridPosition2D, newObject);
                return true;
            }
            else if (gridObjectArray[gridPosition2D.X, gridPosition2D.Z].Equals(default(T))) // it is a non-nullable type, check if the position is at default value, if yes set the position
            {
                gridObjectArray[gridPosition2D.X, gridPosition2D.Z] = newObject;
                OnGridPositionValueChanged?.Invoke(gridPosition2D, newObject);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Set an object in the grid based on its world position
        /// </summary>
        /// <param name="worldPosition">The world position of the object</param>
        /// <param name="newObject">The new object to set on the position</param>
        /// <param name="replaceIfExistAnObjectAlready">Replace even if the position already has been assigned</param>
        /// <returns>The new object was set successfully or not</returns>
        public bool SetGridObjectAtWorldPosition(Vector3 worldPosition, T newObject, bool replaceIfExistAnObjectAlready = true)
        {
            GridPosition2D gridPosition2D = GetGridPosition2DFromWorldPosition(worldPosition);

            return SetGridObjectAtGridPosition2D(gridPosition2D, newObject, replaceIfExistAnObjectAlready);
        }

        /// <summary>
        /// Converts a gridPosition to a world position
        /// </summary>
        /// <param name="gridPosition2D">The grid position to convert</param>
        /// <returns>The position in world coordinates</returns>
        public Vector3 GetWorldPositionFromGridPosition2D(GridPosition2D gridPosition2D)
        {
            return new Vector3(gridPosition2D.X * cellSizeX, 0, gridPosition2D.Z * cellSizeZ) + gridOriginPosition;
        }

        /// <summary>
        /// Converts the center of a gridPosition to a world position
        /// </summary>
        /// <param name="gridPosition2D">The grid position to convert</param>
        /// <returns>The position in world coordinates at the center of the gridPosition</returns>
        public Vector3 GetWorldPositionFromCenterGridPosition2D(GridPosition2D gridPosition2D)
        {
            return GetWorldPositionFromGridPosition2D(gridPosition2D) + new Vector3(cellSizeX / 2f, 0f, cellSizeZ / 2f);
        }

        /// <summary>
        /// Try to convert a gridPosition into a world position
        /// </summary>
        /// <param name="gridPosition2D">The grid position to convert</param>
        /// <param name="worldPosition">The position in world coordinates</param>
        /// <returns>If it is able to convert the grid position to a world one</returns>
        public bool TryGetWorldPositionFromGridPosition2D(GridPosition2D gridPosition2D, out Vector3 worldPosition)
        {
            worldPosition = Vector3.zero;
            if (!IsWithinGrid2DBounds(gridPosition2D))
                return false;

            worldPosition = GetWorldPositionFromGridPosition2D(gridPosition2D);
            return true;
        }

        /// <summary>
        /// Try to convert the center of a gridPosition into a world position
        /// </summary>
        /// <param name="gridPosition2D">The grid position to convert</param>
        /// <param name="worldPosition">The position in world coordinates at the center of the grid position</param>
        /// <returns>If it is able to convert the center of grid position to a world one</returns>
        public bool TryGetWorldPositionFromCenterGridPosition2D(GridPosition2D gridPosition2D, out Vector3 worldPosition)
        {
            worldPosition = Vector3.zero;
            if (!IsWithinGrid2DBounds(gridPosition2D))
                return false;

            worldPosition = GetWorldPositionFromCenterGridPosition2D(gridPosition2D);
            return true;
        }

        /// <summary>
        /// Converts a world position to a grid position
        /// </summary>
        /// <param name="worldPosition">The world position to convert from</param>
        /// <returns>The grid position related to the world one</returns>
        public GridPosition2D GetGridPosition2DFromWorldPosition(Vector3 worldPosition)
        {
            Vector3 vectorOffset = worldPosition - gridOriginPosition;
            GridPosition2D gridPosition2D = new GridPosition2D(Mathf.FloorToInt(vectorOffset.x / cellSizeX), Mathf.FloorToInt(vectorOffset.z / cellSizeZ));

            return gridPosition2D;
        }

        /// <summary>
        /// Try to convert a world position into a grid position
        /// </summary>
        /// <param name="worldPosition">The world position to try to convert from</param>
        /// <param name="gridPosition2D">The result in grid coordinates</param>
        /// <returns>If the world position is able to be converted into a grid position</returns>
        public bool TryGetGridPosition2DFromWorldPosition(Vector3 worldPosition, out GridPosition2D gridPosition2D)
        {
            gridPosition2D = GetGridPosition2DFromWorldPosition(worldPosition);

            if (!IsWithinGrid2DBounds(gridPosition2D))
                return false;

            return true;
        }

        /// <summary>
        /// Gets all the grid positions that satisfies a condition
        /// </summary>
        /// <param name="predicate">The condition to check on each position (params T: value at the position)</param>
        /// <returns>A list containing all the positions that satisfies the condition</returns>
        public List<GridPosition2D> GetGridPositionsInACertainState(Func<T, bool> predicate)
        {
            List<GridPosition2D> gridPositions = new List<GridPosition2D>();

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    GridPosition2D gridPosition2D = new GridPosition2D(x, z);
                    if (predicate(GetGridObjectAtGridPosition2D(gridPosition2D)))
                        gridPositions.Add(gridPosition2D);
                }
            }

            return gridPositions;
        }

        /// <summary>
        /// Execute an action for every position in the grid
        /// </summary>
        /// <param name="action">Action to apply on every grid position (params GridPosition2D: grid position, T: value at the position)</param>
        public void IterateOverAllGridPositions(Action<GridPosition2D, T> action)
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    GridPosition2D gridPosition2D = new GridPosition2D(x, z);
                    action(gridPosition2D, GetGridObjectAtGridPosition2D(gridPosition2D));
                }
            }
        }

        /// <summary>
        /// Check if a grid position is within the grid bounds
        /// </summary>
        /// <param name="gridPosition2D">The grid position to check</param>
        /// <returns>The grid position is within bounds or not</returns>
        public bool IsWithinGrid2DBounds(GridPosition2D gridPosition2D)
        {
            return gridPosition2D.X >= 0 && gridPosition2D.X < width && gridPosition2D.Z >= 0 && gridPosition2D.Z < height;
        }

        /// <summary>
        /// Check if a coordinate is within the grid bounds
        /// </summary>
        /// <param name="x">The x-coordinate to check</param>
        /// <param name="z">The z-coordinate to check</param>
        /// <returns>The coordinates are within the grid or not</returns>
        public bool IsWithinGrid2DBounds(int x, int z)
        {
            return IsWithinGrid2DBounds(new GridPosition2D(x, z));
        }

        /// <summary>
        /// Check if a world position if within the grid bounds
        /// </summary>
        /// <param name="worldPosition">The world position to check</param>
        /// <returns>If the world position is within the grid or not</returns>
        public bool IsWithinGrid2DBounds(Vector3 worldPosition)
        {
            return TryGetGridPosition2DFromWorldPosition(worldPosition, out _);
        }

        /// <summary>
        /// Check if all the grid positions are within the grid bounds
        /// </summary>
        /// <param name="gridPositions2D">Collection containing all the positions to check</param>
        /// <returns>If ALL the positions are within the grid or not</returns>
        public bool IsWithinGrid2DBounds(IEnumerable<GridPosition2D> gridPositions2D)
        {
            foreach (GridPosition2D gridPosition2D in gridPositions2D)
            {
                if (!IsWithinGrid2DBounds(gridPosition2D))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Check if a grid position is empty (or default value in case of a non-nullable type)
        /// </summary>
        /// <param name="gridPosition2D">The grid position to check</param>
        /// <returns>If the position is empty or not</returns>
        public bool IsPositionEmpty(GridPosition2D gridPosition2D)
        {
            if (default(T) is null)
                return GetGridObjectAtGridPosition2D(gridPosition2D) == null;
            else
                return GetGridObjectAtGridPosition2D(gridPosition2D).Equals(default(T));
        }

        /// <summary>
        /// Check if a grid position is empty (or default value in case of a non-nullable type)
        /// </summary>
        /// <param name="x">The x-coordinate to check</param>
        /// <param name="z">The z-coordinate to check</param>
        /// <returns>If the position is empty or not</returns>
        public bool IsPositionEmpty(int x, int z)
        {
            GridPosition2D gridPosition2D = new GridPosition2D(x, z);

            return IsPositionEmpty(gridPosition2D);
        }

        /// <summary>
        /// Check if a grid position is empty (or default value in case of a non-nullable type) based on world coordinates
        /// </summary>
        /// <param name="worldPosition">The world position to check</param>
        /// <returns>If the position is empty or not</returns>
        public bool IsPositionEmpty(Vector3 worldPosition)
        {
            GridPosition2D gridPosition2D = GetGridPosition2DFromWorldPosition(worldPosition);

            return IsPositionEmpty(gridPosition2D);
        }

        /// <summary>
        /// Get all the adjacent neighbours of a specific position
        /// </summary>
        /// <param name="center">The center position to get the neighbours from</param>
        /// <param name="includeCenterPosition">Should include the center position in the return list</param>
        /// <param name="includeDiagonalNeighbours">Should include diagonal neighbours in the return list</param>
        /// <returns>List containing all the neighbour positions of a specific grid position</returns>
        public List<GridPosition2D> GetAdjacentNeighbours(GridPosition2D center, bool includeCenterPosition = false, bool includeDiagonalNeighbours = false)
        {
            List<GridPosition2D> neighboursList = new List<GridPosition2D>();

            for (int x = -1; x <= 1; x++)
            {
                for (int z = -1; z <= 1; z++)
                {
                    GridPosition2D gridPositionNeighbour = center + (new GridPosition2D(x, z));

                    if (!IsWithinGrid2DBounds(gridPositionNeighbour))
                        continue;

                    if (center == gridPositionNeighbour && !includeCenterPosition)
                        continue;

                    if (!includeDiagonalNeighbours)
                    {
                        if (x != 0 && z != 0)
                            continue;
                    }

                    neighboursList.Add(gridPositionNeighbour);
                }
            }

            return neighboursList;
        }

        /// <summary>
        /// Get all the grid positions within a range
        /// </summary>
        /// <param name="center">The center position to calculate the range from</param>
        /// <param name="range">The lenght of the range (in grid units)</param>
        /// <param name="includeCenterPosition">Should include the center position in the return list</param>
        /// <returns>List containing all the positions within a certain range</returns>
        public List<GridPosition2D> GetGridPositionsFromADistanceRange(GridPosition2D center, int range, bool includeCenterPosition = false)
        {
            List<GridPosition2D> rangeList = new List<GridPosition2D>();

            for (int x = -range; x <= range; x++)
            {
                for (int z = -range; z <= range; z++)
                {
                    if (Mathf.Abs(x) + Mathf.Abs(z) > range)
                        continue;

                    GridPosition2D testGridPosition = center + (new GridPosition2D(x, z));

                    if (!IsWithinGrid2DBounds(testGridPosition))
                        continue;

                    if (center == testGridPosition && !includeCenterPosition)
                        continue;

                    rangeList.Add(testGridPosition);
                }
            }

            return rangeList;
        }

        /// <summary>
        /// Get all the grid position within a square range
        /// </summary>
        /// <param name="center">The center position to calculate the range from</param>
        /// <param name="range">The length of the range (in grid units)</param>
        /// <param name="includeCenterPosition">Should include the center position in the return list</param>
        /// <returns>List containing all the positions within a certain square range</returns>
        public List<GridPosition2D> GetGridPositionsFromASquareRange(GridPosition2D center, int range, bool includeCenterPosition = false)
        {
            List<GridPosition2D> rangeList = new List<GridPosition2D>();

            for (int x = -range; x <= range; x++)
            {
                for (int z = -range; z <= range; z++)
                {
                    GridPosition2D testGridPosition = center + (new GridPosition2D(x, z));

                    if (!IsWithinGrid2DBounds(testGridPosition))
                        continue;

                    if (center == testGridPosition && !includeCenterPosition)
                        continue;

                    rangeList.Add(testGridPosition);
                }
            }

            return rangeList;
        }

        /// <summary>
        /// Instantiate a game object in a certain grid position
        /// </summary>
        /// <param name="gridPosition2D">The grid position to instantiate the object on (will be instantiatd at its center)</param>
        /// <param name="gameObjectPrefab">The object to instantiate</param>
        /// <param name="objectParent">The parent transform for the instantiated object</param>
        /// <param name="onGameObjectSpawned">Action to execute when the object is instantiated (params GameObject: the instantiated game object)</param>
        /// <returns>The instantiated game object</returns>
        public GameObject InstantiateGameObjectAtGridPosition(GridPosition2D gridPosition2D, GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onGameObjectSpawned = null)
        {
            GameObject spawnedGameObject = GameObject.Instantiate(gameObjectPrefab, GetWorldPositionFromCenterGridPosition2D(gridPosition2D), Quaternion.identity, objectParent);

            onGameObjectSpawned?.Invoke(spawnedGameObject);
            return spawnedGameObject;
        }

        /// <summary>
        /// Instantiate a game object in the grid based on a world position
        /// </summary>
        /// <param name="worldPosition">The world position to instantiate the object</param>
        /// <param name="gameObjectPrefab">The object to instantiate</param>
        /// <param name="objectParent">The parent transform for the instantiated object</param>
        /// <param name="onGameObjectSpawned">Action to execute when the object is instantiated (params GameObject: the instantiated game object)</param>
        /// <returns>The instantiated game object</returns>
        public GameObject InstantiateGameObjectAtWorldPosition(Vector3 worldPosition, GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onGameObjectSpawned = null)
        {
            GridPosition2D gridPosition2D = GetGridPosition2DFromWorldPosition(worldPosition);

            return InstantiateGameObjectAtGridPosition(gridPosition2D, gameObjectPrefab, objectParent, onGameObjectSpawned);
        }

        /// <summary>
        /// Instantiate a game object on every grid position
        /// </summary>
        /// <param name="gameObjectPrefab">The object to instantiate</param>
        /// <param name="objectParent">The parent transform for all objects</param>
        /// <param name="onEachGameObjectSpawned">Action to execute when one object is instantiated (params GameObject: the instantiated game object)</param>
        /// <param name="onAllGameObjectSpawned">Action to execute after all objecta are instantiated (params List<GameObject>: all the instantiated game objects)</param>
        /// <returns>A list containing all the instantiated game objects</returns>
        public List<GameObject> InstantiateGameObjectsAtEveryGridPosition(GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onEachGameObjectSpawned = null, Action<List<GameObject>> onAllGameObjectSpawned = null)
        {
            List<GameObject> spawnedGameObjectList = new List<GameObject>();

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    GridPosition2D gridPosition2D = new GridPosition2D(x, z);
                    GameObject spawnedGameObject = InstantiateGameObjectAtGridPosition(gridPosition2D, gameObjectPrefab, objectParent, onEachGameObjectSpawned);

                    spawnedGameObjectList.Add(spawnedGameObject);
                }
            }

            onAllGameObjectSpawned?.Invoke(spawnedGameObjectList);

            return spawnedGameObjectList;
        }

        /// <summary>
        /// Save/serialize the grid using a binary formatter (T and its members must be a serializable type)
        /// </summary>
        /// <param name="filename">The file to be opened/created for writing</param>
        /// <returns>If the save operation was successful or not</returns>
        public bool Save(string filename)
        {
            try
            {
                using (FileStream stream = File.OpenWrite(filename))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, gridObjectArray);
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
        /// <returns>If the load operation was sucessful or not</returns>
        public bool Load(string filename)
        {
            try
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    gridObjectArray = (T[,])formatter.Deserialize(stream);

                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error loading grid: " + e.Message);
                return false;
            }
        }
    }
}