# RigidBody Extensions
## Table of contents
- [Documentation](#documentation)
  - [RigidBody](#rigidBodyExtensions)
      - [AddForceTowards](#rigidBodyExtensionsAddForceTowards)
      - [ApplyForceToReachVelocity](#rigidBodyExtensionsApplyForceToReachVelocity)
      - [ChangeDirection](#rigidBodyExtensionsChangeDirection)
      - [ClampSpeed](#rigidBodyExtensionsClampSpeed)
      - [GetSpeed](#rigidBodyExtensionsGetSpeed)
      - [IsGrounded](#rigidBodyExtensionsIsGrounded)
      - [ResetVelocity](#rigidBodyExtensionsResetVelocity)
      - [SetKinematic](#rigidBodyExtensionsSetKinematic)
      - [SetSpeed](#rigidBodyExtensionsSetSpeed)

## Documentation <a name="documentation"/>
### RigidBody Extensions <a name="rigidBodyExtensions"/>
#### AddForceTowards <a name="rigidBodyExtensionsAddForceTowards"/>
Applies force to the Rigidbody directed toward the given world-space target position
#### Declaration
```csharp
void AddForceTowards(Vector3 targetPosition, float forceMagnitude, ForceMode forceMode = ForceMode.Force);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | targetPosition | The world-space position to apply force towards |
| float | forceMagnitude | The magnitude of the force to apply |
| ForceMode | forceMode | The ForceMode to use when applying the force |


#### ApplyForceToReachVelocity <a name="rigidBodyExtensionsApplyForceToReachVelocity"/>
Applies a force to the Rigidbody that will bring it to a desired target velocity within a single physics update
#### Declaration
```csharp
void ApplyForceToReachVelocity(Vector3 targetVelocity, ForceMode forceMode = ForceMode.Force);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | targetVelocity | The desired target velocity |
| ForceMode | forceMode | The ForceMode to use when applying the force |


#### ChangeDirection <a name="rigidBodyExtensionsChangeDirection"/>
Changes the Rigidbody's movement direction while preserving its current speed. Has no effect if the Rigidbody is not moving
#### Declaration
```csharp
void ChangeDirection(Vector3 newDirection);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | newDirection | The new direction to move in |


#### ClampSpeed <a name="rigidBodyExtensionsClampSpeed"/>
Clamps the Rigidbody's speed to the given maximum value without changing its direction
#### Declaration
```csharp
void ClampSpeed(float maxSpeed);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | maxSpeed | The maximum speed to clamp to |


#### GetSpeed <a name="rigidBodyExtensionsGetSpeed"/>
Returns the current speed (scalar magnitude) of the Rigidbody
#### Declaration
```csharp
float GetSpeed();
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The magnitude of the Rigidbody's current velocity |


#### IsGrounded <a name="rigidBodyExtensionsIsGrounded"/>
Checks whether the Rigidbody is currently grounded by performing a SphereCast downward
#### Declaration
```csharp
bool IsGrounded(float checkDistance = 0.1f, int groundLayer = Physics.DefaultRaycastLayers, float sphereRadius = 0.25f);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | checkDistance | The distance below the Rigidbody to check for ground |
| int | groundLayer | The layer mask representing ground objects |
| float | sphereRadius | The radius of the sphere to cast |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the Rigidbody is grounded, false otherwise |


#### ResetVelocity <a name="rigidBodyExtensionsResetVelocity"/>
Immediately stops the Rigidbody by zeroing out both its linear and angular velocity
#### Declaration
```csharp
void ResetVelocity();
```


#### SetKinematic <a name="rigidBodyExtensionsSetKinematic"/>
Toggles the Rigidbody's isKinematic property and optionally resets its velocity when enabled
#### Declaration
```csharp
void SetKinematic(bool isKinematic, bool resetVelocity = true);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| bool | isKinematic | Whether the Rigidbody should be kinematic |
| bool | resetVelocity | Whether to reset the Rigidbody's velocity when enabling kinematic |


#### SetSpeed <a name="rigidBodyExtensionsSetSpeed"/>
Sets the speed of the Rigidbody while preserving the current direction of movement
#### Declaration
```csharp
void SetSpeed(float speed);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | speed | The desired speed in units per second |