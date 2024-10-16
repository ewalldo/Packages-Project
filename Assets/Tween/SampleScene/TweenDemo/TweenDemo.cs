using UnityEngine;
using UnityEngine.UI;

namespace Tween
{
	public class TweenDemo : MonoBehaviour
	{
        [SerializeField] private Transform cube;
		[SerializeField] private Light spotLight;
		[SerializeField] private Image image;
        [SerializeField] private CanvasGroup canvasGroup;

        private TweenBuilder transformTween;
		private TweenBuilder lightTween;
		private TweenSequencer imageTween;
        private TweenBuilder uiTween;

        private void Awake()
        {
            lightTween = new TweenBuilder(this);
            lightTween.AddTween(new TweenLightColor(spotLight, Color.white, Color.red, 3f, 0f, new EaseInOutSine(), new PingPongLoop(0, 1f)))
                .AddTween(new TweenLightIntensity(spotLight, 10f, 75f, 10f, 0f, new EaseInOutCubic(), new PingPongLoop(0)));

            transformTween = new TweenBuilder(this);
            transformTween.AddTween(new TweenMove(cube, new Vector3(-5f, 1f, 0f), new Vector3(5f, 1f, 0f), 5f, 0f, true, new EaseOutBounce(), new PingPongLoop(0, 1f)))
                .AddTween(new TweenScale(cube, Vector3.one * 0.5f, Vector3.one, 5f, 0f, new EaseInOutSine(), new PingPongLoop(0, 1f)))
                .AddTween(new TweenRotateVector3(cube, Vector3.zero, Vector3.one * 360f, 5f, 0f, false, null, new PingPongLoop(0, 1f)));

            imageTween = new TweenSequencer(this);
            imageTween.AddTween(new TweenImageFillAmount(image, 1f, 0f, 1.5f, 0f, null, new PingPongLoop(1)))
                .AddTween(new TweenImageColor(image, Color.white, Color.green, 3f))
                .AddTween(new TweenImageFade(image, 1f, 0f, 3f, 0f))
                .OnAllTweensCompleted += () =>
                {
                    image.fillAmount = 1f;
                    image.color = Color.white;
                };

            uiTween = new TweenBuilder(this);
            uiTween.AddTween(new TweenCanvasGroupFade(canvasGroup, 1f, 0f, 2f, 0f, new EaseInOutSine(), new PingPongLoop(1)));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transformTween.Stop();
                transformTween.Execute();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                lightTween.Stop();
                lightTween.Execute();
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                imageTween.Stop();
                imageTween.Execute();
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                uiTween.Stop();
                uiTween.Execute();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                TweenShakeRotation shake = new TweenShakeRotation(Camera.main.transform, new Vector3(0f, 0f, 1f), 0.5f, 0f, maxMagnitude: 5, easingFunction: new EaseInCirc());
                StartCoroutine(shake.Execute());
            }
        }
    }
}