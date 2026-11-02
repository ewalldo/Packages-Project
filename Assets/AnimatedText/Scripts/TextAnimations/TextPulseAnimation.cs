using UnityEngine;

namespace AnimatedText
{
    public class TextPulseAnimation : ITextAnimator
	{
        public float Speed { get; private set; }
        public float Variance { get; private set; }
        public float BaseValue { get; private set; }

        public const string START_ANIMATION_TAG = "pulse=";

        public const string END_ANIMATION_TAG = "/pulse";

        public TextPulseAnimation(float speed, float variance, float baseValue)
        {
            Speed = speed;
            Variance = variance;
            BaseValue = baseValue;
        }

        public Matrix4x4 GenerateTransformMatrix(int charIndex)
        {
            float pulseAmount = Mathf.Sin(Time.time * Speed) * Variance + BaseValue;
            Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.one * pulseAmount);

            return matrix;
        }
    }
}