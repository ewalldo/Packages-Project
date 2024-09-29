# Indicator System
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Adding an Indicator](#addAnIndicator)
  - [Create a UI Indicator prefab](#createAUIIndicatorPrefab)
  - [Setting Up Indicators via Code](#settingUpIndicatorsViaCode)
  - [Fade options](#fadeOptions)
  - [Scale options](#scaleOptions)
  - [Scale options](#textOptions)
- [Documentation](#documentation)
  - [Indicator](#indicator)
    - [GetUIIndicator](#indicatorGetUIIndicator)
    - [OriginObject](#indicatorOriginObject)
    - [RenderCanvas](#indicatorRenderCanvas)
    - [RenderCanvasRect](#indicatorRenderCanvasRect)
    - [RenderCamera](#indicatorRenderCamera)
    - [HideOnScreenIndicator](#indicatorHideOnScreenIndicator)
    - [HideOffScreenIndicator](#indicatorHideOffScreenIndicator)
    - [SetupIndicator()](#indicatorSetupIndicator)
    - [SwitchCamera()](#indicatorSwitchCamera)
  - [UIIndicator](#uiindicator)
    - [SetScreenIndicatorsPositionAndRotation()](#uIIndicatorSetScreenIndicatorsPositionAndRotation)
    - [SetScreenIndicatorsPositionAndRotation()](#uIIndicatorSetScreenIndicatorsPosition)
    - [SetScreenIndicatorsRotation()](#uIIndicatorSetScreenIndicatorsRotation)
    - [DeactivateIndicators()](#uIIndicatorDeactivateIndicators)
    - [SetActiveOnScreenIndicator()](#uIIndicatorSetActiveOnScreenIndicator)
    - [SetOnScreenIndicatorSprite()](#uIIndicatorSetOnScreenIndicatorSprite)
    - [SetOnScreenIndicatorAlpha()](#uIIndicatorSetOnScreenIndicatorAlpha)
    - [SetOnScreenTransform()](#uIIndicatorSetOnScreenTransform)
    - [SetActiveOffScreenIndicator()](#uIIndicatorSetActiveOffScreenIndicator)
    - [SetOffScreenIndicatorSprite()](#uIIndicatorSetOffScreenIndicatorSprite)
    - [SetOffScreenIndicatorAlpha()](#uIIndicatorSetOffScreenIndicatorAlpha)
    - [SetOffScreenTransform()](#uIIndicatorSetOffScreenTransform)
  - [UIWaypointIndicator](#uIWaypointIndicator)
    - [DistanceText](#uIWaypointIndicatorDistanceText)
    - [IndicatorText](#uIWaypointIndicatorIndicatorText)
    - [OffScreenSpriteRotates](#uIWaypointIndicatorOffScreenSpriteRotates)
    - [SetTextsPosition()](#uIWaypointIndicatorSetTextsPosition)
    - [SetDistanceText()](#uIWaypointIndicatorSetDistanceText)
    - [SetIndicatorText()](#uIWaypointIndicatorSetIndicatorText)
    - [UpdateTextsState()](#uIWaypointIndicatorUpdateTextsState)
    - [ActivateTexts()](#uIWaypointIndicatorActivateTexts)
    - [ActivateDistanceText()](#uIWaypointIndicatorActivateDistanceText)
    - [ActivateIndicatorText()](#uIWaypointIndicatorActivateIndicatorText)
    - [DeactivateTexts()](#uIWaypointIndicatorDeactivateTexts)
    - [DeactivateDistanceText()](#uIWaypointIndicatorDeactivateDistanceText)
    - [DeactivateIndicatorText()](#uIWaypointIndicatorDeactivateIndicatorText)
    - [SetTextOffScreenOffset()](#uIWaypointIndicatorSetTextOffScreenOffset)
    - [SetDistanceTextOffScreenOffset()](#uIWaypointIndicatorSetDistanceTextOffScreenOffset)
    - [SetIndicatorTextOffScreenOffset()](#uIWaypointIndicatorSetIndicatorTextOffScreenOffset)
  - [UIRadialIndicator](#uIRadialIndicator)
    - [DiameterLength](#UIRadialIndicatorDiameterLength)
  - [IndicatorFader](#indicatorFader)
    - [FadeWithRange](#indicatorFaderFadeWithRange)
    - [MinAlphaDistance](#indicatorFaderMinAlphaDistance)
    - [MaxAlphaDistance](#indicatorFaderMaxAlphaDistance)
    - [AlphaAtMinDistance](#indicatorFaderAlphaAtMinDistance)
    - [AlphaAtMaxDistance](#indicatorFaderAlphaAtMaxDistance)
    - [CalculateAlpha()](#indicatorFaderCalculateAlpha)
  - [IndicatorScaler](#indicatorScaler)
    - [ScaleWithRange](#indicatorScalerScaleWithRange)
    - [MinScaleDistance](#indicatorScalerMinScaleDistance)
    - [MaxScaleDistance](#indicatorScalerMaxScaleDistance)
    - [ScaleAtMinDistance](#indicatorScalerScaleAtMinDistance)
    - [ScaleAtMaxDistance](#indicatorScalerScaleAtMaxDistance)
    - [CalculateScale()](#indicatorScalerCalculateScale)
  - [LengthUnitTypeExtensions](#lengthUnitTypeExtensions)
    - [LengthUnitSymbol()](#lengthUnitTypeExtensionsLengthUnitSymbol)
    - [ConvertFromMeters()](#lengthUnitTypeExtensionsConvertFromMeters)
    - [ConvertToMeters()](#lengthUnitTypeExtensionsConvertToMeters)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
Navigating complex game worlds can often be challenging for players, especially in open-world or large-scale environments where key objectives or points of interest may not be immediately visible. The Indicator System package for Unity is designed to enhance player experience by providing a robust, highly customizable solution for creating visual indicators that guide players toward specific in-game targets. Whether you are developing a first-person shooter, a role-playing game, or any other genre where orientation and navigation are crucial, this package offers the tools you need to keep players engaged and oriented.  
This package allows developers to implement dynamic indicators that visually point players towards objects or locations of interest. These indicators can either be displayed directly on the screen (on-screen indicators) or at the edges of the screen (off-screen indicators), depending on whether the target is visible within the camera’s field of view.  
Whether you need to point out a distant quest objective, warn players of an approaching enemy, or simply highlight an area of interest, the Indicator System is a powerful tool that can be adapted to fit a wide range of gameplay scenarios.  
This package is designed with flexibility and ease of use in mind, offering support for various types of indicators, extensive customization options, and compatibility with all major Unity Canvas render modes.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

- **Package requirements: TextMeshPro**

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Canvas Render Mode Support: The Indicator System seamlessly integrates with all three types of Unity Canvas render modes: Screen Space - Overlay, Screen Space - Camera, and World Space.
- Multiple Indicator Types: The package supports two (currently, more to come) primary types of indicators, Waypoint and Radial
- On-Screen and Off-Screen Indicator Support: Indicators can dynamically adapt to the target’s visibility, switching between on-screen indicator and off-screen indicator depending if the target is within the camera's view.
- Customizable Text and Display Options: Each indicator can include optional description and distance texts, providing additional context such as the name of the target or its distance from the player.
- Fade and Scale Based on Distance: To prevent UI clutter and enhance realism, indicators can be configured to fade out or scale down as the player gets closer to or farther from the target.
- Wide selection of pre-made sprites: A wide selection of different sprites are provided together with this package. All of them are free to use as it is, or you can modify it to fit your needs.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Adding an Indicator <a name="addAnIndicator"/>
To display an indicator for an object in your scene, the first step is to attach an Indicator script to the object you wish to track. The package currently offers two types of indicator scripts: WaypointIndicator and RadialIndicator.  
- WaypointIndicator: This script is used for indicators that directly point to an object’s position in the game world, typically displaying an icon or text that moves with the object.
- RadialIndicator: This script is used to creates indicators that appear around the center of the screen, pointing toward the object’s location.
After attaching the appropriate script to your object, you need to assign a UI Indicator prefab to the UIIndicator field within the script's inspector. This prefab serves as the visual representation of the indicator on the Canvas. During runtime, the system will automatically instantiate and position these UI Indicators based on the target object’s position and the selected indicator type.

### 4.2 Create a UI Indicator prefab <a name="createAUIIndicatorPrefab"/>
When designing a UI Indicator prefab, it’s crucial to structure it properly to ensure it functions as expected within the Indicator System. Here are the key steps to follow:  
- Parenting On/Off-Screen Elements: Both the on-screen and off-screen images that represent the indicator should be parented under an "indicator parent" GameObject. This setup is required for both Waypoint and Radial indicators, ensuring that the system can easily manage and switch between these states as the object moves in and out of the camera’s view.
- Text Components: If your indicator includes text elements, such as distance or description texts, these must also be parented correctly. Specifically, both the distance and description text components should be parented to a "texts parent" GameObject within the prefab. This allows the system to manage these texts effectively, ensuring they display and update correctly during gameplay.
For guidance, you can refer to the examples provided inside the sample scene folder. There’s also blanks UI Indicator prefabs available in the prefabs folder, which you can duplicate and customize by simply replacing the images and texts with your own designs. This setup makes it easy to create new indicators that seamlessly integrate with the system.

### 4.3 Setting Up Indicators via Code <a name="settingUpIndicatorsViaCode"/>
In many games, indicators may need to be instantiated dynamically during gameplay, such as when new objectives or enemies appear. In these cases, it’s essential to properly initialize the indicator after it’s instantiated to ensure it functions correctly.  
Once you’ve instantiated the indicator object, you need to call the SetupIndicator() method to configure it. This method typically requires you to pass in references to the Canvas, the Camera, and the Transform of the object the indicator is tracking. Below is an example code snippet that demonstrates how to instantiate and set up a WaypointIndicator at runtime:
```csharp
WaypointIndicator waypointIndicator = Instantiate(indicatorPrefab, parentTransform);
waypointIndicator.SetupIndicator(indicatorCanvas, mainCamera, mainCamera.transform);
```
In this example:
- indicatorPrefab is the prefab you created for the Indicator.
- parentTransform is the Transform under which the new indicator should be placed.
- indicatorCanvas is the Canvas on which the UI Indicator will be displayed.
- mainCamera is the Camera from which the indicator’s visibility and position are calculated.
For more detailed examples and additional parameters, please refer to the provided sample code or the function’s [documentation](#indicatorSetupIndicator).

### 4.4 Fade options <a name="fadeOptions"/>
The Indicator System includes built-in support for fading indicators based on their distance from the player. This feature is particularly useful for reducing UI clutter and improving immersion by making distant indicators less prominent.  
To enable fading, simply check the "On-Screen" and/or "Off-Screen" fade options in the Indicator’s inspector. Once enabled, you can customize the following parameters:  
- Minimum distance: This value determines the distance at which the indicator’s alpha (transparency) is at its lowest.
- Maximum distance: This value determines the distance at which the indicator’s alpha (transparency) is at its highest.
- Alpha at minimum distance: This parameter allows you to specify the exact alpha value when the distance to the target is at or below the minimum distance.
- Alpha at maximum distance: This parameter allows you to specify the exact alpha value when the distance to the target is at or above the maximum distance.
These settings give you fine control over how indicators appear as the player moves through the game world, helping to ensure that important indicators remain visible while less critical ones fade out.

### 4.5 Scale options <a name="scaleOptions"/>
Similar to fading, the Indicator System also supports scaling indicators based on distance. This feature allows indicators to grow or shrink depending on how close or far the target object is from the player, enhancing the sense of depth and proximity.  
To activate scaling, check the "On-Screen" and/or "Off-Screen" scale options in the Indicator’s inspector. Once activated, you can adjust the following parameters:  
- Minimum distance: The distance at which the indicator’s scale will be at its smallest.
- Maximum distance: The distance at which the indicator’s scale will be at its largest.
- Scale at minimum distance: This setting allows you to define the exact scale of the indicator when the target is at or lower than the minimum distance.
- Scale at maximum distance: This setting allows you to define the exact scale of the indicator when the target is at or above than the maximum distance.
By adjusting these settings, you can create a more dynamic and visually appealing indicator system that responds naturally to the player’s movement and the positions of tracked objects.

### 4.6 Text options <a name="textOptions"/>
For Waypoint indicators, you have the option to display text alongside the indicator, such as a description of the object or the distance to it. These text elements can be crucial for providing additional context or information to the player.  
To control the display of texts, use the checkboxes in the WaypointIndicator’s inspector. These options allow you to toggle the visibility of the description and distance texts based on your game’s needs.  
For examples, refer to the sample scene folder where you’ll find pre-configured indicators that include text elements. The sample scene also provides a practical demonstration of how text options can be used effectively.

## 5 - Documentation <a name="documentation"/>
### 5.1 Indicator <a name="indicator"/>
#### 5.1.1 Indicator.GetUIIndicator <a name="indicatorGetUIIndicator"/>
Gets the UI indicator associated with this indicator
#### Declaration
```csharp
public UIIndicator GetUIIndicator;
```
#### Returns
| Type | Description |
| :--- | :--- |
| UIIndicator | The UIIndicator associated with this Indicator |


#### 5.1.2 Indicator.OriginObject <a name="indicatorOriginObject"/>
Gets or sets the origin object used for distance calculations
#### Declaration
```csharp
public Transform OriginObject;
```
#### Returns
| Type | Description |
| :--- | :--- |
| Transform | The transform which this indicator will track its distance from |


#### 5.1.3 Indicator.RenderCanvas <a name="indicatorRenderCanvas"/>
Gets or sets the canvas used to render the indicator
#### Declaration
```csharp
public Canvas RenderCanvas;
```
#### Returns
| Type | Description |
| :--- | :--- |
| Canvas | The canvas which this indicator will use to render its UIIndicator |


#### 5.1.4 Indicator.RenderCanvasRect <a name="indicatorRenderCanvasRect"/>
Gets the RectTransform of the render canvas
#### Declaration
```csharp
public RectTransform RenderCanvasRect;
```
#### Returns
| Type | Description |
| :--- | :--- |
| RectTransform | The RectTransform of the canvas used to render the UIIndicator |


#### 5.1.5 Indicator.RenderCamera <a name="indicatorRenderCamera"/>
Gets or sets the camera used for rendering the indicator/check for on/off-screen
#### Declaration
```csharp
public Camera RenderCamera;
```
#### Returns
| Type | Description |
| :--- | :--- |
| Camera | The Camera used to check if the indicator is on/off-screen |


#### 5.1.6 Indicator.HideOnScreenIndicator <a name="indicatorHideOnScreenIndicator"/>
Gets or sets whether the on-screen indicator should be hidden
#### Declaration
```csharp
public bool HideOnScreenIndicator;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the on-screen indicator should not be displayed, false otherwise |


#### 5.1.7 Indicator.HideOffScreenIndicator <a name="indicatorHideOffScreenIndicator"/>
Gets or sets whether the off-screen indicator should be hidden
#### Declaration
```csharp
public bool HideOffScreenIndicator;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the off-screen indicator should not be displayed, false otherwise |


#### 5.1.8 Indicator.SetupIndicator() <a name="indicatorSetupIndicator"/>
Sets up the indicator with the specified canvas, camera, and origin object
#### Declaration
```csharp
public void SetupIndicator(Canvas canvas, Camera camera, Transform newOriginObject);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Canvas | canvas | The canvas used for rendering the indicator |
| Camera | camera | The camera used for rendering the indicator |
| Transform | newOriginObject | The origin object for distance calculations |


#### 5.1.9 Indicator.SwitchCamera() <a name="indicatorSwitchCamera"/>
Switches the camera used for rendering the indicator
#### Declaration
```csharp
public void SwitchCamera(Camera newCamera, Transform newOriginObject = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Camera | newCamera | The new camera used for rendering the indicator |
| Transform | newOriginObject | Optional. The new origin object for distance calculations |


### 5.2 UIIndicator <a name="uiindicator"/>
#### 5.2.1 UIIndicator.SetScreenIndicatorsPositionAndRotation() <a name="uIIndicatorSetScreenIndicatorsPositionAndRotation"/>
Sets the position and rotation of the screen indicators
#### Declaration
```csharp
public void SetScreenIndicatorsPositionAndRotation(Vector3 pos, Quaternion rot, bool isLocal);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | pos | The position of the indicators |
| Quaternion | rot | The rotation of the indicators |
| bool | isLocal | If true, sets local position and rotation; otherwise, sets world position and rotation |


#### 5.2.2 UIIndicator.SetScreenIndicatorsPosition() <a name="uIIndicatorSetScreenIndicatorsPosition"/>
Sets the position of the screen indicators
#### Declaration
```csharp
public void SetScreenIndicatorsPosition(Vector3 pos, bool isLocal);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | pos | The position of the indicators |
| bool | isLocal | If true, sets local position; otherwise, sets world position |


#### 5.2.3 UIIndicator.SetScreenIndicatorsRotation() <a name="uIIndicatorSetScreenIndicatorsRotation"/>
Sets the rotation of the screen indicators
#### Declaration
```csharp
public void SetScreenIndicatorsRotation(Quaternion rot, bool isLocal);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Quaternion | rot | The rotation of the indicators |
| bool | isLocal | If true, sets local rotation; otherwise, sets world rotation |


#### 5.2.4 UIIndicator.DeactivateIndicators() <a name="uIIndicatorDeactivateIndicators"/>
Deactivates both on-screen and off-screen indicators
#### Declaration
```csharp
public void DeactivateIndicators();
```


#### 5.2.5 UIIndicator.SetActiveOnScreenIndicator() <a name="uIIndicatorSetActiveOnScreenIndicator"/>
Activates the on-screen indicator and deactivates the off-screen indicator
#### Declaration
```csharp
public void SetActiveOnScreenIndicator();
```


#### 5.2.6 UIIndicator.SetOnScreenIndicatorSprite() <a name="uIIndicatorSetOnScreenIndicatorSprite"/>
Sets the sprite and optional tint color for the on-screen indicator
#### Declaration
```csharp
public void SetOnScreenIndicatorSprite(Sprite onScreenSprite, Color? tintColor = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Sprite | onScreenSprite | The sprite to set for the on-screen indicator |
| Color? | tintColor | The optional tint color to apply to the sprite |


#### 5.2.7 UIIndicator.SetOnScreenIndicatorAlpha() <a name="uIIndicatorSetOnScreenIndicatorAlpha"/>
Sets the alpha transparency of the on-screen indicator
#### Declaration
```csharp
public void SetOnScreenIndicatorAlpha(float alpha);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | alpha | The alpha value to set |


#### 5.2.8 UIIndicator.SetOnScreenTransform() <a name="uIIndicatorSetOnScreenTransform"/>
Configures the transform properties of the on-screen indicator
#### Declaration
```csharp
public void SetOnScreenTransform(Vector2Int? indicatorSize = null, Vector3? indicatorOffset = null, float? indicatorRotation = null, float? indicatorScale = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector2Int? | indicatorSize | Optional size of the indicator |
| Vector3? | indicatorOffset | Optional position offset of the indicator |
| float? | indicatorRotation | Optional rotation of the indicator |
| float? | indicatorScale | Optional scale of the indicator |


#### 5.2.9 UIIndicator.SetActiveOffScreenIndicator() <a name="uIIndicatorSetActiveOffScreenIndicator"/>
Activates the off-screen indicator and deactivates the on-screen indicator
#### Declaration
```csharp
public void SetActiveOffScreenIndicator();
```


#### 5.2.10 UIIndicator.SetOffScreenIndicatorSprite() <a name="uIIndicatorSetOffScreenIndicatorSprite"/>
Sets the sprite and optional tint color for the off-screen indicator
#### Declaration
```csharp
public void SetOffScreenIndicatorSprite(Sprite offScreenSprite, Color? tintColor = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Sprite | offScreenSprite | The sprite to set for the off-screen indicator |
| Color? | tintColor | The optional tint color to apply to the sprite |


#### 5.2.11 UIIndicator.SetOffScreenIndicatorAlpha() <a name="uIIndicatorSetOffScreenIndicatorAlpha"/>
Sets the alpha transparency of the off-screen indicator
#### Declaration
```csharp
public void SetOffScreenIndicatorAlpha(float alpha);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | alpha | The alpha value to set |


#### 5.2.12 UIIndicator.SetOffScreenTransform() <a name="uIIndicatorSetOffScreenTransform"/>
Configures the transform properties of the off-screen indicator
#### Declaration
```csharp
public void SetOffScreenTransform(Vector2Int? indicatorSize = null, Vector3? indicatorOffset = null, float? indicatorRotation = null, float? indicatorScale = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector2Int? | indicatorSize | Optional size of the indicator |
| Vector3? | indicatorOffset | Optional position offset of the indicator |
| float? | indicatorRotation | Optional rotation of the indicator |
| float? | indicatorScale | Optional scale of the indicator |


### 5.3 UIWaypointIndicator <a name="uIWaypointIndicator"/>
#### 5.3.1 UIWaypointIndicator.DistanceText <a name="uIWaypointIndicatorDistanceText"/>
Gets the distance text element
#### Declaration
```csharp
public TextMeshProUGUI DistanceText;
```
#### Returns
| Type | Description |
| :--- | :--- |
| TextMeshProUGUI | The text element used to represent the distance |


#### 5.3.2 UIWaypointIndicator.IndicatorText <a name="uIWaypointIndicatorIndicatorText"/>
Gets the indicator text element
#### Declaration
```csharp
public TextMeshProUGUI IndicatorText;
```
#### Returns
| Type | Description |
| :--- | :--- |
| TextMeshProUGUI | The text element used to represent the indicator description |


#### 5.3.3 UIWaypointIndicator.OffScreenSpriteRotates <a name="uIWaypointIndicatorOffScreenSpriteRotates"/>
Gets or sets a value indicating whether the off-screen sprite rotates.
#### Declaration
```csharp
public bool OffScreenSpriteRotates;
```
#### Returns
| Type | Description |
| :--- | :--- |
| bool | True if the off-screen indicator should rotate to match the indicator direction, false otherwise  |


#### 5.3.4 UIWaypointIndicator.SetTextsPosition() <a name="uIWaypointIndicatorSetTextsPosition"/>
Sets the position of the text elements, adjusting for off-screen locations
#### Declaration
```csharp
public void SetTextsPosition(Vector3 pos, bool isLocal, OffScreenLocations offScreenLocations);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Vector3 | pos | The position to set the texts to |
| bool | isLocal | If true, sets local position; otherwise, sets world position |
| OffScreenLocations | offScreenLocations | The text currently off-screen locations |


#### 5.3.5 UIWaypointIndicator.SetDistanceText() <a name="uIWaypointIndicatorSetDistanceText"/>
Sets the text for the distance text element
#### Declaration
```csharp
public void SetDistanceText(string distance);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | distance | The distance value to display |


#### 5.3.6 UIWaypointIndicator.SetIndicatorText() <a name="uIWaypointIndicatorSetIndicatorText"/>
Sets the text for the indicator text element
#### Declaration
```csharp
public void SetIndicatorText(string text);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | text | The indicator text to display |


#### 5.3.7 UIWaypointIndicator.UpdateTextsState() <a name="uIWaypointIndicatorUpdateTextsState"/>
Updates the state of the text elements, activating or deactivating them based on the specified parameters
#### Declaration
```csharp
public void UpdateTextsState(bool displayDistanceText, bool displayIndicatorText);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| bool | displayDistanceText | If true, displays the distance text; otherwise, hides it |
| bool | displayIndicatorText | If true, displays the indicator text; otherwise, hides it |


#### 5.3.8 UIWaypointIndicator.ActivateTexts() <a name="uIWaypointIndicatorActivateTexts"/>
Activates the specified text elements
#### Declaration
```csharp
public void ActivateTexts(bool displayDistanceText, bool displayIndicatorText);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| bool | displayDistanceText | If true, activates the distance text |
| bool | displayIndicatorText | If true, activates the indicator text |


#### 5.3.9 UIWaypointIndicator.ActivateDistanceText() <a name="uIWaypointIndicatorActivateDistanceText"/>
Activates the distance text element
#### Declaration
```csharp
public void ActivateDistanceText();
```


#### 5.3.10 UIWaypointIndicator.ActivateIndicatorText() <a name="uIWaypointIndicatorActivateIndicatorText"/>
Activates the indicator text element
#### Declaration
```csharp
public void ActivateIndicatorText();
```


#### 5.3.11 UIWaypointIndicator.DeactivateTexts() <a name="uIWaypointIndicatorDeactivateTexts"/>
Deactivates all text elements
#### Declaration
```csharp
public void DeactivateTexts();
```


#### 5.3.12 UIWaypointIndicator.DeactivateDistanceText() <a name="uIWaypointIndicatorDeactivateDistanceText"/>
Deactivates the distance text element
#### Declaration
```csharp
public void DeactivateDistanceText();
```


#### 5.3.13 UIWaypointIndicator.DeactivateIndicatorText() <a name="uIWaypointIndicatorDeactivateIndicatorText"/>
Deactivates the indicator text element
#### Declaration
```csharp
public void DeactivateIndicatorText();
```


#### 5.3.14 UIWaypointIndicator.SetTextOffScreenOffset() <a name="uIWaypointIndicatorSetTextOffScreenOffset"/>
Sets the off-screen offset for both the distance text and the indicator text
#### Declaration
```csharp
public void SetTextOffScreenOffset(TextOffset newDistanceTextOffset, TextOffset newIndicatorTextOffset);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| TextOffset | newDistanceTextOffset | The new offset for the distance text |
| TextOffset | newIndicatorTextOffset | The new offset for the indicator text |


#### 5.3.15 UIWaypointIndicator.SetDistanceTextOffScreenOffset() <a name="uIWaypointIndicatorSetDistanceTextOffScreenOffset"/>
Sets the off-screen offset for the distance text element
#### Declaration
```csharp
public void SetDistanceTextOffScreenOffset(TextOffset newTextOffset);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| TextOffset | newTextOffset | The new offset to apply to the distance text |


#### 5.3.16 UIWaypointIndicator.SetIndicatorTextOffScreenOffset() <a name="uIWaypointIndicatorSetIndicatorTextOffScreenOffset"/>
Sets the off-screen offset for the indicator text element
#### Declaration
```csharp
public void SetIndicatorTextOffScreenOffset(TextOffset newTextOffset);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| TextOffset | newTextOffset | The new offset to apply to the indicator text |


### 5.4 UIRadialIndicator <a name="uIRadialIndicator"/>
### 5.4.1 UIRadialIndicator.DiameterLength <a name="UIRadialIndicatorDiameterLength"/>
Gets the diameter of the radial indicator
#### Declaration
```csharp
public float DiameterLength;
```


### 5.5 IndicatorFader <a name="indicatorFader"/>
#### 5.5.1 IndicatorFader.FadeWithRange <a name="indicatorFaderFadeWithRange"/>
Whether the indicator fades with distance
#### Declaration
```csharp
public bool FadeWithRange;
```


#### 5.5.2 IndicatorFader.MinAlphaDistance <a name="indicatorFaderMinAlphaDistance"/>
Gets or sets the minimum distance at which the indicator alpha will be at the lowest value
#### Declaration
```csharp
public float MinAlphaDistance;
```


#### 5.5.3 IndicatorFader.MaxAlphaDistance <a name="indicatorFaderMaxAlphaDistance"/>
Gets or sets the maximum distance at which the indicator alpha will be at the highest value
#### Declaration
```csharp
public float MaxAlphaDistance;
```


#### 5.5.4 IndicatorFader.AlphaAtMinDistance <a name="indicatorFaderAlphaAtMinDistance"/>
Gets or sets the alpha value at the minimum distance or lower
#### Declaration
```csharp
public float AlphaAtMinDistance;
```


#### 5.5.5 IndicatorFader.AlphaAtMaxDistance <a name="indicatorFaderAlphaAtMaxDistance"/>
Gets or sets the alpha value at the maximum distance or higher
#### Declaration
```csharp
public float AlphaAtMaxDistance;
```


#### 5.5.6 IndicatorFader.CalculateAlpha() <a name="indicatorFaderCalculateAlpha"/>
Calculates the alpha value based on the given distance
#### Declaration
```csharp
public float CalculateAlpha(float distance);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | distance | The distance to the target |


### 5.6 IndicatorScaler <a name="indicatorScaler"/>
#### 5.6.1 IndicatorScaler.ScaleWithRange <a name="indicatorScalerScaleWithRange"/>
Whether the indicator scales with distance
#### Declaration
```csharp
public bool ScaleWithRange;
```


#### 5.6.2 IndicatorScaler.MinScaleDistance <a name="indicatorScalerMinScaleDistance"/>
Gets or sets the minimum distance at which the indicator scale will be at the lowest value
#### Declaration
```csharp
public float MinScaleDistance;
```


#### 5.6.3 IndicatorScaler.MaxScaleDistance <a name="indicatorScalerMaxScaleDistance"/>
Gets or sets the maximum distance at which the indicator scale will be at the highest value
#### Declaration
```csharp
public float MaxScaleDistance;
```


#### 5.6.4 IndicatorScaler.ScaleAtMinDistance <a name="indicatorScalerScaleAtMinDistance"/>
Gets or sets the scale value at the minimum distance or lower
#### Declaration
```csharp
public float ScaleAtMinDistance;
```


#### 5.6.5 IndicatorScaler.ScaleAtMaxDistance <a name="indicatorScalerScaleAtMaxDistance"/>
Gets or sets the scale value at the maximum distance or higher
#### Declaration
```csharp
public float ScaleAtMaxDistance;
```


#### 5.6.6 IndicatorScaler.CalculateScale() <a name="indicatorScalerCalculateScale"/>
Calculates the scale value based on the given distance
#### Declaration
```csharp
public float CalculateScale(float distance);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | distance | The distance to the target |


### 5.7 LengthUnitTypeExtensions <a name="lengthUnitTypeExtensions"/>
#### 5.7.1 LengthUnitTypeExtensions.LengthUnitSymbol() <a name="lengthUnitTypeExtensionsLengthUnitSymbol"/>
Get the string representation of the LengthUnitType
#### Declaration
```csharp
public static string LengthUnitSymbol();
```


#### 5.7.2 LengthUnitTypeExtensions.ConvertFromMeters() <a name="lengthUnitTypeExtensionsConvertFromMeters"/>
Convert the length from meters to a different LengthUnitType
#### Declaration
```csharp
public static float ConvertFromMeters(float length);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | length | The length to convert to meters |
#### Returns
| Type | Description |
| :--- | :--- |
| float | The converted length |


#### 5.7.3 LengthUnitTypeExtensions.ConvertToMeters() <a name="lengthUnitTypeExtensionsConvertToMeters"/>
Convert the length from a different LengthUnitType to meters
#### Declaration
```csharp
public static float ConvertToMeters(float length);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | length | The length to convert |
#### Returns
| Type | Description |
| :--- | :--- |
| float | The length in meters |

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
