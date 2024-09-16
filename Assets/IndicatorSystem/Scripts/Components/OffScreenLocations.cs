using System;

namespace IndicatorSystem
{
	[Flags]
	public enum OffScreenLocations
	{
		None = 0, // 0
		Top = 1 << 0, // 1
		Bottom = 1 << 1, // 2
		Left = 1 << 2, // 4
		Right = 1 << 3 // 8
	}
}