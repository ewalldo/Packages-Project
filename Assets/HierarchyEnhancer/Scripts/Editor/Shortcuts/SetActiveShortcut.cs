using UnityEngine;

namespace HierarchyEnhancer
{
    public class SetActiveShortcut : IHierarchyShortcut
    {
        public KeyCode GetShortcutKeyCode => KeyCode.A;

        public void ShortcutAction(GameObject obj)
        {
            obj.SetActive(!obj.activeSelf);
            Event.current.Use();
        }
    }
}