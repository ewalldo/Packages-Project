using UnityEngine;
using TMPro;

namespace Tween
{
    public class TweenTest : MonoBehaviour
	{
        [SerializeField] private GameObject rendererTest;
        [SerializeField] private TextMeshProUGUI textTest;
        [SerializeField] private Transform transformTest;

        private TweenBuilder tweenBuilder;

        private void Awake()
        {
            tweenBuilder = new TweenBuilder(this);
            tweenBuilder.AddTween(new TweenTextFade(textTest, 0, 2f));
            tweenBuilder.AddTween(new TweenScale(transformTest, Vector3.one * 2, 2f, 0f, null, new PingPongLoop(0, 0f, null, () => Debug.Log("Loop completed"))));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rendererTest.GetComponent<Renderer>().TweenColor(Color.red, 3f, 0f, new EaseInOutBack(), new PingPongLoop(0, 2.5f));
                tweenBuilder.Execute();
                //textTest.TweenFade(0f, 2f, 0f, null, new PingPongLoop(0));
            }
        }
    }
}