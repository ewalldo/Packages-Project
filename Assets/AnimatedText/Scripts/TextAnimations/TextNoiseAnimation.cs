using UnityEngine;

namespace AnimatedText
{
	public class TextNoiseAnimation : ITextAnimator
	{
        public float Speed {  get; private set; }
        public float RadiusX { get; private set; }
        public float RadiusY { get; private set; }

        public const string START_ANIMATION_TAG = "noise=";

        public const string END_ANIMATION_TAG = "/noise";

        public TextNoiseAnimation(float speed, float radiusX, float radiusY)
        {
            Speed = speed;
            RadiusX = radiusX;
            RadiusY = radiusY;
        }

        public Matrix4x4 GenerateTransformMatrix(int charIndex)
        {
            float offSetX = (Mathf.PerlinNoise(Time.time * Speed, charIndex * 1.5f) - 0.5f) * 2f * RadiusX;
            float offSetY = (Mathf.PerlinNoise(charIndex * 1.5f, Time.time * Speed) - 0.5f) * 2f * RadiusY;

            return Matrix4x4.TRS(new Vector3(offSetX, offSetY, 0f), Quaternion.identity, Vector3.one);
        }
    }
}