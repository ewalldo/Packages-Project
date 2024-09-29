using System;
using UnityEngine;

namespace Extensions
{
	public static class RendererExtensions
	{
		/// <summary>
		/// Checks if a Renderer is visible from a specified camera
		/// </summary>
		/// <param name="renderer">The renderer to check</param>
		/// <param name="camera">The camera to check the visibility from</param>
		/// <returns>True is visible, false otherwise</returns>
		public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
		{
			if (camera == null)
				throw new ArgumentNullException(nameof(camera), "Camera can't be null");

			Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
			return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
		}
	}
}