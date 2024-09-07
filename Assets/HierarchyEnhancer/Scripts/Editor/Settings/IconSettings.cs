using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
    public class IconSettings
	{
        // The default width and height of a Unity icon is 16 pixels
        public const int DEFAULT_ICON_SIZE = 16;
        public const int MAX_COMPONENTS_ICONS = 10;
        public const string DEFAULT_IGNORED_COMPONENTS = "Transform,RectTransform";

        public const string DRAW_COMPONENTS_ICONS_PREFS_NAME = "DrawComponentsIcons";
        public const string COMPONENTS_ICONS_SIZE_PREFS_NAME = "ComponentsIconsSize";
        public const string MAX_COMPONENTS_ICONS_PREFS_NAME = "MaxComponentsIcons";
        public const string IGNORED_COMPONENTS_PREFS_NAME = "IgnoredComponents";

        public const string SCRIPT_ICON_NAME = "cs Script Icon";

        private readonly List<Type> componentTypes;
        private string newComponentName = "";

        public IconSettings()
        {
            componentTypes = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .Where(type => type.IsSubclassOf(typeof(Component)) && !type.IsAbstract)
                    .OrderBy(type => type.Name)
                    .ToList();
        }

        public void DrawSettings()
        {
            EditorGUILayout.LabelField("<color=white>Icons Settings: </color>", new GUIStyle { fontStyle = FontStyle.Bold });

            EditorGUI.indentLevel++;

            bool shouldDraw = EditorPrefs.GetBool(DRAW_COMPONENTS_ICONS_PREFS_NAME, true);
            shouldDraw = EditorGUILayout.ToggleLeft("Display Hierarchy Icons?", shouldDraw);
            EditorPrefs.SetBool(DRAW_COMPONENTS_ICONS_PREFS_NAME, shouldDraw);

            if (shouldDraw)
            {
                EditorGUI.indentLevel++;

                int componentsIconSize = EditorPrefs.GetInt(COMPONENTS_ICONS_SIZE_PREFS_NAME, DEFAULT_ICON_SIZE);
                componentsIconSize = EditorGUILayout.IntSlider("Icons size (1 ~ 16):", componentsIconSize, 1, DEFAULT_ICON_SIZE);
                EditorPrefs.SetInt(COMPONENTS_ICONS_SIZE_PREFS_NAME, componentsIconSize);

                int maxComponentsIcons = EditorPrefs.GetInt(MAX_COMPONENTS_ICONS_PREFS_NAME, MAX_COMPONENTS_ICONS);
                maxComponentsIcons = EditorGUILayout.IntSlider("Max number of icons to display for each object:", maxComponentsIcons, 1, 99);
                EditorPrefs.SetInt(MAX_COMPONENTS_ICONS_PREFS_NAME, maxComponentsIcons);

                EditorGUILayout.Space(5);

                EditorGUILayout.LabelField("Ignore the following components when drawing the icons:");

                string ignoredComponentsStr = EditorPrefs.GetString(IGNORED_COMPONENTS_PREFS_NAME, DEFAULT_IGNORED_COMPONENTS);
                HashSet<string> ignoredComponents = new HashSet<string>(ignoredComponentsStr.Split(','));

                List<string> toRemove = new List<string>();
                foreach (string ignoredComponent in ignoredComponents)
                {
                    Type componentType = componentTypes.FirstOrDefault(type => type.Name == ignoredComponent);
                    if (componentType != null)
                    {
                        EditorGUILayout.BeginHorizontal();

                        GUIContent content = EditorGUIUtility.ObjectContent(null, componentType);
                        content.text = componentType.Name;
                        if (content.image == null)
                            content.image = EditorGUIUtility.IconContent(SCRIPT_ICON_NAME).image;

                        EditorGUILayout.LabelField(content, GUILayout.Height(DEFAULT_ICON_SIZE));

                        if (GUILayout.Button("Remove", GUILayout.Width(60)))
                        {
                            toRemove.Add(ignoredComponent);
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                }

                foreach (string item in toRemove)
                {
                    ignoredComponents.Remove(item);
                }

                EditorGUILayout.Space(5);

                EditorGUILayout.LabelField("Add new component to the ignore list:");
                newComponentName = EditorGUILayout.TextField(newComponentName, GUILayout.Width(250));
                DisplayComponentSearch(newComponentName, ignoredComponents);

                ignoredComponentsStr = string.Join(",", ignoredComponents);
                EditorPrefs.SetString(IGNORED_COMPONENTS_PREFS_NAME, ignoredComponentsStr);

                EditorGUI.indentLevel--;
            }

            EditorGUI.indentLevel--;
        }

        private void DisplayComponentSearch(string searchTerm, HashSet<string> ignoredComponents)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return;

            if (searchTerm.Length <= 1)
                return;

            List<Type> filteredComponents = componentTypes.Where(type => type.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                .Where(type => !ignoredComponents.Contains(type.Name)).ToList();

            foreach (Type componentType in filteredComponents)
            {
                GUIContent content = EditorGUIUtility.ObjectContent(null, componentType);

                content.text = componentType.Name;
                if (content.image == null)
                    content.image = EditorGUIUtility.IconContent(SCRIPT_ICON_NAME).image;

                if (GUILayout.Button(content, GUILayout.Height(DEFAULT_ICON_SIZE)))
                {
                    ignoredComponents.Add(componentType.Name);
                    newComponentName = string.Empty;
                }
            }
        }

        public void Reset()
        {
            EditorPrefs.SetBool(DRAW_COMPONENTS_ICONS_PREFS_NAME, true);
            EditorPrefs.SetInt(COMPONENTS_ICONS_SIZE_PREFS_NAME, DEFAULT_ICON_SIZE);
            EditorPrefs.SetInt(MAX_COMPONENTS_ICONS_PREFS_NAME, MAX_COMPONENTS_ICONS);
            EditorPrefs.SetString(IGNORED_COMPONENTS_PREFS_NAME, DEFAULT_IGNORED_COMPONENTS);
            newComponentName = string.Empty;
        }
    }
}