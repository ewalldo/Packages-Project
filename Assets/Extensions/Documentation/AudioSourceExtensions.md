# Audio Source Extensions
## Table of contents
- [Documentation](#documentation)
  - [Audio Source](#audioSourceExtensions)
    - [CrossFade](#audioSourceExtensionsCrossFade)
    - [CrossFadeAsync](#audioSourceExtensionsCrossFadeAsync)
    - [FadeIn](#audioSourceExtensionsFadeIn)
    - [FadeInAsync](#audioSourceExtensionsFadeInAsync)
    - [FadeOut](#audioSourceExtensionsFadeOut)
    - [FadeOutAsync](#audioSourceExtensionsFadeOutAsync)

## Documentation <a name="documentation"/>
### AudioSource Extensions <a name="audioSourceExtensions"/>
#### CrossFade <a name="audioSourceExtensionsCrossFade"/>
Cross fade the audio of the audioSource to audioSourceIn over a specific duration
#### Declaration
```csharp
IEnumerator CrossFade(AudioSource audioSourceIn, float crossFadeTime, float startVolume = 1f, float finalVolume = 1f, Action onFinishedCrossFading = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AudioSource | audioSourceIn | The audio source to fade in |
| float | crossFadeTime | The duration over which the cross fade should occur |
| float | startVolume | The starting volume level of the audio to fade out (between 0 and 1) |
| float | finalVolume | The final volume level of the audio to fade in (between 0 and 1) |
| Action | onFinishedFading | Action to invoke when the cross fade is finished |
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerator | An IEnumerator for the cross fade coroutine execution |


#### CrossFadeAsync <a name="audioSourceExtensionsCrossFadeAsync"/>
Cross fade the audio of the audioSource to audioSourceIn over a specific duration
#### Declaration
```csharp
Task CrossFadeAsync(AudioSource audioSourceIn, float crossFadeTime, CancellationToken cancellationToken, float startVolume = 1f, float finalVolume = 1f, Action onFinishedCrossFading = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| AudioSource | audioSourceIn | The audio source to fade in |
| float | crossFadeTime | The duration over which the cross fade should occur |
| CancellationToken | cancellationToken | Cancellation token to safely stop the cross fade operation midway through |
| float | startVolume | The starting volume level of the audio to fade out (between 0 and 1) |
| float | finalVolume | The final volume level of the audio to fade in (between 0 and 1) |
| Action | onFinishedFading | Action to invoke when the cross fade is finished |
#### Returns
| Type | Description |
| :--- | :--- |
| Task | An asynchronous task for the cross fade operation |


#### FadeIn <a name="audioSourceExtensionsFadeIn"/>
Fades in the audio of the audioSource over a specified duration
#### Declaration
```csharp
IEnumerator FadeIn(float fadeInTime, float startVolume = 0f, float finalVolume = 1f, Action onFinishedFading = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | fadeInTime | The duration over which the fade in should occur |
| float | startVolume | The starting volume level of the audio (between 0 and 1) |
| float | finalVolume | The final volume level of the audio (between 0 and 1) |
| Action | onFinishedFading | Action to invoke when the fade in is finished |
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerator | An IEnumerator for the fade in coroutine execution |


#### FadeInAsync <a name="audioSourceExtensionsFadeInAsync"/>
Fades in the audio of the audioSource over a specified duration
#### Declaration
```csharp
Task FadeInAsync(float fadeInTime, CancellationToken cancellationToken, float startVolume = 0f, float finalVolume = 1f, Action onFinishedFading = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | fadeInTime | The duration over which the fade in should occur |
| CancellationToken | cancellationToken | Cancellation token to safely stop the fade in operation midway through |
| float | startVolume | The starting volume level of the audio (between 0 and 1) |
| float | finalVolume | The final volume level of the audio (between 0 and 1) |
| Action | onFinishedFading | Action to invoke when the fade in is finished |
#### Returns
| Type | Description |
| :--- | :--- |
| Task | An asynchronous task for the fade in operation |


#### FadeOut <a name="audioSourceExtensionsFadeOut"/>
Fades out the audio of the audioSource over a specified duration
#### Declaration
```csharp
IEnumerator FadeOut(float fadeOutTime, float startVolume = 1f, float finalVolume = 0f, bool resetVolumeAfterFade = false, Action onFinishedFading = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | fadeOutTime | The duration over which the fade out should occur |
| float | startVolume | The starting volume level of the audio (between 0 and 1) |
| float | finalVolume | The final volume level of the audio (between 0 and 1) |
| bool | resetVolumeAfterEnds | Indicates wheter to reset the volume to its starting value after the fade operation |
| Action | onFinishedFading | Action to invoke when the fade out is finished |
#### Returns
| Type | Description |
| :--- | :--- |
| IEnumerator | An IEnumerator for the fade out coroutine execution |


#### FadeOutAsync <a name="audioSourceExtensionsFadeOutAsync"/>
Fades out the audio of the audioSource over a specified duration
#### Declaration
```csharp
Task FadeOutAsync(float fadeOutTime, CancellationToken cancellationToken, float startVolume = 1f, float finalVolume = 0f, bool resetVolumeAfterFade = false, Action onFinishedFading = null);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| float | fadeOutTime | The duration over which the fade out should occur |
| CancellationToken | cancellationToken | Cancellation token to safely stop the fade out operation midway through |
| float | startVolume | The starting volume level of the audio (between 0 and 1) |
| float | finalVolume | The final volume level of the audio (between 0 and 1) |
| bool | resetVolumeAfterEnds | Indicates wheter to reset the volume to its starting value after the fade operation |
| Action | onFinishedFading | Action to invoke when the fade out is finished |
#### Returns
| Type | Description |
| :--- | :--- |
| Task | An asynchronous task for the fade out operation |