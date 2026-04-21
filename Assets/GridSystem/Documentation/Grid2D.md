# Grid2D
## Table of contents
- [Documentation](#documentation)
  - [GridPosition2D](#gridPosition2DGridPosition2D)
    - [GridPosition2D()](#gridPosition2DGridPosition2D)
    - [GridPosition2D.DirectNeighbours](#gridPosition2DDirectNeighbours)
    - [GridPosition2D.Neighbours](#gridPosition2DNeighbours)
    - [GridPosition2D.ManhattanDistance()](#gridPosition2DManhattanDistance)
    - [GridPosition2D.ChebyshevDistance()](#gridPosition2DChebyshevDistance)
    - [GridPosition2D.GetGridPositionsFromADistanceRange()](#gridPosition2DGetGridPositionsFromADistanceRange)
    - [GridPosition2D.GetGridPositionsFromASquareRange()](#gridPosition2DGetGridPositionsFromASquareRange)
    - [GridPosition2D.GetGridPositionsFromACircularRange()](#gridPosition2DGetGridPositionsFromACircularRange)
  - [Grid2D](#grid2Dgrid2D)
    - [Grid2D()](#grid2Dgrid2D)
    - [Grid2D.Width](#grid2DWidth)
    - [Grid2D.Height](#grid2DHeight)
    - [Grid2D.Count](#grid2DCount)
    - [Grid2D.CellSizeX](#grid2DCellSizeX)
    - [Grid2D.CellSizeZ](#grid2DCellSizeZ)
    - [Grid2D.GridOriginPosition](#grid2DGridOriginPosition)
    - [Grid2D.IsSquareGrid](#grid2DIsSquareGrid)
    - [Grid2D.IsSquareGridCellSize](#grid2DIsSquareGridCellSize)
    - [Grid2D.OnGridPositionValueChanged](#grid2DOnGridPositionValueChanged)
    - [Grid2D.Indexers](#grid2DIndexers)
    - [Grid2D.GetEnumerator()](#grid2DGetEnumerator)
    - [Grid2D.GetGridObjectsWithPositions()](#grid2DGetGridObjectsWithPositions)
    - [Grid2D.GetRow()](#grid2DGetRow)
    - [Grid2D.GetCol()](#grid2DGetCol)
    - [Grid2D.ClearGrid()](#grid2DClearGrid)
    - [Grid2D.Fill()](#grid2DFill)
    - [Grid2D.Map()](#grid2DMap)
    - [Grid2D.Swap()](#grid2DSwap)
    - [Grid2D.GetGridObjectAtGridPosition2D()](#grid2DGetGridObjectAtGridPosition2D)
    - [Grid2D.TryGetGridObjectAtGridPosition2D()](#grid2DTryGetGridObjectAtGridPosition2D)
    - [Grid2D.GetGridObjectAtWorldPosition()](#grid2DGetGridObjectAtWorldPosition)
    - [Grid2D.TryGetGridObjectAtWorldPosition()](#grid2DTryGetGridObjectAtWorldPosition)
    - [Grid2D.GetRandomGridObject()](#grid2DGetRandomGridObject)
    - [Grid2D.GetSubGrid()](#grid2DGetSubGrid)
    - [Grid2D.GetRandomGridPosition()](#grid2DGetRandomGridPosition)
    - [Grid2D.GetWrappedGridPosition()](#grid2DGetWrappedGridPosition)
    - [Grid2D.SetGridObjectAtGridPosition2D()](#grid2DSetGridObjectAtGridPosition2D)
    - [Grid2D.SetGridObjectAtWorldPosition()](#grid2DSetGridObjectAtWorldPosition)
    - [Grid2D.GetWorldPositionFromGridPosition2D()](#grid2DGetWorldPositionFromGridPosition2D)
    - [Grid2D.GetWorldPositionFromCenterGridPosition2D()](#grid2DGetWorldPositionFromCenterGridPosition2D)
    - [Grid2D.TryGetWorldPositionFromGridPosition2D()](#grid2DTryGetWorldPositionFromGridPosition2D)
    - [Grid2D.TryGetWorldPositionFromCenterGridPosition2D()](#grid2DTryGetWorldPositionFromCenterGridPosition2D)
    - [Grid2D.GetGridPosition2DFromWorldPosition()](#grid2DGetGridPosition2DFromWorldPosition)
    - [Grid2D.TryGetGridPosition2DFromWorldPosition()](#grid2DTryGetGridPosition2DFromWorldPosition)
    - [Grid2D.Any()](#grid2DAny)
    - [Grid2D.All()](#grid2DAll)
    - [Grid2D.Where()](#grid2DWhere)
    - [Grid2D.IterateOverAllGridPositions()](#grid2DIterateOverAllGridPositions)
    - [Grid2D.IsWithinGrid2DBounds()](#grid2DIsWithinGrid2DBounds)
    - [Grid2D.IsPositionEmpty()](#grid2DIsPositionEmpty)
    - [Grid2D.GetAdjacentNeighbours()](#grid2DGetAdjacentNeighbours)
    - [Grid2D.GetGridPositionsFromADistanceRange()](#grid2DGetGridPositionsFromADistanceRange)
    - [Grid2D.GetGridPositionsFromASquareRange()](#grid2DGetGridPositionsFromASquareRange)
    - [Grid2D.GetGridPositionsFromACircularRange()](#grid2DGetGridPositionsFromACircularRange)
    - [Grid2D.Save()](#grid2DSave)
    - [Grid2D.Load()](#grid2DLoad)
    - [Grid2D.InstantiateGameObjectAtGridPosition()](#grid2DInstantiateGameObjectAtGridPosition)
    - [Grid2D.InstantiateGameObjectAtWorldPosition()](#grid2DInstantiateGameObjectAtWorldPosition)
    - [Grid2D.InstantiateGameObjectsAtEveryGridPosition()](#grid2DInstantiateGameObjectsAtEveryGridPosition)

## Documentation <a name="documentation"/>
### 1 GridPosition2D() <a name="gridPosition2DGridPosition2D"/>
Instantiate a new instance of the GridPosition2D struct
#### Declaration
```csharp
public GridPosition2D(int x, int z);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | x | The position x-coordinate |
| int | z | The position z-coordinate |


### GridPosition2D.DirectNeighbours <a name="gridPosition2DDirectNeighbours"/>
Get all the direct (sides) neighbours from this GridPosition2D
#### Declaration
```csharp
public List<GridPosition2D> DirectNeighbours;
```
#### Returns
| Type | Description |
| :--- | :--- |
| List<GridPosition2D> | The direct neighbours of this GridPosition2D |


### GridPosition2D.Neighbours <a name="gridPosition2DNeighbours"/>
Get all the neighbour positions (side and diagonals) from this GridPosition2D
#### Declaration
```csharp
public List<GridPosition2D> Neighbours;
```
#### Returns
| Type | Description |
| :--- | :--- |
| List<GridPosition2D> | The neighbours of this GridPosition2D |


### GridPosition2D.ManhattanDistanceFrom() <a name="gridPosition2DManhattanDistanceFrom"/>
### GridPosition2D.ManhattanDistance() <a name="gridPosition2DManhattanDistance"/>
Calculates the Manhattan distance between this and a different GridPosition2D
Calculates the Manhattan distance between two GridPosition2D
#### Declaration
```csharp
public int ManhattanDistanceFrom(GridPosition2D other);
public static int ManhattanDistance(GridPosition2D a, GridPosition2D b);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | other | The GridPosition2D to calculate the distance from |
| GridPosition2D | a | The first GridPosition2D |
| GridPosition2D | b | The second GridPosition2D |
#### Returns
| Type | Description |
| :--- | :--- |
| int | The distance between the two positions |


### GridPosition2D.ChebyshevDistanceFrom() <a name="gridPosition2DChebyshevDistanceFrom"/>
### GridPosition2D.ChebyshevDistance() <a name="gridPosition2DChebyshevDistanceFrom"/>
Calculates the Chebyshev distance between this and a different GridPosition2D
Calculates the Chebyshev distance between two GridPosition2D
#### Declaration
```csharp
public int ChebyshevDistanceFrom(GridPosition2D other);
public static int ChebyshevDistance(GridPosition2D a, GridPosition2D b);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | other | The GridPosition2D to calculate the distance from |
| GridPosition2D | a | The first GridPosition2D |
| GridPosition2D | b | The second GridPosition2D |
#### Returns
| Type | Description |
| :--- | :--- |
| int | The distance between the two positions |


### GridPosition2D.GetGridPositionsFromADistanceRange() <a name="gridPosition2DGetGridPositionsFromADistanceRange"/>
Get all the grid positions within a range
#### Declaration
```csharp
public HashSet<GridPosition2D> GetGridPositionsFromADistanceRange(int range, bool includeSelf = true);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | range | The length of the range (in grid units) |
| bool | includeSelf | Whether to include the current position in the returned set |
#### Returns
| Type | Description |
| :--- | :--- |
| HashSet<GridPosition2D> | Set containing all the positions within the range |


### GridPosition2D.GetGridPositionsFromASquareRange() <a name="gridPosition2DGetGridPositionsFromASquareRange"/>
Get all the grid positions within a square range
#### Declaration
```csharp
public HashSet<GridPosition2D> GetGridPositionsFromASquareRange(int range, bool includeSelf = true);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | range | The length of the range (in grid units) |
| bool | includeSelf | Whether to include the current position in the returned set |
#### Returns
| Type | Description |
| :--- | :--- |
| HashSet<GridPosition2D> | Set containing all the positions within the square range |


### GridPosition2D.GetGridPositionsFromACircularRange() <a name="gridPosition2DGetGridPositionsFromACircularRange"/>
Get all the grid positions within a circular range
#### Declaration
```csharp
public HashSet<GridPosition2D> GetGridPositionsFromACircularRange(float range, bool includeSelf = true);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | range | The length of the range (in grid units) |
| bool | includeSelf | Whether to include the current position in the returned set |
#### Returns
| Type | Description |
| :--- | :--- |
| HashSet<GridPosition2D> | Set containing all the positions within the circular range |


### 2 Grid2D() <a name="grid2Dgrid2D"/>
Instantiate a new instance of the Grid2D class
#### Declaration
```csharp
public Grid2D<T>(int width, int height, float cellSizeX, float cellSizeZ, Vector3 gridOriginPosition, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null);
public Grid2D<T>(int width, int height, float cellSizeX, float cellSizeZ, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null);
public Grid2D<T>(int width, int height, float cellSize, Vector3 gridOriginPosition, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null);
public Grid2D<T>(int width, int height, float cellSize, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| T | ----- | The type of object that this grid will hold |
| int | width | The width of the grid |
| int | height | The height of the grid |
| float | cellSizeX | The width of the grid's cell |
| float | cellSizeZ | The height of the grid's cell |
| float | cellSize | The size of each cell in the grid |
| Vector3 | gridOriginPosition | The grid origin position |
| Func<Grid2D<T>, GridPosition2D, T> | gridObjectInitializer | The initialize function for each grid element (where Grid2D<T> references this grid object and GridPosition2D references the position in the grid for the object) |


### Grid2D.Width <a name="grid2DWidth"/>
Get the width of the grid
#### Declaration
```csharp
public int Width;
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | The width of the grid |


### Grid2D.Height <a name="grid2DHeight"/>
Get the height of the grid
#### Declaration
```csharp
public int Height;
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | The height of the grid |


### Grid2D.Count <a name="grid2DCount"/>
Get the total number of cells in the grid
#### Declaration
```csharp
public int Count;
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | The total number of cells in the grid |


### Grid2D.CellSizeX <a name="grid2DCellSizeX"/>
Get the width of the grid's cell
#### Declaration
```csharp
public float CellSizeX;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The cell's width of the grid |


### Grid2D.CellSizeZ <a name="grid2DCellSizeZ"/>
Get the height of the grid's cell
#### Declaration
```csharp
public float CellSizeZ;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The cell's height of the grid |


### Grid2D.GridOriginPosition <a name="grid2DGridOriginPosition"/>
Get the origin position of the grid
#### Declaration
```csharp
public Vector3 GridOriginPosition;
```
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | The grid origin position |


### Grid2D.IsSquareGrid <a name="grid2DIsSquareGrid"/>
Check if is a square grid (width == height)
#### Declaration
```csharp
public bool IsSquareGrid;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | The grid number of rows is the same as the number of columns |


### Grid2D.IsSquareGridCellSize <a name="grid2DIsSquareGridCellSize"/>
Check if the grid has square cells (cell's width == cell's height)
#### Declaration
```csharp
public bool IsSquareGridCellSize;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | The grid's cells are square (the cells width is the same as the height) |


### Grid2D.OnGridPositionValueChanged <a name="grid2DOnGridPositionValueChanged"/>
Event to be raised when the value of a cell changes
#### Declaration
```csharp
public event Action<GridPosition2D, T> OnGridPositionValueChanged;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| GridPosition2D | The grid position where the value has changed |
| T | The new value assigned to the position |


### Grid2D.Indexers <a name="grid2DIndexers"/>
Get the object at a specific grid position
#### Declaration
```csharp
public T [int x, int z];
public T [GridPosition2D gridPosition2D];
public T [Vector3 worldPosition];
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | x | The x-coordinate of the grid to get an object from |
| int | z | The z-coordinate of the grid to get an object from |
| GridPosition2D | gridPosition2D | The grid postion to get an object from |
| Vector3 | worldPosition | The world position to be converted to a grid position |
#### Returns
| Type | Description |
| :--- | :--- |
| T | The object at the specified grid position |


### Grid2D.GetEnumerator() <a name="grid2DGetEnumerator"/>
Returns the elements of the grid
#### Declaration
```csharp
public IEnumerator<T> GetEnumerator();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerator<T> | The elements of the grid |


### Grid2D.GetGridObjectsWithPositions() <a name="grid2DGetGridObjectsWithPositions"/>
Returns the elements of the grid with their respective positions
#### Declaration
```csharp
public IEnumerable<(GridPosition2D Position, T Value)> GetGridObjectsWithPositions();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<GridPosition2D, T> | The elements of the grid and the respective position |


### Grid2D.GetRow() <a name="grid2DGetRow"/>
Returns the elements of a specific row
#### Declaration
```csharp
public IEnumerable<T> GetRow(int rowIndex);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | rowIndex | The row to get the elements from |
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<T> | The elements of the specified row |


### Grid2D.GetCol() <a name="grid2DGetCol"/>
Returns the elements of a specific column
#### Declaration
```csharp
public IEnumerable<T> GetCol(int colIndex);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | colIndex | The column to get the elements from |
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<T> | The elements of the specified column |


### Grid2D.ClearGrid() <a name="grid2DClearGrid"/>
Clear the grid and reset all the positions to their default values
#### Declaration
```csharp
public void ClearGrid();
```


### Grid2D.Fill() <a name="grid2DFill"/>
Fill all the positions in the grid with a specific value
#### Declaration
```csharp
public void Fill(T value);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| T | value | The value to apply to every position |


### Grid2D.Map() <a name="grid2DMap"/>
Map the grid to a new grid with the same dimensions but with different type of elements based on a mapping function
#### Declaration
```csharp
public Grid2D<TResult> Map<TResult>(Func<T, TResult> mapper);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Func<T, TResult> | mapper | The mapping function |
#### Returns
| Type | Description |
| :--- | :--- |
| Grid2D<TResult> | A new grid with the mapped values |


### Grid2D.Swap() <a name="grid2DSwap"/>
Swap the values of two positions in the grid
#### Declaration
```csharp
public void Swap(GridPosition2D a, GridPosition2D b);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | a | The first position |
| GridPosition2D | b | The second position |


### Grid2D.GetGridObjectAtGridPosition2D() <a name="grid2DGetGridObjectAtGridPosition2D"/>
Get an element from the grid based on a grid position
#### Declaration
```csharp
public T GetGridObjectAtGridPosition2D(GridPosition2D gridPosition2D);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | gridPosition2D | The position to get the element from |
#### Returns
| Type | Description |
| :--- | :--- |
| T | The element at the specified grid position |


### Grid2D.TryGetGridObjectAtGridPosition2D() <a name="grid2DTryGetGridObjectAtGridPosition2D"/>
Attempts to retrieve the object located at the specified 2D grid position
#### Declaration
```csharp
public bool TryGetGridObjectAtGridPosition2D(GridPosition2D gridPosition2D, out T value);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | gridPosition2D | The position to get the element from |
| T | value | When this method returns, contains the object at the specified grid position if found, otherwise the default value for the type |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if an object exists at the specified grid position, false otherwise |


### Grid2D.GetGridObjectAtWorldPosition() <a name="grid2DGetGridObjectAtWorldPosition"/>
Get an element from the grid based on a world position
#### Declaration
```csharp
public T GetGridObjectAtWorldPosition(Vector3 worldPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | worldPosition | The world position to get the element from |
#### Returns
| Type | Description |
| :--- | :--- |
| T | The element at the specified world position |


### Grid2D.TryGetGridObjectAtWorldPosition() <a name="grid2DTryGetGridObjectAtWorldPosition"/>
Attempts to retrieve the object located at the specified world position
#### Declaration
```csharp
public bool TryGetGridObjectAtWorldPosition(Vector3 worldPosition, out T value);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | worldPosition | The world position to get the element from |
| T | value | When this method returns, contains the object at the specified grid position if found, otherwise the default value for the type |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if an object exists at the specified grid position, false otherwise |


### Grid2D.GetRandomGridObject() <a name="grid2DGetRandomGridObject"/>
Get an random object from the grid
#### Declaration
```csharp
public T GetRandomGridObject();
```
#### Returns
| Type | Description |
| :--- | :--- |
| T | A random object from the grid |


### Grid2D.GetSubGrid() <a name="grid2DGetSubGrid"/>
Get a sub-grid from the original grid (inclusive interval)
#### Declaration
```csharp
public Grid2D<T> GetSubGrid(int startX, int endX, int startZ, int endZ, Vector3 newGridOriginPosition);
public Grid2D<T> GetSubGrid(GridPosition2D start, GridPosition2D end, Vector3 newGridOriginPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | startX | The start X-value of the subgrid |
| int | endX | The end X-value of the subgrid |
| int | startZ | The start Z-value of the subgrid |
| int | endZ | The end Z-value of the subgrid |
| GridPosition2D | start | The start grid position of the subgrid |
| GridPosition2D | end | The end grid position of the subgrid |
| Vector3 | newGridPosition | The original position for the subgrid |
#### Returns
| Type | Description |
| :--- | :--- |
| Grid2D<T> | A subgrid containing the elements of the original grid |


### Grid2D.GetRandomGridPosition() <a name="grid2DGetRandomGridPosition"/>
Gets a random position from the grid
#### Declaration
```csharp
public GridPosition2D GetRandomGridPosition();
```
#### Returns
| Type | Description |
| :--- | :--- |
| GridPosition2D | A random position within the grid |


### Grid2D.GetWrappedGridPosition() <a name="grid2DGetWrappedGridPosition"/>
Gets the wrapped position of the grid
#### Declaration
```csharp
public GridPosition2D GetWrappedGridPosition(int x, int z);
public GridPosition2D GetWrappedGridPosition(GridPosition2D gridPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | x | The x-coordinate of the position |
| int | z | The z-coordinate of the position |
| GridPosition2D | gridPosition | The The grid position coordinate |
#### Returns
| Type | Description |
| :--- | :--- |
| GridPosition2D | The wrapped position |


### Grid2D.SetGridObjectAtGridPosition2D() <a name="grid2DSetGridObjectAtGridPosition2D"/>
Set a grid object in a determined grid position
#### Declaration
```csharp
public bool SetGridObjectAtGridPosition2D(GridPosition2D gridPosition2D, T newObject, bool replaceIfExistAnObjectAlready = true);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | gridPosition2D | The grid position of the object |
| T | newObject | The new object to set in the position |
| bool | replaceIfExistAnObjectAlready | Replace even if the position already has been assigned |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | The new object was set successfully or not |


### Grid2D.SetGridObjectAtWorldPosition() <a name="grid2DSetGridObjectAtWorldPosition"/>
Set an object in the grid based on its world position
#### Declaration
```csharp
public bool SetGridObjectAtWorldPosition(Vector3 worldPosition, T newObject, bool replaceIfExistAnObjectAlready = true);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | worldPosition | The world position of the object |
| T | newObject | The new object to set in the position |
| bool | replaceIfExistAnObjectAlready | Replace even if the position already has been assigned |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | The new object was set successfully or not |


### Grid2D.GetWorldPositionFromGridPosition2D() <a name="grid2DGetWorldPositionFromGridPosition2D"/>
Converts a gridPosition to a world position
#### Declaration
```csharp
public Vector3 GetWorldPositionFromGridPosition2D(GridPosition2D gridPosition2D);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | gridPosition2D | The grid position to convert |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | The position in world coordinates |


### Grid2D.GetWorldPositionFromCenterGridPosition2D() <a name="grid2DGetWorldPositionFromCenterGridPosition2D"/>
Converts the center of a gridPosition to a world position
#### Declaration
```csharp
public Vector3 GetWorldPositionFromCenterGridPosition2D(GridPosition2D gridPosition2D);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | gridPosition2D | The grid position to convert |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | The position in world coordinates at the center of the gridPosition |


### Grid2D.TryGetWorldPositionFromGridPosition2D() <a name="grid2DTryGetWorldPositionFromGridPosition2D"/>
Try to convert a gridPosition into a world position
#### Declaration
```csharp
public bool TryGetWorldPositionFromGridPosition2D(GridPosition2D gridPosition2D, out Vector3 worldPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | gridPosition2D | The grid position to convert |
| Vector3 | worldPosition | The position in world coordinates |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | If it is able to convert the grid position to a world one |


### Grid2D.TryGetWorldPositionFromCenterGridPosition2D() <a name="grid2DTryGetWorldPositionFromCenterGridPosition2D"/>
Try to convert the center of a gridPosition into a world position
#### Declaration
```csharp
public bool TryGetWorldPositionFromCenterGridPosition2D(GridPosition2D gridPosition2D, out Vector3 worldPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | gridPosition2D | The grid position to convert |
| Vector3 | worldPosition | The position in world coordinates at the center of the grid position |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | If it is able to convert the grid position to a world one |


### Grid2D.GetGridPosition2DFromWorldPosition() <a name="grid2DGetGridPosition2DFromWorldPosition"/>
Converts a world position to a grid position
#### Declaration
```csharp
public GridPosition2D GetGridPosition2DFromWorldPosition(Vector3 worldPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | worldPosition | The world position to convert from |
#### Returns
| Type | Description |
| :--- | :--- |
| GridPosition2D | The grid position related to the world one |


### Grid2D.TryGetGridPosition2DFromWorldPosition() <a name="grid2DTryGetGridPosition2DFromWorldPosition"/>
Try to convert a world position into a grid position
#### Declaration
```csharp
public bool TryGetGridPosition2DFromWorldPosition(Vector3 worldPosition, out GridPosition2D gridPosition2D);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | worldPosition | The world position to convert from |
| GridPosition2D | gridPosition2D | The result in grid coordinates |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | If the world position is able to be converted into a grid position |


### Grid2D.Any() <a name="grid2DAny"/>
Check if any of the grid positions satisfies a condition
#### Declaration
```csharp
public bool Any(Func<T, bool> predicate);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Func<T, bool> | predicate | The condition to check on each position |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if any position satisfies the condition, false otherwise |


### Grid2D.All() <a name="grid2DAll"/>
Check if all grid positions satisfies a condition
#### Declaration
```csharp
public bool All(Func<T, bool> predicate);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Func<T, bool> | predicate | The condition to check on each position |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if all positions satisfies the condition, false otherwise |


### Grid2D.Where() <a name="grid2DWhere"/>
Gets all the grid positions that satisfies a condition
#### Declaration
```csharp
public List<GridPosition2D> GetGridPositionsInACertainState(Func<T, bool> predicate);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Func<T, bool> | predicate | The condition to check on each position (params T: value at the position) |
#### Returns
| Type | Description |
| :--- | :--- |
| List<GridPosition2D> | A list containing all the positions that satisfies the condition |


### Grid2D.IterateOverAllGridPositions() <a name="grid2DIterateOverAllGridPositions"/>
Execute an action for every position in the grid
#### Declaration
```csharp
public void IterateOverAllGridPositions(Action<GridPosition2D, T> action);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Action<GridPosition2D, T> | action | Action to apply on every grid position (params GridPosition2D: grid position, T: value at the position) |


### Grid2D.IsWithinGrid2DBounds() <a name="grid2DIsWithinGrid2DBounds"/>
Check if a gridPosition/coordinate/worldPosition is within the grid bounds
#### Declaration
```csharp
public bool IsWithinGrid2DBounds(GridPosition2D gridPosition2D);
public bool IsWithinGrid2DBounds(int x, int z);
public bool IsWithinGrid2DBounds(Vector3 worldPosition);
public bool IsWithinGrid2DBounds(IEnumerable<GridPosition2D> gridPositions2D);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | gridPosition2D | The grid position to check |
| int | x | The x-coordinate to check |
| int | z | The z-coordinate to check |
| Vector3 | worldPosition | The world position to check |
| IEnumerable<GridPosition2D> | gridPositions2D | Collection containing all the positions to check |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | If the position(s) are within the grid bounds |


### Grid2D.IsPositionEmpty() <a name="grid2DIsPositionEmpty"/>
Check if a grid position is empty (or default value in case of a non-nullable type)
#### Declaration
```csharp
public bool IsPositionEmpty(GridPosition2D gridPosition2D);
public bool IsPositionEmpty(int x, int z);
public bool IsPositionEmpty(Vector3 worldPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | gridPosition2D | The grid position to check |
| int | x | The x-coordinate to check |
| int | z | The z-coordinate to check |
| Vector3 | worldPosition | The world position to check |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | If the position is empty or not |


### Grid2D.GetAdjacentNeighbours() <a name="grid2DGetAdjacentNeighbours"/>
Get all the adjacent neighbours of a specific position
#### Declaration
```csharp
public List<GridPosition2D> GetAdjacentNeighbours(GridPosition2D center, bool includeCenterPosition = false, bool includeDiagonalNeighbours = false);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | center | The center position to get the neighbours from |
| bool | includeCenterPosition | Should include the center position in the return list |
| bool | includeDiagonalNeighbours | Should include diagonal neighbours in the return list |
#### Returns
| Type | Description |
| :--- | :--- |
| List<GridPosition2D> | List containing all the neighbour positions of a specific grid position |


### Grid2D.GetGridPositionsFromADistanceRange() <a name="grid2DGetGridPositionsFromADistanceRange"/>
Get all the grid positions within a range
#### Declaration
```csharp
public List<GridPosition2D> GetGridPositionsFromADistanceRange(GridPosition2D center, int range, bool includeCenterPosition = false);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | center | The center position to calculate the range from |
| int | range | The length of the range (in grid units) |
| bool | includeCenterPosition | Should include the center position in the return list |
#### Returns
| Type | Description |
| :--- | :--- |
| List<GridPosition2D> | List containing all the positions within the range |


### Grid2D.GetGridPositionsFromASquareRange() <a name="grid2DGetGridPositionsFromASquareRange"/>
Get all the grid position within a square range
#### Declaration
```csharp
public List<GridPosition2D> GetGridPositionsFromASquareRange(GridPosition2D center, int range, bool includeCenterPosition = false);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | center | The center position to calculate the range from |
| int | range | The length of the range (in grid units) |
| bool | includeCenterPosition | Should include the center position in the return list |
#### Returns
| Type | Description |
| :--- | :--- |
| List<GridPosition2D> | List containing all the positions within the square range |


### Grid2D.GetGridPositionsFromACircularRange() <a name="grid2DGetGridPositionsFromACircularRange"/>
Get all grid positions within a circular range
#### Declaration
```csharp
public List<GridPosition2D> GetGridPositionsFromACircularRange(GridPosition2D center, float range, bool includeCenterPosition = false);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | center | The center position to calculate the range from |
| float | range | The length of the range (in grid units) |
| bool | includeCenterPosition | Should include the center position in the return list |
#### Returns
| Type | Description |
| :--- | :--- |
| List<GridPosition2D> | List containing all the positions within the circular range |


### Grid2D.Save() <a name="grid2DSave"/>
Save a grid as JSON string (T and its members must be a serializable type)
#### Declaration
```csharp
public static string Save<T>(Grid2D<T> grid);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Grid2D<T> | grid | The grid to save |
#### Returns
| Type | Description |
| :--- | :--- |
| string | The grid in a JSON format |


### Grid2D.Load() <a name="grid2DLoad"/>
Load a grid from a JSON string (T and its members must be a serializable type)
#### Declaration
```csharp
public static Grid2D<T> Load<T>(string jsonData);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | jsonData | The JSON string containing the serialized grid |
#### Returns
| Type | Description |
| :--- | :--- |
| Grid2D<T> | The loaded grid |


### Grid2D.InstantiateGameObjectAtGridPosition() <a name="grid2DInstantiateGameObjectAtGridPosition"/>
Instantiate a game object in a certain grid position
#### Declaration
```csharp
public GameObject InstantiateGameObjectAtGridPosition(GridPosition2D gridPosition2D, GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onGameObjectSpawned = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | gridPosition2D | The grid position to instantiate the object on (will be instantiatd at its center) |
| GameObject | gameObjectPrefab | The object to instantiate |
| Transform | objectParent | The parent transform for the instantiated object |
| Action<GameObject> | onGameObjectSpawned | Action to execute when the object is instantiated (params GameObject: the instantiated game object) |
#### Returns
| Type | Description |
| :--- | :--- |
| GameObject | The instantiated game object |


### Grid2D.InstantiateGameObjectAtWorldPosition() <a name="grid2DInstantiateGameObjectAtWorldPosition"/>
Instantiate a game object in the grid based on a world position
#### Declaration
```csharp
public GameObject InstantiateGameObjectAtWorldPosition(Vector3 worldPosition, GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onGameObjectSpawned = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | worldPosition | The world position to instantiate the object on |
| GameObject | gameObjectPrefab | The object to instantiate |
| Transform | objectParent | The parent transform for the instantiated object |
| Action<GameObject> | onGameObjectSpawned | Action to execute when the object is instantiated (params GameObject: the instantiated game object) |
#### Returns
| Type | Description |
| :--- | :--- |
| GameObject | The instantiated game object |


### Grid2D.InstantiateGameObjectsAtEveryGridPosition() <a name="grid2DInstantiateGameObjectsAtEveryGridPosition"/>
Instantiate a game object on every grid position
#### Declaration
```csharp
public List<GameObject> InstantiateGameObjectsAtEveryGridPosition(GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onEachGameObjectSpawned = null, Action<List<GameObject>> onAllGameObjectSpawned = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GameObject | gameObjectPrefab | The object to instantiate |
| Transform | objectParent | The parent transform for all the instantiated object |
| Action<GameObject> | onEachGameObjectSpawned | Action to execute when the object is instantiated (params GameObject: the instantiated game object) |
| Action<List<GameObject>> | onAllGameObjectSpawned | Action to execute when all objects are instantiated (params List<GameObject>: all the instantiated game objects) |
#### Returns
| Type | Description |
| :--- | :--- |
| List<GameObject> | All the instantiated game objects |