# Hierarchy Enhancer
## Table of contents
- [Hierarchy Enhancer](#hierarchy-enhancer)
  - [Table of contents](#table-of-contents)
  - [1 - Introduction ](#1---introduction-)
  - [2 - Version History ](#2---version-history-)
  - [3 - Features ](#3---features-)
  - [4 - Get Started ](#4---get-started-)
    - [4.1 Hierarchy settings ](#41-hierarchy-settings-)
    - [4.2 Displaying icons ](#42-displaying-icons-)
    - [4.3 Adding headers ](#43-adding-headers-)
    - [4.4 Customizing headers ](#44-customizing-headers-)
    - [4.5 Sorting objects in the hierarchy ](#45-sorting-objects-in-the-hierarchy-)
    - [4.6 Hierarchy shortcuts ](#46-hierarchy-shortcuts-)
  - [5 - Contact Information ](#5---contact-information-)

## 1 - Introduction <a name="introduction"/>
When working on complex scenes with many objects and components, Unity's hierarchy can become cluttered and difficult to navigate. So to solve this problem, we designed this package to improve the usability of it and help developers to better manage their scene hierarchy.  
Currently, this package has three main features:  
1) The ability to display all the components attached to a gameObject as icons beside the object name.  
2) The ability to create header displays to easily organize different sections of objects.  
3) The ability to sort gameObjects in the hierarchy based on a condition.  
4) The ability to use shortcuts when hovering over an item in the hierarchy.  

The first feature makes it easier to quickly identify the components attached to a gameObject without having to scroll through the inspector to see which components are attached to it or click through all children of an object to check which one has a specific component. This can save a lot of time when working with large scenes and complex objects.  
The second feature allows you to create headers in the hierarchy view to group related objects together. This can be especially useful when working on scenes with many objects, as it makes it easier to organize and navigate the hierarchy view.  
The third feature allows you to automatically sort objects in the hierarchy based on its name or position, thus allowing you to quickly organize objects without having to manually move them in the hierarchy.  
Overall, the Hierarchy Enhancer package is a simple yet powerful tool for improving the usability of the Unity editor's hierarchy view. It can save time and make it easier to manage complex scenes, making it an essential tool for Unity developers.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release
- 1.1: Add option to sort hierarchy objects
- 1.1.1: Add more options in the project settings
- 1.2: Add shortcuts when hovering an item in the hierarchy

## 3 - Features <a name="features"/>
- Useful for identifying which components are attached to which objects.
- Useful for organizing hierarchy into different groups.
- Useful for sort objects in the hierarchy.
- Shortcut options.
- Icons display can be toggled on and off.
- The appearance of the headers are customizable.
- Code can be easily extended: The code itself is organized in a way that is easy to understand, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Hierarchy settings <a name="hierarchySettings"/>
The settings for this package can be adjusted from the "Project Settings" menu. Click on the "Hierarchy Enhancer" option on the left and adjust your settings. The currents supported settings are icons display, icons size and icons limit.

### 4.2 Displaying icons <a name="displayingIcons"/>
By default, icons should be displayed as soons as your add this package to your project. If in case the icons are not being displayed, go to "Project Settings", click on the "Hierarchy Enhancer" option in the left menu and turn on the icons display.

### 4.3 Adding headers <a name="addingHeaders"/>
Headers can be added in two different ways, 1) using the add object menu (it can be opened by right-clicking the hierarchy view or by clicking on the + sign at the top or by clicking on the GameObject option at the top of the unity project) and selecting the "Header" option (it should be located near the create empty option), and 2) by attaching the "HierarchyHeader" script to an gameObject.

### 4.4 Customizing headers <a name="customizingHeaders"/>
Headers appearance can be customized in the inspector when you select them in the hierarchy. Options include the header and font color, font size, alignment and style.

### 4.5 Sorting objects in the hierarchy <a name="sortingObjectsInTheHierarchy"/>
Objects in the hierarchy can be sorted by right-clicking a game object and selecting the option "Sort". This should open an editor window where you can choose how the sorting will be performed. Below is an overview of the sorting options.  
- Sorting Target: Children (sort all children of each selected object), Selected only (sort only the selected objects)  
- Sorting Type: By Name (sort objects based on its name), By Position X/Y/Z (sort objects based on its position)  
- Sorting Order: Ascending (objects will be sorted in ascending order), Descending (objects will be sorted in descending order)  

### 4.6 Hierarchy shortcuts <a name="hierarchyShortcuts"/>
Shortcuts are available when hovering over an item in the hierarchy (make sure that the hierarchy is the focused window). The following supported shortcuts are:  
- Activate/deactivate: Press "A" when hovering over a gameObject to toggle its status between active and inactive.  
- Focus: Press "F" when hovering over a gameObject to focus on it on the Scene view.
- Expand/collapse: Press "C" when hovering over a gameObject to expand/collapse the object in the hierarchy.
- Delete: Press "Shift + X" when hovering over a gameObject to delete it from the hierarchy.

## 5 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com