using UnityEngine;

namespace AnimatedText
{
	public class TextBounceAnimation : ITextAnimator
	{
		public float Speed {  get; private set; }
		public float Height { get; private set; }
		public bool OffsetEachCharacter { get; private set; }

        public const string START_ANIMATION_TAG = "bounce=";

        public const string END_ANIMATION_TAG = "/bounce";

        public TextBounceAnimation(float speed, float height, bool offsetEachCharacter)
        {
            Speed = speed;
            Height = height;
            OffsetEachCharacter = offsetEachCharacter;
        }

        public Matrix4x4 GenerateTransformMatrix(int charIndex)
        {
            float bounce = Mathf.Abs(Mathf.Sin(Time.time * Speed + (OffsetEachCharacter ? charIndex : 0))) * Height;
            return Matrix4x4.TRS(new Vector3(0f, bounce, 0f), Quaternion.identity, Vector3.one);
        }
    }
}