# Goals
## Table of contents
- [Documentation](#documentation)
  - [GoapGoal](#goapGoal)
    - [Name](#goapGoalname)
    - [DesiredState](#goapGoalDesiredState)
    - [GetPriority()](#goapGoalGetPriority)
    - [IsValid()](#goapGoalIsValid)
    - [IsSatisfied()](#goapGoalIsSatisfied)
    - [OnGoalActivated()](#goapGoalOnGoalActivated)
    - [OnGoalDeactivated()](#goapGoalOnGoalDeactivated)
    - [BuildDesiredState()](#goapGoalBuildDesiredState)
  - [GoalDeactivationReason](#goalDeactivationReason)
  - [GoalSelector](#goalSelector)
    - [GoalSelector()](#goalSelectorConstructor)
    - [CurrentGoal](#goalSelectorCurrentGoal)
    - [Goals](#goalSelectorGoals)
    - [RegisterGoal()](#goalSelectorRegisterGoal)
    - [UnregisterGoal()](#goalSelectorUnregisterGoal)
    - [ClearGoals()](#goalSelectorClearGoals)
    - [SelectBestGoal()](#goalSelectorSelectBestGoal)
    - [ClearCurrentGoal()](#goalSelectorClearCurrentGoal)

## Documentation <a name="documentation"/>
### 1 GoapGoal <a name="goapGoal"/>
Abstract MonoBehaviour base class for all GOAP goals. Inherit from this to create concrete goals and attach them as components on a GoapAgent's GameObject.
Implements the IGoal interface.
#### 1.1 Name <a name="goapGoalName"/>
Human-readable name for the goal. Defaults to the class name if left empty.
##### Declaration
```csharp
public string Name;
```
##### Returns
| Type | Description |
| :--- | :--- |
| string | Human-readable name for the goal. Defaults to the class name if empty |


#### 1.2 DesiredState <a name="goapGoalDesiredState"/>
The desired state that this goal wants to achieve
##### Declaration
```csharp
public WorldState DesiredState;
```
##### Returns
| Type | Description |
| :--- | :--- |
| WorldState | The desired state this goal wants to achieve |


#### 1.3 GetPriority() <a name="goapGoalGetPriority"/>
Priority score of this goal. Higher values win during goal selection. Can be static or dynamically computed based on the current world state or blackboard values.
##### Declaration
```csharp
public abstract float GetPriority(WorldState currentState, Blackboard blackboard);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldState | currentState | The agent's current world state at evaluation time |
| Blackboard | blackboard | The agent's current blackboard at evaluation time |
##### Returns
| Type | Description |
| :--- | :--- |
| float | The priority value of this goal, the higher the value, the bigger the priority |


#### 1.4 IsValid() <a name="goapGoalIsValid"/>
Whether this goal is currently relevant and eligible to be selected. An invalid goal is never selected, regardless of its priority.
##### Declaration
```csharp
public abstract bool IsValid(WorldState currentState);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldState | currentState | The agent's current world state at evaluation time |
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the goal is currently valid, false otherwise |


#### 1.5 IsSatisfied() <a name="goapGoalIsSatisfied"/>
Whether this goal has already been satisfied by the current world state. A satisfied goal should not be re-planned for.
##### Declaration
```csharp
public virtual bool IsSatisfied(WorldState currentState);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldState | currentState | The agent's current world state at evaluation time |
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the goal is currently satisfied, false otherwise |


#### 1.6 OnGoalActivated() <a name="goapGoalOnGoalActivated"/>
Called when this goal becomes the active goal.
Always call base.OnGoalActivated() when overriding.
##### Declaration
```csharp
public virtual void OnGoalActivated();
```


#### 1.7 OnGoalDeactivated() <a name="goapGoalOnGoalDeactivated"/>
Called when this goal is deactivated. Reason is provided so the goal can react differently to success vs interruption.
Always call base.OnGoalDeactivated() when overriding.
##### Declaration
```csharp
public virtual void OnGoalDeactivated(GoalDeactivationReason reason);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GoalDeactivationReason | reason | The reason why the goal was deactivated |


#### 1.8 BuildDesiredState() <a name="goapGoalBuildDesiredState"/>
Override this to define what world state this goal desires.
##### Declaration
```csharp
/// example:
/// protected override void BuildDesiredState(WorldState desiredState)
/// {
///     desiredState.Set(WorldKeys.IsEnemyDead, true);
/// }
protected abstract void BuildDesiredState(WorldState desiredState);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldState | desiredState | The desired state that this goal wants to achieve |


### 2 GoalDeactivationReason <a name="goalDeactivationReason"/>
Describes why a goal was deactivated.
##### Declaration
```csharp
public enum GoalDeactivationReason;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Completed | The goal was successfully completed (its desired state is satisfied) |
| Interrupted | A higher priority goal took over |
| Invalidated | The goal became invalid mid-execution (e.g. conditions changed) |
| PlanFailed | The planner failed to find any plan to achieve this goal |


### 3 GoalSelector <a name="goalSelector"/>
#### 3.1 GoalSelector() <a name="goalSelectorConstructor"/>
Evaluates all registered goals against the current world state and selects the highest-priority valid, unsatisfied goal.
##### Declaration
```csharp
public GoalSelector();
```


#### 3.2 CurrentGoal <a name="goalSelectorCurrentGoal"/>
The currently active goal. Null if none has been selected yet.
##### Declaration
```csharp
public IGoal CurrentGoal;
```
##### Returns
| Type | Description |
| :--- | :--- |
| IGoal | The currently active goal. Null if none has been selected yet |


#### 3.3 Goals <a name="goalSelectorGoals"/>
Read-only view of all registered goals.
##### Declaration
```csharp
public IReadOnlyList<IGoal> Goals;
```
##### Returns
| Type | Description |
| :--- | :--- |
| IReadOnlyList<IGoal> | Read-only view of all registered goals |


#### 3.4 RegisterGoal() <a name="goalSelectorRegisterGoal"/>
Registers a goal to be considered during selection.
##### Declaration
```csharp
public void RegisterGoal(IGoal goal);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| IGoal | goal | The goal to be registered |


#### 3.5 UnregisterGoal() <a name="goalSelectorUnregisterGoal"/>
Removes a previously registered goal.
##### Declaration
```csharp
public void UnregisterGoal(IGoal goal);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| IGoal | goal | The goal to be unregistered |


#### 3.6 ClearGoals() <a name="goalSelectorClearGoals"/>
Removes all registered goals and clears the current selection.
##### Declaration
```csharp
public void ClearGoals();
```


#### 3.7 SelectBestGoal() <a name="goalSelectorSelectBestGoal"/>
Evaluates all registered goals and selects the best one.
##### Declaration
```csharp
public GoalSelectionResult SelectBestGoal(WorldState currentState, Blackboard blackboard);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldState | currentState | The agent's current world state snapshot |
| Blackboard | blackboard | The agent's current blackboard snapshot |
##### Returns
| Type | Description |
| :--- | :--- |
| GoalSelectionResult | The result of a goal selection evaluation. Carries both the winning goal (if any) and the reason it was selected or not. |


#### 3.8 ClearCurrentGoal() <a name="goalSelectorClearCurrentGoal"/>
Forces the current goal to be deactivated without selecting a new one.
##### Declaration
```csharp
public void ClearCurrentGoal(GoalDeactivationReason reason)
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GoalDeactivationReason | reason | The reason to deactivate the current goal |