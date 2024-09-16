using UnityEngine;

namespace IndicatorSystem
{
	[System.Serializable]
	public class TextOffset
	{
        public float Left;
        public float Right;
        public float Top;
        public float Bottom;

        public TextOffset()
        {
            Left = 0;
            Right = 0;
            Top = 0;
            Bottom = 0;
        }

        public TextOffset(float left, float right, float top, float bottom)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }
    }
}