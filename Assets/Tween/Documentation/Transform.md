# Transform
## Table of contents
- [Documentation](#documentation)
  - [Transform Tweens](#transformTweens)
        - [TweenMove()](#tweenMove)
        - [TweenRotateQuaternion()](#tweenRotateQuaternion)
        - [TweenRotateVector3()](#tweenRotateVector3)
        - [TweenScale()](#tweenScale)
        - [TweenShakePosition()](#tweenShakePosition)
        - [TweenShakeRotation()](#tweenShakeRotation)
        - [TweenShakeScale()](#tweenShakeScale)
  - [Transform Tweens extensions](#transformTweensExtensions)
        - [TweenMove()](#tweenMoveExtensions)
        - [TweenRotateQuaternion()](#tweenRotateQuaternionExtensions)
        - [TweenRotateVector3()](#tweenRotateVector3Extensions)
        - [TweenScale()](#tweenScaleExtensions)
        - [TweenShakePosition()](#tweenShakePositionExtensions)
        - [TweenShakeRotation()](#tweenShakeRotationExtensions)
        - [TweenShakeScale()](#tweenShakeScaleExtensions)

## Documentation <a name="documentation"/>
#### 1 Transform Tweens <a name="transformTweens"/>
Tweens that are applied to the Transform component.
##### 1.1 TweenMove() <a name="tweenMove"/>
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

##### 1.2 TweenRotateQuaternion() <a name="tweenRotateQuaternion"/>
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

##### 1.3 TweenRotateVector3() <a name="tweenRotateVector3"/>
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

##### 1.4 TweenScale() <a name="tweenScale"/>
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

##### 1.5 TweenShakePosition() <a name="tweenShakePosition"/>
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

##### 1.6 TweenShakeRotation() <a name="tweenShakeRotation"/>
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

##### 1.7 TweenShakeScale() <a name="tweenShakeScale"/>
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

#### 2 Transform Tweens extensions <a name="transformTweensExtensions"/>
Tween extensions for the Transform class
##### 2.1 TweenMove() <a name="tweenMoveExtensions"/>
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

##### 2.2 TweenRotateQuaternion() <a name="tweenRotateQuaternionExtensions"/>
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

##### 2.3 TweenRotateVector3() <a name="tweenRotateVector3Extensions"/>
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

##### 2.4 TweenScale() <a name="tweenScaleExtensions"/>
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

##### 2.5 TweenShakePosition() <a name="tweenShakePositionExtensions"/>
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

##### 2.6 TweenShakeRotation() <a name="tweenShakeRotationExtensions"/>
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

##### 2.7 TweenShakeScale() <a name="tweenShakeScaleExtensions"/>
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