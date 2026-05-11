namespace AnimatedText
{
	public static class TagsUtils
	{
        public const string SPEED_TAG = "speed=";
        public const string PAUSE_TAG = "pause=";
        public const string ACTION_TAG = "action=";

        //public const string WAVE_ANIMATION_START_TAG = "wave=";
        //public const string WAVE_ANIMATION_END_TAG = "/wave";
        //public const string SHAKE_ANIMATION_START_TAG = "shake=";
        //public const string SHAKE_ANIMATION_END_TAG = "/shake";
        //public const string ROTATE_ANIMATION_START_TAG = "rotate=";
        //public const string ROTATE_ANIMATION_END_TAG = "/rotate";

        public const string REPLACE_TAG = "replace=";

        public static readonly string[] CUSTOM_TAGS = { SPEED_TAG, PAUSE_TAG, ACTION_TAG,
            TextWaveAnimation.START_ANIMATION_TAG, TextWaveAnimation.END_ANIMATION_TAG,
            TextShakeAnimation.START_ANIMATION_TAG, TextShakeAnimation.END_ANIMATION_TAG,
            TextPulseAnimation.START_ANIMATION_TAG, TextPulseAnimation.END_ANIMATION_TAG,
            TextRotateAnimation.START_ANIMATION_TAG, TextRotateAnimation.END_ANIMATION_TAG,
            REPLACE_TAG};

        public static readonly string[] START_ANIMATION_TAGS = {
            TextWaveAnimation.START_ANIMATION_TAG,
            TextShakeAnimation.START_ANIMATION_TAG,
            TextPulseAnimation.START_ANIMATION_TAG,
            TextRotateAnimation.START_ANIMATION_TAG};

        public static readonly string[] END_ANIMATION_TAGS = {
            TextWaveAnimation.END_ANIMATION_TAG,
            TextShakeAnimation.END_ANIMATION_TAG,
            TextPulseAnimation.END_ANIMATION_TAG,
            TextRotateAnimation.END_ANIMATION_TAG};

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