# Chrono Tools
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Creating a timer](#creatingATimer)
  - [Using CountdownTimer](#usingCountdownTimer)
  - [Using PeriodicTimer](#usingPeriodicTimer)
  - [Using StopwatchTimer](#usingStopwatchTimer)
- [Documentation](#documentation)
  - [Timer](#timer)
    - [Timer.CurrentTime](#timerCurrentTime)
    - [Timer.IsRunning](#timerIsRunning)
    - [Timer.Progress](#timerProgress)
    - [Timer.OnTimerStart](#timerOnTimerStart)
    - [Timer.OnTimerStop](#timerOnTimerStop)
    - [Timer.OnTimerPaused](#timerOnTimerPaused)
    - [Timer.OnTimerResumed](#timerOnTimerResumed)
    - [Timer.Start()](#timerStart)
    - [Timer.Stop()](#timerStop)
    - [Timer.Reset()](#timerReset)
    - [Timer.Resume()](#timerResume)
    - [Timer.Pause()](#timerPause)
    - [Timer.Tick()](#timerTick)
  - [CountdownTimer](#countdownTimer)
    - [CountdownTimer.OnCountdownEnd](#countdownTimerOnCountdownEnd)
  - [PeriodicTimer](#periodicTimer)
    - [PeriodicTimer.OnPeriodEnd](#periodicTimerOnPeriodEnd)
  - [StopwatchTimer](#stopwatchTimer)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
Chrono Tools is a lightweight and flexible Unity package designed to help developers manage and manipulate time-based events in their games. This package includes several types of timers, each with different behaviors that are useful for various gameplay scenarios, such as countdowns, repeated events, and stopwatches.  
With Chrono Tools, developers can easily integrate time-tracking functionality into their projects, whether it's creating countdowns for power-ups, managing periodic events, or tracking elapsed time for achievements. The package provides intuitive APIs and is designed to be both easy to use and customizable.  

This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Countdown Timer: A timer that counts down from a specified time and triggers an event when it reaches zero.
- Periodic Timer: A timer that resets itself at the end of each cycle, ideal for recurring events.
- Stopwatch Timer: A simple timer that tracks how much time has elapsed since it started.
- Event Support: Each timer has events for starting, stopping, pausing, resuming, and when the timer reaches its end.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Creating a timer <a name="creatingATimer"/>
To create and use a timer, you can instantiate any of the provided timer classes, such as CountdownTimer, PeriodicTimer, or StopwatchTimer. Each timer comes with methods to start, stop, pause, and resume.  
```csharp
CountdownTimer countdown = new CountdownTimer(10f); // 10 second countdown
countdown.Start();
```

### 4.2 Using CountdownTimer <a name="usingCountdownTimer"/>
The CountdownTimer counts down from a set time and triggers an event when it reaches zero.
```csharp
CountdownTimer countdown = new CountdownTimer(15f); // Start a 15-second countdown
countdown.OnCountdownEnd += () => Debug.Log("Countdown finished!");
countdown.Start(); // Starts the timer
```

### 4.3 Using PeriodicTimer <a name="usingPeriodicTimer"/>
The PeriodicTimer is ideal for recurring events that happen at a regular interval. It resets itself after each cycle and can trigger an event at the end of each period.
```csharp
PeriodicTimer periodic = new PeriodicTimer(5f); // Trigger event every 5 seconds
periodic.OnPeriodEnd += () => Debug.Log("Period ended!");
periodic.Start(); // Starts the periodic timer
```

### 4.4 Using StopwatchTimer <a name="usingStopwatchTimer"/>
The StopwatchTimer tracks how much time has passed since it started. It increases the time every frame, useful for tracking elapsed time during gameplay.
```csharp
StopwatchTimer stopwatch = new StopwatchTimer();
stopwatch.Start(); // Starts the stopwatch

// Later, you can stop the stopwatch
stopwatch.Stop();
Debug.Log($"Time elapsed: {stopwatch.CurrentTime} seconds");
```

## 5 - Documentation <a name="documentation"/>
### 5.1 Timer <a name="timer"/>
The Timer class is the abstract base class for all timers in this package. It contains common functionality such as starting, stopping, resetting, and pausing the timer.
#### 5.1.1 Timer.CurrentTime <a name="timerCurrentTime"/>
Gets the current time of the timer.
#### Declaration
```csharp
public float CurrentTime;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | Current time in seconds |

#### 5.1.2 Timer.IsRunning <a name="timerIsRunning"/>
Gets a value indicating whether the timer is currently running.
#### Declaration
```csharp
public bool IsRunning;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | Boolean indicating if the time is currently running |

#### 5.1.3 Timer.Progress <a name="timerProgress"/>
Gets the progress of the timer as a float value, typically between 0 and 1 (Stopwatch and Periodic).
#### Declaration
```csharp
public float Progress;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The current progress of the timer |

#### 5.1.4 Timer.OnTimerStart <a name="timerOnTimerStart"/>
Invoked when the timer starts.
#### Declaration
```csharp
public event Action OnTimerStart;
```

#### 5.1.5 Timer.OnTimerStop <a name="timerOnTimerStop"/>
Invoked when the timer stops.
#### Declaration
```csharp
public event Action OnTimerStop;
```

#### 5.1.6 Timer.OnTimerPaused <a name="timerOnTimerPaused"/>
Invoked when the timer is paused.
#### Declaration
```csharp
public event Action OnTimerPaused;
```

#### 5.1.7 Timer.OnTimerResumed <a name="timerOnTimerResumed"/>
Invoked when the timer is resumed.
#### Declaration
```csharp
public event Action OnTimerResumed;
```

#### 5.1.8 Timer.Start() <a name="timerStart"/>
Starts the timer, setting CurrentTime to the initial time and triggering the OnTimerStart event.
#### Declaration
```csharp
public void Start();
```

#### 5.1.9 Timer.Stop() <a name="timerStop"/>
Stops the timer and triggers the OnTimerStop event.
#### Declaration
```csharp
public void Stop();
```

#### 5.1.10 Timer.Reset() <a name="timerReset"/>
Resets the timer to its initial time.
#### Declaration
```csharp
public void Reset();
public void Reset(float newTime);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | newTime | The new time value to reset the timer to |

#### 5.1.11 Timer.Resume() <a name="timerResume"/>
Resumes the timer execution from a paused state.
#### Declaration
```csharp
public void Resume();
```

#### 5.1.12 Timer.Pause() <a name="timerPause"/>
Pauses the timer execution.
#### Declaration
```csharp
public void Pause();
```

#### 5.1.13 Timer.Tick() <a name="timerTick"/>
This method must be called on the monoBehaviour's Update to update the timer's state each tick.
#### Declaration
```csharp
public void Tick();
```

### 5.2 CountdownTimer <a name="countdownTimer"/>
The CountdownTimer class is a timer that counts down from a specified time to zero, triggering the OnCountdownEnd event when the countdown finishes.
#### Declaration
```csharp
public CountdownTimer(float value);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | value | The countdown time in seconds |

#### 5.2.1 CountdownTimer.OnCountdownEnd <a name="countdownTimerOnCountdownEnd"/>
Invoked when the countdown reaches zero.
#### Declaration
```csharp
public event Action OnCountdownEnd;
```

### 5.3 PeriodicTimer <a name="periodicTimer"/>
The PeriodicTimer class is a timer that resets itself at the end of each period and triggers the OnPeriodEnd event at each period's end.
#### Declaration
```csharp
public PeriodicTimer(float value);
public PeriodicTimer(int frequencyPerSecond);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | value | The period time in seconds |
| int | frequencyPerSecond | The period time measured in how many time it should occur each second |

#### 5.3.1 PeriodicTimer.OnPeriodEnd <a name="periodicTimerOnPeriodEnd"/>
Invoked each time that the period reaches zero.
#### Declaration
```csharp
public event Action OnPeriodEnd;
```

### 5.4 StopwatchTimer <a name="stopwatchTimer"/>
The StopwatchTimer class tracks how much time has passed since it started. It increases over time and can be used for measuring elapsed time..
#### Declaration
```csharp
public StopwatchTimer();
```

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com