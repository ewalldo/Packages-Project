using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
    [InitializeOnLoad]
	public static class HierarchyItemShortcuts
	{
        private static List<IHierarchyShortcut> shortcuts;

        static HierarchyItemShortcuts()
        {
            EditorApplication.hierarchyWindowItemOnGUI -= OnShortcutCheck;
            EditorApplication.hierarchyWindowItemOnGUI += OnShortcutCheck;

            Type type = typeof(IHierarchyShortcut);
            IEnumerable<Type> shortcutTypes = Assembly.GetAssembly(type).GetTypes().Where(myType => myType.IsClass && type.IsAssignableFrom(myType));

            shortcuts = new List<IHierarchyShortcut>();
            foreach (Type shortcutType in shortcutTypes)
            {
                IHierarchyShortcut hierarchyShortcut = Activator.CreateInstance(shortcutType) as IHierarchyShortcut;
                shortcuts.Add(hierarchyShortcut);
            }
        }

        private static void OnShortcutCheck(int instanceID, Rect selectionRect)
        {
            GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (obj == null)
                return;

            bool isHovered = Event.current != null && selectionRect.Contains(Event.current.mousePosition);

            if (!isHovered)
                return;

            if (Event.current.type == EventType.KeyDown)
            {
                foreach (IHierarchyShortcut shortcut in shortcuts)
                {
                    if (shortcut.IsShortcutPressed())
                    {
                        shortcut.ShortcutAction(obj);
                    }
                }
            }
        }
    }
}