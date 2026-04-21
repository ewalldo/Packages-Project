# HexGrid
## Table of contents
- [Documentation](#documentation)
  - [AxialCoord](#axialCoordAxialCoord)
      - [AxialCoord()](#axialCoordAxialCoord)
      - [AxialCoord.Neighbours](#axialCoordNeighbours)
      - [AxialCoord.Diagonals](#axialCoordDiagonals)
      - [AxialCoord.DistanceFrom()](#axialCoordDistanceFrom)
      - [AxialCoord.Distance()](#axialCoordDistance)
      - [AxialCoord.GetAxialCoordsWithinRange()](#axialCoordGetAxialCoordsWithinRange)
      - [AxialCoord.ReflectQ](#axialCoordReflectQ)
      - [AxialCoord.ReflectR](#axialCoordReflectR)
      - [AxialCoord.ReflectS](#axialCoordReflectS)
      - [AxialCoord.RotateClockwise](#axialCoordRotateClockwise)
      - [AxialCoord.RotateCounterClockwise](#axialCoordRotateCounterClockwise)
      - [AxialCoord.RotateClockwiseAround()](#axialCoordRotateClockwiseAround)
      - [AxialCoord.Length()](#axialCoordLength)
    - [HexGrid](#hexGridHexGrid)
      - [HexGrid()](#hexGridHexGrid)
      - [HexGrid.HexGridType](#hexGridHexGridType)
      - [HexGrid.EdgeLength](#hexGridEdgeLength)
      - [HexGrid.GridOriginPosition](#hexGridGridOriginPosition)
      - [HexGrid.OnGridPositionValueChanged](#hexGridOnGridPositionValueChanged)
      - [HexGrid.Indexers](#hexGridIndexers)
      - [HexGrid.GetEnumerator()](#hexGridGetEnumerator)
      - [HexGrid.GetGridAxialCoords()](#hexGridGetGridAxialCoords)
      - [HexGrid.GetGridObjectsWithPositions()](#hexGridGetGridObjectsWithPositions)
      - [HexGrid.ClearGrid()](#hexGridClearGrid)
      - [HexGrid.Fill()](#hexGridFill)
      - [HexGrid.Swap()](#hexGridSwap)
      - [HexGrid.GetGridObjectAtAxialCoord()](#hexGridGetGridObjectAtAxialCoord)
      - [HexGrid.TryGetGridObjectAtAxialCoord()](#hexGridTryGetGridObjectAtAxialCoord)
      - [HexGrid.GetGridObjectAtWorldPosition()](#hexGridGetGridObjectAtWorldPosition)
      - [HexGrid.TryGetGridObjectAtWorldPosition()](#hexGridTryGetGridObjectAtWorldPosition)
      - [HexGrid.GetRandomObject()](#hexGridGetRandomObject)
      - [HexGrid.GetRandomAxialCoord()](#hexGridGetRandomAxialCoord)
      - [HexGrid.SetGridObjectAtAxialCoord()](#hexGridSetGridObjectAtAxialCoord)
      - [HexGrid.SetGridObjectAtWorldPosition()](#hexGridSetGridObjectAtWorldPosition)
      - [HexGrid.GetWorldPositionFromAxialCoord()](#hexGridGetWorldPositionFromAxialCoord)
      - [HexGrid.TryGetWorldPositionFromAxialCoord()](#hexGridTryGetWorldPositionFromAxialCoord)
      - [HexGrid.GetAxialCoordFromWorldPosition()](#hexGridGetAxialCoordFromWorldPosition)
      - [HexGrid.TryGetAxialCoordFromWorldPosition()](#hexGridTryGetAxialCoordFromWorldPosition)
      - [HexGrid.Any()](#hexGridAny)
      - [HexGrid.All()](#hexGridAll)
      - [HexGrid.Where()](#hexGridWhere)
      - [HexGrid.IterateOverAllGridPositions()](#hexGridIterateOverAllGridPositions)
      - [HexGrid.IsWithinHexGridBounds()](#hexGridIsWithinHexGridBounds)
      - [HexGrid.IsPositionEmpty()](#hexGridIsPositionEmpty)
      - [HexGrid.GetAdjacentNeighbours()](#hexGridGetAdjacentNeighbours)
      - [HexGrid.GetDiagonalNeighbours()](#hexGridGetDiagonalNeighbours)
      - [HexGrid.GetAxialCoordsFromADistanceRange()](#hexGridGetAxialCoordsFromADistanceRange)
      - [HexGrid.GetAxialCoordsFromIntersectingRanges()](#hexGridGetAxialCoordsFromIntersectingRanges)
      - [HexGrid.GetRing()](#hexGridGetRing)
      - [HexGrid.GetSpiral()](#hexGridGetSpiral)
      - [HexGrid.GetLineWithinBounds()](#hexGridGetLineWithinBounds)
      - [HexGrid.InstantiateGameObjectAtAxialCoord()](#hexGridInstantiateGameObjectAtAxialCoord)
      - [HexGrid.InstantiateGameObjectAtWorldPosition()](#hexGridInstantiateGameObjectAtWorldPosition)
      - [HexGrid.InstantiateGameObjectAtEveryAxialCoord()](#hexGridInstantiateGameObjectAtEveryAxialCoord)
      - [HexGrid.Save()](#hexGridSave)
      - [HexGrid.Load()](#hexGridLoad)
    - [HexagonHexGrid](#hexagonHexGridHexagonHexGrid)
      - [HexagonHexGrid()](#hexagonHexGridHexagonHexGrid)
    - [RectangleHexGrid](#rectangleHexGridRectangleHexGrid)
      - [RectangleHexGrid()](#rectangleHexGridRectangleHexGrid)

## Documentation <a name="documentation"/>
### 1 AxialCoord() <a name="axialCoordAxialCoord"/>
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


### AxialCoord.Neighbours <a name="axialCoordNeighbours"/>
Get all the neighbour positions from this AxialCoord
#### Declaration
```csharp
public List<AxialCoord> Neighbours;
```
#### Returns
| Type | Description |
| :--- | :--- |
| List<AxialCoord> | The neighbours of this AxialCoord |


### AxialCoord.Diagonals <a name="axialCoordDiagonals"/>
Get all the diagonal positions from this AxialCoord
#### Declaration
```csharp
public List<AxialCoord> Diagonals;
```
#### Returns
| Type | Description |
| :--- | :--- |
| List<AxialCoord> | The diagonals of this AxialCoord |


### AxialCoord.DistanceFrom() <a name="axialCoordDistanceFrom"/>
### AxialCoord.Distance() <a name="axialCoordDistance"/>
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


### AxialCoord.GetAxialCoordsWithinRange() <a name="axialCoordGetAxialCoordsWithinRange"/>
Get all AxialCoord within a range
#### Declaration
```csharp
public HashSet<AxialCoord> GetAxialCoordsWithinRange(int range, bool includeSelf = true);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | range | The length of the range (in grid units) |
| bool | includeSelf | Whether to include the current position in the returned set |
#### Returns
| Type | Description |
| :--- | :--- |
| HashSet<AxialCoord> | Set containing all the positions within the range |


### AxialCoord.ReflectQ <a name="axialCoordReflectQ"/>
Reflects this coordinate across the Q axis (keeping Q constant, swapping R and S)
#### Declaration
```csharp
public AxialCoord ReflectQ;
```
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The position when reflecting through the Q-axis |


### AxialCoord.ReflectR <a name="axialCoordReflectR"/>
Reflects this coordinate across the R axis (keeping R constant, swapping Q and S)
#### Declaration
```csharp
public AxialCoord ReflectR;
```
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The position when reflecting through the R-axis |


### AxialCoord.ReflectS <a name="axialCoordReflectS"/>
Reflects this coordinate across the S axis (keeping S constant, swapping Q and R)
#### Declaration
```csharp
public AxialCoord ReflectS;
```
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The position when reflecting through the S-axis |


### AxialCoord.RotateClockwise <a name="axialCoordRotateClockwise"/>
Rotates this coordinate 60° clockwise around the origin
#### Declaration
```csharp
public AxialCoord RotateClockwise;
```
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The position when rotating around the origin clockwise |


### AxialCoord.RotateCounterClockwise <a name="axialCoordRotateCounterClockwise"/>
Rotates this coordinate 60° counter-clockwise around the origin
#### Declaration
```csharp
public AxialCoord RotateCounterClockwise;
```
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The position when rotating around the origin counter-clockwise |


### AxialCoord.RotateClockwiseAround <a name="axialCoordRotateClockwiseAround"/>
Rotates this coordinate around a center point
#### Declaration
```csharp
public AxialCoord RotateClockwiseAround(AxialCoord center, int steps = 1);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | center | The center point to rotate around |
| int | steps | The number of 60° steps to rotate |
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The position when rotating around clockwise around the specified center position a steps amount of time |


### AxialCoord.Length() <a name="axialCoordLength"/>
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


### 2 HexGrid() <a name="hexGridHexGrid"/>
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


### HexGrid.HexGridType <a name="hexGridHexGridType"/>
Get the hex type of this grid
#### Declaration
```csharp
public HexType HexGridType;
```
#### Returns
| Type | Description |
| :--- | :--- |
| HexType | The hex type of this grid |


### HexGrid.EdgeLength <a name="hexGridEdgeLength"/>
Get the edge length of the hex cell's of this grid
#### Declaration
```csharp
public float EdgeLength;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The edge lenght of a hex cell |


### HexGrid.GridOriginPosition <a name="hexGridGridOriginPosition"/>
Get the origin position of the grid
#### Declaration
```csharp
public Vector3 GridOriginPosition;
```
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | The grid origin position |


### HexGrid.Count <a name="hexGridCount"/>
Get the number of positions in the grid
#### Declaration
```csharp
public int Count;
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | The number of positions in the grid |


### HexGrid.OnGridPositionValueChanged <a name="hexGridOnGridPositionValueChanged"/>
Event to be raised when the value of a cell changes
#### Declaration
```csharp
public event Action<AxialCoord, T> OnGridPositionValueChanged;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| AxialCoord | The grid position where the value has changed |
| T | The new value assigned to the position |


### HexGrid.Indexers <a name="hexGridIndexers"/>
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


### HexGrid.GetEnumerator() <a name="hexGridGetEnumerator"/>
Returns the elements of the grid
#### Declaration
```csharp
public IEnumerator<T> GetEnumerator();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<T> | Element of the grid |


### HexGrid.GetGridAxialCoords() <a name="hexGridGetGridAxialCoords"/>
Returns the AxialCoords of this grid
#### Declaration
```csharp
public IEnumerable<AxialCoord> GetGridAxialCoords();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<AxialCoord> | AxialCoord of the grid |


### HexGrid.GetGridObjectsWithPositions() <a name="hexGridGetGridObjectsWithPositions"/>
Returns the elements of the grid with their respective positions
#### Declaration
```csharp
public IEnumerable<(AxialCoord Position, T Value)> GetGridObjectsWithPositions();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<AxialCoord, T> | The elements of the grid and the respective position |


### HexGrid.ClearGrid() <a name="hexGridClearGrid"/>
Clear the grid and reset all the positions to their default values
#### Declaration
```csharp
public void ClearGrid();
```


### HexGrid.Fill() <a name="hexGridFill"/>
Fill all the positions in the grid with the specific value
#### Declaration
```csharp
public void Fill(T value);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| T | value | The value to apply on every position |


### HexGrid.Swap() <a name="hexGridSwap"/>
Swap the values of two positions in the grid
#### Declaration
```csharp
public void Swap(AxialCoord a, AxialCoord b);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GridPosition2D | a | The first position |
| GridPosition2D | b | The second position |


### HexGrid.GetGridObjectAtAxialCoord() <a name="hexGridGetGridObjectAtAxialCoord"/>
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


### HexGrid.TryGetGridObjectAtAxialCoord() <a name="hexGridTryGetGridObjectAtAxialCoord"/>
Attempts to retrieve the object located at the specified position
#### Declaration
```csharp
public bool TryGetGridObjectAtAxialCoord(AxialCoord axialCoord, out T value);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AxialCoord | axialCoord | The position to get the element from |
| T | value | When this method returns, contains the object at the specified grid position if found, otherwise the default value for the type |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if an object exists at the specified grid position, false otherwise |


### HexGrid.GetGridObjectAtWorldPosition() <a name="hexGridGetGridObjectAtWorldPosition"/>
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


### HexGrid.TryGetGridObjectAtWorldPosition() <a name="hexGridTryGetGridObjectAtWorldPosition"/>
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


### HexGrid.GetRandomObject() <a name="hexGridGetRandomObject"/>
Get an random object from the grid
#### Declaration
```csharp
public T GetRandomObject();
```
#### Returns
| Type | Description |
| :--- | :--- |
| T | A random object from the grid |


### HexGrid.GetRandomAxialCoord() <a name="hexGridGetRandomAxialCoord"/>
Gets a random position from the grid
#### Declaration
```csharp
public AxialCoord GetRandomAxialCoord();
```
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | A random position within the grid |


### HexGrid.SetGridObjectAtAxialCoord() <a name="hexGridSetGridObjectAtAxialCoord"/>
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


### HexGrid.SetGridObjectAtWorldPosition() <a name="hexGridSetGridObjectAtWorldPosition"/>
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


### HexGrid.GetWorldPositionFromAxialCoord() <a name="hexGridGetWorldPositionFromAxialCoord"/>
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


### HexGrid.TryGetWorldPositionFromAxialCoord() <a name="hexGridTryGetWorldPositionFromAxialCoord"/>
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


### HexGrid.GetAxialCoordFromWorldPosition() <a name="hexGridGetAxialCoordFromWorldPosition"/>
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


### HexGrid.TryGetAxialCoordFromWorldPosition() <a name="hexGridTryGetAxialCoordFromWorldPosition"/>
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


### HexGrid.Any() <a name="hexGridAny"/>
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


### HexGrid.All() <a name="hexGridAll"/>
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


### HexGrid.Where() <a name="hexGridWhere"/>
Get all positions that satisfies a condition
#### Declaration
```csharp
public List<AxialCoord> Where(Func<T, bool> predicate);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Func<T, bool> | predicate | The condition to check on each position (params T: value at the position) |
#### Returns
| Type | Description |
| :--- | :--- |
| List<AxialCoord> | A list containing all the positions that satisfies the condition |


### HexGrid.IterateOverAllGridPositions() <a name="hexGridIterateOverAllGridPositions"/>
Execute an action for every position in the grid
#### Declaration
```csharp
public void IterateOverAllGridPositions(Action<AxialCoord, T> action);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Action<AxialCoord, T> | action | Action to apply on every grid position (params AxialCoord: grid position, T: value at the position) |


### HexGrid.IsWithinHexGridBounds() <a name="hexGridIsWithinHexGridBounds"/>
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


### HexGrid.IsPositionEmpty() <a name="hexGridIsPositionEmpty"/>
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


### HexGrid.GetAdjacentNeighbours() <a name="hexGridGetAdjacentNeighbours"/>
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


### HexGrid.GetDiagonalNeighbours() <a name="hexGridGetDiagonalNeighbours"/>
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


### HexGrid.GetAxialCoordsFromADistanceRange() <a name="hexGridGetAxialCoordsFromADistanceRange"/>
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


### HexGrid.GetAxialCoordsFromIntersectingRanges() <a name="hexGridGetAxialCoordsFromIntersectingRanges"/>
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


### HexGrid.GetRing() <a name="hexGridGetRing"/>
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


### HexGrid.GetSpiral() <a name="hexGridGetSpiral"/>
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


### HexGrid.GetLineWithinBounds() <a name="hexGridGetLineWithinBounds"/>
Gets all the AxialCoord that forms a straight line between two positions
#### Declaration
```csharp
public HashSet<AxialCoord> GetLineWithinBounds(AxialCoord start, AxialCoord end, bool includeStartAndEndPositions = true);
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


### HexGrid.InstantiateGameObjectAtAxialCoord() <a name="hexGridInstantiateGameObjectAtAxialCoord"/>
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


### HexGrid.InstantiateGameObjectAtWorldPosition() <a name="hexGridInstantiateGameObjectAtWorldPosition"/>
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


### HexGrid.InstantiateGameObjectAtEveryAxialCoord() <a name="hexGridInstantiateGameObjectAtEveryAxialCoord"/>
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


### HexGrid.Save() <a name="hexGridSave"/>
Save a grid as JSON string (T and its members must be a serializable type)
#### Declaration
```csharp
public static string Save<T>(HexGrid<T> grid);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| HexGrid<T> | grid | The grid to save |
#### Returns
| Type | Description |
| :--- | :--- |
| string | The grid in a JSON format |


### HexGrid.Load() <a name="hexGridLoad"/>
Load a grid from a JSON string (T and its members must be a serializable type)
#### Declaration
```csharp
public static SerializableHexGrid<T> Load(string jsonData);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | jsonData | The JSON string containing the serialized grid |
#### Returns
| Type | Description |
| :--- | :--- |
| SerializableHexGrid<T> | The loaded grid |


### 3 HexagonHexGrid() <a name="hexagonHexGridHexagonHexGrid"/>
Initializes a new instance of the HexagonHexGrid class
#### Declaration
```csharp
public HexagonHexGrid<T>(HexType hexType, int rangeFromCenter, float edgeLength, Vector3 gridOriginPosition, Func<HexagonHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);
public HexagonHexGrid<T>(HexType hexType, int rangeFromCenter, float edgeLength, Func<HexagonHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);
public HexagonHexGrid<T>(SerializableHexGrid<T> gridData)
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
| SerializableHexGrid<T> | gridData | The grid data in a serialized format |


### 4 RectangleHexGrid() <a name="rectangleHexGridRectangleHexGrid"/>
Initializes a new instance of the RectangleHexGrid class
#### Declaration
```csharp
public RectangleHexGrid<T>(HexType hexType, HexAlignment centerHexRowColumnAlignment, int leftOffset, int rightOffset, int topOffset, int bottomOffset, float edgeLength, Vector3 gridOriginPosition, Func<RectangleHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);
public RectangleHexGrid<T>(HexType hexType, HexAlignment centerHexRowColumnAlignment, int leftOffset, int rightOffset, int topOffset, int bottomOffset, float edgeLength, Func<RectangleHexGrid<T>, AxialCoord, T> gridObjectInitializer = null);
public RectangleHexGrid<T>(SerializableHexGrid<T> gridData)
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
| SerializableHexGrid<T> | gridData | The grid data in a serialized format |