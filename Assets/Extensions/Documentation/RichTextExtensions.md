# RichText Extensions
## Table of contents
- [Documentation](#documentation)
  - [RichText](#richtextExtensions)
      - [WrapAround](#richTextExtensionsWrapAround)
      - [Bold](#richTextExtensionsBold)
      - [Italic](#richTextExtensionsItalic)
      - [Size](#richTextExtensionsSize)
      - [Color](#richTextExtensionsColor)

## Documentation <a name="documentation"/>
### RichText Extensions <a name="richTextExtensions"/>
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