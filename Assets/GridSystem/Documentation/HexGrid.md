# HexGrid
## Table of contents
- [Documentation](#documentation)
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

## Documentation <a name="documentation"/>
### 1.1 AxialCoord() <a name="axialCoordAxialCoord"/>
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


### 1.2 AxialCoord.Neighbours <a name="axialCoordNeighbours"/>
Get all the neighbour positions from this AxialCoord
#### Declaration
```csharp
public List<AxialCoord> Neighbours;
```
#### Returns
| Type | Description |
| :--- | :--- |
| List<AxialCoord> | The neighbours of this AxialCoord |


### 1.3 AxialCoord.GetNeighbour() <a name="axialCoordGetNeighbour"/>
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


### 1.4 AxialCoord.Diagonals <a name="axialCoordDiagonals"/>
Get all the diagonal positions from this AxialCoord
#### Declaration
```csharp
public List<AxialCoord> Diagonals;
```
#### Returns
| Type | Description |
| :--- | :--- |
| List<AxialCoord> | The diagonals of this AxialCoord |


### 1.5 AxialCoord.GetDiagonal() <a name="axialCoordGetDiagonal"/>
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


### 1.6.1 AxialCoord.DistanceFrom() <a name="axialCoordDistanceFrom"/>
### 1.6.2 AxialCoord.Distance() <a name="axialCoordDistance"/>
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


### 1.7 AxialCoord.GetAxialCoordsWithinRange() <a name="axialCoordGetAxialCoordsWithinRange"/>
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


### 1.8 AxialCoord.ReflectQ <a name="axialCoordReflectQ"/>
Get the AxialCoord position when reflecting through the Q-axis
#### Declaration
```csharp
public AxialCoord ReflectQ;
```
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The position when reflecting through the Q-axis |


### 1.9 AxialCoord.ReflectR <a name="axialCoordReflectR"/>
Get the AxialCoord position when reflecting through the R-axis
#### Declaration
```csharp
public AxialCoord ReflectR;
```
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The position when reflecting through the R-axis |


### 1.10 AxialCoord.ReflectS <a name="axialCoordReflectS"/>
Get the AxialCoord position when reflecting through the S-axis
#### Declaration
```csharp
public AxialCoord ReflectS;
```
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | The position when reflecting through the S-axis |


### 1.11 AxialCoord.Length() <a name="axialCoordLength"/>
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


### 2.1 HexGrid() <a name="hexGridHexGrid"/>
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


### 2.2 HexGrid.GetEdgeLength <a name="hexGridGetEdgeLength"/>
Get the edge length of the hex cell's of this grid
#### Declaration
```csharp
public float GetEdgeLength;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The edge lenght of a hex cell |


### 2.3 HexGrid.GetGridOriginPosition <a name="hexGridGetGridOriginPosition"/>
Get the origin position of the grid
#### Declaration
```csharp
public Vector3 GetGridOriginPosition;
```
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | The grid origin position |


### 2.4 HexGrid.OnGridPositionValueChanged <a name="hexGridOnGridPositionValueChanged"/>
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


### 2.5 HexGrid.Indexers <a name="hexGridIndexers"/>
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


### 2.6 HexGrid.GetGridObjects() <a name="hexGridGetGridObjects"/>
Returns the elements of the grid
#### Declaration
```csharp
public IEnumerable<T> GetGridObjects();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<T> | Element of the grid |


### 2.7 HexGrid.GetGridAxialCoords() <a name="hexGridGetGridAxialCoords"/>
Returns the AxialCoords of this grid
#### Declaration
```csharp
public IEnumerable<AxialCoord> GetGridAxialCoords();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<AxialCoord> | AxialCoord of the grid |


### 2.8 HexGrid.ClearGrid() <a name="hexGridClearGrid"/>
Clear the grid and reset all the positions to their default values
#### Declaration
```csharp
public void ClearGrid();
```


### 2.9 HexGrid.Fill() <a name="hexGridFill"/>
Fill all the positions in the grid with the specific value
#### Declaration
```csharp
public void Fill(T value);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| T | value | The value to apply on every position |


### 2.10 HexGrid.GetGridObjectAtAxialCoord() <a name="hexGridGetGridObjectAtAxialCoord"/>
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


### 2.11 HexGrid.GetGridObjectAtWorldPosition() <a name="hexGridGetGridObjectAtWorldPosition"/>
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


### 2.12 HexGrid.GetRandomObject() <a name="hexGridGetRandomObject"/>
Get an random object from the grid
#### Declaration
```csharp
public T GetRandomObject();
```
#### Returns
| Type | Description |
| :--- | :--- |
| T | A random object from the grid |


### 2.13 HexGrid.GetRandomAxialCoord() <a name="hexGridGetRandomAxialCoord"/>
Gets a random position from the grid
#### Declaration
```csharp
public AxialCoord GetRandomAxialCoord();
```
#### Returns
| Type | Description |
| :--- | :--- |
| AxialCoord | A random position within the grid |


### 2.14 HexGrid.SetGridObjectAtAxialCoord() <a name="hexGridSetGridObjectAtAxialCoord"/>
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


### 2.15 HexGrid.SetGridObjectAtWorldPosition() <a name="hexGridSetGridObjectAtWorldPosition"/>
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


### 2.16 HexGrid.GetWorldPositionFromAxialCoord() <a name="hexGridGetWorldPositionFromAxialCoord"/>
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


### 2.17 HexGrid.TryGetWorldPositionFromAxialCoord() <a name="hexGridTryGetWorldPositionFromAxialCoord"/>
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


### 2.18 HexGrid.GetAxialCoordFromWorldPosition() <a name="hexGridGetAxialCoordFromWorldPosition"/>
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


### 2.19 HexGrid.TryGetAxialCoordFromWorldPosition() <a name="hexGridTryGetAxialCoordFromWorldPosition"/>
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


### 2.20 HexGrid.GetGridPositionsInACertainState() <a name="hexGridGetGridPositionsInACertainState"/>
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


### 2.21 HexGrid.IterateOverAllGridPositions() <a name="hexGridIterateOverAllGridPositions"/>
Execute an action for every position in the grid
#### Declaration
```csharp
public void IterateOverAllGridPositions(Action<AxialCoord, T> action);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Action<AxialCoord, T> | action | Action to apply on every grid position (params AxialCoord: grid position, T: value at the position) |


### 2.22 HexGrid.IsWithinHexGridBounds() <a name="hexGridIsWithinHexGridBounds"/>
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


### 2.23 HexGrid.IsPositionEmpty() <a name="hexGridIsPositionEmpty"/>
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


### 2.24 HexGrid.GetAdjacentNeighbours() <a name="hexGridGetAdjacentNeighbours"/>
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


### 2.25 HexGrid.GetDiagonalNeighbours() <a name="hexGridGetDiagonalNeighbours"/>
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


### 2.26 HexGrid.GetAxialCoordsFromADistanceRange() <a name="hexGridGetAxialCoordsFromADistanceRange"/>
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


### 2.27 HexGrid.GetAxialCoordsFromIntersectingRanges() <a name="hexGridGetAxialCoordsFromIntersectingRanges"/>
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


### 2.28 HexGrid.GetRing() <a name="hexGridGetRing"/>
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


### 2.29 HexGrid.GetSpiral() <a name="hexGridGetSpiral"/>
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


### 2.30 HexGrid.InstantiateGameObjectAtAxialCoord() <a name="hexGridInstantiateGameObjectAtAxialCoord"/>
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


### 2.31 HexGrid.InstantiateGameObjectAtWorldPosition() <a name="hexGridInstantiateGameObjectAtWorldPosition"/>
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


### 2.32 HexGrid.InstantiateGameObjectAtEveryAxialCoord() <a name="hexGridInstantiateGameObjectAtEveryAxialCoord"/>
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


### 2.33 HexGrid.Save() <a name="hexGridSave"/>
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


### 2.34 HexGrid.Load() <a name="hexGridLoad"/>
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


### 2.35 HexGrid.GetLine() <a name="hexGridGetLine"/>
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


### 3.1 HexagonHexGrid() <a name="hexagonHexGridHexagonHexGrid"/>
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


### 4.1 RectangleHexGrid() <a name="rectangleHexGridRectangleHexGrid"/>
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