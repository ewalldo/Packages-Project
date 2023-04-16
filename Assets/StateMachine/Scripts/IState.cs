namespace StateMachinePattern
{
	public interface IState
	{
		/// <summary>
		/// Invoked when entering the state
		/// </summary>
		public void OnEnter();
		/// <summary>
		/// Invoked on the Update() function
		/// </summary>
		public void OnUpdate();
		/// <summary>
		/// Invoked on the FixedUpdate function
		/// </summary>
		public void OnFixedUpdate();
		/// <summary>
		/// Invoked when leaving the state
		/// </summary>
		public void OnExit();
	}
}