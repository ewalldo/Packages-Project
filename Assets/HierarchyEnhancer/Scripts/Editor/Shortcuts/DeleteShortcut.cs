using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
	public class DeleteShortcut : IHierarchyShortcut
	{
        public bool IsShortcutPressed()
        {
            return Event.current.keyCode == KeyCode.X && Event.current.modifiers == EventModifiers.Shift;
        }

        public void ShortcutAction(GameObject obj)
        {
            Undo.DestroyObjectImmediate(obj);
            Event.current.Use();
        }
    }
}