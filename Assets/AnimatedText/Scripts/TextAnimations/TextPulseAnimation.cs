using UnityEngine;

namespace AnimatedText
{
	public class TextPulseAnimation : ITextAnimator
	{
        public float Speed { get; private set; }
        public float Variance { get; private set; }
        public float BaseValue { get; private set; }

        public TextPulseAnimation(float speed, float variance, float baseValue)
        {
            Speed = speed;
            Variance = variance;
            BaseValue = baseValue;
        }

        public Matrix4x4 GenerateTranformMatrix(int charIndex)
        {
            float pulseAmount = Mathf.Sin(Time.time * Speed) * Variance + BaseValue;
            Matrix4x4 matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, Vector3.one * pulseAmount);

            return matrix;
        }
    }
}