using UnityEngine;

namespace Tween
{
	public class TweenCoroutineStarter : MonoBehaviour
	{
        private static TweenCoroutineStarter instance;

        public static TweenCoroutineStarter Instance
        {
            get
            {
                if (instance == null)
                    SetupInstance();
                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private static void SetupInstance()
        {
            if (instance == null)
            {
                GameObject gameObject = new GameObject("TweenCoroutineStarter");
                instance = gameObject.AddComponent<TweenCoroutineStarter>();
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}