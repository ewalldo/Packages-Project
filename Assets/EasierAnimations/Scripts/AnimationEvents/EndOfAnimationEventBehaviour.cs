using UnityEngine;

namespace EasierAnimations
{
	public class EndOfAnimationEventBehaviour : BaseAnimationEventBehaviour
	{
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            NotifyReceiver();
        }
    }
}