using UnityEngine;

namespace AnimatedText
{
	public class TextShakeAnimation : ITextAnimator
	{
        public float Radius { get; private set; }

        public TextShakeAnimation(float radius)
        {
            Radius = radius;
        }

        public Matrix4x4 GenerateTranformMatrix(int charIndex)
        {
            Vector3 shakeOffset = UnityEngine.Random.insideUnitSphere * Radius;
            shakeOffset.z = 0f;
            Matrix4x4 matrix = Matrix4x4.TRS(shakeOffset, Quaternion.identity, Vector3.one);

            return matrix;
        }
    }
}