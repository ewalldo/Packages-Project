using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
    public class IsolateShortcut : IHierarchyShortcut
    {
        public bool IsShortcutActive => EditorPrefs.GetBool(ShortcutSettings.SHORTCUTS_ACTIVE_ISOLATE_PREFS_NAME, true);

        public bool IsShortcutPressed => Event.current.keyCode == KeyCode.I && Event.current.modifiers == EventModifiers.None;

        public void ShortcutAction(GameObject obj)
        {
            if (SceneVisibilityManager.instance.IsCurrentStageIsolated())
                return;

            Selection.activeGameObject = obj;
            SceneVisibilityManager.instance.Isolate(obj, true);
            Event.current.Use();
        }
    }
}