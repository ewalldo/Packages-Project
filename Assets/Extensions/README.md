# Extensions
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Using the extensions in the project](#usingTheExtensionsInTheProject)
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
  - [Color](#colorExtensions)
    - [ToHexString](#colorExtensionsToHexString)
    - [ToHexUInt](#colorExtensionsToHexUint)
  - [GameObject](#gameObjectExtensions)
    - [AddOrGetComponent](#gameObjectExtensionsAddOrGetComponent)
  - [List](#listExtensions)
    - [HasIndex](#listExtensionsHasIndex)
    - [First](#listExtensionsFirst)
    - [Last](#listExtensionsLast)
    - [RandomElement](#listExtensionsRandomElement)
    - [Minimum](#listExtensionsMinimum)
    - [Maximum](#listExtensionsMaximum)
    - [Swap](#listExtensionsSwap)
    - [RotateLeft](#listExtensionsRotateLeft)
    - [RotateRight](#listExtensionsRotateRight)
    - [RemoveNullValues](#listExtensionsRemoveNullValues)
    - [Shuffle](#listExtensionsShuffle)
    - [NormalizeList](#listExtensionsNormalizeList)
    - [MapList](#listExtensionsMapList)
    - [ComplementList](#listExtensionsComplementList)
    - [InverseList](#listExtensionsInverseList)
    - [AsReadOnly](#listExtensionsAsReadOnly)
  - [Math](#mathExtensions)
    - [InRange](#mathExtensionsInRange)
    - [Normalize](#mathExtensionsNormalize)
    - [Map](#mathExtensionsMap)
    - [Map](#mathExtensionsComplement)
    - [Inverse](#mathExtensionsInverse)
    - [Clamp](#mathExtensionsClamp)
    - [Clamp01](#mathExtensionsClamp01)
  - [Renderer](#rendererExtensions)
    - [IsVisibleFrom](#rendererExtensionsIsVisibleFrom)
  - [RichText](#richtextExtensions)
    - [WrapAround](#richTextExtensionsWrapAround)
    - [Bold](#richTextExtensionsBold)
    - [Italic](#richTextExtensionsItalic)
    - [Size](#richTextExtensionsSize)
    - [Color](#richTextExtensionsColor)
  - [Transform](#transformExtensions)
    - [FirstChild](#transformExtensionsFirstChild)
    - [LastChild](#transformExtensionsLastChild)
    - [DestroyAllChildren](#transformExtensionsDestroyAllChildren)
    - [SetActiveAllChildren](#transformExtensionsSetActiveAllChildren)
    - [SetParentAndReset](#transformExtensionsSetParentAndReset)
    - [RotateTowards](#transformExtensionsRotateTowards)
    - [DistanceTo](#transformExtensionsDistanceTo)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The "Extensions" package for Unity is a collection of extension methods that add functionality to Unity game engine and C# built-in classes. This package can help you to write cleaner and more concise code by providing useful methods for common tasks.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Extension methods for commonly used classes:
  - Array
  - Color
  - GameObject
  - List
  - Math
  - Renderer
  - RichText
  - Transform
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Using the extensions in the project <a name="usingTheExtensionsInTheProject"/>
- To use the extensions in your project, just add the "extensions" namespace on your scripts: using Extensions

## 5 - Documentation <a name="documentation"/>
### 5.1 Array Extensions <a name="arrayExtensions"/>
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


### 5.2 Color Extensions <a name="colorExtensions"/>
#### ToHexString <a name="colorExtensionsToHexString"/>
Converts a Color to a hexadecimal string representation
#### Declaration
```csharp
string ToHexString();
```
#### Returns
| Type | Description |
| :--- | :--- |
| string | The hex string representation of the color |


#### ToHexUInt <a name="colorExtensionsToHexUint"/>
Converts the Color to a hex uint representation
#### Declaration
```csharp
string ToHexUInt();
```
#### Returns
| Type | Description |
| :--- | :--- |
| uint | The uint representation of a color |


### 5.3 GameObject Extensions <a name="gameObjectExtensions"/>
#### AddOrGetComponent <a name="gameObjectExtensionsAddOrGetComponent"/>
Try to get a component from a gameObject, if it doesn't exist, add to it and return it
#### Declaration
```csharp
T AddOrGetComponent<T>();
```
#### Returns
| Type | Description |
| :--- | :--- |
| T | The component in the gameObject |



### 5.4 List Extensions <a name="listExtensions"/>
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


### 5.5 Math Extensions <a name="mathExtensions"/>
#### InRange <a name="mathExtensionsInRange"/>
Returns if the value is within the min and max values
#### Declaration
```csharp
bool InRange(int min, int max);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | min | The minimum value |
| int | max | The maximum value |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | Whether the value is within the range or not |


#### Normalize <a name="mathExtensionsNormalize"/>
Normalize a value between 0 and 1
#### Declaration
```csharp
float Normalize(float min, float max);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | min | The minimum value |
| float | max | The maximum value |
#### Returns
| Type | Description |
| :--- | :--- |
| float | The normalized value |


#### Map <a name="mathExtensionsMap"/>
Map a value to a new range
#### Declaration
```csharp
float Map(float min, float max, float targetMin, float targetMax);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | min | The current minimum range |
| float | max | The current maximum range |
| float | targetMin | The new target minimum range |
| float | targetMax | The new target maximum range |
#### Returns
| Type | Description |
| :--- | :--- |
| float | The mapped value |


#### Complement <a name="mathExtensionsComplement"/>
Return the complement of a value (1 - value)
#### Declaration
```csharp
float Complement();
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The complement of the value |


#### Inverse <a name="mathExtensionsInverse"/>
Inverse the signal of a value
#### Declaration
```csharp
float Inverse();
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The inverted value |


#### Clamp <a name="mathExtensionsClamp"/>
Clamp the value between a min and max
#### Declaration
```csharp
float Clamp(float min, float max);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | min | The minimum value |
| float | max | The maximum value |
#### Returns
| Type | Description |
| :--- | :--- |
| float | The clamped value |


#### Clamp01 <a name="mathExtensionsClamp01"/>
Clamp the value between 0 and 1
#### Declaration
```csharp
float Clamp01();
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The clamped value |


### 5.6 Renderer Extensions <a name="rendererExtensions"/>
#### IsVisibleFrom <a name="rendererExtensionsIsVisibleFrom"/>
Checks if a Renderer is visible from a specified camera
#### Declaration
```csharp
bool IsVisibleFrom(Camera camera);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Camera | camera | The camera to check the visibility from |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | Whether the renderer is visible from the camera or not |


### 5.7 RichText Extensions <a name="richTextExtensions"/>
#### WrapAround <a name="richTextExtensionsWrapAround"/>
Wraps a start and end string around another one
#### Declaration
```csharp
string WrapAround(string startElement, string endElement);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | startElement | The start string |
| string | endElement | The final string |
#### Returns
| Type | Description |
| :--- | :--- |
| string | The string with the start and end element wrapped around it |


#### Bold <a name="richTextExtensionsBold"/>
Renders the text in bold
#### Declaration
```csharp
string Bold();
```
#### Returns
| Type | Description |
| :--- | :--- |
| string | The bolded text representation |


#### Italic <a name="richTextExtensionsItalic"/>
Renders the text in italic
#### Declaration
```csharp
string Italic();
```
#### Returns
| Type | Description |
| :--- | :--- |
| string | The italic text representation |


#### Size <a name="richTextExtensionsSize"/>
Change the render size of the text
#### Declaration
```csharp
string Size(int size);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | size | The size for the text, given in pixels |
#### Returns
| Type | Description |
| :--- | :--- |
| string | The resized text |


#### Color <a name="richTextExtensionsColor"/>
Change the render color of the text
#### Declaration
```csharp
string Color(Color color);
string Color(uint hexColor);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Color | color | The color to apply to the text |
| uint | hexColor | The color to apply to the text in hex value representation |
#### Returns
| Type | Description |
| :--- | :--- |
| string | The text with the color applied |


### 5.8 Transform Extensions <a name="transformExtensions"/>
#### FirstChild <a name="transformExtensionsFirstChild"/>
Returns the first child transform of a gameObject, returns null if there is no children
#### Declaration
```csharp
transform FirstChild();
```
#### Returns
| Type | Description |
| :--- | :--- |
| Transform | The first child |


#### LastChild <a name="transformExtensionsLastChild"/>
Returns the last child transform of a gameObject, returns null if there is no children
#### Declaration
```csharp
transform LastChild();
```
#### Returns
| Type | Description |
| :--- | :--- |
| Transform | The last child |


#### DestroyAllChildren <a name="transformExtensionsDestroyAllChildren"/>
Destroy all children of a transform
#### Declaration
```csharp
void DestroyAllChildren();
```


#### SetActiveAllChildren <a name="transformExtensionsSetActiveAllChildren"/>
Activate/deactivate all children of a transform
#### Declaration
```csharp
void SetActiveAllChildren(bool status);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| bool | status | True activate all the children, false deactivate all of them |


#### SetParentAndReset <a name="transformExtensionsSetParentAndReset"/>
Set the object to a new parent and reset the transform values
#### Declaration
```csharp
void SetParentAndReset(Transform parent, bool resetPosition = true, bool resetRotation = true, bool resetScale = true);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | parent | The parent to be attached to |
| bool | resetPosition | Should reset the position? |
| bool | resetRotation | Should reset the rotation? |
| bool | resetScale | Should reset the scale? |


#### RotateTowards <a name="transformExtensionsRotateTowards"/>
Rotate the transform towards a target
#### Declaration
```csharp
void RotateTowards(Vector3 target, float speed);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | target | The target value to be rotated towards |
| float | speed | The speed of the rotation |


#### DistanceTo <a name="transformExtensionsDistanceTo"/>
Calculates the distance of this transform in relation to another one
#### Declaration
```csharp
float DistanceTo(Transform other);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | other | The transform end point |
#### Returns
| Type | Description |
| :--- | :--- |
| float | The distance between the two transforms |

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com