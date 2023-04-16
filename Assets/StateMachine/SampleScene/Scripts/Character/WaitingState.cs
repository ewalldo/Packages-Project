using UnityEngine;

namespace StateMachinePattern
{
	public class WaitingState: IState
	{
		private Character character;
		private Animator characterAnimator;
		private TrafficLight trafficLight;

		private bool isWaiting;

		public WaitingState(TrafficLight trafficLight, Character character, Animator characterAnimator)
		{
			this.trafficLight = trafficLight;
			this.character = character;
			this.characterAnimator = characterAnimator;

			trafficLight.OnStateChanged += TrafficLight_OnStateChanged;
		}

		public void OnEnter()
		{
			isWaiting = true;
			characterAnimator.SetBool("IsWalking", false);
		}

		public void OnExit()
		{
			isWaiting = false;
		}

		public void OnUpdate()
		{
			//
		}

		public void OnFixedUpdate()
		{
			//
		}

		private void TrafficLight_OnStateChanged(IState newState)
		{
			if (!isWaiting)
				return;

			if (newState is GreenLightState)
			{
				character.WalkingState.SetToFinalDestination();
				character.ChangeState(character.WalkingState);
			}
		}

		public void CleanUp()
		{
			trafficLight.OnStateChanged -= TrafficLight_OnStateChanged;
		}
	}
}
