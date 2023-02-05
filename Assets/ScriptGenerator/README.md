# Script Generator
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Create a template](#createATemplate)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The "Script Generator" package is a tool that allows you to create script templates of different types inside of Unity.  
Right now, the only option to create a script in Unity is for a MonoBehaviour class, so if you want a generic C# class, an interface, a struct or any other type, you must erase the reference to the MonoBehaviour and/or replace the type of script and/or add more code to it.  
Do these things above doesn't take much time, but after creating many scripts, this process starts to get repetitive. This allows you to save a few seconds every time by giving the option to create the desired type right away inside of Unity.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release
- 1.1: Add option to create a "C# Custom Property Attribute"

## 3 - Features <a name="features"/>
- Template generation: Allows script templates to be created easily inside of Unity, current supported templates are: (more to be added in the future)
  - C# Class
  - C# MonoBehaviour
  - C# Scriptable Object
  - C# Custom Editor
  - C# Custom Property Drawer
  - C# Custom Property Attribute
  - C# Interface
  - C# Struct
  - C# Enum
- Code can be easily extended: The code itself is organized in a way that is easy to understand, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Create a template <a name="createATemplate"/>
- Templates can be created by right-clicking the project window, choose "Create"->"C# Scripts Templates"->"Type of template that you want"

## 5 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
