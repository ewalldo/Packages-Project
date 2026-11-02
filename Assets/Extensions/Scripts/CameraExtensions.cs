using System;
using UnityEngine;

namespace Extensions
{
    public static class CameraExtensions
    {
        /// <summary>
        /// Adds a specific layer to the camera's culling mask, enabling rendering of that layer
        /// </summary>
        /// <param name="camera">The camera whose culling mask will be modified</param>
        /// <param name="layer">The layer index to add</param>
        public static void AddLayerToCullingMask(this Camera camera, int layer)
        {
            if (layer < 0 || layer > 31)
                throw new ArgumentOutOfRangeException(nameof(layer), "Layer must be between 0 and 31.");

            camera.cullingMask |= (1 << layer);
        }

        /// <summary>
        /// Returns all GameObjects hit by a ray cast from the camera through the given screen position, sorted by distance from the camera (nearest first)
        /// </summary>
        /// <param name="camera">The camera to cast from</param>
        /// <param name="screenPosition">The screen-space position (e.g. mouse position)</param>
        /// <param name="maxDistance">The maximum distance to cast the ray</param>
        /// <param name="layerMask">The layer mask to use for the raycast</param>
        /// <returns>An array of GameObjects hit by the ray</returns>
        public static GameObject[] GetAllGameObjectsAtScreenPosition(this Camera camera, Vector2 screenPosition, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers)
        {
            Ray ray = camera.ScreenPointToRay(screenPosition);
            RaycastHit[] hits = Physics.RaycastAll(ray, maxDistance, layerMask);

            System.Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance)); // Sort hits by distance from the camera

            GameObject[] hitObjects = new GameObject[hits.Length];
            for (int i = 0; i < hits.Length; i++)
            {
                hitObjects[i] = hits[i].collider.gameObject;
            }

            return hitObjects;
        }

        /// <summary>
        /// Returns the first GameObject hit by a ray cast from the camera through the given screen position
        /// </summary>
        /// <param name="camera">The camera to cast from</param>
        /// <param name="screenPosition">The screen-space position (e.g. mouse position)</param>
        /// <param name="maxDistance">The maximum distance to cast the ray</param>
        /// <param name="layerMask">The layer mask to use for the raycast</param>
        /// <returns>The first GameObject hit by the ray, or null if no object was hit</returns>
        public static GameObject GetGameObjectAtScreenPosition(this Camera camera, Vector2 screenPosition, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers)
        {
            Ray ray = camera.ScreenPointToRay(screenPosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance, layerMask))
            {
                return hitInfo.collider.gameObject;
            }

            return null;
        }

        /// <summary>
        /// Returns the world-space bounds of the camera's orthographic view at a given Z depth. Only valid for orthographic cameras.
        /// </summary>
        /// <param name="camera">The orthographic camera</param>
        /// <param name="depth">The world-space Z depth at which to calculate the bounds</param>
        /// <returns>The world-space bounds of the orthographic view</returns>
        public static Bounds GetOrthographicBounds(this Camera camera, float depth = 0f)
        {
            if (!camera.orthographic)
                throw new InvalidOperationException("Camera must be orthographic to calculate orthographic bounds.");

            float height = camera.orthographicSize * 2f;
            float width = height * camera.aspect;

            return new Bounds(
                new Vector3(camera.transform.position.x, camera.transform.position.y, depth),
                new Vector3(width, height, 0f));
        }

        /// <summary>
        /// Calculates the screen-space bounding box of a Renderer as seen by this camera
        /// </summary>
        /// <param name="camera">The camera</param>
        /// <param name="renderer">The renderer to get the bounds from</param>
        /// <returns>The screen-space bounding box of the renderer</returns>
        public static Rect GetScreenSpaceBoundsFromRenderer(this Camera camera, Renderer renderer)
        {
            if (renderer == null)
                throw new ArgumentNullException(nameof(renderer), "Renderer can't be null");

            Bounds bounds = renderer.bounds;

            Vector3[] corners =
            {
                bounds.min,
                bounds.max,
                new(bounds.min.x, bounds.min.y, bounds.max.z),
                new(bounds.min.x, bounds.max.y, bounds.min.z),
                new(bounds.max.x, bounds.min.y, bounds.min.z),
                new(bounds.min.x, bounds.max.y, bounds.max.z),
                new(bounds.max.x, bounds.min.y, bounds.max.z),
                new(bounds.max.x, bounds.max.y, bounds.min.z)
            };

            Vector3 screenMin = new(float.MaxValue, float.MaxValue, 0f);
            Vector3 screenMax = new(float.MinValue, float.MinValue, 0f);

            foreach (Vector3 corner in corners)
            {
                Vector3 screenPoint = camera.WorldToScreenPoint(corner);

                if (screenPoint.z < 0f) continue; // Behind the camera

                screenMin.x = Mathf.Min(screenMin.x, screenPoint.x);
                screenMin.y = Mathf.Min(screenMin.y, screenPoint.y);
                screenMax.x = Mathf.Max(screenMax.x, screenPoint.x);
                screenMax.y = Mathf.Max(screenMax.y, screenPoint.y);
            }

            return new Rect(screenMin.x, screenMin.y,
                screenMax.x - screenMin.x,
                screenMax.y - screenMin.y);
        }

        /// <summary>
        /// Calculates the world-space size (width and height) of the camera's view at a given distance. Works for both orthographic and perspective cameras.
        /// </summary>
        /// <param name="camera">The camera to calculate the view size for</param>
        /// <param name="distance">Distance from the camera at which to calculate the size</param>
        /// <returns>A Vector2 where X is the width and Y is the height in world units</returns>
        public static Vector2 GetViewSizeAtDistance(this Camera camera, float distance)
        {
            if (camera.orthographic)
            {
                float height = camera.orthographicSize * 2f;
                float width = height * camera.aspect;
                return new Vector2(width, height);
            }
            else
            {
                float frustumHeight = 2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
                float frustumWidth = frustumHeight * camera.aspect;
                return new Vector2(frustumWidth, frustumHeight);
            }
        }

        /// <summary>
        /// Checks whether a specific layer is included in the camera's culling mask
        /// </summary>
        /// <param name="camera">The camera to check</param>
        /// <param name="layer">The layer index to check</param>
        /// <returns>True if the layer is included in the culling mask, false otherwise</returns>
        public static bool IsLayerRenderedByCamera(this Camera camera, int layer)
        {
            if (layer < 0 || layer > 31)
                throw new ArgumentOutOfRangeException(nameof(layer), "Layer must be between 0 and 31.");

            return (camera.cullingMask & (1 << layer)) != 0;
        }

        /// <summary>
        /// Determines whether a world-space point is visible within the camera's view frustum
        /// </summary>
        /// <param name="camera">The camera to check against</param>
        /// <param name="worldPosition">The world position to test</param>
        /// <returns>True if the point is within the camera's view frustum, false otherwise</returns>
        public static bool IsPointVisibleFromCamera(this Camera camera, Vector3 worldPosition)
        {
            Vector3 viewportPoint = camera.WorldToViewportPoint(worldPosition);
            return viewportPoint.x is >= 0f and <= 1f &&
                viewportPoint.y is >= 0f and <= 1f &&
                viewportPoint.z > 0;
        }

        /// <summary>
        /// Checks if a specific Renderer is visible from the camera
        /// </summary>
        /// <param name="camera">The camera to check against</param>
        /// <param name="renderer">The renderer whose bounds will be tested</param>
        /// <returns>True if visible, false otherwise</returns>
        public static bool IsRendererVisibleFromCamera(this Camera camera, Renderer renderer)
        {
            if (renderer == null)
                throw new ArgumentNullException(nameof(renderer), "Renderer can't be null");

            return renderer.IsVisibleFrom(camera);
        }

        /// <summary>
        /// Checks whether the given screen-space position is currently hovering over a UI element.
        /// Requires an EventSystem to be present in the scene.
        /// </summary>
        /// <param name="camera">The camera to check against</param>
        /// <param name="screenPosition">The screen-space position to check</param>
        /// <returns>True if the position is over a UI element, false otherwise</returns>
        public static bool IsScreenPositionOverUI(this Camera camera, Vector2 screenPosition)
        {
            if (UnityEngine.EventSystems.EventSystem.current == null)
                throw new InvalidOperationException("An EventSystem is required to use IsScreenPositionOverUI.");

            return UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
        }

        /// <summary>
        /// Removes a specific layer from the camera's culling mask, preventing rendering of that layer
        /// </summary>
        /// <param name="camera">The camera whose culling mask will be modified</param>
        /// <param name="layer">The layer index to remove</param>
        public static void RemoveLayerFromCullingMask(this Camera camera, int layer)
        {
            if (layer < 0 || layer > 31)
                throw new ArgumentOutOfRangeException(nameof(layer), "Layer must be between 0 and 31.");

            camera.cullingMask &= ~(1 << layer);
        }

        /// <summary>
        /// Converts a screen-space point to a world-space point at the specified distance from the camera.
        /// Useful for placing objects at a fixed depth relative to the camera.
        /// </summary>
        /// <param name="camera">The camera to use for conversion</param>
        /// <param name="screenPosition">The screen-space point (pixels)</param>
        /// <param name="distance">The distance from the camera to the desired world units</param>
        /// <returns>The world-space position at the specified distance</returns>
        public static Vector3 ScreenPointToWorldPositionAtDistance(this Camera camera, Vector2 screenPosition, float distance)
        {
            Vector3 screenPositionWithDistance = new Vector3(screenPosition.x, screenPosition.y, distance);
            return camera.ScreenToWorldPoint(screenPositionWithDistance);
        }

        /// <summary>
        /// Returns the world-space position of a screen-space point on a flat horizontal (XZ) plane at the given world-space Y height
        /// </summary>
        /// <param name="camera">The camera to cast from</param>
        /// <param name="screenPosition">The screen-space position (e.g. mouse position)</param>
        /// <param name="worldPosition">The resulting world-space position on the plane</param>
        /// <param name="yHeight">The world-space Y height of the horizontal plane</param>
        /// <returns>True if the ray intersects the plane, false if they are parallel</returns>
        public static bool ScreenPointToWorldPositionOnHorizontalPlane(this Camera camera, Vector2 screenPosition, out Vector3 worldPosition, float yHeight = 0f)
        {
            Plane horizontalPlane = new Plane(Vector3.up, new Vector3(0, yHeight, 0));
            return camera.ScreenPointToWorldPositionOnPlane(screenPosition, horizontalPlane, out worldPosition);
        }

        /// <summary>
        /// Returns the world-space position of a screen-space point projected onto a world-space plane.
        /// Useful for top-down or isometric applications where you want the world position of a mouse click.
        /// </summary>
        /// <param name="camera">The camera to cast from</param>
        /// <param name="screenPosition">The screen-space position (e.g. mouse position)</param>
        /// <param name="plane">The world-space plane to project onto</param>
        /// <param name="worldPosition">The resulting world-space position on the plane</param>
        /// <returns>True if the ray intersects the plane, false if they are parallel</returns>
        public static bool ScreenPointToWorldPositionOnPlane(this Camera camera, Vector2 screenPosition, Plane plane, out Vector3 worldPosition)
        {
            Ray ray = camera.ScreenPointToRay(screenPosition);

            if (plane.Raycast(ray, out float distance))
            {
                worldPosition = ray.GetPoint(distance);
                return true;
            }

            worldPosition = default;
            return false;
        }

        /// <summary>
        /// Casts a ray from the camera through the given screen-space position
        /// </summary>
        /// <param name="camera">The camera to cast from</param>
        /// <param name="screenPosition">The screen-space position to cast through</param>
        /// <param name="hitInfo">Information about the raycast hit</param>
        /// <param name="maxDistance">The maximum distance the ray should travel</param>
        /// <param name="layerMask">A layer mask to filter which objects can be hit</param>
        /// <returns>True if the ray hit something, false otherwise</returns>
        public static bool ScreenPointToRaycastHit(this Camera camera, Vector2 screenPosition, out RaycastHit hitInfo, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers)
        {
            Ray ray = camera.ScreenPointToRay(screenPosition);
            return Physics.Raycast(ray, out hitInfo, maxDistance, layerMask);
        }

        /// <summary>
        /// Attempts to retrieve a component of type T from the first object hit by a ray cast through the given screen-space position
        /// </summary>
        /// <typeparam name="T">The type of component to check</typeparam>
        /// <param name="camera">The camera to cast from</param>
        /// <param name="screenPosition">The screen-space position (e.g. mouse position)</param>
        /// <param name="component">The resulting component, or null if none was found</param>
        /// <param name="maxDistance">The maximum distance to cast the ray</param>
        /// <param name="layerMask">The layer mask to use for the raycast</param>
        /// <returns>True if the component was found, false otherwise</returns>
        public static bool TryGetComponentAtScreenPosition<T>(this Camera camera, Vector2 screenPosition, out T component, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers) where T : Component
        {
            GameObject hitObject = camera.GetGameObjectAtScreenPosition(screenPosition, maxDistance, layerMask);

            if (hitObject != null && hitObject.TryGetComponent(out component))
                return true;

            component = default;
            return false;
        }
    }
}