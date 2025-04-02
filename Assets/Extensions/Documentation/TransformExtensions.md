# Transform Extensions
## Table of contents
- [Documentation](#documentation)
  - [Transform](#transformExtensions)
      - [Children](#transformExtensionsChildren)
      - [DestroyAllChildren](#transformExtensionsDestroyAllChildren)
      - [DirectionFrom](#transformExtensionsDirectionFrom)
      - [DirectionTo](#transformExtensionsDirectionTo)
      - [DistanceTo](#transformExtensionsDistanceTo)
      - [FirstChild](#transformExtensionsFirstChild)
      - [ForEveryChild](#transformExtensionsForEveryChild)
      - [IsAllCornersVisible](#transformExtensionsIsAllCornersVisible)
      - [IsAtLeastOneCornerVisible](#transformExtensionsIsAtLeastOneCornerVisible)
      - [LastChild](#transformExtensionsLastChild)
      - [ResetTransform](#transformExtensionsResetTransform)
      - [RotateTowards](#transformExtensionsRotateTowards)
      - [SetActiveAllChildren](#transformExtensionsSetActiveAllChildren)
      - [SetParentAndReset](#transformExtensionsSetParentAndReset)

## Documentation <a name="documentation"/>
### Transform Extensions <a name="transformExtensions"/>
#### Children <a name="transformExtensionsChildren"/>
Retrieves all children from the Transform
#### Declaration
```csharp
IEnumerable<Transform> Children();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<Transform> | IEnumerable containing all child Transform |


#### DestroyAllChildren <a name="transformExtensionsDestroyAllChildren"/>
Destroy all children of a transform
#### Declaration
```csharp
void DestroyAllChildren();
```


#### DirectionFrom <a name="transformExtensionsDirectionFrom"/>
Calculates the direction between another transform or point in space in relation to this one
#### Declaration
```csharp
Vector3 DirectionFrom(Transform other, bool useLocalPosition = false);
Vector3 DirectionFrom(Vector3 other, bool useLocalPosition = false);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | other | The transform to calculate the direction from |
| Vector3 | other | The position to calculate the direction from |
| bool | useLocalPosition | If the direction should be calculated using the local position or the global one |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | The normalized directional vector from the target to this transform |


#### DirectionTo <a name="transformExtensionsDirectionTo"/>
Calculates the direction between this transform in relation to another one or a point in space
#### Declaration
```csharp
Vector3 DirectionTo(Transform other, bool useLocalPosition = false);
Vector3 DirectionTo(Vector3 other, bool useLocalPosition = false);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | other | The transform to calculate the direction to |
| Vector3 | other | The position to calculate the direction to |
| bool | useLocalPosition | If the direction should be calculated using the local position or the global one |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | The normalized directional vector from this transform to the target |


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


#### ForEveryChild <a name="transformExtensionsForEveryChild"/>
Performs an action on every child of the Transform
#### Declaration
```csharp
void ForEveryChild(Action<Transform> action);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Action<Transform> | action | Action to be performed on every child |


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