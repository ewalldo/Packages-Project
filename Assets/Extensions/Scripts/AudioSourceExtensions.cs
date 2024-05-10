using System;
using System.Collections;
using UnityEngine;

namespace Extensions
{
    /// <summary>
    /// Extension methods for <see cref="AudioSource"/> types
    /// </summary>
    public static class AudioSourceExtensions
    {
        /// <summary>
        /// Fades out the audio of the <paramref name="audioSource"/> over a specified duration.
        /// </summary>
        /// <param name="audioSource">The audio source to fade out</param>
        /// <param name="fadeOutTime">The duration over which the fade out should occur</param>
        /// <param name="startVolume">The starting volume level of the audio (between 0 and 1)</param>
        /// <param name="finalVolume">The final volume level of the audio (between 0 and 1)</param>
        /// <param name="resetVolumeAfterFade">Indicates wheter to reset the volume to its starting value after the fade operation</param>
        /// <param name="onFinishedFading">Action to invoke when the fade out is finished</param>
        /// <returns>An <see cref="IEnumerator"/> for the fade out coroutine execution</returns>
        public static IEnumerator FadeOut(this AudioSource audioSource, float fadeOutTime, float startVolume = 1f, float finalVolume = 0f, bool resetVolumeAfterFade = false, Action onFinishedFading = null)
        {
            ValidateParams(fadeOutTime, startVolume, finalVolume, () => startVolume < finalVolume);

            float volumeIncrement = (startVolume - finalVolume) / fadeOutTime;

            while (audioSource.volume > finalVolume)
            {
                audioSource.volume -= volumeIncrement * Time.deltaTime;
                yield return null;
            }

            audioSource.Stop();
            if (resetVolumeAfterFade)
                audioSource.volume = startVolume;
            onFinishedFading?.Invoke();
        }

        /// <summary>
        /// Fades in the audio of the <paramref name="audioSource"/> over a specified duration.
        /// </summary>
        /// <param name="audioSource">The audio source to fade in</param>
        /// <param name="fadeInTime">The duration over which the fade in should occur</param>
        /// <param name="startVolume">The starting volume level of the audio (between 0 and 1)</param>
        /// <param name="finalVolume">The final volume level of the audio (between 0 and 1)</param>
        /// <param name="onFinishedFading">Action to invoke when the fade in is finished</param>
        /// <returns>An <see cref="IEnumerator"/> for the fade in coroutine execution</returns>
        public static IEnumerator FadeIn(this AudioSource audioSource, float fadeInTime, float startVolume = 0f, float finalVolume = 1f, Action onFinishedFading = null)
        {
            ValidateParams(fadeInTime, startVolume, finalVolume, () => finalVolume < startVolume);

            float volumeIncrement = (finalVolume - startVolume) / fadeInTime;

            if (!audioSource.isPlaying)
                audioSource.Play();

            while (audioSource.volume < finalVolume)
            {
                audioSource.volume += volumeIncrement * Time.deltaTime;
                yield return null;
            }

            audioSource.volume = finalVolume;
            onFinishedFading?.Invoke();
        }

        /// <summary>
        /// Cross fade the audio of the <paramref name="audioSourceOut"/> to <paramref name="audioSourceIn"/> over a specific duration.
        /// </summary>
        /// <param name="audioSourceOut">The audio source to fade out</param>
        /// <param name="audioSourceIn">The audio source to fade in</param>
        /// <param name="crossFadeTime">The duration over which the cross fade should occur</param>
        /// <param name="startVolume">The starting volume level of the audio to fade out (between 0 and 1)</param>
        /// <param name="finalVolume">The final volume level of the audio to fade in (between 0 and 1)</param>
        /// <param name="onFinishedCrossFading">Action to invoke when the cross fade is finished</param>
        /// <returns>An <see cref="IEnumerator"/> for the cross fade coroutine execution</returns>
        public static IEnumerator CrossFade(this AudioSource audioSourceOut, AudioSource audioSourceIn, float crossFadeTime, float startVolume = 1f, float finalVolume = 1f, Action onFinishedCrossFading = null)
        {
            ValidateParams(crossFadeTime, startVolume, finalVolume);

            audioSourceOut.volume = startVolume;
            audioSourceIn.volume = 0f;

            float volumeIncrementOut = startVolume / crossFadeTime;
            float volumeIncrementIn = finalVolume / crossFadeTime;

            if (!audioSourceIn.isPlaying)
                audioSourceIn.Play();

            while (audioSourceOut.volume > 0f)
            {
                audioSourceOut.volume -= volumeIncrementOut * Time.deltaTime;
                audioSourceIn.volume += volumeIncrementIn * Time.deltaTime;
                yield return null;
            }

            audioSourceOut.Stop();
            audioSourceOut.volume = 0f;
            audioSourceIn.volume = finalVolume;
            onFinishedCrossFading?.Invoke();
        }

        /// <summary>
        /// Validate the fade/crossFade audio source parameters.
        /// </summary>
        /// <param name="time">Duration of the fade/crossFade</param>
        /// <param name="startVolume">The starting volume level of the audio source</param>
        /// <param name="finalVolume">The final volume level of the audio</param>
        /// <param name="fadeValuesCheck">Func used for extra validation</param>
        private static void ValidateParams(float time, float startVolume, float finalVolume, Func<bool> fadeValuesCheck = null)
        {
            if (time <= 0)
                throw new ArgumentException("Time should be a positive value higher than zero");

            if (finalVolume < 0f || finalVolume > 1f)
                throw new ArgumentOutOfRangeException(nameof(finalVolume), "Value was out of range [0...1]");

            if (startVolume < 0f || startVolume > 1f)
                throw new ArgumentOutOfRangeException(nameof(startVolume), "Value was out of range [0...1]");

            if (fadeValuesCheck != null)
            {
                if (fadeValuesCheck.Invoke())
                {
                    throw new ArgumentException("In case of Fade out: Start volume should be higher than final volume.\nIn case of Fade in: Start volume should be lower than final volume.");
                }
            }
        }
    }
}