# Extensions
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Using the extensions in the project](#usingTheExtensionsInTheProject)
- [Documentation](#documentation)
  - [Array](#arrayExtensions)
  - [AudioSource](#audioSourceExtensions)
  - [Color](#colorExtensions)
  - [Enumerable](#enumerableExtensions)
  - [Float](#floatExtensions)
  - [GameObject](#gameObjectExtensions)
  - [Int](#intExtensions)
  - [List](#listExtensions)
  - [Measurements](#measurementExtensions)
  - [Renderer](#rendererExtensions)
  - [RichText](#richtextExtensions)
  - [String](#stringExtensions)
  - [TMPro](#tmproExtensions)
  - [Transform](#transformExtensions)
  - [Vector](#vectorExtensions)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The "Extensions" package for Unity is a collection of utility extensions designed to streamline common tasks and enhance the functionality of various Unity and C# classes. With these extensions, developers can optimize their workflow, write cleaner code, and improve overall productivity. This documentation provides an overview of the extensions included in the package and instructions for their usage.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release
- 1.1: Add extension methods to the AudioSource class and Vector2/3/4 structs plus a few methods to the other extensions
- 1.2: Add extension methods to the TMPro and string classes plus a few methods to the other extensions
- 1.2.1: Add extension methods to the Vector2 struct
- 1.3: Add extension method to the IEnumerable interface, plus new extension methods to Color, GameObject, IList, Math, String, Transform and Vector

## 3 - Features <a name="features"/>
- Extension methods for commonly used classes:
  - Array
  - AudioSource
  - Color
  - Enumerable
  - Float
  - GameObject
  - Int
  - List
  - Measurements
  - Renderer
  - RichText
  - String
  - TMPro
  - Transform
  - Vector
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Using the extensions in the project <a name="usingTheExtensionsInTheProject"/>
- To use the extensions in your project, just add the "extensions" namespace on your scripts: using Extensions
- You can then call the extension methods directly on instances of the corresponding classes. For example:
```csharp
// Shuffle an array
int[] numbers = { 1, 2, 3, 4, 5 };
numbers.Shuffle();

// Reset the transform of a GameObject
transform.ResetTransform();
```

## 5 - Documentation <a name="documentation"/>
* [Array](ArrayExtensions.md) <a name="arrayExtensions">
* [AudioSource](AudioSourceExtensions.md) <a name="audioSourceExtensions">
* [Color](ColorExtensions.md) <a name="colorExtensions">
* [Enumerable](EnumerableExtensions.md) <a name="enumerableExtensions">
* [Float](FloatExtensions.md) <a name="floatExtensions">
* [GameObject](GameObjectExtensions.md) <a name="gameObjectExtensions">
* [Int](IntExtensions.md) <a name="intExtensions">
* [List](ListExtensions.md) <a name="listExtensions">
* [Measurements](MeasurementsExtensions.md) <a name="measurementExtensions">
* [Renderer](RendererExtensions.md) <a name="rendererExtensions">
* [RichText](RichTextExtensions.md) <a name="richtextExtensions">
* [String](StringExtensions.md) <a name="stringExtensions">
* [TMPro](TMProExtensions.md) <a name="tmproExtensions">
* [Transform](TransformExtensions.md) <a name="transformExtensions">
* [Vector](VectorExtensions.md) <a name="vectorExtensions">


## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com