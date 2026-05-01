# Int Extensions
## Table of contents
- [Documentation](#documentation)
  - [Int](#intExtensions)
      - [Clamp](#intExtensionsClamp)
      - [GetBiasedRandomNumber](#intExtensionsGetBiasedRandomNumber)
      - [InRange](#intExtensionsInRange)
      - [Inverse](#intExtensionsInverse)
      - [Maximum](#intExtensionsMaximum)
      - [Minimum](#intExtensionsMinimum)
      - [ToOrdinal](#intExtensionsToOrdinal)
      - [ToRomanNumeral](#intExtensionsToRomanNumeral)
      - [ToTimer](#intExtensionsToTimer)
      - [Wrap](#intExtensionsWrap)

## Documentation <a name="documentation"/>
### Int Extensions <a name="intExtensions"/>
#### Clamp <a name="intExtensionsClamp"/>
Clamp the value between a min and max
#### Declaration
```csharp
int Clamp(int min, int max);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | min | The minimum value |
| int | max | The maximum value |
#### Returns
| Type | Description |
| :--- | :--- |
| int | The clamped value |


#### GetBiasedRandomNumber <a name="intExtensionsGetBiasedRandomNumber"/>
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


#### InRange <a name="intExtensionsInRange"/>
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


#### Inverse <a name="intExtensionsInverse"/>
Inverse the signal of a value
#### Declaration
```csharp
int Inverse();
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | The inverted value |


#### Maximum <a name="intExtensionsMaximum"/>
Gets the maximum between two values
Gets the maximum value in a set of values
#### Declaration
```csharp
int Maximum(int b);
int Maximum(params int[] values)
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | b | The second value to compare with |
| int[] | values | Set of values to get the maximum from |
#### Returns
| Type | Description |
| :--- | :--- |
| int | The maximum value between the two/in a set |


#### Minimum <a name="intExtensionsMinimum"/>
Gets the minimum between two values
Gets the minimum value in a set of values
#### Declaration
```csharp
int Minimum(int b);
int Minimum(params int[] values)
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | b | The second value to compare with |
| int[] | values | Set of values to get the minimum from |
#### Returns
| Type | Description |
| :--- | :--- |
| int | The minimum value between the two/in a set |


#### ToOrdinal <a name="intExtensionsToOrdinal"/>
Converts an integer to its ordinal representation (e.g. 1 to 1st, 2 to 2nd, etc.)
#### Declaration
```csharp
string ToOrdinal();
```
#### Returns
| Type | Description |
| :--- | :--- |
| string | The value in its ordinal representation |


#### ToRomanNumeral <a name="intExtensionsToRomanNumeral"/>
Converts an integer to its Roman numeral representation (e.g. 1 to I, 2 to II, etc.)
#### Declaration
```csharp
string ToRomanNumeral();
```
#### Returns
| Type | Description |
| :--- | :--- |
| string | The value in its Roman numeral representation |


#### ToTimer <a name="intExtensionsToTimer"/>
Maps a value in seconds to a "MM:SS" style timer string
#### Declaration
```csharp
string ToTimer();
```
#### Returns
| Type | Description |
| :--- | :--- |
| string | String representation in the "MM:SS" format |


#### Wrap <a name="intExtensionsWrap"/>
Wraps the value between min (inclusive) and max (exclusive)
#### Declaration
```csharp
int Wrap(int min, int max);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | min | The minimum value of the wrap range |
| int | max | The maximum value of the wrap range |
#### Returns
| Type | Description |
| :--- | :--- |
| int | The value wrapped |