# TMPro Extensions
## Table of contents
- [Documentation](#documentation)
  - [TMPro](#tmproExtensions)
      - [ResizeRectTransformToMatchText](#tmproExtensionsResizeRectTransformToMatchText)

## Documentation <a name="documentation"/>
### TMPro Extensions <a name="tmproExtensions"/>
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