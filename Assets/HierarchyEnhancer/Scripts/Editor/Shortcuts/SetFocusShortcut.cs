using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
    public class SetFocusShortcut : IHierarchyShortcut
    {
        public bool IsShortcutActive => EditorPrefs.GetBool(ShortcutSettings.SHORTCUTS_ACTIVE_SET_FOCUS_PREFS_NAME, true);

        public bool IsShortcutPressed => Event.current.keyCode == KeyCode.F && Event.current.modifiers == EventModifiers.None;

        public void ShortcutAction(GameObject obj)
        {
            Selection.activeGameObject = obj;
            SceneView.lastActiveSceneView.FrameSelected();
            Event.current.Use();
        }
    }
}