# String Extensions
## Table of contents
- [Documentation](#documentation)
  - [String](#stringExtensions)
      - [CopyToClipboard](#stringExtensionsCopyToClipboard)
      - [FromHexString](#stringExtensionsFromHexString)
      - [FromFromRomanNumerals](#stringExtensionsFromFromRomanNumerals)
      - [GetFileExtension](#stringExtensionsGetFileExtension)
      - [HasValue](#stringExtensionsHasValue)
      - [IsNullOrEmpty](#stringExtensionsIsNullOrEmpty)
      - [IsNullOrWhiteSpace](#stringExtensionsIsNullOrWhiteSpace)
      - [Shorten](#stringExtensionsShorten)
      - [ToColor](#stringExtensionsToColor)
      - [ToEnum](#stringExtensionsToEnum)
      - [ToFloat](#stringExtensionsToFloat)
      - [ToInt](#stringExtensionsToInt)
      - [ToVector](#stringExtensionsToVector)
      - [ValueOrEmpty](#stringExtensionsValueOrEmpty)
      - [With](#stringExtensionsWith)

## Documentation <a name="documentation"/>
### String Extensions <a name="stringExtensions"/>
#### CopyToClipboard <a name="stringExtensionsCopyToClipboard"/>
Copies the string to the system clipboard
#### Declaration
```csharp
void CopyToClipboard();
```


#### FromHexString <a name="stringExtensionsFromHexString"/>
Converts a hex string into a Color
#### Declaration
```csharp
Color FromHexString();
```
#### Returns
| Type | Description |
| :--- | :--- |
| Color | The Color represented by the hex string |


#### FromFromRomanNumerals <a name="stringExtensionsFromFromRomanNumerals"/>
Converts a Roman numeral string into an integer (e.g. I to 1, II to 2, etc.)
#### Declaration
```csharp
int FromRomanNumerals();
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | The integer representing the Roman numeral |


#### GetFileExtension <a name="stringExtensionsGetFileExtension"/>
Gets the file extension of a file in a string format
#### Declaration
```csharp
string GetFileExtension();
```
#### Returns
| Type | Description |
| :--- | :--- |
| string | The corresponding file extension |


#### HasValue <a name="stringExtensionsHasValue"/>
Checks if a string has a value, i.e. not null, not empty and not white spaces only
#### Declaration
```csharp
bool hasValue();
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True, if the string has value, false otherwise |


#### IsNullOrEmpty <a name="stringExtensionsIsNullOrEmpty"/>
Checks if a string is null or empty
#### Declaration
```csharp
bool IsNullOrEmpty();
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True, if null or empty, false otherwise |


#### IsNullOrWhiteSpace <a name="stringExtensionsIsNullOrWhiteSpace"/>
Checks if a string is null or composed of white space
#### Declaration
```csharp
bool IsNullOrWhiteSpace();
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True, if null or composed of white spaces, false otherwise |


#### Shorten <a name="stringExtensionsShorten"/>
Shortens a string to a specified maxLength. If the string is smaller, the original string is returned
#### Declaration
```csharp
string Shorten(int maxLength);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | maxLength | The max length of the new string |
#### Returns
| Type | Description |
| :--- | :--- |
| string | The shortened string |


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


#### ToEnum <a name="stringExtensionsToEnum"/>
Converts a string to an enum value
#### Declaration
```csharp
T ToEnum<T>() where T: struct, Enum;
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| T | --- | The Enum type to convert to |
#### Returns
| Type | Description |
| :--- | :--- |
| T | The enum value represented by the string |


#### ToFloat <a name="stringExtensionsToFloat"/>
Converts a string to an float value
#### Declaration
```csharp
float ToFloat();
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The float value represented by the string |


#### ToInt <a name="stringExtensionsToInt"/>
Converts a string to an int value
#### Declaration
```csharp
int ToInt();
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | The int value represented by the string |


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


#### ValueOrEmpty <a name="stringExtensionsValueOrEmpty"/>
Gets the value of a string or an empty one if the string is null
#### Declaration
```csharp
string ValueOrEmpty();
```
#### Returns
| Type | Description |
| :--- | :--- |
| string | The string value or an empty string if null |


#### With <a name="stringExtensionsWith"/>
Shorthand version of string.Format. ex: "Hello {0}{1}.With("world", "!");
#### Declaration
```csharp
string With(params object[] args);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| params object[] | args | Values to be inserted into the string |
#### Returns
| Type | Description |
| :--- | :--- |
| string | The formatted string |