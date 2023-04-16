# Health System
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Adding health to a gameObject](#addingHealthToAGameObject)
  - [Modifying the health through damage or heal](#modifyingTheHealthThroughDamageOrHeal)
  - [HealthComponent events](#healthComponentEvents)
- [Documentation](#documentation)
  - [HealthComponent.GetHealth](#healthComponentGetHealth)
  - [HealthComponent.GetHealthNormalized](#healthComponentGetHealthNormalized)
  - [HealthComponent.GetMaxHealth](#healthComponentGetMaxHealth)
  - [HealthComponent.IsDead](#healthComponentIsDead)
  - [HealthComponent.IsOnCriticalHealth](#healthComponentIsOnCriticalHealth)
  - [HealthComponent.IsOnFullHealth](#healthComponentIsOnFullHealth)
  - [HealthComponent.OnCurrentHealthChanged](#healthComponentOnCurrentHealthChanged)
  - [HealthComponent.OnMaxHealthChanged](#healthComponentOnMaxHealthChanged)
  - [HealthComponent.OnDamageTaken](#healthComponentOnDamageTaken)
  - [HealthComponent.OnDamageHealed](#healthComponentOnDamageHealed)
  - [HealthComponent.OnCriticalHealthStarted](#healthComponentOnCriticalHealthStarted)
  - [HealthComponent.OnCriticalHealthEnded](#healthComponentOnCriticalHealthEnded)
  - [HealthComponent.OnDeath](#healthComponentOnDeath)
  - [HealthComponent.OnRevive](#healthComponentOnRevive)
  - [HealthComponent.TakeDamage](#healthComponentTakeDamage)
  - [HealthComponent.Die](#healthComponentDie)
  - [HealthComponent.HealDamage](#healthComponentHealDamage)
  - [HealthComponent.HealToFull](#healthComponentHealToFull)
  - [HealthComponent.SetMaxHealth](#healthComponentSetMaxHealth)
  - [HealthComponent.SetHealth](#healthComponentSetHealth)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The Health System package provides a comprehensive and easy-to-use system for adding health to any object in a Unity scene. With this package, you can add health to any object by simply attaching the HealthComponent script, and set the inital values in the editor.  
The Health System package provides robust functionality for modifying health, allowing you to simulate damage and healing. Also, it provides several events that are triggered when the health of an object changes passing the related parameters as attribute together with the causer of the event, thus making it useful to trigger custom effects (like different colors depending on the type of damage) or implement other features (like a killfeed showing who caused a death).  
Overall, this Health System Package for Unity is an useful tool for any developer looking to add health to their objects in game. Its easy-to-use and convenient features make it a valuable asset for creating games and applications.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

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

### 4.2 Modifying the health through damage or heal <a name="modifyingTheHealthThroughDamageOrHeal"/>
To apply damage or healing to the health component, just the invoke the TakeDamage() and HealDamage() functions in the HealthComponent script.  
```csharp
public void TakeDamage(float amountDamage, object damageCauser);
public void HealDamage(float amountHeal, object healingCauser);
```

### 4.3 HealthComponent events <a name="healthComponentEvents"/>
The HealthComponent script has many events related to changing the health value. For more details on the events, please check the documentation section.  
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

## 5 - Documentation <a name="documentation"/>
### 5.1 HealthComponent.GetHealth <a name="healthComponentGetHealth"/>
Get the current health of the health component
#### Declaration
```csharp
public float GetHealth;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The current health |


### 5.2 HealthComponent.GetHealthNormalized <a name="healthComponentGetHealthNormalized"/>
Get the normalized current health of the health component
#### Declaration
```csharp
public float GetHealthNormalized;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The current health normalized |


### 5.3 HealthComponent.GetMaxHealth <a name="healthComponentGetMaxHealth"/>
Get the maxHealth value of this health component
#### Declaration
```csharp
public float GetMaxHealth;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The max health value |


### 5.4 HealthComponent.IsDead <a name="healthComponentIsDead"/>
Check if the current health is zero or below
#### Declaration
```csharp
public bool IsDead;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | Is the health value zero or below |


### 5.5 HealthComponent.IsOnCriticalHealth <a name="healthComponentIsOnCriticalHealth"/>
Check if the current health is on a critical value
#### Declaration
```csharp
public bool IsOnCriticalHealth;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | Is the health value under the critical threshold |


### 5.6 HealthComponent.IsOnFullHealth <a name="healthComponentIsOnFullHealth"/>
Check if the current health value is the same as the full health
#### Declaration
```csharp
public bool IsOnFullHealth;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | Is the current health value the same as the full health |


### 5.7 HealthComponent.OnCurrentHealthChanged <a name="healthComponentOnCurrentHealthChanged"/>
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


### 5.8 HealthComponent.OnMaxHealthChanged <a name="healthComponentOnMaxHealthChanged"/>
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


### 5.9 HealthComponent.OnDamageTaken <a name="healthComponentOnDamageTaken"/>
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


### 5.10 HealthComponent.OnDamageHealed <a name="healthComponentOnDamageHealed"/>
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


### 5.11 HealthComponent.OnCriticalHealthStarted <a name="healthComponentOnCriticalHealthStarted"/>
Invoked when the health reaches a critical value
#### Declaration
```csharp
public Action OnCriticalHealthStarted;
```


### 5.12 HealthComponent.OnCriticalHealthEnded <a name="healthComponentOnCriticalHealthEnded"/>
Invoked when the health leaves the critical value threshold
#### Declaration
```csharp
public Action OnCriticalHealthEnded;
```


### 5.13 HealthComponent.OnDeath <a name="healthComponentOnDeath"/>
Invoked when the health reaches 0
#### Declaration
```csharp
public Action<object> OnDeath;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| object | The object who caused the death |


### 5.14 HealthComponent.OnRevive <a name="healthComponentOnRevive"/>
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


### 5.15 HealthComponent.TakeDamage <a name="healthComponentTakeDamage"/>
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


### 5.16 HealthComponent.Die <a name="healthComponentDie"/>
Reduce the health value to zero
#### Declaration
```csharp
public void Die(object deathCauser);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| object | deathCauser | The object responsible for the death |


### 5.17 HealthComponent.HealDamage <a name="healthComponentHealDamage"/>
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


### 5.18 HealthComponent.HealToFull <a name="healthComponentHealToFull"/>
Heal this healthComponent to its maximum capacity
#### Declaration
```csharp
public void HealToFull(object healingCauser);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| object | healingCauser | The object responsible to full heal this healthComponent |


### 5.19 HealthComponent.SetMaxHealth <a name="healthComponentSetMaxHealth"/>
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


### 5.20 HealthComponent.SetHealth <a name="healthComponentSetHealth"/>
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
