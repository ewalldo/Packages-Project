# Sensing
## Table of contents
- [Documentation](#documentation)
  - [GoapSensor](#goapSensor)
    - [Name](#goapSensorName)
    - [IsEnabled](#goapSensorIsEnabled)
    - [UpdateMode](#goapSensorUpdateMode)
    - [UpdateInterval](#goapSensorUpdateInterval)
    - [Initialize()](#goapSensorInitialize)
    - [UpdateSensor()](#goapSensorUpdateSensor)
    - [ForceUpdate()](#goapSensorForceUpdate)
    - [OnSensorEnabled()](#goapSensorOnSensorEnabled)
    - [OnSensorDisabled()](#goapSensorOnSensorDisabled)
    - [Teardown()](#goapSensorTeardown)
    - [UpdateSense()](#goapSensorUpdateSense)
  - [SensorUpdateMode](#sensorUpdateMode)
  - [SensorContext](#sensorContext)
    - [SensorContext()](#sensorContextConstructor)
    - [AgentObject](#sensorContextAgentObject)
    - [AgentTransform](#sensorContextAgentTransform)
    - [WorldState](#sensorContextWorldState)
    - [Blackboard](#sensorContextBlackboard)
    - [DeltaTime](#sensorContextDeltaTime)
    - [TotalTime](#sensorContextTotalTime)
  - [Blackboard](#blackboard)
    - [Blackboard()](#blackboardConstructor)
    - [OnValueChanged](#blackboardOnValueChanged)
    - [Set()](#blackboardSet)
    - [Remove()](#blackboardRemove)
    - [Clear()](#blackboardClear)
    - [Has()](#blackboardHas)
    - [TryGet()](#blackboardTryGet)
    - [Get()](#blackboardGet)
    - [GetKeys()](#blackboardGetKeys)

## Documentation <a name="documentation"/>
### 1 GoapSensor <a name="goapSensor"/>
Abstract MonoBehaviour base class for all GOAP sensors. Inherit from this to create concrete sensors and attach them as components on a GoapAgent's GameObject.
Implements the ISensor interface.
#### 1.1 Name <a name="goapSensorName"/>
Human-readable name for the sensor. Defaults to the class name if left empty.
##### Declaration
```csharp
public string Name;
```
##### Returns
| Type | Description |
| :--- | :--- |
| string | Human-readable name for the sensor. Defaults to the class name if empty |


#### 1.2 IsEnabled <a name="goapSensorIsEnabled"/>
Whether this sensor is currently active and should be ticked. Disabled sensors are skipped entirely by the GoapAgent.
##### Declaration
```csharp
public bool IsEnabled;
```
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the sensor is currently enabled, false otherwise |


#### 1.3 UpdateMode <a name="goapSensorUpdateMode"/>
Defines when a sensor performs its update logic.
##### Declaration
```csharp
public SensorUpdateMode UpdateMode;
```
##### Returns
| Type | Description |
| :--- | :--- |
| SensorUpdateMode | The update mode for this sensor |


#### 1.4 UpdateInterval <a name="goapSensorUpdateInterval"/>
Time in seconds between updates when UpdateMode is Interval. Ignored for EveryFrame and Manual modes.
##### Declaration
```csharp
public float UpdateInterval;
```
##### Returns
| Type | Description |
| :--- | :--- |
| float | Time in seconds between updates for Interval's UpdateMode |


#### 1.5 Initialize() <a name="goapSensorInitialize"/>
Called once by the GoapAgent when the agent initializes. Use to cache references, pre-allocate buffers, or subscribe to events.
Always call base.Initialize() when overriding.
##### Declaration
```csharp
public virtual void Initialize(SensorContext context);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| SensorContext | context | The context carrying all runtime data a sensor needs during execution. Sensors should read and write to this context |


#### 1.6 UpdateSensor() <a name="goapSensorUpdateSensor"/>
Entry point called by the GoapAgent on each update for active sensors.
##### Declaration
```csharp
public void UpdateSensor(SensorContext context);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| SensorContext | context | The context carrying all runtime data a sensor needs during execution. Sensors should read and write to this context |


#### 1.7 ForceUpdate() <a name="goapSensorForceUpdate"/>
Forces an immediate sensor update regardless of UpdateMode or interval. Only works when the sensor is enabled and initialized.
##### Declaration
```csharp
public void ForceUpdate(SensorContext context);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| SensorContext | context | The context carrying all runtime data a sensor needs during execution. Sensors should read and write to this context |


#### 1.8 OnSensorEnabled() <a name="goapSensorOnSensorEnabled"/>
Called when this sensor is enabled after being disabled.
Always call base.OnSensorEnabled() when overriding.
##### Declaration
```csharp
public void OnSensorEnabled();
```


#### 1.9 OnSensorDisabled() <a name="goapSensorOnSensorDisabled"/>
Called when this sensor is disabled.
Always call base.OnSensorDisabled() when overriding.
##### Declaration
```csharp
public void OnSensorDisabled();
```


#### 1.10 Teardown() <a name="goapSensorTeardown"/>
Called once by the GoapAgent when it is destroyed or disabled permanently.
Always call base.Teardown() when overriding.
##### Declaration
```csharp
public void Teardown();
```


#### 1.11 UpdateSense() <a name="goapSensorUpdateSense"/>
Override to define this action's preconditions.
Override to implement the actual perception logic for this sensor. Read from the game world and write results into context.WorldState and/or context.Blackboard.
##### Declaration
```csharp
/// example:
/// protected override void UpdateSense(SensorContext context)
/// {
///     bool canSeeEnemy = Physics.Linecast(context.AgentTransform.position, _enemy.position);
///     context.WorldState.Set(WorldKeys.IsEnemyVisible, canSeeEnemy);
///     context.Blackboard.Set("NearestEnemy", canSeeEnemy ? _enemy : null);
/// }
public abstract void UpdateSense(SensorContext context);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| SensorContext | context | The context carrying all runtime data a sensor needs during execution. Sensors should read and write to this context |


### 2 SensorUpdateMode <a name="sensorUpdateMode"/>
Defines when a sensor performs its update logic. Set per-sensor in the Inspector to balance accuracy vs performance.
##### Declaration
```csharp
public enum SensorUpdateMode;
```
##### Returns
| Type | Description |
| :--- | :--- |
| EveryFrame | The sensor updates every single frame. Use for time-critical perceptions that cannot afford any delay. |
| Interval | The sensor updates at a fixed time interval defined by UpdateInterval. The recommended default for most sensors. |
| Manual | The sensor only updates when UpdateSensor() is called explicitly. Use when perception is event-driven. |


### 3 SensorContext <a name="sensorContext"/>
#### 3.1 SensorContext() <a name="sensorContextConstructor"/>
Class to carries all runtime data a sensor needs during its update.
Sensors should read and write to this context rather than caching direct references to agent internals.
##### Declaration
```csharp
public SensorContext(GameObject agentObject, WorldState worldState, Blackboard blackboard);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GameObject | agentObject | The main game object of the agent |
| WorldState | worldState | The agent's world state |
| Blackboard | blackboard | The agent's blackboard |


#### 3.2 AgentObject <a name="sensorContextAgentObject"/>
The main GameObject that owns the GoapAgent running this sensor
##### Declaration
```csharp
public GameObject AgentObject;
```
##### Returns
| Type | Description |
| :--- | :--- |
| GameObject | The agent's main GameObject |


#### 3.3 AgentTransform <a name="sensorContextAgentTransform"/>
The Transform of the main agent. Convenience shortcut to AgentObject.transform
##### Declaration
```csharp
public Transform AgentTransform;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Transform | The agent's main GameObject Transform |


#### 3.4 WorldState <a name="sensorContextWorldState"/>
The agent's live world state where Sensors can read and write during execution.
##### Declaration
```csharp
public WorldState WorldState;
```
##### Returns
| Type | Description |
| :--- | :--- |
| WorldState | The agent's current world state |


#### 3.5 Blackboard <a name="sensorContextBlackboard"/>
The agent's blackboard state where Sensors can read and write during execution.
##### Declaration
```csharp
public Blackboard Blackboard;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Blackboard | The agent's blackboard instance |


#### 3.6 DeltaTime <a name="sensorContextDeltaTime"/>
The delta time for the current tick.
##### Declaration
```csharp
public float DeltaTime;
```
##### Returns
| Type | Description |
| :--- | :--- |
| float | The interval in seconds from the last frame to the current one |


#### 3.7 TotalTime <a name="sensorContextTotalTime"/>
Total time elapsed since this agent was started and the sensor was active.
##### Declaration
```csharp
public float TotalTime;
```
##### Returns
| Type | Description |
| :--- | :--- |
| float | Time in seconds since the agent has started and the sensor was active |


### 4 Blackboard <a name="blackboard"/>
#### 4.1 Blackboard() <a name="blackboardConstructor"/>
A generic key-value store shared across sensors, actions, and goals on a single agent. Allows data sharing without direct coupling.
Sensors are the primary writers, actions and goals are the primary readers.
##### Declaration
```csharp
public Blackboard(int capacity = 16);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | capacity | The maximum number of key-values that it can hold |


#### 4.2 OnValueChanged <a name="blackboardOnValueChanged"/>
Raised when any value on the blackboard changes. Key is the changed entry's key, value is the new value.
##### Declaration
```csharp
public event Action<string, object> OnValueChanged;
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | key | The key which the value has changed |
| object | value | The new value associated with the key |


#### 4.3 Set() <a name="blackboardSet"/>
Writes a value to the blackboard under the given key.
##### Declaration
```csharp
public void Set<T>(string key, T value);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | key | The key to set the value |
| T | value | The new value associated with the key |


#### 4.4 Remove() <a name="blackboardRemove"/>
Removes an entry from the blackboard if it exists.
##### Declaration
```csharp
public void Remove(string key);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | key | The key which to remove from the blackboard |


#### 4.5 Clear() <a name="blackboardClear"/>
Removes all entries from the blackboard
##### Declaration
```csharp
public void Clear();
```


#### 4.6 Has() <a name="blackboardHas"/>
Checks if a specific key exists in the blackboard.
##### Declaration
```csharp
public bool Has(string key);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | key | The key to check if exists |
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True if exists in the blackboard, false otherwise |


#### 4.7 TryGet() <a name="blackboardTryGet"/>
Tries to retrieve a value by key, casting it to the expected type T.
##### Declaration
```csharp
public bool TryGet<T>(string key, out T value);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | key | The key to check if exists |
| T | value | The value associated with the key, if it does not exists, returns the default for the type |
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True if exists in the blackboard and the type matches, false otherwise |


#### 4.8 Get() <a name="blackboardGet"/>
Returns the value for a key, or a default value if not found.
##### Declaration
```csharp
public T Get<T>(string key, T defaultValue = default);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | key | The key to check if exists |
| T | value | The value to return if the key does not exist in the blackboard |
##### Returns
| Type | Description |
| :--- | :--- |
| T | The value associated with the key if exists in the blackboard, otherwise returns the defaultValue parameter |


#### 4.9 GetKeys() <a name="blackboardGetKeys"/>
Returns all currently stored keys of the blackboard.
##### Declaration
```csharp
public IEnumerable<string> GetKeys();
```
##### Returns
| Type | Description |
| :--- | :--- |
| IEnumerable<string> | The keys that are currently stored in the blackboard |