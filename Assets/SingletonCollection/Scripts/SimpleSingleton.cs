using UnityEngine;

namespace SingletonCollection
{
	public class SimpleSingleton<T> : MonoBehaviour where T : Component
	{
        protected static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name);
                    instance = go.AddComponent<T>();
                }

                return instance;
            }
        }

        protected virtual void Awake()
        {
            InitializeSingleton();
        }

        protected virtual void InitializeSingleton()
        {
            if (!Application.isPlaying)
                return;

            if (instance != null && instance != this)
                Destroy(this.gameObject);
            else
                instance = this as T;
        }
    }
}