using UnityEngine;

namespace Extensions
{
    public static class RigidBodyExtensions
    {
        /// <summary>
        /// Applies force to the Rigidbody directed toward the given world-space target position
        /// </summary>
        /// <param name="rigidbody">The Rigidbody to apply force to</param>
        /// <param name="targetPosition">The world-space position to apply force towards</param>
        /// <param name="forceMagnitude">The magnitude of the force to apply</param>
        /// <param name="forceMode">The ForceMode to use when applying the force</param>
        public static void AddForceTowards(this Rigidbody rigidbody, Vector3 targetPosition, float forceMagnitude, ForceMode forceMode = ForceMode.Force)
        {
            Vector3 direction = (targetPosition - rigidbody.position).normalized;
            rigidbody.AddForce(direction * forceMagnitude, forceMode);
        }

        /// <summary>
        /// Applies a force to the Rigidbody that will bring it to a desired target velocity within a single physics update
        /// </summary>
        /// <param name="rigidbody">The Rigidbody to apply force to</param>
        /// <param name="targetVelocity">The desired target velocity</param>
        /// <param name="forceMode">The ForceMode to use when applying the force</param>
        public static void ApplyForceToReachVelocity(this Rigidbody rigidbody, Vector3 targetVelocity, ForceMode forceMode = ForceMode.Force)
        {
            Vector3 velocityDelta = targetVelocity - rigidbody.linearVelocity;
            Vector3 requiredForce = velocityDelta * rigidbody.mass / Time.fixedDeltaTime;
            rigidbody.AddForce(requiredForce, forceMode);
        }

        /// <summary>
        /// Changes the Rigidbody's movement direction while preserving its current speed. Has no effect if the Rigidbody is not moving
        /// </summary>
        /// <param name="rigidbody">The RigidBody to change the direction for</param>
        /// <param name="newDirection">The new direction to move in</param>
        public static void ChangeDirection(this Rigidbody rigidbody, Vector3 newDirection)
        {
            float speed = rigidbody.GetSpeed();
            rigidbody.linearVelocity = newDirection.normalized * speed;
        }

        /// <summary>
        /// Clamps the Rigidbody's speed to the given maximum value without changing its direction
        /// </summary>
        /// <param name="rigidbody">The RigidBody to clamp the speed for</param>
        /// <param name="maxSpeed">The maximum speed to clamp to</param>
        public static void ClampSpeed(this Rigidbody rigidbody, float maxSpeed)
        {
            if (rigidbody.GetSpeed() > maxSpeed)
                rigidbody.SetSpeed(maxSpeed);
        }

        /// <summary>
        /// Returns the current speed (scalar magnitude) of the Rigidbody
        /// </summary>
        /// <param name="rigidbody">The RigidBody to get the speed from</param>
        /// <returns>The magnitude of the Rigidbody's current velocity</returns>
        public static float GetSpeed(this Rigidbody rigidbody) => rigidbody.linearVelocity.magnitude;

        /// <summary>
        /// Checks whether the Rigidbody is currently grounded by performing a SphereCast downward
        /// </summary>
        /// <param name="rigidbody">The Rigidbody to check</param>
        /// <param name="checkDistance">The distance below the Rigidbody to check for ground</param>
        /// <param name="groundLayer">The layer mask representing ground objects</param>
        /// <param name="sphereRadius">The radius of the sphere to cast</param>
        /// <returns>True if the Rigidbody is grounded, false otherwise</returns>
        public static bool IsGrounded(this Rigidbody rigidbody, float checkDistance = 0.1f, int groundLayer = Physics.DefaultRaycastLayers, float sphereRadius = 0.25f)
        {
            return Physics.SphereCast(rigidbody.position, sphereRadius, Vector3.down, out RaycastHit _, checkDistance, groundLayer);
        }

        /// <summary>
        /// Immediately stops the Rigidbody by zeroing out both its linear and angular velocity
        /// </summary>
        /// <param name="rigidbody">The RigidBody to reset</param>
		public static void ResetVelocity(this Rigidbody rigidbody)
        {
            rigidbody.linearVelocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }

        /// <summary>
        /// Toggles the Rigidbody's isKinematic property and optionally resets its velocity when enabled
        /// </summary>
        /// <param name="rigidbody">The Rigidbody to modify</param>
        /// <param name="isKinematic">Whether the Rigidbody should be kinematic</param>
        /// <param name="resetVelocity">Whether to reset the Rigidbody's velocity when enabling kinematic</param>
        public static void SetKinematic(this Rigidbody rigidbody, bool isKinematic, bool resetVelocity = true)
        {
            if (isKinematic && resetVelocity)
                rigidbody.ResetVelocity();

            rigidbody.isKinematic = isKinematic;
        }

        /// <summary>
        /// Sets the speed of the Rigidbody while preserving the current direction of movement
        /// </summary>
        /// <param name="rigidbody">The RigidBody to set the speed for</param>
        /// <param name="speed">The desired speed in units per second</param>
        public static void SetSpeed(this Rigidbody rigidbody, float speed)
        {
            Vector3 direction = rigidbody.linearVelocity.normalized;
            rigidbody.linearVelocity = direction * speed;
        }
    }
}