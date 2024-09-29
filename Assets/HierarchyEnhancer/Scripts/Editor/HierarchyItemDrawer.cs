using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
    [InitializeOnLoad]
    public static class HierarchyItemDrawer
    {
        static HierarchyItemDrawer()
        {
            EditorApplication.hierarchyWindowItemOnGUI -= OnHierarchyGUI;
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
        }

        private static void OnHierarchyGUI(int instanceID, Rect selectionRect)
        {
            GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (obj == null)
                return;

            // Draw object as header if there is a header component
            if (obj.TryGetComponent(out HierarchyHeader hierarchyHeader))
            {
                DrawHeaderInHierarchy(hierarchyHeader, selectionRect);
                return;
            }

            // Draw components icons 
            if (EditorPrefs.GetBool(IconSettings.DRAW_COMPONENTS_ICONS_PREFS_NAME, true))
            {
                Component[] components = obj.GetComponents<Component>();

                int iconsSize = EditorPrefs.GetInt(IconSettings.COMPONENTS_ICONS_SIZE_PREFS_NAME, IconSettings.DEFAULT_ICON_SIZE);
                float iconX = selectionRect.x + selectionRect.width - iconsSize;

                int maxIcons = EditorPrefs.GetInt(IconSettings.MAX_COMPONENTS_ICONS_PREFS_NAME, IconSettings.MAX_COMPONENTS_ICONS);

                List<string> ignoredComponents = new List<string>(EditorPrefs.GetString(IconSettings.IGNORED_COMPONENTS_PREFS_NAME, IconSettings.DEFAULT_IGNORED_COMPONENTS).Split(','));

                int drewIcons = 0;
                for (int i = components.Length - 1; i >= 0; i--)
                {
                    Component component = components[i];

                    if (ignoredComponents.Contains(component.GetType().Name))
                        continue;

                    Texture icon = GetIconForComponent(component);

                    if (icon != null)
                    {
                        Rect iconRect = new Rect(iconX, selectionRect.y + ((selectionRect.height - iconsSize) / 2), iconsSize, iconsSize);
                        GUI.DrawTexture(iconRect, icon);

                        iconX -= iconsSize;

                        drewIcons++;
                        if (drewIcons >= maxIcons)
                            break;
                    }
                }
            }
        }

        private static Texture GetIconForComponent(Component component)
        {
            Texture icon = null;

            if (component != null)
            {
                GUIContent content = EditorGUIUtility.ObjectContent(component, component.GetType());

                if (content != null)
                {
                    icon = content.image;
                }
            }

            return icon;
        }

        private static void DrawHeaderInHierarchy(HierarchyHeader hierarchyHeader, Rect selectionRect)
        {
            GUIStyle headerStyle = new GUIStyle(EditorStyles.label)
            {
                alignment = hierarchyHeader.GetTextAnchor,
                fontStyle = hierarchyHeader.GetFontStyle,
                fontSize = hierarchyHeader.GetFontSize
            };
            headerStyle.normal.textColor = hierarchyHeader.GetFontColor;

            EditorGUI.DrawRect(selectionRect, hierarchyHeader.GetHeaderColor);
            EditorGUI.LabelField(selectionRect, hierarchyHeader.name, headerStyle);
        }
    }
}