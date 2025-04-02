# Color Extensions
## Table of contents
- [Documentation](#documentation)
  - [Color](#colorExtensions)
      - [Blend](#colorExtensionsBlend)
      - [Invert](#colorExtensionsInvert)
      - [ToHexString](#colorExtensionsToHexString)
      - [ToHexUInt](#colorExtensionsToHexUint)
      - [With](#colorExtensionsWith)
      - [WithAlpha](#colorExtensionsWithAlpha)
      - [WithBlue](#colorExtensionsWithBlue)
      - [WithGreen](#colorExtensionsWithGreen)
      - [WithRed](#colorExtensionsWithRed)

## Documentation <a name="documentation"/>
### Color Extensions <a name="colorExtensions"/>
#### Blend <a name="colorExtensionsBlend"/>
Blend two colors based on a specified ratio
#### Declaration
```csharp
Color Blend(Color color2, float ratio);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Color | color2 | The second color of the blend |
| float | ratio | The blend ratio of the colors |
#### Returns
| Type | Description |
| :--- | :--- |
| Color | The blended color based on the specified ratio |


#### Invert <a name="colorExtensionsInvert"/>
Inverts the color
#### Declaration
```csharp
Color Invert();
```
#### Returns
| Type | Description |
| :--- | :--- |
| Color | The inverted color |


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


#### With <a name="colorExtensionsWith"/>
Returns a new Color with the specified components replaced
#### Declaration
```csharp
Color With(float? r = null, float? g = null, float? b = null, float? a = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float? | r | The new r value |
| float? | g | The new g value |
| float? | b | The new b value |
| float? | a | The new a value |
#### Returns
| Type | Description |
| :--- | :--- |
| Color | New Color with the specified components replaced |


#### WithAlpha <a name="colorExtensionsWithAlpha"/>
Returns a new Color with the alpha component replaced
#### Declaration
```csharp
Color WithAlpha(float alpha);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | alpha | The new alpha value |
#### Returns
| Type | Description |
| :--- | :--- |
| Color | New Color with the alpha component replaced |


#### WithBlue <a name="colorExtensionsWithBlue"/>
Returns a new Color with the B component replaced
#### Declaration
```csharp
Color WithBlue(float bValue);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | bValue | The new B value |
#### Returns
| Type | Description |
| :--- | :--- |
| Color | New Color with the B component replaced |


#### WithGreen <a name="colorExtensionsWithGreen"/>
Returns a new Color with the G component replaced
#### Declaration
```csharp
Color WithGreen(float gValue);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | gValue | The new G value |
#### Returns
| Type | Description |
| :--- | :--- |
| Color | New Color with the G component replaced |


#### WithRed <a name="colorExtensionsWithRed"/>
Returns a new Color with the R component replaced
#### Declaration
```csharp
Color WithRed(float rValue);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | rValue | The new R value |
#### Returns
| Type | Description |
| :--- | :--- |
| Color | New Color with the R component replaced |