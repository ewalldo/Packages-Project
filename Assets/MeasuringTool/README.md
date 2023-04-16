# Measurement Tool
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Add the measurement tool to a scene](#addTheMeasurementToolToAScene)
  - [Setting up ruler size and measurement unit](#settingUpRulerSizeAndMeasurementUnit)
  - [Displaying axis measurements](#displayingAxisMeasurements)
  - [Displaying distance and angles between objects](#displayingDistanceAndAnglesBetweenObjects)
  - [The measurement tool is not showing in the Scene View](#theMeasurementToolIsNotShowingInTheSceneView)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The Measurement Tool Package for Unity is a comprehensive set of tools designed to help developers and designers create accurate and precise game levels, applications, or visualizations. With this package, you can easily measure distances and angles in your Unity scenes, allowing you to ensure that your gameObjects are positioned correctly and that they fit together perfectly.  
The Measurement Tool Package is ideal for a wide range of projects and users, including architects, engineers, game developers, product designers, and anyone who needs to position things precisely. Whether you're creating a game level, designing a product prototype, or visualizing an architectural project, the Measurement Tool Package can help you save time and effort by providing accurate and reliable measurements directly within Unity.  
The package includes a range of measurement tools that are easy to use, allowing you to tailor your measurements to your specific needs. With its support of various measurement units and visualization options, the Measurement Tool Package is an essential tool for any developer or designer looking to create precise and accurate levels in Unity.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.  

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Useful for level design, making it easier to position objects in a scene based on distance/angle.
- Useful for XR applications, making it easier to position objects in real world position/coordinates.
- Support different measurement units: Allowing adjustments/check based on different scales, going from millimeters up to kilometers (more to be added in the future)
  - Meter
  - Centimeter
  - Millimeter
  - Kilometer
  - Inch
  - Foot
  - Yard
  - Mile
- Code can be easily extended: The code itself is organized in a way that is easy to understand, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Add the measurement tool to a scene <a name="addTheMeasurementToolToAScene"/>
To measurement tool can be added to a scene by clicking the "Tools" menu at the topbar and selecting "Measurement Tool" in the options. Another way to add it is by attaching the "EditorMeasurementTool" script to any object in the scene.  

### 4.2 Setting up ruler size and measurement unit <a name="settingUpRulerSizeAndMeasurementUnit"/>
The ruler size and the measurement unit can be set at the top section of the script in the inspector. Just be careful that a very high value for the ruler can end up lagging the editor, in that case toggling off some of the axis can help with it. 

### 4.3 Displaying axis measurements <a name="displayingAxisMeasurements"/>
You can display measurements for the X, Y and Z-axis by toggling the "Display axis measurements" in the inspector. From there you can select which axis to you want to display.  

### 4.4 Displaying distance and angles between objects <a name="displayingDistanceAndAnglesBetweenObjects"/>
You can measure the distance/angles between a source object against a single or multiple targets. To add a source, just drag a gameObject to the "Source Object" field in the inspector (if no source is provided, the gameObject with the EditorMeasurementTool script will be used as a source). To add targets, just drag them to the "Target Object(s) field in the inspector. The in-between distance and the angle information can be toggled on and off by checking the boxes right under the "Source" and "Target(s)" fields.  

### 4.5 The measurement tool is not showing in the Scene View <a name="theMeasurementToolIsNotShowingInTheSceneView"/>
In case you can't visualize the measurement tool in the scene view, make sure that the toggle for gizmos in the editor (normally located at the top right corner) is turned on and the toggle for the "EditorMeasurementTool" script in the gizmos list is also on.  

## 5 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
