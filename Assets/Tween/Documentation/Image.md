# Image
## Table of contents
- [Documentation](#documentation)
  - [Image Tweens](#imageTweens)
        - [TweenImageColor()](#tweenImageColor)
        - [TweenImageFade()](#tweenImageFade)
        - [TweenImageFillAmount()](#tweenImageFillAmount)
  - [Image Tweens extensions](#imageTweensExtensions)
        - [TweenImageColor()](#tweenImageColorExtensions)
        - [TweenImageFade()](#tweenImageFadeExtensions)
        - [TweenImageFillAmount()](#tweenImageFillAmountExtensions)

## Documentation <a name="documentation"/>
#### 1 Image Tweens <a name="imageTweens"/>
Tweens that are applied to the Image component.
##### 1.1 TweenImageColor() <a name="tweenImageColor"/>
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

##### 1.2 TweenImageFade() <a name="tweenImageFade"/>
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

##### 1.3 TweenImageFillAmount() <a name="tweenImageFillAmount"/>
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

#### 2 Image Tweens extensions <a name="imageTweensExtensions"/>
Tweens extensions for the Image class
##### 2.1 TweenImageColor() <a name="tweenImageColorExtensions"/>
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

##### 2.2 TweenImageFade() <a name="tweenImageFadeExtensions"/>
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

##### 2.3 TweenImageFillAmount() <a name="tweenImageFillAmountExtensions"/>
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