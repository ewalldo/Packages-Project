using UnityEngine;
using UnityEditor;

namespace ExtraAttributes
{
    [CustomPropertyDrawer(typeof(SceneFieldAttribute))]
    public class SceneFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SceneFieldAttribute sceneFieldAttribute = attribute as SceneFieldAttribute;

            if (property.propertyType != SerializedPropertyType.String && property.propertyType != SerializedPropertyType.Integer)
            {
                string errorMessage = "SceneField attribute: Must be used with string or int property type!";

                Debug.LogError(errorMessage);
                EditorGUI.HelpBox(position, errorMessage, MessageType.Error);
                return;
            }

            EditorBuildSettingsScene[] buildScenes = EditorBuildSettings.scenes;

            if (buildScenes.Length <= 0)
            {
                EditorGUI.HelpBox(position, "SceneField attribute: No scenes found in the build settings!", MessageType.Error);
                return;
            }

            int index = 0;
            GUIContent[] gUIContents = new GUIContent[buildScenes.Length];
            for (int i = 0; i < buildScenes.Length; i++)
            {
                if (property.propertyType == SerializedPropertyType.String)
                {
                    string sceneName = GetStringNameFromFullPath(buildScenes[i].path);
                    gUIContents[i] = new GUIContent(sceneName);
                    if (property.stringValue == sceneName)
                        index = i;
                }
                else if (property.propertyType == SerializedPropertyType.Integer)
                {
                    gUIContents[i] = new GUIContent($"({i}): " + buildScenes[i].path.Split('/')[^1].Replace(".unity", ""));
                    if (property.intValue == i)
                        index = i;
                }
            }

            EditorGUI.BeginChangeCheck();
            int newIdx = EditorGUI.Popup(position, label, index, gUIContents);

            if (EditorGUI.EndChangeCheck())
            {
                if (property.propertyType == SerializedPropertyType.String)
                    property.stringValue = GetStringNameFromFullPath(buildScenes[newIdx].path);
                else if (property.propertyType == SerializedPropertyType.Integer)
                    property.intValue = newIdx;
            }
        }

        private string GetStringNameFromFullPath(string fullPath)
        {
            return fullPath.Split('/')[^1].Replace(".unity", "");
        }
    }
}