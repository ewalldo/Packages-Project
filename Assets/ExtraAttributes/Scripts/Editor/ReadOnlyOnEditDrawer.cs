using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyOnEditAttribute))]
    public class ReadOnlyOnEditDrawer : PropertyDrawer
	{
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!Application.isPlaying)
            {
                EditorGUI.BeginDisabledGroup(true);
                EditorGUI.PropertyField(position, property, label);
                EditorGUI.EndDisabledGroup();
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }
    }
}