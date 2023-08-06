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

            if (property.propertyType != SerializedPropertyType.String)
            {
                string errorMessage = "SceneField attribute: Must be used with string property type!";

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

            GUIContent[] gUIContents = new GUIContent[buildScenes.Length];
            for (int i = 0; i < buildScenes.Length; i++)
            {
                gUIContents[i] = new GUIContent(buildScenes[i].path.Split('/')[^1].Replace(".unity", ""));
            }

            EditorGUI.BeginChangeCheck();
            sceneFieldAttribute.SetSceneIndex(EditorGUI.Popup(position, label, sceneFieldAttribute.SelectedSceneIndex, gUIContents));

            if (EditorGUI.EndChangeCheck())
                property.stringValue = buildScenes[sceneFieldAttribute.SelectedSceneIndex].path;
        }
    }
}