using System;
using UnityEngine;

namespace ExtraAttributes
{
	/// <summary>
	/// Attribute to wrap around a value when it goes out of a specific range (int and float only)
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class WrapAttribute : PropertyAttribute
	{
		public float MinValue { get; private set; }
		public float MaxValue { get; private set; }

		/// <summary>
		/// Attribute to wrap around a value when it goes out of a specific range (int and float only)
		/// </summary>
		/// <param name="min">The minimum value of the range</param>
		/// <param name="max">The maximum value of the range</param>
		public WrapAttribute(float min, float max)
        {
			MinValue = min;
			MaxValue = max;
		}

		/// <summary>
		/// Attribute to wrap around a value when it goes out of the [0...1] range (int and float only)
		/// </summary>
		public WrapAttribute()
			: this(0.0f, 1.0f) { }
	}
}