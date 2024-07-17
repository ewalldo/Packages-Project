using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
    public class SetActiveShortcut : IHierarchyShortcut
    {
        public bool IsShortcutPressed()
        {
            return Event.current.keyCode == KeyCode.A && Event.current.modifiers == EventModifiers.None;
        }

        public void ShortcutAction(GameObject obj)
        {
            Undo.RecordObject(obj, "Toggle Active Status");
            obj.SetActive(!obj.activeSelf);
            Event.current.Use();
        }
    }
}