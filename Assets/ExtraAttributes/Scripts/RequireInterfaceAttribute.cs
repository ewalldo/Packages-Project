using System;
using UnityEngine;

namespace ExtraAttributes
{
	/// <summary>
	/// Attribute to restrict the object references to items that implements a specific interface
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class RequireInterfaceAttribute : PropertyAttribute
	{
		public readonly Type InterfaceType;

		/// <summary>
		/// Attribute to restrict the object references to items that implements a specific interface
		/// </summary>
		/// <param name="interfaceType">The interface that the object should implement</param>
		public RequireInterfaceAttribute(Type interfaceType)
        {
			Debug.Assert(interfaceType.IsInterface, $"{nameof(interfaceType)} needs to be an interface!");
			InterfaceType = interfaceType;
		}
	}
}