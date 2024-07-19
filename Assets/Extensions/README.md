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
  - [AudioSource](#audioSourceExtensions)
    - [FadeOut](#audioSourceExtensionsFadeOut)
    - [FadeOutAsync](#audioSourceExtensionsFadeOutAsync)
    - [FadeIn](#audioSourceExtensionsFadeIn)
    - [FadeInAsync](#audioSourceExtensionsFadeInAsync)
    - [CrossFade](#audioSourceExtensionsCrossFade)
    - [CrossFadeAsync](#audioSourceExtensionsCrossFadeAsync)
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
    - [MapUnclamped](#mathExtensionsMapUnclamped)
    - [MapClamped](#mathExtensionsMapClamped)
    - [Complement](#mathExtensionsComplement)
    - [Inverse](#mathExtensionsInverse)
    - [Clamp](#mathExtensionsClamp)
    - [Clamp01](#mathExtensionsClamp01)
    - [GetBiasedRandomNumber](#mathExtensionsGetBiasedRandomNumber)
  - [Renderer](#rendererExtensions)
    - [IsVisibleFrom](#rendererExtensionsIsVisibleFrom)
  - [RichText](#richtextExtensions)
    - [WrapAround](#richTextExtensionsWrapAround)
    - [Bold](#richTextExtensionsBold)
    - [Italic](#richTextExtensionsItalic)
    - [Size](#richTextExtensionsSize)
    - [Color](#richTextExtensionsColor)
  - [String](#stringExtensions)
    - [ToVector](#stringExtensionsToVector)
    - [ToColor](#stringExtensionsToColor)
  - [TMPro](#tmproExtensions)
    - [ResizeRectTransformToMatchText](#tmproExtensionsResizeRectTransformToMatchText)
  - [Transform](#transformExtensions)
    - [FirstChild](#transformExtensionsFirstChild)
    - [LastChild](#transformExtensionsLastChild)
    - [DestroyAllChildren](#transformExtensionsDestroyAllChildren)
    - [SetActiveAllChildren](#transformExtensionsSetActiveAllChildren)
    - [ResetTransform](#transformExtensionsResetTransform)
    - [SetParentAndReset](#transformExtensionsSetParentAndReset)
    - [RotateTowards](#transformExtensionsRotateTowards)
    - [DistanceTo](#transformExtensionsDistanceTo)
    - [IsAllCornersVisible](#transformExtensionsIsAllCornersVisible)
    - [IsAtLeastOneCornerVisible](#transformExtensionsIsAtLeastOneCornerVisible)
  - [Vector](#vectorExtensions)
    - [Vector2:With](#vectorExtensionsVector2With)
    - [Vector2:WithX](#vectorExtensionsVector2WithX)
    - [Vector2:WithY](#vectorExtensionsVector2WithY)
    - [Vector3:With](#vectorExtensionsVector3With)
    - [Vector3:WithX](#vectorExtensionsVector3WithX)
    - [Vector3:WithY](#vectorExtensionsVector3WithY)
    - [Vector3:WithZ](#vectorExtensionsVector3WithZ)
    - [Vector3:WithXY](#vectorExtensionsVector3WithXY)
    - [Vector3:WithXZ](#vectorExtensionsVector3WithXZ)
    - [Vector3:WithYZ](#vectorExtensionsVector3WithYZ)
    - [Vector4:With](#vectorExtensionsVector4With)
    - [Vector4:WithX](#vectorExtensionsVector4WithX)
    - [Vector4:WithY](#vectorExtensionsVector4WithY)
    - [Vector4:WithZ](#vectorExtensionsVector4WithZ)
    - [Vector4:WithW](#vectorExtensionsVector4WithW)
    - [Vector4:WithXY](#vectorExtensionsVector4WithXY)
    - [Vector4:WithXZ](#vectorExtensionsVector4WithXZ)
    - [Vector4:WithXW](#vectorExtensionsVector4WithXW)
    - [Vector4:WithYZ](#vectorExtensionsVector4WithYZ)
    - [Vector4:WithYW](#vectorExtensionsVector4WithYW)
    - [Vector4:WithZW](#vectorExtensionsVector4WithZW)
    - [Vector4:WithXYZ](#vectorExtensionsVector4WithXYZ)
    - [Vector4:WithXYW](#vectorExtensionsVector4WithXYW)
    - [Vector4:WithXZW](#vectorExtensionsVector4WithXZW)
    - [Vector4:WithYZW](#vectorExtensionsVector4WithYZW)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The "Extensions" package for Unity is a collection of utility extensions designed to streamline common tasks and enhance the functionality of various Unity and C# classes. With these extensions, developers can optimize their workflow, write cleaner code, and improve overall productivity. This documentation provides an overview of the extensions included in the package and instructions for their usage.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release
- 1.1: Add extension methods to the AudioSource class and Vector2/3/4 structs plus a few methods to the other extensions
- 1.2: Add extension methods to the TMPro and string classes plus a few methods to the other extensions

## 3 - Features <a name="features"/>
- Extension methods for commonly used classes:
  - Array
  - AudioSource
  - Color
  - GameObject
  - List
  - Math
  - Renderer
  - RichText
  - String
  - TMPro
  - Transform
  - Vector
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Using the extensions in the project <a name="usingTheExtensionsInTheProject"/>
- To use the extensions in your project, just add the "extensions" namespace on your scripts: using Extensions
- You can then call the extension methods directly on instances of the corresponding classes. For example:
```csharp
// Shuffle an array
int[] numbers = { 1, 2, 3, 4, 5 };
numbers.Shuffle();

// Reset the transform of a GameObject
transform.ResetTransform();
```

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


### 5.2 AudioSource Extensions <a name="audioSourceExtensions"/>
#### FadeOut <a name="audioSourceExtensionsFadeOut"/>
Fades out the audio of the audioSource over a specified duration
#### Declaration
```csharp
IEnumerator FadeOut(float fadeOutTime, float startVolume = 1f, float finalVolume = 0f, bool resetVolumeAfterFade = false, Action onFinishedFading = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | fadeOutTime | The duration over which the fade out should occur |
| float | startVolume | The starting volume level of the audio (between 0 and 1) |
| float | finalVolume | The final volume level of the audio (between 0 and 1) |
| bool | resetVolumeAfterEnds | Indicates wheter to reset the volume to its starting value after the fade operation |
| Action | onFinishedFading | Action to invoke when the fade out is finished |
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerator | An IEnumerator for the fade out coroutine execution |


#### FadeOutAsync <a name="audioSourceExtensionsFadeOutAsync"/>
Fades out the audio of the audioSource over a specified duration
#### Declaration
```csharp
Task FadeOutAsync(float fadeOutTime, CancellationToken cancellationToken, float startVolume = 1f, float finalVolume = 0f, bool resetVolumeAfterFade = false, Action onFinishedFading = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | fadeOutTime | The duration over which the fade out should occur |
| CancellationToken | cancellationToken | Cancellation token to safely stop the fade out operation midway through |
| float | startVolume | The starting volume level of the audio (between 0 and 1) |
| float | finalVolume | The final volume level of the audio (between 0 and 1) |
| bool | resetVolumeAfterEnds | Indicates wheter to reset the volume to its starting value after the fade operation |
| Action | onFinishedFading | Action to invoke when the fade out is finished |
#### Returns
| Type | Description |
| :--- | :--- |
| Task | An asynchronous task for the fade out operation |


#### FadeIn <a name="audioSourceExtensionsFadeIn"/>
Fades in the audio of the audioSource over a specified duration
#### Declaration
```csharp
IEnumerator FadeIn(float fadeInTime, float startVolume = 0f, float finalVolume = 1f, Action onFinishedFading = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | fadeInTime | The duration over which the fade in should occur |
| float | startVolume | The starting volume level of the audio (between 0 and 1) |
| float | finalVolume | The final volume level of the audio (between 0 and 1) |
| Action | onFinishedFading | Action to invoke when the fade in is finished |
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerator | An IEnumerator for the fade in coroutine execution |


#### FadeInAsync <a name="audioSourceExtensionsFadeInAsync"/>
Fades in the audio of the audioSource over a specified duration
#### Declaration
```csharp
Task FadeInAsync(float fadeInTime, CancellationToken cancellationToken, float startVolume = 0f, float finalVolume = 1f, Action onFinishedFading = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | fadeInTime | The duration over which the fade in should occur |
| CancellationToken | cancellationToken | Cancellation token to safely stop the fade in operation midway through |
| float | startVolume | The starting volume level of the audio (between 0 and 1) |
| float | finalVolume | The final volume level of the audio (between 0 and 1) |
| Action | onFinishedFading | Action to invoke when the fade in is finished |
#### Returns
| Type | Description |
| :--- | :--- |
| Task | An asynchronous task for the fade in operation |


#### CrossFade <a name="audioSourceExtensionsCrossFade"/>
Cross fade the audio of the audioSource to audioSourceIn over a specific duration
#### Declaration
```csharp
IEnumerator CrossFade(AudioSource audioSourceIn, float crossFadeTime, float startVolume = 1f, float finalVolume = 1f, Action onFinishedCrossFading = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AudioSource | audioSourceIn | The audio source to fade in |
| float | crossFadeTime | The duration over which the cross fade should occur |
| float | startVolume | The starting volume level of the audio to fade out (between 0 and 1) |
| float | finalVolume | The final volume level of the audio to fade in (between 0 and 1) |
| Action | onFinishedFading | Action to invoke when the cross fade is finished |
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerator | An IEnumerator for the cross fade coroutine execution |


#### CrossFadeAsync <a name="audioSourceExtensionsCrossFadeAsync"/>
Cross fade the audio of the audioSource to audioSourceIn over a specific duration
#### Declaration
```csharp
Task CrossFadeAsync(AudioSource audioSourceIn, float crossFadeTime, CancellationToken cancellationToken, float startVolume = 1f, float finalVolume = 1f, Action onFinishedCrossFading = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AudioSource | audioSourceIn | The audio source to fade in |
| float | crossFadeTime | The duration over which the cross fade should occur |
| CancellationToken | cancellationToken | Cancellation token to safely stop the cross fade operation midway through |
| float | startVolume | The starting volume level of the audio to fade out (between 0 and 1) |
| float | finalVolume | The final volume level of the audio to fade in (between 0 and 1) |
| Action | onFinishedFading | Action to invoke when the cross fade is finished |
#### Returns
| Type | Description |
| :--- | :--- |
| Task | An asynchronous task for the cross fade operation |


### 5.3 Color Extensions <a name="colorExtensions"/>
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


### 5.4 GameObject Extensions <a name="gameObjectExtensions"/>
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



### 5.5 List Extensions <a name="listExtensions"/>
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


### 5.6 Math Extensions <a name="mathExtensions"/>
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
Map a value currently in the (min, max) range to a range between (targetMin, targetMax)
#### Declaration
```csharp
float Map(float min, float max, float newMin, float newMax);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | min | The current minimum value of the range |
| float | max | The current maximum value of the range |
| float | newMin | The minimum value of the new range |
| float | newMax | The maximum value of the new range |
#### Returns
| Type | Description |
| :--- | :--- |
| float | The mapped value |


#### MapUnclamped <a name="mathExtensionsMapUnclamped"/>
Map a value currently in the (min, max) range to a range between (newMin, newMax) without clamping it.
#### Declaration
```csharp
float MapUnclamped(float min, float max, float newMin, float newMax);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | min | The current minimum value of the range |
| float | max | The current maximum value of the range |
| float | newMin | The minimum value of the new range |
| float | newMax | The maximum value of the new range |
#### Returns
| Type | Description |
| :--- | :--- |
| float | The mapped value |


#### MapClamped <a name="mathExtensionsMapClamped"/>
Map a value currently in the (min, max) range to a range between (newMin, newMax) and clamp it between (newMin, newMax).
#### Declaration
```csharp
float MapClamped(float min, float max, float newMin, float newMax);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | min | The current minimum value of the range |
| float | max | The current maximum value of the range |
| float | newMin | The minimum value of the new range |
| float | newMax | The maximum value of the new range |
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


#### GetBiasedRandomNumber <a name="mathExtensionsGetBiasedRandomNumber"/>
Get a random number between min and max (both inclusive) where the probability of said number is biased towards the lower or higher end of the range
#### Declaration
```csharp
int GetBiasedRandomNumber(int min, int max, double power = 1);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | min | The mininum possible value for the random number |
| int | max | The maximum possible value for the random number |
| double | power | The probability distribution of the generated number.<br/> A value lower than 1 will result in a higher likelihood of larger numbers being generated. The closer to 0, the bigger the chance of a large number.<br/> A value higher than 1 will result in a higher likelihood of smaller numbers being generated. The higher the number, the bigger the chance of a smaller number.<br/> A value equals to 1 will result in a uniform distribution, where all values are equallly likely to occur |
#### Returns
| Type | Description |
| :--- | :--- |
| int | The generated random number |


### 5.7 Renderer Extensions <a name="rendererExtensions"/>
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


### 5.8 RichText Extensions <a name="richTextExtensions"/>
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


### 5.9 String Extensions <a name="stringExtensions"/>
#### ToVector <a name="stringExtensionsToVector"/>
Converts a string representation to a Vector
#### Declaration
```csharp
T ToVector<T>() where T : struct;
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| T | --- | The type of Vector to convert to (2, 2Int, 3, 3Int, 4) |
#### Returns
| Type | Description |
| :--- | :--- |
| T | The Vector representation of the string |


#### ToColor <a name="stringExtensionsToColor"/>
Converts a string representation (in RGBA color format "RGBA(r, g, b, a)" or RGB color format "RGB(r, g, b)) to a Color
#### Declaration
```csharp
Color ToColor();
```
#### Returns
| Type | Description |
| :--- | :--- |
| Color | The Color representation of the string |


### 5.10 TMPro Extensions <a name="tmproExtensions"/>
#### ResizeRectTransformToMatchText <a name="tmproExtensionsResizeRectTransformToMatchText"/>
Resize the rectTransform of the TMP_Text to match the text size
#### Declaration
```csharp
void ResizeRectTransformToMatchText(bool shouldResizeHorizontal, bool shouldResizeVertical, Vector2 minSize, Vector2 maxSize, Vector2 padding);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| bool | shouldResizeHorizontal | Should resize the rectTransform horizontally? |
| bool | shouldResizeVertical | Should resize the rectTransform vertically? |
| Vector2 | minSize | The minimum size of the rectTransform |
| Vector2 | maxSize | The maximum size of the rectTransform |
| Vector2 | padding | Amount of padding to be added to the rectTransform |


### 5.11 Transform Extensions <a name="transformExtensions"/>
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


#### ResetTransform <a name="transformExtensionsResetTransform"/>
Reset the transform to its default values
#### Declaration
```csharp
void ResetTransform(bool isLocal = true, bool resetPosition = true, bool resetRotation = true, bool resetScale = true);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| bool | isLocal | True if the local values should be reset, false if the global ones |
| bool | resetPosition | Should reset the position? |
| bool | resetRotation | Should reset the rotation? |
| bool | resetScale | Should reset the scale? |


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
Calculates the distance of this transform in relation to another one or a point in space
#### Declaration
```csharp
float DistanceTo(Transform other, bool useLocalPosition = false);
float DistanceTo(Vector3 other, bool useLocalPosition = false);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | other | The transform end point |
| Vector3 | other | The position end point |
| bool | useLocalPosition | If the distance should be calculated using the local position or the global one |
#### Returns
| Type | Description |
| :--- | :--- |
| float | The distance between the two transforms or the ditance between the transform and the point |


#### IsAllCornersVisible <a name="transformExtensionsIsAllCornersVisible"/>
Checks if all corners of a rectTransform are visible on the screen
#### Declaration
```csharp
bool IsAllCornersVisible(Canvas canvas);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Canvas | canvas | The parent canvas of the rect transform |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True, if all four corners are on the screen, false otherwise |


#### IsAtLeastOneCornerVisible <a name="transformExtensionsIsAtLeastOneCornerVisible"/>
Check if at least one corner of a rectTransform is visible on the screen
#### Declaration
```csharp
bool IsAtLeastOneCornerVisible(Canvas canvas);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Canvas | canvas | The parent canvas of the rect transform |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True, if at least one corner is on the screen, false otherwise |


### 5.12 Vector Extensions <a name="vectorExtensions"/>
#### Vector2:With <a name="vectorExtensionsVector2With"/>
Returns a new Vector2 with the specified components replaced
#### Declaration
```csharp
Vector2 With(float? x = null, float? y = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float? | x | Optional X component. If null, the original X component is used |
| float? | y | Optional Y component. If null, the original Y component is used |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector2 | A new Vector2 with the specified components replaced |


#### Vector2:WithX <a name="vectorExtensionsVector2WithX"/>
Returns a new Vector2 with the X component replaced
#### Declaration
```csharp
Vector2 WithX(float x);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | x | The new X component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector2 | A new Vector2 with the X component replaced |


#### Vector2:WithY <a name="vectorExtensionsVector2WithY"/>
Returns a new Vector2 with the Y component replaced
#### Declaration
```csharp
Vector2 WithY(float y);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | y | The new Y component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector2 | A new Vector2 with the Y component replaced |


#### Vector3:With <a name="vectorExtensionsVector3With"/>
Returns a new Vector3 with the specified components replaced
#### Declaration
```csharp
Vector3 With(float? x = null, float? y = null, float? z = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float? | x | Optional X component. If null, the original X component is used |
| float? | y | Optional Y component. If null, the original Y component is used |
| float? | z | Optional Z component. If null, the original Z component is used |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | A new Vector3 with the specified components replaced |


#### Vector3:WithX <a name="vectorExtensionsVector3WithX"/>
Returns a new Vector3 with the X component replaced
#### Declaration
```csharp
Vector3 WithX(float x);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | x | The new X component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | A new Vector3 with the X component replaced |


#### Vector3:WithY <a name="vectorExtensionsVector3WithY"/>
Returns a new Vector3 with the Y component replaced
#### Declaration
```csharp
Vector3 WithY(float y);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | y | The new Y component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | A new Vector3 with the Y component replaced |


#### Vector3:WithZ <a name="vectorExtensionsVector3WithZ"/>
Returns a new Vector3 with the Z component replaced
#### Declaration
```csharp
Vector3 WithZ(float z);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | z | The new Z component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | A new Vector3 with the Z component replaced |


#### Vector3:WithXY <a name="vectorExtensionsVector3WithXY"/>
Returns a new Vector3 with the X and Y components replaced
#### Declaration
```csharp
Vector3 WithXY(float x, float y);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | x | The new X component |
| float | y | The new y component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | A new Vector3 with the X and Y components replaced |


#### Vector3:WithXZ <a name="vectorExtensionsVector3WithXZ"/>
Returns a new Vector3 with the X and Z components replaced
#### Declaration
```csharp
Vector3 WithXZ(float x, float z);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | x | The new X component |
| float | z | The new z component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | A new Vector3 with the X and Z components replaced |


#### Vector3:WithYZ <a name="vectorExtensionsVector3WithYZ"/>
Returns a new Vector3 with the Y and Z components replaced
#### Declaration
```csharp
Vector3 WithXZ(float y, float z);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | y | The new Y component |
| float | z | The new z component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | A new Vector3 with the Y and Z components replaced |


#### Vector4:With <a name="vectorExtensionsVector4With"/>
Returns a new Vector4 with the specified components replaced
#### Declaration
```csharp
Vector4 With(float? x = null, float? y = null, float? z = null, float? w = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float? | x | Optional X component. If null, the original X component is used |
| float? | y | Optional Y component. If null, the original Y component is used |
| float? | z | Optional Z component. If null, the original Z component is used |
| float? | w | Optional W component. If null, the original W component is used |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the specified components replaced |


#### Vector4:WithX <a name="vectorExtensionsVector4WithX"/>
Returns a new Vector4 with the X component replaced
#### Declaration
```csharp
Vector4 WithX(float x);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | x | The new X component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the X component replaced |


#### Vector4:WithY <a name="vectorExtensionsVector4WithY"/>
Returns a new Vector4 with the Y component replaced
#### Declaration
```csharp
Vector4 WithY(float y);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | y | The new Y component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the Y component replaced |


#### Vector4:WithZ <a name="vectorExtensionsVector4WithZ"/>
Returns a new Vector4 with the Z component replaced
#### Declaration
```csharp
Vector4 WithZ(float z);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | z | The new Z component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the Z component replaced |


#### Vector4:WithW <a name="vectorExtensionsVector4WithW"/>
Returns a new Vector4 with the W component replaced
#### Declaration
```csharp
Vector4 WithW(float w);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | w | The new W component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the W component replaced |


#### Vector4:WithXY <a name="vectorExtensionsVector4WithXY"/>
Returns a new Vector4 with the X and Y components replaced
#### Declaration
```csharp
Vector4 WithXY(float x, float y);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | x | The new X component |
| float | y | The new Y component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the X and Y components replaced |


#### Vector4:WithXZ <a name="vectorExtensionsVector4WithXZ"/>
Returns a new Vector4 with the X and Z components replaced
#### Declaration
```csharp
Vector4 WithXZ(float x, float z);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | x | The new X component |
| float | z | The new Z component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the X and Z components replaced |


#### Vector4:WithXW <a name="vectorExtensionsVector4WithXW"/>
Returns a new Vector4 with the X and W components replaced
#### Declaration
```csharp
Vector4 WithXW(float x, float w);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | x | The new X component |
| float | w | The new W component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the X and W components replaced |


#### Vector4:WithYZ <a name="vectorExtensionsVector4WithYZ"/>
Returns a new Vector4 with the Y and Z components replaced
#### Declaration
```csharp
Vector4 WithYZ(float y, float z);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | y | The new Y component |
| float | z | The new Z component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the Y and Z components replaced |


#### Vector4:WithYW <a name="vectorExtensionsVector4WithYW"/>
Returns a new Vector4 with the Y and W components replaced
#### Declaration
```csharp
Vector4 WithYZ(float y, float w);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | y | The new Y component |
| float | w | The new W component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the Y and W components replaced |


#### Vector4:WithZW <a name="vectorExtensionsVector4WithZW"/>
Returns a new Vector4 with the Z and W components replaced
#### Declaration
```csharp
Vector4 WithZZ(float z, float w);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | z | The new Z component |
| float | w | The new W component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the Z and W components replaced |


#### Vector4:WithXYZ <a name="vectorExtensionsVector4WithXYZ"/>
Returns a new Vector4 with the X, Y and Z components replaced
#### Declaration
```csharp
Vector4 WithXYZ(float x, float y, float z);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | x | The new X component |
| float | y | The new Y component |
| float | z | The new Z component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the X, Y and Z components replaced |


#### Vector4:WithXYW <a name="vectorExtensionsVector4WithXYW"/>
Returns a new Vector4 with the X, Y and W components replaced
#### Declaration
```csharp
Vector4 WithXYW(float x, float y, float w);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | x | The new X component |
| float | y | The new Y component |
| float | w | The new W component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the X, Y and W components replaced |


#### Vector4:WithXZW <a name="vectorExtensionsVector4WithXZW"/>
Returns a new Vector4 with the X, Z and W components replaced
#### Declaration
```csharp
Vector4 WithXZW(float x, float z, float w);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | x | The new X component |
| float | z | The new Z component |
| float | w | The new W component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the X, Z and W components replaced |


#### Vector4:WithYZW <a name="vectorExtensionsVector4WithYZW"/>
Returns a new Vector4 with the Y, Z and W components replaced
#### Declaration
```csharp
Vector4 WithYZW(float y, float z, float w);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | y | The new Y component |
| float | z | The new Z component |
| float | w | The new W component |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the Y, Z and W components replaced |

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com