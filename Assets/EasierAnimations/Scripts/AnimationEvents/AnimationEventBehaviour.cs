using UnityEngine;

namespace EasierAnimations
{
	public class AnimationEventBehaviour : BaseAnimationEventBehaviour
	{
		[SerializeField] private bool shouldTriggerEventOnEachLoop;
		[SerializeField] [Range(0f, 1f)] private float triggerTime;

		private bool hasTriggered;
		private int previousLoop;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

			hasTriggered = false;
			previousLoop = Mathf.FloorToInt(stateInfo.normalizedTime);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            float currentTime = stateInfo.normalizedTime % 1f;
            int currentLoop = Mathf.FloorToInt(stateInfo.normalizedTime);

            if (shouldTriggerEventOnEachLoop && previousLoop < currentLoop)
            {
                hasTriggered = false;
                previousLoop = currentLoop;
            }

            if (!hasTriggered && currentTime >= triggerTime)
            {
                NotifyReceiver();
                hasTriggered = true;
            }
        }

        public void SetTriggerTime(float newTriggerTime)
        {
            triggerTime = newTriggerTime;
        }
    }
}