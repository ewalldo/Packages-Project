# Material
## Table of contents
- [Documentation](#documentation)
  - [Material Tweens](#materialTweens)
        - [TweenMaterialColor()](#tweenMaterialColor)
        - [TweenMaterialFade()](#tweenMaterialFade)
  - [Material Tweens extensions](#lightTweensExtensions)
        - [TweenMaterialColor()](#tweenMaterialColorExtensions)
        - [TweenMaterialFade()](#tweenMaterialFadeExtensions)

## Documentation <a name="documentation"/>
#### 1 Material Tweens <a name="materialTweens"/>
Tweens that are applied to the Material component.
##### 1.1 TweenMaterialColor() <a name="tweenMaterialColor"/>
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

##### 1.2 TweenMaterialFade() <a name="tweenMaterialFade"/>
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

#### 2 Material Tweens extensions <a name="materialTweensExtensions"/>
Tweens extensions for the Material class
##### 2.1 TweenMaterialColor() <a name="tweenMaterialColorExtensions"/>
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

##### 2.2 TweenMaterialFade() <a name="tweenMaterialFadeExtensions"/>
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