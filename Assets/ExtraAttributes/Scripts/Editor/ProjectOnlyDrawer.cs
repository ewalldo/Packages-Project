using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(ProjectOnlyAttribute))]
    public class ProjectOnlyDrawer : PropertyDrawer
	{
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.ObjectReference)
            {
                string errorMessage = "ProjectOnly attribute: Must be used with object reference property type!";

                Debug.LogError(errorMessage);
                EditorGUI.HelpBox(position, errorMessage, MessageType.Error);
                return;
            }

            EditorGUI.BeginProperty(position, label, property);

            property.objectReferenceValue = EditorGUI.ObjectField(position, new GUIContent(label.text + " (Project Only)"), property.objectReferenceValue, fieldInfo.FieldType, false);

            EditorGUI.EndProperty();
        }
    }
}