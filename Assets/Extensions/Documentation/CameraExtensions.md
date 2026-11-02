# Camera Extensions
## Table of contents
- [Documentation](#documentation)
  - [Camera](#cameraExtensions)
      - [AddLayerToCullingMask](#cameraExtensionsAddLayerToCullingMask)
      - [GetAllGameObjectsAtScreenPosition](#cameraExtensionsGetAllGameObjectsAtScreenPosition)
      - [GetGameObjectAtScreenPosition](#cameraExtensionsGetGameObjectAtScreenPosition)
      - [GetOrthographicBounds](#cameraExtensionsGetOrthographicBounds)
      - [GetScreenSpaceBoundsFromRenderer](#cameraExtensionsGetScreenSpaceBoundsFromRenderer)
      - [GetViewSizeAtDistance](#cameraExtensionsGetViewSizeAtDistance)
      - [IsLayerRenderedByCamera](#cameraExtensionsIsLayerRenderedByCamera)
      - [IsPointVisibleFromCamera](#cameraExtensionsIsPointVisibleFromCamera)
      - [IsRendererVisibleFromCamera](#cameraExtensionsIsRendererVisibleFromCamera)
      - [IsScreenPositionOverUI](#cameraExtensionsIsScreenPositionOverUI)
      - [RemoveLayerFromCullingMask](#cameraExtensionsRemoveLayerFromCullingMask)
      - [ScreenPointToWorldPositionAtDistance](#cameraExtensionsScreenPointToWorldPositionAtDistance)
      - [ScreenPointToWorldPositionOnHorizontalPlane](#cameraExtensionsScreenPointToWorldPositionOnHorizontalPlane)
      - [ScreenPointToWorldPositionOnPlane](#cameraExtensionsScreenPointToWorldPositionOnPlane)
      - [ScreenPointToRaycastHit](#cameraExtensionsScreenPointToRaycastHit)
      - [TryGetComponentAtScreenPosition](#cameraExtensionsTryGetComponentAtScreenPosition)

## Documentation <a name="documentation"/>
### Camera Extensions <a name="cameraExtensions"/>
#### AddLayerToCullingMask <a name="cameraExtensionsAddLayerToCullingMask"/>
Adds a specific layer to the camera's culling mask, enabling rendering of that layer
#### Declaration
```csharp
void AddLayerToCullingMask(int layer);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | layer | The layer index to add |


#### GetAllGameObjectsAtScreenPosition <a name="cameraExtensionsGetAllGameObjectsAtScreenPosition"/>
Returns all GameObjects hit by a ray cast from the camera through the given screen position, sorted by distance from the camera (nearest first)
#### Declaration
```csharp
GameObject[] GetAllGameObjectsAtScreenPosition(Vector2 screenPosition, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector2 | screenPosition | The screen-space position (e.g. mouse position) |
| float | maxDistance | The maximum distance to cast the ray |
| int | layerMask | The layer mask to use for the raycast |
#### Returns
| Type | Description |
| :--- | :--- |
| GameObject[] | An array of GameObjects hit by the ray |


#### GetGameObjectAtScreenPosition <a name="cameraExtensionsGetGameObjectAtScreenPosition"/>
Returns the first GameObject hit by a ray cast from the camera through the given screen position
#### Declaration
```csharp
GameObject GetGameObjectAtScreenPosition(Vector2 screenPosition, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector2 | screenPosition | The screen-space position (e.g. mouse position) |
| float | maxDistance | The maximum distance to cast the ray |
| int | layerMask | The layer mask to use for the raycast |
#### Returns
| Type | Description |
| :--- | :--- |
| GameObject | The first GameObject hit by the ray, or null if no object was hit |


#### GetOrthographicBounds <a name="cameraExtensionsGetOrthographicBounds"/>
Returns the world-space bounds of the camera's orthographic view at a given Z depth. Only valid for orthographic cameras.
#### Declaration
```csharp
Bounds GetOrthographicBounds(float depth = 0f);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | depth | The world-space Z depth at which to calculate the bounds |
#### Returns
| Type | Description |
| :--- | :--- |
| Bounds | The world-space bounds of the orthographic view |


#### GetScreenSpaceBoundsFromRenderer <a name="cameraExtensionsGetScreenSpaceBoundsFromRenderer"/>
Calculates the screen-space bounding box of a Renderer as seen by this camera
#### Declaration
```csharp
Rect GetScreenSpaceBoundsFromRenderer(Renderer renderer);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Renderer | renderer | The renderer to get the bounds from |
#### Returns
| Type | Description |
| :--- | :--- |
| Rect | The screen-space bounding box of the renderer |


#### GetViewSizeAtDistance <a name="cameraExtensionsGetViewSizeAtDistance"/>
Calculates the world-space size (width and height) of the camera's view at a given distance. Works for both orthographic and perspective cameras.
#### Declaration
```csharp
Vector2 GetViewSizeAtDistance(float distance);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | distance | Distance from the camera at which to calculate the size |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector2 | A Vector2 where X is the width and Y is the height in world units |


#### IsLayerRenderedByCamera <a name="cameraExtensionsIsLayerRenderedByCamera"/>
Checks whether a specific layer is included in the camera's culling mask
#### Declaration
```csharp
bool IsLayerRenderedByCamera(int layer);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | layer | The layer index to check |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the layer is included in the culling mask, false otherwise |


#### IsPointVisibleFromCamera <a name="cameraExtensionsIsPointVisibleFromCamera"/>
Determines whether a world-space point is visible within the camera's view frustum
#### Declaration
```csharp
bool IsPointVisibleFromCamera(Vector3 worldPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | worldPosition | The world position to test |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the point is within the camera's view frustum, false otherwise |


#### IsRendererVisibleFromCamera <a name="cameraExtensionsIsRendererVisibleFromCamera"/>
Checks if a specific Renderer is visible from the camera
#### Declaration
```csharp
bool IsRendererVisibleFromCamera(Renderer renderer);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Renderer | renderer | The renderer whose bounds will be tested |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if visible, false otherwise |


#### IsScreenPositionOverUI <a name="cameraExtensionsIsScreenPositionOverUI"/>
Checks whether the given screen-space position is currently hovering over a UI element. Requires an EventSystem to be present in the scene.
#### Declaration
```csharp
bool IsScreenPositionOverUI(Vector2 screenPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector2 | screenPosition | The screen-space position to check |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the position is over a UI element, false otherwise |


#### RemoveLayerFromCullingMask <a name="cameraExtensionsRemoveLayerFromCullingMask"/>
Removes a specific layer from the camera's culling mask, preventing rendering of that layer
#### Declaration
```csharp
void RemoveLayerFromCullingMask(int layer);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | layer | The layer index to remove |


#### ScreenPointToWorldPositionAtDistance <a name="cameraExtensionsScreenPointToWorldPositionAtDistance"/>
Converts a screen-space point to a world-space point at the specified distance from the camera. Useful for placing objects at a fixed depth relative to the camera.
#### Declaration
```csharp
Vector3 ScreenPointToWorldPositionAtDistance(Vector2 screenPosition, float distance);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector2 | screenPosition | The screen-space point (pixels) |
| float | distance | The distance from the camera to the desired world units |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | The world-space position at the specified distance |


#### ScreenPointToWorldPositionOnHorizontalPlane <a name="cameraExtensionsScreenPointToWorldPositionOnHorizontalPlane"/>
Returns the world-space position of a screen-space point on a flat horizontal (XZ) plane at the given world-space Y height
#### Declaration
```csharp
bool ScreenPointToWorldPositionOnHorizontalPlane(Vector2 screenPosition, out Vector3 worldPosition, float yHeight = 0f);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector2 | screenPosition | The screen-space position (e.g. mouse position) |
| out Vector3 | worldPosition | The resulting world-space position on the plane |
| float | yHeight | The world-space Y height of the horizontal plane |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the ray intersects the plane, false if they are parallel |


#### ScreenPointToWorldPositionOnPlane <a name="cameraExtensionsScreenPointToWorldPositionOnPlane"/>
Returns the world-space position of a screen-space point projected onto a world-space plane. Useful for top-down or isometric applications where you want the world position of a mouse click.
#### Declaration
```csharp
bool ScreenPointToWorldPositionOnPlane(Vector2 screenPosition, Plane plane, out Vector3 worldPosition);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector2 | screenPosition | The screen-space position (e.g. mouse position) |
| Plane | plane | The world-space plane to project onto |
| out Vector3 | worldPosition | The resulting world-space position on the plane |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the ray intersects the plane, false if they are parallel |


#### ScreenPointToRaycastHit <a name="cameraExtensionsScreenPointToRaycastHit"/>
Casts a ray from the camera through the given screen-space position
#### Declaration
```csharp
bool ScreenPointToRaycastHit(Vector2 screenPosition, out RaycastHit hitInfo, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector2 | screenPosition | The screen-space position to cast through |
| out RaycastHit | hitInfo | Information about the raycast hit |
| float | maxDistance | The maximum distance the ray should travel |
| int  | layerMask | A layer mask to filter which objects can be hit |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the ray hit something, false otherwise |


#### TryGetComponentAtScreenPosition <a name="cameraExtensionsTryGetComponentAtScreenPosition"/>
Attempts to retrieve a component of type T from the first object hit by a ray cast through the given screen-space position
#### Declaration
```csharp
bool TryGetComponentAtScreenPosition<T>(Vector2 screenPosition, out T component, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers) where T : Component;
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector2 | screenPosition | The screen-space position (e.g. mouse position) |
| out T | component | The resulting component, or null if none was found |
| float | maxDistance | The maximum distance to cast the ray |
| int  | layerMask | The layer mask to use for the raycast |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the component was found, false otherwise |