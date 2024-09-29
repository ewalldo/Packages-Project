using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
    public class HideUnhideShortcut : IHierarchyShortcut
    {
        public bool IsShortcutActive => EditorPrefs.GetBool(ShortcutSettings.SHORTCUTS_ACTIVE_HIDE_UNHIDE_PREFS_NAME, true);

        public bool IsShortcutPressed => Event.current.keyCode == KeyCode.H && Event.current.modifiers == EventModifiers.None;

        public void ShortcutAction(GameObject obj)
        {
            if (SceneVisibilityManager.instance.IsHidden(obj))
                SceneVisibilityManager.instance.Show(obj, true);
            else
                SceneVisibilityManager.instance.Hide(obj, true);

            Event.current.Use();
        }
    }
}