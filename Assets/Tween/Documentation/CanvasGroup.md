# Canvas Group
## Table of contents
- [Documentation](#documentation)
  - [Canvas Group Tweens](#canvasGroupTweens)
        - [TweenCanvasGroupFade()](#tweenCanvasGroupFade)
  - [Canvas Group Tweens extensions](#canvasGroupTweensExtensions)
        - [TweenCanvasGroupFade()](#tweenCanvasGroupFadeExtensions)

## Documentation <a name="documentation"/>
#### 1 Canvas Group Tweens <a name="canvasGroupTweens"/>
Tweens that are applied to the Canvas Group component.
##### 1.1 TweenCanvasGroupFade() <a name="tweenCanvasGroupFade"/>
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

#### 2 Canvas Group extensions <a name="canvasGroupTweensExtensions"/>
Tween extensions for the CanvasGroup class
##### 2.1 TweenCanvasGroupFade() <a name="tweenCanvasGroupFadeExtensions"/>
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