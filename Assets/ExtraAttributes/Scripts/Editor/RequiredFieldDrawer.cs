using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(RequiredFieldAttribute))]
    public class RequiredFieldDrawer : PropertyDrawer
	{
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.ObjectReference && property.objectReferenceValue == null)
            {
                return base.GetPropertyHeight(property, label) * 2;
            }
            else
            {
                return base.GetPropertyHeight(property, label);
            }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            RequiredFieldAttribute requiredFieldAttribute = attribute as RequiredFieldAttribute;

            if (property.propertyType == SerializedPropertyType.ObjectReference && property.objectReferenceValue == null)
            {
                Color ogColor = GUI.color;
                GUI.color = requiredFieldAttribute.RequiredColor;
                float halfPropertySize = GetPropertyHeight(property, label) / 2f;

                EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, halfPropertySize), property, label);
                Rect helpBoxRect = new Rect(position.x, position.y + halfPropertySize, position.width, halfPropertySize);
                EditorGUI.HelpBox(helpBoxRect, "This field is required and cannot be null!", MessageType.Error);

                GUI.color = ogColor;
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
            }

            EditorGUI.EndProperty();
        }
    }
}