using UnityEngine;

namespace StateMachinePattern
{
	public class Character: StateMachineMonoBehaviour
	{
		[SerializeField] private TrafficLight trafficLight;

		[SerializeField] private Vector3 firstDestination;
		[SerializeField] private Vector3 finalDestination;

		[SerializeField] private Animator characterAnimator;

		public WalkingState WalkingState { get; private set; }
		public WaitingState WaitingState { get; private set; }

		private void Start()
		{
			WalkingState = new WalkingState(firstDestination, finalDestination, 0.01f, this, trafficLight, characterAnimator);
			WaitingState = new WaitingState(trafficLight, this, characterAnimator);

			ChangeState(WalkingState);
		}

		private void OnDestroy()
		{
			WaitingState.CleanUp();
		}
	}
}
