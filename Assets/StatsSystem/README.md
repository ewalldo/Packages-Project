# Stats System
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Create a "Stat Type"](#createAStatType)
  - [Create a "Stat Set"](#createAStatSet)
  - [Instantiate a "Single Stat"](#instantiateASingleStat)
  - [Instantiate a "Stats Modifier"](#instantiateAStatsModifier)
  - [Add/Remove a modifier from a stat](#addRemoveModifiersFromAStat)
- [Documentation](#documentation)
  - [SingleStat()](#singleStatSingleStat)
  - [SingleStat.BaseValue](#singleStatStatBaseValue)
  - [SingleStat.StatType](#singleStatStatType)
  - [SingleStat.StatsModifiers](#singleStatStatsModifiers)
  - [SingleStat.OnSingleStatBaseValueChange](#singleStatOnSingleStatBaseValueChange)
  - [SingleStat.OnModifierAdded](#singleStatOnModifierAdded)
  - [SingleStat.OnModifierRemoved](#singleStatOnModifierRemoved)
  - [SingleStat.OnModifierListModified](#singleStatOnModifierListModified)
  - [SingleStat.GetFinalValueAfterModifiers](#singleStatGetFinalValueAfterModifiers)
  - [SingleStat.GetFinalValueAfterModifiersNormalized](#singleStatGetFinalValueAfterModifiersNormalized)
  - [SingleStat.GetStatBaseValueNormalized](#singleStatGetStatBaseValueNormalized)
  - [SingleStat.IncreaseDecreaseBaseStat()](#singleStatIncreaseDecreaseBaseStat)
  - [SingleStat.AddModifier()](#singleStatAddModifier)
  - [SingleStat.RemoveModifier()](#singleStatRemoveModifier)
  - [SingleStat.RemoveAllModifiers()](#singleStatRemoveAllModifiers)
  - [SingleStat.RemoveModifiersBySource()](#singleStatRemoveModifiersBySource)
  - [StatsModifier())](#statsModifierStatsModifier)
  - [StatsModifier.ModifierValue](#statsModifierValue)
  - [StatsModifier.StatTypeTarget](#statsModifierStatTypeTarget)
  - [StatsModifierStatsModifiersType.](#statsModifierStatsModifiersType)
  - [StatsModifier.ModifierOrder](#statsModifierModifierOrder)
  - [StatsModifier.ModifierSource](#statsModifierModifierSource)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The "Stats System" package is a tool for creating and managing stats value for characters, enemies, and so on in Unity projects. It allows you to easily create stats sets that can be shared between objects of similar characteristics, as well as add/remove modifiers that alters the value of those stats under certain circumstances (equipment, buffs/debuffs, power ups, ...). It is a useful package for people creating RPGs where they need to keep track of the stats of their characters, or even any type of game where you need a behaviour to be based on a numeric value, like the jumping range or speed in a platform game.  
The package itself is basically divided into three parts: 1) "StatType" and "StatTypeSet" are scriptable objects used to define individual stats and organize them into sets that can be shared between different similar objects. 2) The "SingleStat" class allows the creation and management of a single instance of a stat value and add/remove modifiers that affects it's final value. This is a normal C# script, so it can be instantiated anywhere in your code. 3) The "StatModifier" class allows you to create modifiers that will target a specific stat, it has options to choose the type of modifier (flat or percentage), as wells as options to modify the order which the modifier is applied, useful for situations where you want to make sure that a modifier is applied before or after others. Like the SingleStat script, the StatModifier class is also a normal C# script.  
This package also includes a custom editor for the "StatModifier" class, allowing you to setup easily modifiers through the inspector instead of through code, and also include a sample scene demonstrating how to use this tool to manage two different sets of stats at the same time.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Easier to create and define stats: By using ScriptableObjects, stat types and stat sets can be generated from the editor, making it easier to manage all your in-game stats.
- Safe to apply temporary stat changes: By using modifiers when changing the current stat instead of updating the value itself, we make sure that the original value is preserved, making it safer to roll back to its original when the temporary stat change wears off.
- Multiple events: The SingleStat class contains various events related to modifiers, allowing others classes to easily subscribe to stat related events.
- Modifiers order: The order which the modifiers are applied can be adjusted through their "order" parameter, allowing the creation of modifiers that have high/low priority.
- Custom editor for the StatsModifier class: Allows StatsModifier to be edited from the editor, instead of code only.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Create a "stat type" <a name="createAStatType"/>
- Stat types can be create by right-clicking the project window, choose "Create"->"ScriptableObjects"->"Stats System"-"Stat Type". The name of the file will be used as the name of the stat type as well.

### 4.2 Create a "stat set" <a name="createAStatSet"/>
- Stat sets can be create by right-clicking the project window, choose "Create"->"ScriptableObjects"->"Stats System"-"Stat Type Set"

### 4.3 Instantiate a "single stat" <a name="instantiateASingleStat"/>
An instance of the SingleStat class can be instantiated by calling its constructor and passing the StatType and base value as parameters. The minimum and maximum that a stat can reach can also be defined in the constructor as optional parameters.  
```csharp
public SingleStat(StatType statType, float statBaseValue, float statMinValue = float.MinValue, float statMaxValue = float.MaxValue)
```

### 4.4 Instantiate a "stats modifier" <a name="instantiateAStatsModifier"/>
An instance of the StatsModifier class can be instantiated in many ways, with the only required parameters being how much the stat should change, what statType is this modifier targeting and the type of modifier (flat, percentage additive, percentage multiplicative). Optional parameters include a value indicating the modifier order (passing a low number will give a higher priority when applying the modifier) and an Object indicating the source of the modifier (can be used to remove modifiers more easily). The package also includes a PropertyDrawer for the StatsModifier class, allowing them to be easily edited from the editor also.
```csharp
public StatsModifier(float value, StatType statTypeTarget, StatsModifiersType statsModifiersType, int modifierOrder, UnityEngine.Object modifierSource)
public StatsModifier(float value, StatType statTypeTarget, StatsModifiersType statsModifiersType)
public StatsModifier(float value, StatType statTypeTarget, StatsModifiersType statsModifiersType, int modifierOrder)
public StatsModifier(float value, StatType statTypeTarget, StatsModifiersType statsModifiersType, UnityEngine.Object modifierSource)
```

### 4.5 Add/Remove modifiers from a stat <a name="addRemoveModifiersFromAStat"
Modifiers can be added/removed from a stat by using the AddModifier/RemoveModifier functions in the SingleStat class by passing an instance of the StatsModifier class as a parameter. Modifiers can also be removed by calling RemoveAllModifiers or RemoveModifiersBySource functions.

## 5 - Documentation <a name="documentation"/>
### 5.1 SingleStat() <a name="singleStatSingleStat"/>
Instantiate a new instance of the SingleStat class
#### Declaration
```csharp
public SingleStat(StatType statType, float statBaseValue, float statMinValue = float.MinValue, float statMaxValue = float.MaxValue);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| StatType | statType | The stat type of this stat |
| float | statBaseValue | The stat initial value |
| float | statMinValue | The minimum value this stat can reach |
| float | statMaxValue | The maximum value this stat can reach |


### 5.2 SingleStat.StatBaseValue <a name="singleStatStatBaseValue"/>
Get the stat base value
#### Declaration
```csharp
public float StatBaseValue;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The stat base value |


### 5.3 SingleStat.Type <a name="singleStatStatType"/>
Get the type of this stat
#### Declaration
```csharp
public float Type;
```
#### Returns
| Type | Description |
| :--- | :--- |
| StatType | The type of this stat |


### 5.4 SingleStat.StatsModifiers <a name="singleStatStatsModifiers"/>
Get the modifiers of this stat
#### Declaration
```csharp
public List<StatsModifier> StatsModifiers;
```
#### Returns
| Type | Description |
| :--- | :--- |
| List<StatsModifier> | The modifiers on this stat |


### 5.5 SingleStat.OnSingleStatBaseValueChange <a name="singleStatOnSingleStatBaseValueChange"/>
Invoked when the base value of the stat has changed
#### Declaration
```csharp
public Action<float, float> OnSingleStatBaseValueChange;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| float | Base value of the stat after the change |
| float | the stat value with the modifiers applied after the change |


### 5.6 SingleStat.OnModifierAdded <a name="singleStatOnModifierAdded"/>
Invoked when a modifier is added to the stat
#### Declaration
```csharp
public Action<float, float> OnModifierAdded;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| float | Base value of the stat after the change |
| float | the stat value with the modifiers applied after the change |


### 5.7 SingleStat.OnModifierRemoved <a name="singleStatOnModifierRemoved"/>
Invoked when a modifier is removed from the stat
#### Declaration
```csharp
public Action<float, float> OnModifierRemoved;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| float | Base value of the stat after the change |
| float | the stat value with the modifiers applied after the change |


### 5.8 SingleStat.OnModifierListModified <a name="singleStatOnModifierListModified"/>
Invoked when the modifier list is modified
#### Declaration
```csharp
public Action<float, float> OnModifierListModified;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| float | Base value of the stat after the change |
| float | the stat value with the modifiers applied after the change |


### 5.9 SingleStat.GetFinalValueAfterModifiers <a name="singleStatGetFinalValueAfterModifiers"/>
Get the final stat value after the modifiers were applied
#### Declaration
```csharp
public float GetFinalValueAfterModifiers;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The final stat value after the modifiers were applied |


### 5.10 SingleStat.GetFinalValueAfterModifiersNormalized <a name="singleStatGetFinalValueAfterModifiersNormalized"/>
Get the final stat normalized after the modifiers were applied
#### Declaration
```csharp
public float GetFinalValueAfterModifiersNormalized;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The final stat normalized after the modifiers were applied |


### 5.11 SingleStat.GetStatBaseValueNormalized <a name="singleStatGetStatBaseValueNormalized"/>
Get the base stat normalized
#### Declaration
```csharp
public float GetStatBaseValueNormalized;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The base stat normalized |


### 5.12 SingleStat.IncreaseDecreaseBaseStat() <a name="singleStatIncreaseDecreaseBaseStat"/>
Increase/decrease the stat by the passed amount
#### Declaration
```csharp
public void IncreaseDecreaseBaseStat(float amount);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | amount | The amount to modify the stat |


### 5.13 SingleStat.AddModifier() <a name="singleStatAddModifier"/>
Add a modifier to the stat
#### Declaration
```csharp
public void AddModifier(StatsModifier statsModifier);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| StatsModifier | statsModifier | The modifier to be added |


### 5.14 SingleStat.RemoveModifier() <a name="singleStatRemoveModifier"/>
Remove a modifier from the stat
#### Declaration
```csharp
public bool RemoveModifier(StatsModifier statsModifier);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| StatsModifier | statsModifier | The modifier to be removed |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | If the modifier removal was successful or not |


### 5.15 SingleStat.RemoveAllModifiers() <a name="singleStatRemoveAllModifiers"/>
Remove all modifiers from the stat
#### Declaration
```csharp
public bool RemoveAllModifiers();
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | If modifiers were removed or not |


### 5.16 SingleStat.RemoveModifiersBySource() <a name="singleStatRemoveModifiersBySource"/>
Remove all the modifiers from a specific source
#### Declaration
```csharp
public bool RemoveModifiersBySource(Object modifierSource);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Object | modifierSource | The source indicating which modifiers should be removed |
#### Returns
| Type | Description |
| :--- | :--- |
| bool | If the modifier list was modified or not |


### 5.17 StatsModifier() <a name="statsModifierStatsModifier"/>
Instantiate a new instance of the StatsModifier class
#### Declaration
```csharp
public StatsModifier(float value, StatType statTypeTarget, StatsModifiersType statsModifiersType, int modifierOrder, UnityEngine.Object modifierSource);
public StatsModifier(float value, StatType statTypeTarget, StatsModifiersType statsModifiersType);
public StatsModifier(float value, StatType statTypeTarget, StatsModifiersType statsModifiersType, int modifierOrder);
public StatsModifier(float value, StatType statTypeTarget, StatsModifiersType statsModifiersType, UnityEngine.Object modifierSource);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | value | The value of this modifier |
| StatType | statTypeTarget | The statType that this modifier will modify |
| StatsModifiersType | statsModifiersType | The type of this modifier |
| int | modifierOrder | The order of this modifier when applying to the stat |
| Object | modifierSource | The source object of this modifier |


### 5.18 StatsModifier.Value <a name="statsModifierValue"/>
Get the modifier value
#### Declaration
```csharp
public float Value;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The modifier value |


### 5.19 StatsModifier.StatTypeTarget <a name="statsModifierStatTypeTarget"/>
Get the stat type who this modifier is targeting
#### Declaration
```csharp
public StatType StatTypeTarget;
```
#### Returns
| Type | Description |
| :--- | :--- |
| StatType | The stat type who this modifier is targeting |


### 5.20 StatsModifier.StatsModifiersType <a name="statsModifierStatsModifiersType"/>
Get the type of this modifier
#### Declaration
```csharp
public StatsModifiersType StatsModifiersType;
```
#### Returns
| Type | Description |
| :--- | :--- |
| StatsModifiersType | The type of this modifier |


### 5.21 StatsModifier.ModifierOrder <a name="statsModifierModifierOrder"/>
Get the order of this modifier when applying to the stat
#### Declaration
```csharp
public int ModifierOrder;
```
#### Returns
| Type | Description |
| :--- | :--- |
| int | The order of this modifier when applying to the stat |


### 5.22 StatsModifier.ModifierSource <a name="statsModifierModifierSource"/>
Get the source object of this modifier
#### Declaration
```csharp
public Object ModifierSource;
```
#### Returns
| Type | Description |
| :--- | :--- |
| Object | The source object of this modifier |

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
