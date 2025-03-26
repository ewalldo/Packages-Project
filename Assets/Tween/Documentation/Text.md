# Text
## Table of contents
- [Documentation](#documentation)
  - [Text Tweens](#textTweens)
        - [TweenTextColor()](#tweenTextColor)
        - [TweenTextFade()](#tweenTextFade)
  - [Text Tweens extensions](#textTweensExtensions)
        - [TweenTextColor()](#tweenTextColorExtensions)
        - [TweenTextFade()](#tweenTextFadeExtensions)

## Documentation <a name="documentation"/>
#### 1 Text Tweens <a name="textTweens"/>
Tweens that are applied to the TMP_Text component.
##### 1.1 TweenTextColor() <a name="tweenTextColor"/>
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

##### 1.2 TweenTextFade() <a name="tweenTextFade"/>
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

#### 2 Text Tweens extensions <a name="textTweensExtensions"/>
Tweens extensions for the TMP_Text class
##### 2.1 TweenTextColor() <a name="tweenTextColorExtensions"/>
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

##### 2.2 TweenTextFade() <a name="tweenTextFadeExtensions"/>
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