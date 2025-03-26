# Camera
## Table of contents
- [Documentation](#documentation)
  - [Camera Tweens](#cameraTweens)
        - [TweenCameraFOV()](#tweenCameraFOV)
  - [Camera Tweens extensions](#cameraTweensExtensions)
        - [TweenCameraFOV()](#tweenCameraFOVExtensions)

## Documentation <a name="documentation"/>
#### 1 Camera Tweens <a name="cameraTweens"/>
Tweens that are applied to the Camera component.
##### 1.1 TweenCameraFOV() <a name="tweenCameraFOV"/>
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

#### 2 Camera extensions <a name="cameraTweensExtensions"/>
Tween extensions for the Camera class
##### 2.1 TweenCameraFOV() <a name="tweenCameraFOVExtensions"/>
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