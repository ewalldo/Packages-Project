# Event Bus
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Create an event type](#createAnEventType)
  - [Registering an event](#registeringAnEvent)
  - [Unregistering from an event](#unregisteringFromAnEvent)
  - [Invoking an event](#invokingAnEvent)
- [Documentation](#documentation)
  - [EventBus.Register()](#eventBusRegister)
  - [EventBus.Unregister()](#eventBusUnregister)
  - [EventBus.Invoke()](#eventBusInvoke)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
An event bus is a simple register-unregister pattern that allows communication between different parts of a game or application. It decouples the sender of an event from its receivers, making it easier to add, remove, or modify components in your game without having to update every component that communicates with it.  
This "Event Bus" package tool helps you to create and use an Event Bus in an safe and easy way. By using scriptable objects as a way to identify event types, we ensure that our code is protected against common errors that can happen when using implementations that utilizes string or enums as an identifier. This tool was also created to be easy to use, all the main actions related to event bus (register/unregister/invoke) can be implemented with a single line of code.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Use of scriptable objects for the event type: Common implementations of "Event Bus" uses a string or enum as a key value for events. The downside of using strings is that a simple typo, wrong capitalization or a blank space can cause events to not be invoked correctly, these errors are not caught by the IDE thus making them harder to debug. Enums can make up for this string's weakness, but on the other hand they may cause a different one. Enums underlying type is an int, so a simple addition or removal of an enum value can cause their value to shift to the next/previous one, so if you have enum values set up in the inspector, they may change to a completely different without triggering any type of warning/error, also making the code harder to debug too. By using scriptable objects instead, we ensure that those two problems cannot happen, thus making the code safer and easier to debug in case of errors.
- Simple to use: Events can be registered/unregistered/invoked by using one single line of code, making it easy to use while avoid crowding other classes with too much code.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Create an event type <a name="createAnEventType"/>
- Event type can be created by right-clicking the project window, choose "Create"->"Scriptable Objects"->"Event Bus"->"Event Type".

### 4.2 Registering an event <a name="registeringAnEvent"/>
Events can be registered by calling the static function Register in the EventBus class. Each event is registered under a event type and up to five parameters can be used.
```csharp
public static void Register(EventType eventType, Action callback);
public static void Register<T0>(EventType eventType, Action<T0> callback);
public static void Register<T0, T1>(EventType eventType, Action<T0, T1> callback);
public static void Register<T0, T1, T2>(EventType eventType, Action<T0, T1, T2> callback);
public static void Register<T0, T1, T2, T3>(EventType eventType, Action<T0, T1, T2, T3> callback);
public static void Register<T0, T1, T2, T3, T4>(EventType eventType, Action<T0, T1, T2, T3, T4> callback);
```

### 4.3 Unregistering from an event <a name="unregisteringFromAnEvent"/>
Events can be unregistered by calling the static function Unregister in the EventBus class and passing both the event type and event.
```csharp
public static void Unregister(EventType eventType, Action callback);
public static void Unregister<T0>(EventType eventType, Action<T0> callback);
public static void Unregister<T0, T1>(EventType eventType, Action<T0, T1> callback);
public static void Unregister<T0, T1, T2>(EventType eventType, Action<T0, T1, T2> callback);
public static void Unregister<T0, T1, T2, T3>(EventType eventType, Action<T0, T1, T2, T3> callback);
public static void Unregister<T0, T1, T2, T3, T4>(EventType eventType, Action<T0, T1, T2, T3, T4> callback);
```

### 4.4 Invoking an event <a name="invokingAnEvent"/>
Events can be invoked by calling the static function Invoke in the EventBus class and passing both the event type and its respective parameters.
```csharp
public static void Invoke(EventType eventType);
public static void Invoke<T0>(EventType eventType, T0 arg0);
public static void Invoke<T0, T1>(EventType eventType, T0 arg0, T1 arg1);
public static void Invoke<T0, T1, T2>(EventType eventType, T0 arg0, T1 arg1, T2 arg2);
public static void Invoke<T0, T1, T2, T3>(EventType eventType, T0 arg0, T1 arg1, T2 arg2, T3 arg3);
public static void Invoke<T0, T1, T2, T3, T4>(EventType eventType, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
```

## 5 - Documentation <a name="documentation"/>
### 5.1 EventBus.Register() <a name="eventBusRegister"/>
Register an event in the event bus (up to five parameters)
#### Declaration
```csharp
public static void Register(EventType eventType, Action callback);
public static void Register<T0>(EventType eventType, Action<T0> callback);
public static void Register<T0, T1>(EventType eventType, Action<T0, T1> callback);
public static void Register<T0, T1, T2>(EventType eventType, Action<T0, T1, T2> callback);
public static void Register<T0, T1, T2, T3>(EventType eventType, Action<T0, T1, T2, T3> callback);
public static void Register<T0, T1, T2, T3, T4>(EventType eventType, Action<T0, T1, T2, T3, T4> callback);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| EventType | eventType | The type of the event |
| Action | callback | The event to be registered |


### 5.2 EventBus.Unregister() <a name="eventBusUnregister"/>
Unregister an event from the event bus (up to five parameters)
#### Declaration
```csharp
public static void Unregister(EventType eventType, Action callback);
public static void Unregister<T0>(EventType eventType, Action<T0> callback);
public static void Unregister<T0, T1>(EventType eventType, Action<T0, T1> callback);
public static void Unregister<T0, T1, T2>(EventType eventType, Action<T0, T1, T2> callback);
public static void Unregister<T0, T1, T2, T3>(EventType eventType, Action<T0, T1, T2, T3> callback);
public static void Unregister<T0, T1, T2, T3, T4>(EventType eventType, Action<T0, T1, T2, T3, T4> callback);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| EventType | eventType | The type of the event |
| Action | callback | The event to be unregistered |


### 5.3 EventBus.Invoke() <a name="eventBusInvoke"/>
Invoke all events registered to an event type (up to five parameters)
#### Declaration
```csharp
public static void Invoke(EventType eventType);
public static void Invoke<T0>(EventType eventType, T0 arg0);
public static void Invoke<T0, T1>(EventType eventType, T0 arg0, T1 arg1);
public static void Invoke<T0, T1, T2>(EventType eventType, T0 arg0, T1 arg1, T2 arg2);
public static void Invoke<T0, T1, T2, T3>(EventType eventType, T0 arg0, T1 arg1, T2 arg2, T3 arg3);
public static void Invoke<T0, T1, T2, T3, T4>(EventType eventType, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| EventType | eventType | The type of the event |
| T0...T4 | args | The parameters for the event |

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com