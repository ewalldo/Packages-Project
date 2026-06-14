# Agent
## Table of contents
- [Documentation](#documentation)
  - [GoapAgent](#goapAgent)
    - [WorldState](#goapAgentWorldState)
    - [Blackboard](#goapAgentBlackboard)
    - [State](#goapAgentState)
    - [ActiveGoal](#goapAgentActiveGoal)
    - [ActivePlan](#goapAgentActivePlan)
    - [ActiveAction](#goapAgentActiveAction)
    - [ExecutionEvents](#goapAgentExecutionEvents)
    - [GoalsParent](#goapAgentGoalsParent)
    - [ActionsParent](#goapAgentActionsParent)
    - [SensorsParent](#goapAgentSensorsParent)
    - [OnAgentStateChanged](#goapAgentOnAgentStateChanged)
    - [Tick()](#goapAgentTick)
    - [ForceReplan()](#goapAgentForceReplan)
    - [SetState()](#goapAgentSetState)
    - [RegisterComponent()](#goapAgentRegisterComponent)
    - [UnregisterComponent()](#goapAgentUnregisterComponent)
  - [AgentTickMode](#agentTickMode)
  - [GoapAgentConfig](#goapAgentConfig)
    - [PlannerSettings](#goapAgentConfigPlannerSettings)
    - [ReplanInterval](#goapAgentConfigReplanInterval)
    - [MaxConsecutivePlanFail](#goapAgentConfigMaxConsecutivePlanFail)
    - [GoalEvaluationInterval](#goapAgentConfigMaxGoalEvaluationInterval)
    - [AllowMidPlanGoalInterruption](#goapAgentConfigAllowMidPlanGoalInterruption)
    - [TickSensorsWhileIdle](#goapAgentConfigTickSensorsWhileIdle)
    - [TickMode](#goapAgentConfigTickMode)
    - [DebugLog](#goapAgentConfigDebugLog)
    - [DebugLogPlans](#goapAgentConfigDebugLogPlans)
    - [CreateDefault()](#goapAgentConfigCreateDefault)
  - [IAgentComponent](#iAgentComponent)
    - [Initialize()](#iAgentComponentInitialize)
    - [Tick()](#iAgentComponentTick)
    - [OnAgentStateChanged()](#iAgentComponentOnAgentStateChanged)
    - [Shutdown()](#iAgentComponentShutdown)
  - [AgentState](#agentState)

## Documentation <a name="documentation"/>
### 1 GoapAgent <a name="goapAgent"/>
Top-level MonoBehaviour that owns and orchestrates the full GOAP loop.
#### 1.1 WorldState <a name="goapAgentWorldState"/>
The agent's current live world state.
##### Declaration
```csharp
public WorldState WorldState;
```
##### Returns
| Type | Description |
| :--- | :--- |
| WorldState | The agent's current world state |


#### 1.2 Blackboard <a name="goapAgentBlackboard"/>
The shared blackboard for sensor/action data exchange.
##### Declaration
```csharp
public Blackboard Blackboard;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Blackboard | The agent's blackboard |


#### 1.3 State <a name="goapAgentState"/>
The agent's current high-level state.
##### Declaration
```csharp
public AgentState State;
```
##### Returns
| Type | Description |
| :--- | :--- |
| AgentState | The agent's current state |


#### 1.4 ActiveGoal <a name="goapAgentActiveGoal"/>
The goal currently being pursued. Null if none.
##### Declaration
```csharp
public IGoal ActiveGoal;
```
##### Returns
| Type | Description |
| :--- | :--- |
| IGoal | The agent's current goal |


#### 1.5 ActivePlan <a name="goapAgentActivePlan"/>
The plan currently being executed. Null if none.
##### Declaration
```csharp
public GoapPlan ActivePlan;
```
##### Returns
| Type | Description |
| :--- | :--- |
| GoapPlan | The agent's current plan |


#### 1.6 ActiveAction <a name="goapAgentActiveAction"/>
The action currently executing. Null if none.
##### Declaration
```csharp
public IAction ActiveAction;
```
##### Returns
| Type | Description |
| :--- | :--- |
| IAction | The agent's current action |


#### 1.7 ExecutionEvents <a name="goapAgentExecutionEvents"/>
PlanExecutor's events for external subscription.
##### Declaration
```csharp
public ExecutionEvents ExecutionEvents;
```
##### Returns
| Type | Description |
| :--- | :--- |
| ExecutionEvents | The agent's execution events |


#### 1.8 GoalsParent <a name="goapAgentGoalsParent"/>
The object which the goals are attached to it. If not set, will return the gameObject which GoapAgent is attached to it.
##### Declaration
```csharp
public GameObject GoalsParent;
```
##### Returns
| Type | Description |
| :--- | :--- |
| GameObject | The gameObject which the goals are attached |


#### 1.9 ActionsParent <a name="goapAgentActionsParent"/>
The object which the actions are attached to it. If not set, will return the gameObject which GoapAgent is attached to it.
##### Declaration
```csharp
public GameObject ActionsParent;
```
##### Returns
| Type | Description |
| :--- | :--- |
| GameObject | The gameObject which the actions are attached |


#### 1.10 SensorsParent <a name="goapAgentSensorsParent"/>
The object which the sensors are attached to it. If not set, will return the gameObject which GoapAgent is attached to it.
##### Declaration
```csharp
public GameObject SensorsParent;
```
##### Returns
| Type | Description |
| :--- | :--- |
| GameObject | The gameObject which the sensors are attached |


#### 1.11 OnAgentStateChanged <a name="goapAgentOnAgentStateChanged"/>
Event raised whenever the agent transitions to a new AgentState.
##### Declaration
```csharp
public event Action<AgentState, AgentState> OnAgentStateChanged;
```
##### Returns
| Type | Description |
| :--- | :--- |
| AgentState | The agent's state before the transition |
| AgentState | The agent's state after the transition |


#### 1.12 Tick() <a name="goapAgentTick"/>
Manually drives the agent by one tick.
##### Declaration
```csharp
public void Tick(float deltaTime);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | deltaTime | The delta time between updates in seconds |


#### 1.13 ForceReplan() <a name="goapAgentForceReplan"/>
Forces an immediate replan for the currently active goal.
##### Declaration
```csharp
public void ForceReplan();
```


#### 1.14 SetState() <a name="goapAgentSetState"/>
Sets the agent's state directly. Use to pause, disable, or resume the agent from external systems.
##### Declaration
```csharp
public void SetState(AgentState newState);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AgentState | newState | The new state for the agent to transition to |


#### 1.15 RegisterComponent() <a name="goapAgentRegisterComponent"/>
Registers a custom IAgentComponent to be driven by this agent's lifecycle.
##### Declaration
```csharp
public void RegisterComponent(IAgentComponent component);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| IAgentComponent | component | The component to be registered |


#### 1.16 UnregisterComponent() <a name="goapAgentUnregisterComponent"/>
Unregisters and shuts down a previously registered component.
##### Declaration
```csharp
public void UnregisterComponent(IAgentComponent component);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| IAgentComponent | component | The component to be unregistered |


### 2 AgentTickMode <a name="agentTickMode"/>
Controls which Unity update loop the GoapAgent uses to tick its subsystems.
##### Declaration
```csharp
public enum AgentTickMode;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Update | Agent ticks in Unity's Update() loop |
| FixedUpdate | Agent ticks in Unity's FixedUpdate() loop |
| Manual | The agent does not tick itself. An external system must call Tick() manually |


### 3 GoapAgentConfig <a name="goapAgentConfig"/>
Configuration asset for the GoapAgent.
Create one via Assets > Create > Scriptable Objects > GOAP > Agent Config and assign to the GoapAgent component in the Inspector.
#### 3.1 PlannerSettings <a name="goapAgentConfigPlannerSettings"/>
Planner configuration asset. Leave empty to use default settings.
##### Declaration
```csharp
public PlannerSettings PlannerSettings;
```
##### Returns
| Type | Description |
| :--- | :--- |
| PlannerSettings | The Agent's planner settings |


#### 3.2 ReplanInterval <a name="goapAgentConfigReplanInterval"/>
How often (in seconds) the agent re-evaluates its current goal's plans even if nothing obviously changed. Set to 0 to disable periodic replanning.
##### Declaration
```csharp
public float ReplanInterval;
```
##### Returns
| Type | Description |
| :--- | :--- |
| float | The interval in seconds to re-evaluate agent's current goal's plan. Set to 0 to disable periodic replanning |


#### 3.3 MaxConsecutivePlanFail <a name="goapAgentConfigMaxConsecutivePlanFail"/>
How many consecutive planning failures are allowed before the agent enters PlanningFailed state and stops trying. -1 means unlimited retries.
##### Declaration
```csharp
public int MaxConsecutivePlanFail;
```
##### Returns
| Type | Description |
| :--- | :--- |
| int | The number of attemps to formulate a plan before giving up |


#### 3.4 GoalEvaluationInterval <a name="goapAgentConfigMaxGoalEvaluationInterval"/>
How often (in seconds) goal priority is re-evaluated. Lower values give more responsive goal switching at higher CPU cost.
##### Declaration
```csharp
public float GoalEvaluationInterval;
```
##### Returns
| Type | Description |
| :--- | :--- |
| float | The interval in seconds to re-evaluate agent's goal |


#### 3.5 AllowMidPlanGoalInterruption <a name="goapAgentConfigAllowMidPlanGoalInterruption"/>
If enabled, the agent will interrupt the current plan and replan immediately whenever goal selection produces a different goal.
If disabled, goal re-evaluation only triggers replanning after the current plan naturally ends.
##### Declaration
```csharp
public bool AllowMidPlanGoalInterruption;
```
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True to enable replan immediatelly when goal priority changes, false to keep plan until it finishes (be it by failure or completion) |


#### 3.6 TickSensorsWhileIdle <a name="goapAgentConfigTickSensorsWhileIdle"/>
If enabled, sensors tick even while the agent is in Planning or Idle states.
Recommended: true. Disabling saves CPU but may cause stale world state.
##### Declaration
```csharp
public bool TickSensorsWhileIdle;
```
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True to enable sensor update even when agent is not executing a plan, false to pause updates outside of executing states |


#### 3.7 TickMode <a name="goapAgentConfigTickMode"/>
Which Unity update loop drives this agent.
##### Declaration
```csharp
public AgentTickMode TickMode;
```
##### Returns
| Type | Description |
| :--- | :--- |
| AgentTickMode | The update loop that will tick Agent's update |


#### 3.8 DebugLog <a name="goapAgentConfigDebugLog"/>
If enabled, the agent logs every state transition and replan request in the console.
##### Declaration
```csharp
public bool DebugLog;
```
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True to display log messages. False to turn it off |


#### 3.9 DebugLogPlans <a name="goapAgentConfigDebugLogPlans"/>
If enabled, the agent logs the full plan each time a new one is formed.
##### Declaration
```csharp
public bool DebugLogPlans;
```
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True to display plan log messages. False to turn it off |


#### 3.10 CreateDefault() <a name="goapAgentConfigCreateDefault"/>
Creates a default GoapAgentConfig instance.
##### Declaration
```csharp
public static GoapAgentConfig CreateDefault();
```
##### Returns
| Type | Description |
| :--- | :--- |
| GoapAgentConfig | An instance of GoapAgentConfig containing default values |


### 4 IAgentComponent <a name="iAgentComponent"/>
Contract for any subsystem that can be registered with and driven by a GoapAgent.
Implementing this interface allows custom subsystems to hook into the agent's lifecycle.
#### 4.1 Initialize() <a name="iAgentComponentInitialize"/>
Called once when the GoapAgent initializes.
##### Declaration
```csharp
public void Initialize(GoapAgent agent);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GoapAgent | agent | The agent that owns this component |


#### 4.2 Tick() <a name="iAgentComponentTick"/>
Called every frame (or FixedUpdate) when the agent is Active.
##### Declaration
```csharp
public Tick(float deltaTime);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | deltaTime | The delta time between updates in seconds |


#### 4.3 OnAgentStateChanged() <a name="iAgentComponentOnAgentStateChanged"/>
Called when the agent transitions into a new AgentState.
##### Declaration
```csharp
public void OnAgentStateChanged(AgentState previousState, AgentState newState);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AgentState | previousState | The agent's state before the transition |
| AgentState | newState | The agent's new state after the transition |


#### 4.4 Shutdown() <a name="iAgentComponentShutdown"/>
Called once when the GoapAgent is destroyed or permanently disabled.
##### Declaration
```csharp
public void Shutdown();
```


### 5 AgentState <a name="agentState"/>
Describes the GoapAgent's current high-level operational state.
Drives which subsystems are ticked each frame and what decisions the agent is allowed to make.
This describes what the agent as a whole is doing.
##### Declaration
```csharp
public enum AgentState;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Uninitialized | The agent has been created but not yet initialized. No subsystems are running |
| Active | The agent is fully operational. Sensors tick, goals are evaluated, plans are formed and executed |
| SensingOnly | Sensors and goal selection are running, but planning and execution are paused |
| Idle | The agent found no valid, unsatisfied goal to pursue. Planning resumes when a goal becomes valid |
| Planning | The agent is currently waiting for the planner to return a result |
| PlanningFailed | The planner failed to find any plan for the active goal after exhausting all retry attempts defined in GoapAgentConfig |
| Disabled | All agent activity is suspended. No subsystems tick |