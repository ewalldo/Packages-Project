using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
    public class SetFocusShortcut : IHierarchyShortcut
    {
        public KeyCode GetShortcutKeyCode => KeyCode.F;

        public void ShortcutAction(GameObject obj)
        {
            Selection.activeGameObject = obj;
            SceneView.lastActiveSceneView.FrameSelected();
            Event.current.Use();
        }
    }
}