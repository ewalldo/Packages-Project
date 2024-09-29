using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
	public class DeleteShortcut : IHierarchyShortcut
	{
        public bool IsShortcutActive => EditorPrefs.GetBool(ShortcutSettings.SHORTCUTS_ACTIVE_DELETE_PREFS_NAME, true);

        public bool IsShortcutPressed => Event.current.keyCode == KeyCode.X && Event.current.modifiers == EventModifiers.Shift;

        public void ShortcutAction(GameObject obj)
        {
            Undo.DestroyObjectImmediate(obj);
            Event.current.Use();
        }
    }
}