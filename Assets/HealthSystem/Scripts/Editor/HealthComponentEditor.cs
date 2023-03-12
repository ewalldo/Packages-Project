using UnityEngine;
using UnityEditor;

namespace HealthSystem
{
    [CustomEditor(typeof(HealthComponent))]
    public class HealthComponentEditor : Editor
	{
        private HealthComponent healthComponent;

        private SerializedProperty maxHealthProperty;
        private SerializedProperty initialHealthProperty;
        private SerializedProperty startAtMaxHealthProperty;
        private SerializedProperty criticalThresholdProperty;

        private void OnEnable()
        {
            healthComponent = target as HealthComponent;

            maxHealthProperty = serializedObject.FindProperty(healthComponent.GetNameOfMaxCurrentHealth);
            initialHealthProperty = serializedObject.FindProperty(healthComponent.GetNameOfCurrentHealth);
            startAtMaxHealthProperty = serializedObject.FindProperty(healthComponent.GetNameOfStartAtMaxHealth);
            criticalThresholdProperty = serializedObject.FindProperty(healthComponent.GetNameOfCriticalHealthThreshold);
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            float maxHealth = EditorGUILayout.FloatField("Max Health", maxHealthProperty.floatValue);

            EditorGUILayout.Space(10);

            bool startAtMaxHealth = EditorGUILayout.Toggle("Start at max health", startAtMaxHealthProperty.boolValue);

            GUI.enabled = !startAtMaxHealth;
            float initialHealth = EditorGUILayout.FloatField("Initial health", initialHealthProperty.floatValue);
            GUI.enabled = true;

            EditorGUILayout.Space(10);

            GUIContent criticalThresholdGUIContent = new GUIContent("Critical threshold", "The threshold when the health reaches critical condition");
            float criticalThreshold = EditorGUILayout.Slider(criticalThresholdGUIContent, criticalThresholdProperty.floatValue, 0f, 1f);

            if (EditorGUI.EndChangeCheck())
            {
                maxHealthProperty.floatValue = maxHealth;

                if (startAtMaxHealth)
                    initialHealthProperty.floatValue = maxHealth;
                else
                    initialHealthProperty.floatValue = initialHealth > maxHealth ? maxHealth : initialHealth;

                startAtMaxHealthProperty.boolValue = startAtMaxHealth;

                criticalThresholdProperty.floatValue = criticalThreshold;

                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}