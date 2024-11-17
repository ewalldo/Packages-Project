using System;
using UnityEngine;

namespace ExtraAttributes
{
	/// <summary>
	/// Attribute used to make a value be restricted to a specific range (int and float only)
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class ClampAttribute : PropertyAttribute
	{
		public float MinValue { get; private set; }
		public float MaxValue { get; private set; }

		/// <summary>
		/// Attribute used to make a value be restricted to a specific range (int and float only)
		/// </summary>
		/// <param name="min">The minimum value of the range</param>
		/// <param name="max">The maximum value of the range</param>
		public ClampAttribute(float min, float max)
        {
			MinValue = min;
			MaxValue = max;
		}

		/// <summary>
		/// Attribute used to make a value be restricted to a [0...1] range (int and float only)
		/// </summary>
		public ClampAttribute()
			: this(0.0f, 1.0f) { }
	}
}