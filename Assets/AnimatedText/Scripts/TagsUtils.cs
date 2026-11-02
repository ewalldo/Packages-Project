using System.Collections.Generic;

namespace AnimatedText
{
	public static class TagsUtils
	{
        public const string SPEED_TAG = "speed=";
        public const string PAUSE_TAG = "pause=";
        public const string ACTION_TAG = "action=";

        public const string REPLACE_TAG = "replace=";

        public static readonly HashSet<string> CUSTOM_TAGS = new HashSet<string>() {
            SPEED_TAG, PAUSE_TAG, ACTION_TAG,
            TextWaveAnimation.START_ANIMATION_TAG, TextWaveAnimation.END_ANIMATION_TAG,
            TextShakeAnimation.START_ANIMATION_TAG, TextShakeAnimation.END_ANIMATION_TAG,
            TextPulseAnimation.START_ANIMATION_TAG, TextPulseAnimation.END_ANIMATION_TAG,
            TextRotateAnimation.START_ANIMATION_TAG, TextRotateAnimation.END_ANIMATION_TAG,
            TextBounceAnimation.START_ANIMATION_TAG, TextBounceAnimation.END_ANIMATION_TAG,
            TextNoiseAnimation.START_ANIMATION_TAG, TextNoiseAnimation.END_ANIMATION_TAG,
            REPLACE_TAG};

        public static readonly HashSet<string> START_ANIMATION_TAGS = new HashSet<string>() {
            TextWaveAnimation.START_ANIMATION_TAG,
            TextShakeAnimation.START_ANIMATION_TAG,
            TextPulseAnimation.START_ANIMATION_TAG,
            TextRotateAnimation.START_ANIMATION_TAG,
            TextBounceAnimation.START_ANIMATION_TAG,
            TextNoiseAnimation.START_ANIMATION_TAG};

        public static readonly HashSet<string> END_ANIMATION_TAGS = new HashSet<string>() {
            TextWaveAnimation.END_ANIMATION_TAG,
            TextShakeAnimation.END_ANIMATION_TAG,
            TextPulseAnimation.END_ANIMATION_TAG,
            TextRotateAnimation.END_ANIMATION_TAG,
            TextBounceAnimation.END_ANIMATION_TAG,
            TextNoiseAnimation.END_ANIMATION_TAG};

        public static bool IsCustomTag(string possibleCustomTag)
        {
            foreach (string customTag in CUSTOM_TAGS)
            {
                if (possibleCustomTag.StartsWith(customTag))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsReplaceTag(string possibleReplaceTag)
        {
            return possibleReplaceTag.StartsWith(REPLACE_TAG);
        }

        public static bool IsStartAnimationTag(string possibleStartAnimationTag)
        {
            foreach (string startAnimationTag in START_ANIMATION_TAGS)
            {
                if (possibleStartAnimationTag.StartsWith(startAnimationTag))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsEndAnimationTag(string possibleEndAnimationTag)
        {
            foreach (string endAnimationTag in END_ANIMATION_TAGS)
            {
                if (possibleEndAnimationTag.StartsWith(endAnimationTag))
                {
                    return true;
                }
            }

            return false;
        }
    }
}