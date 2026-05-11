using UnityEngine;

namespace AnimatedText
{
	public interface ITextAnimator
	{
		public Matrix4x4 GenerateTransformMatrix(int charIndex);
	}
}