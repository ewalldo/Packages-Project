# Planning
## Table of contents
- [Documentation](#documentation)
  - [PlannerSettings](#plannerSettings)
    - [MaxIterations](#plannerSettingsMaxIterations)
    - [MaxPlanLength](#plannerSettingsMaxPlanLength)
    - [HeuristicWeight](#plannerSettingsHeuristicWeight)
    - [DebugLog](#plannerSettingsDebugLog)
    - [CreateDefault()](#plannerSettingsCreateDefault)
  - [GoapPlan](#goapPlan)
    - [Status](#goapPlanStatus)
    - [IsEmpty](#goapPlanIsEmpty)
    - [RemainingCount](#goapPlanRemainingCount)
    - [TotalCount](#goapPlanTotalCount)
    - [Actions](#goapPlanActions)
    - [Peek()](#goapPlanPeek)
    - [Dequeue()](#goapPlanDequeue)
    - [TryPeek()](#goapPlanTryPeek)
    - [TryDequeue()](#goapPlanTryDequeue)
  - [PlanStatus](#planStatus)
  - [GoapPlanner](#goapPlanner)
    - [GoapPlanner()](#goapPlannerConstructor)
    - [CreatePlan()](#goapPlannerCreatePlan)

## Documentation <a name="documentation"/>
### 1 PlannerSettings <a name="plannerSettings"/>
Configuration asset for the GoapPlanner.
Create one via Assets > Create > Scriptable Objects > GOAP > Planner Settings and assign it to the GoapAgentConfig in the Inspector.
#### 1.1 MaxIterations <a name="plannerSettingsMaxIterations"/>
Maximum number of nodes the planner may expand before giving up. Prevents infinite loops on unsolvable goals.
##### Declaration
```csharp
public int MaxIterations;
```
##### Returns
| Type | Description |
| :--- | :--- |
| int | The maximum number of nodes the planner can explore before giving up on a plan |


#### 1.2 MaxPlanLength <a name="plannerSettingsMaxPlanLength"/>
Maximum number of actions allowed in a single plan. Prevents the planner from finding absurdly long plans.
##### Declaration
```csharp
public int MaxPlanLength;
```
##### Returns
| Type | Description |
| :--- | :--- |
| int | The maximum number of action in a single plan |


#### 1.3 HeuristicWeight <a name="plannerSettingsHeuristicWeight"/>
Weight applied to the heuristic component of the f-cost (f = g + weight * h). 1.0 = standard A*. Higher values = faster but less optimal (weighted A*).
##### Declaration
```csharp
public float HeuristicWeight;
```
##### Returns
| Type | Description |
| :--- | :--- |
| float | The heuristic weight to be used on the planner |


#### 1.4 DebugLog <a name="plannerSettingsDebugLog"/>
If enabled, the planner will log search details to the console.
##### Declaration
```csharp
public bool DebugLog;
```
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True to display log messages during planning. False to turn it off |


#### 1.5 CreateDefault() <a name="plannerSettingsCreateDefault"/>
Creates a default PlannerSettings instance.
##### Declaration
```csharp
public static PlannerSettings CreateDefault();
```
##### Returns
| Type | Description |
| :--- | :--- |
| PlannerSettings | An instance of PlannerSettings containing default values |


### 2 GoapPlan <a name="goapPlan"/>
An ordered sequence of actions produced by the GoapPlanner and consumed sequentially by a PlanExecutor.
#### 2.1 Status <a name="goapPlanStatus"/>
Current lifecycle status of the plan.
##### Declaration
```csharp
public PlanStatus Status;
```
##### Returns
| Type | Description |
| :--- | :--- |
| PlanStatus | The current status of the plan |


#### 2.2 IsEmpty <a name="goapPlanIsEmpty"/>
Whether there are no remaining actions to execute in the plan.
##### Declaration
```csharp
public bool IsEmpty;
```
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True if there are zero actions remaining in the plan, false otherwise |


#### 2.3 RemainingCount <a name="goapPlanRemainingCount"/>
Number of actions remaining in the plan.
##### Declaration
```csharp
public int RemainingCount;
```
##### Returns
| Type | Description |
| :--- | :--- |
| int | The number of actions still remaining in the plan |


#### 2.4 TotalCount <a name="goapPlanTotalCount"/>
The total number of actions in the original plan (including already executed ones).
##### Declaration
```csharp
public int TotalCount;
```
##### Returns
| Type | Description |
| :--- | :--- |
| int | The total number of actions in the original plan |


#### 2.5 Actions <a name="goapPlanActions"/>
Read-only snapshot of all actions in the plan in execution order. Includes already-executed actions.
##### Declaration
```csharp
public IReadOnlyList<IAction> Actions;
```
##### Returns
| Type | Description |
| :--- | :--- |
| IReadOnlyList<IAction> | List containing the actions of the current plan |


#### 2.6 Peek() <a name="goapPlanPeek"/>
Returns the next action without removing it from the plan queue.
##### Declaration
```csharp
public IAction Peek();
```
##### Returns
| Type | Description |
| :--- | :--- |
| IAction | The action on the top of the queue |


#### 2.7 Dequeue() <a name="goapPlanDequeue"/>
Removes and returns the next action from the plan queue.
##### Declaration
```csharp
public IAction Dequeue();
```
##### Returns
| Type | Description |
| :--- | :--- |
| IAction | The action on the top of the queue |


#### 2.8 TryPeek() <a name="goapPlanTryPeek"/>
Tries to return the next action without removing it from the plan queue.
##### Declaration
```csharp
public bool TryPeek(out IAction action);
```
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True if there is an action in the queue, false otherwise |
| IAction | The action on the top of the queue. Defaults to null if queue is empty |


#### 2.9 TryDequeue() <a name="goapPlanTryDequeue"/>
Tries to remove and returns the next action from the plan queue.
##### Declaration
```csharp
public bool TryDequeue(out IAction action);
```
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True if there is an action in the queue, false otherwise |
| IAction | The action on the top of the queue. Defaults to null if queue is empty |


### 3 PlanStatus <a name="planStatus"/>
Represents the current lifecycle state of a GoapPlan.
##### Declaration
```csharp
public enum PlanStatus;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Idle | The plan has been created but execution has not started |
| Running | The plan is currently being executed |
| Succeeded | All actions in the plan completed successfully |
| Failed | An action in the plan failed, triggering a replan |
| Interrupted | The plan was cancelled externally (e.g. goal changed) |


### 4 GoapPlanner <a name="goapPlanner"/>
#### 4.1 GoapPlanner() <a name="goapPlannerConstructor"/>
A forward-search A* GOAP planner.
##### Declaration
```csharp
public GoapPlanner(PlannerSettings settings = null, IPlannerHeuristic heuristic = null);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| PlannerSettings | settings | Planner configuration. If null, defaults are used |
| IPlannerHeuristic | heuristic | Heuristic to guide search. If null, the default (UnsatisfiedConditionsHeuristic) is used |


#### 4.1 CreatePlan() <a name="goapPlannerCreatePlan"/>
Attempts to find a plan: a sequence of actions that, when executed in order, will transition the current world into a state that satisfies a goal.
##### Declaration
```csharp
public GoapPlan CreatePlan(WorldState currentState, IGoal goal, IReadOnlyList<IAction> availableActions);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| WorldState | currentState | The agent's current real world state |
| IGoal | goal | The goal whose DesiredState the plan must satisfy |
| IReadOnlyList<IAction> | availableActions | All actions the agent can potentially perform |
##### Returns
| Type | Description |
| :--- | :--- |
| GoapPlan | A GoapPlan instance containing an ordered sequence of actions, , or null if no plan exists |