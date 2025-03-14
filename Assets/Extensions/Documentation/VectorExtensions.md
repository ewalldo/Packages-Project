# Vector Extensions
## Table of contents
- [Documentation](#documentation)
  - [Vector](#vectorExtensions)
      - [Vector2:AddToAxis](#vectorExtensionsVector2AddToAxis)
      - [Vector2:InRangeOf](#vectorExtensionsVector2InRangeOf)
      - [Vector2:With](#vectorExtensionsVector2With)
      - [Vector2:WithX](#vectorExtensionsVector2WithX)
      - [Vector2:WithY](#vectorExtensionsVector2WithY)
      - [Vector2:RandomPointInAnnulus](#vectorExtensionsVector2RandomPointInAnnulus)
      - [Vector2:PointToSphereSurface](#vectorExtensionsVector2PointToSphereSurface)
      - [Vector3:AddToAxis](#vectorExtensionsVector3AddToAxis)
      - [Vector3:InRangeOf](#vectorExtensionsVector3InRangeOf)
      - [Vector3:With](#vectorExtensionsVector3With)
      - [Vector3:WithX](#vectorExtensionsVector3WithX)
      - [Vector3:WithY](#vectorExtensionsVector3WithY)
      - [Vector3:WithZ](#vectorExtensionsVector3WithZ)
      - [Vector3:WithXY](#vectorExtensionsVector3WithXY)
      - [Vector3:WithXZ](#vectorExtensionsVector3WithXZ)
      - [Vector3:WithYZ](#vectorExtensionsVector3WithYZ)
      - [Vector3:RandomPointInAnnulus](#vectorExtensionsVector3RandomPointInAnnulus)
      - [Vector4:AddToAxis](#vectorExtensionsVector4AddToAxis)
      - [Vector4:InRangeOf](#vectorExtensionsVector4InRangeOf)
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

## Documentation <a name="documentation"/>
### Vector Extensions <a name="vectorExtensions"/>
#### Vector2:AddToAxis <a name="vectorExtensionsVector2AddToAxis"/>
Returns a new Vector2 with a specific amount added to each axis
#### Declaration
```csharp
Vector2 AddToAxis(float x = 0, float y = 0);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | x | Amount to add to the X-axis. Defaults to 0 |
| float | y | Amount to add to the Y-axis. Defaults to 0 |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector2 | A new Vector2 with the value added to the specified components |


#### Vector2:InRangeOf <a name="vectorExtensionsVector2InRangeOf"/>
Returns true if current Vector2 is in range of specified Vector2 and range
#### Declaration
```csharp
bool InRangeOf(Vector2 origin, float range);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector2 | origin | The Vector4 to compare with |
| float | range | The range of the specified Vector2 |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True, if the current Vector2 is in range, false otherwise |


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


#### Vector2:RandomPointInAnnulus <a name="vectorExtensionsVector2RandomPointInAnnulus"/>
Gets a random point inside an annulus using the current Vector2 as origin
#### Declaration
```csharp
Vector2 RandomPointInAnnulus(float smallerRadius, float largerRadius);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | smallerRadius | The radius of the smaller circle |
| float | largerRadius | The radius of the larger circle |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector2 | A random point inside the specified annulus |


#### Vector2:PointToSphereSurface <a name="vectorExtensionsVector2PointToSphereSurface"/>
Map a 2D point to a sphere surface.
  The middle of the 2D point will be mapped to the front of the sphere (0, 0, radius).
  While the values of the X edges (minX and maxX) will be mapped to the back (0, 0, -radius).
#### Declaration
```csharp
Vector3 PointToSphereSurface(float radius, float minX = 0, float maxX = 1, float minY = 0, float maxY = 1);
Vector3 PointToSphereSurface(float radius, Vector2 xRange, Vector2 yRange);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | radius | The sphere radius |
| float | minX | The minimum X value of the range |
| float | maxX | The maximum X value of the range |
| float | minY | The minimum Y value of the range |
| float | maxY | The maximum Y value of the range |
| Vector2 | xRange | The range of the X value [xMin, xMax] |
| Vector2 | yRange | The range of the Y value [yMin, yMax] |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | The point on the sphere surface |


#### Vector3:AddToAxis <a name="vectorExtensionsVector3AddToAxis"/>
Returns a new Vector3 with a specific amount added to each axis
#### Declaration
```csharp
Vector3 AddToAxis(float x = 0, float y = 0, float z = 0);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | x | Amount to add to the X-axis. Defaults to 0 |
| float | y | Amount to add to the Y-axis. Defaults to 0 |
| float | z | Amount to add to the Z-axis. Defaults to 0 |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | A new Vector3 with the value added to the specified components |


#### Vector3:InRangeOf <a name="vectorExtensionsVector3InRangeOf"/>
Returns true if current Vector3 is in range of specified Vector3 and range
#### Declaration
```csharp
bool InRangeOf(Vector3 origin, float range);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | origin | The Vector3 to compare with |
| float | range | The range of the specified Vector3 |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True, if the current Vector3 is in range, false otherwise |


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

#### Vector3:RandomPointInAnnulus <a name="vectorExtensionsVector3RandomPointInAnnulus"/>
Gets a random point inside an annulus using the current Vector3 as origin
#### Declaration
```csharp
Vector3 RandomPointInAnnulus(float smallerRadius, float largerRadius);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | smallerRadius | The radius of the smaller circle |
| float | largerRadius | The radius of the larger circle |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | A random point inside the specified annulus |


#### Vector4:AddToAxis <a name="vectorExtensionsVector4AddToAxis"/>
Returns a new Vector4 with a specific amount added to each axis
#### Declaration
```csharp
Vector4 AddToAxis(float x = 0, float y = 0, float z = 0, float w = 0);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | x | Amount to add to the X-axis. Defaults to 0 |
| float | y | Amount to add to the Y-axis. Defaults to 0 |
| float | z | Amount to add to the Z-axis. Defaults to 0 |
| float | w | Amount to add to the W-axis. Defaults to 0 |
#### Returns
| Type | Description |
| :--- | :--- |
| Vector4 | A new Vector4 with the value added to the specified components |


#### Vector4:InRangeOf <a name="vectorExtensionsVector4InRangeOf"/>
Returns true if current Vector4 is in range of specified Vector4 and range
#### Declaration
```csharp
bool InRangeOf(Vector4 origin, float range);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector4 | origin | The Vector4 to compare with |
| float | range | The range of the specified Vector4 |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True, if the current Vector4 is in range, false otherwise |


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