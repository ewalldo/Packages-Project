using UnityEngine;
using UnityEditor;
using System;
using Object = UnityEngine.Object;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(RequireInterfaceAttribute))]
    public class RequireInterfaceDrawer : PropertyDrawer
	{
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            RequireInterfaceAttribute requireInterfaceAttribute = attribute as RequireInterfaceAttribute;

            Type requiredInterfaceType = requireInterfaceAttribute.InterfaceType;

            EditorGUI.BeginProperty(position, label, property);

            if (property.isArray && property.propertyType == SerializedPropertyType.Generic)
                DrawArrayField(position, property, label, requiredInterfaceType);
            else
                DrawInterfaceObjectField(position, property, label, requiredInterfaceType);

            EditorGUI.EndProperty();
        }

        private void DrawArrayField(Rect position, SerializedProperty property, GUIContent label, Type interfaceType)
        {
            property.arraySize = EditorGUI.IntField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight),
                label.text + " Size",
                property.arraySize);

            float yOffset = EditorGUIUtility.singleLineHeight;
            for (int i = 0; i < property.arraySize; i++)
            {
                SerializedProperty element = property.GetArrayElementAtIndex(i);
                Rect elementRect = new Rect(position.x, position.y + yOffset, position.width, EditorGUIUtility.singleLineHeight);
                DrawInterfaceObjectField(elementRect, element, new GUIContent($"Element {i}"), interfaceType);
                yOffset += EditorGUIUtility.singleLineHeight;
            }
        }

        private void DrawInterfaceObjectField(Rect position, SerializedProperty property, GUIContent label, Type interfaceType)
        {
            Object oldReference = property.objectReferenceValue;
            Object newReference = EditorGUI.ObjectField(position, label + $" ({interfaceType.Name})", oldReference, typeof(Object), true);

            if (newReference != null && newReference != oldReference)
                ValidateAndAssignObject(property, newReference, interfaceType);
            else if (newReference == null)
                property.objectReferenceValue = null;
        }

        private void ValidateAndAssignObject(SerializedProperty property, Object newReference, Type interfaceType)
        {
            if (newReference is GameObject gameObject)
            {
                Component component = gameObject.GetComponent(interfaceType);
                if (component != null)
                {
                    property.objectReferenceValue = component;
                    return;
                }
            }
            else if (interfaceType.IsAssignableFrom(newReference.GetType()))
            {
                property.objectReferenceValue = newReference;
                return;
            }

            Debug.LogError($"The object does not implement the interface '{interfaceType.Name}'!");
            property.objectReferenceValue = null;
        }
    }
}