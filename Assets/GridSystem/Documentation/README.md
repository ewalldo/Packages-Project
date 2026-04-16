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
  - [Grid2D](#grid2D)
  - [HexGrid](#hexGrid)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The Grid System Package for Unity is a comprehensive and adaptable tool designed to bring powerful grid-based functionality to your Unity projects. Built with versatility, performance, and ease of use in mind, this package is ideal for games and applications that rely on structured layouts, like board games, tactical strategy games, city-builders and so on. Whether you are working in 2D or need a more unique hexagonal grid system, this package is designed to handle both, with an intuitive API that makes grid management seamless and efficient.  
With the Grid System Package, you can create both standard 2D grids and hexagonal grids without extra setup, expanding the possibilities for your game design. Traditional 2D grids are perfect for tile-based RPGs, puzzle games, and grid-aligned level designs, while hexagonal grids allow for unique spatial arrangements often seen in tactical and strategy games. Each grid type is fully supported, so you can easily integrate whichever layout suits your project’s aesthetic and functional needs.  
Accessing grid elements is made straightforward with indexers, which allow you to retrieve, modify, or set specific cells using coordinates directly. This feature enhances readability and performance, as you can directly access grid cells without needing additional lookup functions. Indexers ensure that all grid cells are readily accessible with simple syntax, improving code clarity and reducing errors.  
The Grid System Package includes a wide range of built-in methods for manipulating grid cells. These include methods to get all the positions that fulfil a certain condition, that apply an operation on each each cell, that get all the positions within a range, and more. These methods make it easy to work with the grid data in a consistent and efficient manner.  

The Grid System Package for Unity offers a comprehensive solution for developers looking to integrate structured grid-based layouts with minimal setup. With broad support for both 2D and hexagonal grids, intuitive indexing access, and extensive manipulation functions, this package eliminates the need to build complex grid systems from scratch.  
Designed with performance and ease-of-use in mind, it ensures that developers can focus on building gameplay features rather than low-level grid management. Whether you're building a complex city-building game with a sprawling map or a tactical RPG with precise grid mechanics, this package adapts to your needs, allowing for both efficient development and a high degree of customization.  

This package has been updated to Unity 6000.3.9f1. However, it should work without issue with earlier or future versions of Unity.  
Please let us know if you encounter any issues with the version of Unity you are using.

## 2 - Version History <a name="versionHistory"/>
- 1.0.0: Initial release
- 1.0.1: Remove redundant error checking
- 1.0.2: Refactor GridPosition2D struct and Grid2D class
- 1.1.0: Add support for hex grids
- 1.1.1: Ensure package functionality in Unity version 6000.3.9f1
- 1.1.2: Add new sample scene to showcase hex grids
- 1.1.3: Add new methods and improve code readability/maintainability for 2D Grids

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
* [Grid2D](Grid2D.md) <a name="grid2D">
* [HexGrid](HexGrid.md) <a name="hexGrid">

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
