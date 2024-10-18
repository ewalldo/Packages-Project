# Loot Pool
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Create a loot pool](#createALootPool)
  - [Edit a loot pool](#editALootPool)
  - [Spawn items from the loot pool](#spawnFromALootPool)
- [Documentation](#documentation)
  - [LootPool.PullIndependentLoot()](#pullIndependentLoot)
  - [LootPool.DependentLoot()](#pullDependentLoot)
  - [LootPool.PullLoot()](#pullLoot)
  - [LootPool.SpawnDrop()](#spawnDrop)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The "Loot Pool" package is a tool for creating and managing pools of loot in Unity projects. It allows you to define a set of items that can be spawned under certain conditions (when a character/monster is defeated, when the player reachs a point in the map, ...).  
The pool itself is divided into two parts, a independent pool (each item in the list has its own chance of being pulled) and a dependent pool (the chance of a item being pulled depends on the other items in the list), giving you more control on how and what items will be spawned on the map. Options like the probability, minimum/maximum number of each items can easily be defined thanks to a clean and easy to use UI.  
Also, the package contains options on how and where the loot can be spawned, parameters like the position and offset can be defined by code.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release
- 1.0.1: Refactor editor code

## 3 - Features <a name="features"/>
- Easier to create and manage loot pools: By using ScriptablesObjects, loot pools can be created and managed from the editor, without the need of any code.
- More control on the loot pool: Loot pool is divided into two different pools (independent and dependent), giving more control and options on the items being spawned. Also, minimum and maximum quantity of each loot can be set individually.
- Clean inspector UI: Simple and clean UI allows you to create loot pools very fast, while the graph at the bottom gives you a easy way to visualize the probabilities of each one of the items being spawned. Also, the graph is capable of display warnings in case a item is not set up correctly.
- Spawn options: There are a number of options to configure how the items from the loot pool are spawned. Parameters options include the spawn position, offset, number of pulls for each pool and so on.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Create a loot pool <a name="createALootPool"/>
- Loot pools can be created by right-clicking the project window, choose "Create"->"ScriptableObjects"->"Loot Pool"

### 4.2 Edit a loot pool <a name="editALootPool"/>
The loot pool UI is organized into three parts: The "independent pool", the "dependent pool" and the "visualization area".
- Items can be added or removed from a pool by using the "+" and "-" signs respectively.
- The "Item" field corresponds to the loot item
- The "Min" and "Max" fields allows you to define what is the minimum and maximum amount that will be spawned for this item (max value is inclusive)
- The "Drop Chance (0~1)" field represents the probability of the item being dropped (with 0 being 0% and 1 being 100%)
- The visualization tool at the bottom gives you a nice view on the probabilities of the spawn for this loot pool, as well as showing warning in case a item is not set up properly.

### 4.3 Spawn items from the loot pool <a name="spawnFromALootPool"/>
- Items can be spawned through code by using the SpawnDrop function in the LootPool script. Details on how use the SpawnDrop function can be found in the documentation part.

## 5 - Documentation <a name="documentation"/>
### 5.1 LootPool.PullIndependentLoot() <a name="pullIndependentLoot"/>
Pull loot from a list in an independent way (each item in the list has its own chance of being pulled)
#### Declaration
```csharp
public static List<GameObject> PullIndependentLoot(List<LootItem> lootItems, int independentPulls);
public List<GameObject> PullIndependentLoot(int independentPulls);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| List<LootItem> | lootItems | The independent list to pull items from |
| int | independentPulls | How many times it should pull from the list |
#### Returns
| Type | Description |
| :--- | :--- |
| List<GameObject> | List of GameObjects containing the pulled items |


### 5.2 LootPool.PullDependentLoot() <a name="pullDependentLoot"/>
Pull loot from a list in a dependent way (the chance of a item being pulled depends on the other items in the list)
#### Declaration
```csharp
public static List<GameObject> PullDependentLoot(List<LootItem> lootItems, int dependentPulls);
public List<GameObject> PullDependentLoot(int dependentPulls);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| List<LootItem> | lootItems | The dependent list to pull items from |
| int | dependentPulls | How many times it should pull from the list |
#### Returns
| Type | Description |
| :--- | :--- |
| List<GameObject> | List of GameObjects containing the pulled items |


### 5.3 LootPool.PullLoot() <a name="pullLoot"/>
Pull loot from the loot pool
#### Declaration
```csharp
public List<GameObject> PullDependentLoot(int independentPulls, int dependentPulls);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | independentPulls | How many times it should pull from the independent list |
| int | dependentPulls | How many times it should pull from the dependent list |
#### Returns
| Type | Description |
| :--- | :--- |
| List<GameObject> | List of GameObjects containing the pulled items |


### 5.4 LootPool.SpawnDrop() <a name="spawnDrop"/>
Pulls and spawn the loot from the loot pool
#### Declaration
```csharp
public void SpawnDrop(Transform spawnPosition, Vector3 offsetRange, int independentPulls = 1, int dependentPulls = 1);
public void SpawnDrop(Transform spawnPosition, float offsetRange, int independentPulls = 1, int dependentPulls = 1);
public void SpawnDrop(Transform spawnPosition, int independentPulls = 1, int dependentPulls = 1);
public static void SpawnDrop(List<LootItem> lootItems, Transform spawnPosition, Vector3 offsetRange, int numberPulls = 1, bool isIndependentLoot = true);
public static void SpawnDrop(List<LootItem> lootItems, Transform spawnPosition, float offsetRange, int numberPulls = 1, bool isIndependentLoot = true);
public static void SpawnDrop(List<LootItem> lootItems, Transform spawnPosition, int numberPulls = 1, bool isIndependentLoot = true);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | spawnPosition | The central position where the loot will be spawned |
| Vector3 | offsetRange | The offset range from the spawnPosition (calculated independent for each item) |
| float | offsetRange | The offset range from the spawnPosition (calculated independent for each item), applied to all axis |
| int | independentPulls | How many times it should pull from the independent list |
| int | dependentPulls | How many times it should pull from the dependent list |
| List<LootItem> | lootItems | The pool of items to pull from |

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
