# Selection History
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Adding Selection History to the Editor](#addingSelectionHistoryToTheEditor)
  - [Using the Selection History](#usingTheSelectionHistory)
  - [Customizing Settings](#customizingSettings)
  - [Clearing the History](#clearingTheHistory)
  - [Persisting Settings](#persistingSettings)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The Selection History package for Unity is an editor tool designed to help developers efficiently navigate through their recent selection history, allowing you to quickly revisit previously selected objects within both the Project and Hierarchy windows. With this package, you can improve your workflow by saving time and minimizing repetitive navigation steps.  
Ideal for Unity developers and designers, the Selection History package is useful for level design, asset organization, and rapid iteration. The package is fully customizable, enabling you to adjust the length of the history, toggle icon display, and specify which windows selections to track.  
This package has been tested with Unity version 2022.1 and is expected to work with both older and future versions.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Displays a history of recently selected objects, accessible in a separate window.
- Configurable history length, with options to customize which windows (Hierarchy or Project) are tracked.
- Option to display or hide object icons for a more visual history view.
- Quick access to previously selected objects with a single click, saving time in scene navigation.
- Persistent settings that are stored between sessions, so your preferences are always remembered.
- Easy Integration: Simple setup within the Unity Editor; no scripting knowledge required.
- Code can be easily extended: The code itself is organized in a way that is easy to understand, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Adding Selection History to the Editor <a name="addingSelectionHistoryToTheEditor"/>
To open the Selection History window, go to the top menu bar, click on Window -> General, then select Selection History Window. This will open a new tab that you can dock anywhere in the Unity Editor.

### 4.2 Using the Selection History <a name="usingTheSelectionHistory"/>
Once the Selection History window is open, it will automatically begin tracking your selections:
- Any GameObject selected in either the Hierarchy or Project window will be added to the top of the list.
- You can click on any item in the list to instantly select it and focus on that object in the editor.
- If you want to clear the history, simply click the Clear button at the bottom of the window.

### 4.3 Customizing Settings <a name="customizingSettings"/>
To modify the Selection History settings to adjust the following settings as needed:
- Selection History Length: Sets the number of items to track in your history.
- Display Icons: Toggles the display of object icons in the history list.
- Register Hierarchy Selection: Enable or disable tracking of object selections from the Hierarchy window.
- Register Project Selection: Enable or disable tracking of asset selections from the Project window.

### 4.4 Clearing the History <a name="clearingTheHistory"/>
If you want to remove all items from the history list, click the Clear button at the bottom of the Selection History window. This will reset your selection history, starting fresh from the next selection.

### 4.5 Persisting Settings <a name="persistingSettings"/>
The Selection History package automatically saves your settings, so you don’t need to reconfigure it each time you open Unity. Settings are stored per project, meaning they will be preserved even if you close and reopen the editor.

## 5 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
