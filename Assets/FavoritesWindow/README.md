# Favorites Window
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Adding FavoritesWindow to the Editor](#addingFavoritesWindowToTheEditor)
  - [Creating and Managing Favorite Panels](#creatingAndManagingFavoritePanels)
  - [Adding and Removing Favorites](#addingAndRemovingFavorites)
  - [Customizing Panel Display](#customizingPanelDisplay)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The FavoritesWindow package for Unity is an editor extension designed to streamline project organization by allowing users to create panels for their most frequently used assets. With this package, you can quickly access assets across your project and improve workflow efficiency.  
Favorites Window enables you to create multiple custom panels where you can save links to your favorite assets, all organized for quick access. Ideal for complex projects or large teams, this package enhances productivity by eliminating time spent searching for frequently used assets.  
This package has been tested with Unity version 2022.1 and is expected to work with both older and future versions.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Customizable Panels: Create and manage multiple favorite panels to suit your organizational needs.
- Quick Access to Favorites: Save time by storing links to frequently used assets or scene objects.
- Display Options: Toggle between displaying full asset paths, file icons, or file names only for a cleaner interface.
- Error Handling: Detects missing or deleted assets and automatically cleans up favorites.
- Data Persistence: Automatically saves and loads favorite panels across sessions.
- Easy Integration: Simple setup within the Unity Editor; no scripting knowledge required.
- Code can be easily extended: The code itself is organized in a way that is easy to understand, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Adding FavoritesWindow to the Editor <a name="addingFavoritesWindowToTheEditor"/>
To open the FavoritesWindow, go to the top menu bar, click on Window -> General, then select Favorites. This will open a new tab that you can dock anywhere in the Unity Editor.

### 4.2 Creating and Managing Favorite Panels <a name="creatingAndManagingFavoritePanels"/>
In the FavoritesWindow tab, you can create new panels for organizing favorites:
- Use the dropdown menu to select a panel.
- Click Create New Panel to add a new panel.
- To rename or delete the current panel, use the Rename Panel and Delete Panel buttons respectively.

### 4.3 Adding and Removing Favorites <a name="addingAndRemovingFavorites"/>
- To add an asset to your favorites: Drag the asset directly into the FavoritesWindow's drag and drop area. The dragged object will appear within the selected panel, allowing for quick and easy access. Depending on the size of your favorite window, it may be needed to scroll down to find the drag and drop area.
- To remove an item: Click on the "X" button to the right of the favorite object to remove it from the current panel.
- To remove all items: Click the "Clear all favorites" button at the bottom of the window to remove all favorites from the current panel.

### 4.4 Customizing Panel Display <a name="customizingPanelDisplay"/>
Customize how your favorites are displayed to match your workflow:
- Toggle Full Path Display: Click the "Display full path / file only" button to switch between displaying full asset paths and just the file names.
- Toggle Icons Display: Click the "Turn on/off icons" button to toggle the icons to the left of each favorite object.

## 5 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
