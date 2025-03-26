# Light
## Table of contents
- [Documentation](#documentation)
  - [Light Tweens](#lightTweens)
        - [TweenLightColor()](#tweenLightColor)
        - [TweenLightIntensity()](#tweenLightIntensity)
  - [Light Tweens extensions](#lightTweensExtensions)
        - [TweenLightColor()](#tweenLightColorExtensions)
        - [TweenLightIntensity()](#tweenLightIntensityExtensions)

## Documentation <a name="documentation"/>
#### 1 Light Tweens <a name="lightTweens"/>
Tweens that are applied to the Light component.
##### 1.1 TweenLightColor() <a name="tweenLightColor"/>
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

##### 1.2 TweenLightIntensity() <a name="tweenLightIntensity"/>
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

#### 2 Light Tweens extensions <a name="lightTweensExtensions"/>
Tweens extensions for the Light class
##### 2.1 TweenLightColor() <a name="tweenLightColorExtensions"/>
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

##### 2.2 TweenLightIntensity() <a name="tweenLightIntensityExtensions"/>
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