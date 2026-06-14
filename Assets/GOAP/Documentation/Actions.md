# Actions
## Table of contents
- [Documentation](#documentation)
  - [GoapAction](#goapAction)
    - [Name](#goapActionName)
    - [Preconditions](#goapActionPreconditions)
    - [Effects](#goapActionEffects)
    - [GetCost()](#goapActionGetCost)
    - [IsExecutable()](#goapActionIsExecutable)
    - [OnStart()](#goapActionOnStart)
    - [OnTick()](#goapActionOnTick)
    - [OnStop()](#goapActionOnStop)
    - [BuildPreconditions()](#goapActionBuildPreconditions)
    - [BuildEffects()](#goapActionBuildEffects)
  - [ActionStatus](#actionStatus)
  - [ActionStopReason](#actionStopReason)
  - [ActionContext](#actionContext)
    - [ActionContext()](#actionContextConstructor)
    - [AgentObject](#actionContextAgentObject)
    - [AgentTransform](#actionContextAgentTransform)
    - [CurrentWorldState](#actionContextCurrentWorldState)
    - [Blackboard](#actionContextBlackboard)
    - [TimeSinceActionStarted](#actionContextTimeSinceActionStarted)
    - [DeltaTime](#actionContextDeltaTime)

## Documentation <a name="documentation"/>
### 1 GoapAction <a name="goapAction"/>
Abstract MonoBehaviour base class for all GOAP actions. Inherit from this to create concrete actions and attach them as components on a GoapAgent's GameObject.
Implements the IAction interface.
#### 1.1 Name <a name="goapActionName"/>
Human-readable name for the action. Defaults to the class name if left empty.
##### Declaration
```csharp
public string Name;
```
##### Returns
| Type | Description |
| :--- | :--- |
| string | Human-readable name for the action. Defaults to the class name if empty |


#### 1.2 Preconditions <a name="goapActionPreconditions"/>
The world state facts that must be true for this action to be considered by the planner.
##### Declaration
```csharp
public IReadOnlyList<WorldStateFact> Preconditions;
```
##### Returns
| Type | Description |
| :--- | :--- |
| IReadOnlyList<WorldStateFact> | The world state facts for this action to be considered |


#### 1.3 Effects <a name="goapActionEffects"/>
The world state facts this action will produce when it completes.
##### Declaration
```csharp
public IReadOnlyList<WorldStateFact> Effects;
```
##### Returns
| Type | Description |
| :--- | :--- |
| IReadOnlyList<WorldStateFact> | The effects that this action will cause when completed successfully |


#### 1.4 GetCost() <a name="goapActionGetCost"/>
The cost of executing the action so the planner can use this to find the lowest-cost plan. Override to return a dynamic cost based on runtime state.
##### Declaration
```csharp
public virtual float GetCost(WorldState currentState);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldState | currentState | The agent's current world state at planning time |
#### Returns
| Type | Description |
| :--- | :--- |
| float | The cost value to execute this action, planner will prioritize the sequence of actions that cost the least to reach a specific goal |


#### 1.5 IsExecutable() <a name="goapActionIsExecutable"/>
A runtime check performed just before execution begins. Unlike preconditions (which are evaluated by the planner on simulated state), this is checked against the real world state at execution time.
Use this to catch edge cases that the planner's simulation could not foresee at planning time.
Example: checking if the target of this action has became invalid while performing a previous action in the plan.
Returns true by default.
##### Declaration
```csharp
public virtual bool IsExecutable(WorldState currentState);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldState | currentState | The agent's current world state right before starting this action |
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True if this action can be executed, false otherwise |


#### 1.6 OnStart() <a name="goapActionOnStart"/>
Called once when the PlanExecutor starts this action. Can be override for setup logic.
Always call base.OnStart() when overriding.
##### Declaration
```csharp
public virtual void OnStart(ActionContext context);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| ActionContext | context | The context carrying all runtime data an action needs during execution. Action should only read from the context and avoid writing to it |


#### 1.7 OnTick() <a name="goapActionOnTick"/>
Called on every update while this action is active.
Return Continue() to continue, Complete() to signal success, or Fail() to trigger a replan.
##### Declaration
```csharp
public abstract ActionStatus OnTick(ActionContext context);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| ActionContext | context | The context carrying all runtime data an action needs during execution. Action should only read from the context and avoid writing to it |
##### Returns
| Type | Description |
| :--- | :--- |
| ActionStatus | The result of the action after the current tick. Return Continue() to continue, Complete() to signal success, or Fail() to trigger a replan. |


#### 1.8 OnStop() <a name="goapActionOnStop"/>
Called once when the action is stopped, for any reason. Can be override for cleanup logic.
Always call base.OnStop() when overriding.
##### Declaration
```csharp
public virtual void OnStop(ActionContext context, ActionStopReason reason);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| ActionContext | context | The context carrying all runtime data an action needs during execution. Action should only read from the context and avoid writing to it |
| ActionStopReason | reason | The reason that has caused this action to stop |


#### 1.9 BuildPreconditions() <a name="goapActionBuildPreconditions"/>
Override to define this action's preconditions.
##### Declaration
```csharp
/// example:
/// protected override void BuildPreconditions(List<WorldStateFact> preconditions)
/// {
///     preconditions.Add(WorldStateFact.Create(WorldKeys.HasWeapon, true));
///     preconditions.Add(WorldStateFact.Create(WorldKeys.IsEnemyVisible, true));
/// }
protected abstract void BuildPreconditions(List<WorldStateFact> preconditions);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| List<WorldStateFact> | preconditions | The conditions that must be true for this action to execute |


#### 1.10 BuildEffects() <a name="goapActionBuildEffects"/>
Override to define this action's effects.
##### Declaration
```csharp
/// example:
/// protected override void BuildEffects(List<WorldStateFact> effects)
/// {
///     effects.Add(WorldStateFact.Create(WorldKeys.IsEnemyDead, true));
/// }
protected abstract void BuildEffects(List<WorldStateFact> effects);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| List<WorldStateFact> | effects | The effects that this action will to the world state when completed successfully |


### 2 ActionStatus <a name="actionStatus"/>
Represents the current execution state of a GoapAction.
##### Declaration
```csharp
public enum ActionStatus;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Idle | The action has not been started yet |
| Running | The action is currently executing |
| Completed | The action finished successfully and applied its effects |
| Failed | The action encountered an error, failed execution or its conditions were no longer met |


### 3 ActionStopReason <a name="actionStopReason"/>
Represents the current execution state of a GoapAction.
##### Declaration
```csharp
public enum ActionStopReason;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Completed | The action completed successfully on its own |
| PlanAborted | The action was stopped because the plan it belonged to was aborted |
| Failed | The action failed during execution and triggered a replan |
| ForcedStop | The action was forcibly stopped from the outside |


### 4 ActionContext <a name="actionContext"/>
#### 4.1 ActionContext() <a name="actionContextConstructor"/>
Class to carries all runtime data an action during execution.
Actions should read from this context rather than writing or caching direct references.
##### Declaration
```csharp
public ActionContext(GameObject agentObject, WorldState currentWorldState, Blackboard blackboard);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GameObject | agentObject | The main game object of the agent |
| WorldState | currentWorldState | The agent's world state |
| Blackboard | blackboard | The agent's blackboard |


#### 4.2 AgentObject <a name="actionContextAgentObject"/>
The main GameObject that owns the GoapAgent running this action
##### Declaration
```csharp
public GameObject AgentObject;
```
##### Returns
| Type | Description |
| :--- | :--- |
| GameObject | The agent's main GameObject |


#### 4.3 AgentTransform <a name="actionContextAgentTransform"/>
The Transform of the main agent. Convenience shortcut to AgentObject.transform
##### Declaration
```csharp
public Transform AgentTransform;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Transform | The agent's main GameObject Transform |


#### 4.4 CurrentWorldState <a name="actionContextCurrentWorldState"/>
The agent's live world state where Actions can read from this during execution.
##### Declaration
```csharp
public WorldState CurrentWorldState;
```
##### Returns
| Type | Description |
| :--- | :--- |
| WorldState | The agent's current world state |


#### 4.5 Blackboard <a name="actionContextBlackboard"/>
The agent's blackboard state where Actions can read from this during execution.
##### Declaration
```csharp
public Blackboard Blackboard;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Blackboard | The agent's blackboard instance |


#### 4.6 TimeSinceActionStarted <a name="actionContextTimeSinceActionStarted"/>
Time in seconds since the current action was started
##### Declaration
```csharp
public float TimeSinceActionStarted;
```
##### Returns
| Type | Description |
| :--- | :--- |
| float | Time in seconds since the action has started |


#### 4.7 DeltaTime <a name="actionContextDeltaTime"/>
The delta time for the current tick
##### Declaration
```csharp
public float DeltaTime;
```
##### Returns
| Type | Description |
| :--- | :--- |
| float | The interval in seconds from the last frame to the current one |