# Execution
## Table of contents
- [Documentation](#documentation)
  - [PlanExecutor](#planExecutor)
    - [PlanExecutor()](#planExecutorConstructor)
    - [CurrentPlan](#planExecutorCurrentPlan)
    - [CurrentAction](#planExecutorCurrentAction)
    - [CurrentActionContext](#planExecutorCurrentActionContext)
    - [State](#planExecutorState)
    - [Events](#planExecutorEvents)
    - [IsRunning](#planExecutorIsRunning)
    - [StartPlan()](#planExecutorStartPlan)
    - [Tick()](#planExecutorTick)
    - [InterruptPlan()](#planExecutorInterruptPlan)
    - [Reset()](#planExecutorReset)
  - [PlanInterruptReason](#planInterruptReason)
  - [ExecutorState](#executorState)
  - [ExecutionEvents](#executionEvents)
    - [ExecutionEvents()](#executionEventsConstructor)
    - [OnPlanStarted](#executionEventsOnPlanStarted)
    - [OnPlanSucceeded](#executionEventsOnPlanSucceeded)
    - [OnPlanFailed](#executionEventsOnPlanFailed)
    - [OnPlanInterrupted](#executionEventsOnPlanInterrupted)
    - [OnActionStarted](#executionEventsOnActionStarted)
    - [OnActionCompleted](#executionEventsOnActionCompleted)
    - [OnActionFailed](#executionEventsOnActionFailed)

## Documentation <a name="documentation"/>
### 1 PlanExecutor <a name="planExecutor"/>
#### 1.1 PlanExecutor() <a name="planExecutorConstructor"/>
Concrete plan executor that steps through a GoapPlan's action sequence.
##### Declaration
```csharp
public PlanExecutor(ActionContext actionContext, bool debugLog = false);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| ActionContext | actionContext | The context carrying all runtime data an action needs during execution |
| bool | debugLog | True to display Executor log messages during execution. False to turn it off |


#### 1.2 CurrentPlan <a name="planExecutorCurrentPlan"/>
The current plan being executed.
##### Declaration
```csharp
public GoapPlan CurrentPlan;
```
##### Returns
| Type | Description |
| :--- | :--- |
| GoapPlan | The current plan being executed |


#### 1.3 CurrentAction <a name="planExecutorCurrentAction"/>
The current action from the plan which is being executed.
##### Declaration
```csharp
public IAction CurrentAction;
```
##### Returns
| Type | Description |
| :--- | :--- |
| IAction | The current action from the plan which is being executed |


#### 1.4 CurrentActionContext <a name="planExecutorCurrentActionContext"/>
The action context shared by all the actions.
##### Declaration
```csharp
public ActionContext CurrentActionContext;
```
##### Returns
| Type | Description |
| :--- | :--- |
| ActionContext | The context carrying all runtime data an action needs during execution |


#### 1.5 State <a name="planExecutorState"/>
The internal state of the PlanExecutor's own state machine.
##### Declaration
```csharp
public ExecutorState State;
```
##### Returns
| Type | Description |
| :--- | :--- |
| ExecutorState | The current execution state of the Executor |


#### 1.6 Events <a name="planExecutorEvents"/>
Event hub for plan and action lifecycle notifications.
##### Declaration
```csharp
public ExecutionEvents Events;
```
##### Returns
| Type | Description |
| :--- | :--- |
| ExecutionEvents | The ExecutionEvents instance that raise plan and action lifecycle events  |


#### 1.7 IsRunning <a name="planExecutorIsRunning"/>
Whether the executor currently has an active plan running
##### Declaration
```csharp
public bool IsRunning;
```
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the executor is currently executing a plan, false otherwise  |


#### 1.8 StartPlan() <a name="planExecutorStartPlan"/>
Loads a new plan and begins execution on the next Tick(). If a plan is already running it will be interrupted first.
##### Declaration
```csharp
public void StartPlan(GoapPlan plan, PlanInterruptReason interruptReason = PlanInterruptReason.Replanned);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GoapPlan | plan | The plan to execute |
| PlanInterruptReason | interruptReason | The reason given to the current plan if one is already running |


#### 1.9 Tick() <a name="planExecutorTick"/>
Advances execution by one tick. Must be called every frame by the GoapAgent while a plan is active.
##### Declaration
```csharp
public Tick();
```


#### 1.10 InterruptPlan() <a name="planExecutorInterruptPlan"/>
Aborts the current plan and stops the active action immediately.
##### Declaration
```csharp
public void InterruptPlan(PlanInterruptReason reason);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| PlanInterruptReason | reason | The reason given to the current plan if one is already running |


#### 1.11 Reset() <a name="planExecutorReset"/>
Resets the executor fully back to Idle state. Automatically called after a plan ends (success or failure) before starting a new one.
##### Declaration
```csharp
public void Reset();
```


### 2 PlanInterruptReason <a name="planInterruptReason"/>
Describes why a plan was interrupted before it could complete naturally.
##### Declaration
```csharp
public enum PlanInterruptReason;
```
##### Returns
| Type | Description |
| :--- | :--- |
| GoalChanged | The active goal changed, making the current plan irrelevant |
| WorldStateInvalidated | The world state changed so significantly that the remaining actions can no longer be expected to reach the goal |
| Replanned | A new plan was computed for the same goal and is replacing this one |
| AgentStopped | The agent was disabled or destroyed mid-execution |


### 3 ExecutorState <a name="executorState"/>
Describes the internal state of the PlanExecutor's own state machine.
##### Declaration
```csharp
public enum ExecutorState;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Idle | No plan is loaded. The executor is idle and waiting |
| StartingAction | An action has been dequeued and is about to have OnStart() called. Lasts only one tick. |
| RunningAction | An action is actively running. OnTick() is being called every update |
| CompletingAction | The active action completed and the executor is transitioning to the next one. Lasts only one tick |
| PlanSucceeded | The plan finished successfully. Terminal state until reset |
| PlanFailed | The plan failed. Terminal state until reset |


### 4 ExecutionEvents <a name="executionEvents"/>
#### 4.1 ExecutionEvents() <a name="executionEventsConstructor"/>
Centralised event hub for plan and action lifecycle notifications.
##### Declaration
```csharp
public ExecutionEvents();
```


#### 4.2 OnPlanStarted <a name="executionEventsOnPlanStarted"/>
Raised when a new plan is accepted and execution begins.
##### Declaration
```csharp
public event Action<GoapPlan> OnPlanStarted;
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GoapPlan | plan | The full plan that has just started |


#### 4.3 OnPlanSucceeded <a name="executionEventsOnPlanSucceeded"/>
Raised when every action in a plan has completed successfully.
##### Declaration
```csharp
public event Action<GoapPlan> OnPlanSucceeded;
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GoapPlan | plan | The full plan that has just completed successfully |


#### 4.4 OnPlanFailed <a name="executionEventsOnPlanFailed"/>
Raised when execution is aborted due to an action failure.
##### Declaration
```csharp
public event Action<GoapPlan, IAction> OnPlanFailed;
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GoapPlan | plan | The full plan that has just failed |
| IAction | action | The action that has caused the plan to fail |


#### 4.5 OnPlanInterrupted <a name="executionEventsOnPlanInterrupted"/>
Raised when execution is cancelled externally (e.g. the goal changed, the agent was disabled).
##### Declaration
```csharp
public event Action<GoapPlan, PlanInterruptReason> OnPlanInterrupted;
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GoapPlan | plan | The full plan that has just been interrupted |
| PlanInterruptReason | reason | The reason for the current plan to be interrupted |


#### 4.6 OnActionStarted <a name="executionEventsOnActionStarted"/>
Raised just after an action's OnStart() is called.
##### Declaration
```csharp
public event Action<IAction> OnActionStarted;
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| IAction | action | The action that has just started |


#### 4.7 OnActionCompleted <a name="executionEventsOnActionCompleted"/>
Raised just after an action's OnStop() is called with Completed reason.
##### Declaration
```csharp
public event Action<IAction> OnActionCompleted;
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| IAction | action | The action that has just completed |


#### 4.8 OnActionFailed <a name="executionEventsOnActionFailed"/>
Raised just after an action's OnStop() is called with Failed reason.
##### Declaration
```csharp
public event Action<IAction> OnActionFailed;
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| IAction | action | The action that has just failed to complete |