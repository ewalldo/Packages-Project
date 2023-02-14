using UnityEngine;

namespace StateMachinePattern
{
	public class WalkingState: IState
	{
		private float distanceThreshold;
		private Vector3 firstDestination;
		private Vector3 finalDestination;
		private Character character;
		private TrafficLight trafficLight;

		private Vector3 currentDestination;
		private Transform characterTransform;
		private Animator characterAnimator;

		private float speed = 4f;

		private Vector3 originalPosition;

		public WalkingState(Vector3 firstDestination, Vector3 finalDestination, float distanceThreshold, Character character, TrafficLight trafficLight, Animator characterAnimator)
		{
			this.firstDestination = firstDestination;
			this.finalDestination = finalDestination;
			this.distanceThreshold = distanceThreshold;
			this.character = character;
			this.trafficLight = trafficLight;

			characterTransform = character.transform;
			this.characterAnimator = characterAnimator;

			currentDestination = firstDestination;
			originalPosition = characterTransform.position;
		}

		public void OnEnter()
		{
			characterAnimator.SetBool("IsWalking", true);
		}

		public void OnExit()
		{
			//
		}

		public void OnUpdate()
		{
			Vector3 direction = (currentDestination - characterTransform.position).normalized;

			characterTransform.position += speed * Time.deltaTime * direction;

			if (Vector3.Distance(characterTransform.position, finalDestination) <= distanceThreshold)
			{
				characterTransform.position = originalPosition;
				currentDestination = firstDestination;
				return;
			}

			if (Vector3.Distance(characterTransform.position, currentDestination) <= distanceThreshold)
			{
				if (trafficLight.CanCross)
				{
					currentDestination = finalDestination;
				}
				else
				{
					character.ChangeState(character.WaitingState);
				}
			}
		}

		public void OnFixedUpdate()
		{
			//
		}

		public void SetToFinalDestination()
		{
			currentDestination = finalDestination;
		}
	}
}
