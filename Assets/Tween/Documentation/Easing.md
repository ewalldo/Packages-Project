# Easing
## Table of contents
- [Documentation](#documentation)
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

## Documentation <a name="documentation"/>
### Easing Functions <a name="easingFunctions"/>
Easing functions specify the rate of change of a parameter over time.
#### LinearEasing() <a name="linearEasing"/>
#### Declaration
```csharp
public class LinearEasing();
```

#### EaseInQuad() <a name="easeInQuad"/>
#### Declaration
```csharp
public class EaseInQuad();
```

#### EaseOutQuad() <a name="easeOutQuad"/>
#### Declaration
```csharp
public class EaseOutQuad();
```

#### EaseInOutQuad() <a name="easeInOutQuad"/>
#### Declaration
```csharp
public class EaseInOutQuad();
```

#### EaseInCubic() <a name="easeInCubic"/>
#### Declaration
```csharp
public class EaseInCubic();
```

#### EaseOutCubic() <a name="easeOutCubic"/>
#### Declaration
```csharp
public class EaseOutCubic();
```

#### EaseInOutCubic() <a name="easeInOutCubic"/>
#### Declaration
```csharp
public class EaseInOutCubic();
```

#### EaseInQuart() <a name="easeInQuart"/>
#### Declaration
```csharp
public class EaseInQuart();
```

#### EaseOutQuart() <a name="easeOutQuart"/>
#### Declaration
```csharp
public class EaseOutQuart();
```

#### EaseInOutQuart() <a name="easeInOutQuart"/>
#### Declaration
```csharp
public class EaseInOutQuart();
```

#### 5.2.11 EaseInQuint() <a name="easeInQuint"/>
#### Declaration
```csharp
public class EaseInQuint();
```

#### EaseOutQuint() <a name="easeOutQuint"/>
#### Declaration
```csharp
public class EaseOutQuint();
```

#### EaseInOutQuint() <a name="easeInOutQuint"/>
#### Declaration
```csharp
public class EaseInOutQuint();
```

#### EaseInInSine() <a name="easeInSine"/>
#### Declaration
```csharp
public class EaseInSine();
```

#### EaseOutSine() <a name="easeOutSine"/>
#### Declaration
```csharp
public class EaseOutSine();
```

#### EaseInOutSine() <a name="easeInOutSine"/>
#### Declaration
```csharp
public class EaseInOutSine();
```

#### EaseInExpo() <a name="easeInExpo"/>
#### Declaration
```csharp
public class EaseInExpo();
```

#### EaseOutExpo() <a name="easeOutExpo"/>
#### Declaration
```csharp
public class EaseOutExpo();
```

#### EaseInOutExpo() <a name="easeInOutExpo"/>
#### Declaration
```csharp
public class EaseInOutExpo();
```

#### EaseInCirc() <a name="easeInCirc"/>
#### Declaration
```csharp
public class EaseInCirc();
```

#### EaseOutCirc() <a name="easeOutCirc"/>
#### Declaration
```csharp
public class EaseOutCirc();
```

#### EaseInOutCirc() <a name="easeInOutCirc"/>
#### Declaration
```csharp
public class EaseInOutCirc();
```

#### EaseInBounce() <a name="easeInBounce"/>
#### Declaration
```csharp
public class EaseInBounce();
```

#### EaseOutBounce() <a name="easeOutBounce"/>
#### Declaration
```csharp
public class EaseOutBounce();
```

#### EaseInOutBounce() <a name="easeInOutBounce"/>
#### Declaration
```csharp
public class EaseInOutBounce();
```

#### EaseInBack() <a name="easeInBack"/>
#### Declaration
```csharp
public class EaseInBack();
```

#### EaseOutBack() <a name="easeOutBack"/>
#### Declaration
```csharp
public class EaseOutBack();
```

#### EaseInOutBack() <a name="easeInOutBack"/>
#### Declaration
```csharp
public class EaseInOutBack();
```

#### EaseInElastic() <a name="easeInElastic"/>
#### Declaration
```csharp
public class EaseInElastic();
```

#### EaseOutElastic() <a name="easeOutElastic"/>
#### Declaration
```csharp
public class EaseOutElastic();
```

#### EaseInOutElastic() <a name="easeInOutElastic"/>
#### Declaration
```csharp
public class EaseInOutElastic();
```

#### SpringEasing() <a name="springEasing"/>
#### Declaration
```csharp
public class SpringEasing();
```

#### PunchEasing() <a name="punchEasing"/>
#### Declaration
```csharp
public class PunchEasing();
```

#### AnimationCurveEasing() <a name="animationCurveEasing"/>
#### Declaration
```csharp
public class AnimationCurveEasing(AnimationCurve animationCurve);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AnimationCurve | animationCurve | The AnimationCurve which the easing will be based on |

#### EasingFactory.GetEasing() <a name="easingFactoryGetEasing"/>
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