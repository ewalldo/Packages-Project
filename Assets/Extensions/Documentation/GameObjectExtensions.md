# GameObject Extensions
## Table of contents
- [Documentation](#documentation)
  - [GameObject](#gameObjectExtensions)
      - [AddOrGetComponent](#gameObjectExtensionsAddOrGetComponent)
      - [GetOrNull](#gameObjectExtensionsGetOrNull)
      - [GetPath](#gameObjectExtensionsGetPath)
      - [GetFullPath](#gameObjectExtensionsGetFullPath)

## Documentation <a name="documentation"/>
### GameObject Extensions <a name="gameObjectExtensions"/>
#### AddOrGetComponent <a name="gameObjectExtensionsAddOrGetComponent"/>
Try to get a component from a gameObject, if it doesn't exist, add to it and return it
#### Declaration
```csharp
T AddOrGetComponent<T>();
```
#### Returns
| Type | Description |
| :--- | :--- |
| T | The component in the gameObject |


#### GetOrNull <a name="gameObjectExtensionsGetOrNull"/>
Return a gameObject itself if exists, null otherwise
#### Declaration
```csharp
T GetOrNull<T>();
```
#### Returns
| Type | Description |
| :--- | :--- |
| T | The object itself if it exists and it is not destroyed, null otherwise |


#### GetPath <a name="gameObjectExtensionsGetPath"/>
Get the full hierarchical path, from the root until parent, for this specific GameObject
#### Declaration
```csharp
string GetPath();
```
#### Returns
| Type | Description |
| :--- | :--- |
| string | String representation of the hierarchical path |


#### GetFullPath <a name="gameObjectExtensionsGetFullPath"/>
Get the full hierarchical path, from the root until gameObject, for this specific GameObject
#### Declaration
```csharp
string GetFullPath();
```
#### Returns
| Type | Description |
| :--- | :--- |
| string | String representation of the full hierarchical path |