# WorldStates
## Table of contents
- [Documentation](#documentation)
  - [WorldStateKey](#worldStateKey)
    - [WorldStateKey()](#worldStateKeyConstructor)
  - [WorldStateFact](#worldStateFact)
    - [WorldStateFact()](#worldStateFactConstructor)
    - [WorldStateFact.Create()](#worldStateFactCreate)
  - [WorldState](#worldState)
    - [WorldState()](#worldStateConstructor)
    - [Count](#worldStateCount)
    - [Set()](#worldStateSet)
    - [Apply()](#worldStateApply)
    - [ApplyRange()](#worldStateApplyRange)
    - [Remove()](#worldStateRemove)
    - [Clear()](#worldStateClear)
    - [Has()](#worldStateHas)
    - [TryGet()](#worldStateTryGet)
    - [Get...()](#worldStateGet)
    - [Clone()](#worldStateClone)
    - [MergeWith()](#worldStateMergeWith)
    - [Satisfies()](#worldStateSatisfies)
    - [GetDiff()](#worldStateGetDiff)
    - [GetAllFacts()](#worldStateGetAllFacts)

## Documentation <a name="documentation"/>
### 1 WorldStateKey <a name="worldStateKey"/>
#### 1.1 WorldStateKey() <a name="worldStateKeyConstructor"/>
A lightweight, hashable key used to identify a fact inside a WorldState.
##### Declaration
```csharp
public WorldStateKey(string name);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | name | The human-readable name for the key |


### 2 WorldStateFact <a name="worldStateFact"/>
#### 2.1 WorldStateFact() <a name="worldStateFactConstructor"/>
Represents a single fact: a key paired with a value. Used to define preconditions and effects on actions, and as individual entries inside a WorldState.
##### Declaration
```csharp
public WorldStateFact(WorldStateKey key, object value);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldStateKey | key | The key for the fact |
| object | value | The object associated with the key |


#### 2.1 WorldStateFact.Create() <a name="worldStateFactCreate"/>
Typed factory methods to create WorldStateFact.
##### Declaration
```csharp
public static WorldStateFact Create(WorldStateKey key, bool value);
public static WorldStateFact Create(WorldStateKey key, int value);
public static WorldStateFact Create(WorldStateKey key, float value);
public static WorldStateFact Create(WorldStateKey key, string value);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldStateKey | key | The key for the fact |
| bool | value | The object associated with the key |
| int | value | The object associated with the key |
| float | value | The object associated with the key |
| string | value | The object associated with the key |


### 3 WorldState <a name="worldState"/>
#### 3.1 WorldState() <a name="worldStateConstructor"/>
A mutable key-value store representing a snapshot of facts about the world.
##### Declaration
```csharp
public WorldState();
public WorldState(int capacity)
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | capacity | The maximum number of states that it can hold |


#### 3.2 Count <a name="worldStateCount"/>
The number of states it has currently.
##### Declaration
```csharp
public int Count;
```
##### Returns
| Type | Description |
| :--- | :--- |
| int | The current number of states |


#### 3.3 Set() <a name="worldStateSet"/>
Set the value of a specific world state.
##### Declaration
```csharp
public void Set(WorldStateKey key, bool value);
public void Set(WorldStateKey key, int value);
public void Set(WorldStateKey key, float value);
public void Set(WorldStateKey key, string value);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldStateKey | key | The key used to identify the fact |
| bool | value | The value for the corresponding key |
| int | value | The value for the corresponding key |
| float | value | The value for the corresponding key |
| string | value | The value for the corresponding key |


#### 3.4 Apply() <a name="worldStateApply"/>
Sets a value using a pre-built WorldStateFact.
##### Declaration
```csharp
public void Apply(WorldStateFact fact);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldStateFact | fact | The WorldStateFact to be used to set a state |


#### 3.5 ApplyRange() <a name="worldStateApplyRange"/>
Applies a collection of facts (e.g. action effects) onto this state.
##### Declaration
```csharp
public void ApplyRange(IEnumerable<WorldStateFact> facts);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| IEnumerable<WorldStateFact> | facts | The facts to be applied to the state |


#### 3.6 Remove() <a name="worldStateRemove"/>
Remove a fact from this state.
##### Declaration
```csharp
public void Remove(WorldStateKey key);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldStateKey | key | The facts to be removed from the state |


#### 3.7 Clear() <a name="worldStateClear"/>
Clear all facts from the state
##### Declaration
```csharp
public void Clear();
```


#### 3.8 Has() <a name="worldStateHas"/>
Check if the current state has a specific fact.
##### Declaration
```csharp
public bool Has(WorldStateKey key);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldStateKey | key | The key to check if exists in the current state |
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True, if exists, false otherwise |


#### 3.9 TryGet() <a name="worldStateTryGet"/>
Check if the current state has a specific fact, if it does return it.
##### Declaration
```csharp
public bool TryGet<T>(WorldStateKey key, out T value);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldStateKey | key | The key to check if exists in the current state |
| T | value | The value associated with the key, if it does not exists, returns the default for the type |
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True, if exists, false otherwise |


#### 3.10 Get...() <a name="worldStateGet"/>
Check if the current state has a specific fact, if it does return it.
##### Declaration
```csharp
public bool GetBool(WorldStateKey key, bool defaultValue = false);
public bool GetInt(WorldStateKey key, int defaultValue = 0);
public bool GetFloat(WorldStateKey key, float defaultValue = 0f);
public bool GetString(WorldStateKey key, string defaultValue = "");
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldStateKey | key | The key to check if exists in the current state |
| bool | defaultValue | The value associated with the key, if it does not exists, returns false |
| int | defaultValue | The value associated with the key, if it does not exists, returns 0 |
| float | defaultValue | The value associated with the key, if it does not exists, returns 0f |
| string | defaultValue | The value associated with the key, if it does not exists, returns empty string |
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True, if exists, false otherwise |


#### 3.11 Clone() <a name="worldStateClone"/>
Returns a deep copy of this WorldState.
##### Declaration
```csharp
public WorldState Clone();
```
##### Returns
| Type | Description |
| :--- | :--- |
| WorldState | A copy of the WorldState |


#### 3.12 MergeWith() <a name="worldStateMergeWith"/>
Copies all facts from another WorldState into this one. Existing keys are overwritten, keys only in this state are preserved.
##### Declaration
```csharp
public void MergeWith(WorldState other);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldState | other | The WorldState to merge with |


#### 3.13 Satisfies() <a name="worldStateSatisfies"/>
Checks whether this WorldState satisfies all facts defined in the given state.
A state is satisfied if for every fact, this state contains the same key with an equal value. Extra facts in this state are ignored.
##### Declaration
```csharp
public bool Satisfies(WorldState goalState);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldState | goalState | The desired state to check against |
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True if satisfies, false otherwise |


#### 3.14 GetDiff() <a name="worldStateGetDiff"/>
Returns all facts that differ between this state and another.
A fact is included if: the key is missing in the other state, or the value for the same key is different.
##### Declaration
```csharp
public IReadOnlyList<WorldStateFact> GetDiff(WorldState other);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldState | other | The state to compare against |
##### Returns
| Type | Description |
| :--- | :--- |
| IReadOnlyList<WorldStateFact> | List containing the facts that differs from the other state |


#### 3.15 GetAllFacts() <a name="worldStateGetAllFacts"/>
Enumerate all current facts in this state
##### Declaration
```csharp
public IEnumerable<WorldStateFact> GetAllFacts();
```
##### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<WorldStateFact> | All the current facts in this state |