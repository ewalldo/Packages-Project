using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tween
{
    public class TweenTest : MonoBehaviour
	{
        [SerializeField] private GameObject rendererTest;
        [SerializeField] private TextMeshProUGUI textTest;
        [SerializeField] private Image imageTest;
        [SerializeField] private Transform transformTest;
        [SerializeField] private Material mat1;

        private TweenBuilder tweenBuilder;

        private void Awake()
        {
            tweenBuilder = new TweenBuilder(this);
            tweenBuilder.AddTween(new TweenTextFade(textTest, 0, 2f));
            tweenBuilder.AddTween(new TweenScale(transformTest, Vector3.one * 2, 2f, 0f, null, new PingPongLoop(0, 0f, null, () => Debug.Log("Loop completed"))));
            tweenBuilder.AddTween(new TweenImageFillAmount(imageTest, 0f, 2f, 0f, new EaseInSine(), new PingPongLoop(0, 1f)));
            tweenBuilder.AddTween(new TweenMaterialColor(mat1, Color.red, Color.blue, 2f, 0f, new EaseInSine(), new PingPongLoop(0)));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rendererTest.GetComponent<Renderer>().TweenColor(Color.red, 3f, 0f, 0, new EaseInOutBack(), new PingPongLoop(0, 2.5f));
                tweenBuilder.Execute();
                //textTest.TweenFade(0f, 2f, 0f, null, new PingPongLoop(0));
            }
        }
    }
}