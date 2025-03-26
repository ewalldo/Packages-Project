# RawImage
## Table of contents
- [Documentation](#documentation)
  - [RawImage Tweens](#rawImageTweens)
        - [TweenRawImageColor()](#tweenRawImageColor)
        - [TweenRawImageFade()](#tweenRawImageFade)

## Documentation <a name="documentation"/>
#### 1 RawImage Tweens <a name="rawImageTweens"/>
Tweens that are applied to the RawImage component.
##### 1.1 TweenRawImageColor() <a name="tweenRawImageColor"/>
Apply tween to the color attribute of the RawImage's component
#### Declaration
```csharp
public TweenRawImageColor(RawImage targetObject, Color from, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenRawImageColor(RawImage targetObject, Color to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenRawImageColor(RawImage targetObject, TweenParameters<Color> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| RawImage | targetObject | The target RawImage to apply the tween |
| Color | from | The initial value of the color |
| Color | to | The final value of the color |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |

##### 1.2 TweenRawImageFade() <a name="tweenRawImageFade"/>
Apply tween to the alpha attribute of the RawImage's color component
#### Declaration
```csharp
public TweenRawImageFade(RawImage targetObject, float from, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenRawImageFade(RawImage targetObject, float to, float duration, float delay = 0f, EasingFunction easingFunction = null, ILoopType loopType = null, Action onComplete = null);
public TweenRawImageFade(RawImage targetObject, TweenParameters<float> tweenParameters, Action onComplete = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| RawImage | targetObject | The target RawImage to apply the tween |
| float | from | The initial value of the alpha |
| float | to | The final value of the alpha |
| float | duration | How long the tween will take to complete |
| float | delay | How long should it wait until the tween starts |
| EasingFunction | easingFunction | The easing function to be applied when tweening the values |
| ILoopType | loopType | The type of looping for this tween |
| Action | onComplete | Action to be executed when the tween is completed |
| TweenParameters | tweenParameters | Class containing the basic values for the tween |