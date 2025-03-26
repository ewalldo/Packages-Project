# Renderer
## Table of contents
- [Documentation](#documentation)
  - [Renderer Tweens](#rendererTweens)
        - [TweenRendererColor()](#tweenRendererColor)
        - [TweenRendererFade()](#tweenRendererFade)
  - [Renderer Tweens extensions](#rendererTweensExtensions)
        - [TweenRendererColor()](#tweenRendererColorExtensions)
        - [TweenRendererFade()](#tweenRendererFadeExtensions)

## Documentation <a name="documentation"/>
#### 1 Renderer Tweens <a name="rendererTweens"/>
Tweens that are applied to the Renderer component.
##### 1.1 TweenRendererColor() <a name="tweenRendererColor"/>
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

##### 1.2 TweenRendererFade() <a name="tweenRendererFade"/>
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

#### 2 Renderer Tweens extensions <a name="rendererTweensExtensions"/>
Tweens extensions for the Renderer class
##### 2.1 TweenRendererColor() <a name="tweenRendererColorExtensions"/>
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

##### 2.2 TweenRendererFade() <a name="tweenRendererFadeExtensions"/>
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