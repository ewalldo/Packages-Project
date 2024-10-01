using UnityEngine;

namespace SingletonCollection
{
	public class PersistentNewestSingleton<T> : MonoBehaviour where T : Component
	{
        protected static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name)
                    {
                        hideFlags = HideFlags.DontSave
                    };
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

            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);

            if (instance != null && instance != this)
                Destroy(instance.gameObject);

            instance = this as T;
        }
    }
}