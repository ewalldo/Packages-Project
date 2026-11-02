# GOAP System
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Setting up a GoapAgent](#settingUpAGoapAgent)
  - [Agent configuration](#agentConfiguration)
  - [Defining World States/Keys](#definingWorldStatesKeys)
  - [Creating goals](#creatingGoals)
  - [Creating actions](#creatingActions)
  - [Creating sensors](#creatingSensors)
- [Documentation](#documentation)
  - [Actions](#documentationActions)
  - [Agent](#documentationAgent)
  - [Execution](#documentationExecution)
  - [Goals](#documentationGoals)
  - [Planning](#documentationPlanning)
  - [Sensing](#documentationSensing)
  - [WorldStates](#documentationWorldStates)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
Goal Oriented Action Planning (GOAP) is a technique used to create AI in games, allowing the creation of complex behavior for any non-playable character.  
The idea is to break down a complex goal into a series of actions that an agent can perform, and these actions are then organized into a sequence that will move the agent towards achieving their desired goal.  
The main advantage of GOAP when compared to other game AI techniques like FSM or Behavior Trees, is that the developer does not need to implement or define the transitions between each action or state, GOAP will automatically do that at runtime. By doing that it will not only reduce the complexity that the developer needs to implement, as it will not need to cover every case, but will also allows the NPCs to dinamically adapt to changes and create a more realistic behavior.  
This package was created to simplify the process of creating GOAP agents in Unity, with easy to use and simplicity in mind, it allows developers to quickly define goals, actions and sensors by just inheriting from specific classes, making the implementation of complex behaviors be straightforward.  
Additionally, configurations assets can be used to create specific settings that can be shared within a group of agents, allowing different agents to have different configuration based on their needs. This does not only allows more customization, but also makes edit groups of agents easier, as it only needs to edit one file and the changes will propagate to all agents that uses the same asset.  
Lastly, performance was taken into consideration during the development of this package. Many classes were optimized to ensure lower memory usage and faster execution.  

This package has been created with Unity 6000.3.9f1. However, it should work without issue with earlier or future versions of Unity.  
Please let us know if you encounter any issues with the version of Unity you are using.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Easy of use: goals, actions and sensors can be quickly implemented by only inheriting from specific classes.
- Efficient implementation of pathfinding algorithm (A*) to find the optimal sequence of actions.
- Settings as scriptableObjects allowing the creation of isolated agent settings, That way not only agents can share settings if desired, but also makes the swap/edit for new settings easier.
- Custom editor displaying goal, action, sensor, world state, blackboard and other information during runtime for easier debugging.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Setting up a GoapAgent <a name="settingUpAGoapAgent"/>
To create a GOAP agent, you only need to attach the GoapAgent.cs script to a GameObject, and set the configuration file. For more details on the configuration file, please check the section 4.2 below.  
Additionally, if necessary, the following optional references can also be set in the Inspector.  
- Agent Object: The main gameObject to pass as context to Actions and Sensors. If not set, will use the gameObject which the GoapAgent script is attached to.
- Goals Parent: The object which the goals are attached to it. If not set, will use the gameObject which the GoapAgent script is attached to.
- Actions Parent: The object which the actions are attached to it. If not set, will use the gameObject which the GoapAgent script is attached to.
- Sensors Parent: The object which the sensors are attached to it. If not set, will use the gameObject which the GoapAgent script is attached to.

### 4.2 Agent configuration <a name="agentConfiguration"/>
An agent configuration file can be created by right-clicking the Project window and selecting "Create -> Scriptable Objects -> GOAP -> Agent Config".  
This will generate a configuration scriptableObject that can be attached to any GoapAgent.  
Below is the details regarding each parameters in the agent configuration file:
- Planner Settings: Planner configuration asset. Leave empty to use default settings. Details on the Planner Settings configuration file can be found below.
- Replan Interval: How often (in seconds) the agent re-evaluates its goal and replans even if nothing obviously changed. Set to 0 to disable periodic replanning.
- Max Consecutive Plan Failures: How many consecutive planning failures are allowed before the agent enters PlanningFailed state and stops trying. -1 means unlimited retries.
- Goal Evaluation Interval: How often (in seconds) goal priority is re-evaluated. Lower values give more responsive goal switching at higher CPU cost.
- Allow Mid Plan Goal Interruption: If enabled, the agent will interrupt the current plan and replan immediately whenever goal selection produces a different goal. If disabled, goal re-evaluation only triggers replanning after the current plan naturally ends.
- Tick Sensors While Idle: If enabled, sensors tick even while the agent is in Planning or Idle states. Recommended: true. Disabling saves CPU but may cause stale world state.
- Tick Mode: Which Unity update loop drives this agent.
- Debug Log: If enabled, the agent logs every state transition and replan request.
- Debug Log Plans: If enabled, the agent logs the full plan each time a new one is formed.

The Planner Settings configuration file can be created similarly by right-clicking the Project window and selecting "Create -> Scriptable Objects -> GOAP -> Planner Settings".  
Below is the details regarding each parameters in the planner configuration file:
- Max Iterations: Maximum number of nodes the planner may expand before giving up. Prevents infinite loops on unsolvable goals.
- Max Plan Length: Maximum number of actions allowed in a single plan. Prevents the planner from finding absurdly long plans.
- Heuristic Weight: Weight applied to the heuristic component of the f-cost (f = g + weight * h). 1.0 = standard A*. Higher values = faster but less optimal (weighted A*).
- Debug Log: If enabled, the planner will log search details to the console.


### 4.3 Defining World States/Keys <a name="definingWorldStatesKeys"/>
World states are widely used throughout this package. Goals, actions, sensors and many other places makes use of them.  
They are stored as a mutable key-value structure (Dictionary) to allow for efficient retrieval, and instead of using string as many GOAP implementation uses, this packages utilizes a WorldStateKey structure as a key, allowing better performance and eliminating typo errors that commonly happens when using strings instead.  
WorldStateKey are intended to be stored as static readonly fields to avoid repeated allocations and easier access.
```csharp
public static readonly WorldStateKey IsEnemyVisible = new WorldStateKey("IsEnemyVisible");
public static readonly WorldStateKey IsEnergyLow = new WorldStateKey("IsEnergyLow");
```

### 4.4 Creating goals <a name="creatingGoals"/>
In order to implement a Goal, just inherit from the abstract MonoBehaviour base class "GoapGoal" and attach them as components on a GoapAgent's GameObject or on the "Goals Parent" GameObject that was set in the GoapAgent.  
The concrete goal subclass must implement the following methods:
- GetPriority()       : return how important this goal is right now.
- IsValid()           : return whether this goal should be considered.
- BuildDesiredState() : define what world state this goal desires.

Optionally, the subclass can override the following methods:
- IsSatisfied()       : checks if the current state already satisfies the goal's desired state
- OnGoalActivated()   : called when this goal becomes the active goal. Always call base.OnGoalActivated() when overriding.
- OnGoalDeactivated() : called when this goal is deactivated. Always call base.OnGoalDeactivated() when overriding.
```csharp
public class KillPlayerGoal : GoapGoal
{
    [SerializeField] private float _basePriority = 5f;

    public override float GetPriority(WorldState currentState, Blackboard blackboard)
    {
        // Can return a static value, or it can be calculated dynamically based on WorldState and/or Blackboard values. 
        // This example returns a static priority, but for example, it could have read the player's health from the Blackboard and returns a higher priority when the player's health is low. 
        return _basePriority;
    }

    public override bool IsValid(WorldState currentState)
    {
        // This goal is only valid when the player is visible AND not dead.
        return currentState.GetBool(EnemyWorldKeys.IsPlayerVisible) && !currentState.GetBool(EnemyWorldKeys.IsPlayerDead);
    }

    protected override void BuildDesiredState(WorldState desiredState)
    {
        // The desired state for this goal: to IsPlayerDead to be true.
        desiredState.Set(EnemyWorldKeys.IsPlayerDead, true);
    }
}
```

### 4.5 Creating actions <a name="creatingActions"/>
In order to implement an Action, just inherit from the abstract MonoBehaviour base class "GoapAction" and attach them as components on a GoapAgent's GameObject or on the "Actions Parent" GameObject that was set in the GoapAgent.  
The concrete action subclass must implement the following methods:
- BuildPreconditions()  : define what must be true before this action runs
- BuildEffects()        : define what becomes true after this action runs
- OnTick()              : the per-frame execution logic

Optionally, the subclass can override the following methods:
- GetCost()             : return a dynamic cost (default is _baseCost)
- IsExecutable()        : runtime pre-execution validation (default is true)
- OnStart()             : called once before the first tick. Always call base.OnStart() when overriding.
- OnStop()              : called once after the last tick. Always call base.OnStop() when overriding.
```csharp
public class AttackPlayerAction : GoapAction
{
    public override ActionStatus OnTick(ActionContext context)
    {
        // Action fails if the player gets out of range
        if (!context.CurrentWorldState.GetBool(EnemyWorldKeys.IsPlayerInRange))
            return Fail();

        // Simulate attack by asssuming it takes 2 seconds to complete.
        if (context.TimeSinceActionStarted >= 2f)
            return Complete();

        return Continue();
    }

    protected override void BuildEffects(List<WorldStateFact> effects)
    {
        // The effects that will be applied to the WorldState when this actions complete successfully.
        // In this example, kill the player when the attack is successfully completed.
        effects.Add(WorldStateFact.Create(EnemyWorldKeys.IsPlayerDead, true));
    }

    protected override void BuildPreconditions(List<WorldStateFact> preconditions)
    {
        // The conditions necessary for this action to be considered when creating a plan.
        // In this example, the player must be in attack range, visible AND not dead.
        preconditions.Add(WorldStateFact.Create(EnemyWorldKeys.IsPlayerInRange, true));
        preconditions.Add(WorldStateFact.Create(EnemyWorldKeys.IsPlayerVisible, true));
        preconditions.Add(WorldStateFact.Create(EnemyWorldKeys.IsPlayerDead, false));
    }
}
```

### 4.6 Creating sensors <a name="creatingSensors"/>
In order to implement a Sensor, just inherit from the abstract MonoBehaviour base class "GoapSensor" and attach them as components on a GoapAgent's GameObject or on the "Sensors Parent" GameObject that was set in the GoapAgent.  
The concrete sensor subclass must implement the following method:
- UpdateSense() : read from the game world, write to WorldState and/or Blackboard

Optionally, the subclass can override the following methods:
- Initialize()       : cache references or subscribe to events. Always call base.Initialize() when overriding.
- OnSensorEnabled()  : resume after being re-enabled. Always call base.OnSensorEnabled() when overriding.
- OnSensorDisabled() : pause or release when disabled. Always call base.OnSensorDisabled() when overriding.
- Teardown()         : full cleanup on agent destruction. Always call base.Teardown() when overriding.
```csharp
// Sensor to check if the enemy is at a cover position.
// Can be used in a situation where the enemy can only heal or attack from cover.
public class EnemyCoverSensor : GoapSensor
{
    [SerializeField] private Transform[] _coversPositions;
    private float _stoppingDistance = 0.5f;

    public override void Initialize(SensorContext context)
    {
        // write the cover positions to the blackboard, so an action can read it from if necessary.
        // for example, a MoveToCover action can read all the positions and select the closest one to move towards.
        base.Initialize(context);
        context.Blackboard.Set("CoversPosition", _coversPositions);
    }

    public override void UpdateSense(SensorContext context)
    {
        // write to the world state indicating if the current position is at any cover location or not.
        // optionally, can also write to the blackboard which one is the closest one for example.
        foreach (Transform cover in _coversPositions)
        {
            float distanceToCover = Vector3.Distance(context.AgentTransform.position, cover.position);
            if (distanceToCover < _stoppingDistance)
            {
                context.WorldState.Set(EnemyWorldKeys.IsAtCover, true);
                return;
            }
        }

        context.WorldState.Set(EnemyWorldKeys.IsAtCover, false);
    }
}
```

## 5 - Documentation <a name="documentation"/>
In order to keep the documentation more managable, I have divided it into into sub documents based on the namespaces included in this package. If you want more details regarding specific methods, please check the corresponding file.
* [Actions](Actions.md) <a name="documentationActions">
* [Agent](Agent.md) <a name="documentationAgent">
* [Execution](Execution.md) <a name="documentationExecution">
* [Goals](Goals.md) <a name="documentationGoals">
* [Planning](Planning.md) <a name="documentationPlanning">
* [Sensing](Sensing.md) <a name="documentationSensing">
* [WorldStates](WorldStates.md) <a name="documentationWorldStates">

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com