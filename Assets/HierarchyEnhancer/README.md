# Hierarchy Enhancer
## Table of contents
- [Hierarchy Enhancer](#hierarchy-enhancer)
  - [Table of contents](#table-of-contents)
  - [1 - Introduction ](#1---introduction-)
  - [2 - Version History ](#2---version-history-)
  - [3 - Features ](#3---features-)
  - [4 - Get Started ](#4---get-started-)
    - [4.1 Displaying icons ](#41-displaying-icons-)
    - [4.2 Adding headers ](#42-adding-headers-)
    - [4.3 Customizing headers ](#43-customizing-headers-)
  - [5 - Contact Information ](#5---contact-information-)

## 1 - Introduction <a name="introduction"/>
When working on complex scenes with many objects and components, Unity's hierarchy can become cluttered and difficult to navigate. So to solve this problem, we designed this package to improve the usability of it and help developers to better manage their scene hierarchy.  
Currently, this package has two main features:  
1) The ability to display all the components attached to a gameObject as icons beside the object name.  
2) The ability to create header displays to easily organize different sections of objects.  
The first feature makes it easier to quickly identify the components attached to a gameObject without having to scroll through the inspector to see which components who are attached to it or click through all children of an object to check which one has a specific component. This can save a lot of time when working with large scenes and complex objects.  
The second feature allows you to create headers in the hierarchy view to group related objects together. This can be especially useful when working on scenes with many objects, as it makes it easier to organize and navigate the hierarchy view.  
Overall, the Hierarchy Enhancer package is a simple yet powerful tool for improving the usability of the Unity editor's hierarchy view. It can save time and make it easier to manage complex scenes, making it an essential tool for Unity developers.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Useful for identifying which components are attached to which objects.
- Useful for organizing hierarchy into different groups
- Icons display can be toggled on and off
- The appearance of the headers are customizable
- Code can be easily extended: The code itself is organized in a way that is easy to understand, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Displaying icons <a name="displayingIcons"/>
- By default, icons should be displayed as soons as your add this package to your project. If in case the icons are not being displayed, go to "Project Settings", click on the "Hierarchy Enhancer" option in the left menu and turn on the icons display.

### 4.2 Adding headers <a name="addingHeaders"/>
- Headers can be added in two different ways, 1) using the add object menu (it can be opened by right-clicking the hierarchy view or by clicking on the + sign at the top or by clicking on the GameObject option at the top of the unity project) and selecting the "Header" option (it should be located near the create empty option), and 2) by attaching the "HierarchyHeader" script to an gameObject.

### 4.3 Customizing headers <a name="customizingHeaders"/>
- Headers appearance can be customized in the inspector when you select them in the hierarchy. Options include the header and font color, font size, alignment and style.

## 5 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com