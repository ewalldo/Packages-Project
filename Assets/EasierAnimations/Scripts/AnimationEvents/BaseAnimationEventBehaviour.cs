using UnityEngine;

namespace EasierAnimations
{
	public abstract class BaseAnimationEventBehaviour : StateMachineBehaviour
	{
		[SerializeField] protected string eventName;

		protected AnimationEventReceiver animationEventReceiver;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (animationEventReceiver == null)
                animationEventReceiver = animator.GetComponent<AnimationEventReceiver>();
        }

        protected void NotifyReceiver()
        {
            if (animationEventReceiver != null)
                animationEventReceiver.TriggerAnimationEvent(eventName);
        }
    }
}