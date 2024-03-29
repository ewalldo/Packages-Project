# Extra Attributes
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Assing an attribute to a field](#assingAnAttributeToAField)
- [Documentation](#documentation)
  - [AssetPath()](#assetPath)
  - [ColorPalette()](#colorPalette)
  - [FloatRangeWithStep()](#floatRangeWithStep)
  - [HeaderPlus()](#headerPlus)
  - [HideOnEdit()](#hideOnEdit)
  - [HideOnPlay()](#hideOnPlay)
  - [IntRangeWithStep()](#intRangeWithStep)
  - [LayerField()](#layerField)
  - [PrettyField()](#prettyField)
  - [ProjectOnly()](#projectOnly)
  - [ReadOnly()](#readOnly)
  - [ReadOnlyOnEdit()](#readOnlyOnEdit)
  - [ReadOnlyOnPlay()](#readOnlyOnPlay)
  - [RequiredField()](#requiredField)
  - [ResourcesPath()](#resourcesPath)
  - [SceneField()](#sceneField)
  - [SceneOnly()](#sceneOnly)
  - [TagField()](#tagField)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The "Extra Attributes" package for Unity is a toolset designed to significantly enhance the Unity Inspector experience, making it more intuitive, organized, and efficient for Unity developers. This package aims to streamline the process of designing and configuring Unity components by providing a collection of custom attributes that can be easily applied to fields within your scripts. These attributes offer additional functionalities and visual enhancements, improving the overall productivity, maintainability of your projects and enforce validation rules within the Unity Inspector.  
With the "Extra Attributes" package, you can create more informative and user-friendly Inspector layouts, ensuring a smoother workflow during development and making it easier to manage complex projects with numerous components.  
For a full list of the supported attributes, please check the documentation section.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.  

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Enhanced Headers and Label Fields: The package offers an enhanced version of headers and labels in the Inspector. These improved headers allow you to customize your component fields, making it simpler to understand their purpose at a glance.
- Layer/Tag/Scene Fields: These attributes provide dropdown menus in the Inspector, presenting a list of available options defined in Unity. By utilizing these attributes, you can easily assign the appropriate option to objects, avoiding potential errors and maintaining consistency in your scenes.
- Other attributes: This package offers a fair amount of extra attributes that can be used for many situations in your Unity projects, for a full list of supported attributes, please check the documentation section.
- Data Integrity and Validation: By leveraging attributes like Read Only and Required Field, you can control data modifications and enforce essential validation rules, thereby improving the robustness and reliability of your scripts.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Assing an attribute to a field <a name="assingAnAttributeToAField"/>
Attributes in this package can be assigned in the same way as Unity's attributes, just add the attribute above a property declaration. For example:  
```csharp
[RequiredField][SerializeField]
private AudioSource audioSource;
```

## 5 - Documentation <a name="documentation"/>
### 5.1 AssetPath() <a name="assetPath"/>
Allows drag/drop of files in the field to automatically fill up with its path (string only)
#### Declaration
```csharp
public AssetPath();
```


### 5.2 ColorPalette() <a name="colorPalette"/>
Restrict the color field to a limited set of options (Color only)
#### Declaration
```csharp
public ColorPalette(params string[] colorNames);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string[] | colorNames | Color name or its RBG representation in a string format (R, G, B). Ex: [ColorPalette("Red", "Green", "Blue")] or [ColorPalette("(1, 0, 0)", "(0, 1, 0)", "(0, 0, 1)")] |


### 5.3 FloatRangeWithStep() <a name="floatRangeWithStep"/>
Attribute used to make a float variable be restricted to a specific range and only be modified by a specific step value (float only)
#### Declaration
```csharp
public FloatRangeWithStep(float minValue, float maxValue, float step);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | minValue | The minimum value for the float |
| float | maxValue | The maximum value for the float |
| float | step | Amount that the value should change |


### 5.4 HeaderPlus() <a name="headerPlus"/>
Attribute used to add a header above fields in the inspector, can be customized with an icon and/or text color
#### Declaration
```csharp
public HeaderPlus(string headerText, float[] headerColor = null, TextAnchor textAnchor = TextAnchor.MiddleLeft, string iconName = "");
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | headerText | The text for the header |
| float[] | headerColor | The color for the text in a float[3] (RGB) or float[4] (RGBA) format |
| TextAnchor | textAnchor | Alignment for the text header |
| string | iconName | Name of the texture in the Resources folder |


### 5.5 HideOnEdit() <a name="hideOnEdit"/>
Attribute used to hide the field while in edit mode (will be displayed during play mode)
#### Declaration
```csharp
public HideOnEdit();
```


### 5.6 HideOnPlay() <a name="hideOnPlay"/>
Attribute used to hide the field while in play mode (will be displayed during edit mode)
#### Declaration
```csharp
public HideOnPlay();
```


### 5.7 IntRangeWithStep() <a name="intRangeWithStep"/>
Attribute used to make a int variable be restricted to a specific range and only be modified by a specific step value (int only)
#### Declaration
```csharp
public IntRangeWithStep(int minValue, int maxValue, int step);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| int | minValue | The minimum value for the int |
| int | maxValue | The maximum value for the int |
| int | step | Amount that the value should change |


### 5.8 LayerField() <a name="layerField"/>
Attribute to convert a int field into a layer selection field (int only)
#### Declaration
```csharp
public LayerField();
```


### 5.9 PrettyField() <a name="prettyField"/>
Attribute to add customization to the label part of a field
#### Declaration
```csharp
public PrettyFieldAttribute(string fieldText = "", float[] fieldColor = null, string iconName = "");
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | fieldText | The text for the label |
| fieldColor[] | fieldColor | The color for the text in a float[3] (RGB) or float[4] (RGBA) format |
| string | iconName | Name of the texture in the Resources folder |


### 5.10 ProjectOnly() <a name="projectOnly"/>
Attribute to restrict the object references to items located in the Project window only
#### Declaration
```csharp
public ProjectOnly();
```


### 5.11 ReadOnly() <a name="readOnly"/>
Attribute to restrict the field to be read-only (i.e. non-editable) in the inspector
#### Declaration
```csharp
public ReadOnly();
```


### 5.12 ReadOnlyOnEdit() <a name="readOnlyOnEdit"/>
Attribute to restrict the field to be read-only (i.e. non-editable) while in edit mode
#### Declaration
```csharp
public ReadOnlyOnEdit();
```


### 5.13 ReadOnlyOnPlay() <a name="readOnlyOnPlay"/>
Attribute to restrict the field to be read-only (i.e. non-editable) while in play mode
#### Declaration
```csharp
public ReadOnlyOnPlay();
```


### 5.14 RequiredField() <a name="requiredField"/>
Attribute to mark a field as required, i.e. will display an error while the value is null
#### Declaration
```csharp
public RequiredField();
```


### 5.15 ResourcesPath() <a name="resourcesPath"/>
Allows drag/drop of files from within the resouces folder in this field to automatically fill up with its filename (string only)
#### Declaration
```csharp
public ResourcesPath();
```


### 5.16 SceneField() <a name="sceneField"/>
Attribute to convert a string field into a scene selection field (string only)
#### Declaration
```csharp
public SceneField();
```


### 5.17 SceneOnly() <a name="sceneOnly"/>
Attribute to restrict the object references to items located in scenes only
#### Declaration
```csharp
public SceneOnly();
```


### 5.18 TagField() <a name="tagField"/>
Attribute to convert a string field into a tag selection field (string only)
#### Declaration
```csharp
public TagField();
```


## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
