using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ExtraAttributes
{
    [InitializeOnLoad]
    public static class RequiredFieldChecker
	{
        static RequiredFieldChecker()
        {
            EditorApplication.playModeStateChanged -= OnPlayModeChanged;
            EditorApplication.playModeStateChanged += OnPlayModeChanged;
        }

        private static void OnPlayModeChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredPlayMode)
                CheckAllRequiredFields();
        }

        private static void CheckAllRequiredFields()
        {
            MonoBehaviour[] allMonoBehaviours = Object.FindObjectsOfType<MonoBehaviour>();

            foreach (MonoBehaviour monoBehaviour in allMonoBehaviours)
            {
                FieldInfo[] fields = monoBehaviour.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (FieldInfo field in fields)
                {
                    var requiredFieldAttribute = field.GetCustomAttribute<RequiredFieldAttribute>();
                    if (requiredFieldAttribute != null)
                    {
                        object fieldValue = field.GetValue(monoBehaviour);

                        if (fieldValue.Equals(null))
                        {
                            Debug.LogError($"[RequiredField] Error in '{monoBehaviour.gameObject.name}' on script '{monoBehaviour.GetType().Name}': Field '{field.Name}' is required but is not assigned.", monoBehaviour.gameObject);
                        }
                    }
                }
            }
        }
    }
}