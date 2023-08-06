using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(HideOnEditAttribute))]
    public class HideOnEditDrawer : PropertyDrawer
	{
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return Application.isPlaying ? base.GetPropertyHeight(property, label) : 0f;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!Application.isPlaying)
                return;

            EditorGUI.PropertyField(position, property, label);
        }
    }
}