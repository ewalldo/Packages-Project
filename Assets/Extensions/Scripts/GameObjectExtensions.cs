using System;
using UnityEngine;

namespace Extensions
{
	public static class GameObjectExtensions
	{
		/// <summary>
		/// Try to get a component from a gameObject, if it doesn't exist, add to it and return it
		/// </summary>
		/// <typeparam name="T">The component to be added to get/add to the gameObject</typeparam>
		/// <param name="gameObject">The gameObject to check</param>
		/// <returns>The component in the gameObject</returns>
		public static T AddOrGetComponent<T>(this GameObject gameObject) where T : Component
        {
			if (gameObject == null)
				throw new ArgumentNullException(nameof(gameObject));

			T component = gameObject.GetComponent<T>();
			if (component == null)
			{
				component = gameObject.AddComponent<T>();
			}

			return component;
		}
	}
}