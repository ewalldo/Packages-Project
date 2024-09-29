using System;

namespace StateMachinePattern
{
	public class StateMachine
	{
        /// <summary>
        /// The current state of the state machine
        /// </summary>
        public IState CurrentState { get; private set; }

        /// <summary>
        /// The previous state of the state machine
        /// </summary>
        public IState PreviousState { get; private set; }

        private bool inTransition;

        /// <summary>
        /// Invoked when the state machine changes to a new state
        /// </summary>
        /// <param name="curState">IState: the current state that it has changed to</param>
        public event Action<IState> OnStateChanged;

        public virtual void Update()
        {
            if (CurrentState != null && !inTransition)
                CurrentState.OnUpdate();
        }

        public virtual void FixedUpdate()
        {
            if (CurrentState != null && !inTransition)
                CurrentState.OnFixedUpdate();
        }

        /// <summary>
        /// Change the state machine to a new state
        /// </summary>
        /// <param name="newState">The new state to change into</param>
        public void ChangeState(IState newState)
        {
            if (CurrentState == newState || inTransition)
                return;

            ChangeStateRoutine(newState);
        }

        /// <summary>
        /// Revert to the previous state
        /// </summary>
        public void RevertState()
        {
            if (PreviousState != null)
                ChangeState(PreviousState);
        }

        /// <summary>
        /// Execute the routine to change into a new state
        /// </summary>
        /// <param name="newState"></param>
        private void ChangeStateRoutine(IState newState)
        {
            inTransition = true;

            if (CurrentState != null)
                CurrentState.OnExit();

            if (CurrentState != null)
                PreviousState = CurrentState;

            CurrentState = newState;
            OnStateChanged?.Invoke(CurrentState);

            if (CurrentState != null)
                CurrentState.OnEnter();

            inTransition = false;
        }
    }
}