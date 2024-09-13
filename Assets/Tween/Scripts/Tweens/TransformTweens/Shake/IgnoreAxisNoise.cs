using System;

namespace Tween
{
	[Flags]
	public enum IgnoreAxisNoise
	{
		None = 0, // 0
		X = 1 << 0, // 1
		Y = 1 << 1, // 2
		Z = 1 << 2, // 4
		All = 1 << 3 // 8
	}
}