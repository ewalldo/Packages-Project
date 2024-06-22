using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
	public static class HierarchyEnhancerSettings
	{
        // The default width and height of a Unity icon is 16 pixels
        public const int DEFAULT_ICON_SIZE = 16;
        public const int MAX_COMPONENTS_ICONS = 10;

        public const string DRAW_COMPONENTS_ICONS_PREFS_NAME = "DrawComponentsIcons";
        public const string COMPONENTS_ICONS_SIZE_PREFS_NAME = "ComponentsIconsSize";
        public const string MAX_COMPONENTS_ICONS_PREFS_NAME = "MaxComponentsIcons";

        [SettingsProvider()]
        public static SettingsProvider OnSettingsUI()
        {
            SettingsProvider provider = new SettingsProvider("Project/Hierarchy Enhancer", SettingsScope.Project)
            {
                label = "Hierarchy Enhancer",
                guiHandler = (searchContext) =>
                {
                    GUILayout.Label("Icons Settings");

                    bool shouldDraw = EditorPrefs.GetBool(DRAW_COMPONENTS_ICONS_PREFS_NAME, true);
                    shouldDraw = EditorGUILayout.Toggle("Display Hierarchy Icons?", shouldDraw);
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

                        EditorGUI.indentLevel--;
                    }

                    EditorGUILayout.Space(20f);
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("Reset to default", GUILayout.Width(200)))
                    {
                        EditorPrefs.SetBool(DRAW_COMPONENTS_ICONS_PREFS_NAME, true);
                        EditorPrefs.SetInt(COMPONENTS_ICONS_SIZE_PREFS_NAME, DEFAULT_ICON_SIZE);
                        EditorPrefs.SetInt(MAX_COMPONENTS_ICONS_PREFS_NAME, MAX_COMPONENTS_ICONS);
                    }
                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();
                },
                keywords = new HashSet<string>(new[] { "Icons, Hierarchy" })
            };

            return provider;
        }
    }
}