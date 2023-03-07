using UnityEngine;

namespace AnimatedText
{
	public class TextWaveAnimation : ITextAnimator
	{
        public float Frequency { get; private set; }
        public float Amplitude { get; private set; }

        public TextWaveAnimation(float frequency, float amplitude)
        {
            Frequency = frequency;
            Amplitude = amplitude;
        }

        public Matrix4x4 GenerateTranformMatrix(int charIndex)
        {
            float waveYPosition = Mathf.Sin(Time.time * Frequency + charIndex) * Amplitude;
            Matrix4x4 matrix = Matrix4x4.TRS(new Vector3(0f, waveYPosition, 0f), Quaternion.identity, Vector3.one);

            return matrix;
        }
    }
}