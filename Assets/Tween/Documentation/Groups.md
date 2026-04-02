# Groups
## Table of contents
- [Documentation](#documentation)
  - [Tween Groups](#tweenGroups)
      - [TweenBuilder()](#tweenBuilder)
      - [TweenSequencer()](#tweenSequencer)
      - [ITweenGroup.OnAllTweensCompleted()](#iTweenGroupOnAllTweensCompleted)
      - [ITweenGroup.AddTween()](#iTweenGroupAddTween)
      - [ITweenGroup.IsExecuting()](#iTweenGroupIsExecuting)
      - [ITweenGroup.Execute()](#iTweenGroupExecute)
      - [ITweenGroup.Reset()](#iTweenGroupReset)
      - [ITweenGroup.Stop()](#iTweenGroupStop)
      - [TweenSequenceer.AddDelay()](#tweenSequenceerAddDelay)
      - [TweenSequenceer.AddConditional()](#tweenSequenceerAddConditional)

## Documentation <a name="documentation"/>
### Tween Groups <a name="tweenGroups"/>
Tween group classes are classes that implements the ITweenGroup interface and it can be used to group tweens together to be executed simultaneously or in sequence.
#### TweenBuilder() <a name="tweenBuilder"/>
Create a tween group that can be triggered simultaneously.
#### Declaration
```csharp
public TweenBuilder(MonoBehaviour monoBehaviour);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| MonoBehaviour | monoBehaviour | MonoBehaviour that will be responsible to trigger all the tween coroutines of this group |

#### TweenSequencer() <a name="tweenSequencer"/>
Create a tween group that will be executed in sequence.
#### Declaration
```csharp
public TweenSequencer(MonoBehaviour monoBehaviour);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| MonoBehaviour | monoBehaviour | MonoBehaviour that will be responsible to trigger all the tween coroutines of this group |

#### ITweenGroup.OnAllTweensCompleted <a name="iTweenGroupOnAllTweensCompleted"/>
Invoked when all tweens in the group finishes its execution.
#### Declaration
```csharp
public Action OnAllTweensCompleted;
```

#### ITweenGroup.AddTween() <a name="iTweenGroupAddTween"/>
Add a new tween to the group.
#### Declaration
```csharp
public ITweenGroup AddTween(ITweener tween);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| ITweener | tween | Tween to be added to the group |
#### Returns
| Type | Description |
| :--- | :--- |
| ITweenGroup | The tween group with the new tween added to it |

#### ITweenGroup.IsExecuting <a name="iTweenGroupIsExecuting"/>
True if the group is currently running, false otherwise.
#### Declaration
```csharp
public bool IsExecuting;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | Boolean indicating if the group is currently running |

#### ITweenGroup.Execute() <a name="iTweenGroupExecute"/>
Starts the execution of the tween group.
#### Declaration
```csharp
public void Execute();
```

#### ITweenGroup.Reset() <a name="iTweenGroupReset"/>
Clear all tweens in the group
#### Declaration
```csharp
public void Reset();
```

#### ITweenGroup.Stop() <a name="iTweenGroupStop"/>
Stop the execution of the tween group
#### Declaration
```csharp
public void Stop(bool forceFinish);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| bool | forceFinish | True for all tweens in the group to become their final value on stop, false otherwise |

#### TweenSequenceer.AddDelay() <a name="tweenSequenceerAddDelay"/>
Add a delay to a sequence.
#### Declaration
```csharp
public ITweenGroup AddDelay(float duration);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | duration | How long the delay should last |
#### Returns
| Type | Description |
| :--- | :--- |
| ITweenGroup | The tween group with the new delay added to it |

#### TweenSequenceer.AddConditional() <a name="tweenSequenceerAddConditional"/>
Add a conditional check to a sequence, i.e. it will only proceed to the next tween in the sequence when the condition is fulfilled
#### Declaration
```csharp
public ITweenGroup AddConditional(Func<bool> condition, float checkInterval);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Func<bool> | condition | Func to check if the sequence should proceed to the next tween |
| float | checkInterval | How often should check the condition |
#### Returns
| Type | Description |
| :--- | :--- |
| ITweenGroup | The tween group with the new condition added to it |