# State Machine
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Creating a state machine](#creatingAStateMachine)
  - [Creating a state](#creatingAState)
  - [Changing state](#changingState)
  - [Reverting state](#revertingState)
  - [Automatically create state machine and state scripts](#automaticallyCreateStateMachineAndStateScripts)
- [Documentation](#documentation)
  - [StateMachine.CurrentState](#stateMachineCurrentState)
  - [StateMachine.PreviousState ](#stateMachinePreviousState)
  - [StateMachine.OnStateChanged](#stateMachineOnStateChanged)
  - [StateMachine.ChangeState()](#stateMachineChangeState)
  - [StateMachine.RevertState()](#stateMachineRevertState)
  - [IState.OnEnter()](#istateOnEnter)
  - [IState.OnExit()](#istateOnExit)
  - [IState.OnUpdate()](#istateOnUpdate)
  - [IState.OnFixedUpdate()](#istateOnFixedUpdate)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The "State Machine" package is a utility for managing game states in Unity. It allows you to define a set of states more easily, making it easy to create complex game logic. The package provides a interface that can be used to create the game states, simplifying the process of implementing state management in your game making the code more compact and readable.  
The package also include a "state machine generator" tool, allowing you to quickly create the base of multiple state scripts at once, saving you seconds (or a few minutes depending on the number of scripts) of writing basic code and compilation time.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

## 2 - Version History <a name="versionHistory"/>
- 1.0.0: Initial release
- 1.0.1: Adjust spacing on automatically generated scripts
- 1.0.2: Add non-MonoBehaviour version of the State Machine
- 1.0.3: Edit StateMachine generator tool to allow creation of both MonoBehaviour and non-Monobehaviour version

## 3 - Features <a name="features"/>
- Use of interface: Unlike traditional implementations that use enums, the use of a interface for states provide a more flexible, compact and extensible way to define states and their behaviours, making the code cleaner and easier to debug and maintain.
- Simple to use: States machines and states can be easily created by just inheriting/implementing their respective class and interface.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Creating a state machine <a name="creatingAStateMachine"/>
- A state machine can be created by making it inherit from the StateMachineMonoBehaviour class, so your new class can access any method or attribute that belongs to MonoBehaviour.
- Or just instantiate the "StateMachine" class inside any of your scripts
```csharp
// MonoBehaviour version
class MyStateMachine : StateMachineStateMachineMonoBehaviour;

// C# class version
private StateMachine myStateMachine = new StateMachine();
```

### 4.2 Creating a state <a name="creatingAState"/>
States can be created by implementing the IState interface. This interface include methods when entering or exiting a state (OnEnter and OnExit), as well as methods for Update and FixedUpdate (OnUpdate and OnFixedUpdate).
```csharp
class MyState : IState;
```

### 4.3 Changing state <a name="changingState"/>
States can be changed by calling the ChangeState method and passing the new state as a parameter.
```csharp
public void ChangeState(IState newState);
```

### 4.4 Reverting state <a name="revertingState"/>
States can be reverted to a previous one by calling the RevertState method.
```csharp
public void RevertState();
```

### 4.5 Automatically create state machine and state scripts <a name="automaticallyCreateStateMachineAndStateScripts"/>
State machine and states scripts can be automatically created by using the "State Machine Generator" window. To opne it, just click "Window"->"State Machine Generator" in the toolbar. The name of the state machine can be defined at the top of the window, while the state names are defined at the list right under it. At the bottom there are toggles for the following options:
- Override namespace: Allow you to chose which namespace your scripts will belong to, if not toggled it will put the scripts under the "StateMachinePattern" namespace.
- Create states only: If this toggled is turned on, it will not generate the state machine script, only the state ones defined in the list. This option is useful in case you want to add states to a already existing state machine.

## 5 - Documentation <a name="documentation"/>
### 5.1 StateMachine() <a name="stateMachineConstructor"/>
Instantiate a new instance of the StateMachine class
#### Declaration
```csharp
public StateMachine();
```


### 5.2 StateMachine.CurrentState <a name="stateMachineCurrentState"/>
The current state of the state machine
#### Declaration
```csharp
public IState CurrentState;
```
#### Returns
| Type | Description |
| :--- | :--- |
| IState | Current state of the state machine |


### 5.3 StateMachine.PreviousState <a name="stateMachinePreviousState"/>
The previous state of the state machine
#### Declaration
```csharp
public IState PreviousState;
```
#### Returns
| Type | Description |
| :--- | :--- |
| IState | Previous state of the state machine |


### 5.4 StateMachine.OnStateChanged <a name="stateMachineOnStateChanged"/>
Invoked when the state machine changes to a new state
#### Declaration
```csharp
public event Action<IState> OnStateChanged;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| IState | The current state that it has changed to |


### 5.5 StateMachine.ChangeState() <a name="stateMachineChangeState"/>
Change the state machine to a new state
#### Declaration
```csharp
public void ChangeState(IState newState);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| IState | newState | The new state to change into |


### 5.6 StateMachine.RevertState() <a name="stateMachineRevertState"/>
Revert to the previous state
#### Declaration
```csharp
public void RevertState();
```


### 5.7 IState.OnEnter() <a name="istateOnEnter"/>
Invoked when entering the state
#### Declaration
```csharp
public void OnEnter();
```


### 5.8 IState.OnExit() <a name="istateOnExit"/>
Invoked when leaving the state
#### Declaration
```csharp
public void OnExit();
```


### 5.9 IState.OnUpdate() <a name="istateOnUpdate"/>
Invoked on the Update() function
#### Declaration
```csharp
public void OnUpdate();
```


### 5.10 IState.OnFixedUpdate() <a name="istateOnFixedUpdate"/>
Invoked on the FixedUpdate() function
#### Declaration
```csharp
public void OnFixedUpdate();
```

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com