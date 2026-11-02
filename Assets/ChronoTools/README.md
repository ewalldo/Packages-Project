# Chrono Tools
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Creating a timer](#creatingATimer)
  - [Using CountdownTimer](#usingCountdownTimer)
  - [Using PeriodicTimer](#usingPeriodicTimer)
  - [Using DelayTimer](#usingDelayTimer)
  - [Using StopwatchTimer](#usingStopwatchTimer)
  - [Convert timers to custom string representation](#ConvertTimersToCustomStringRepresentation)
  - [Interface support](#InterfaceSupport)
- [Documentation](#documentation)
  - [Timer](#timer)
    - [Timer.CurrentTime](#timerCurrentTime)
    - [Timer.IsRunning](#timerIsRunning)
    - [Timer.IsPaused](#timerIsPaused)
    - [Timer.Mode](#timerMode)
    - [Timer.TimeScale](#timerTimeScale)
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
    - [CountdownTimer.Loops](#countdownTimerLoops)
    - [CountdownTimer.IsInfinite](#countdownTimerIsInfinite)
    - [CountdownTimer.CompletedLoops](#countdownTimerCompletedLoops)
    - [CountdownTimer.OnCountdownEnd](#countdownTimerOnCountdownEnd)
    - [CountdownTimer.OnComplete](#countdownTimerOnComplete)
  - [PeriodicTimer](#periodicTimer)
  - [DelayTimer](#delayTimer)
  - [StopwatchTimer](#stopwatchTimer)
    - [StopwatchTimer.Laps](#stopwatchTimerLaps)
    - [StopwatchTimer.LapCount](#stopwatchTimerLapCount)
    - [StopwatchTimer.OnLap](#stopwatchTimerOnLap)
    - [StopwatchTimer.Lap()](#stopwatchTimerLap)
    - [StopwatchTimer.GetCumulativeLaps()](#stopwatchTimerGetCumulativeLaps)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
Chrono Tools is a lightweight and flexible Unity package designed to help developers manage and manipulate time-based events in their games. This package includes several types of timers, each with different behaviors that are useful for various gameplay scenarios, such as countdowns, repeated events, and stopwatches.  
With Chrono Tools, developers can easily integrate time-tracking functionality into their projects, whether it's creating countdowns for power-ups, managing periodic events, or tracking elapsed time for achievements. The package provides intuitive APIs and is designed to be both easy to use and customizable.  

This package has been updated to Unity 6000.3.9f1. However, it should work without issue with earlier or future versions of Unity.  
Please let us know if you encounter any issues with the version of Unity you are using.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release
- 1.0.1: Ensure package functionality in Unity version 6000.3.9f1.
- 1.1: Added new timers and methods, interface support and util classes.

## 3 - Features <a name="features"/>
- Countdown Timer: A timer that counts down from a specified time, and triggers an event when it reaches zero.
- Periodic Timer: A timer that resets itself at the end of each cycle, ideal for recurring events.
- Delay Timer: A simplified countdown timer for situations that only requires a callback to beinvoked after a given delay.
- Stopwatch Timer: A simple timer that tracks how much time has elapsed since it started.
- Event Support: Each timer has events for starting, stopping, pausing, resuming, and when the timer reaches its end.
- String representation: All timers can be easily converted to a more readable string representation.
- Interface support: All timers uses interfaces in their implementation, making it easier to create timer dependent systems that can work with any type of timer.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Creating a timer <a name="creatingATimer"/>
To create and use a timer, you can instantiate any of the provided timer classes, such as CountdownTimer, PeriodicTimer, DelayTimer or StopwatchTimer. Each timer comes with methods to start, stop, pause, and resume.  
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

### 4.4 Using DelayTimer <a name="usingDelayTimer"/>
The DelayTimer is ideal for timers that invokes a callback once, after the given delay elapses.
```csharp
DelayTimer delay = new DelayTimer(5f, () => Debug.Log("Delay ended!")); // Display the log message after 5 seconds have passed.
delay.Start(); // Starts the delay timer
```

### 4.5 Using StopwatchTimer <a name="usingStopwatchTimer"/>
The StopwatchTimer tracks how much time has passed since it started. It increases the time every frame, useful for tracking elapsed time during gameplay.
```csharp
StopwatchTimer stopwatch = new StopwatchTimer();
stopwatch.Start(); // Starts the stopwatch

// Later, you can stop the stopwatch
stopwatch.Stop();
Debug.Log($"Time elapsed: {stopwatch.CurrentTime} seconds");
```

### 4.6 Convert timers to custom string representation <a name="ConvertTimersToCustomStringRepresentation"/>
Several methods are provided for situations where a string representation of a timer is necessary.
This can be achieved by using the ToClock() method which is available to all timers, or by using the static TimeFormatExtensions.ToClock() method.
Timers support the following representations by default: seconds, minutes:seconds, minutes:seconds:milliseconds and hours:minutes:seconds.
For custom representations besides the above, the TimeFormatExtensions.ToClock(this float seconds, string format) method can be used.
```csharp
CountdownTimer countdown = new CountdownTimer(15f); // Start a 15-second countdown
countdown.Start(); // Starts the timer

// Convert the timer to a string in the mm:ss format
string timerString = countdownTimer.ToClock(ClockFormat.MinutesSeconds);
string timerString = TimeFormatExtensions.ToClock(countdownTimer.CurrentTime, ClockFormat.MinutesSeconds); // or countdownTimer.CurrentTime.ToClock(ClockFormat.MinutesSeconds)
string timerString = TimeFormatExtensions.ToClock(countdownTimer.CurrentTime, @"mm\:ss"); // or countdownTimer.CurrentTime.ToClock(@"mm\:ss");
```

### 4.7 Interface support <a name="InterfaceSupport"/>
All timers in this package implements the interfaces below, allowing the creation of systems that can work with any type of timer, instead of concrete implementations.
- IReadOnlyTimer: Read-only view of a timer's current state.
- ITimer: Full timer contract: read-only state, lifecycle control, lifecycle events, and per-frame ticking.
```csharp
public class TimerUI
{
  private IReadOnlyTimer timer;
  private Text uiText;

  public TimerUI(IReadOnlyTimer timer, Text uiText)
  {
    this.timer = timer;
    this.uiText = uiText;
  }

  public void UpdateUI()
  {
    uiText.text = timer.CurrentTime.ToClock(ClockFormat.MinutesSeconds);
  }
}

Text text = new Text();
CountdownTimer countdown = new CountdownTimer(15f);
StopwatchTimer stopwatch = new StopwatchTimer();

TimerUI a = new TimerUI(countdown, text);
TimerUI b = new TimerUI(stopwatch, text);
```
For full details on each interface, please check the source code of each file.


## 5 - Documentation <a name="documentation"/>
### 5.1 Timer <a name="timer"/>
The Timer class is the abstract base class for all timers in this package. It contains common functionality such as starting, stopping, resetting, and pausing the timer.
#### Timer.CurrentTime <a name="timerCurrentTime"/>
Gets the current time of the timer, in seconds.
#### Declaration
```csharp
public float CurrentTime;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | Current time in seconds |

#### Timer.IsRunning <a name="timerIsRunning"/>
Gets a value indicating whether the timer is currently running.
#### Declaration
```csharp
public bool IsRunning;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | Boolean indicating if the time is currently running |

#### Timer.IsPaused <a name="timerIsPaused"/>
Gets a value indicating whether the timer is currently paused.
#### Declaration
```csharp
public bool IsPaused;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | Boolean indicating if the time is currently paused |

#### Timer.Mode <a name="timerMode"/>
Gets or sets which delta time to use when invoking the parameterless Tick() method.
Ignored when advancing the timer with the parameter version Tick(float).
#### Declaration
```csharp
public TimeMode Mode;
```
#### Returns
| Type | Description |
| :--- | :--- |
| TimeMode | Which delta time (scaled or unscaled) to use when invoking the Tick() method |

#### Timer.TimeScale <a name="timerTimeScale"/>
Gets or sets a speed multiplier applied to the delta on every tick.
1 = normal speed, 2 = twice as fast, 0.5 = half speed, 0 = frozen.
Applies to both the parameterless Tick() and the parameter one Tick(float).
#### Declaration
```csharp
public float TimeScale;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | Speed multiplier to apply to the delta |

#### Timer.Progress <a name="timerProgress"/>
Gets the progress of the timer as a float value, typically between 0 and 1 (Stopwatch and Periodic).
#### Declaration
```csharp
public float Progress;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The current progress of the timer |

#### Timer.OnTimerStart <a name="timerOnTimerStart"/>
Invoked when the timer starts.
#### Declaration
```csharp
public event Action OnTimerStart;
```

#### Timer.OnTimerStop <a name="timerOnTimerStop"/>
Invoked when the timer stops.
#### Declaration
```csharp
public event Action OnTimerStop;
```

#### Timer.OnTimerPaused <a name="timerOnTimerPaused"/>
Invoked when the timer is paused.
#### Declaration
```csharp
public event Action OnTimerPaused;
```

#### Timer.OnTimerResumed <a name="timerOnTimerResumed"/>
Invoked when the timer is resumed.
#### Declaration
```csharp
public event Action OnTimerResumed;
```

#### Timer.Start() <a name="timerStart"/>
Starts the timer, setting CurrentTime to the initial time and triggering the OnTimerStart event.
#### Declaration
```csharp
public void Start();
```

#### Timer.Stop() <a name="timerStop"/>
Stops the timer and triggers the OnTimerStop event.
#### Declaration
```csharp
public void Stop();
```

#### Timer.Reset() <a name="timerReset"/>
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

#### Timer.Resume() <a name="timerResume"/>
Resumes the timer execution from a paused state.
#### Declaration
```csharp
public void Resume();
```

#### Timer.Pause() <a name="timerPause"/>
Pauses the timer execution.
#### Declaration
```csharp
public void Pause();
```

#### Timer.Tick() <a name="timerTick"/>
Advances the timer by a certain amount of time.
Parameterless version advances by using the delta time selected by Mode.
Parameter version advances the timer by the given amount of time.
Both versions are scaled by TimeScale.
#### Declaration
```csharp
public void Tick();
public void Tick(float deltaTime);
```

### 5.2 CountdownTimer <a name="countdownTimer"/>
The CountdownTimer class is a timer that counts down from a specified time to zero
It triggers the OnCountdownEnd event each time the countdown reaches zero (once per loop), and OnComplete event once when all loops have finished (never raised on an infinite countdown).
#### Declaration
```csharp
public CountdownTimer(float value, int loops = 1);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | value | The countdown time in seconds |
| int | loops | The amount of times the countdown should run. 1 = once (default); 0 or less = loop forever |

#### CountdownTimer.Loops <a name="countdownTimerLoops"/>
Gets or sets how many times the countdown runs.
1 runs it once. A value greater than 1 runs the countdown that many times. A value of 0 or less makes it loop forever.
#### Declaration
```csharp
public int Loops;
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | How many times (loops) the countdown runs |

#### CountdownTimer.IsInfinite <a name="countdownTimerIsInfinite"/>
True if the CountdownTimer is infinite (keep looping forever), false otherwise.
#### Declaration
```csharp
public bool IsInfinite;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the CountdownTimer is infinite, false otherwise |

#### CountdownTimer.CompletedLoops <a name="countdownTimerCompletedLoops"/>
Gets the number of completed loops since the last Start or Reset.
#### Declaration
```csharp
public int CompletedLoops => completedLoops;
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | the number of completed loops since the last Start or Reset |

#### CountdownTimer.OnCountdownEnd <a name="countdownTimerOnCountdownEnd"/>
Invoked when the countdown reaches zero (once per loop).
#### Declaration
```csharp
public event Action OnCountdownEnd;
```

#### CountdownTimer.OnComplete <a name="countdownTimerOnComplete"/>
Invoked once when all loops have finished. Never raised on an infinite countdown.
#### Declaration
```csharp
public event Action OnCountdownEnd;
```

### 5.3 PeriodicTimer <a name="periodicTimer"/>
The PeriodicTimer is a convenience class to create timers that keep running forever.
It is a CountdownTimer preconfigured to run indefinitely.
All methods and properties that belongs to CountdownTimer can be used with a PeriodicTimer instance.
#### Declaration
```csharp
public PeriodicTimer(float value);
public static PeriodicTimer FromFrequency(float frequencyPerSecond);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | value | The period time in seconds |
| float | frequencyPerSecond | The number of periods per second |

### 5.4 DelayTimer <a name="delayTimer"/>
The DelayTimer is a convenience class to create timers that invokes a callback once, after the given delay elapses.
It is a CountdownTimer preconfigured to run a single time, with the callback wired to CountdownTimer.OnComplete.
All methods and properties that belongs to CountdownTimer can be used with a DelayTimer instance.
#### Declaration
```csharp
public DelayTimer(float value, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | value | The delay, in seconds, before the callback fires |
| Action | onComplete | Callback invoked once when the delay elapses |

### 5.5 StopwatchTimer <a name="stopwatchTimer"/>
The StopwatchTimer class tracks how much time has passed since it started. It increases over time and can be used for measuring elapsed time..
#### Declaration
```csharp
public StopwatchTimer();
```

#### StopwatchTimer.Laps <a name="stopwatchTimerLaps"/>
Gets the recorded laps as split times, i.e. each entry is the time elapsed since the previous lap.
#### Declaration
```csharp
public IReadOnlyList<float> Laps;
```
#### Returns
| Type | Description |
| :--- | :--- |
| IReadOnlyList<float> | The recorded laps as split times |

#### StopwatchTimer.LapCount <a name="stopwatchTimerLapCount"/>
Gets the number of laps recorded since the last Start or Reset.
#### Declaration
```csharp
public int LapCount;
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | The number of laps recorded |

#### StopwatchTimer.OnLap <a name="stopwatchTimerOnLap"/>
Invoked each time a lap is recorded, passing the split time for that lap.
#### Declaration
```csharp
public event Action<float> OnLap;
```

#### StopwatchTimer.Lap() <a name="stopwatchTimerLap"/>
Records a lap and returns its split time (the elapsed time since the previous lap).
#### Declaration
```csharp
public float Lap();
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The split time for the recorded lap, in seconds |

#### StopwatchTimer.GetCumulativeLaps() <a name="stopwatchTimerGetCumulativeLaps"/>
Returns the recorded laps as cumulative totals, i.e. each entry is the total elapsed time at the moment that lap was recorded.
#### Declaration
```csharp
public List<float> GetCumulativeLaps();
```
#### Returns
| Type | Description |
| :--- | :--- |
| List<float> | A new list of cumulative lap times, in seconds |

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com