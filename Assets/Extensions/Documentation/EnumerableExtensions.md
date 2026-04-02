# Enumerable Extensions
## Table of contents
- [Documentation](#documentation)
  - [Enumerable](#enumerableExtensions)
      - [ForEach](#enumerableExtensionsForEach)

## Documentation <a name="documentation"/>
### Enumerable Extensions <a name="enumerableExtensions"/>
#### ForEach <a name="enumerableExtensionsForEach"/>
Performs an action on each element of the sequence
#### Declaration
```csharp
void ForEach<T>(Action<T> action);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Action<T> | action | The action to be performed on each element |