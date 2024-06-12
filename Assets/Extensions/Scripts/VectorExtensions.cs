using UnityEngine;

namespace Extensions
{
	public static class VectorExtensions
	{
        #region Vector2 Extensions

        /// <summary>
        /// Returns a new Vector2 with the specified components replaced.
        /// </summary>
        /// <param name="v">The original Vector2</param>
        /// <param name="x">Optional X component. If null, the original X component is used.</param>
        /// <param name="y">Optional Y component. If null, the original Y component is used.</param>
        /// <returns>A new Vector2 with the specified components replaced.</returns>
        public static Vector2 With(this Vector2 v, float? x = null, float? y = null)
        {
            return new Vector2(x ?? v.x, y ?? v.y);
        }

        /// <summary>
        /// Returns a new Vector2 with the X component replaced.
        /// </summary>
        /// <param name="v">The original Vector2</param>
        /// <param name="xValue">The new X component.</param>
        /// <returns>A new Vector2 with the X component replaced.</returns>
        public static Vector2 WithX(this Vector2 v, float xValue) => v.With(x: xValue);

        /// <summary>
        /// Returns a new Vector2 with the Y component replaced.
        /// </summary>
        /// <param name="v">The original Vector2</param>
        /// <param name="yValue">The new Y component.</param>
        /// <returns>A new Vector2 with the X component replaced.</returns>
        public static Vector2 WithY(this Vector2 v, float yValue) => v.With(y: yValue);

        #endregion

        #region Vector3 Extensions

        /// <summary>
        /// Returns a new Vector3 with the specified components replaced.
        /// </summary>
        /// <param name="v">The original Vector3</param>
        /// <param name="x">Optional X component. If null, the original X component is used.</param>
        /// <param name="y">Optional Y component. If null, the original Y component is used.</param>
        /// <param name="z">Optional Z component. If null, the original Z component is used.</param>
        /// <returns>A new Vector3 with the specified components replaced.</returns>
        public static Vector3 With(this Vector3 v, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x ?? v.x, y ?? v.y, z ?? v.z);
        }

        /// <summary>
        /// Returns a new Vector3 with the X component replaced.
        /// </summary>
        /// <param name="v">The original Vector3</param>
        /// <param name="xValue">The new X component.</param>
        /// <returns>A new Vector3 with the X component replaced.</returns>
        public static Vector3 WithX(this Vector3 v, float xValue) => v.With(x: xValue);

        /// <summary>
        /// Returns a new Vector3 with the Y component replaced.
        /// </summary>
        /// <param name="v">The original Vector3</param>
        /// <param name="yValue">The new Y component.</param>
        /// <returns>A new Vector3 with the Y component replaced.</returns>
        public static Vector3 WithY(this Vector3 v, float yValue) => v.With(y: yValue);

        /// <summary>
        /// Returns a new Vector3 with the Z component replaced.
        /// </summary>
        /// <param name="v">The original Vector3</param>
        /// <param name="zValue">The new Z component.</param>
        /// <returns>A new Vector3 with the Z component replaced.</returns>
        public static Vector3 WithZ(this Vector3 v, float zValue) => v.With(z: zValue);

        /// <summary>
        /// Returns a new Vector3 with the X and Y components replaced.
        /// </summary>
        /// <param name="v">The original Vector3</param>
        /// <param name="xValue">The new X component.</param>
        /// <param name="yValue">The new Y component.</param>
        /// <returns>A new Vector3 with the X and Y components replaced.</returns>
        public static Vector3 WithXY(this Vector3 v, float xValue, float yValue) => v.With(x: xValue, y: yValue);

        /// <summary>
        /// Returns a new Vector3 with the X and Z components replaced.
        /// </summary>
        /// <param name="v">The original Vector3</param>
        /// <param name="xValue">The new X component.</param>
        /// <param name="zValue">The new Z component.</param>
        /// <returns>A new Vector3 with the X and Z components replaced.</returns>
        public static Vector3 WithXZ(this Vector3 v, float xValue, float zValue) => v.With(x: xValue, z: zValue);

        /// <summary>
        /// Returns a new Vector3 with the Y and Z components replaced.
        /// </summary>
        /// <param name="v">The original Vector3</param>
        /// <param name="yValue">The new Y component.</param>
        /// <param name="zValue">The new Z component.</param>
        /// <returns>A new Vector3 with the X and Y components replaced.</returns>
        public static Vector3 WithYZ(this Vector3 v, float yValue, float zValue) => v.With(y: yValue, z: zValue);

        #endregion

        #region Vector4 Extensions

        /// <summary>
        /// Returns a new Vector4 with the specified components replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="x">Optional X component. If null, the original X component is used.</param>
        /// <param name="y">Optional Y component. If null, the original Y component is used.</param>
        /// <param name="z">Optional Z component. If null, the original Z component is used.</param>
        /// <param name="w">Optional W component. If null, the original W component is used.</param>
        /// <returns>A new Vector4 with the specified components replaced.</returns>
        public static Vector4 With(this Vector4 v, float? x = null, float? y = null, float? z = null, float? w = null)
        {
            return new Vector4(x ?? v.x, y ?? v.y, z ?? v.z, w ?? v.w);
        }

        /// <summary>
        /// Returns a new Vector4 with the X component replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="xValue">The new X component.</param>
        /// <returns>A new Vector4 with the X component replaced.</returns>
        public static Vector4 WithX(this Vector4 v, float xValue) => v.With(x: xValue);

        /// <summary>
        /// Returns a new Vector4 with the Y component replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="yValue">The new Y component.</param>
        /// <returns>A new Vector4 with the Y component replaced.</returns>
        public static Vector4 WithY(this Vector4 v, float yValue) => v.With(y: yValue);

        /// <summary>
        /// Returns a new Vector4 with the Z component replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="zValue">The new Z component.</param>
        /// <returns>A new Vector4 with the Z component replaced.</returns>
        public static Vector4 WithZ(this Vector4 v, float zValue) => v.With(z: zValue);

        /// <summary>
        /// Returns a new Vector4 with the W component replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="wValue">The new W component.</param>
        /// <returns>A new Vector4 with the W component replaced.</returns>
        public static Vector4 WithW(this Vector4 v, float wValue) => v.With(w: wValue);

        /// <summary>
        /// Returns a new Vector4 with the X and Y components replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="xValue">The new X component.</param>
        /// <param name="yValue">The new Y component.</param>
        /// <returns>A new Vector4 with the X and Y components replaced.</returns>
        public static Vector4 WithXY(this Vector4 v, float xValue, float yValue) => v.With(x: xValue, y: yValue);

        /// <summary>
        /// Returns a new Vector4 with the X and Z components replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="xValue">The new X component.</param>
        /// <param name="zValue">The new Z component.</param>
        /// <returns>A new Vector4 with the X and Z components replaced.</returns>
        public static Vector4 WithXZ(this Vector4 v, float xValue, float zValue) => v.With(x: xValue, z: zValue);

        /// <summary>
        /// Returns a new Vector4 with the X and W components replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="xValue">The new X component.</param>
        /// <param name="wValue">The new W component.</param>
        /// <returns>A new Vector4 with the X and W components replaced.</returns>
        public static Vector4 WithXW(this Vector4 v, float xValue, float wValue) => v.With(x: xValue, w: wValue);

        /// <summary>
        /// Returns a new Vector4 with the Y and Z components replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="yValue">The new Y component.</param>
        /// <param name="zValue">The new Z component.</param>
        /// <returns>A new Vector4 with the Y and Z components replaced.</returns>
        public static Vector4 WithYZ(this Vector4 v, float yValue, float zValue) => v.With(y: yValue, z: zValue);

        /// <summary>
        /// Returns a new Vector4 with the Y and W components replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="yValue">The new Y component.</param>
        /// <param name="wValue">The new W component.</param>
        /// <returns>A new Vector4 with the Y and W components replaced.</returns>
        public static Vector4 WithYW(this Vector4 v, float yValue, float wValue) => v.With(y: yValue, w: wValue);

        /// <summary>
        /// Returns a new Vector4 with the Z and W components replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="zValue">The new Z component.</param>
        /// <param name="wValue">The new W component.</param>
        /// <returns>A new Vector4 with the Z and W components replaced.</returns>
        public static Vector4 WithZW(this Vector4 v, float zValue, float wValue) => v.With(z: zValue, w: wValue);

        /// <summary>
        /// Returns a new Vector4 with the X, Y and Z components replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="xValue">The new X component.</param>
        /// <param name="yValue">The new Y component.</param>
        /// <param name="zValue">The new Z component.</param>
        /// <returns>A new Vector4 with the X, Y, and Z components replaced.</returns>
        public static Vector4 WithXYZ(this Vector4 v, float xValue, float yValue, float zValue) => v.With(x: xValue, y: yValue, z: zValue);

        /// <summary>
        /// Returns a new Vector4 with the X, Y and W components replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="xValue">The new X component.</param>
        /// <param name="yValue">The new Y component.</param>
        /// <param name="wValue">The new W component.</param>
        /// <returns>A new Vector4 with the X, Y, and W components replaced.</returns>
        public static Vector4 WithXYW(this Vector4 v, float xValue, float yValue, float wValue) => v.With(x: xValue, y: yValue, w: wValue);

        /// <summary>
        /// Returns a new Vector4 with the X, Z and W components replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="xValue">The new X component.</param>
        /// <param name="zValue">The new Z component.</param>
        /// <param name="wValue">The new W component.</param>
        /// <returns>A new Vector4 with the X, Z, and W components replaced.</returns>
        public static Vector4 WithXZW(this Vector4 v, float xValue, float zValue, float wValue) => v.With(x: xValue, z: zValue, w: wValue);

        /// <summary>
        /// Returns a new Vector4 with the Y, Z and W components replaced.
        /// </summary>
        /// <param name="v">The original Vector4</param>
        /// <param name="yValue">The new Y component.</param>
        /// <param name="zValue">The new Z component.</param>
        /// <param name="wValue">The new W component.</param>
        /// <returns>A new Vector4 with the Y, Z, and W components replaced.</returns>
        public static Vector4 WithYZW(this Vector4 v, float yValue, float zValue, float wValue) => v.With(y: yValue, z: zValue, w: wValue);

        #endregion
    }
}