using UnityEngine;

namespace AnimatedText
{
	public class TextRotateAnimation : ITextAnimator
	{
        public float Speed { get; private set; }
        public float RotationValue { get; private set; }

        public TextRotateAnimation(float speed)
        {
            Speed = speed;
            RotationValue = 0f;
        }

        private void IncrementRotationValue(float amount)
        {
            RotationValue += amount;
            if (RotationValue > 360f)
                RotationValue -= 360f;
        }

        public Matrix4x4 GenerateTranformMatrix(int charIndex)
        {
            IncrementRotationValue(Time.deltaTime * Speed);
            Matrix4x4 matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.Euler(0f, 0f, RotationValue), Vector3.one);

            return matrix;
        }
    }
}