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
      - [TweenMove()](#tweenMove)
      - [TweenRotateQuaternion()](#tweenRotateQuaternion)
      - [TweenRotateVector3()](#tweenRotateVector3)
      - [TweenScale()](#tweenScale)
      - [TweenShakePosition()](#tweenShakePosition)
      - [TweenShakeRotation()](#tweenShakeRotation)
      - [TweenShakeScale()](#tweenShakeScale)
    - [Camera Tweens](#cameraTweens)
      - [TweenCameraFOV()](#tweenCameraFOV)
    - [Canvas Group Tweens](#canvasGroupTweens)
      - [TweenCanvasGroupFade()](#tweenCanvasGroupFade)
    - [Image Tweens](#imageTweens)
      - [TweenImageColor()](#tweenImageColor)
      - [TweenImageFade()](#tweenImageFade)
      - [TweenImageFillAmount()](#tweenImageFillAmount)
    - [Light Tweens](#lightTweens)
      - [TweenLightColor()](#tweenLightColor)
      - [TweenLightIntensity()](#tweenLightIntensity)
    - [Material Tweens](#materialTweens)
      - [TweenMaterialColor()](#tweenMaterialColor)
      - [TweenMaterialFade()](#tweenMaterialFade)
    - [Renderer Tweens](#rendererTweens)
      - [TweenRendererColor()](#tweenRendererColor)
      - [TweenRendererFade()](#tweenRendererFade)
    - [Text Tweens](#textTweens)
      - [TweenTextColor()](#tweenTextColor)
      - [TweenTextFade()](#tweenTextFade)
  - [Easing Functions](#easingFunctions)
    - [LinearEasing()](#linearEasing)
    - [EaseOutQuad()](#easeInQuad)
    - [EaseInOutQuad()](#easeOutQuad)
    - [EaseInCubic()](#easeInOutQuad)
    - [EaseOutCubic()](#easeInCubic)
    - [EaseInOutCubic()](#easeOutCubic)
    - [EaseInQuart()](#easeInOutCubic)
    - [EaseOutQuart()](#easeInQuart)
    - [EaseInOutQuart()](#easeOutQuart)
    - [EaseInQuint()](#easeInOutQuart)
    - [EaseOutQuint()](#easeInQuint)
    - [EaseInOutQuint()](#easeOutQuint)
    - [EaseInInSine()](#easeInOutQuint)
    - [EaseOutSine()](#easeInSine)
    - [EaseInOutSine()](#easeOutSine)
    - [EaseInExpo()](#easeInOutSine)
    - [EaseOutExpo()](#easeInExpo)
    - [EaseInOutExpo()](#easeOutExpo)
    - [EaseInCirc()](#easeInOutExpo)
    - [EaseOutCirc()](#easeInCirc)
    - [EaseInOutCirc()](#easeOutCirc)
    - [EaseInBounce()](#easeInOutCirc)
    - [EaseOutBounce()](#easeInBounce)
    - [EaseInOutBounce()](#easeOutBounce)
    - [EaseInBack()](#easeInOutBounce)
    - [EaseOutBack()](#easeInBack)
    - [LinearEasing()](#easeOutBack)
    - [EaseInOutBack()](#easeInOutBack)
    - [EaseInElastic()](#easeInElastic)
    - [EaseOutElastic()](#easeOutElastic)
    - [EaseInOutElastic()](#easeInOutElastic)
    - [SpringEasing()](#springEasing)
    - [PunchEasing()](#punchEasing)
    - [AnimationCurveEasing()](#animationCurveEasing)
    - [EasingFactory.GetEasing()](#easingFactoryGetEasing)
  - [Looping Functions](#loopingFunctions)
    - [RestartLoop()](#restartLoop)
    - [PingPongLoop()](#pingPongLoop)
    - [IncrementalLoop()](#incrementalLoop)
  - [Tween Groups](#tweenGroups)
    - [TweenBuilder()](#tweenBuilder)
    - [TweenSequencer()](#tweenSequencer)
    - [ITweenGroup.OnAllTweensCompleted()](#iTweenGroupOnAllTweensCompleted)
    - [ITweenGroup.AddTween()](#iTweenGroupAddTween)
    - [ITweenGroup.Execute()](#iTweenGroupExecute)
    - [ITweenGroup.Reset()](#iTweenGroupReset)
    - [ITweenGroup.Stop()](#iTweenGroupStop)
    - [TweenSequenceer.AddDelay()](#tweenSequenceerAddDelay)
    - [TweenSequenceer.AddConditional()](#tweenSequenceerAddConditional)
  - [Tweens Extensions](#tweenExtensions)
    - [Transform Tweens extensions](#transformTweensExtensions)
      - [TweenMove()](#tweenMoveExtensions)
      - [TweenRotateQuaternion()](#tweenRotateQuaternionExtensions)
      - [TweenRotateVector3()](#tweenRotateVector3Extensions)
      - [TweenScale()](#tweenScaleExtensions)
      - [TweenShakePosition()](#tweenShakePositionExtensions)
      - [TweenShakeRotation()](#tweenShakeRotationExtensions)
      - [TweenShakeScale()](#tweenShakeScaleExtensions)
    - [Camera Tweens extensions](#cameraTweensExtensions)
      - [TweenCameraFOV()](#tweenCameraFOVExtensions)
    - [Canvas Group Tweens extensions](#canvasGroupTweensExtensions)
      - [TweenCanvasGroupFade()](#tweenCanvasGroupFadeExtensions)
    - [Image Tweens extensions](#imageTweensExtensions)
      - [TweenImageColor()](#tweenImageColorExtensions)
      - [TweenImageFade()](#tweenImageFadeExtensions)
      - [TweenImageFillAmount()](#tweenImageFillAmountExtensions)
    - [Light Tweens extensions](#lightTweensExtensions)
      - [TweenLightColor()](#tweenLightColorExtensions)
      - [TweenLightIntensity()](#tweenLightIntensityExtensions)
    - [Material Tweens extensions](#lightTweensExtensions)
      - [TweenMaterialColor()](#tweenMaterialColorExtensions)
      - [TweenMaterialFade()](#tweenMaterialFadeExtensions)
    - [Renderer Tweens extensions](#rendererTweensExtensions)
      - [TweenRendererColor()](#tweenRendererColorExtensions)
      - [TweenRendererFade()](#tweenRendererFadeExtensions)
    - [Text Tweens extensions](#textTweensExtensions)
      - [TweenTextColor()](#tweenTextColorExtensions)
      - [TweenTextFade()](#tweenTextFadeExtensions)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The Tween package is a powerful toolset designed to simplify the process of creating and managing tweens in Unity. A tween, short for "in-betweening," refers to the animation transition between two values over a specific duration. With this package, you can effortlessly animate various types of objects, ranging from Transforms to Images, enhancing the visual and interactive elements of your Unity projects.  
Whether you want to smoothly move a game object, fade in/out a UI element, or perform complex animations, the Tween package provides a comprehensive solution. It offers a wide range of features and functionalities that empower developers to create stunning and dynamic visual effects without the need for complex scripting or manual interpolation.  
The Tween package excels in its simplicity and ease of use. It leverages intuitive syntax and convenient extension methods to streamline the tween creation and configuration process. By providing a clear and concise API, the package allows developers to focus on the creative aspects of animation, enabling them to bring their visions to life with minimal effort.  
Additionally, the Tween package enhances your workflow by offering grouping capabilities. You can create groups of tweens to be executed in parallel or in sequence, providing full control over the timing and synchronization of animations. This allows for the creation of intricate and synchronized animations that seamlessly combine multiple objects or properties.  To further enhance the quality and fluidity of your animations, the Tween package supports a variety of easing functions. These functions enable you to add natural and appealing motion effects to your tweens, making them more visually appealing and lifelike. With options such as ease-in, ease-out, and various other easing functions, you can effortlessly create animations that feel smooth and polished.  
Moreover, the Tween package includes looping functionality, allowing you to create tweens that repeat their animation either indefinitely or a specified number of times. This feature is especially useful for creating looping animations or implementing interactive elements that require repeated movement or transformation.  
In summary, the Tween package in Unity provides a robust set of tools for creating and managing tweens. With its support for various object types, grouping capabilities, easing functions, looping, and convenient extension methods, the package empowers developers to create engaging and visually appealing animations with ease. Whether you are a beginner or an experienced developer, the Tween package offers a valuable asset for enhancing the overall user experience of your Unity projects.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

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
#### 5.1.1 Transform Tweens <a name="transformTweens"/>
Tweens that are applied to the Transform component.
##### 5.1.1.1 TweenMove() <a name="tweenMove"/>
Apply tween to the position or localPosition attribute of the Transform component
#### Declaration
```csharp
public TweenMove(Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, bool isLocalPosition = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenMove(Transform targetObject, Vector3 to, float duration, float delay = 0f, bool isLocalPosition = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenMove(Transform targetObject, TweenParameters<Vector3> tweenParameters, bool isLocalPosition = true, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | targetObject | The target Transform to apply the tween |
| Vector3 | from | The initial value of the position/localPosition |
| Vector3 | to | The final value of the position/localPosition |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| bool | isLocalPosition | Should the tween be applied on the Transform localPosition or position |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.1.1.2 TweenRotateQuaternion() <a name="tweenRotateQuaternion"/>
Apply tween to the rotation attribute of the Transform component by using Quaternions
#### Declaration
```csharp
public TweenRotateQuaternion(Transform targetObject, Quaternion from, Quaternion to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenRotateQuaternion(Transform targetObject, Quaternion to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenRotateQuaternion(Transform targetObject, TweenParameters<Quaternion> tweenParameters, bool isLocalRotation = true, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | targetObject | The target Transform to apply the tween |
| Quaternion | from | The initial value of the rotation |
| Quaternion | to | The final value of the rotation |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| bool | isLocalRotation | Should the tween be applied on the Transform localRotation or rotation |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.1.1.3 TweenRotateVector3() <a name="tweenRotateVector3"/>
Apply tween to the rotation attribute of the Transform component by using Vector3
#### Declaration
```csharp
public TweenRotateVector3(Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenRotateVector3(Transform targetObject, Vector3 to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenRotateVector3(Transform targetObject, TweenParameters<Vector3> tweenParameters, bool isLocalRotation = true, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | targetObject | The target Transform to apply the tween |
| Vector3 | from | The initial value of the rotation |
| Vector3 | to | The final value of the rotation |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| bool | isLocalRotation | Should the tween be applied on the Transform localRotation or rotation |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.1.1.4 TweenScale() <a name="tweenScale"/>
Apply tween to the localScale attribute of the Transform component
#### Declaration
```csharp
public TweenScale(Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenScale(Transform targetObject, Vector3 to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenScale(Transform targetObject, TweenParameters<Vector3> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | targetObject | The target Transform to apply the tween |
| Vector3 | from | The initial value of the scale |
| Vector3 | to | The final value of the scale |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.1.1.5 TweenShakePosition() <a name="tweenShakePosition"/>
Apply shake motion to the position or localPosition attribute of the Transform component
#### Declaration
```csharp
public TweenShakePosition(Transform targetObject, Vector3 from, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalPosition = true, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null);
public TweenShakePosition(Transform targetObject, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalPosition = true, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null);
public TweenShakePosition(Transform targetObject, ShakeParameters shakeParameters, bool isLocalPosition = true, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | targetObject | The target Transform to apply the tween |
| Vector3 | from | The initial value of the position/localPosition |
| Vector3 | direction | The direction of the shake on each axis |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| float | speed | The speed of the shake |
| float | maxMagnitude | The max value that the shake can reach |
| float | noiseMagnitude | The amount of noise to add to each shake |
| IgnoreAxisNoise | ignoreAxisNoise | Which axis noise won't be applied to |
| bool | isLocalPosition | Should the tween be applied on the Transform localPosition or position |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| RestartLoop | loopType | The restart loop for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| ShakeParameters | shakeParameters | Class containing the basic values for the tween |

##### 5.1.1.6 TweenShakeRotation() <a name="tweenShakeRotation"/>
Apply shake motion to the rotation attribute of the Transform component
#### Declaration
```csharp
public TweenShakeRotation(Transform targetObject, Vector3 from, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalRotation = true, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null);
public TweenShakeRotation(Transform targetObject, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalRotation = true, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null);
public TweenShakeRotation(Transform targetObject, ShakeParameters shakeParameters, bool isLocalRotation = true, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | targetObject | The target Transform to apply the tween |
| Vector3 | from | The initial value of the rotation/localRotation |
| Vector3 | direction | The direction of the shake on each axis |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| float | speed | The speed of the shake |
| float | maxMagnitude | The max value that the shake can reach |
| float | noiseMagnitude | The amount of noise to add to each shake |
| IgnoreAxisNoise | ignoreAxisNoise | Which axis noise won't be applied to |
| bool | isLocalPosition | Should the tween be applied on the Transform localRotation or rotation |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| RestartLoop | loopType | The restart loop for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| ShakeParameters | shakeParameters | Class containing the basic values for the tween |

##### 5.1.1.7 TweenShakeScale() <a name="tweenShakeScale"/>
Apply shake motion to the localScale attribute of the Transform component
#### Declaration
```csharp
public TweenShakeScale(Transform targetObject, Vector3 from, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null);
public TweenShakeScale(Transform targetObject, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null);
public TweenShakeScale(Transform targetObject, ShakeParameters shakeParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | targetObject | The target Transform to apply the tween |
| Vector3 | from | The initial value of the scale |
| Vector3 | direction | The direction of the shake on each axis |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| float | speed | The speed of the shake |
| float | maxMagnitude | The max value that the shake can reach |
| float | noiseMagnitude | The amount of noise to add to each shake |
| IgnoreAxisNoise | ignoreAxisNoise | Which axis noise won't be applied to |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| RestartLoop | loopType | The restart loop for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| ShakeParameters | shakeParameters | Class containing the basic values for the tween |

#### 5.1.2 Camera Tweens <a name="cameraTweens"/>
Tweens that are applied to the Camera component.
##### 5.1.2.1 TweenCameraFOV() <a name="tweenCameraFOV"/>
Apply tween to the FOV attribute of the Camera component
#### Declaration
```csharp
public TweenCameraFOV(Camera targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenCameraFOV(Camera targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenCameraFOV(Camera targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Camera | targetObject | The target Camera to apply the tween |
| float | from | The initial value of the FOV |
| float | to | The final value of the FOV |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

#### 5.1.3 Canvas Group Tweens <a name="canvasGroupTweens"/>
Tweens that are applied to the Canvas Group component.
##### 5.1.3.1 TweenCanvasGroupFade() <a name="tweenCanvasGroupFade"/>
Apply tween to the alpha attribute of the Canvas Group component
#### Declaration
```csharp
public TweenCanvasGroupFade(CanvasGroup targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenCanvasGroupFade(CanvasGroup targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenCanvasGroupFade(CanvasGroup targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| CanvasGroup | targetObject | The target CanvasGroup to apply the tween |
| float | from | The initial value of the alpha |
| float | to | The final value of the alpha |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

#### 5.1.4 Image Tweens <a name="imageTweens"/>
Tweens that are applied to the Image component.
##### 5.1.4.1 TweenImageColor() <a name="tweenImageColor"/>
Apply tween to the color attribute of the Image component
#### Declaration
```csharp
public TweenImageColor(Image targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenImageColor(Image targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenImageColor(Image targetObject, TweenParameters<Color> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Image | targetObject | The target Image to apply the tween |
| Color | from | The initial value of the color |
| Color | to | The final value of the color |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.1.4.2 TweenImageFade() <a name="tweenImageFade"/>
Apply tween to the alpha attribute of the Image component
#### Declaration
```csharp
public TweenImageFade(Image targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenImageFade(Image targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenImageFade(Image targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Image | targetObject | The target Image to apply the tween |
| float | from | The initial value of the alpha |
| float | to | The final value of the alpha |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.1.4.3 TweenImageFillAmount() <a name="tweenImageFillAmount"/>
Apply tween to the fillAmount attribute of the Image component
#### Declaration
```csharp
public TweenImageFillAmount(Image targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenImageFillAmount(Image targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenImageFillAmount(Image targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Image | targetObject | The target Image to apply the tween |
| float | from | The initial value of the fillAmount |
| float | to | The final value of the fillAmount |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

#### 5.1.5 Light Tweens <a name="lightTweens"/>
Tweens that are applied to the Light component.
##### 5.1.5.1 TweenLightColor() <a name="tweenLightColor"/>
Apply tween to the color attribute of the Light component
#### Declaration
```csharp
public TweenLightColor(Light targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenLightColor(Light targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenLightColor(Light targetObject, TweenParameters<Color> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Light | targetObject | The target Light to apply the tween |
| Color | from | The initial value of the color |
| Color | to | The final value of the color |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.1.5.2 TweenLightIntensity() <a name="tweenLightIntensity"/>
Apply tween to the intensity attribute of the Light component
#### Declaration
```csharp
public TweenLightIntensity(Light targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenLightIntensity(Light targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenLightIntensity(Light targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Light | targetObject | The target Light to apply the tween |
| float | from | The initial value of the intensity |
| float | to | The final value of the intensity |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

#### 5.1.6 Material Tweens <a name="materialTweens"/>
Tweens that are applied to the Material component.
##### 5.1.6.1 TweenMaterialColor() <a name="tweenMaterialColor"/>
Apply tween to the color attribute of the Material component
#### Declaration
```csharp
public TweenMaterialColor(Material targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenMaterialColor(Material targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenMaterialColor(Material targetObject, TweenParameters<Color> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Material | targetObject | The target Material to apply the tween |
| Color | from | The initial value of the color |
| Color | to | The final value of the color |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.1.6.2 TweenMaterialFade() <a name="tweenMaterialFade"/>
Apply tween to the alpha attribute of the Material component
#### Declaration
```csharp
public TweenMaterialFade(Material targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenMaterialFade(Material targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenMaterialFade(Material targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Material | targetObject | The target Material to apply the tween |
| float | from | The initial value of the alpha |
| float | to | The final value of the alpha |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

#### 5.1.7 Renderer Tweens <a name="rendererTweens"/>
Tweens that are applied to the Renderer component.
##### 5.1.7.1 TweenRendererColor() <a name="tweenRendererColor"/>
Apply tween to the color attribute of the Renderer's material component
#### Declaration
```csharp
public TweenRendererColor(Renderer targetObject, Color from, Color to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenRendererColor(Renderer targetObject, Color to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenRendererColor(Renderer targetObject, TweenParameters<Color> tweenParameters, int materialIndex = 0, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Renderer | targetObject | The target Renderer to apply the tween |
| Color | from | The initial value of the color |
| Color | to | The final value of the color |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| int | materialIndex | The index of the material to which the tween will be applied to |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.1.7.2 TweenRendererFade() <a name="tweenRendererFade"/>
Apply tween to the alpha attribute of the Renderer's material component
#### Declaration
```csharp
public TweenRendererFade(Renderer targetObject, float from, float to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenRendererFade(Renderer targetObject, float to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenRendererFade(Renderer targetObject, TweenParameters<float> tweenParameters, int materialIndex = 0, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Renderer | targetObject | The target Renderer to apply the tween |
| float | from | The initial value of the alpha |
| float | to | The final value of the alpha |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| int | materialIndex | The index of the material to which the tween will be applied to |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

#### 5.1.8 Text Tweens <a name="textTweens"/>
Tweens that are applied to the TMP_Text component.
##### 5.1.8.1 TweenTextColor() <a name="tweenTextColor"/>
Apply tween to the color attribute of the TMP_Text component
#### Declaration
```csharp
public TweenTextColor(TMP_Text targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenTextColor(TMP_Text targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenTextColor(TMP_Text targetObject, TweenParameters<Color> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| TMP_Text | targetObject | The target TMP_Text to apply the tween |
| Color | from | The initial value of the color |
| Color | to | The final value of the color |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.1.8.2 TweenTextFade() <a name="tweenTextFade"/>
Apply tween to the alpha attribute of the TMP_Text component
#### Declaration
```csharp
public TweenTextFade(TMP_Text targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenTextFade(TMP_Text targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenTextFade(TMP_Text targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| TMP_Text | targetObject | The target TMP_Text to apply the tween |
| float | from | The initial value of the alpha |
| float | to | The final value of the alpha |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

### 5.2 Easing Functions <a name="easingFunctions"/>
Easing functions specify the rate of change of a parameter over time.
#### 5.2.1 LinearEasing() <a name="linearEasing"/>
#### Declaration
```csharp
public class LinearEasing();
```

#### 5.2.2 EaseInQuad() <a name="easeInQuad"/>
#### Declaration
```csharp
public class EaseInQuad();
```

#### 5.2.3 EaseOutQuad() <a name="easeOutQuad"/>
#### Declaration
```csharp
public class EaseOutQuad();
```

#### 5.2.4 EaseInOutQuad() <a name="easeInOutQuad"/>
#### Declaration
```csharp
public class EaseInOutQuad();
```

#### 5.2.5 EaseInCubic() <a name="easeInCubic"/>
#### Declaration
```csharp
public class EaseInCubic();
```

#### 5.2.6 EaseOutCubic() <a name="easeOutCubic"/>
#### Declaration
```csharp
public class EaseOutCubic();
```

#### 5.2.7 EaseInOutCubic() <a name="easeInOutCubic"/>
#### Declaration
```csharp
public class EaseInOutCubic();
```

#### 5.2.8 EaseInQuart() <a name="easeInQuart"/>
#### Declaration
```csharp
public class EaseInQuart();
```

#### 5.2.9 EaseOutQuart() <a name="easeOutQuart"/>
#### Declaration
```csharp
public class EaseOutQuart();
```

#### 5.2.10 EaseInOutQuart() <a name="easeInOutQuart"/>
#### Declaration
```csharp
public class EaseInOutQuart();
```

#### 5.2.11 EaseInQuint() <a name="easeInQuint"/>
#### Declaration
```csharp
public class EaseInQuint();
```

#### 5.2.12 EaseOutQuint() <a name="easeOutQuint"/>
#### Declaration
```csharp
public class EaseOutQuint();
```

#### 5.2.13 EaseInOutQuint() <a name="easeInOutQuint"/>
#### Declaration
```csharp
public class EaseInOutQuint();
```

#### 5.2.14 EaseInInSine() <a name="easeInSine"/>
#### Declaration
```csharp
public class EaseInSine();
```

#### 5.2.15 EaseOutSine() <a name="easeOutSine"/>
#### Declaration
```csharp
public class EaseOutSine();
```

#### 5.2.16 EaseInOutSine() <a name="easeInOutSine"/>
#### Declaration
```csharp
public class EaseInOutSine();
```

#### 5.2.17 EaseInExpo() <a name="easeInExpo"/>
#### Declaration
```csharp
public class EaseInExpo();
```

#### 5.2.18 EaseOutExpo() <a name="easeOutExpo"/>
#### Declaration
```csharp
public class EaseOutExpo();
```

#### 5.2.19 EaseInOutExpo() <a name="easeInOutExpo"/>
#### Declaration
```csharp
public class EaseInOutExpo();
```

#### 5.2.20 EaseInCirc() <a name="easeInCirc"/>
#### Declaration
```csharp
public class EaseInCirc();
```

#### 5.2.21 EaseOutCirc() <a name="easeOutCirc"/>
#### Declaration
```csharp
public class EaseOutCirc();
```

#### 5.2.22 EaseInOutCirc() <a name="easeInOutCirc"/>
#### Declaration
```csharp
public class EaseInOutCirc();
```

#### 5.2.23 EaseInBounce() <a name="easeInBounce"/>
#### Declaration
```csharp
public class EaseInBounce();
```

#### 5.2.24 EaseOutBounce() <a name="easeOutBounce"/>
#### Declaration
```csharp
public class EaseOutBounce();
```

#### 5.2.25 EaseInOutBounce() <a name="easeInOutBounce"/>
#### Declaration
```csharp
public class EaseInOutBounce();
```

#### 5.2.26 EaseInBack() <a name="easeInBack"/>
#### Declaration
```csharp
public class EaseInBack();
```

#### 5.2.27 EaseOutBack() <a name="easeOutBack"/>
#### Declaration
```csharp
public class EaseOutBack();
```

#### 5.2.28 EaseInOutBack() <a name="easeInOutBack"/>
#### Declaration
```csharp
public class EaseInOutBack();
```

#### 5.2.29 EaseInElastic() <a name="easeInElastic"/>
#### Declaration
```csharp
public class EaseInElastic();
```

#### 5.2.30 EaseOutElastic() <a name="easeOutElastic"/>
#### Declaration
```csharp
public class EaseOutElastic();
```

#### 5.2.31 EaseInOutElastic() <a name="easeInOutElastic"/>
#### Declaration
```csharp
public class EaseInOutElastic();
```

#### 5.2.32 SpringEasing() <a name="springEasing"/>
#### Declaration
```csharp
public class SpringEasing();
```

#### 5.2.33 PunchEasing() <a name="punchEasing"/>
#### Declaration
```csharp
public class PunchEasing();
```

#### 5.2.34 AnimationCurveEasing() <a name="animationCurveEasing"/>
#### Declaration
```csharp
public class AnimationCurveEasing(AnimationCurve animationCurve);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AnimationCurve | animationCurve | The AnimationCurve which the easing will be based on |

#### 5.2.35 EasingFactory.GetEasing() <a name="easingFactoryGetEasing"/>
Create an instance of an EasingFunction based on an EasingType
#### Declaration
```csharp
public static EasingFunction GetEasing(EasingType easingType, params object[] constructorArgs);
public static EasingFunction GetEasing(string easingTypeString, params object[] constructorArgs)
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| EasingType | easingType | The EasingType of the EasingFunction to instantiate |
| string | easingTypeString | The EasingType of the EasingFunction to instantiate in string format |
| params object[] | constructorArgs | Optional arguments for the constructor |
#### Returns
| Type | Description |
| :--- | :--- |
| EasingFunction | An EasingFunction instance |

### 5.3 Looping Functions <a name="loopingFunctions"/>
Looping functions specify how the tween should loop upon completion.
#### 5.3.1 RestartLoop() <a name="restartLoop"/>
Restore the tween to its initial value and repeat the tween.
#### Declaration
```csharp
public RestartLoop(uint numLoops, float delayBetweenLoops = 0f, Func<bool> earlyExit = null, Action onOneLoopCompleted = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| uint | numLoops | The number of times that the tween should loop (0 indicates infinite looping) |
| float | delayBetweenLoops | The delay (in seconds) between loops |
| Func<bool> | earlyExit | Func to check if the tween should exit the looping (checked at the end of each loop) |
| Action | onOneLoopCompleted | Action to be executed at the end of each looping |

#### 5.3.2 PingPongLoop() <a name="pingPongLoop"/>
Invert the tween values, i.e. the initial value become the final one and final become the initial, and execute the tween.
#### Declaration
```csharp
public PingPongLoop(uint numLoops, float delayBetweenLoops = 0f, Func<bool> earlyExit = null, Action onOneLoopCompleted = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| uint | numLoops | The number of times that the tween should loop (0 indicates infinite looping) |
| float | delayBetweenLoops | The delay (in seconds) between loops |
| Func<bool> | earlyExit | Func to check if the tween should exit the looping (checked at the end of each loop) |
| Action | onOneLoopCompleted | Action to be executed at the end of each looping |

#### 5.3.3 IncrementalLoop() <a name="incrementalLoop"/>
Repeat the tween by using the final value as initial, and adding the difference of initial and final to the final tween.
#### Declaration
```csharp
public IncrementalLoop(uint numLoops, float delayBetweenLoops = 0f, Func<bool> earlyExit = null, Action onOneLoopCompleted = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| uint | numLoops | The number of times that the tween should loop (0 indicates infinite looping) |
| float | delayBetweenLoops | The delay (in seconds) between loops |
| Func<bool> | earlyExit | Func to check if the tween should exit the looping (checked at the end of each loop) |
| Action | onOneLoopCompleted | Action to be executed at the end of each looping |

### 5.4 Tween Groups <a name="tweenGroups"/>
Tween group classes are classes that implements the ITweenGroup interface and it can be used to group tweens together to be executed simultaneously or in sequence.
#### 5.4.1 TweenBuilder() <a name="tweenBuilder"/>
Create a tween group that can be triggered simultaneously.
#### Declaration
```csharp
public TweenBuilder(MonoBehaviour monoBehaviour);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| MonoBehaviour | monoBehaviour | MonoBehaviour that will be responsible to trigger all the tween coroutines of this group |

#### 5.4.2 TweenSequencer() <a name="tweenSequencer"/>
Create a tween group that will be executed in sequence.
#### Declaration
```csharp
public TweenSequencer(MonoBehaviour monoBehaviour);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| MonoBehaviour | monoBehaviour | MonoBehaviour that will be responsible to trigger all the tween coroutines of this group |

#### 5.4.3 ITweenGroup.OnAllTweensCompleted <a name="iTweenGroupOnAllTweensCompleted"/>
Invoked when all tweens in the group finishes its execution.
#### Declaration
```csharp
public Action OnAllTweensCompleted;
```

#### 5.4.4 ITweenGroup.AddTween() <a name="iTweenGroupAddTween"/>
Add a new tween to the group.
#### Declaration
```csharp
public ITweenGroup AddTween(ITweener tween);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| ITweener | tween | Tween to be added to the group |
#### Returns
| Type | Description |
| :--- | :--- |
| ITweenGroup | The tween group with the new tween added to it |

#### 5.4.5 ITweenGroup.Execute() <a name="iTweenGroupExecute"/>
Starts the execution of the tween group.
#### Declaration
```csharp
public void Execute();
```

#### 5.4.6 ITweenGroup.Reset() <a name="iTweenGroupReset"/>
Clear all tweens in the group
#### Declaration
```csharp
public void Reset();
```

#### 5.4.7 ITweenGroup.Stop() <a name="iTweenGroupStop"/>
Stop the execution of the tween group
#### Declaration
```csharp
public void Stop();
```

#### 5.4.8 TweenSequenceer.AddDelay() <a name="tweenSequenceerAddDelay"/>
Add a delay to a sequence.
#### Declaration
```csharp
public ITweenGroup AddDelay(float duration);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | duration | How long the delay should last |
#### Returns
| Type | Description |
| :--- | :--- |
| ITweenGroup | The tween group with the new delay added to it |

#### 5.4.9 TweenSequenceer.AddConditional() <a name="tweenSequenceerAddConditional"/>
Add a conditional check to a sequence, i.e. it will only proceed to the next tween in the sequence when the condition is fulfilled
#### Declaration
```csharp
public ITweenGroup AddConditional(Func<bool> condition, float checkInterval);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Func<bool> | condition | Func to check if the sequence should proceed to the next tween |
| float | checkInterval | How often should check the condition |
#### Returns
| Type | Description |
| :--- | :--- |
| ITweenGroup | The tween group with the new condition added to it |

### 5.5 Tween Extensions <a name="tweenExtensions"/>
Extensions methods were created for each tween, so it can be more easily used. (For better control, we still recommend the use of the Tween classes or groups instead)
#### 5.5.1 Transform Tweens extensions <a name="transformTweensExtensions"/>
Tween extensions for the Transform class
##### 5.5.1.1 TweenMove() <a name="tweenMoveExtensions"/>
Apply tween to the position or localPosition attribute of the Transform component
#### Declaration
```csharp
public static Transform TweenMove(this Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, bool isLocalPosition = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenMove(this Transform targetObject, Vector3 to, float duration, float delay = 0f, bool isLocalPosition = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenMove(this Transform targetObject, TweenParameters<Vector3> tweenParameters, bool isLocalPosition = true, Action onComplete = null);
public static Transform TweenMoveX(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalPosition = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenMoveX(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalPosition = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenMoveX(this Transform targetObject, TweenParameters<float> tweenParameters, bool isLocalPosition = true, Action onComplete = null);
public static Transform TweenMoveY(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalPosition = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenMoveY(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalPosition = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenMoveY(this Transform targetObject, TweenParameters<float> tweenParameters, bool isLocalPosition = true, Action onComplete = null);
public static Transform TweenMoveZ(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalPosition = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenMoveZ(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalPosition = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenMoveZ(this Transform targetObject, TweenParameters<float> tweenParameters, bool isLocalPosition = true, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | targetObject | The target Transform to apply the tween |
| Vector3 | from | The initial value of the position/localPosition |
| float | from | The initial value of the position/localPosition |
| Vector3 | to | The final value of the position/localPosition |
| float | to | The final value of the position/localPosition |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| bool | isLocalPosition | Should the tween be applied on the Transform localPosition or position |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.5.1.2 TweenRotateQuaternion() <a name="tweenRotateQuaternionExtensions"/>
Apply tween to the rotation attribute of the Transform component by using Quaternions
#### Declaration
```csharp
public static Transform TweenRotate(this Transform targetObject, Quaternion from, Quaternion to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotate(this Transform targetObject, Quaternion to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotate(this Transform targetObject, TweenParameters<Quaternion> tweenParameters, bool isLocalRotation = true, Action onComplete = null);
public static Transform TweenRotateXQuaternion(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotateXQuaternion(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotateXQuaternion(this Transform targetObject, TweenParameters<float> tweenParameters, bool isLocalRotation = true, Action onComplete = null);
public static Transform TweenRotateYQuaternion(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotateYQuaternion(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotateYQuaternion(this Transform targetObject, TweenParameters<float> tweenParameters, bool isLocalRotation = true, Action onComplete = null);
public static Transform TweenRotateZQuaternion(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotateZQuaternion(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotateZQuaternion(this Transform targetObject, TweenParameters<float> tweenParameters, bool isLocalRotation = true, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | targetObject | The target Transform to apply the tween |
| Quaternion | from | The initial value of the rotation |
| float | from | The initial value of the rotation |
| Quaternion | to | The final value of the rotation |
| float | to | The final value of the rotation |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| bool | isLocalRotation | Should the tween be applied on the Transform localRotation or rotation |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.5.1.3 TweenRotateVector3() <a name="tweenRotateVector3Extensions"/>
Apply tween to the rotation attribute of the Transform component by using Vector3
#### Declaration
```csharp
public static Transform TweenRotate(this Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotate(this Transform targetObject, Vector3 to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotate(this Transform targetObject, TweenParameters<Vector3> tweenParameters, bool isLocalRotation = true, Action onComplete = null);
public static Transform TweenRotateXVector3(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotateXVector3(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotateXVector3(this Transform targetObject, TweenParameters<float> tweenParameters, bool isLocalRotation = true, Action onComplete = null);
public static Transform TweenRotateYVector3(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotateYVector3(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotateYVector3(this Transform targetObject, TweenParameters<float> tweenParameters, bool isLocalRotation = true, Action onComplete = null);
public static Transform TweenRotateZVector3(this Transform targetObject, float from, float to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotateZVector3(this Transform targetObject, float to, float duration, float delay = 0f, bool isLocalRotation = true, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenRotateZVector3(this Transform targetObject, TweenParameters<float> tweenParameters, bool isLocalRotation = true, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | targetObject | The target Transform to apply the tween |
| Vector3 | from | The initial value of the rotation |
| float | from | The initial value of the rotation |
| Vector3 | to | The final value of the rotation |
| float | to | The final value of the rotation |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| bool | isLocalRotation | Should the tween be applied on the Transform localRotation or rotation |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.5.1.4 TweenScale() <a name="tweenScaleExtensions"/>
Apply tween to the localScale attribute of the Transform component
#### Declaration
```csharp
public static Transform TweenScale(this Transform targetObject, Vector3 from, Vector3 to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenScale(this Transform targetObject, Vector3 to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenScale(this Transform targetObject, TweenParameters<Vector3> tweenParameters, Action onComplete = null);
public static Transform TweenScaleX(this Transform targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenScaleX(this Transform targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenScaleX(this Transform targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
public static Transform TweenScaleY(this Transform targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenScaleY(this Transform targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenScaleY(this Transform targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
public static Transform TweenScaleZ(this Transform targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenScaleZ(this Transform targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Transform TweenScaleZ(this Transform targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | targetObject | The target Transform to apply the tween |
| Vector3 | from | The initial value of the scale |
| float | from | The initial value of the scale |
| Vector3 | to | The final value of the scale |
| float | to | The final value of the scale |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.5.1.5 TweenShakePosition() <a name="tweenShakePositionExtensions"/>
Apply shake motion to the position or localPosition attribute of the Transform component
#### Declaration
```csharp
public static Transform TweenShakePosition(this Transform targetObject, Vector3 from, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalPosition = true, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null);
public static Transform TweenShakePosition(this Transform targetObject, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalPosition = true, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null);
public static Transform TweenShakePosition(this Transform targetObject, ShakeParameters shakeParameters, bool isLocalPosition = true, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | targetObject | The target Transform to apply the tween |
| Vector3 | from | The initial value of the position/localPosition |
| Vector3 | direction | The direction of the shake on each axis |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| float | speed | The speed of the shake |
| float | maxMagnitude | The max value that the shake can reach |
| float | noiseMagnitude | The amount of noise to add to each shake |
| IgnoreAxisNoise | ignoreAxisNoise | Which axis noise won't be applied to |
| bool | isLocalPosition | Should the tween be applied on the Transform localPosition or position |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| RestartLoop | loopType | The restart loop for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| ShakeParameters | shakeParameters | Class containing the basic values for the tween |

##### 5.5.1.6 TweenShakeRotation() <a name="tweenShakeRotationExtensions"/>
Apply shake motion to the rotation or localRotation attribute of the Transform component
#### Declaration
```csharp
public static Transform TweenShakeRotation(this Transform targetObject, Vector3 from, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalRotation = true, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null);
public static Transform TweenShakeRotation(this Transform targetObject, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, bool isLocalRotation = true, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null);
public static Transform TweenShakeRotation(this Transform targetObject, ShakeParameters shakeParameters, bool isLocalRotation = true, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | targetObject | The target Transform to apply the tween |
| Vector3 | from | The initial value of the rotation/localRotation |
| Vector3 | direction | The direction of the shake on each axis |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| float | speed | The speed of the shake |
| float | maxMagnitude | The max value that the shake can reach |
| float | noiseMagnitude | The amount of noise to add to each shake |
| IgnoreAxisNoise | ignoreAxisNoise | Which axis noise won't be applied to |
| bool | isLocalPosition | Should the tween be applied on the Transform localRotation or rotation |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| RestartLoop | loopType | The restart loop for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| ShakeParameters | shakeParameters | Class containing the basic values for the tween |

##### 5.5.1.7 TweenShakeScale() <a name="tweenShakeScaleExtensions"/>
Apply shake motion to the localScale attribute of the Transform component
#### Declaration
```csharp
public static Transform TweenShakeScale(this Transform targetObject, Vector3 from, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null);
public static Transform TweenShakeScale(this Transform targetObject, Vector3 direction, float duration, float delay = 0f, float speed = 20f, float maxMagnitude = 1f, float noiseMagnitude = 0.3f, IgnoreAxisNoise ignoreAxisNoise = IgnoreAxisNoise.None, EasingFunction easingFunction = null, RestartLoop loopType = null, Action onComplete = null);
public static Transform TweenShakeScale(this Transform targetObject, ShakeParameters shakeParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Transform | targetObject | The target Transform to apply the tween |
| Vector3 | from | The initial value of the scale |
| Vector3 | direction | The direction of the shake on each axis |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| float | speed | The speed of the shake |
| float | maxMagnitude | The max value that the shake can reach |
| float | noiseMagnitude | The amount of noise to add to each shake |
| IgnoreAxisNoise | ignoreAxisNoise | Which axis noise won't be applied to |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| RestartLoop | loopType | The restart loop for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| ShakeParameters | shakeParameters | Class containing the basic values for the tween |

#### 5.5.2 Camera extensions <a name="cameraTweensExtensions"/>
Tween extensions for the Camera class
##### 5.5.2.1 TweenCameraFOV() <a name="tweenCameraFOVExtensions"/>
Apply tween to the FOV attribute of the Camera component
#### Declaration
```csharp
public static Camera TweenFOV(this Camera targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Camera TweenFOV(this Camera targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Camera TweenFOV(this Camera targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Camera | targetObject | The target Camera to apply the tween |
| float | from | The initial value of the FOV |
| float | to | The final value of the FOV |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

#### 5.5.3 Canvas Group extensions <a name="canvasGroupTweensExtensions"/>
Tween extensions for the CanvasGroup class
##### 5.5.3.1 TweenCanvasGroupFade() <a name="tweenCanvasGroupFadeExtensions"/>
Apply tween to the alpha attribute of the Canvas Group component
#### Declaration
```csharp
public static CanvasGroup TweenFade(this CanvasGroup targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static CanvasGroup TweenFade(this CanvasGroup targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static CanvasGroup TweenFade(this CanvasGroup targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| CanvasGroup | targetObject | The target CanvasGroup to apply the tween |
| float | from | The initial value of the alpha |
| float | to | The final value of the alpha |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

#### 5.5.4 Image Tweens extensions <a name="imageTweensExtensions"/>
Tweens extensions for the Image class
##### 5.5.4.1 TweenImageColor() <a name="tweenImageColorExtensions"/>
Apply tween to the color attribute of the Image component
#### Declaration
```csharp
public static Image TweenColor(this Image targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Image TweenColor(this Image targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Image TweenColor(this Image targetObject, TweenParameters<Color> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Image | targetObject | The target Image to apply the tween |
| Color | from | The initial value of the color |
| Color | to | The final value of the color |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.5.4.2 TweenImageFade() <a name="tweenImageFadeExtensions"/>
Apply tween to the alpha attribute of the Image component
#### Declaration
```csharp
public static Image TweenFade(this Image targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Image TweenFade(this Image targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Image TweenFade(this Image targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Image | targetObject | The target Image to apply the tween |
| float | from | The initial value of the alpha |
| float | to | The final value of the alpha |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.5.4.3 TweenImageFillAmount() <a name="tweenImageFillAmountExtensions"/>
Apply tween to the fillAmount attribute of the Image component
#### Declaration
```csharp
public static Image TweenFillAmount(this Image targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Image TweenFillAmount(this Image targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Image TweenFillAmount(this Image targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Image | targetObject | The target Image to apply the tween |
| float | from | The initial value of the fillAmount |
| float | to | The final value of the fillAmount |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

#### 5.5.5 Light Tweens extensions <a name="lightTweensExtensions"/>
Tweens extensions for the Light class
##### 5.5.5.1 TweenLightColor() <a name="tweenLightColorExtensions"/>
Apply tween to the color attribute of the Light component
#### Declaration
```csharp
public static Light TweenColor(this Light targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Light TweenColor(this Light targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Light TweenColor(this Light targetObject, TweenParameters<Color> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Light | targetObject | The target Light to apply the tween |
| Color | from | The initial value of the color |
| Color | to | The final value of the color |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.5.5.2 TweenLightIntensity() <a name="tweenLightIntensityExtensions"/>
Apply tween to the intensity attribute of the Light component
#### Declaration
```csharp
public static Light TweenIntensity(this Light targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Light TweenIntensity(this Light targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Light TweenIntensity(this Light targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Light | targetObject | The target Light to apply the tween |
| float | from | The initial value of the intensity |
| float | to | The final value of the intensity |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

#### 5.5.6 Material Tweens extensions <a name="materialTweensExtensions"/>
Tweens extensions for the Material class
##### 5.5.6.1 TweenMaterialColor() <a name="tweenMaterialColorExtensions"/>
Apply tween to the color attribute of the Material component
#### Declaration
```csharp
public static Material TweenColor(this Material targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Material TweenColor(this Material targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Material TweenColor(this Material targetObject, TweenParameters<Color> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Material | targetObject | The target Material to apply the tween |
| Color | from | The initial value of the color |
| Color | to | The final value of the color |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.5.6.2 TweenMaterialFade() <a name="tweenMaterialFadeExtensions"/>
Apply tween to the alpha attribute of the Material component
#### Declaration
```csharp
public static Material TweenFade(this Material targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Material TweenFade(this Material targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Material TweenFade(this Material targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Material | targetObject | The target Material to apply the tween |
| float | from | The initial value of the alpha |
| float | to | The final value of the alpha |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

#### 5.5.7 Renderer Tweens extensions <a name="rendererTweensExtensions"/>
Tweens extensions for the Renderer class
##### 5.5.7.1 TweenRendererColor() <a name="tweenRendererColorExtensions"/>
Apply tween to the color attribute of the Renderer's material component
#### Declaration
```csharp
public static Renderer TweenColor(this Renderer targetObject, Color from, Color to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Renderer TweenColor(this Renderer targetObject, Color to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Renderer TweenColor(this Renderer targetObject, TweenParameters<Color> tweenParameters, int materialIndex = 0, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Renderer | targetObject | The target Renderer to apply the tween |
| Color | from | The initial value of the color |
| Color | to | The final value of the color |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| int | materialIndex | The index of the material to which the tween will be applied to |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.5.7.2 TweenRendererFade() <a name="tweenRendererFadeExtensions"/>
Apply tween to the alpha attribute of the Renderer's material component
#### Declaration
```csharp
public static Renderer TweenFade(this Renderer targetObject, float from, float to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Renderer TweenFade(this Renderer targetObject, float to, float duration, float delay = 0f, int materialIndex = 0, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static Renderer TweenFade(this Renderer targetObject, TweenParameters<float> tweenParameters, int materialIndex = 0, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| Renderer | targetObject | The target Renderer to apply the tween |
| float | from | The initial value of the alpha |
| float | to | The final value of the alpha |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| int | materialIndex | The index of the material to which the tween will be applied to |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

#### 5.5.8 Text Tweens extensions <a name="textTweensExtensions"/>
Tweens extensions for the TMP_Text class
##### 5.5.8.1 TweenTextColor() <a name="tweenTextColorExtensions"/>
Apply tween to the color attribute of the TMP_Text component
#### Declaration
```csharp
public static TMP_Text TweenColor(this TMP_Text targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static TMP_Text TweenColor(this TMP_Text targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static TMP_Text TweenColor(this TMP_Text targetObject, TweenParameters<Color> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| TMP_Text | targetObject | The target TMP_Text to apply the tween |
| Color | from | The initial value of the color |
| Color | to | The final value of the color |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 5.5.8.2 TweenTextFade() <a name="tweenTextFadeExtensions"/>
Apply tween to the alpha attribute of the TMP_Text component
#### Declaration
```csharp
public static TMP_Text TweenFade(this TMP_Text targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static TMP_Text TweenFade(this TMP_Text targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public static TMP_Text TweenFade(this TMP_Text targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| TMP_Text | targetObject | The target TMP_Text to apply the tween |
| float | from | The initial value of the alpha |
| float | to | The final value of the alpha |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com