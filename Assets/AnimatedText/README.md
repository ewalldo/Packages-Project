# Animated Text
## Table of contents
- [Introduction](#introduction)
- [Version History](#versionHistory)
- [Features](#features)
- [Get started](#getStarted)
  - [Add the text animations to a text](#addTheTextAnimationsToAText)
  - [Using the "Replace" tag](#usingTheReplaceTag)
  - [Using the runtime tags](#usingTheRuntimeTags)
  - [Using the animation tags](#usingTheAnimationTags)
  - [Using the richText tags](#usingTheRichTextTags)
  - [Typing text](#typingText)
- [Documentation](#documentation)
  - [TextAnimator.DefaultTypingSpeed](#textAnimatorDefaultTypingSpeed)
  - [TextAnimator.OnCharTyped](#textAnimatorOnCharTyped)
  - [TextAnimator.OnStartedTyping](#textAnimatorOnStartedTyping)
  - [TextAnimator.OnFinishedTyping](#textAnimatorOnFinishedTyping)
  - [TextAnimator.OnDialogueAction](#textAnimatorOnDialogueAction)
  - [TextAnimator.TypeText()](#textAnimatorTypeText)
  - [ReplaceTagParser.AddEntry()](#replaceTagParserAddEntry)
  - [ReplaceTagParser.ParseKey()](#replaceTagParserParseKey)
  - [ReplaceTagParser.GetTagsParserDictionary()](#replaceTagParserGetTagsParserDictionary)
- [Contact Information](#contactInformation)

## 1 - Introduction <a name="introduction"/>
The "Animated text" package is a collection of scripts that helps the user to quickly customize their texts, adding visual interest and enhancing the overall user experience. Whether you're creating a tutorial, or a dialogue system, this package provides an easy and intuitive way to animate text on screen. The package includes a variety of features to control the flow of the typing animation, trigger custom actions, and add animation to specific portions of the text.  
Additionally, the package provides a special tag for parsing text during runtime. This allows developers to create dynamic text that responds to user input, like custom names, providing a more immersive experience for the player.  
With support for all TextMeshPro's RichText tags, developers can customize the appearance of the text with bold, italic, underlined fonts, color, and so on.  
Overall, this Animated Text Package for Unity is an useful tool for any developer looking to add animated text effects to their Unity projects. Its easy-to-use and convenient features make it a valuable asset for creating engaging and interactive games and applications.  
This package was created and tested using Unity version 2022.1, but it should work without a problem with earlier or future versions of Unity.  

- **Package requirements: TextMeshPro**

## 2 - Version History <a name="versionHistory"/>
- 1.0: Initial release
- 1.1: Add option to change default typing speed from code

## 3 - Features <a name="features"/>
- Easy to add a typing animation to texts, just attach a script and call one method.
- Typing animation can be controlled through tags during runtime.
- Is able to trigger actions during typing animation.
- Has support all TextMeshPro's RichText tags.
- Allows to add animations to portions of the text.
- Text can be changed during runtime thanks to the "Replace" tag.
- Code can be easily extended: The code itself is organized in a way that is easy to understand and with comments on all the important parts, making it easier in case you want to extend by adding new functionalities.

## 4 - Get Started <a name="getStarted"/>
### 4.1 Add the text animations to a text <a name="addTheTextAnimationsToAText"/>
To add animations to your text, just add the TextAnimator script to a gameObject that contains a TextMeshProUGUI text.

### 4.2 Using the "Replace" tag <a name="usingTheReplaceTag"/>
The "Replace" tag will replace itself in a text with another text. To use this tag just add <replace=keyValue> where you want the text to appear in the sentence.  
Just make sure that the "keyValue" parameter is an existing key in the dictionary of the static ReplaceTagParser class.  
Key/value pairs can be added to the ReplaceTagParser class by calling its static AddEntry() method.

### 4.3 Using the runtime tags <a name="usingTheRuntimeTags"/>
The runtime tags are tags that execute an action during the typing sequence. The current available runtime tags are: <speed=value>, <pause=value> and <action=actionName>.  
The "speed" tag controls how fast the typing speed goes, use a high value means that the typing goes faster, while a lower one slows it down.  
The "pause" tag can be used to pause the typing of a text for an amount of seconds.  
The "action" tag is used to trigger the OnDialogueAction event using the "acitonName" as the parameter.

### 4.4 Using the animation tags <a name="usingTheAnimationTags"/>
Animation tags are used to animate a portion of the text, the currently supported animations are: wave, shake, pulse and rotate.  
The wave tag needs two parameters: frequency (controls the speed) and amplitude (controls the range), here is an example on how to use it: <wave=frequency,amplitude>.  
The shake tag needs one parameter: radius (offset from the center), here is an example on how to use it: <shake=radius>.  
The pulse tag needs three parameters: speed (controls the pulsing speed), variance (controls how much the scale can vary) and base value (the scale initial value), here is an example on how to use it: <pulse=speed,variance,baseValue>.  
The rotate tag needs one parameter: speed (rotation speed), here is an example on how to use it: <rotate=speed>.  
The corresponding closure tags for each animation are: </wave>, </shake>, </pulse>, </rotate>. Forget to add or close them in a different order can lead to unexpected behaviour.  
Correct order: <wave=5,10><shake=4>Text to wave and shake</shake></wave>.  
Incorrect order: <wave=5,10><shake=4>Text to wave and shake</wave></shake>.  

### 4.5 Using the richText tags <a name="usingTheRichTextTags"/>
This package supports all TextMeshPro's RichText tags, so it can be used in the same way in your text.

### 4.6 Typing text <a name="typingText"/>
To start typing a text, just invoke the TypeText() method in the TextAnimator class by passing a string (with your tags) as an attribute.

## 5 - Documentation <a name="documentation"/>
### 5.1 TextAnimator.DefaultTypingSpeed <a name="textAnimatorDefaultTypingSpeed"/>
The speed (pause between characters in seconds) of the texts being typed
#### Declaration
```csharp
public float DefaultTypingSpeed;
```
#### Returns
| Type | Description |
| :--- | :--- |
| float | The speed (pause between characters in seconds) of the texts being typed |

### 5.2 TextAnimator.OnCharTyped <a name="textAnimatorOnCharTyped"/>
Invoked when a char is typed on the screen
#### Declaration
```csharp
public Action<char> OnCharTyped;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| char | The char value typed on the screen |


### 5.3 TextAnimator.OnStartedTyping <a name="textAnimatorOnStartedTyping"/>
Invoked when a text starts being typed on the screen
#### Declaration
```csharp
public Action OnStartedTyping;
```


### 5.4 TextAnimator.OnFinishedTyping <a name="textAnimatorOnFinishedTyping"/>
Invoked when a text is finished being typed on the screen
#### Declaration
```csharp
public Action OnFinishedTyping;
```


### 5.5 TextAnimator.OnDialogueAction <a name="textAnimatorOnDialogueAction"/>
Invoked when an action tag is evaluated during typing
#### Declaration
```csharp
public Action<string> OnDialogueAction;
```
#### Parameters
| Type | Description |
| :--- | :--- |
| string | The value of the action tag |


### 5.6 TextAnimator.TypeText() <a name="textAnimatorTypeText"/>
Start typing the text on screen
#### Declaration
```csharp
public void TypeText(string textToType);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | textToType | The string containing the text information to be typed on the screen |


### 5.7 ReplaceTagParser.AddEntry() <a name="replaceTagParserAddEntry"/>
Add an entry to the parser dictionary
#### Declaration
```csharp
public static void AddEntry(string key, string value);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | key | The key value for the dictionary |
| string | value | The corresponding value to be associated with the key |


### 5.8 ReplaceTagParser.ParseKey() <a name="replaceTagParserParseKey"/>
Get the value associated with a key
#### Declaration
```csharp
public static string ParseKey(string key);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| string | key | The key value of the dictionary |
#### Returns
| Type | Description |
| :--- | :--- |
| string | The value associated with the key, or empty string if the value does not exist |


### 5.9 ReplaceTagParser.GetTagsParserDictionary() <a name="replaceTagParserGetTagsParserDictionary"/>
Get the whole tags dictionary
#### Declaration
```csharp
public static Dictionary<string, string> GetTagsParserDictionary;
```
#### Returns
| Type | Description |
| :--- | :--- |
| Dictionary<string, string> | The dictionary containing all the key/value pairs of the ReplaceTagParser class |


## 6 - Contact Information <a name="contactInformation"/>
If you have any questions or want to report a bug/problem with the package, please contact me at evaldo.lborba@gmail.com
