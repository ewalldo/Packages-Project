using UnityEngine;
using TMPro;

namespace Tween
{
    public class TweenTest : MonoBehaviour
	{
        [SerializeField] private GameObject rendererTest;
        [SerializeField] private TextMeshProUGUI textTest;

        private TweenBuilder tweenBuilder;

        private void Awake()
        {
            tweenBuilder = new TweenBuilder(this);
            tweenBuilder.AddTween(new TweenTextFade(textTest, 0, 2f));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rendererTest.GetComponent<Renderer>().TweenColor(Color.red, 3f, 0f, new EaseInOutBack(), new PingPongLoop(0, 2.5f));
                //tweenBuilder.Execute();
                textTest.TweenFade(0f, 2f, 0f, null, new PingPongLoop(0));
            }
        }
    }
}