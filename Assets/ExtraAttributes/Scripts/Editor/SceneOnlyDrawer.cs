using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(SceneOnlyAttribute))]
    public class SceneOnlyDrawer : PropertyDrawer
	{
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.ObjectReference)
            {
                string errorMessage = "SceneOnly attribute: Must be used with object reference property type!";

                Debug.LogError(errorMessage);
                EditorGUI.HelpBox(position, errorMessage, MessageType.Error);
                return;
            }

            EditorGUI.BeginProperty(position, label, property);

            Object newObject = EditorGUI.ObjectField(position, new GUIContent(label.text + " (Scene Only)"), property.objectReferenceValue, fieldInfo.FieldType, true);

            if (IsSceneObject(newObject))
            {
                property.objectReferenceValue = newObject;
            }
            else if (newObject != null)
            {
                Debug.LogError("SceneOnly attribute: Only objects in the scene hierarchy are allowed!");
                property.objectReferenceValue = null; // Reset the value if it's not a scene object
            }
            else
            {
                property.objectReferenceValue = null;
            }

            EditorGUI.EndProperty();
        }

        private bool IsSceneObject(Object obj)
        {
            return (obj != null && !EditorUtility.IsPersistent(obj));
        }
    }
}