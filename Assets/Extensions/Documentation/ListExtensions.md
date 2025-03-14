# List Extensions
## Table of contents
- [Documentation](#documentation)
  - [List](#listExtensions)
      - [HasIndex](#listExtensionsHasIndex)
      - [IsNullOrEmpty](#listExtensionsIsNullOrEmpty)
      - [First](#listExtensionsFirst)
      - [Last](#listExtensionsLast)
      - [RandomElement](#listExtensionsRandomElement)
      - [Minimum](#listExtensionsMinimum)
      - [Maximum](#listExtensionsMaximum)
      - [Swap](#listExtensionsSwap)
      - [RotateLeft](#listExtensionsRotateLeft)
      - [RotateRight](#listExtensionsRotateRight)
      - [RemoveNullValues](#listExtensionsRemoveNullValues)
      - [RemoveDuplicates](#listExtensionsRemoveDuplicates)
      - [Shuffle](#listExtensionsShuffle)
      - [NormalizeList](#listExtensionsNormalizeList)
      - [MapList](#listExtensionsMapList)
      - [ComplementList](#listExtensionsComplementList)
      - [InverseList](#listExtensionsInverseList)
      - [AsReadOnly](#listExtensionsAsReadOnly)

## Documentation <a name="documentation"/>
### List Extensions <a name="listExtensions"/>
#### HasIndex <a name="listExtensionsHasIndex"/>
Returns whether an index is within the bounds of a list
#### Declaration
```csharp
bool HasIndex(int index);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | index | The index value to check |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | Wheter the index is within the bounds of the array or not |


#### IsNullOrEmpty <a name="listExtensionsIsNullOrEmpty"/>
Returns whether a list is null or empty
#### Declaration
```csharp
bool IsNullOrEmpty();
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool |True, if the list is null or empty, false otherwise |


#### First <a name="listExtensionsFirst"/>
Return the first element of a list
#### Declaration
```csharp
T First();
```
#### Returns
| Type | Description |
| :--- | :--- |
| T | The first element of the list |


#### Last <a name="listExtensionsLast"/>
Return the last element of a list
#### Declaration
```csharp
T Last();
```
#### Returns
| Type | Description |
| :--- | :--- |
| T | The last element of the list |


#### RandomElement <a name="listExtensionsRandomElement"/>
Gets a random element from a list
#### Declaration
```csharp
T RandomElement();
```
#### Returns
| Type | Description |
| :--- | :--- |
| T | The random element got from the list |


#### Minimum <a name="listExtensionsMinimum"/>
Return the minimum element of a list
#### Declaration
```csharp
float Minimum();
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The minimum element of the list |


#### Maximum <a name="listExtensionsMaximum"/>
Return the maximum element of a list
#### Declaration
```csharp
float Maximum();
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The maximum element of the list |


#### Swap <a name="listExtensionsSwap"/>
Swap the value in the "firstIndex" with the one in the "secondIndex"
#### Declaration
```csharp
void Swap(int firstIndex, int secondIndex);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | firstIndex | The first index |
| int | secondIndex | The second index |


#### RotateLeft <a name="listExtensionsRotateLeft"/>
Move all items of a list "amount" spaces to the left
#### Declaration
```csharp
void RotateLeft(int amount);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | amount | Move all items of a list "amount" spaces to the left |


#### RotateRight <a name="listExtensionsRotateRight"/>
Move all items of a list "amount" spaces to the right
#### Declaration
```csharp
void RotateRight(int amount);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | amount | Move all items of a list "amount" spaces to the right |


#### RemoveNullValues <a name="listExtensionsRemoveNullValues"/>
Remove all null entries in a list
#### Declaration
```csharp
void RemoveNullValues();
```


#### RemoveDuplicates <a name="listExtensionsRemoveDuplicates"/>
Remove all duplicates in a list
#### Declaration
```csharp
void RemoveDuplicates();
```


#### Shuffle <a name="listExtensionsShuffle"/>
Shuffle a list by using Fisher-Yates
#### Declaration
```csharp
void Shuffle();
```


#### NormalizeList <a name="listExtensionsNormalizeList"/>
Normalize a list of float between the values of 0 and 1
#### Declaration
```csharp
void NormalizeList();
void NormalizeList(float min, float max);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | min | The minimum value |
| float | max | The maximum value |


#### MapList <a name="listExtensionsMapList"/>
Map a list to a new range
#### Declaration
```csharp
void MapList(float min, float max, float targetMin, float targetMax);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | min | The current minimum range |
| float | max | The current maximum range |
| float | targetMin | The new target minimum range |
| float | targetMax | The new target maximum range |


#### ComplementList <a name="listExtensionsComplementList"/>
Change all values of the list to its complement (1 - value)
#### Declaration
```csharp
void ComplementList();
```


#### InverseList <a name="listExtensionsInverseList"/>
Inverse the signal of all elements in the list
#### Declaration
```csharp
void InverseList();
```


#### AsReadOnly <a name="listExtensionsAsReadOnly"/>
Gets a read-only version of a list
#### Declaration
```csharp
IReadOnlyList<T> AsReadOnly<T>();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IReadOnlyList<T> | The read-only version of the list |