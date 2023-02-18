# Camera System
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Creating camera settings](#creatingCameraSettings)
  - [Setting up a camera](#settingUpACamera)
  - [Camera controls](#cameraControls)
  - [Saving/loading camera settings](#savingCameraSettings)
- [Documentation](#documentation)
  - [CameraController.SetCameraSettings()](#cameraControllerSetCameraSettings)
  - [CameraSettings.OverrideCameraInitialOffset](#cameraSettingsOverrideCameraInitialOffset)
  - [CameraSettings.CinemachineVirtualCameraInitialOffset](#cameraSettingsCinemachineVirtualCameraInitialOffset)
  - [CameraSettings.MoveCameraSpeed](#cameraSettingsMoveCameraSpeed)
  - [CameraSettings.UseEdgeScrolling](#cameraSettingsUseEdgeScrolling)
  - [CameraSettings.EdgeScrollSizeX](#cameraSettingsEdgeScrollSizeX)
  - [CameraSettings.EdgeScrollSizeY](#cameraSettingsEdgeScrollSizeY)
  - [CameraSettings.UseDragPan](#cameraSettingsUseDragPan)
  - [CameraSettings.DragPanSpeedMultiplier](#cameraSettingsDragPanSpeedMultiplier)
  - [CameraSettings.RotateCameraSpeed](#cameraSettingsRotateCameraSpeed)
  - [CameraSettings.UseDragRotation](#cameraSettingsUseDragRotation)
  - [CameraSettings.DragRotationSpeedMultiplier](#cameraSettingsDragRotationSpeedMultiplier)
  - [CameraSettings.UseZoom](#cameraSettingsUseZoom)
  - [CameraSettings.UseZoom](#cameraSettingsZoomCameraSpeed)
  - [CameraSettings.ZoomCameraAmount](#cameraSettingsZoomCameraAmount)
  - [CameraSettings.FollowOffsetMin](#cameraSettingsFollowOffsetMin)
  - [CameraSettings.FollowOffsetMax](#cameraSettingsFollowOffsetMax)
  - [CameraSettings.ConvertSettingsToJSONString()](#cameraSettingsConvertSettingsToJSONString)
  - [CameraSettings.LoadSettingsFromJson()](#cameraSettingsLoadSettingsFromJson)
  - [CameraSettings.SaveSettingsToPlayerPrefs()](#cameraSettingsSaveSettingsToPlayerPrefs)
  - [CameraSettings.LoadSettingsFromPlayerPrefs()](#cameraSettingsLoadSettingsFromPlayerPrefs)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The Camera System Package is a collection of scripts that allow for easy and flexible camera control in Unity. The package uses Cinemachine and the new Input System approach to create smooth camera movement and customizable inputs. With the Camera System Package, you can quickly create a camera that works really well for games that requires a free camera movement.  
The camera settings are created using scriptable objects, allowing the use to easily switch between presets both in the editor or during runtime. Also, the camera settings values can be save/load using playerPrefs or Json, so any changes in the camera can be restored when relaunching the game.
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.  

- **Package requirements: Cinemachine and InputSystem**

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Easier to create camera presets: By using ScriptableObjects, different camera presets can be created allowing the camera settings to be changed easily in the editor or during runtime.
- New input system: Thanks to the new input system, it is easier to remap/change the camera controls.
- Cinemachine: Cinemachine provides more control/customization options for controling cameras in Unity, allowing more customization for the camera parameters.
- Save/load settings: Camera settings can be saved/loaded by using playerPrefs or Json, giving more option on how to store the setting values.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Creating camera settings <a name="creatingCameraSettings"/>
- Camera settings can be created by right-clicking the project window, choose "Create"->"Scriptable Objects"->"Camera System"-"Camera Settings".

### 4.2 Setting up a camera <a name="settingUpACamera"/>
- Add a CinemachineVirtualCamera to the scene.
- Create am empty game object and attach the "CameraController" script to it.
- Drag the CinemachineVirtualCamera to the "Cinemachine virtual camera" slot in the CameraController script.
- In the CinemachineVirtualCamera drag the previously created empty to the "Follow" and "Look At" slots.
- Edit other CinemachineVirtualCamera settings as you see fit.

### 4.3 Camera controls <a name="cameraControls"/>
By default camera controls are:
- Movement: WASD keys, arrow keys or controller left stick (or by right-mouse click if drag pan is active).
- Rotation: "Q" and "E" keys (or by middle-mouse click if drag rotation is active).
- Zoom: By middle-mouse scroll if the useZoom option is active.  
To overwrite/change the default camera controls scheme, you can edit the CameraSystemInputActions.inputactions file in the Scripts folder.

### 4.4 Saving/loading camera settings <a name="savingCameraSettings"/>
Camera settings contains methods to save the settings to playerPrefs or exporte them as Json string. Similarly, settings can be loaded by those two methods too. Check more details about those methods in the documentation section.
```csharp
public string ConvertSettingsToJSONString();
public void LoadSettingsFromJson(string json);
public void SaveSettingsToPlayerPrefs();
public void LoadSettingsFromPlayerPrefs();
```

## 5 - Documentation <a name="documentation"/>
### 5.1 CameraController.SetCameraSettings() <a name="cameraControllerSetCameraSettings"/>
Set a new camera settings to this controller
#### Declaration
```csharp
public void SetCameraSettings(CameraSettings cameraSettings)
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| CameraSettings | cameraSettings | The new camera settings |


### 5.2 CameraSettings.OverrideCameraInitialOffset <a name="cameraSettingsOverrideCameraInitialOffset"/>
Should override the initial offset of the cinemachineCamera at the awake?
#### Declaration
```csharp
public bool OverrideCameraInitialOffset;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True to override the cinemachineValue, false otherwise |


### 5.3 CameraSettings.CinemachineVirtualCameraInitialOffset <a name="cameraSettingsCinemachineVirtualCameraInitialOffset"/>
Get the initial offset for the cinemachine virtual camera
#### Declaration
```csharp
public Vector3 CinemachineVirtualCameraInitialOffset;
```
#### Returns
| Type | Description |
| :--- | :--- |
| Vector3 | The initial offset for the cinemachine virtual camera |


### 5.4 CameraSettings.MoveCameraSpeed <a name="cameraSettingsMoveCameraSpeed"/>
Get the camera movement speed
#### Declaration
```csharp
public float MoveCameraSpeed;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The camera movement speed |


### 5.5 CameraSettings.UseEdgeScrolling <a name="cameraSettingsUseEdgeScrolling"/>
Should edge scrolling be active or not
#### Declaration
```csharp
public bool UseEdgeScrolling;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True to activate the edge scrolling, false otherwise |


### 5.6 CameraSettings.EdgeScrollSizeX <a name="cameraSettingsEdgeScrollSizeX"/>
Percentage of the screen width where the edge scroll will be active (0.1 means that will be active on the 10% of the screen)
#### Declaration
```csharp
public float EdgeScrollSizeX;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | Percentage of the screen width (0~0.49) |


### 5.7 CameraSettings.EdgeScrollSizeY <a name="cameraSettingsEdgeScrollSizeY"/>
Percentage of the screen height where the edge scroll will be active (0.1 means that will be active on the 10% of the screen)
#### Declaration
```csharp
public float EdgeScrollSizeY;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | Percentage of the screen height (0~0.49) |


### 5.8 CameraSettings.UseDragPan <a name="cameraSettingsUseDragPan"/>
Should drag pan be active or not, if active camera can be moved with right-mouse click
#### Declaration
```csharp
public bool UseDragPan;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True to activate drag pan, false otherwise |


### 5.9 CameraSettings.DragPanSpeedMultiplier <a name="cameraSettingsDragPanSpeedMultiplier"/>
Get the multiplier speed when using drag pan
#### Declaration
```csharp
public float DragPanSpeedMultiplier;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The multiplier speed when using drag pan |


### 5.10 CameraSettings.RotateCameraSpeed <a name="cameraSettingsRotateCameraSpeed"/>
Get the camera rotation speed
#### Declaration
```csharp
public float RotateCameraSpeed;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The camera rotation speed |


### 5.11 CameraSettings.UseDragRotation <a name="cameraSettingsUseDragRotation"/>
Should drag rotation be active or not, if active camera can be rotated with middle-mouse click
#### Declaration
```csharp
public bool UseDragRotation;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True to activate drag rotation, false otherwise |


### 5.12 CameraSettings.DragRotationSpeedMultiplier <a name="cameraSettingsDragRotationSpeedMultiplier"/>
Get the multiplier speed when using drag rotation
#### Declaration
```csharp
public float DragRotationSpeedMultiplier;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The multiplier speed when using drag rotation |


### 5.13 CameraSettings.UseZoom <a name="cameraSettingsUseZoom"/>
Should camera zoom be active or not, if active camera can be zoomed with middle-mouse scroll
#### Declaration
```csharp
public bool UseZoom;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True to activate zoom, false otherwise |


### 5.14 CameraSettings.ZoomCameraSpeed <a name="cameraSettingsZoomCameraSpeed"/>
Get the camera zoom speed
#### Declaration
```csharp
public float ZoomCameraSpeed;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The camera zoom speed |


### 5.15 CameraSettings.ZoomCameraAmount <a name="cameraSettingsZoomCameraAmount"/>
Get the camera step size when zooming
#### Declaration
```csharp
public float ZoomCameraAmount;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The camera step size when zooming |


### 5.16 CameraSettings.FollowOffsetMin <a name="cameraSettingsFollowOffsetMin"/>
Get the minimum amount of offset the camera should keep when zooming
#### Declaration
```csharp
public float FollowOffsetMin;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The minimum amount of offset the camera should keep when zooming |


### 5.17 CameraSettings.FollowOffsetMax <a name="cameraSettingsFollowOffsetMax"/>
Get the maximum amount of offset the camera should keep when zooming
#### Declaration
```csharp
public float FollowOffsetMax;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The maximum amount of offset the camera should keep when zooming |


### 5.18 CameraSettings.ConvertSettingsToJSONString() <a name="cameraSettingsConvertSettingsToJSONString"/>
Convert this CameraSettings to a json string
#### Declaration
```csharp
public string ConvertSettingsToJSONString();
```
#### Returns
| Type | Description |
| :--- | :--- |
| string | The string containing the settings in a json format |


### 5.19 CameraSettings.LoadSettingsFromJson() <a name="cameraSettingsLoadSettingsFromJson"/>
Load camera settings based on a json string
#### Declaration
```csharp
public void LoadSettingsFromJson(string json);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | json | The string containing the camera settings |


### 5.20 CameraSettings.SaveSettingsToPlayerPrefs() <a name="cameraSettingsSaveSettingsToPlayerPrefs"/>
Save this camera settings to playerPrefs
#### Declaration
```csharp
public void SaveSettingsToPlayerPrefs();
```


### 5.21 CameraSettings.LoadSettingsFromPlayerPrefs() <a name="cameraSettingsLoadSettingsFromPlayerPrefs"/>
Load the camera settings from playerPrefs
#### Declaration
```csharp
public void LoadSettingsFromPlayerPrefs();
```

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
