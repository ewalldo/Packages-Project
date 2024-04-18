using UnityEngine;

namespace ExtraAttributes
{
    /// <summary>
    /// Attribute to convert a string or int field into a Animator Parameter selection field (string and int only)
    /// </summary>
    public class AnimatorParamFieldAttribute : PropertyAttribute
    {
        public string AnimatorName { get; private set; }
        public AnimatorControllerParameterType? AnimatorParamType { get; private set; }

        /// <summary>
        /// Attribute to convert a string or int field into a Animator Parameter selection field (string and int only)
        /// </summary>
        /// <param name="animatorName">The animator containing the animator controller to get the parameters from</param>
        /// <param name="animatorParamType">Display only parameters of this specific type</param>
        public AnimatorParamFieldAttribute(string animatorName, AnimatorControllerParameterType animatorParamType)
        {
            AnimatorName = animatorName;
            AnimatorParamType = animatorParamType;
        }

        /// <summary>
        /// Attribute to convert a string or int field into a Animator Parameter selection field (string and int only)
        /// </summary>
        /// <param name="animatorName">The animator containing the animator controller to get the parameters from</param>
        public AnimatorParamFieldAttribute(string animatorName)
        {
            AnimatorName = animatorName;
            AnimatorParamType = null;
        }
    }
}
