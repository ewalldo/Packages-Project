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
  - [Hex grid shapes](#hexGridShapes)
- [Documentation](#documentation)
  - [GridPosition2D](#gridPosition2DGridPosition2D)
    - [GridPosition2D()](#gridPosition2DGridPosition2D)
    - [GridPosition2D.DirectNeighbours](#gridPosition2DDirectNeighbours)
    - [GridPosition2D.GetDirectNeighbour()](#gridPosition2DGetDirectNeighbour)
    - [GridPosition2D.Neighbours](#gridPosition2DNeighbours)
    - [GridPosition2D.GetNeighbour()](#gridPosition2DGetNeighbour)
    - [GridPosition2D.DistanceFrom()](#gridPosition2DDistanceFrom)
    - [GridPosition2D.ManhattanDistance()](#gridPosition2DManhattanDistance)
    - [GridPosition2D.GetGridPositionsFromADistanceRange()](#gridPosition2DGetGridPositionsFromADistanceRange)
    - [GridPosition2D.GetGridPositionsFromASquareRange()](#gridPosition2DGetGridPositionsFromASquareRange)
    - [GridPosition2D.GetGridPositionsFromACircularRange()](#gridPosition2DGetGridPositionsFromACircularRange)
  - [Grid2D](#grid2Dgrid2D)
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
    - [Grid2D.GetWrappedGridPosition()](#grid2DGetWrappedGridPosition)
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
    - [Grid2D.GetGridPositionsFromACircularRange()](#grid2DGetGridPositionsFromACircularRange)
    - [Grid2D.InstantiateGameObjectAtGridPosition()](#grid2DInstantiateGameObjectAtGridPosition)
    - [Grid2D.InstantiateGameObjectAtWorldPosition()](#grid2DInstantiateGameObjectAtWorldPosition)
    - [Grid2D.InstantiateGameObjectsAtEveryGridPosition()](#grid2DInstantiateGameObjectsAtEveryGridPosition)
    - [Grid2D.Save()](#grid2DSave)
    - [Grid2D.Load()](#grid2DLoad)
  - [AxialCoord](#axialCoordAxialCoord)
    - [AxialCoord()](#axialCoordAxialCoord)
    - [AxialCoord.Neighbours](#axialCoordNeighbours)
    - [AxialCoord.GetNeighbour()](#axialCoordGetNeighbour)
    - [AxialCoord.Diagonals](#axialCoordDiagonals)
    - [AxialCoord.GetDiagonal()](#axialCoordGetDiagonal)
    - [AxialCoord.DistanceFrom()](#axialCoordDistanceFrom)
    - [AxialCoord.Distance()](#axialCoordDistance)
    - [AxialCoord.GetAxialCoordsWithinRange()](#axialCoordGetAxialCoordsWithinRange)
    - [AxialCoord.ReflectQ](#axialCoordReflectQ)
    - [AxialCoord.ReflectR](#axialCoordReflectR)
    - [AxialCoord.ReflectS](#axialCoordReflectS)
    - [AxialCoord.Length()](#axialCoordLength)
  - [HexGrid](#hexGridHexGrid)
    - [HexGrid()](#hexGridHexGrid)
    - [HexGrid.GetEdgeLength](#hexGridGetEdgeLength)
    - [HexGrid.GetGridOriginPosition](#hexGridGetGridOriginPosition)
    - [HexGrid.OnGridPositionValueChanged](#hexGridOnGridPositionValueChanged)
    - [HexGrid.Indexers](#hexGridIndexers)
    - [HexGrid.GetGridObjects()](#hexGridGetGridObjects)
    - [HexGrid.GetGridAxialCoords()](#hexGridGetGridAxialCoords)
    - [HexGrid.ClearGrid()](#hexGridClearGrid)
    - [HexGrid.Fill()](#hexGridFill)
    - [HexGrid.GetGridObjectAtAxialCoord()](#hexGridGetGridObjectAtAxialCoord)
    - [HexGrid.GetGridObjectAtWorldPosition()](#hexGridGetGridObjectAtWorldPosition)
    - [HexGrid.GetRandomObject()](#hexGridGetRandomObject)
    - [HexGrid.GetRandomAxialCoord()](#hexGridGetRandomAxialCoord)
    - [HexGrid.SetGridObjectAtAxialCoord()](#hexGridSetGridObjectAtAxialCoord)
    - [HexGrid.SetGridObjectAtWorldPosition()](#hexGridSetGridObjectAtWorldPosition)
    - [HexGrid.GetWorldPositionFromAxialCoord()](#hexGridGetWorldPositionFromAxialCoord)
    - [HexGrid.TryGetWorldPositionFromAxialCoord()](#hexGridTryGetWorldPositionFromAxialCoord)
    - [HexGrid.GetAxialCoordFromWorldPosition()](#hexGridGetAxialCoordFromWorldPosition)
    - [HexGrid.TryGetAxialCoordFromWorldPosition()](#hexGridTryGetAxialCoordFromWorldPosition)
    - [HexGrid.GetGridPositionsInACertainState()](#hexGridGetGridPositionsInACertainState)
    - [HexGrid.IterateOverAllGridPositions()](#hexGridIterateOverAllGridPositions)
    - [HexGrid.IsWithinHexGridBounds()](#hexGridIsWithinHexGridBounds)
    - [HexGrid.IsPositionEmpty()](#hexGridIsPositionEmpty)
    - [HexGrid.GetAdjacentNeighbours()](#hexGridGetAdjacentNeighbours)
    - [HexGrid.GetDiagonalNeighbours()](#hexGridGetDiagonalNeighbours)
    - [HexGrid.GetAxialCoordsFromADistanceRange()](#hexGridGetAxialCoordsFromADistanceRange)
    - [HexGrid.GetAxialCoordsFromIntersectingRanges()](#hexGridGetAxialCoordsFromIntersectingRanges)
    - [HexGrid.GetRing()](#hexGridGetRing)
    - [HexGrid.GetSpiral()](#hexGridGetSpiral)
    - [HexGrid.InstantiateGameObjectAtAxialCoord()](#hexGridInstantiateGameObjectAtAxialCoord)
    - [HexGrid.InstantiateGameObjectAtWorldPosition()](#hexGridInstantiateGameObjectAtWorldPosition)
    - [HexGrid.InstantiateGameObjectAtEveryAxialCoord()](#hexGridInstantiateGameObjectAtEveryAxialCoord)
    - [HexGrid.Save()](#hexGridSave)
    - [HexGrid.Load()](#hexGridLoad)
    - [HexGrid.GetLine()](#hexGridGetLine)
  - [HexagonHexGrid](#hexagonHexGridHexagonHexGrid)
    - [HexagonHexGrid()](#hexagonHexGridHexagonHexGrid)
  - [RectangleHexGrid](#rectangleHexGridRectangleHexGrid)
    - [RectangleHexGrid()](#rectangleHexGridRectangleHexGrid)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The Grid System Package for Unity is a comprehensive and adaptable tool designed to bring powerful grid-based functionality to your Unity projects. Built with versatility, performance, and ease of use in mind, this package is ideal for games and applications that rely on structured layouts, like board games, tactical strategy games, city-builders and so on. Whether you are working in 2D or need a more unique hexagonal grid system, this package is designed to handle both, with an intuitive API that makes grid management seamless and efficient.  
With the Grid System Package, you can create both standard 2D grids and hexagonal grids without extra setup, expanding the possibilities for your game design. Traditional 2D grids are perfect for tile-based RPGs, puzzle games, and grid-aligned level designs, while hexagonal grids allow for unique spatial arrangements often seen in tactical and strategy games. Each grid type is fully supported, so you can easily integrate whichever layout suits your project’s aesthetic and functional needs.  
Accessing grid elements is made straightforward with indexers, which allow you to retrieve, modify, or set specific cells using coordinates directly. This feature enhances readability and performance, as you can directly access grid cells without needing additional lookup functions. Indexers ensure that all grid cells are readily accessible with simple syntax, improving code clarity and reducing errors.  
The Grid System Package includes a wide range of built-in methods for manipulating grid cells. These include methods to get all the positions that fulfil a certain condition, that apply an operation on each each cell, that get all the positions within a range, and more. These methods make it easy to work with the grid data in a consistent and efficient manner.  

The Grid System Package for Unity offers a comprehensive solution for developers looking to integrate structured grid-based layouts with minimal setup. With broad support for both 2D and hexagonal grids, intuitive indexing access, and extensive manipulation functions, this package eliminates the need to build complex grid systems from scratch.  
Designed with performance and ease-of-use in mind, it ensures that developers can focus on building gameplay features rather than low-level grid management. Whether you're building a complex city-building game with a sprawling map or a tactical RPG with precise grid mechanics, this package adapts to your needs, allowing for both efficient development and a high degree of customization.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.  

## 2 - Version History <a name="versionHistory"/>
- 1.0.0: Initial release
- 1.0.1: Remove redundant error checking
- 1.0.2: Refactor GridPosition2D struct and Grid2D class
- 1.1.0: Add support for hex grids

## 3 - Features <a name="features"/>
- Use of generics allowing the instantiation of any type of grid.
- Supports both 2D and hex grids.
- Support for different shapes of hex grids.
- Easy-to-use methods that simplifies working with grid data in Unity projects.
- Different types of indexer makes it easier to access position in the grid.
- Many types of methods to manipulate or get information from the grid.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Instantiate a grid <a name="instantiateAGrid"/>
An instance of a 2D or hex grid class can be instantiated by calling one of its constructors and passing the required grid information as parameters and the type of objects that the grid will hold.  
The constructor also accepts an optional Func parameter that can be used to initialize the object on each cell instead of using their default values. You can find below an example on how to instantiate the grid classes.  
```csharp
// Example of how to instantiate a grid of Terrain (let's assume that Terrain is a class that holds information about the height of the game's terrain)
// Here we are instantiating a 10x10 2d grid where each cell has a size of 2. The grid origin is located at the (0, 0, 0) position and each terrain object is initialized using an anonymous function.
Grid2D<Terrain> terrainGrid = new Grid2D<Terrain>(10, 10, 2, Vector3.Zero, (Grid2D<Terrain> g, GridPosition2D gp) => new Terrain(g, gp, terrainHeight=Random.Next(10)));

// Using the same example as above, a grid of Terrain
// Here we are instantiating a hex grid where there are 9 rows below and 9 columns to the right of the origin hex cell (10x10 rectangular hex grid), with a edge lenght of 2. The grid origin is located at the (0, 0, 0) position and each terrain object is initialized using an anonymous function.
RectangleHexGrid<Terrain> terrainGrid = new RectangleHexGrid<Terrain>(HexType.FlatTop, HexAlignment.FlatTopDown, 0, 9, 0, 9, 2, Vector3.zero, (RectangleHexGrid<Terrain> g, AxialCoord ac) => new Terrain(g, ac, terrainHeight=Random.Next(10)));

// Grid2D constructors
public Grid2D<T>(int width, int height, float cellSizeX, float cellSizeZ, Vector3 gridOriginPosition, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null);
public Grid2D<T>(int width, int height, float cellSizeX, float cellSizeZ, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null);
public Grid2D<T>(int width, int height, float cellSize, Vector3 gridOriginPosition, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null);
public Grid2D<T>(int width, int height, float cellSize, Func<Grid2D<T>, GridPosition2D, T> gridObjectInitializer = null);

// RectangleHexGrid constructors
public RectangleHexGrid<T>(HexType hexType, HexAlignment centerHexRowColumnAlignment, int leftOffset, int rightOffset, int topOffset, int bottomOffset, float edgeLength, Vector3 gridOriginPosition, Func<RectangleHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);
public RectangleHexGrid<T>(HexType hexType, HexAlignment centerHexRowColumnAlignment, int leftOffset, int rightOffset, int topOffset, int bottomOffset, float edgeLength, Func<RectangleHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);

// HexagonHexGrid constructors
public HexagonHexGrid<T>(HexType hexType, int rangeFromCenter, float edgeLength, Vector3 gridOriginPosition, Func<HexagonHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);
public HexagonHexGrid<T>(HexType hexType, int rangeFromCenter, float edgeLength, Func<HexagonHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);
```

### 4.2 Accessing grid elements <a name="accessingGridElements"/>
Grid elements can be accessed in different ways. You can get elements from the grid by its GridPosition2D (ex 1), coordinates (ex 2), world position (ex 3) or by one of the Get methods (ex 4). Same apply to setting the elements.  
```csharp
// ex 1
GridPosition2D gridPosition = new GridPosition2D(x, y);
var cellValue = grid2D[gridPosition];
grid2D[gridPosition] = cellValue;

AxialCoord axialCoord = new AxialCoord(q, r);
var hexCellValue = hexGrid[axialCoord];
hexGrid[axialCoord] = hexCellValue;

// ex 2
var cellValue = grid2D[x, y];
grid2D[x, y] = cellValue;

var hexCellValue = hexGrid[q, r];
hexGrid[q, r] = hexCellValue;

// ex 3
Vector3 pos = new Vector3(0, 0, 0);
var cellValue = grid2D[pos];
grid2D[pos] = cellValue;

var hexCellValue = hexGrid[pos];
hexGrid[pos] = hexCellValue;

// ex 4
var cellValue = grid2D.GetGridObjectAtGridPosition2D(gridPosition);
var cellValue = grid2D.GetGridObjectAtWorldPosition(pos);
grid2D.SetGridObjectAtGridPosition2D(gridPosition, cellValue);
grid2D.SetGridObjectAtWorldPosition(pos, cellValue);

var hexCellValue = hexGrid.GetGridObjectAtAxialCoord(axialCoord);
var hexCellValue = hexGrid.GetGridObjectAtWorldPosition(pos);
hexGrid.SetGridObjectAtAxialCoord(axialCoord, hexCellValue);
hexGrid.SetGridObjectAtWorldPosition(pos, hexCellValue);
```

### 4.3 Relationship between grid coordinates and world coordinates <a name="relationshipBetweenGridCoordinatesAndWorldCoordinates"/>
Grid's cell origin points are at the bottom left part of the cell, so methods like GetWorldPositionFromGridPosition2D() and TryGetWorldPositionFromGridPosition2D() will return the world position located the bottom left of the cell.  
If you want the center position of the cell, use the GetWorldPositionFromCenterGridPosition2D() and TryGetWorldPositionFromCenterGridPosition2D() instead.  
When getting grid coordinates from world position, the origin of the cell doesn't matter at all.  
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

### 4.5 Hex grid shapes <a name="hexGridShapes"/>
The current version of this package supports the creation of the following hex grid shapes:  
- Rectangular
- Hexagon
Each shape requires different parameters, below is the constructor of each hex shape.  
For more details regarding each parameter, please chech the documentation.  
```csharp
// RectangleHexGrid constructors
public RectangleHexGrid<T>(HexType hexType, HexAlignment centerHexRowColumnAlignment, int leftOffset, int rightOffset, int topOffset, int bottomOffset, float edgeLength, Vector3 gridOriginPosition, Func<RectangleHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);
public RectangleHexGrid<T>(HexType hexType, HexAlignment centerHexRowColumnAlignment, int leftOffset, int rightOffset, int topOffset, int bottomOffset, float edgeLength, Func<RectangleHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);

// HexagonHexGrid constructors
public HexagonHexGrid<T>(HexType hexType, int rangeFromCenter, float edgeLength, Vector3 gridOriginPosition, Func<HexagonHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);
public HexagonHexGrid<T>(HexType hexType, int rangeFromCenter, float edgeLength, Func<HexagonHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);
```

## 5 - Documentation <a name="documentation"/>
### 5.1.1 GridPosition2D() <a name="gridPosition2DGridPosition2D"/>
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


### 5.1.2 GridPosition2D.DirectNeighbours <a name="gridPosition2DDirectNeighbours"/>
Get all the direct (sides) neighbours from this GridPosition2D
#### Declaration
```csharp
public List<GridPosition2D> DirectNeighbours;
```
#### Returns
| Type | Description |
| :--- | :--- |
| List<GridPosition2D> | The direct neighbours of this GridPosition2D |


### 5.1.3 GridPosition2D.GetDirectNeighbour() <a name="gridPosition2DGetDirectNeighbour"/>
Get a specific direct neighbour from this GridPosition2D
#### Declaration
```csharp
public GridPosition2D GetDirectNeighbour(int idx);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | idx | The direct neighbour index |
#### Returns
| Type | Description |
| :--- | :--- |
| GridPosition2D | The neighbour at the idx position |


### 5.1.4 GridPosition2D.Neighbours <a name="gridPosition2DNeighbours"/>
Get all the neighbour positions (side and diagonals) from this GridPosition2D
#### Declaration
```csharp
public List<GridPosition2D> Neighbours;
```
#### Returns
| Type | Description |
| :--- | :--- |
| List<GridPosition2D> | The neighbours of this GridPosition2D |


### 5.1.5 GridPosition2D.GetNeighbour() <a name="gridPosition2DGetNeighbour"/>
Get a specific neighbour from this GridPosition2D
#### Declaration
```csharp
public GridPosition2D GetNeighbour(int idx);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | idx | The neighbour index |
#### Returns
| Type | Description |
| :--- | :--- |
| GridPosition2D | The neighbour at the idx position |


### 5.1.6.1 GridPosition2D.DistanceFrom() <a name="gridPosition2DDistanceFrom"/>
### 5.1.6.2 GridPosition2D.ManhattanDistance() <a name="gridPosition2DManhattanDistance"/>
Calculates the Manhattan distance between this and a different GridPosition2D
Calculates the Manhattan distance between two GridPosition2D
#### Declaration
```csharp
public int DistanceFrom(GridPosition2D other);
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


### 5.1.7 GridPosition2D.GetGridPositionsFromADistanceRange() <a name="gridPosition2DGetGridPositionsFromADistanceRange"/>
Get all the grid positions within a range
#### Declaration
```csharp
public HashSet<GridPosition2D> GetGridPositionsFromADistanceRange(int range);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | range | The length of the range (in grid units) |
#### Returns
| Type | Description |
| :--- | :--- |
| HashSet<GridPosition2D> | Set containing all the positions within the range |


### 5.1.8 GridPosition2D.GetGridPositionsFromASquareRange() <a name="gridPosition2DGetGridPositionsFromASquareRange"/>
Get all the grid positions within a square range
#### Declaration
```csharp
public HashSet<GridPosition2D> GetGridPositionsFromASquareRange(int range);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | range | The length of the range (in grid units) |
#### Returns
| Type | Description |
| :--- | :--- |
| HashSet<GridPosition2D> | Set containing all the positions within the square range |


### 5.1.9 GridPosition2D.GetGridPositionsFromACircularRange() <a name="gridPosition2DGetGridPositionsFromACircularRange"/>
Get all the grid positions within a circular range
#### Declaration
```csharp
public HashSet<GridPosition2D> GetGridPositionsFromACircularRange(float range);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | range | The length of the range (in grid units) |
#### Returns
| Type | Description |
| :--- | :--- |
| HashSet<GridPosition2D> | Set containing all the positions within the circular range |


### 5.2.1 Grid2D() <a name="grid2Dgrid2D"/>
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


### 5.2.2 Grid2D.GetWidth <a name="grid2DGetWidth"/>
Get the width of the grid
#### Declaration
```csharp
public int GetWidth;
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | The width of the grid |


### 5.2.3 Grid2D.GetHeight <a name="grid2DGetHeight"/>
Get the height of the grid
#### Declaration
```csharp
public int GetHeight;
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | The height of the grid |


### 5.2.4 Grid2D.GetCellSizeX <a name="grid2DGetCellSizeX"/>
Get the width of the grid's cell
#### Declaration
```csharp
public float GetCellSizeX;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The cell's width of the grid |


### 5.2.5 Grid2D.GetCellSizeZ <a name="grid2DGetCellSizeZ"/>
Get the height of the grid's cell
#### Declaration
```csharp
public float GetCellSizeZ;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The cell's height of the grid |


### 5.2.6 Grid2D.GetGridOriginPosition <a name="grid2DGetGridOriginPosition"/>
Get the origin position of the grid
#### Declaration
```csharp
public Vector3 GetGridOriginPosition;
```
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | The grid origin position |


### 5.2.7 Grid2D.IsSquareGrid <a name="grid2DIsSquareGrid"/>
Check if is a square grid (width == height)
#### Declaration
```csharp
public bool IsSquareGrid;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | The grid number of rows is the same as the number of columns |


### 5.2.8 Grid2D.IsSquareGridCellSize <a name="grid2DIsSquareGridCellSize"/>
Check if the grid has square cells (cell's width == cell's height)
#### Declaration
```csharp
public bool IsSquareGridCellSize;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | The grid's cells are square (the cells width is the same as the height) |


### 5.2.9 Grid2D.OnGridPositionValueChanged <a name="grid2DOnGridPositionValueChanged"/>
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


### 5.2.10 Grid2D.Indexers <a name="grid2DIndexers"/>
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


### 5.2.11 Grid2D.GetGridObjects <a name="grid2DGetGridObjects"/>
Returns the elements of the grid
#### Declaration
```csharp
public IEnumerable<T> GetGridObjects();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<T> | The elements of the grid |


### 5.2.12 Grid2D.GetRow() <a name="grid2DGetRow"/>
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


### 5.2.13 Grid2D.GetCol() <a name="grid2DGetCol"/>
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


### 5.2.14 Grid2D.ClearGrid() <a name="grid2DClearGrid"/>
Clear the grid and reset all the positions to their default values
#### Declaration
```csharp
public void ClearGrid();
```


### 5.2.15 Grid2D.Fill() <a name="grid2DFill"/>
Fill all the positions in the grid with a specific value
#### Declaration
```csharp
public void Fill(T value);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| T | value | The value to apply to every position |


### 5.2.16 Grid2D.GetGridObjectAtGridPosition2D() <a name="grid2DGetGridObjectAtGridPosition2D"/>
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


### 5.2.17 Grid2D.GetGridObjectAtWorldPosition() <a name="grid2DGetGridObjectAtWorldPosition"/>
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


### 5.2.18 Grid2D.GetRandomGridObject() <a name="grid2DGetRandomGridObject"/>
Get an random object from the grid
#### Declaration
```csharp
public T GetRandomGridObject();
```
#### Returns
| Type | Description |
| :--- | :--- |
| T | A random object from the grid |


### 5.2.19 Grid2D.GetSubGrid() <a name="grid2DGetSubGrid"/>
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


### 5.2.20 Grid2D.GetRandomGridPosition() <a name="grid2DGetRandomGridPosition"/>
Gets a random position from the grid
#### Declaration
```csharp
public GridPosition2D GetRandomGridPosition();
```
#### Returns
| Type | Description |
| :--- | :--- |
| GridPosition2D | A random position within the grid |


### 5.2.21 Grid2D.GetWrappedGridPosition() <a name="grid2DGetWrappedGridPosition"/>
Gets the wrapped position of the grid
#### Declaration
```csharp
public GridPosition2D GetWrappedGridPosition(int x, int z);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | x | The x-coordinate of the position |
| int | z | The z-coordinate of the position |
#### Returns
| Type | Description |
| :--- | :--- |
| GridPosition2D | The wrapped position |


### 5.2.22 Grid2D.SetGridObjectAtGridPosition2D() <a name="grid2DSetGridObjectAtGridPosition2D"/>
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


### 5.2.23 Grid2D.SetGridObjectAtWorldPosition() <a name="grid2DSetGridObjectAtWorldPosition"/>
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


### 5.2.24 Grid2D.GetWorldPositionFromGridPosition2D() <a name="grid2DGetWorldPositionFromGridPosition2D"/>
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


### 5.2.25 Grid2D.GetWorldPositionFromCenterGridPosition2D() <a name="grid2DGetWorldPositionFromCenterGridPosition2D"/>
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


### 5.2.26 Grid2D.TryGetWorldPositionFromGridPosition2D() <a name="grid2DTryGetWorldPositionFromGridPosition2D"/>
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


### 5.2.27 Grid2D.TryGetWorldPositionFromCenterGridPosition2D() <a name="grid2DTryGetWorldPositionFromCenterGridPosition2D"/>
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


### 5.2.28 Grid2D.GetGridPosition2DFromWorldPosition() <a name="grid2DGetGridPosition2DFromWorldPosition"/>
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


### 5.2.29 Grid2D.TryGetGridPosition2DFromWorldPosition() <a name="grid2DTryGetGridPosition2DFromWorldPosition"/>
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


### 5.2.30 Grid2D.GetGridPositionsInACertainState() <a name="grid2DGetGridPositionsInACertainState"/>
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


### 5.2.31 Grid2D.IterateOverAllGridPositions() <a name="grid2DIterateOverAllGridPositions"/>
Execute an action for every position in the grid
#### Declaration
```csharp
public void IterateOverAllGridPositions(Action<GridPosition2D, T> action);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Action<GridPosition2D, T> | action | Action to apply on every grid position (params GridPosition2D: grid position, T: value at the position) |


### 5.2.32 Grid2D.IsWithinGrid2DBounds() <a name="grid2DIsWithinGrid2DBounds"/>
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


### 5.2.33 Grid2D.IsPositionEmpty() <a name="grid2DIsPositionEmpty"/>
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


### 5.2.34 Grid2D.GetAdjacentNeighbours() <a name="grid2DGetAdjacentNeighbours"/>
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


### 5.2.35 Grid2D.GetGridPositionsFromADistanceRange() <a name="grid2DGetGridPositionsFromADistanceRange"/>
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


### 5.2.36 Grid2D.GetGridPositionsFromASquareRange() <a name="grid2DGetGridPositionsFromASquareRange"/>
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


### 5.2.37 Grid2D.GetGridPositionsFromACircularRange() <a name="grid2DGetGridPositionsFromACircularRange"/>
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


### 5.2.38 Grid2D.InstantiateGameObjectAtGridPosition() <a name="grid2DInstantiateGameObjectAtGridPosition"/>
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


### 5.2.39 Grid2D.InstantiateGameObjectAtWorldPosition() <a name="grid2DInstantiateGameObjectAtWorldPosition"/>
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


### 5.2.40 Grid2D.InstantiateGameObjectsAtEveryGridPosition() <a name="grid2DInstantiateGameObjectsAtEveryGridPosition"/>
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


### 5.2.41 Grid2D.Save() <a name="grid2DSave"/>
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


### 5.2.42 Grid2D.Load() <a name="grid2DLoad"/>
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


### 5.3.1 AxialCoord() <a name="axialCoordAxialCoord"/>
Instantiate a new instance of the AxialCoord struct
#### Declaration
```csharp
public AxialCoord(int q, int r);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | q | The position q-coordinate |
| int | r | The position r-coordinate |


### 5.3.2 AxialCoord.Neighbours <a name="axialCoordNeighbours"/>
Get all the neighbour positions from this AxialCoord
#### Declaration
```csharp
public List<AxialCoord> Neighbours;
```
#### Returns
| Type | Description |
| :--- | :--- |
| List<AxialCoord> | The neighbours of this AxialCoord |


### 5.3.3 AxialCoord.GetNeighbour() <a name="axialCoordGetNeighbour"/>
Get a specific neighbour from this AxialCoord
#### Declaration
```csharp
public AxialCoord GetNeighbour(int idx) => Neighbours[(6 + (idx % 6)) % 6];
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | idx | The neighbour index |
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The neighbour at the index position |


### 5.3.4 AxialCoord.Diagonals <a name="axialCoordDiagonals"/>
Get all the diagonal positions from this AxialCoord
#### Declaration
```csharp
public List<AxialCoord> Diagonals;
```
#### Returns
| Type | Description |
| :--- | :--- |
| List<AxialCoord> | The diagonals of this AxialCoord |


### 5.3.5 AxialCoord.GetDiagonal() <a name="axialCoordGetDiagonal"/>
Get a specific diagonal from this AxialCoord
#### Declaration
```csharp
public AxialCoord GetDiagonal(int idx) => Diagonals[(6 + (idx % 6)) % 6];
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | idx | The diagonal index |
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The diagonal at the index position |


### 5.3.6.1 AxialCoord.DistanceFrom() <a name="axialCoordDistanceFrom"/>
### 5.3.6.2 AxialCoord.Distance() <a name="axialCoordDistance"/>
Calculates the distance between this and a different AxialCoord
Calculates the distance between two AxialCoord
#### Declaration
```csharp
public int DistanceFrom(AxialCoord other);
public static int Distance(AxialCoord a, AxialCoord b);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | other | The AxialCoord to calculate the distance from |
| AxialCoord | a | The first AxialCoord |
| AxialCoord | b | The second AxialCoord |
#### Returns
| Type | Description |
| :--- | :--- |
| int | The distance between the two positions |


### 5.3.7 AxialCoord.GetAxialCoordsWithinRange() <a name="axialCoordGetAxialCoordsWithinRange"/>
Get all AxialCoord within a range
#### Declaration
```csharp
public HashSet<AxialCoord> GetAxialCoordsWithinRange(int range);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | range | The length of the range (in grid units) |
#### Returns
| Type | Description |
| :--- | :--- |
| HashSet<AxialCoord> | Set containing all the positions within the range |


### 5.3.8 AxialCoord.ReflectQ <a name="axialCoordReflectQ"/>
Get the AxialCoord position when reflecting through the Q-axis
#### Declaration
```csharp
public AxialCoord ReflectQ;
```
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The position when reflecting through the Q-axis |


### 5.3.9 AxialCoord.ReflectR <a name="axialCoordReflectR"/>
Get the AxialCoord position when reflecting through the R-axis
#### Declaration
```csharp
public AxialCoord ReflectR;
```
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The position when reflecting through the R-axis |


### 5.3.10 AxialCoord.ReflectS <a name="axialCoordReflectS"/>
Get the AxialCoord position when reflecting through the S-axis
#### Declaration
```csharp
public AxialCoord ReflectS;
```
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The position when reflecting through the S-axis |


### 5.3.11 AxialCoord.Length() <a name="axialCoordLength"/>
Calculates the length of an AxialCoord
#### Declaration
```csharp
public static int Length(AxialCoord a);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | a | The AxialCoord to calculate the length |
#### Returns
| Type | Description |
| :--- | :--- |
| int | The AxialCoord's length |


### 5.4.1 HexGrid() <a name="hexGridHexGrid"/>
Initializes a new instance of the HexGrid class
#### Declaration
```csharp
public HexGrid<T>(HexType hexType, float edgeLength, Vector3 gridOriginPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| T | ----- | The type of object that this grid will hold |
| HexType | hexType | The hex type of this grid |
| float | edgeLength | The lenght of the edge of each hex cell |
| Vector3 | gridOriginPosition | The grid origin position |


### 5.4.2 HexGrid.GetEdgeLength <a name="hexGridGetEdgeLength"/>
Get the edge length of the hex cell's of this grid
#### Declaration
```csharp
public float GetEdgeLength;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The edge lenght of a hex cell |


### 5.4.3 HexGrid.GetGridOriginPosition <a name="hexGridGetGridOriginPosition"/>
Get the origin position of the grid
#### Declaration
```csharp
public Vector3 GetGridOriginPosition;
```
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | The grid origin position |


### 5.3.4 HexGrid.OnGridPositionValueChanged <a name="hexGridOnGridPositionValueChanged"/>
Event to be raised when the value of a cell changes
#### Declaration
```csharp
public Action<AxialCoord, T> OnGridPositionValueChanged;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| AxialCoord | The grid position where the value has changed |
| T | The new value assigned to the position |


### 5.3.5 HexGrid.Indexers <a name="hexGridIndexers"/>
Get the object at a specific grid position
#### Declaration
```csharp
public T [int q, int r];
public T [AxialCoord axialCoord];
public T [Vector3 worldPosition];
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | q | The q-coordinate of the grid to get an object from |
| int | r | The r-coordinate of the grid to get an object from |
| AxialCoord | axialCoord | The grid postion to get an object from |
| Vector3 | worldPosition | The world position to be converted to a grid position |
#### Returns
| Type | Description |
| :--- | :--- |
| T | The object at the specified grid position |


### 5.3.6 HexGrid.GetGridObjects() <a name="hexGridGetGridObjects"/>
Returns the elements of the grid
#### Declaration
```csharp
public IEnumerable<T> GetGridObjects();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<T> | Element of the grid |


### 5.3.7 HexGrid.GetGridAxialCoords() <a name="hexGridGetGridAxialCoords"/>
Returns the AxialCoords of this grid
#### Declaration
```csharp
public IEnumerable<AxialCoord> GetGridAxialCoords();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<AxialCoord> | AxialCoord of the grid |


### 5.3.8 HexGrid.ClearGrid() <a name="hexGridClearGrid"/>
Clear the grid and reset all the positions to their default values
#### Declaration
```csharp
public void ClearGrid();
```


### 5.3.9 HexGrid.Fill() <a name="hexGridFill"/>
Fill all the positions in the grid with the specific value
#### Declaration
```csharp
public void Fill(T value);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| T | value | The value to apply on every position |


### 5.3.10 HexGrid.GetGridObjectAtAxialCoord() <a name="hexGridGetGridObjectAtAxialCoord"/>
Get an element from the grid on a specific AxialCoord
#### Declaration
```csharp
public T GetGridObjectAtAxialCoord(AxialCoord axialCoord);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | axialCoord | The position to get the element from |
#### Returns
| Type | Description |
| :--- | :--- |
| T | The object at the specified grid position |


### 5.3.11 HexGrid.GetGridObjectAtWorldPosition() <a name="hexGridGetGridObjectAtWorldPosition"/>
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
| T | The object at the specified world position |


### 5.3.12 HexGrid.GetRandomObject() <a name="hexGridGetRandomObject"/>
Get an random object from the grid
#### Declaration
```csharp
public T GetRandomObject();
```
#### Returns
| Type | Description |
| :--- | :--- |
| T | A random object from the grid |


### 5.3.13 HexGrid.GetRandomAxialCoord() <a name="hexGridGetRandomAxialCoord"/>
Gets a random position from the grid
#### Declaration
```csharp
public AxialCoord GetRandomAxialCoord();
```
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | A random position within the grid |


### 5.3.14 HexGrid.SetGridObjectAtAxialCoord() <a name="hexGridSetGridObjectAtAxialCoord"/>
Set a grid object in a specific grid position
#### Declaration
```csharp
public bool SetGridObjectAtAxialCoord(AxialCoord axialCoord, T newObject, bool replaceIfExistAnObjectAlready = true);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | axialCoord | The grid position of the object |
| T | newObject | The new object to set in the position |
| bool | replaceIfExistAnObjectAlready | Replace even if the position has already been assigned |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the object was successfully assigned, false otherwise |


### 5.3.15 HexGrid.SetGridObjectAtWorldPosition() <a name="hexGridSetGridObjectAtWorldPosition"/>
Set an object in the grid based on a world position
#### Declaration
```csharp
public bool SetGridObjectAtWorldPosition(Vector3 worldPosition, T newObject, bool replaceIfExistAnObjectAlready = true);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | worldPosition | The world position of the object |
| T | newObject | The new object to set in the position |
| bool | replaceIfExistAnObjectAlready | Replace even if the position has already been assigned |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the object was successfully assigned, false otherwise |


### 5.3.16 HexGrid.GetWorldPositionFromAxialCoord() <a name="hexGridGetWorldPositionFromAxialCoord"/>
Converts a AxialCoord to a world position
#### Declaration
```csharp
public Vector3 GetWorldPositionFromAxialCoord(AxialCoord axialCoord);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | axialCoord | The AxialCoord to convert from |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | The position in world coordinates |


### 5.3.17 HexGrid.TryGetWorldPositionFromAxialCoord() <a name="hexGridTryGetWorldPositionFromAxialCoord"/>
Try to convert a AxialCoord into a world position
#### Declaration
```csharp
public bool TryGetWorldPositionFromAxialCoord(AxialCoord axialCoord, out Vector3 worldPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | axialCoord | The AxialCoord to convert from |
| Vector3 | worldPosition | The position in world coordinates |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if it is able to convert, false otherwise |


### 5.3.18 HexGrid.GetAxialCoordFromWorldPosition() <a name="hexGridGetAxialCoordFromWorldPosition"/>
Converts a world position into AxialCoord
#### Declaration
```csharp
public AxialCoord GetAxialCoordFromWorldPosition(Vector3 worldPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | worldPosition | The world position to convert from |
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The AxialCoord corresponding to the world position |


### 5.3.19 HexGrid.TryGetAxialCoordFromWorldPosition() <a name="hexGridTryGetAxialCoordFromWorldPosition"/>
Try to convert a world position into AxialCoord
#### Declaration
```csharp
public bool TryGetAxialCoordFromWorldPosition(Vector3 worldPosition, out AxialCoord axialCoord);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | worldPosition | The world position to try to convert from |
| AxialCoord | axialCoord | The corresponding AxialCoord |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if it is able to convert, false otherwise |


### 5.3.20 HexGrid.GetGridPositionsInACertainState() <a name="hexGridGetGridPositionsInACertainState"/>
Get all positions that satisfies a condition
#### Declaration
```csharp
public List<AxialCoord> GetGridPositionsInACertainState(Func<T, bool> predicate);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Func<T, bool> | predicate | The condition to check on each position (params T: value at the position) |
#### Returns
| Type | Description |
| :--- | :--- |
| List<AxialCoord> | A list containing all the positions that satisfies the condition |


### 5.3.21 HexGrid.IterateOverAllGridPositions() <a name="hexGridIterateOverAllGridPositions"/>
Execute an action for every position in the grid
#### Declaration
```csharp
public void IterateOverAllGridPositions(Action<AxialCoord, T> action);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Action<AxialCoord, T> | action | Action to apply on every grid position (params AxialCoord: grid position, T: value at the position) |


### 5.3.22 HexGrid.IsWithinHexGridBounds() <a name="hexGridIsWithinHexGridBounds"/>
Check if a grid position is within the grid bounds
#### Declaration
```csharp
public bool IsWithinHexGridBounds(AxialCoord axialCoord);
public bool IsWithinHexGridBounds(int q, int r);
public bool IsWithinHexGridBounds(Vector3 worldPosition);
public bool IsWithinHexGridBounds(IEnumerable<AxialCoord> axialCoords);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | axialCoord | The AxialCoord to check |
| int | q | The q-coordinate to check |
| int | r | The r-coordinate to check |
| Vector3 | worldPosition | The world position to check |
| IEnumerable<AxialCoord> | axialCoords | Collection containing all the positions to check |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the position (or all positions) is/are within the grid, false otherwise |


### 5.3.23 HexGrid.IsPositionEmpty() <a name="hexGridIsPositionEmpty"/>
Check if the position is empty (or default value in case of a non-nullable type)
#### Declaration
```csharp
public bool IsPositionEmpty(AxialCoord axialCoord);
public bool IsPositionEmpty(int q, int r);
public bool IsPositionEmpty(Vector3 worldPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | axialCoord | The AxialCoord to check |
| int | q | The q-coordinate to check |
| int | r | The r-coordinate to check |
| Vector3 | worldPosition | The world position to check |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the position is empty, false otherwise |


### 5.3.24 HexGrid.GetAdjacentNeighbours() <a name="hexGridGetAdjacentNeighbours"/>
Get all adjacent neighbours of a specific position
#### Declaration
```csharp
public List<AxialCoord> GetAdjacentNeighbours(AxialCoord center, bool includeCenterPosition = false);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | center | The center position to get the neighbours from |
| bool | includeCenterPosition | Should include the center position in the return list |
#### Returns
| Type | Description |
| :--- | :--- |
| List<AxialCoord> | List containing all the neighbour positions of a specific grid position |


### 5.3.25 HexGrid.GetDiagonalNeighbours() <a name="hexGridGetDiagonalNeighbours"/>
Get all diagonals of a specific position
#### Declaration
```csharp
public List<AxialCoord> GetDiagonalNeighbours(AxialCoord center, bool includeCenterPosition = false);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | center | The center position to get the diagonals from |
| bool | includeCenterPosition | Should include the center position in the return list |
#### Returns
| Type | Description |
| :--- | :--- |
| List<AxialCoord> | List containing all the diagonal positions of a specific grid position |


### 5.3.26 HexGrid.GetAxialCoordsFromADistanceRange() <a name="hexGridGetAxialCoordsFromADistanceRange"/>
Get all the grid positions within a range
#### Declaration
```csharp
public List<AxialCoord> GetAxialCoordsFromADistanceRange(AxialCoord center, int range, bool includeCenterPosition = false);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | center | The center position to calculate the range from |
| int | range | The length of the range (in grid units) |
| bool | includeCenterPosition | Should include the center position in the return list |
#### Returns
| Type | Description |
| :--- | :--- |
| List<AxialCoord> | List containing all the positions within the range |


### 5.3.27 HexGrid.GetAxialCoordsFromIntersectingRanges() <a name="hexGridGetAxialCoordsFromIntersectingRanges"/>
Given two centers and a range, gets all the grid positions that intersects
#### Declaration
```csharp
public List<AxialCoord> GetAxialCoordsFromIntersectingRanges(AxialCoord center1, AxialCoord center2, int range);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | center1 | The first center position |
| AxialCoord | center2 | The second center position |
| int | range | The length of the range (in grid units) |
#### Returns
| Type | Description |
| :--- | :--- |
| List<AxialCoord> | List containing all the intersected positions |


### 5.3.28 HexGrid.GetRing() <a name="hexGridGetRing"/>
Get all the positions forming a ring around a specific center
#### Declaration
```csharp
public List<AxialCoord> GetRing(AxialCoord center, int radius);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | center | The center position to get the ring from |
| int | radius | The radius of the ring (in grid units) |
#### Returns
| Type | Description |
| :--- | :--- |
| List<AxialCoord> | List containing all the positions forming the ring |


### 5.3.29 HexGrid.GetSpiral() <a name="hexGridGetSpiral"/>
Get all the positions forming a spiral from a specific center
#### Declaration
```csharp
public List<AxialCoord> GetSpiral(AxialCoord center, int radius);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | center | The center position of the spiral |
| int | radius | The radius of the spiral (in grid units) |
#### Returns
| Type | Description |
| :--- | :--- |
| List<AxialCoord> | List containing all the positions forming the spiral |


### 5.3.30 HexGrid.InstantiateGameObjectAtAxialCoord() <a name="hexGridInstantiateGameObjectAtAxialCoord"/>
Instantiate a game object in a certain grid position
#### Declaration
```csharp
public GameObject InstantiateGameObjectAtAxialCoord(AxialCoord axialCoord, GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onGameObjectSpawned = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | axialCoord | The grid position to instantiate the object on |
| GameObject | gameObjectPrefab | The object to instantiate |
| Transform | objectParent | The parent transform for the instantiated object |
| Action<GameObject> | onGameObjectSpawned | Action to execute when the object is instantiated |
#### Returns
| Type | Description |
| :--- | :--- |
| GameObject | The instantiated game object |


### 5.3.31 HexGrid.InstantiateGameObjectAtWorldPosition() <a name="hexGridInstantiateGameObjectAtWorldPosition"/>
Instantiate a game object on the grid based on a world position
#### Declaration
```csharp
public GameObject InstantiateGameObjectAtWorldPosition(Vector3 worldPosition, GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onGameObjectSpawned = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | worldPosition | The world position to instantiate the object |
| GameObject | gameObjectPrefab | The object to instantiate |
| Transform | objectParent | The parent transform for the instantiated object |
| Action<GameObject> | onGameObjectSpawned | Action to execute when the object is instantiated |
#### Returns
| Type | Description |
| :--- | :--- |
| GameObject | The instantiated game object |


### 5.3.32 HexGrid.InstantiateGameObjectAtEveryAxialCoord() <a name="hexGridInstantiateGameObjectAtEveryAxialCoord"/>
Instantiate a game object on every grid position
#### Declaration
```csharp
public List<GameObject> InstantiateGameObjectAtEveryAxialCoord(GameObject gameObjectPrefab, Transform objectParent, Action<GameObject> onEachGameObjectSpawned = null, Action<List<GameObject>> onAllGameObjectSpawned = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GameObject | gameObjectPrefab | The object to instantiate |
| Transform | objectParent | The parent transform for all objects |
| Action<GameObject> | onEachGameObjectSpawned | Action to execute when one object is instantiated (params GameObject: the instantiated game object) |
| Action<List<GameObject>> | onAllGameObjectSpawned | Action to execute after all objecta are instantiated (params List<GameObject>: all the instantiated game objects) |
#### Returns
| Type | Description |
| :--- | :--- |
| List<GameObject> | A list containing all the instantiated game objects |


### 5.3.33 HexGrid.Save() <a name="hexGridSave"/>
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
| bool | True if the save operation was successful, false otherwise |


### 5.3.34 HexGrid.Load() <a name="hexGridLoad"/>
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
| bool | True if the save operation was successful, false otherwise |


### 5.3.35 HexGrid.GetLine() <a name="hexGridGetLine"/>
Gets all the AxialCoord that forms a straight line between two positions
#### Declaration
```csharp
public static HashSet<AxialCoord> GetLine(AxialCoord start, AxialCoord end, bool includeStartAndEndPositions = true);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | start | The start of the line |
| AxialCoord | end | The end of the line |
| bool | includeStartAndEndPositions | Should the start and end positions be included in the return set |
#### Returns
| Type | Description |
| :--- | :--- |
| HashSet<AxialCoord> | Set containing all the positions forming the line |


### 5.5.1 HexagonHexGrid() <a name="hexagonHexGridHexagonHexGrid"/>
Initializes a new instance of the HexagonHexGrid class
#### Declaration
```csharp
public HexagonHexGrid<T>(HexType hexType, int rangeFromCenter, float edgeLength, Vector3 gridOriginPosition, Func<HexagonHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);
public HexagonHexGrid<T>(HexType hexType, int rangeFromCenter, float edgeLength, Func<HexagonHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| T | ----- | The type of object that this grid will hold |
| HexType | hexType | The type of hex this grid is composed of |
| int | rangeFromCenter | The number of hex cells on each direction from the center |
| float | edgeLength | The edge length of a hex cell |
| Vector3 | gridOriginPosition | The origin position of the hex grid |
| Func<HexagonHexGrid<T>, AxialCoord, T> | gridObjectInitializer | The initialize function for each grid element (Func<HexagonHexGrid<T>, AxialCoord, T> where HexagonHexGrid<T> references this grid object and AxialCoord references the position in the grid for the object) |


### 5.6.1 RectangleHexGrid() <a name="rectangleHexGridRectangleHexGrid"/>
Initializes a new instance of the RectangleHexGrid class
#### Declaration
```csharp
public RectangleHexGrid<T>(HexType hexType, HexAlignment centerHexRowColumnAlignment, int leftOffset, int rightOffset, int topOffset, int bottomOffset, float edgeLength, Vector3 gridOriginPosition, Func<RectangleHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);
public RectangleHexGrid<T>(HexType hexType, HexAlignment centerHexRowColumnAlignment, int leftOffset, int rightOffset, int topOffset, int bottomOffset, float edgeLength, Func<RectangleHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| T | ----- | The type of object that this grid will hold |
| HexType | hexType | The type of hex this grid is composed of |
| HexAlignment | centerHexRowColumnAlignment | The alignment of the center row (PointTop) or column (FlatTop) of the grid |
| int | leftOffset | Number of hex cells to the left of the center hex |
| int | rightOffset | Number of hex cells to the right of the center hex |
| int | topOffset | Number of hex cells above the center hex |
| int | bottomOffset | Number of hex cells below the center hex |
| float | edgeLength | The edge length of a hex cell |
| Vector3 | gridOriginPosition | The origin position of the hex grid |
| Func<RectangleHexGrid<T>, AxialCoord, T> | gridObjectInitializer | The initialize function for each grid element (Func<RectangleHexGrid<T>, AxialCoord, T> where RectangleHexGrid<T> references this grid object and AxialCoord references the position in the grid for the object) |

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
