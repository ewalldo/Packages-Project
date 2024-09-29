using System;
using UnityEngine;

namespace GenericNamespace
{
	public class MovementWithMomentum
	{
		// TODO: Rewrite class

		private readonly float movementSpeed = 2.0f;
		private readonly float momentumDampening = 0.95f;
		private readonly Action<float> applyMovement;
		private readonly Action onAfterAnyMovementApplied;

		private float momentum;

        public MovementWithMomentum(float movementSpeed, float momemtumDampening, Action<float> applyMovement, Action onAfterAnyMovementApplied = null)
        {
			this.movementSpeed = movementSpeed;
			this.momentumDampening = momemtumDampening;
			this.applyMovement = applyMovement;
			this.onAfterAnyMovementApplied = onAfterAnyMovementApplied;
		}

		public void ResetMomemtum()
        {
			momentum = 0f;
		}

		public void ApplyMovement(float delta)
        {
			float movementAmount = delta * movementSpeed * Time.deltaTime;

			applyMovement?.Invoke(movementAmount);
			onAfterAnyMovementApplied?.Invoke();

			momentum = movementAmount;
		}

		public void ApplyMomentum()
        {
			if (Mathf.Abs(momentum) > 0.01f)
            {
				applyMovement?.Invoke(momentum);
				onAfterAnyMovementApplied?.Invoke();

				momentum *= momentumDampening;
			}
		}
	}
}