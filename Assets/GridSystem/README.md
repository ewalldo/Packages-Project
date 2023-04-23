# Grid System
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Instantiate a grid](#instantiateAGrid)
  - [Accessing grid elements](#accessingGridElements)
  - [Relationship between grid coordinates and world coordinates](#relationshipBetweenGridCoordinatesAndWorldCoordinates)
  - [Grid methods](#gridMethods)
- [Documentation](#documentation)
  - [Grid2D()](#grid2Dgrid2D)
  - [Grid2D.GetWidth](#grid2DGetWidth)
  - [Grid2D.GetHeight](#grid2DGetHeight)
  - [Grid2D.GetCellSizeX](#grid2DGetCellSizeX)
  - [Grid2D.GetCellSizeZ](#grid2DGetCellSizeZ)
  - [Grid2D.GetGridOriginPosition](#grid2DGetGridOriginPosition)
  - [Grid2D.IsSquareGrid](#grid2DIsSquareGrid)
  - [Grid2D.IsSquareGridCellSize](#grid2DIsSquareGridCellSize)
  - [Grid2D.OnGridPositionValueChanged](#grid2DOnGridPositionValueChanged)
  - [Grid2D.Indexers](#grid2DIndexers)
  - [Grid2D.GetGridObjects](#grid2DGetGridObjects)
  - [Grid2D.GetRow()](#grid2DGetRow)
  - [Grid2D.GetCol()](#grid2DGetCol)
  - [Grid2D.ClearGrid()](#grid2DClearGrid)
  - [Grid2D.Fill()](#grid2DFill)
  - [Grid2D.GetGridObjectAtGridPosition2D()](#grid2DGetGridObjectAtGridPosition2D)
  - [Grid2D.GetGridObjectAtWorldPosition()](#grid2DGetGridObjectAtWorldPosition)
  - [Grid2D.GetRandomGridObject()](#grid2DGetRandomGridObject)
  - [Grid2D.GetSubGrid()](#grid2DGetSubGrid)
  - [Grid2D.GetRandomGridPosition()](#grid2DGetRandomGridPosition)
  - [Grid2D.SetGridObjectAtGridPosition2D()](#grid2DSetGridObjectAtGridPosition2D)
  - [Grid2D.SetGridObjectAtWorldPosition()](#grid2DSetGridObjectAtWorldPosition)
  - [Grid2D.GetWorldPositionFromGridPosition2D()](#grid2DGetWorldPositionFromGridPosition2D)
  - [Grid2D.GetWorldPositionFromCenterGridPosition2D()](#grid2DGetWorldPositionFromCenterGridPosition2D)
  - [Grid2D.TryGetWorldPositionFromGridPosition2D()](#grid2DTryGetWorldPositionFromGridPosition2D)
  - [Grid2D.TryGetWorldPositionFromCenterGridPosition2D()](#grid2DTryGetWorldPositionFromCenterGridPosition2D)
  - [Grid2D.GetGridPosition2DFromWorldPosition()](#grid2DGetGridPosition2DFromWorldPosition)
  - [Grid2D.TryGetGridPosition2DFromWorldPosition()](#grid2DTryGetGridPosition2DFromWorldPosition)
  - [Grid2D.GetGridPositionsInACertainState()](#grid2DGetGridPositionsInACertainState)
  - [Grid2D.IterateOverAllGridPositions()](#grid2DIterateOverAllGridPositions)
  - [Grid2D.IsWithinGrid2DBounds()](#grid2DIsWithinGrid2DBounds)
  - [Grid2D.IsPositionEmpty()](#grid2DIsPositionEmpty)
  - [Grid2D.GetAdjacentNeighbours()](#grid2DGetAdjacentNeighbours)
  - [Grid2D.GetGridPositionsFromADistanceRange()](#grid2DGetGridPositionsFromADistanceRange)
  - [Grid2D.GetGridPositionsFromASquareRange()](#grid2DGetGridPositionsFromASquareRange)
  - [Grid2D.InstantiateGameObjectAtGridPosition()](#grid2DInstantiateGameObjectAtGridPosition)
  - [Grid2D.InstantiateGameObjectAtWorldPosition()](#grid2DInstantiateGameObjectAtWorldPosition)
  - [Grid2D.InstantiateGameObjectsAtEveryGridPosition()](#grid2DInstantiateGameObjectsAtEveryGridPosition)
  - [Grid2D.Save()](#grid2DSave)
  - [Grid2D.Load()](#grid2DLoad)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The Grid System Package is a Unity package that provides a simple and efficient way to create and manipulate grids in Unity. Grids are commonly used in games and simulations to represent environments, game boards, maps, and other structured data. The Grid System Package uses generics, allowing you to create a grid that can contain any type of object, whether it is a game object, a scriptable object, a primitive type, or a custom class.  
The Grid System Package provides several different types of indexers that can be used to access the grid data in various ways. These include standard row and column indexers, as well as indexers that accept a GridPosition or Vector3. This makes it easy to manipulate the grid data and perform common operations, such as adding or removing objects, checking if a cell is empty, or iterating over the cells of the grid.  
In addition to the indexers, the Grid System Package provides several methods that can be used to manipulate and get information from the grid. These include methods to get all the positions that fulfil a certain condition, that apply an operation on each each cell, that get all the positions within a range, and more. These methods make it easy to work with the grid data in a consistent and efficient manner.  
Overall, the Grid System Package is a powerful and flexible tool that can be used in a wide variety of Unity projects, from simple games to complex simulations. Whether you need to represent a game board, a map, or some other structured data, the Grid System Package makes it easy to create and manipulate grids with ease.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.  

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Use of generics allowing the instantiation of any type of grid.
- Easy-to-use methods that simplifies working with grid data in Unity projects.
- Different types of indexer makes it easier to access position in the grid.
- Many types of methods to manipulate or get information from the grid.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Instantiate a grid <a name="instantiateAGrid"/>
An instance of a grid class can be instantiated by calling one of its constructors and passing the required grid information as parameters (the dimensions of the grid, the dimensions of the grid's cells and the grid origin point) and the type of objects that the grid will hold. The constructor also accepts an optional Func parameter that can be used to initialize the object on each cell instead of using their default values. You can find below an example on how to instantiate the grid class.  
```csharp
// Example of how to instantiate a grid of Terrain (let's assume that Terrain is a class that holds information about the height of the game's terrain)
// Here we are instantiating a 10x10 grid where each cell has a size of 2. The grid origin is located at the (0, 0, 0) position and each terrain object is initialized using an anonymous function.
Grid2D<Terrain> terrainGrid = new Grid2D<Terrain>(10, 10, 2, Vector3.Zero, (Grid2D<Terrain> g, GridPosition2D gp) => new Terrain(g, gp, terrainHeight=Random.Next(10)));

// Grid2D constructors
public Grid2D<T>(int width, int height, float cellSizeX, float cellSizeZ, Vector3 gridOriginPosition, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null);
public Grid2D<T>(int width, int height, float cellSizeX, float cellSizeZ, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null);
public Grid2D<T>(int width, int height, float cellSize, Vector3 gridOriginPosition, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null);
public Grid2D<T>(int width, int height, float cellSize, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null);
```

### 4.2 Accessing grid elements <a name="accessingGridElements"/>
Grid elements can be accessed in different ways. You can get elements from the grid by its GridPosition2D (ex 1), coordinates (ex 2), world position (ex 3) or by one of the Get methods (ex 4). Same apply to setting the elements. All those functions check if the position you're trying to access is valid, which is useful to find bugs within the code.  
```csharp
// ex 1
GridPosition2D gridPosition = new GridPosition2D(x, y);
var cellValue = grid2D[gridPosition];
grid2D[gridPosition] = cellValue;

// ex 2
var cellValue = grid2D[x, y];
grid2D[x, y] = cellValue;

// ex 3
Vector3 pos = new Vector3(0, 0, 0);
var cellValue = grid2D[pos];
grid2D[pos] = cellValue;

// ex 4
var cellValue = grid2D.GetGridObjectAtGridPosition2D(gridPosition);
var cellValue = grid2D.GetGridObjectAtWorldPosition(pos);
grid2D.SetGridObjectAtGridPosition2D(gridPosition, cellValue);
grid2D.SetGridObjectAtWorldPosition(pos, cellValue);
```

### 4.3 Relationship between grid coordinates and world coordinates <a name="relationshipBetweenGridCoordinatesAndWorldCoordinates"/>
Grid's cell origin points are at the bottom left part of the cell, so methods like GetWorldPositionFromGridPosition2D() and TryGetWorldPositionFromGridPosition2D() will return the world position located the bottom left of the cell. If you want the center position of the cell, use the GetWorldPositionFromCenterGridPosition2D() and TryGetWorldPositionFromCenterGridPosition2D() instead. When getting grid coordinates from world position, the origin of the cell doesn't matter at all.  
```csharp
// We instantiate a 10x10 grid where each cell has a size of 2
// Cell(0, 0) bottom left coordinate will be at Vector3(0, 0, 0) and top right at (2, 0, 2)-exclusive interval
// Cell(1, 0) bottom left coordinate will be at Vector3(2, 0, 0) and top right at (4, 0, 2)-exclusive interval
// Cell(0, 1) bottom left coordinate will be at Vector3(0, 0, 2) and top right at (2, 0, 4)-exclusive interval
// ...
Grid2D<Foo> grid = new Grid2D<Foo>(10, 10, 2, Vector3.Zero);

// Get the world position of the grid position (0, 0) will result in Vector3(0, 0, 0)
GetWorldPositionFromGridPosition2D(new GridPosition2D(0, 0));
// Get the world position at the center of the grid position (0, 0) will result in Vector3(1, 0, 1)
GetWorldPositionFromCenterGridPosition2D(new GridPosition2D(0, 0));
// Get the world position of the grid position (1, 0) will result in Vector3(2, 0, 0)
GetWorldPositionFromGridPosition2D(new GridPosition2D(1, 0));
// Get the world position at the center of the grid position (1, 0) will result in Vector3(3, 0, 1)
GetWorldPositionFromCenterGridPosition2D(new GridPosition2D(1, 0));

// Get the grid position from the world position (0, 0, 0) will result at the coordinate (0, 0)
GetGridPosition2DFromWorldPosition(new Vector3(0, 0, 0));
// Get the grid position from the world position (1, 0, 1) will result at the coordinate (0, 0)
GetGridPosition2DFromWorldPosition(new Vector3(1, 0, 1));
// Get the grid position from the world position (2, 0, 2) will result at the coordinate (1, 1)
GetGridPosition2DFromWorldPosition(new Vector3(2, 0, 2));
// Get the grid position from the world position (0.75, 0, 1.5) will result at the coordinate (0, 0)
GetGridPosition2DFromWorldPosition(new Vector3(0.75, 0, 1.5));
```

### 4.4 Grid methods <a name="gridMethods"/>
Grid class contain many methods to manipulate and/or get information from the grid. For example, get all the positions that fulfil a certain condition (GetGridPositionsInACertainState()), to apply an operation on each each cell (IterateOverAllGridPositions()), get all the positions within a range (GetGridPositionsFromADistanceRange()) and many others. For more details check out the documentation below. 

## 5 - Documentation <a name="documentation"/>
### 5.1 Grid2D() <a name="grid2Dgrid2D"/>
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


### 5.2 Grid2D.GetWidth <a name="grid2DGetWidth"/>
Get the width of the grid
#### Declaration
```csharp
public int GetWidth;
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | The width of the grid |


### 5.3 Grid2D.GetHeight <a name="grid2DGetHeight"/>
Get the height of the grid
#### Declaration
```csharp
public int GetHeight;
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | The height of the grid |


### 5.4 Grid2D.GetCellSizeX <a name="grid2DGetCellSizeX"/>
Get the width of the grid's cell
#### Declaration
```csharp
public float GetCellSizeX;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The cell's width of the grid |


### 5.5 Grid2D.GetCellSizeZ <a name="grid2DGetCellSizeZ"/>
Get the height of the grid's cell
#### Declaration
```csharp
public float GetCellSizeZ;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The cell's height of the grid |


### 5.6 Grid2D.GetGridOriginPosition <a name="grid2DGetGridOriginPosition"/>
Get the origin position of the grid
#### Declaration
```csharp
public Vector3 GetGridOriginPosition;
```
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | The grid origin position |


### 5.7 Grid2D.IsSquareGrid <a name="grid2DIsSquareGrid"/>
Check if is a square grid (width == height)
#### Declaration
```csharp
public bool IsSquareGrid;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | The grid number of rows is the same as the number of columns |


### 5.8 Grid2D.IsSquareGridCellSize <a name="grid2DIsSquareGridCellSize"/>
Check if the grid has square cells (cell's width == cell's height)
#### Declaration
```csharp
public bool IsSquareGridCellSize;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | The grid's cells are square (the cells width is the same as the height) |


### 5.9 Grid2D.OnGridPositionValueChanged <a name="grid2DOnGridPositionValueChanged"/>
Event to be raised when the value of a cell changes
#### Declaration
```csharp
public Action<GridPosition2D, T> OnGridPositionValueChanged;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| GridPosition2D | The grid position where the value has changed |
| T | The new value assigned to the position |


### 5.10 Grid2D.Indexers <a name="grid2DIndexers"/>
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


### 5.11 Grid2D.GetGridObjects <a name="grid2DGetGridObjects"/>
Returns the elements of the grid
#### Declaration
```csharp
public IEnumerable<T> GetGridObjects();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<T> | The elements of the grid |


### 5.12 Grid2D.GetRow() <a name="grid2DGetRow"/>
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


### 5.13 Grid2D.GetCol() <a name="grid2DGetCol"/>
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


### 5.14 Grid2D.ClearGrid() <a name="grid2DClearGrid"/>
Clear the grid and reset all the positions to their default values
#### Declaration
```csharp
public void ClearGrid();
```


### 5.15 Grid2D.Fill() <a name="grid2DFill"/>
Fill all the positions in the grid with a specific value
#### Declaration
```csharp
public void Fill(T value);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| T | value | The value to apply to every position |


### 5.16 Grid2D.GetGridObjectAtGridPosition2D() <a name="grid2DGetGridObjectAtGridPosition2D"/>
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


### 5.17 Grid2D.GetGridObjectAtWorldPosition() <a name="grid2DGetGridObjectAtWorldPosition"/>
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


### 5.18 Grid2D.GetRandomGridObject() <a name="grid2DGetRandomGridObject"/>
Get an random object from the grid
#### Declaration
```csharp
public T GetRandomGridObject();
```
#### Returns
| Type | Description |
| :--- | :--- |
| T | A random object from the grid |


### 5.19 Grid2D.GetSubGrid() <a name="grid2DGetSubGrid"/>
Get a sub-grid from the original grid (inclusive interval)
#### Declaration
```csharp
public Grid2D<T> GetSubGrid(int startRow, int endRow, int startColumn, int endColumn, Vector3 newGridOriginPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | startRow | The start row of the subgrid |
| int | endRow | The end row of the subgrid (inclusive) |
| int | startColumn | The start column of the subgrid |
| int | endColumn | The end column of the subgrid |
| Vector3 | newGridPosition | The original position for the subgrid |
#### Returns
| Type | Description |
| :--- | :--- |
| Grid2D<T> | A subgrid containing the elements of the original grid |


### 5.20 Grid2D.GetRandomGridPosition() <a name="grid2DGetRandomGridPosition"/>
Gets a random position from the grid
#### Declaration
```csharp
public GridPosition2D GetRandomGridPosition();
```
#### Returns
| Type | Description |
| :--- | :--- |
| GridPosition2D | A random position within the grid |


### 5.21 Grid2D.SetGridObjectAtGridPosition2D() <a name="grid2DSetGridObjectAtGridPosition2D"/>
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


### 5.22 Grid2D.SetGridObjectAtWorldPosition() <a name="grid2DSetGridObjectAtWorldPosition"/>
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


### 5.23 Grid2D.GetWorldPositionFromGridPosition2D() <a name="grid2DGetWorldPositionFromGridPosition2D"/>
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


### 5.24 Grid2D.GetWorldPositionFromCenterGridPosition2D() <a name="grid2DGetWorldPositionFromCenterGridPosition2D"/>
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


### 5.25 Grid2D.TryGetWorldPositionFromGridPosition2D() <a name="grid2DTryGetWorldPositionFromGridPosition2D"/>
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


### 5.26 Grid2D.TryGetWorldPositionFromCenterGridPosition2D() <a name="grid2DTryGetWorldPositionFromCenterGridPosition2D"/>
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


### 5.27 Grid2D.GetGridPosition2DFromWorldPosition() <a name="grid2DGetGridPosition2DFromWorldPosition"/>
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


### 5.28 Grid2D.TryGetGridPosition2DFromWorldPosition() <a name="grid2DTryGetGridPosition2DFromWorldPosition"/>
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


### 5.29 Grid2D.GetGridPositionsInACertainState() <a name="grid2DGetGridPositionsInACertainState"/>
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


### 5.30 Grid2D.IterateOverAllGridPositions() <a name="grid2DIterateOverAllGridPositions"/>
Execute an action for every position in the grid
#### Declaration
```csharp
public void IterateOverAllGridPositions(Action<GridPosition2D, T> action);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Action<GridPosition2D, T> | action | Action to apply on every grid position (params GridPosition2D: grid position, T: value at the position) |


### 5.31 Grid2D.IsWithinGrid2DBounds() <a name="grid2DIsWithinGrid2DBounds"/>
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


### 5.32 Grid2D.IsPositionEmpty() <a name="grid2DIsPositionEmpty"/>
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


### 5.33 Grid2D.GetAdjacentNeighbours() <a name="grid2DGetAdjacentNeighbours"/>
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


### 5.34 Grid2D.GetGridPositionsFromADistanceRange() <a name="grid2DGetGridPositionsFromADistanceRange"/>
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
| List<GridPosition2D> | List containing all the positions within a certain range |


### 5.35 Grid2D.GetGridPositionsFromASquareRange() <a name="grid2DGetGridPositionsFromASquareRange"/>
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
| List<GridPosition2D> | List containing all the positions within a certain square range |


### 5.36 Grid2D.InstantiateGameObjectAtGridPosition() <a name="grid2DInstantiateGameObjectAtGridPosition"/>
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


### 5.37 Grid2D.InstantiateGameObjectAtWorldPosition() <a name="grid2DInstantiateGameObjectAtWorldPosition"/>
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


### 5.38 Grid2D.InstantiateGameObjectsAtEveryGridPosition() <a name="grid2DInstantiateGameObjectsAtEveryGridPosition"/>
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


### 5.39 Grid2D.Save() <a name="grid2DSave"/>
Save/serialize the grid using a binary formatter (T and its members must be a serializable type)
#### Declaration
```csharp
public bool Save(string filename);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | filename | The file to be opened/created for writing |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | If the save operation was successful or not |


### 5.40 Grid2D.Load() <a name="grid2DLoad"/>
Load/deserialize a grid using a binary formatter (T and its members must be a serializable type)
#### Declaration
```csharp
public bool Load(string filename);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | filename | The file to be opened for reading |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | If the load operation was successful or not |

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
