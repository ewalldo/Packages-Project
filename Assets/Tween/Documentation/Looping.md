# Looping
## Table of contents
- [Documentation](#documentation)
  - [Looping Functions](#loopingFunctions)
      - [RestartLoop()](#restartLoop)
      - [PingPongLoop()](#pingPongLoop)
      - [IncrementalLoop()](#incrementalLoop)

## Documentation <a name="documentation"/>
### Looping Functions <a name="loopingFunctions"/>
Looping functions specify how the tween should loop upon completion.
#### RestartLoop() <a name="restartLoop"/>
Restore the tween to its initial value and repeat the tween.
#### Declaration
```csharp
public RestartLoop(uint numLoops, float delayBetweenLoops = 0f, Func<bool> earlyExit = null, Action onOneLoopCompleted = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| uint | numLoops | The number of times that the tween should loop (0 indicates infinite looping) |
| float | delayBetweenLoops | The delay (in seconds) between loops |
| Func<bool> | earlyExit | Func to check if the tween should exit the looping (checked at the end of each loop) |
| Action | onOneLoopCompleted | Action to be executed at the end of each looping |

#### PingPongLoop() <a name="pingPongLoop"/>
Invert the tween values, i.e. the initial value become the final one and final become the initial, and execute the tween.
#### Declaration
```csharp
public PingPongLoop(uint numLoops, float delayBetweenLoops = 0f, Func<bool> earlyExit = null, Action onOneLoopCompleted = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| uint | numLoops | The number of times that the tween should loop (0 indicates infinite looping) |
| float | delayBetweenLoops | The delay (in seconds) between loops |
| Func<bool> | earlyExit | Func to check if the tween should exit the looping (checked at the end of each loop) |
| Action | onOneLoopCompleted | Action to be executed at the end of each looping |

#### IncrementalLoop() <a name="incrementalLoop"/>
Repeat the tween by using the final value as initial, and adding the difference of initial and final to the final tween.
#### Declaration
```csharp
public IncrementalLoop(uint numLoops, float delayBetweenLoops = 0f, Func<bool> earlyExit = null, Action onOneLoopCompleted = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| uint | numLoops | The number of times that the tween should loop (0 indicates infinite looping) |
| float | delayBetweenLoops | The delay (in seconds) between loops |
| Func<bool> | earlyExit | Func to check if the tween should exit the looping (checked at the end of each loop) |
| Action | onOneLoopCompleted | Action to be executed at the end of each looping |