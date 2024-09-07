using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
    public static class HierarchyEnhancerSettings
	{
        private static readonly ShortcutSettings shortcutSettings;
        private static readonly IconSettings iconSettings;

        static HierarchyEnhancerSettings()
        {
            shortcutSettings = new ShortcutSettings();
            iconSettings = new IconSettings();
        }

        [SettingsProvider()]
        public static SettingsProvider OnSettingsUI()
        {
            SettingsProvider provider = new SettingsProvider("Project/Hierarchy Enhancer", SettingsScope.Project)
            {
                label = "Hierarchy Enhancer",
                guiHandler = (searchContext) =>
                {
                    shortcutSettings.DrawSettings();
                    EditorGUILayout.Space(10f);
                    iconSettings.DrawSettings();

                    EditorGUILayout.Space(20f);

                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("Reset to default", GUILayout.Width(200)))
                    {
                        shortcutSettings.Reset();
                        iconSettings.Reset();
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