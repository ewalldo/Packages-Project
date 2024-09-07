using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
    public class SetActiveShortcut : IHierarchyShortcut
    {
        public bool IsShortcutActive => EditorPrefs.GetBool(ShortcutSettings.SHORTCUTS_ACTIVE_SET_ACTIVE_PREFS_NAME, true);

        public bool IsShortcutPressed => Event.current.keyCode == KeyCode.A && Event.current.modifiers == EventModifiers.None;

        public void ShortcutAction(GameObject obj)
        {
            Undo.RecordObject(obj, "Toggle Active Status");
            obj.SetActive(!obj.activeSelf);
            Event.current.Use();
        }
    }
}