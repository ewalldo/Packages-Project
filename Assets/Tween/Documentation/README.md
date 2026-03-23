# Tween System
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Creating a tween](#creatingATween)
  - [Executing a tween](#executingATween)
  - [Grouping tweens](#groupingTweens)
  - [Add easing to tweens](#addEasingToTweens)
  - [Add looping to tweens](#addLoopingToTweens)
  - [Tween shortcuts](#tweenShortcuts)
- [Documentation](#documentation)
  - [Tweens](#availableTweens)
    - [Transform Tweens](#transformTweens)
    - [Camera Tweens](#cameraTweens)
    - [Canvas Group Tweens](#canvasGroupTweens)
    - [Image Tweens](#imageTweens)
    - [Light Tweens](#lightTweens)
    - [Material Tweens](#materialTweens)
    - [RawImage Tweens](#rawImageTweens)
    - [Renderer Tweens](#rendererTweens)
    - [Text Tweens](#textTweens)
  - [Easing Functions](#easingFunctions)
  - [Looping Functions](#loopingFunctions)
  - [Tween Groups](#tweenGroups)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The Tween package is a powerful toolset designed to simplify the process of creating and managing tweens in Unity. A tween, short for "in-betweening," refers to the animation transition between two values over a specific duration. With this package, you can effortlessly animate various types of objects, ranging from Transforms to Images, enhancing the visual and interactive elements of your Unity projects.  
Whether you want to smoothly move a game object, fade in/out a UI element, or perform complex animations, the Tween package provides a comprehensive solution. It offers a wide range of features and functionalities that empower developers to create stunning and dynamic visual effects without the need for complex scripting or manual interpolation.  
The Tween package excels in its simplicity and ease of use. It leverages intuitive syntax and convenient extension methods to streamline the tween creation and configuration process. By providing a clear and concise API, the package allows developers to focus on the creative aspects of animation, enabling them to bring their visions to life with minimal effort.  
Additionally, the Tween package enhances your workflow by offering grouping capabilities. You can create groups of tweens to be executed in parallel or in sequence, providing full control over the timing and synchronization of animations. This allows for the creation of intricate and synchronized animations that seamlessly combine multiple objects or properties.  To further enhance the quality and fluidity of your animations, the Tween package supports a variety of easing functions. These functions enable you to add natural and appealing motion effects to your tweens, making them more visually appealing and lifelike. With options such as ease-in, ease-out, and various other easing functions, you can effortlessly create animations that feel smooth and polished.  
Moreover, the Tween package includes looping functionality, allowing you to create tweens that repeat their animation either indefinitely or a specified number of times. This feature is especially useful for creating looping animations or implementing interactive elements that require repeated movement or transformation.  
In summary, the Tween package in Unity provides a robust set of tools for creating and managing tweens. With its support for various object types, grouping capabilities, easing functions, looping, and convenient extension methods, the package empowers developers to create engaging and visually appealing animations with ease. Whether you are a beginner or an experienced developer, the Tween package offers a valuable asset for enhancing the overall user experience of your Unity projects.  

This package has been updated to Unity 6000.3.9f1. However, it should work without issue with earlier or future versions of Unity.  
Please let us know if you encounter any issues with the version of Unity you are using.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release
- 1.1: Add tween options to the Camera class
- 1.1.1: Refactor tween classes to make extendibility easier
- 1.1.2: Edit group tweens
- 1.1.3: Add more options to Renderer tweens
- 1.2: Add material tweens
- 1.2.1: Add AnimationCurveEasing
- 1.3: Add Shake tweens to the Transform component and PunchEasing
- 1.4: Add TweenParameters and ShakeParameters classes
- 1.4.1: Change default values for local transform to be true
- 1.5: Add extra options to group tweens
- 1.5.1: Fixed issue with looping not resetting
- 1.5.2: Refactor tween classes
- 1.5.3: Add sample tween scene
- 1.6: Add tween options to RawImage tweens and new methods to group Tweens
- 1.6.1: Ensure package functionality in Unity version 6000.3.9f1

## 3 - Features <a name="features"/>
- Offers the possibility of "tween" many types of components.
- Tweens can be added to groups for more control on timing and synchronization between tweens.
- Has many options of easing.
- Looping options
- Shortcuts for easier usability
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Creating a tween <a name="creatingATween"/>
Tweens can be created by calling the corresponding tween class and passing the tween setting as parameters. Below is an example on how to create a move tween to translate an object from point A to point B, taking 2 seconds. For extra parameters please check the documentation.  
```csharp
TweenMove tweenMove = new TweenMove(objectToMove, pointA, pointB, 2f);
```

### 4.2 Executing a tween <a name="executingATween"/>
To execute a tween, just call the Execute() method of the tween class. Below is an example on how to execute a tween class.
```csharp
TweenMove tweenMove = new TweenMove(objectToMove, pointA, pointB, 2f);
StartCoroutine(tweenMove.Execute());
```

### 4.3 Grouping tweens <a name="groupingTweens"/>
Tweens can be grouped to be triggered in parallel or in sequence. For parallel execution, please use the TweenBuilder class, for sequential the TweenSequencer class can be used. Below is and example of how to create a group tween to move and scale an object at the same time while changing a text color.  
```csharp
TweenBuilder tweenBuilder = new TweenBuilder(monobehaviourClass);
tweenBuilder.AddTween(new TweenMove(objectToMove, pointA, pointB, 2f));
tweenBuilder.AddTween(new TweenScale(objectToMove, originalScale, newScale, 2f));
tweenBuilder.AddTween(new TweenTextColor(textMeshProObject, Color.White, Color.Black, 2f));
tweenBuilder.Execute();
```

### 4.4 Add easing to tweens <a name="addEasingToTweens"/>
You can change how the value change rate over time by passing an Easing class in the Tween constructor. If no easing is defined, linear easing will be used for the values. Below is an example on how to use EaseInSine to move a tween from point A to point B. Check the documentation section on information on all the easing supported, or check the EasingDemo scene for a visual comparison on the easing functions.
```csharp
TweenMove tweenMove = new TweenMove(objectToMove, pointA, pointB, 2f, 0f, false, new EaseInSine());
```

### 4.5 Add looping to tweens <a name="addLoopingToTweens"/>
You can add a looping option for each tween by passing a Looping class in the Tween constructor. Currently supported looping types are: Restart, PingPong and Incremental. For more information on them, as well as the possible parameters, please check the documentation section. Below is an example of a tween that will be moving from point A to B, than back to A, back to B, ... ten times (use zero as the first parameter if you want a tween to loop forever).
```csharp
TweenMove tweenMove = new TweenMove(objectToMove, pointA, pointB, 2f, 0f, false, new EaseInSine(), new PingPongLoop(10));
```

### 4.6 Tween shortcuts <a name="tweenShortcuts"/>
This package contains extension methods for all the tweens types, so you can define and execute a tween with just one line of code and without explicitly instantiate any class. Below is an example on how to create a move tween to translate an object from point A to point B. (For better control, we still recommend the use of the Tween classes or groups instead)
```csharp
objectToMove.TweenMove(pointA, pointB, 2f, 0f, false, new EaseInSine(), new PingPongLoop(10));
```

## 5 - Documentation <a name="documentation"/>
### 5.1 Tweens <a name="availableTweens"/>
Tweening, is a process that involves creating intermediate values, called inbetweens, between a start and end value. The intended result is to create the illusion smoothly transitioning from one value into another. The list below details which classes/attributes are supported by this tween package.
* [Transform Tweens](Transform.md) <a name="transformTweens">
* [Camera Tweens](Camera.md) <a name="cameraTweens">
* [CanvasGroup Tweens](CanvasGroup.md) <a name="canvasGroupTweens">
* [Image Tweens](Image.md) <a name="imageTweens">
* [Light Tweens](Light.md) <a name="lightTweens">
* [Material Tweens](Material.md) <a name="materialTweens">
* [RawImage Tweens](RawImage.md) <a name="rawImageTweens">
* [Renderer Tweens](Renderer.md) <a name="rendererTweens">
* [Text Tweens](Text.md) <a name="textTweens">
* [Easing Functions](Easing.md) <a name="easingFunctions">
* [Looping Functions](Looping.md) <a name="loopingFunctions">
* [Tween Groups](Groups.md) <a name="tweenGroups">

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com