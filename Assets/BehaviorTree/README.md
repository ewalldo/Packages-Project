# Behavior Tree System
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Setting up an agent to run a BehaviorTree](#SettingUpAnAgentToRunABehaviorTree)
  - [Creating an Action Node](#CreatingAnActionNode)
  - [Decorator node types](#DecoratorNodeTypes)
  - [Using the Service node](#UsingTheServiceNode)
  - [Using the Condition Guard node](#UsingTheConditionGuardNode)
  - [Creating a Condition Node](#CreatingAConditionNode)
  - [Composite node types](#CompositeNodeTypes)
  - [Visualize behavior trees](#VisualizeBehaviorTrees)
- [Documentation](#documentation)
  - [BehaviorTreeRunner](#behaviorTreeRunner)
    - [BehaviorTreeRunner.Tree](#behaviorTreeRunnerTree)
    - [BehaviorTreeRunner.Blackboard](#behaviorTreeRunnerBlackboard)
    - [BehaviorTreeRunner.Tick()](#behaviorTreeRunnerTick)
  - [BehaviorTree](#behaviorTree)
    - [BehaviorTree.Root](#behaviorTreeRoot)
    - [BehaviorTree.Blackboard](#behaviorTreeBlackboard)
    - [BehaviorTree.Context](#behaviorTreeContext)
    - [BehaviorTree.LastStatus](#behaviorTreeLastStatus)
    - [BehaviorTree.AddDebugger()](#behaviorTreeAddDebugger)
    - [BehaviorTree.RemoveDebugger()](#behaviorTreeRemoveDebugger)
    - [BehaviorTree.Tick()](#behaviorTreeTick)
    - [BehaviorTree.Abort()](#behaviorTreeAbort)
    - [BehaviorTree.ResetTree()](#behaviorTreeResetTree)
  - [BehaviorTreeContext](#behaviorTreeContext)
    - [BehaviorTreeContext.GameObject](#behaviorTreeContextGameObject)
    - [BehaviorTreeContext.Transform](#behaviorTreeContextTransform)
    - [BehaviorTreeContext.Blackboard](#behaviorTreeContextBlackboard)
    - [BehaviorTreeContext.BehaviorTree](#behaviorTreeContextBehaviorTree)
    - [BehaviorTreeContext.DeltaTime](#behaviorTreeContextDeltaTime)
    - [BehaviorTreeContext.AddDebugger()](#behaviorTreeContextAddDebugger)
    - [BehaviorTreeContext.RemoveDebugger()](#behaviorTreeContextRemoveDebugger)
  - [Blackboard](#blackboard)
    - [Blackboard.OnValueChanged](#blackboardOnValueChanged)
    - [Blackboard.Keys](#blackboardKeys)
    - [Blackboard.SetValue()](#blackboardSetValue)
    - [Blackboard.TryGetValue()](#blackboardTryGetValue)
    - [Blackboard.GetValueOrDefault()](#blackboardGetValueOrDefault)
    - [Blackboard.HasKey()](#blackboardHasKey)
    - [Blackboard.Remove()](#blackboardRemove)
    - [Blackboard.Clear()](#blackboardClear)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
A Behavior Tree is a hierarchical model used to design artificial intelligence and complex decision-making logic in games. Inspired by programming flowcharts, it organizes an agent's behavior into a structured tree of nodes, making AI logic modular, scalable, and easier to debug.  
Unlike traditional finite state machines (FSMs), behavior trees prevent messy transitions by breaking decisions down into clear priorities. They execute logic top-to-bottom and left-to-right using specialized node types like composites (controls execution flow), decorators (controls child outcomes) and action/condition (concrete implementation of behaviors) nodes.  
Ultimately, behavior trees shine because they decouple AI decision-making from the underlying game code. By allowing designers and programmers to easily mix, match, and reuse nodes, they transform game states into robust, reactive implementation resulting in more lifelike characters.  
This package was created to simplify the process of creating behavior trees in Unity, with easy to use and simplicity in mind, it allows developers to quickly define concrete trees, action/condition nodes by just inheriting from specific classes, making the implementation of complex behaviors be straightforward.  
Additionally, this package provides common features like Blackboard and Context in order to facilitate the manipulation of the data required for the execution of the behavor trees, and also editor tools for easily visualization of the tree's execution flow during runtime.  
Lastly, performance was taken into consideration during the development of this package. Many classes were optimized to ensure lower memory usage and faster execution.  

This package has been created with Unity 6000.3.9f1. However, it should work without issue with earlier or future versions of Unity.  
Please let us know if you encounter any issues with the version of Unity you are using.

*Support for graphical creation of Behavior Tree using node based approached is planned to be added with the next LTS version of Unity, as at the moment GraphToolkit package is still in an experimental stage (6000.3).

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Easy of use: Behavior trees can be quickly added to agents by only inheriting from a specific class (BehaviorTreeRunner). Implementation of concreate actions and condition nodes also follows the same pattern and can be easily implemented by just create concrete class the inherits from ActionNode and ConditionNode respectively.
- Out-of-the-box implementations for the most common decorator and composite node types, allowing faster implementation/experimentation.
- Utilizes common behavior tree data strucutures like Blackboard and Context to facilite access to the data required to run a behavior tree more efficiently.
- Custom editor tools that allow the visualization of the tree's state during runtime for easier debugging.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Setting up an agent to run a BehaviorTree <a name="SettingUpAnAgentToRunABehaviorTree"/>
 In order to have an agent running a behavior tree, please create a class that inherits from BehaviorTreeRunner and attach it to the agent's GameObject.  
A concrete BehaviorTreeRunner subclass must implement the following method:
- BuildTree() : defines the behavior tree structure for this agent, returning the root node.
Inside the BuildTree() method is where you define you behavior tree. For a more detailed sample please check the sample scene that comes with the package.
```csharp
// Class the implement a behavior tree for a villager NPC
public class VillagerBT : BehaviorTreeRunner
{
  [SerializeField] private VillagerStats villagerStats;

  protected override Node BuildTree(Blackboard blackboard)
  {
    return new Selector( // root node is a selector node
      new ConditionGuard( // work branch
        new EnergyThresholdCondition(() => !villagerStats.IsEnergyLow), // condition to check if the villager has enough energy
        new Sequence( // if it has, performs the following sequence: go to work -> work
          new GoToAction(workLocation),
          new WorkAction()
          )
        ),
      new ConditionGuard( // rest branch
          new EnergyThresholdCondition(() => !villagerStats.IsEnergyFull), // condition to check if the villager is fully rested
          new Sequence( // if isn't, performs the following sequence: go to rest place -> rest
            new GoToAction(restLocation),
            new RestAction()
          )
        ),
      new WaitAction() // wait branch in case it does not fulfill the requirements to either work or rest
    );
  }

  private class EnergyThresholdCondition : ConditionNode
  {
    // concrete implementation of a ConditionNode that do energy related checks
  }

  private class GoToAction : ActionNode
  {
    // concrete implementation of an ActionNode that move the agent's to a specific position
  }

  private class WorkAction : ActionNode
  {
    // concrete implementation of an ActionNode that causes the agent to do some specific work
  }

  private class RestAction : ActionNode
  {
    // concrete implementation of an ActionNode that causes the agent to rest
  }

  private class WaitAction : ActionNode
  {
    // concrete implementation of an ActionNode that causes the agent to wait for a set amount of time
  }
}
```

### 4.2 Creating an Action Node <a name="CreatingAnActionNode"/>
To create a concrete implementation of an Action node, just inherit from the abstract ActionNode class.  
A concrete action node subclass must implement the following method:
- OnTick() : method that defines the action's own tick logic.

Optionally, the subclass can override the following methods:
- Reset()   : abort the node if it is currently running, then fully clears its state. Always call base.Reset() when overriding.
- OnEnter() : called once before the first tick.
- OnExit()  : called once after the last tick or abort.
```csharp
// Oversimplified implementation of a simple move action
private class GoToAction : ActionNode
{
  private readonly BlackboardKey _targetKey;
  private MovementController _movementController;

  public GoToAction(MovementController movementController, BlackboardKey targetKey)
  {
    _movementController = movementController;
    _targetKey = targetKey;
  }

  protected override void OnEnter(BehaviorTreeContext context)
  {
    Vector3 targetPosition = context.Blackboard.GetValueOrDefault<Vector3>(_targetKey);
    _movementController.SetTarget(targetPosition);
  }

  protected override NodeStatus OnTick(BehaviorTreeContext context)
  {
    _movementController.MoveTowardsTarget();

    if (!_movementController.HasReachedDestination())
      return NodeStatus.Running;

    return NodeStatus.Success;
  }
}

// Oversimplified implementation of a simple shoot action
private class ShootPlayerAction : ActionNode
{
  private PlayerController _playerController;

  public ShootPlayerAction(PlayerController playerController)
  {
    _playerController = playerController;
  }

  protected override NodeStatus OnTick(BehaviorTreeContext context)
  {
    if (_playerController.InShootingRange())
    {
      _playerController.TakeDamage();
      return NodeStatus.Success
    }

    return NodeStatus.Failure;
  }
}
```

### 4.3 Decorator node types <a name="DecoratorNodeTypes"/>
This package comes with the following Decorator node types already implemented:
- ConditionGuard: Only runs the child while a condition holds. For more details, please check section 4.5.
- Cooldown: Forces Failure for a duration after the child last finished running.
- Inverter: Flips Success to Failure and vice versa; passes Running through unchanged.
- Repeater: Repeats the child a fixed number of times (or forever), optionally breaking on failure.
- RepeatUntilFailure: Re-runs the child on every success, returns Failure as soon as the child fails.
- RepeatUntilSuccess: Re-runs the child on every failure, returns Success as soon as the child succeeds.
- Service: Ticks its update on its own interval for as long as the child subtree is active, independent of what the child returns. Always passes the child's real status through unchanged. For more details, please check section 4.4.
- TimeLimit: Aborts the child and returns Failure if it runs longer than the configured duration.  

New types of decorator nodes can be defined by creating a class that inherits from the abstract Decorator class.
```csharp
[NodeInfo("NewDecorator", "Decorators", "New Decorator description here.")]
public class NewDecorator : Decorator
{
  // implementation of the new decorator type node.
}
```

### 4.4 Using the Service node <a name="UsingTheServiceNode"/>
Service is a special type of decorator node, it ticks its update on its own interval for as long as the child subtree is active, independent of what the child returns and always passes the child's real status through unchanged.  
You can use this type of nodes for logic that you want to execute while the sub-branch is active, with the most common use-case being updates to the agent's blackboard or context.  
To create a concrete implementation of a Service node, just inherit from the abstract Service class.  
A concrete service node subclass must implement the following method:
- OnUpdate() : defines the service's own update logic.
```csharp
public class EnemyDistanceService : Service
{
  private readonly BlackboardKey _enemyKey;
  private readonly BlackboardKey _enemyDistanceKey;

  public EnemyDistanceService(Node child, float interval, bool updateOnFirstTick, BlackboardKey enemyKey)
    : base(child, interval, updateOnFirstTick)
  {
    _enemyKey = enemyKey;
  }

  protected override void OnUpdate(BehaviorTreeContext context);
  {
    int distanceToEnemy = CalculateDistance(context.Transform, context.BlackBoard.GetValueOrDefault<Transform>(_enemyKey));
    context.Blackboard.SetValue(_enemyDistanceKey, distanceToEnemy);
  }
}
```

### 4.5 Using the Condition Guard node <a name="UsingTheConditionGuardNode"/>
ConditionGuard is a special type of decorator node, it only allows their child to run while a ConditionNode (see section below) holds true.  
A condition guard node requires two parameters:
- ConditionNode() : A concrete implementation of a condition node that must hold for the child to run.
- Node() : The guarded child node, that will only run if the condition specified by the ConditionNode holds true.

Optionally, the condition guard node accepts the following parameter:
- AbortType : Controls how reactively the guard should respond when the condition changes. Defaults to None.  
Possible values for AbortType are:
- None: The condition is checked once, on first entry, like a static precondition. Never re-checked afterward.
- Self: Re-checks the condition every tick while this guard's own child is the active branch, aborting it if the condition turns false. Has no effect while a different (lower-priority) sibling is active instead.
- LowerPriority: Lets a parent reactively notice this guard's condition becoming true again while a lower-priority sibling is currently running, aborting that sibling and taking over. Has no effect while this guard's own child is active.
- Both: Combines the effects of Self and LowerPriority, re-checking the condition every tick and allowing a parent to notice it becoming true again while a lower-priority sibling is currently running.
```csharp
new ConditionGuard(
  // The condition to evaluate, true when the villager's energy is not considered low.
  new EnergyThresholdCondition(() => !villagerStats.IsEnergyLow),
  // The guarded child node. In this example, a Sequence node that contains three action children.
  new Sequence(
    new GoToAction(villagerNavigator, villageManager.ToolShed.Waypoint.position),
    new WorkAction(villagerStats),
    new GoToAction(villagerNavigator, villageManager.ToolShed.Waypoint.position)
  ),
  // The AbortType for this guard.
  AbortType.None
)
```

### 4.6 Creating a Condition Node <a name="CreatingAConditionNode"/>
To create a concrete implementation of a Condition node, just inherit from the abstract ConditionNode class.  
Condition nodes are mainly used with the ConditionGuard decorator, for more details about the decorator, please check the section above.  
A concrete condition node subclass must implement the following method:
- Evaluate() : method that evaluates the node's condition.
```csharp
public class EnergyThresholdCondition : ConditionNode
{
  private readonly Func<bool> _condition;

  // example 1: new EnergyThresholdCondition(() => !villagerStats.IsEnergyLow) // true when the villager's energy is not considered low.
  // example 2: new EnergyThresholdCondition(() => !villagerStats.IsEnergyFull) // true when the villager's enery is not full.
  public EnergyThresholdCondition(Func<bool> condition) 
  {
    _condition = condition;
  }

  protected override bool Evaluate(BehaviorTreeContext context)
  {
    return _condition();
  }
}
```

### 4.7 Composite node types <a name="CompositeNodeTypes"/>
This package comes with the following Composite node types already implemented:
- Selector: Ticks children in order. Succeeds as soon as any child succeeds or fails only once every child has failed.
- RandomSelector: Behaves the same as the Selector node, but child order is shuffled every time it starts.
- Sequence: Ticks children in order. Fails as soon as any child fails or succeeds only once every child has succeeded.
- RandomSequence: Behaves the same as the Sequence node, but child order is shuffled every time it starts.
- Parallel: Ticks every still-running child on every tick, rather than one at a time. Success/failure thresholds are independently configurable via ParallelPolicy parameter.  

New types of composite nodes can be defined by creating a class that inherits from the abstract Composite class.
```csharp
[NodeInfo("NewComposite", "Composites", "New Composite description here.")]
public class NewComposite : Composite
{
  // implementation of the new composite type node.
}
```

### 4.8 Visualize behavior trees <a name="VisualizeBehaviorTrees"/>
At the current moment, behavior trees can only be created through code (support for graphical creation of Behavior Tree is planned for a future release, as at the moment Unity's GraphToolkit package is still in an experimental stage), so in order to visualize the tree, this package comes with a Editor tool that display the flow of execution at runtime.  
This editor tool can be opened by selecting in the hierarchy the GameObject that contains the concrete implementation of the BehaviorTreeRunner class, after that a "Open Tree Viewer" button should appear in the Inspector window.  
When the button is clicked, a window should open displaying a runtime visual representation of the tree, which can be used for debugging.  
Additionally, custom debuggers can be added/removed from any BehaviorTree instance by calling AddDebugger() and RemoveDebugger() respectively. Those custom debuggers must implement the IBehaviorTreeDebugger interface. For more details please check the documentation section.  
```csharp
public class VillagerBT : BehaviorTreeRunner
{
  // Concrete implementation of a behavior tree for a villager
}

public class CustomDebugger : IBehaviorTreeDebugger
{
  void IBehaviorTreeDebugger.OnNodeEnter(Node node)
  {
    NodeInfoAttribute info = node.GetType().GetCustomAttribute<NodeInfoAttribute>();
    Debug.Log("Entered node " + info.DisplayName);
  }

  void IBehaviorTreeDebugger.OnNodeExit(Node node, NodeStatus status)
  {
    NodeInfoAttribute info = node.GetType().GetCustomAttribute<NodeInfoAttribute>();
    Debug.Log("Exited node " + info.DisplayName + " with a status of " + status.ToString());
  }
}

VillagerBT villager = GetComponent<VillagerBT>();
villager.Tree.AddDebugger(new CustomDebugger());
...
villager.Tree.RemoveDebugger(new CustomDebugger());
```

## 5 - Documentation <a name="documentation"/>
### 5.1 BehaviorTreeRunner <a name="behaviorTreeRunner"/>
#### 5.1.1 BehaviorTreeRunner.Tree <a name="behaviorTreeRunnerTree"/>
The agent's running tree instance
##### Declaration
```csharp
public BehaviorTree Tree;
```
##### Returns
| Type | Description |
| :--- | :--- |
| BehaviorTree | The agent's running tree instance |


#### 5.1.2 BehaviorTreeRunner.Blackboard <a name="behaviorTreeRunnerBlackboard"/>
The agent's blackboard instance
##### Declaration
```csharp
public Blackboard Blackboard;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Blackboard | The agent's blackboard instance |


#### 5.1.3 BehaviorTreeRunner.Tick() <a name="behaviorTreeRunnerTick"/>
Used to manually ticks the tree when tickMode is set to Manual. Otherwise, this is called automatically by Update() or FixedUpdate() depending on tickMode.
##### Declaration
```csharp
public void Tick(float deltaTime);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | deltaTime | The time since the last tick |


### 5.2 BehaviorTree <a name="behaviorTree"/>
Creates a tree instance for a given agent
##### Declaration
```csharp
public BehaviorTree(Node root, GameObject owner, Blackboard blackboard = null);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Node | root | The tree's root node. Wrapped in a Root type node automatically if it isn't already one |
| GameObject | owner | The agent this tree instance belongs to |
| Blackboard | blackboard | The blackboard to use, if null create a new instance |

#### 5.2.1 BehaviorTree.Root <a name="behaviorTreeRoot"/>
The tree's entry point
##### Declaration
```csharp
public Root Root;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Root | The tree's entry point |


#### 5.2.2 BehaviorTree.Blackboard <a name="behaviorTreeBlackboard"/>
The blackboard shared by every node in this tree instance
##### Declaration
```csharp
public Blackboard Blackboard;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Blackboard | The blackboard shared by every node in this tree instance |


#### 5.2.3 BehaviorTree.Context <a name="behaviorTreeContext"/>
The per-tick context passed to every node
##### Declaration
```csharp
public BehaviorTreeContext Context;
```
##### Returns
| Type | Description |
| :--- | :--- |
| BehaviorTreeContext | The per-tick context passed to every node |


#### 5.2.4 BehaviorTree.LastStatus <a name="behaviorTreeLastStatus"/>
The result of the most recent tick call
##### Declaration
```csharp
public NodeStatus LastStatus;
```
##### Returns
| Type | Description |
| :--- | :--- |
| NodeStatus | The result of the most recent tick call |


#### 5.2.5 BehaviorTree.AddDebugger() <a name="behaviorTreeAddDebugger"/>
Attaches a debugger so it starts receiving node enter/exit events for this tree
##### Declaration
```csharp
public void AddDebugger(IBehaviorTreeDebugger debugger);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| IBehaviorTreeDebugger | debugger | The debugger to attach |


#### 5.2.6 BehaviorTree.RemoveDebugger() <a name="behaviorTreeRemoveDebugger"/>
Detaches a previously-attached debugger from the tree
##### Declaration
```csharp
public void RemoveDebugger(IBehaviorTreeDebugger debugger);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| IBehaviorTreeDebugger | debugger | The debugger to remove |


#### 5.2.7 BehaviorTree.Tick() <a name="behaviorTreeTick"/>
Ticks the tree once
##### Declaration
```csharp
public NodeStatus Tick(float deltaTime);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | deltaTime | The time since the last tick |
##### Returns
| Type | Description |
| :--- | :--- |
| NodeStatus | The tree's result for this tick |


#### 5.2.8 BehaviorTree.Abort() <a name="behaviorTreeAbort"/>
Aborts the tree if it is currently running
##### Declaration
```csharp
public void Abort();
```


#### 5.2.9 BehaviorTree.ResetTree() <a name="behaviorTreeResetTree"/>
Aborts the tree if running, then fully clears its state so the next tick starts fresh
##### Declaration
```csharp
public void Reset();
```


### 5.3 BehaviorTreeContext <a name="behaviorTreeContext"/>
Creates a context instance for a given agent
##### Declaration
```csharp
public BehaviorTreeContext(GameObject gameObject, Blackboard blackboard);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| GameObject | owner | The agent this context belongs to |
| Blackboard | blackboard | The blackboard every node in the tree will share |

#### 5.3.1 BehaviorTreeContext.GameObject <a name="behaviorTreeContextGameObject"/>
The agent which the context belongs to
##### Declaration
```csharp
public GameObject GameObject;
```
##### Returns
| Type | Description |
| :--- | :--- |
| GameObject | The agent which the context belongs to |


#### 5.3.2 BehaviorTreeContext.Transform <a name="behaviorTreeContextTransform"/>
The agent GameObject's transform
##### Declaration
```csharp
public Transform Transform;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Transform | The agent GameObject's transform |


#### 5.3.3 BehaviorTreeContext.Blackboard <a name="behaviorTreeContextBlackboard"/>
The blackboard shared by every node in this tree instance
##### Declaration
```csharp
public Blackboard Blackboard;
```
##### Returns
| Type | Description |
| :--- | :--- |
| Blackboard | The blackboard shared by every node in the tree instance |


#### 5.3.4 BehaviorTreeContext.BehaviorTree <a name="behaviorTreeContextBehaviorTree"/>
The blackboard shared by every node in this tree instance
##### Declaration
```csharp
public BehaviorTree Tree;
```
##### Returns
| Type | Description |
| :--- | :--- |
| BehaviorTree | The BehaviorTree instance that owns this context |


#### 5.3.5 BehaviorTreeContext.DeltaTime <a name="behaviorTreeContextDeltaTime"/>
The elapsed time for the current tick
##### Declaration
```csharp
public float DeltaTime;
```
##### Returns
| Type | Description |
| :--- | :--- |
| float | The elapsed time for the current tick |


#### 5.3.6 BehaviorTreeContext.AddDebugger() <a name="behaviorTreeContextAddDebugger"/>
Attaches a debugger so it starts receiving node enter/exit events
##### Declaration
```csharp
public void AddDebugger(IBehaviorTreeDebugger debugger);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| IBehaviorTreeDebugger | debugger | The debugger to attach |


#### 5.3.7 BehaviorTreeContext.RemoveDebugger() <a name="behaviorTreeContextRemoveDebugger"/>
Detaches a debugger
##### Declaration
```csharp
public void RemoveDebugger(IBehaviorTreeDebugger debugger);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| IBehaviorTreeDebugger | debugger | The debugger to detach |


### 5.4 Blackboard <a name="blackboard"/>
Creates a blackboard instance
##### Declaration
```csharp
public Blackboard();
```


#### 5.4.1 Blackboard.OnValueChanged <a name="blackboardOnValueChanged"/>
Raised when a value is set or it changes on this blackboard
##### Declaration
```csharp
public event Action<BlackboardKey, object> OnValueChanged;
```
##### Returns
| Type | Description |
| :--- | :--- |
| BlackboardKey | The blackboard key which had the value modified |
| object | The new modified value |


#### 5.4.2 Blackboard.Keys <a name="blackboardKeys"/>
The keys set on this blackboard
##### Declaration
```csharp
public IReadOnlyCollection<BlackboardKey> Keys;
```
##### Returns
| Type | Description |
| :--- | :--- |
| IReadOnlyCollection<BlackboardKey> | The keys set on this blackboard |


#### 5.4.3 Blackboard.SetValue() <a name="blackboardSetValue"/>
Sets a value in the blackboard
##### Declaration
```csharp
public void SetValue<T>(BlackboardKey key, T value);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| BlackboardKey | key | The key to write |
| T | value | The value to store |


#### 5.4.4 Blackboard.TryGetValue() <a name="blackboardTryGetValue"/>
Try to get a value from the blackboard
##### Declaration
```csharp
public bool TryGetValue<T>(BlackboardKey key, out T value);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| BlackboardKey | key | The key to look up |
| out T | value | The found value, or default if not found |
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True if a value of type <typeparamref name="T"/> was found, false otherwise |


#### 5.4.5 Blackboard.GetValueOrDefault() <a name="blackboardGetValueOrDefault"/>
Looks up a value and returns it, if not found, the fallback is returned instead
##### Declaration
```csharp
public T GetValueOrDefault<T>(BlackboardKey key, T fallback = default);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| BlackboardKey | key | The key to look up |
| T | fallback | The value to return if the key isn't found |
##### Returns
| Type | Description |
| :--- | :--- |
| T | The value associated with the key, or fallback if not found |


#### 5.4.6 Blackboard.HasKey() <a name="blackboardHasKey"/>
Check if the blackboard has a specific key
##### Declaration
```csharp
public bool HasKey(BlackboardKey key);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| BlackboardKey | key | The key to check |
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the blackboard has the key, false otherwise |


#### 5.4.7 Blackboard.Remove() <a name="blackboardRemove"/>
Removes a key from the blackboard
##### Declaration
```csharp
public bool Remove(BlackboardKey key);
```
##### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| BlackboardKey | key | The key to remove |
##### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the key was present and removed |


#### 5.4.8 Blackboard.Clear() <a name="blackboardClear"/>
Removes all entries from the blackboard
##### Declaration
```csharp
public void Clear();
```


## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com