namespace AnimatedText
{
	public static class TagsUtils
	{
        public static readonly string SPEED_TAG = "speed=";
        public static readonly string PAUSE_TAG = "pause=";
        public static readonly string ACTION_TAG = "action=";

        public static readonly string WAVE_ANIMATION_START_TAG = "wave=";
        public static readonly string WAVE_ANIMATION_END_TAG = "/wave";
        public static readonly string SHAKE_ANIMATION_START_TAG = "shake=";
        public static readonly string SHAKE_ANIMATION_END_TAG = "/shake";
        public static readonly string PULSE_ANIMATION_START_TAG = "pulse=";
        public static readonly string PULSE_ANIMATION_END_TAG = "/pulse";
        public static readonly string ROTATE_ANIMATION_START_TAG = "rotate=";
        public static readonly string ROTATE_ANIMATION_END_TAG = "/rotate";

        public static readonly string REPLACE_TAG = "replace=";

        public static readonly string[] CUSTOM_TAGS = { SPEED_TAG, PAUSE_TAG, ACTION_TAG,
            WAVE_ANIMATION_START_TAG, WAVE_ANIMATION_END_TAG, SHAKE_ANIMATION_START_TAG, SHAKE_ANIMATION_END_TAG,
            PULSE_ANIMATION_START_TAG, PULSE_ANIMATION_END_TAG, ROTATE_ANIMATION_START_TAG, ROTATE_ANIMATION_END_TAG,
            REPLACE_TAG};

        public static readonly string[] START_ANIMATION_TAGS = {
            WAVE_ANIMATION_START_TAG, SHAKE_ANIMATION_START_TAG,
            PULSE_ANIMATION_START_TAG, ROTATE_ANIMATION_START_TAG};

        public static readonly string[] END_ANIMATION_TAGS = {
            WAVE_ANIMATION_END_TAG, SHAKE_ANIMATION_END_TAG,
            PULSE_ANIMATION_END_TAG, ROTATE_ANIMATION_END_TAG};

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