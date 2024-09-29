using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(ResourcesPathAttribute))]
    public class ResourcesPathDrawer : PropertyDrawer
	{
        private const string resourcesPath = "Resources/";

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                string errorMessage = "ResourcesPath attribute: Must be used with string property type!";

                Debug.LogError(errorMessage);
                EditorGUI.HelpBox(position, errorMessage, MessageType.Error);
                return;
            }

            EditorGUI.BeginProperty(position, label, property);

            EditorGUI.TextField(position, label, property.stringValue);

            bool isDragEventAboveField = IsMousePositionOnTheProperty(position);

            if (isDragEventAboveField && Event.current.type == EventType.DragUpdated)
            {
                // Show a highlight on the field to indicate that it's a valid drop area
                DragAndDrop.visualMode = IsDraggedObjectValid() ? DragAndDropVisualMode.Link : DragAndDropVisualMode.Rejected;
            }

            // Check if a drag-and-drop event occurred
            if (isDragEventAboveField && Event.current.type == EventType.DragPerform && IsDraggedObjectValid())
            {
                DragAndDrop.AcceptDrag();
                string path = DragAndDrop.paths[0];

                int startIndex = path.IndexOf(resourcesPath) + resourcesPath.Length;
                int endIndex = path.LastIndexOf('.');
                if (endIndex > startIndex)
                {
                    property.stringValue = path.Substring(startIndex, endIndex - startIndex);
                }
            }

            EditorGUI.EndProperty();
        }

        /// <summary>
        /// Check if the dragged object is a valid asset
        /// </summary>
        /// <returns>True if valid asset. false otherwise</returns>
        private bool IsDraggedObjectValid()
        {
            if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)
            {
                string path = DragAndDrop.paths[0];
                return !string.IsNullOrEmpty(path) && System.IO.File.Exists(path) && path.Contains(resourcesPath);
            }
            return false;
        }

        /// <summary>
        /// Check if the mouse position is above the property
        /// </summary>
        /// <param name="position">Property rect</param>
        /// <returns>True if mouse is within the property, false otherwise</returns>
        private bool IsMousePositionOnTheProperty(Rect position)
        {
            Vector2 mousePosition = Event.current.mousePosition;
            return position.Contains(mousePosition);
        }
    }
}