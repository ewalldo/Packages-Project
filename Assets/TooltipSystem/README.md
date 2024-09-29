# Tooltip System
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Create a "TooltipStyle"](#createATooltipStyle)
  - [Create a "Tooltip"](#createATooltip)
  - [Setup a "TooltipTrigger"](#setupATooltipTrigger)
  - [The "TooltipController"](#theTooltipController)
  - [The "TooltipPosition"](#theTooltipPosition)
- [Documentation](#documentation)
  - [Tooltip.GetTooltipStyle](#tooltipGetTooltipStyle)
  - [Tooltip.GetCanvasGroup](#tooltipGetCanvasGroup)
  - [Tooltip.SetupTooltip()](#tooltipSetupTooltip)
  - [Tooltip.SetTooltipValues()](#tooltipSetTooltipValues)
  - [Tooltip.ResetTooltip()](#tooltipResetTooltip)
  - [Tooltip.SetTooltipPosition()](#tooltipSetTooltipPosition)
  - [Tooltip.UpdateTooltipPosition()](#tooltipUpdateTooltipPosition)
  - [TooltipTrigger.SetupTrigger()](#tooltipTriggerSetupTrigger)
  - [TooltipTrigger.UpdateText()](#tooltipTriggerUpdateText)
  - [TooltipTrigger.UpdateSprite()](#tooltipTriggerUpdateSprite)
  - [TooltipTrigger.GetTriggerKeys()](#tooltipTriggerGetTriggerKeys)
  - [TooltipTrigger.GetTriggerTextKeys()](#tooltipTriggerGetTriggerTextKeys)
  - [TooltipTrigger.GetTriggerSpriteKeys()](#tooltipTriggerGetTriggerSpriteKeys)
  - [TooltipTrigger.ResetTooltip()](#tooltipTriggerResetTooltip)
  - [TooltipController.Show()](#tooltipControllerShow)
  - [TooltipController.Hide()](#tooltipControllerHide)
  - [TooltipController.UpdateTooltipValues()](#tooltipControllerUpdateTooltipValues)
  - [TooltipController.InitializeTooltipController()](#tooltipControllerInitializeTooltipController)
  - [TooltipController.AddTooltip()](#tooltipControllerAddTooltip)
  - [TooltipController.RemoveTooltip()](#tooltipControllerRemoveTooltip)
  - [TooltipController.EnableDisableTooltips()](#tooltipControllerEnableDisableTooltips)
  - [TooltipController.CloseTooltip()](#tooltipControllerCloseTooltip)
  - [TooltipController.CloseAllTooltips()](#tooltipControllerCloseAllTooltips)
  - [TooltipParams()](#tooltipParams)
  - [TooltipPosition](#tooltipPosition)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
In the world of interactive design and game development, tooltips play a pivotal role. They serve as a bridge between your application and the user, offering a way to communicate information effectively, reduce confusion, and promote user interaction. Whether you're developing a game, a business application, or any other interactive software, tooltips can make all the difference.  
The Tooltip System package is engineered to empower you with a wide array of features and customization options, ensuring that tooltips in your project are not just informative but also seamlessly integrated and visually appealing.  
The Tooltip System package comes equipped with a rich set of features, making it a valuable asset for developers and designers alike. It includes features like, UI element and 3D objects support for triggering, automatic pivot adjustment to ensure the tooltip is always on-screen, different positioning options, support for the old and new input system, support for dynamic data, fade options and so on.  
Whether you aim to provide informative hints, interactive guidance, or context-sensitive help, this package is a valuable asset for enhancing the overall user experience of your Unity projects.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

- **Package requirements: TMPro**

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Tooltip Styles: Create Tooltip Styles for easier control/setup of tooltips.
- UI elements and 3D objects support: Trigger tooltips from both Unity UI elements and 3D world objects.
- Automatic pivot adjustment: The package automatically handles pivot point positioning based on the screen position, guaranteeing tooltips to be always visible on screen.
- Positioning options: Choose from various options to set the tooltip's position relative to the trigger.
- Input system compatibility: Compatible with both the legacy Unity input system and the new input system.
- Dynamic data support: Populate tooltips with dynamic data for real-time updates.
- Fade options: Smooth transitions with customizable fade-in and fade-out animations.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Create a "Tooltip Style" <a name="createATooltipStyle"/>
- A TooltipStyle can be created by right-clicking the project window, choose "Create"->"Scriptable Objects"->"Tooltip System"->"Tooltip Style". The TooltipStyle holds information about the tooltip design, how many text/image components it will have, as well as the IDs for each of the components.

### 4.2 Create a "Tooltip" <a name="createATooltip"/>
- You can create a Tooltip by adding the "Tooltip.cs" script to your gameObject the will be displayed as a tooltip. The first field for the Tooltip is a TooltipStyle, which holds information about the fields that a tooltip should have. After selecting the TooltipStyle, Text and/or Image (depending on the style) fields should appear under it. The label on the left indicates the ID of each field, and the right side is the associated Text/Image component. Under those fields there is a "Main Text Layout Element" component, you can use that to define one layout element to control the minimum and maximum size for the tooltip based on one element. For a better understading on how it works, you can check some of the Tooltip prefabs already included in the package.

### 4.3 Setup a "TooltipTrigger" <a name="setupATooltipTrigger"/>
- To make a object trigger a tooltip, a "TooltipTrigger" must be attached to it. The trigger looks similar to the tooltip script. On the top, it has a field for a TooltipStyle, which holds the information for the tooltip contents. Under the TooltipStyle, on the left side, a label indicates the ID of the field and on the right side you can set the value for that ID. The value on the right side will be displayed on the tooltip everytime it is triggered. Under that there is an option to set where the tooltip should appear (for more details please check the 4.5 section called "TooltipPosition" or the documentation). Under the position, there is a field to set how long is the delay before a tooltip appears.

### 4.4 The "TooltipController" <a name="theTooltipController"/>
- In order to display tooltips, a TooltipController must exists in the scene. You can add the "TooltipController.cs" script to an object in the scene, or just use the TooltipCanvas prefab in the prefabs folder. The prefab is basically an Canvas gameObject with SortOrder set to its maximum value to assure that the tooltips shows above all other UI elements. The TooltipController has a few fields, the first one is a list containing the tooltips prefabs that the program is able to display (you should add your tooltips here). The second one is a toggle that allows tooltips to be turned on/off, following that there is a section to control the fade options for the tooltips. In here you can set if the tooltips should have fade-in/out behaviour, as well as how the type of fade.

### 4.5 The "TooltipPosition" <a name="theTooltipPosition"/>
On each trigger, you can set where the tooltip will be displayed. Currently, the tooltip system supports the following options.  
- At Mouse Cursor: The tooltip will be displayed at the current mouse position and will stays there during its duration.
- Follow Mouse Cursor: The tooltip will be displayed at the current mouse position and will follow it around during its duration.
- At Transform: The tooltip will be displayed at a specific Transform position and will follow the Transform around during its duration.
- At Vector3: The tooltip will be displayed at a specific Vector3 and will stays there during its duration.

## 5 - Documentation <a name="documentation"/>
### 5.1 Tooltip.GetTooltipStyle <a name="tooltipGetTooltipStyle"/>
Get the tooltip style associated with the tooltip
#### Declaration
```csharp
public TooltipStyle GetTooltipStyle;
```
#### Returns
| Type | Description |
| :--- | :--- |
| TooltipStyle | The tooltip style associated with the tooltip |


### 5.2 Tooltip.GetCanvasGroup <a name="tooltipGetCanvasGroup"/>
Get the CanvasGroup associated with the tooltip
#### Declaration
```csharp
public CanvasGroup GetCanvasGroup;
```
#### Returns
| Type | Description |
| :--- | :--- |
| CanvasGroup | The CanvasGroup of the tooltip |


### 5.3 Tooltip.SetupTooltip() <a name="tooltipSetupTooltip"/>
Setup the tooltip dictionaries and get references to the tooltip rectTransform and CanvasGroup
#### Declaration
```csharp
public void SetupTooltip();
```


### 5.4 Tooltip.SetTooltipValues() <a name="tooltipSetTooltipValues"/>
Set the values for the tooltip
#### Declaration
```csharp
public void SetTooltipValues(TooltipParams tooltipParams);
```
#### Parameters
| Type | Description |
| :--- | :--- |
| TooltipParams | The TooltipParams containing this tooltip information |


### 5.5 Tooltip.ResetTooltip() <a name="tooltipResetTooltip"/>
Reset the tooltip
#### Declaration
```csharp
public void ResetTooltip();
```


### 5.6 Tooltip.SetTooltipPosition() <a name="tooltipSetTooltipPosition"/>
Set the tooltip initial position
#### Declaration
```csharp
public void SetTooltipPosition();
```


### 5.7 Tooltip.UpdateTooltipPosition() <a name="tooltipUpdateTooltipPosition"/>
Update the tooltip position based on its TooltiPosition associated with it
#### Declaration
```csharp
private void UpdateTooltipPosition();
```


### 5.8 TooltipTrigger.SetupTrigger() <a name="tooltipTriggerSetupTrigger"/>
Setup the trigger dictionaries
#### Declaration
```csharp
private void SetupTrigger();
```


### 5.9 TooltipTrigger.UpdateText() <a name="tooltipTriggerUpdateText"/>
Update one of the texts for the trigger
#### Declaration
```csharp
public void UpdateText(string textID, string newText);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | textID | The text ID |
| string | newText | The value of the new text |


### 5.10 TooltipTrigger.UpdateSprite() <a name="tooltipTriggerUpdateSprite"/>
Update one of the sprites for the trigger
#### Declaration
```csharp
public void UpdateSprite(string spriteID, Sprite newSprite);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | spriteID | The sprite ID |
| Sprite | newSprite | The value of the new sprite |


### 5.11 TooltipTrigger.GetTriggerKeys() <a name="tooltipTriggerGetTriggerKeys"/>
Get all the keys associated with the trigger
#### Declaration
```csharp
public IEnumerator<string> GetTriggerKeys();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerator<string> | The trigger's keys |


### 5.12 TooltipTrigger.GetTriggerTextKeys() <a name="tooltipTriggerGetTriggerTextKeys"/>
Get all the text keys associated with the trigger
#### Declaration
```csharp
public IEnumerator<string> GetTriggerTextKeys();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerator<string> | The trigger's text keys |


### 5.13 TooltipTrigger.GetTriggerSpriteKeys() <a name="tooltipTriggerGetTriggerSpriteKeys"/>
Get all the sprite keys associated with the trigger
#### Declaration
```csharp
public IEnumerator<string> GetTriggerSpriteKeys();
```
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerator<string> | The trigger's sprite keys |


### 5.14 TooltipTrigger.ResetTooltip() <a name="tooltipTriggerResetTooltip"/>
Reset the trigger
#### Declaration
```csharp
public void ResetTooltip();
```


### 5.15 TooltipController.Show() <a name="tooltipControllerShow"/>
Show a tooltip
#### Declaration
```csharp
public void Show(TooltipStyle style, TooltipParams tooltipParams);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| TooltipStyle | style | The style of the tooltip to show |
| TooltipParams | tooltipParams | The parameters for the tooltip |


### 5.16 TooltipController.Hide() <a name="tooltipControllerHide"/>
Hide a tooltip
#### Declaration
```csharp
public void Hide(TooltipStyle style);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| TooltipStyle | style | The style of the tooltip to hide |


### 5.17 TooltipController.UpdateTooltipValues() <a name="tooltipControllerUpdateTooltipValues"/>
Update a tooltip values
#### Declaration
```csharp
public void UpdateTooltipValues(TooltipStyle style, TooltipParams tooltipParams);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| TooltipStyle | style | The style of the tooltip to update |
| TooltipParams | tooltipParams | The updated parameters for the tooltip |


### 5.18 TooltipController.InitializeTooltipController() <a name="tooltipControllerInitializeTooltipController"/>
Initialize the tooltip controller
#### Declaration
```csharp
public void InitializeTooltipController();
```


### 5.19 TooltipController.AddTooltip() <a name="tooltipControllerAddTooltip"/>
Add a tooltip to the controller
#### Declaration
```csharp
public void AddTooltip(Tooltip newTooltip);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Tooltip | newTooltip | The tooltip to be added |


### 5.20 TooltipController.RemoveTooltip() <a name="tooltipControllerRemoveTooltip"/>
Remove a tooltip from the controller
#### Declaration
```csharp
public void RemoveTooltip(Tooltip toDestroyTooltip);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Tooltip | toDestroyTooltip | The tooltip to be removed |


### 5.21 TooltipController.EnableDisableTooltips() <a name="tooltipControllerEnableDisableTooltips"/>
Set if the controller should display/hide the tooltips
#### Declaration
```csharp
public void EnableDisableTooltips(bool value);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| bool | value | True if tooltips should be displayed, false otherwise |


### 5.22 TooltipController.CloseTooltip() <a name="tooltipControllerCloseTooltip"/>
Close a specific tooltip
#### Declaration
```csharp
public void CloseTooltip(Tooltip tooltipToClose);
public void CloseTooltip(TooltipStyle style);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Tooltip | tooltipToClose | The tooltip to close |
| TooltipStyle | style | The tooltip style to close |


### 5.23 TooltipController.CloseAllTooltips() <a name="tooltipControllerCloseAllTooltips"/>
Close all tooltips
#### Declaration
```csharp
public void CloseAllTooltips();
```


### 5.24 TooltipParams() <a name="tooltipParams"/>
Instantiate a new instance of the TooltipParams class
#### Declaration
```csharp
public TooltipParams(Dictionary<string, string> tooltipTexts, Dictionary<string, Sprite> tooltipSprites, TooltipPosition tooltipPosition, Transform tooltipTransform, Vector3 tooltipVector);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Dictionary<string, string> | tooltipTexts | The tooltip texts |
| Dictionary<string, Sprite> | tooltipSprites | The tooltip sprites |
| TooltipPosition | tooltipPosition | The tooltip display position |
| Transform | tooltipTransform | Which transform the tooltip should be displayed at (if the TooltipPosition was set to transform) |
| Vector3 | tooltipVector | Which Vector3 the tooltip should be displayed at (if the TooltipPosition was set to vector3) |


### 5.25 TooltipPosition <a name="tooltipPosition"/>
Constrols where the tooltip should be displayed
#### Declaration
```csharp
public enum TooltipPosition;
```
#### Returns
| Type | Description |
| :--- | :--- |
| AtMouseCursor | The tooltip will be displayed at the current mouse position and stays there during its duration |
| FollowMouseCursor | The tooltip will be displayed at the current mouse position and will follow it around during its duration |
| AtTransform | The tooltip will be displayed at a specific Transform position and will follow the Transform around during its duration |
| AtVector3 | The tooltip will be displayed at a specific Vector3 and will stays there during its duration |

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
