using UnityEngine;

namespace ExtraAttributes
{
	/// <summary>
	/// Attribute to mark a field as required, i.e. will display an error while the value is null
	/// </summary>
	public class RequiredFieldAttribute : PropertyAttribute
	{
		public Color RequiredColor { get; private set; }

		public RequiredFieldAttribute()
		{
			RequiredColor = Color.red;
		}
	}
}