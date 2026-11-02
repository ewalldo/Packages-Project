# Event Bus
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Create an event bus](#createAnEventBus)
  - [Create an event key](#createAnEventKey)
  - [Registering an event](#registeringAnEvent)
  - [Unregistering from an event](#unregisteringFromAnEvent)
  - [Invoking an event](#invokingAnEvent)
- [Documentation](#documentation)
  - [EventBus.Register()](#eventBusRegister)
  - [EventBus.Unregister()](#eventBusUnregister)
  - [EventBus.UnregisterAll()](#eventBusUnregisterAll)
  - [EventBus.Invoke()](#eventBusInvoke)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
An event bus is a simple register-unregister pattern that allows communication between different parts of a game or application. It decouples the sender of an event from its receivers, making it easier to add, remove, or modify components in your game without having to update every component that communicates with it.  
This "Event Bus" package tool helps you to create and use an Event Bus in an safe and easy way. By using structs as a way to identify event types, we ensure that our code is protected against common errors that can happen when using implementations that utilizes string or enums as an identifier. Additionally, event buses are implemented using ScriptableObjects, allowing not only references through the inspector, as well multiple instances of it (UI event bus, gameplay event bus, and so on). Last, the main EventBus class has it's own custom inspector, making the process of debugging events easier.  
This tool was also created to be easy to use, all the main actions related to event bus (register/unregister/invoke) can be implemented with a single line of code.  

This package has been updated to Unity 6000.3.9f1. However, it should work without issue with earlier or future versions of Unity.  
Please let us know if you encounter any issues with the version of Unity you are using.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release.
- 1.0.1: Ensure package functionality in Unity version 6000.3.9f1.
- 2.0: Refactor package to improve performance and usability.

## 3 - Features <a name="features"/>
- Use of scriptable objects for the event bus: Event buses are defined as ScriptableObjects, ensuring that it persists across scenes, survives scene loads/unloads, and can be referenced like any other asset via the Inspector. Additionally, it allows the creation of isolated, purpose-specific buses, i.e. one event bus to handle UI updates and other just for gameplay events, separating responsabilities and making debug easier.
- Use of Type (struct) as event keys: Common implementations of "Event Bus" uses a string or enum as a key value for events. The downside of using strings is that a simple typo, wrong capitalization or a blank space can cause events to not be invoked correctly, these errors are not caught by the IDE thus making them harder to debug. Enums can make up for this string's weakness, but on the other hand they may cause a different one. Enums underlying type is an int, so a simple addition or removal of an enum value can cause their value to shift to the next/previous one, so if you have enum values set up in the inspector, they may change to a completely different without triggering any type of warning/error, also making the code harder to debug too. By using struct as keys instead, we ensure that those two problems do not occur, thus making the code safer and easier to debug in case of errors. Additionally, this approach allows the struct's to carry their own data, simplyfing the logic and making it simpler to use.
- Simple to use: Events can be registered/unregistered/invoked by using one single line of code, making it easy to use while avoid crowding other classes with too much code.
- Custom inspector: The EventBus ScriptableObject has it's own custom inspector, showcasing which events are registered, and which callbacks are associated with each event, making the process of debugging easier and more effective.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Create an event bus <a name="createAnEventBus"/>
- Event buses can be created by right-clicking the project window, choose "Create"->"Scriptable Objects"->"Event Bus".

### 4.2 Create an event key <a name="createAnEventKey"/>
- Any struct can be used as event key. Below is a snippet demonstrating how to declare, use it to register, unregister and invoke an event bus's event by using a struct.
```csharp
// struct definition, can be used as a key to an event, as well as passing parameters.
public struct OnCharacterMoveEvent
{
    public bool IsMoving;
}

private EventBus gameplayEventBus;

// Register callback method to invoke when OnCharacterMoveEvent is used as key
gameplayEventBus.Register<OnCharacterMoveEvent>(OnCharacterMovement);
// Unregister callback method to invoke when OnCharacterMoveEvent is used as key
gameplayEventBus.Unregister<OnCharacterMoveEvent>(OnCharacterMovement);

// Invoke all callback methods that has the OnCharacterMoveEvent as key
gameplayEventBus.Invoke(new OnCharacterMoveEvent { IsMoving = false });

private void OnCharacterMovement(OnCharacterMoveEvent onCharacterMoveEvent)
{
    Debug.Log("Is character moving: " + onCharacterMoveEvent.IsMoving);
}
```

### 4.3 Registering an event <a name="registeringAnEvent"/>
Events can be registered by invoking the Register() method in the EventBus class. Each event is registered under a event type.
```csharp
// Method definition
public void Register<T>(Action<T> callback) where T : struct;

public struct OnCharacterMoveEvent
{
    public bool IsMoving;
}

private EventBus gameplayEventBus;
// Register callback method to invoke when OnCharacterMoveEvent is used as key
gameplayEventBus.Register<OnCharacterMoveEvent>(OnCharacterMovement);

private void OnCharacterMovement(OnCharacterMoveEvent onCharacterMoveEvent)
{
    Debug.Log("Is character moving: " + onCharacterMoveEvent.IsMoving);
}
```

### 4.4 Unregistering from an event <a name="unregisteringFromAnEvent"/>
Events can be unregistered by invoking the Unregister() method in the EventBus class. An event type (struct) is required to unregister an event.
```csharp
// Method definition
public void Unregister<T>(Action<T> callback) where T : struct;

public struct OnCharacterMoveEvent
{
    public bool IsMoving;
}

private EventBus gameplayEventBus;
// Unregister callback method to invoke when OnCharacterMoveEvent is used as key
gameplayEventBus.Unregister<OnCharacterMoveEvent>(OnCharacterMovement);

private void OnCharacterMovement(OnCharacterMoveEvent onCharacterMoveEvent)
{
    Debug.Log("Is character moving: " + onCharacterMoveEvent.IsMoving);
}
```

### 4.5 Invoking an event <a name="invokingAnEvent"/>
Events can be invoked by calling by invoking the Invoke() method in the EventBus class and passing the event type with its respective parameters.
```csharp
// Method definition
public void Invoke<T>(T eventData) where T : struct;

public struct OnCharacterMoveEvent
{
    public bool IsMoving;
}

private EventBus gameplayEventBus;
// Invoke all callback methods that has the OnCharacterMoveEvent as key
gameplayEventBus.Invoke(new OnCharacterMoveEvent { IsMoving = false });
```

## 5 - Documentation <a name="documentation"/>
### 5.1 EventBus.Register() <a name="eventBusRegister"/>
Register a callback for a specific event type
#### Declaration
```csharp
public void Register<T>(Action<T> callback) where T : struct;
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Action<T> | callback | Callback for the event |


### 5.2 EventBus.Unregister() <a name="eventBusUnregister"/>
Unregister a callback for a specific event type
#### Declaration
```csharp
public void Unregister<T>(Action<T> callback) where T : struct;
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Action<T> | callback | Callback for the event |


### 5.3 EventBus.UnregisterAll() <a name="eventBusUnregisterAll"/>
Unregister all callbacks from all event types
#### Declaration
```csharp
public void UnregisterAll();
```


### 5.4 EventBus.Invoke() <a name="eventBusInvoke"/>
Invoke all callbacks registered to a specific event type
#### Declaration
```csharp
public void Invoke<T>(T eventData) where T : struct;
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| T | eventData | The data for this event |

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com