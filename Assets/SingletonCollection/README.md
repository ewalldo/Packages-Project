# Singleton Collection
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [SimpleSingleton](#simpleSingleton)
  - [PersistentOldestSingleton](#persistentOldestSingleton)
  - [PersistentNewestSingleton](#persistentNewestSingleton)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The "Singleton Collection" package provides multiple types of Singleton patterns for Unity projects, helping developers manage unique instances of components across their scenes. It includes three distinct singleton types: SimpleSingleton, PersistentOldestSingleton, and PersistentNewestSingleton. Each singleton type is designed to control how the single instance behaves during runtime, including whether it persists across scenes or if older instances are preserved.  

This package was developed and tested with Unity version 2022.1 but should work with earlier and future Unity versions as well.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release

## 3 - Features <a name="features"/>
- Simple Singleton: Ensures that only one instance of the component exists. If a new instance is created, it destroys the new instance and keeps the original. Don't persist between scenes.
- Persistent Oldest Singleton: The oldest instance is preserved across scene loads using DontDestroyOnLoad(). Any new instances are automatically destroyed.
- Persistent Newest Singleton: The newest instance becomes the singleton and persists across scene loads, while older instances are destroyed.
- Code can be easily extended: The code itself is organized in a way that is easy to understand, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
To start using the SingletonCollection package in your Unity project, follow these steps:
### 4.1 SimpleSingleton <a name="simpleSingleton"/>
This singleton ensures that only one instance of a component exists, and any subsequent instances are destroyed.
```csharp
public class MySingletonClass : SimpleSingleton<MySingletonClass>
{
  protected override void Awake()
  {
    base.Awake();
    // Additional initialization logic here
  }
}
```

### 4.2 PersistentOldestSingleton <a name="persistentOldestSingleton"/>
This singleton ensures the oldest instance persists across scenes, while newer instances are automatically destroyed.
```csharp
public class MyPersistentOldestClass : PersistentOldestSingleton<MyPersistentOldestClass>
{
  protected override void Awake()
  {
    base.Awake();
    // Additional initialization logic here
  }
}
```

### 4.3 PersistentNewestSingleton <a name="persistentNewestSingleton"/>
This singleton ensures the most recent instance persists across scenes, destroying any older instances.
```csharp
public class MyPersistentNewestClass : PersistentNewestSingleton<MyPersistentNewestClass>
{
  protected override void Awake()
  {
    base.Awake();
    // Additional initialization logic here
  }
}
```

## 5 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
