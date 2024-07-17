using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
    public class SetFocusShortcut : IHierarchyShortcut
    {
        public bool IsShortcutPressed()
        {
            return Event.current.keyCode == KeyCode.F && Event.current.modifiers == EventModifiers.None;
        }

        public void ShortcutAction(GameObject obj)
        {
            Selection.activeGameObject = obj;
            SceneView.lastActiveSceneView.FrameSelected();
            Event.current.Use();
        }
    }
}