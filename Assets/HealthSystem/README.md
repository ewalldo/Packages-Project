# Health System
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Adding health to a gameObject](#addingHealthToAGameObject)
  - [Modifying the health through damage or heal](#modifyingTheHealthThroughDamageOrHeal)
  - [Health events](#healthEvents)
  - [Interface support](#healthInterfaceSupport)
- [Documentation](#documentation)
  - [Health()](#healthConstructor)
  - [GetHealth](#healthGetHealth)
  - [GetHealthNormalized](#healthGetHealthNormalized)
  - [GetMaxHealth](#healthGetMaxHealth)
  - [IsDead](#healthIsDead)
  - [IsOnCriticalHealth](#healthIsOnCriticalHealth)
  - [IsOnFullHealth](#healthIsOnFullHealth)
  - [OnCurrentHealthChanged](#healthOnCurrentHealthChanged)
  - [OnMaxHealthChanged](#healthOnMaxHealthChanged)
  - [OnDamageTaken](#healthOnDamageTaken)
  - [OnDamageHealed](#healthOnDamageHealed)
  - [OnCriticalHealthStarted](#healthOnCriticalHealthStarted)
  - [OnCriticalHealthEnded](#healthOnCriticalHealthEnded)
  - [OnDeath](#healthOnDeath)
  - [OnRevive](#healthOnRevive)
  - [TakeDamage()](#healthTakeDamage)
  - [Die()](#healthDie)
  - [HealDamage()](#healthHealDamage)
  - [HealToFull()](#healthHealToFull)
  - [SetMaxHealth()](#healthSetMaxHealth)
  - [SetHealth()](#healthSetHealth)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The Health System package provides a comprehensive and easy-to-use system for adding health to any object in a Unity scene. With this package, you can add health to any object by simply attaching the HealthComponent script, and set the inital values in the editor or by instanciating a new class inside a script.  
The Health System package provides robust functionality for modifying health, allowing you to simulate damage and healing. Also, it provides several events that are triggered when the health of an object changes passing the related parameters as attribute together with the causer of the event, thus making it useful to trigger custom effects (like different colors depending on the type of damage) or implement other features (like a killfeed showing who caused a death).  
Overall, this Health System Package for Unity is an useful tool for any developer looking to add health to their objects in game. Its easy-to-use and convenient features make it a valuable asset for creating games and applications.  

This package has been updated to Unity 6000.3.9f1. However, it should work without issue with earlier or future versions of Unity.  
Please let us know if you encounter any issues with the version of Unity you are using.

## 2 - Version History <a name="versionHistory"/>
- 1.0.0: Initial release
- 1.0.1: Add a non-MonoBehaviour version of the health component
- 1.1: Add multiple interface support
- 1.1.1: Ensure package functionality in Unity version 6000.3.9f1

## 3 - Features <a name="features"/>
- Easy to use: Just add a script to any object that needs health, such as characters or props.
- Easy to modify: The class exposes functions to modify the value of the health, making it easier to apply damage or healing to the health.
- Multiple events: The HealthComponent class contains various events, allowing others classes to easily subscribe to specific ones creating a more decoupled and easier to debug code.
- Events causer: All the events has a "causer" parameter to indicate which object is causing the health to change. That parameter can be useful to trigger custom effects based on the type of damage or healing, and for features like killfeed.
- Custom editor: Allows the HealthComponent class to be modified from the editor, making it easier for non-programmers to use it.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Adding health to a gameObject <a name="addingHealthToAGameObject"/>
- To add health to any gameObject in Unity, just drag the HealthComponent script to it. The values of max health, start health and critical threshold can be set through the inspector.
- Or just instantiate the "Health" class inside any of your scripts.
```csharp
// Constructor
public Health(float maxHealth, float curHealth, float criticalHealthThreshold = 0f)

// Instantiate example
private Health characterHealth = new Health(100, 100, 03f);
```

### 4.2 Modifying the health through damage or heal <a name="modifyingTheHealthThroughDamageOrHeal"/>
To apply damage or healing to the health, just the invoke the TakeDamage() and HealDamage() functions in the HealthComponent script.  
```csharp
public void TakeDamage(float amountDamage, object damageCauser);
public void HealDamage(float amountHeal, object healingCauser);
```

### 4.3 Health events <a name="healthEvents"/>
The HealthComponent and Health script has many events related to changing the health value. For more details on the events, please check the documentation section.  
```csharp
public event Action<float, float, object> OnCurrentHealthChanged;
public event Action<float, float, object> OnMaxHealthChanged;
public event Action<float, float, object> OnDamageTaken;
public event Action<float, float, object> OnDamageHealed;
public event Action OnCriticalHealthStarted;
public event Action OnCriticalHealthEnded;
public event Action<object> OnDeath;
public event Action<float, object> OnRevive;
```

### 4.4 Interface support <a name="healthInterfaceSupport"/>
The HealthComponent and Health script implements the following interfaces. Feel free to reference them in your code if need it.  
```csharp
IHealth
IDamageable
IHealable
IHealthStatus
```

## 5 - Documentation <a name="documentation"/>
### 5.1 Health() <a name="healthConstructor"/>
Instantiate a new instance of the Health class
#### Declaration
```csharp
public Health(float maxHealth, float curHealth, float criticalHealthThreshold = 0f);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | maxHealth | The max Health value of this health component |
| float | curHealth | The current health of the health component |
| float | criticalHealthThreshold | The percentage that the health should be (related to max health) to be considered in a critical state |


### 5.2 GetHealth <a name="healthGetHealth"/>
### 5.2.1 Health.GetHealth
### 5.2.2 HealthComponent.GetHealth
### 5.2.3 IHealth.GetHealth
### 5.2.4 IHealthStatus.GetHealth
Get the current health of the health component
#### Declaration
```csharp
public float GetHealth;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The current health |


### 5.3 GetHealthNormalized <a name="healthGetHealthNormalized"/>
### 5.3.1 Health.GetHealthNormalized
### 5.3.2 HealthComponent.GetHealthNormalized
### 5.3.3 IHealth.GetHealthNormalized
### 5.3.4 IHealthStatus.GetHealthNormalized
Get the normalized current health of the health component
#### Declaration
```csharp
public float GetHealthNormalized;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The current health normalized |


### 5.4 GetMaxHealth <a name="healthGetMaxHealth"/>
### 5.4.1 Health.GetMaxHealth
### 5.4.2 HealthComponent.GetMaxHealth
### 5.4.3 IHealth.GetMaxHealth
### 5.4.4 IHealthStatus.GetMaxHealth
Get the maxHealth value of this health component
#### Declaration
```csharp
public float GetMaxHealth;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The max health value |


### 5.5 IsDead <a name="healthIsDead"/>
### 5.5.1 Health.IsDead
### 5.5.2 HealthComponent.IsDead
### 5.5.3 IHealth.IsDead
### 5.5.4 IHealthStatus.IsDead
Check if the current health is zero or below
#### Declaration
```csharp
public bool IsDead;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | Is the health value zero or below |


### 5.6 IsOnCriticalHealth <a name="healthIsOnCriticalHealth"/>
### 5.6.1 Health.IsOnCriticalHealth
### 5.6.2 HealthComponent.IsOnCriticalHealth
### 5.6.3 IHealth.IsOnCriticalHealth
### 5.6.4 IHealthStatus.IsOnCriticalHealth
Check if the current health is on a critical value
#### Declaration
```csharp
public bool IsOnCriticalHealth;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | Is the health value under the critical threshold |


### 5.7 IsOnFullHealth <a name="healthIsOnFullHealth"/>
### 5.7.1 Health.IsOnFullHealth
### 5.7.2 HealthComponent.IsOnFullHealth
### 5.7.3 IHealth.IsOnFullHealth
### 5.7.4 IHealthStatus.IsOnFullHealth
Check if the current health value is the same as the full health
#### Declaration
```csharp
public bool IsOnFullHealth;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | Is the current health value the same as the full health |


### 5.8 OnCurrentHealthChanged <a name="healthOnCurrentHealthChanged"/>
### 5.8.1 Health.IsOnFullHealth
### 5.8.2 HealthComponent.IsOnFullHealth
### 5.8.3 IHealth.IsOnFullHealth
Invoked when the current health value changes
#### Declaration
```csharp
public Action<float, float, object> OnCurrentHealthChanged;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| float | How much has the health changed (positive value means heal and negative means damage) |
| float | Amount of health after the change |
| object | The object who caused the current health to change |


### 5.9 OnMaxHealthChanged <a name="healthOnMaxHealthChanged"/>
### 5.9.1 Health.OnMaxHealthChanged
### 5.9.2 HealthComponent.OnMaxHealthChanged
### 5.9.3 IHealth.OnMaxHealthChanged
Invoked when the max health value changes
#### Declaration
```csharp
public Action<float, float, object> OnMaxHealthChanged;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| float | How much has the max health changed (positive value means increase and negative means decrease) |
| float | Amount of max health after the change |
| object | The object who caused the max health to change |


### 5.10 OnDamageTaken <a name="healthOnDamageTaken"/>
### 5.10.1 Health.OnDamageTaken
### 5.10.2 HealthComponent.OnDamageTaken
### 5.10.3 IHealth.OnDamageTaken
### 5.10.4 IDamageable.OnDamageTaken
Invoked when some damage is applied to the health
#### Declaration
```csharp
public Action<float, float, object> OnDamageTaken;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| float | Amount of damage taken |
| float | Amount of health after the damage is applied |
| object | The object who caused damage |


### 5.11 OnDamageHealed <a name="healthOnDamageHealed"/>
### 5.11.1 Health.OnDamageHealed
### 5.11.2 HealthComponent.OnDamageHealed
### 5.11.3 IHealth.OnDamageHealed
### 5.11.4 IHealable.OnDamageHealed
Invoked when some healing is applied to the health
#### Declaration
```csharp
public Action<float, float, object> OnDamageHealed;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| float | Amount of healing |
| float | Amount of health after the healing is applied |
| object | The object who caused healing |


### 5.12 OnCriticalHealthStarted <a name="healthOnCriticalHealthStarted"/>
### 5.12.1 Health.OnCriticalHealthStarted
### 5.12.2 HealthComponent.OnCriticalHealthStarted
### 5.12.3 IHealth.OnCriticalHealthStarted
### 5.12.4 IHealthStatus.OnCriticalHealthStarted
Invoked when the health reaches a critical value
#### Declaration
```csharp
public Action OnCriticalHealthStarted;
```


### 5.13 OnCriticalHealthEnded <a name="healthOnCriticalHealthEnded"/>
### 5.13.1 Health.OnCriticalHealthEnded
### 5.13.2 HealthComponent.OnCriticalHealthEnded
### 5.13.3 IHealth.OnCriticalHealthEnded
### 5.13.4 IHealthStatus.OnCriticalHealthEnded
Invoked when the health leaves the critical value threshold
#### Declaration
```csharp
public Action OnCriticalHealthEnded;
```


### 5.14 OnDeath <a name="healthOnDeath"/>
### 5.14.1 Health.OnDeath
### 5.14.2 HealthComponent.OnDeath
### 5.14.3 IHealth.OnDeath
### 5.14.4 IDamageable.OnDeath
Invoked when the health reaches 0
#### Declaration
```csharp
public Action<object> OnDeath;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| object | The object who caused the death |


### 5.15 OnRevive <a name="healthOnRevive"/>
### 5.15.1 Health.OnRevive
### 5.15.2 HealthComponent.OnRevive
### 5.15.3 IHealth.OnRevive
### 5.15.4 IHealable.OnRevive
Invoked when the health goes from 0 to a positive value
#### Declaration
```csharp
public Action<float, object> OnRevive;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| float | Amount of health after the revive is applied |
| object | The object who caused the revive |


### 5.16 TakeDamage <a name="healthTakeDamage"/>
### 5.16.1 Health.TakeDamage
### 5.16.2 HealthComponent.TakeDamage
### 5.16.3 IHealth.TakeDamage
### 5.16.4 IDamageable.TakeDamage
Apply damage to the healthComponent
#### Declaration
```csharp
public void TakeDamage(float amountDamage, object damageCauser);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | amountDamage | Amount of damage to cause |
| object | damageCauser | The object responsible to cause damage to this healthComponent |


### 5.17 Die <a name="healthDie"/>
### 5.17.1 Health.Die
### 5.17.2 HealthComponent.Die
### 5.17.3 IHealth.Die
### 5.17.4 IDamageable.Die
Reduce the health value to zero
#### Declaration
```csharp
public void Die(object deathCauser);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| object | deathCauser | The object responsible for the death |


### 5.18 HealDamage <a name="healthHealDamage"/>
### 5.18.1 Health.HealDamage
### 5.18.2 HealthComponent.HealDamage
### 5.18.3 IHealth.HealDamage
### 5.18.4 IHealable.HealDamage
Apply healing to the healthComponent
#### Declaration
```csharp
public void HealDamage(float amountHeal, object healingCauser);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | amountToHeal | Amount of healing |
| object | healingCauser | The object responsible to heal this healthComponent |


### 5.19 HealToFull <a name="healthHealToFull"/>
### 5.19.1 Health.HealToFull
### 5.19.2 HealthComponent.HealToFull
### 5.19.3 IHealth.HealToFull
### 5.19.4 IHealable.HealToFull
Heal this healthComponent to its maximum capacity
#### Declaration
```csharp
public void HealToFull(object healingCauser);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| object | healingCauser | The object responsible to full heal this healthComponent |


### 5.20 SetMaxHealth <a name="healthSetMaxHealth"/>
### 5.20.1 Health.SetMaxHealth
### 5.20.2 HealthComponent.SetMaxHealth
### 5.20.3 IHealth.SetMaxHealth
Update the maxHealth value of this component
#### Declaration
```csharp
public void SetMaxHealth(float newMaxHealth, bool updateToFullHealth, object changeCauser);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | newMaxHealth | The new amount of maxHealth for this healthComponent |
| bool | updateToFullHealth | Should the health value be replenished to full after modifying the max health? |
| object | changeCauser | The object responsible for modifying the maxHealth of this healthComponent |


### 5.21 SetHealth <a name="healthSetHealth"/>
### 5.21.1 Health.SetHealth
### 5.21.2 HealthComponent.SetHealth
### 5.21.3 IHealth.SetHealth
Set the health to a specific amount
#### Declaration
```csharp
public void SetHealth(float newHealth, object changeCauser);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | newHealth | The new amount of health this healthComponent will have |
| object | changeCauser | The object responsible for modify the health value of this healthComponent |

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
