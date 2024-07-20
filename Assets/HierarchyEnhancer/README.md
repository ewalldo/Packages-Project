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
    - [4.6 Renaming objects in the hierarchy ](#46-renaming-objects-in-the-hierarchy-)
    - [4.7 Hierarchy shortcuts ](#47-hierarchy-shortcuts-)
  - [5 - Contact Information ](#5---contact-information-)

## 1 - Introduction <a name="introduction"/>
Navigating and managing complex scenes in Unity, especially those with a multitude of objects and components, can be a daunting task. The default hierarchy view can quickly become cluttered, making it difficult to find and organize objects efficiently. Recognizing this challenge, we developed the Hierarchy Enhancer package to streamline the hierarchy management process and enhance the overall usability of Unity's editor.  

The Hierarchy Enhancer package offers several features designed to improve the way you interact with the hierarchy. These features include:  
1) Icon Display for Components: Easily visualize all the components attached to a GameObject directly in the hierarchy view through icons displayed next to the object name. This eliminates the need to scroll through the inspector or click through each child object to identify specific components, significantly speeding up your workflow when dealing with large scenes and complex objects.  

2) Header Creation for Organization: Introduce headers into the hierarchy to group related objects together. Headers help in logically organizing different sections of your hierarchy, making it simpler to manage and navigate through numerous objects. This is particularly useful in large-scale projects where keeping the hierarchy tidy is essential.  

3) Automated Object Sorting: Automatically sort GameObjects in the hierarchy based on specific criteria such as name or position. This feature helps maintain an organized hierarchy without the need for manual rearrangement, ensuring a consistent and orderly structure that can be easily maintained.  

4) Batch Renaming of GameObjects: Rename multiple GameObjects simultaneously with customizable renaming options. This feature is particularly beneficial when working on scenes with numerous objects that require systematic naming conventions, saving time and reducing the potential for errors.  

5) Hierarchy Shortcuts: Utilize a range of shortcuts when hovering over items in the hierarchy to perform common actions quickly. These shortcuts, such as activating/deactivating objects, focusing on objects in the scene view, expanding/collapsing objects, and deleting objects, enhance efficiency by reducing the number of steps needed to perform these actions.  

Each of these features is designed to address specific pain points commonly encountered when managing the hierarchy in Unity. By integrating the Hierarchy Enhancer into your workflow, you can expect a more organized, efficient, and user-friendly experience while working with complex scenes.  

In summary, the Hierarchy Enhancer is a helpful tool for Unity developers looking to improve their workflow, manage complex scenes more effectively, and save time on routine hierarchy management tasks. By enhancing the default hierarchy view, this package allows developers to focus more on creating and less on managing, leading to a more productive development process.  

This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.  

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release
- 1.1: Add option to sort hierarchy objects
- 1.1.1: Add more options in the project settings
- 1.2: Add shortcuts when hovering an item in the hierarchy
- 1.3: Add option to rename multiple objects

## 3 - Features <a name="features"/>
- Useful for identifying which components are attached to which objects.
- Useful for organizing hierarchy into different groups.
- Useful for sorting objects in the hierarchy.
- Useful to rename multiple objects at the same time.
- Provides shortcut options.
- Icons display can be toggled on and off.
- The appearance of the headers are customizable.
- Code can be easily extended: The code itself is organized in a way that is easy to understand, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Hierarchy settings <a name="hierarchySettings"/>
The settings for this package can be adjusted from the "Project Settings" menu. Click on the "Hierarchy Enhancer" option on the left and adjust your settings. The currents supported settings are icons display, icons size and icons limit.

### 4.2 Displaying icons <a name="displayingIcons"/>
By default, icons should be displayed as soons as your add this package to your project. If in case the icons are not being displayed, go to "Project Settings", click on the "Hierarchy Enhancer" option in the left menu and turn on the icons display.

### 4.3 Adding headers <a name="addingHeaders"/>
Headers can be added in two different ways:  
1) using the add object menu (it can be opened by right-clicking the hierarchy view or by clicking on the + sign at the top or by clicking on the GameObject option at the top of the unity project) and selecting the "Header" option (it should be located near the create empty option).  
2) by attaching the "HierarchyHeader" script to an gameObject.  

### 4.4 Customizing headers <a name="customizingHeaders"/>
Headers appearance can be customized in the inspector when you select them in the hierarchy. Options include the header and font color, font size, alignment and style.

### 4.5 Sorting objects in the hierarchy <a name="sortingObjectsInTheHierarchy"/>
Objects in the hierarchy can be sorted by right-clicking a game object and selecting the option "Sort". This should open an editor window where you can choose how the sorting will be performed. Below is an overview of the sorting options.  
- Sorting Target: Children (sort all children of each selected object), Selected only (sort only the selected objects)  
- Sorting Type: By Name (sort objects based on its name), By Position X/Y/Z (sort objects based on its position)  
- Sorting Order: Ascending (objects will be sorted in ascending order), Descending (objects will be sorted in descending order)  

### 4.6 Renaming objects in the hierarchy <a name="renamingObjectsInTheHierarchy"/>
Objects in the hierarchy can be renamed simultaneously by right-clicking a game object and selecting the option "Rename (HierarchyEnhancer)". This should open an editor window where you can choose how the renaming will be performed. Below is an overview of the renaming options.  
- Rename Target: Children (rename all children of each selected object), Selected only (rename only the selected objects).  
- Rename Affix: Suffix (affix added at the end of the name), Suffix (affix added at the start of the name).  
- Base name: The base name that all objects will share.    
- Start value: The start number value for the affix.  
- Minimum number of digits: How many digits at minimum will be displayed in the affix.  
- Affix template: The format of the affix to be attached to the name of all objects (must include one and only one lowercase 'x' character, which will be replaced by a number).  
- Preview: preview display of what the name will look like.  

### 4.7 Hierarchy shortcuts <a name="hierarchyShortcuts"/>
Shortcuts are available when hovering over an item in the hierarchy (make sure that the hierarchy is the focused window). The following supported shortcuts are:  
- Activate/deactivate: Press "A" when hovering over a gameObject to toggle its status between active and inactive.  
- Focus: Press "F" when hovering over a gameObject to focus on it on the Scene view.
- Expand/collapse: Press "C" when hovering over a gameObject to expand/collapse the object in the hierarchy.
- Delete: Press "Shift + X" when hovering over a gameObject to delete it from the hierarchy.

## 5 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com