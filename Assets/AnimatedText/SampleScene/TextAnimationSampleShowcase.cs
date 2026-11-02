using UnityEngine;

namespace AnimatedText
{
	public class TextAnimationSampleShowcase : MonoBehaviour
	{
		[SerializeField] private TextAnimator waveText;
		[SerializeField] private TextAnimator shakeText;
		[SerializeField] private TextAnimator pulseText;
		[SerializeField] private TextAnimator rotationText;
		[SerializeField] private TextAnimator bounceText;
		[SerializeField] private TextAnimator noiseText;

        private void Start()
        {
			waveText.TypeText("<wave=5,5>Wave animation</wave>");
			shakeText.TypeText("<shake=5>Shake animation</shake>");
			pulseText.TypeText("<pulse=5,0.2,1>Pulse animation</pulse>");
			rotationText.TypeText("<rotate=60>Rotation animation</rotate>");
			bounceText.TypeText("<bounce=5,5,false>Bounce animation</bounce>");
			noiseText.TypeText("<noise=20,5,1>Noise animation</noise>");
        }
    }
}