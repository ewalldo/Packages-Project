using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
    [InitializeOnLoad]
	public static class HierarchyItemDrawer
	{
        // The default width and height of a Unity icon is 16 pixels
        private const float ICON_SIZE = 16f;

        static HierarchyItemDrawer()
        {
			EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
		}

        [SettingsProvider()]
        public static SettingsProvider OnSettingsUI()
        {
            SettingsProvider provider = new SettingsProvider("Project/Hierarchy Enhancer", SettingsScope.Project)
            {
                label = "Hierarchy Enhancer",
                guiHandler = (searchContext) =>
                {
                    GUILayout.Label("Icons Settings");

                    bool shouldDraw = EditorPrefs.GetBool("DrawComponentsIcons", true);
                    shouldDraw = EditorGUILayout.Toggle("Display Hierarchy Icons?", shouldDraw);
                    EditorPrefs.SetBool("DrawComponentsIcons", shouldDraw);
                },
                keywords = new HashSet<string>(new[] { "Icons, Hierarchy" })
            };

            return provider;
        }

        private static void OnHierarchyGUI(int instanceID, Rect selectionRect)
        {
            GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (obj != null)
            {
                if (obj.TryGetComponent(out HierarchyHeader hierarchyHeader))
                {
                    DrawHeaderInHierarchy(hierarchyHeader, selectionRect);
                    return;
                }

                if (!EditorPrefs.GetBool("DrawComponentsIcons", true))
                    return;

                Component[] components = obj.GetComponents<Component>();
                float iconX = selectionRect.x + selectionRect.width - ICON_SIZE;

                for (int i = components.Length - 1; i >= 0; i--)
                {
                    Component component = components[i];

                    if (component is Transform)
                        continue;

                    Texture icon = GetIconForComponent(component);

                    if (icon != null)
                    {
                        Rect iconRect = new Rect(iconX, selectionRect.y, ICON_SIZE, ICON_SIZE);
                        GUI.DrawTexture(iconRect, icon);

                        iconX -= ICON_SIZE;
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
            GUIStyle headerStyle = new GUIStyle(EditorStyles.label);
            headerStyle.alignment = hierarchyHeader.GetTextAnchor;
            headerStyle.fontStyle = hierarchyHeader.GetFontStyle;
            headerStyle.fontSize = hierarchyHeader.GetFontSize;
            headerStyle.normal.textColor = hierarchyHeader.GetFontColor;

            EditorGUI.DrawRect(selectionRect, hierarchyHeader.GetHeaderColor);
            EditorGUI.LabelField(selectionRect, hierarchyHeader.name, headerStyle);
        }
    }
}