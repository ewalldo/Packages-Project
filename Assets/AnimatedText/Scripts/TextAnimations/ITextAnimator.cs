using UnityEngine;

namespace AnimatedText
{
	public interface ITextAnimator
	{
		public Matrix4x4 GenerateTranformMatrix(int charIndex);
	}
}