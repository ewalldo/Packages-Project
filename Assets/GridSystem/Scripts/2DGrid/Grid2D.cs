using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
	public class Grid2D<T> : IEnumerable<T>
    {
        private readonly int width;
        private readonly int height;
        private readonly float cellSizeX;
        private readonly float cellSizeZ;
        private readonly Vector3 gridOriginPosition;
        private Dictionary<GridPosition2D, T> grid;

        private static int RandomInt(int max) => UnityEngine.Random.Range(0, max);

        /// <summary>
        /// Get the width of the grid
        /// </summary>
        public int Width => width;
        /// <summary>
        /// Get the height of the grid
        /// </summary>
        public int Height => height;
        /// <summary>
        /// Get the total number of cells in the grid
        /// </summary>
        public int Count => Width * Height;
        /// <summary>
        /// Get the width of the grid's cell
        /// </summary>
        public float CellSizeX => cellSizeX;
        /// <summary>
        /// Get the height of the grid's cell
        /// </summary>
        public float CellSizeZ => cellSizeZ;
        /// <summary>
        /// Get the origin position of the grid
        /// </summary>
        public Vector3 GridOriginPosition => gridOriginPosition;
        /// <summary>
        /// Check if is a square grid (width == height)
        /// </summary>
        public bool IsSquareGrid => Width == Height;
        /// <summary>
        /// Check if the grid has square cells (cell's width == cell's height)
        /// </summary>
        public bool IsSquareGridCellSize => Mathf.Approximately(CellSizeX, CellSizeZ);

        /// <summary>
        /// Event to be raised when the value of a cell changes
        /// <param name="gridPosition2D">GridPosition2D: the grid position where the value has changed</param>"
        /// <param name="value">T: the new value assigned to the position</param>"
        /// </summary>
        public event Action<GridPosition2D, T> OnGridPositionValueChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid2D{T}"/> class.
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

            grid = new Dictionary<GridPosition2D, T>();

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    GridPosition2D gridPosition2D = new GridPosition2D(x, z);

                    // ex: grid2D = new Grid2D<GridObject>(width, height, cellSize, cellSize, Vector3.Zero, (Grid2D<GridObject> g, GridPosition gridPosition) => new GridObject(g, gridPosition));
                    if (gridObjectInitializer != null)
                        grid[gridPosition2D] = gridObjectInitializer(this, gridPosition2D);
                    else
                        grid[gridPosition2D] = default(T);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid2D{T}"/> class.
        /// </summary>
        /// <param name="width">The width of the grid</param>
        /// <param name="height">The height of the grid</param>
        /// <param name="cellSizeX">The width of the grid's cell</param>
        /// <param name="cellSizeZ">The height of the grid's cell</param>
        /// <param name="gridObjectInitializer">The initialize function for each grid element (Func<Grid2D<T>, GridPosition2D, T> where Grid2D<T> references this grid object and GridPosition2D references the position in the grid for the object)</param>
        public Grid2D(int width, int height, float cellSizeX, float cellSizeZ, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null)
            : this(width, height, cellSizeX, cellSizeZ, Vector3.zero, gridObjectInitializer) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid2D{T}"/> class.
        /// </summary>
        /// <param name="width">The width of the grid</param>
        /// <param name="height">The height of the grid</param>
        /// <param name="cellSize">The size of each cell in the grid</param>
        /// <param name="gridOriginPosition">The grid origin position</param>
        /// <param name="gridObjectInitializer">The initialize function for each grid element (Func<Grid2D<T>, GridPosition2D, T> where Grid2D<T> references this grid object and GridPosition2D references the position in the grid for the object)</param>
        public Grid2D(int width, int height, float cellSize, Vector3 gridOriginPosition, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null)
            : this(width, height, cellSize, cellSize, gridOriginPosition, gridObjectInitializer) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Grid2D{T}"/> class.
        /// </summary>
        /// <param name="width">The width of the grid</param>
        /// <param name="height">The height of the grid</param>
        /// <param name="cellSize">The size of each cell in the grid</param>
        /// <param name="gridObjectInitializer">The initialize function for each grid element (Func<Grid2D<T>, GridPosition2D, T> where Grid2D<T> references this grid object and GridPosition2D references the position in the grid for the object)</param>
        public Grid2D(int width, int height, float cellSize, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null)
            : this(width, height, cellSize, cellSize, Vector3.zero, gridObjectInitializer) { }

        public T this[int x, int z]
        {
            get => GetGridObjectAtGridPosition2D(new GridPosition2D(x, z));
            set => SetGridObjectAtGridPosition2D(new GridPosition2D(x, z), value, true);
        }

        public T this[GridPosition2D gridPosition2D]
        {
            get => GetGridObjectAtGridPosition2D(gridPosition2D);
            set => SetGridObjectAtGridPosition2D(gridPosition2D, value, true);
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
            for (int x = 0; x < Width; x++)
            {
                for (int z = 0; z < Height; z++)
                {
                    yield return GetGridObjectAtGridPosition2D(new GridPosition2D(x, z));
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Returns the elements of the grid with their respective positions
        /// </summary>
        /// <returns>Element of the grid and the respective position</returns>
        public IEnumerable<(GridPosition2D Position, T Value)> GetGridObjectsWithPositions()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int z = 0; z < Height; z++)
                {
                    var pos = new GridPosition2D(x, z);
                    yield return (pos, GetGridObjectAtGridPosition2D(pos));
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
            if (rowIndex < 0 || rowIndex >= Height)
                throw new ArgumentOutOfRangeException(nameof(rowIndex));

            for (int x = 0; x < Width; x++)
            {
                yield return GetGridObjectAtGridPosition2D(new GridPosition2D(x, rowIndex));
            }
        }

        /// <summary>
        /// Returns the elements of a specific column
        /// </summary>
        /// <param name="colIndex">The column to get the elements from</param>
        /// <returns>Element of the column</returns>
        public IEnumerable<T> GetCol(int colIndex)
        {
            if (colIndex < 0 || colIndex >= Width)
                throw new ArgumentOutOfRangeException(nameof(colIndex));

            for (int z = 0; z < Height; z++)
            {
                yield return GetGridObjectAtGridPosition2D(new GridPosition2D(colIndex, z));
            }
        }

        /// <summary>
        /// Clear the grid and reset all the positions to their default values
        /// </summary>
        public void ClearGrid()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int z = 0; z < Height; z++)
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
            for (int x = 0; x < Width; x++)
            {
                for (int z = 0; z < Height; z++)
                {
                    SetGridObjectAtGridPosition2D(new GridPosition2D(x, z), value, true);
                }
            }
        }

        /// <summary>
        /// Map the grid to a new grid with the same dimensions but with different type of elements based on a mapping function
        /// </summary>
        /// <param name="mapper">The mapping function</param>
        /// <returns>A new grid with the mapped values</returns>
        public Grid2D<TResult> Map<TResult>(Func<T, TResult> mapper)
        {
            Grid2D<TResult> mappedGrid = new Grid2D<TResult>(Width, Height, CellSizeX, CellSizeZ, GridOriginPosition);

            for (int x = 0; x < Width; x++)
            {
                for (int z = 0; z < Height; z++)
                {
                    GridPosition2D gridPosition2D = new GridPosition2D(x, z);
                    mappedGrid.SetGridObjectAtGridPosition2D(gridPosition2D, mapper(GetGridObjectAtGridPosition2D(gridPosition2D)), true);
                }
            }

            return mappedGrid;
        }

        /// <summary>
        /// Swap the values of two positions in the grid
        /// </summary>
        /// <param name="a">The first position</param>
        /// <param name="b">The second position</param>
        public void Swap(GridPosition2D a, GridPosition2D b)
        {
            if (!IsWithinGrid2DBounds(a))
                throw new ArgumentException($"There is no grid position {a} in this grid");
            if (!IsWithinGrid2DBounds(b))
                throw new ArgumentException($"There is no grid position {b} in this grid");

            T temp = GetGridObjectAtGridPosition2D(a);
            SetGridObjectAtGridPosition2D(a, GetGridObjectAtGridPosition2D(b), true);
            SetGridObjectAtGridPosition2D(b, temp, true);
        }

        /// <summary>
        /// Get an element from the grid based on a grid position
        /// </summary>
        /// <param name="gridPosition2D">The position to get the element from</param>
        /// <returns>The element at the specified grid position</returns>
        public T GetGridObjectAtGridPosition2D(GridPosition2D gridPosition2D)
        {
            if (grid.TryGetValue(gridPosition2D, out T value))
                return value;
            else
                throw new ArgumentException($"There is no grid position {gridPosition2D} in this grid");
        }

        /// <summary>
        /// Attempts to retrieve the object of type <typeparamref name="T"/> located at the specified 2D grid position
        /// </summary>
        /// <param name="gridPosition2D">The 2D grid position from which to retrieve the object</param>
        /// <param name="value">When this method returns, contains the object of type <typeparamref name="T"/> at the specified grid position if found, otherwise the default value for the type</param>
        /// <returns>True if an object exists at the specified grid position, false otherwise</returns>
        public bool TryGetGridObjectAtGridPosition2D(GridPosition2D gridPosition2D, out T value)
        {
            value = default(T);
            if (!IsWithinGrid2DBounds(gridPosition2D))
                return false;

            value = GetGridObjectAtGridPosition2D(gridPosition2D);
            return true;
        }

        /// <summary>
        /// Get an element from the grid based on a world position
        /// </summary>
        /// <param name="worldPosition">The world position to get the element from</param>
        /// <returns>The element at the specified world position</returns>
        public T GetGridObjectAtWorldPosition(Vector3 worldPosition)
        {
            if (TryGetGridPosition2DFromWorldPosition(worldPosition, out GridPosition2D gridPosition2D))
                return GetGridObjectAtGridPosition2D(gridPosition2D);
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
            if (!TryGetGridPosition2DFromWorldPosition(worldPosition, out GridPosition2D gridPosition2D))
                return false;
            value = GetGridObjectAtGridPosition2D(gridPosition2D);
            return true;
        }

        /// <summary>
        /// Get a random object from the grid
        /// </summary>
        /// <returns>A random element from the grid</returns>
        public T GetRandomGridObject()
        {
            int x = RandomInt(Width);
            int z = RandomInt(Height);
            return GetGridObjectAtGridPosition2D(new GridPosition2D(x, z));
        }

        /// <summary>
        /// Get a sub-grid from the original grid (inclusive interval)
        /// </summary>
        /// <param name="startX">The start X-value of the subgrid</param>
        /// <param name="endX">The end X-value of the subgrid</param>
        /// <param name="startZ">The start Z-value of the subgrid</param>
        /// <param name="endZ">The end Z-value of the subgrid</param>
        /// <param name="newGridOriginPosition">The origin position for the subgrid</param>
        /// <returns>A subgrid containing the elements of the original grid</returns>
        public Grid2D<T> GetSubGrid(int startX, int endX, int startZ, int endZ, Vector3 newGridOriginPosition)
        {
            if (startX < 0 || startX >= Width)
                throw new ArgumentOutOfRangeException(nameof(startX));
            if (endX < 0 || endX >= Width || endX < startX)
                throw new ArgumentOutOfRangeException(nameof(endX));
            if (startZ < 0 || startZ >= Height)
                throw new ArgumentOutOfRangeException(nameof(startZ));
            if (endZ < 0 || endZ >= Height || endZ < startZ)
                throw new ArgumentOutOfRangeException(nameof(endZ));

            Grid2D<T> subGrid = new Grid2D<T>(endX - startX + 1, endZ - startZ + 1, CellSizeX, CellSizeZ, newGridOriginPosition);

            for (int x = startX; x <= endX; x++)
            {
                for (int z = startZ; z <= endZ; z++)
                {
                    subGrid.SetGridObjectAtGridPosition2D(new GridPosition2D(x - startX, z - startZ), GetGridObjectAtGridPosition2D(new GridPosition2D(x, z)), true);
                }
            }

            return subGrid;
        }

        /// <summary>
        /// Get a sub-grid from the original grid (inclusive interval)
        /// </summary>
        /// <param name="start">The start grid position of the subgrid</param>
        /// <param name="end">The end grid position of the subgrid</param>
        /// <param name="newGridOriginPosition">The origin position for the subgrid</param>
        /// <returns>A subgrid containing the elements of the original grid</returns>
        public Grid2D<T> GetSubGrid(GridPosition2D start, GridPosition2D end, Vector3 newGridOriginPosition)
        {
            return GetSubGrid(start.X, end.X, start.Z, end.Z, newGridOriginPosition);
        }

        /// <summary>
        /// Gets a random position from the grid
        /// </summary>
        /// <returns>A random position within the grid</returns>
        public GridPosition2D GetRandomGridPosition()
        {
            int x = RandomInt(Width);
            int z = RandomInt(Height);
            return new GridPosition2D(x, z);
        }

        /// <summary>
        /// Gets the wrapped position of the grid
        /// </summary>
        /// <param name="x">The x-coordinate of the position</param>
        /// <param name="z">The z-coordinate of the position</param>
        /// <returns>The wrapped position</returns>
        public GridPosition2D GetWrappedGridPosition(int x, int z)
        {
            int wrappedX = ((x % Width) + Width) % Width;
            int wrappedZ = ((z % Height) + Height) % Height;
            return new GridPosition2D(wrappedX, wrappedZ);
        }

        /// <summary>
        /// Gets the wrapped position of the grid
        /// </summary>
        /// <param name="gridPosition">The grid position coordinate</param>
        /// <returns>The wrapped position</returns>
        public GridPosition2D GetWrappedGridPosition(GridPosition2D gridPosition)
        {
            return GetWrappedGridPosition(gridPosition.X, gridPosition.Z);
        }

        /// <summary>
        /// Set a grid object in a determined grid position
        /// </summary>
        /// <param name="gridPosition2D">The grid position of the object</param>
        /// <param name="newObject">The new object to set in the position</param>
        /// <param name="replaceIfExistAnObjectAlready">Replace even if the position already has been assigned</param>
        /// <returns>True if the object was set successfully, false otherwise</returns>
        public bool SetGridObjectAtGridPosition2D(GridPosition2D gridPosition2D, T newObject, bool replaceIfExistAnObjectAlready = true)
        {
            if (!grid.ContainsKey(gridPosition2D))
                throw new ArgumentException($"There is no grid position {gridPosition2D} in this grid");

            if ((replaceIfExistAnObjectAlready) || // always replace
                (EqualityComparer<T>.Default.Equals(GetGridObjectAtGridPosition2D(gridPosition2D), default))) // only replace if the position is empty (or default value in case of a non-nullable type)
            {
                grid[gridPosition2D] = newObject;
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
        /// <returns>True if the object was set successfully, false otherwise</returns>
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
            return new Vector3(gridPosition2D.X * CellSizeX, 0, gridPosition2D.Z * CellSizeZ) + GridOriginPosition;
        }

        /// <summary>
        /// Converts the center of a gridPosition to a world position
        /// </summary>
        /// <param name="gridPosition2D">The grid position to convert</param>
        /// <returns>The position in world coordinates at the center of the gridPosition</returns>
        public Vector3 GetWorldPositionFromCenterGridPosition2D(GridPosition2D gridPosition2D)
        {
            return GetWorldPositionFromGridPosition2D(gridPosition2D) + new Vector3(CellSizeX / 2f, 0f, CellSizeZ / 2f);
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
            Vector3 vectorOffset = worldPosition - GridOriginPosition;
            GridPosition2D gridPosition2D = new GridPosition2D(Mathf.FloorToInt(vectorOffset.x / CellSizeX), Mathf.FloorToInt(vectorOffset.z / CellSizeZ));

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

            return IsWithinGrid2DBounds(gridPosition2D);
        }

        /// <summary>
        /// Check if any of the grid positions satisfies a condition
        /// </summary>
        /// <param name="predicate">The condition to check on each position</param>
        /// <returns>True if any position satisfies the condition, false otherwise</returns>
        public bool Any(Func<T, bool> predicate)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int z = 0; z < Height; z++)
                {
                    if (predicate(GetGridObjectAtGridPosition2D(new GridPosition2D(x, z))))
                        return true;
                }
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
            for (int x = 0; x < Width; x++)
            {
                for (int z = 0; z < Height; z++)
                {
                    if (!predicate(GetGridObjectAtGridPosition2D(new GridPosition2D(x, z))))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Gets all the grid positions that satisfies a condition
        /// </summary>
        /// <param name="predicate">The condition to check on each position (params T: value at the position)</param>
        /// <returns>A list containing all the positions that satisfies the condition</returns>
        public List<GridPosition2D> Where(Func<T, bool> predicate)
        {
            List<GridPosition2D> gridPositions = new List<GridPosition2D>();

            for (int x = 0; x < Width; x++)
            {
                for (int z = 0; z < Height; z++)
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
            for (int x = 0; x < Width; x++)
            {
                for (int z = 0; z < Height; z++)
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
            return gridPosition2D.X >= 0 && gridPosition2D.X < Width && gridPosition2D.Z >= 0 && gridPosition2D.Z < Height;
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
            return EqualityComparer<T>.Default.Equals(GetGridObjectAtGridPosition2D(gridPosition2D), default);
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

            foreach (GridPosition2D neighbour in includeDiagonalNeighbours ? center.Neighbours : center.DirectNeighbours)
            {
                if (IsWithinGrid2DBounds(neighbour))
                    neighboursList.Add(neighbour);
            }

            if (includeCenterPosition)
                neighboursList.Add(center);

            return neighboursList;
        }

        /// <summary>
        /// Get all the grid positions within a range
        /// </summary>
        /// <param name="center">The center position to calculate the range from</param>
        /// <param name="range">The lenght of the range (in grid units)</param>
        /// <param name="includeCenterPosition">Should include the center position in the return list</param>
        /// <returns>List containing all the positions within the range</returns>
        public List<GridPosition2D> GetGridPositionsFromADistanceRange(GridPosition2D center, int range, bool includeCenterPosition = false)
        {
            List<GridPosition2D> rangeList = new List<GridPosition2D>();

            foreach (GridPosition2D inRange in center.GetGridPositionsFromADistanceRange(range, includeCenterPosition))
            {
                if (IsWithinGrid2DBounds(inRange))
                    rangeList.Add(inRange);
            }

            return rangeList;
        }

        /// <summary>
        /// Get all the grid position within a square range
        /// </summary>
        /// <param name="center">The center position to calculate the range from</param>
        /// <param name="range">The length of the range (in grid units)</param>
        /// <param name="includeCenterPosition">Should include the center position in the return list</param>
        /// <returns>List containing all the positions within the square range</returns>
        public List<GridPosition2D> GetGridPositionsFromASquareRange(GridPosition2D center, int range, bool includeCenterPosition = false)
        {
            List<GridPosition2D> rangeList = new List<GridPosition2D>();

            foreach (GridPosition2D inRange in center.GetGridPositionsFromASquareRange(range, includeCenterPosition))
            {
                if (IsWithinGrid2DBounds(inRange))
                    rangeList.Add(inRange);
            }

            return rangeList;
        }

        /// <summary>
        /// Get all grid positions within a circular range
        /// </summary>
        /// <param name="center">The center position to calculate the range from</param>
        /// <param name="range">The length of the range (in grid units)</param>
        /// <param name="includeCenterPosition">Should include the center position in the return list</param>
        /// <returns>List containing all the positions within the circular range</returns>
        public List<GridPosition2D> GetGridPositionsFromACircularRange(GridPosition2D center, float range, bool includeCenterPosition = false)
        {
            List<GridPosition2D> rangeList = new List<GridPosition2D>();

            foreach (GridPosition2D inRange in center.GetGridPositionsFromACircularRange(range, includeCenterPosition))
            {
                if (IsWithinGrid2DBounds(inRange))
                    rangeList.Add(inRange);
            }

            return rangeList;
        }

        /// <summary>
        /// Save a grid as JSON string (T and its members must be a serializable type)
        /// </summary>
        /// <param name="grid">The grid to save</param>
        /// <returns>The grid in a string JSON format</returns>
        public static string Save<TResult>(Grid2D<TResult> grid)
        {
            SerializableGrid2D<TResult> gridData = new SerializableGrid2D<TResult>(grid);
            string json = JsonUtility.ToJson(gridData);
            return json;
        }

        /// <summary>
        /// Load a grid from a JSON string (T and its members must be a serializable type)
        /// </summary>
        /// <param name="jsonData">The JSON string containing the serialized grid</param>
        /// <returns>The loaded grid</returns>
        public static Grid2D<TResult> Load<TResult>(string jsonData)
        {
            SerializableGrid2D<TResult> gridData = JsonUtility.FromJson<SerializableGrid2D<TResult>>(jsonData);
            
            if (gridData == null || gridData.Data == null || gridData.Data.Length == 0)
            {
                throw new ArgumentException("The provided JSON data is not valid for deserializing a grid");
            }

            Grid2D<TResult> grid = new Grid2D<TResult>(gridData.Width, gridData.Height, gridData.CellSizeX, gridData.CellSizeZ, new Vector3(gridData.OriginX, gridData.OriginY, gridData.OriginZ));

            for (int x = 0; x < gridData.Width; x++)
            {
                for (int z = 0; z < gridData.Height; z++)
                {
                    int index = x * gridData.Height + z;
                    grid.SetGridObjectAtGridPosition2D(new GridPosition2D(x, z), gridData.Data[index], true);
                }
            }

            return grid;
        }
    }
}