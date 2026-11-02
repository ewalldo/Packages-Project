# Float Extensions
## Table of contents
- [Documentation](#documentation)
  - [Float](#floatExtensions)
      - [Clamp](#floatExtensionsClamp)
      - [Clamp01](#floatExtensionsClamp01)
      - [Complement](#floatExtensionsComplement)
      - [InRange](#floatExtensionsInRange)
      - [Inverse](#floatExtensionsInverse)
      - [Map](#floatExtensionsMap)
      - [MapClamped](#floatExtensionsMapClamped)
      - [MapUnclamped](#floatExtensionsMapUnclamped)
      - [Maximum](#floatExtensionsMaximum)
      - [Minimum](#floatExtensionsMinimum)
      - [Normalize](#floatExtensionsNormalize)
      - [ToPercentage](#floatExtensionsToPercentage)
      - [Wrap](#floatExtensionsWrap)

## Documentation <a name="documentation"/>
### Float Extensions <a name="floatExtensions"/>
#### Clamp <a name="floatExtensionsClamp"/>
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


#### Clamp01 <a name="floatExtensionsClamp01"/>
Clamp the value between 0 and 1
#### Declaration
```csharp
float Clamp01();
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The clamped value |


#### Complement <a name="floatExtensionsComplement"/>
Return the complement of a value (1 - value)
#### Declaration
```csharp
float Complement();
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The complement of the value |


#### InRange <a name="floatExtensionsInRange"/>
Returns if the value is within the min and max values
#### Declaration
```csharp
bool InRange(float min, float max);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | min | The minimum value |
| float | max | The maximum value |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | Whether the value is within the range or not |


#### Inverse <a name="floatExtensionsInverse"/>
Inverse the signal of a value
#### Declaration
```csharp
float Inverse();
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The inverted value |


#### Map <a name="floatExtensionsMap"/>
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


#### MapClamped <a name="floatExtensionsMapClamped"/>
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


#### MapUnclamped <a name="floatExtensionsMapUnclamped"/>
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


#### Maximum <a name="floatExtensionsMaximum"/>
Gets the maximum between two values
Gets the maximum value in a set of values
#### Declaration
```csharp
float Maximum(float b);
float Maximum(params float[] values)
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | b | The second value to compare with |
| float[] | values | Set of values to get the maximum from |
#### Returns
| Type | Description |
| :--- | :--- |
| float | The maximum value between the two/in a set |


#### Minimum <a name="floatExtensionsMinimum"/>
Gets the minimum between two values
Gets the minimum value in a set of values
#### Declaration
```csharp
float Minimum(float b);
float Minimum(params float[] values)
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | b | The second value to compare with |
| float[] | values | Set of values to get the minimum from |
#### Returns
| Type | Description |
| :--- | :--- |
| float | The minimum value between the two/in a set |


#### Normalize <a name="floatExtensionsNormalize"/>
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


#### ToPercentage <a name="floatExtensionsToPercentage"/>
Converts a value to its representation in percentage (between 0 and 100%)
#### Declaration
```csharp
float ToPercentage(float total = 1f);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | total | The value which represents 100% |
#### Returns
| Type | Description |
| :--- | :--- |
| float | The value representation in percentage |


#### Wrap <a name="floatExtensionsWrap"/>
Wraps the value between min (inclusive) and max (exclusive)
#### Declaration
```csharp
float Wrap(float min, float max);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | min | The minimum value of the wrap range |
| float | max | The maximum value of the wrap range |
#### Returns
| Type | Description |
| :--- | :--- |
| float | The value wrapped |