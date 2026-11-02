using UnityEngine;

namespace AnimatedText
{
	public class TextRotateAnimation : ITextAnimator
	{
        public float Speed { get; private set; }

        public const string START_ANIMATION_TAG = "rotate=";

        public const string END_ANIMATION_TAG = "/rotate";

        public TextRotateAnimation(float speed)
        {
            Speed = speed;
        }

        public Matrix4x4 GenerateTransformMatrix(int charIndex)
        {
            float angle = Time.time * Speed % 360;
            Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, angle), Vector3.one);

            return matrix;
        }
    }
}