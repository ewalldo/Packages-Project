using System;
using System.Linq;
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

		/// <summary>
		/// Return a gameObject itself if exists, null otherwise
		/// </summary>
		/// <typeparam name="T">The type of the object</typeparam>
		/// <param name="obj">The object being checked</param>
		/// <returns>The object itself if it exists and it is not destroyed, null otherwise</returns>
		public static T GetOrNull<T>(this T obj) where T : UnityEngine.Object
		{
			return obj ?? null;
		}

		/// <summary>
		/// Get the full hierarchical path, from the root until parent, for this specific GameObject
		/// </summary>
		/// <param name="gameObject">The GameObject to get the path from</param>
		/// <returns>String representation of the hierarchical path</returns>
		public static string GetPath(this GameObject gameObject)
		{
			return "/" + string.Join("/", gameObject.GetComponentsInParent<Transform>().Select((t) => t.name).Reverse().ToArray());
		}

		/// <summary>
		/// Get the full hierarchical path, from the root until gameObject, for this specific GameObject
		/// </summary>
		/// <param name="gameObject">The GameObject to get the path from</param>
		/// <returns>String representation of the full hierarchical path</returns>
		public static string GetFullPath(this GameObject gameObject)
		{
			return gameObject.GetPath() + "/" + gameObject.name;
		}
	}
}