using System;
using UnityEngine;

namespace StateMachinePattern
{
	public abstract class StateMachine : MonoBehaviour
	{
        public IState CurrentState { get; private set; }
        public IState PreviousState { get; private set; }

        private bool inTransition;

        public Action<IState> OnStateChanged;

        protected virtual void Update()
        {
            if (CurrentState != null && !inTransition)
                CurrentState.OnUpdate();
        }

        protected virtual void FixedUpdate()
        {
            if (CurrentState != null && !inTransition)
                CurrentState.OnFixedUpdate();
        }

        public void ChangeState(IState newState)
        {
            if (CurrentState == newState || inTransition)
                return;

            ChangeStateRoutine(newState);
        }

        public void RevertState()
        {
            if (PreviousState != null)
                ChangeState(PreviousState);
        }

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