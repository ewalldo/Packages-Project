# Array Extensions
## Table of contents
- [Documentation](#documentation)
  - [Array](#arrayExtensions)
    - [HasIndex](#arrayExtensionsHasIndex)
    - [First](#arrayExtensionsFirst)
    - [Last](#arrayExtensionsLast)
    - [Minimum](#arrayExtensionsMinimum)
    - [Maximum](#arrayExtensionsMaximum)
    - [Swap](#arrayExtensionsSwap)
    - [Shuffle](#arrayExtensionsShuffle)
    - [Normalize](#arrayExtensionsNormalize)
    - [MapArray](#arrayExtensionsMapArray)
    - [ComplementArray](#arrayExtensionsComplementArray)
    - [InverseArray](#arrayExtensionsInverseArray)

## Documentation <a name="documentation"/>
### Array Extensions <a name="arrayExtensions"/>
#### HasIndex <a name="arrayExtensionsHasIndex"/>
Returns whether an index is within the bounds of an array
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


#### First <a name="arrayExtensionsFirst"/>
Return the first element of an array
#### Declaration
```csharp
T First();
```
#### Returns
| Type | Description |
| :--- | :--- |
| T | The first element of the array |


#### Last <a name="arrayExtensionsLast"/>
Return the last element of an array
#### Declaration
```csharp
T Last();
```
#### Returns
| Type | Description |
| :--- | :--- |
| T | The last element of the array |

#### Minimum <a name="arrayExtensionsMinimum"/>
Return the minimum element of an array
#### Declaration
```csharp
float Minimum();
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The minimum element of the array |


#### Maximum <a name="arrayExtensionsMaximum"/>
Return the maximum element of an array
#### Declaration
```csharp
float Maximum();
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The maximum element of the array |


#### Swap <a name="arrayExtensionsSwap"/>
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


#### Shuffle <a name="arrayExtensionsShuffle"/>
Shuffle an array by using Fisher-Yates
#### Declaration
```csharp
void Shuffle();
```


#### Normalize <a name="arrayExtensionsNormalize"/>
Normalize an array of float between the values of 0 and 1
#### Declaration
```csharp
void NormalizeArray();
void NormalizeArray(float min, float max);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | min | The minimum value |
| float | max | The maximum value |


#### MapArray <a name="arrayExtensionsMapArray"/>
Map an array to a new range
#### Declaration
```csharp
void MapArray(float min, float max, float targetMin, float targetMax);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | min | The current minimum range |
| float | max | The current maximum range |
| float | targetMin | The new target minimum range |
| float | targetMax | The new target maximum range |


#### ComplementArray <a name="arrayExtensionsComplementArray"/>
Change all values of the array to its complement (1 - value)
#### Declaration
```csharp
void ComplementArray();
```


#### InverseArray <a name="arrayExtensionsInverseArray"/>
Inverse the signal of all elements in the array
#### Declaration
```csharp
void InverseArray();
```