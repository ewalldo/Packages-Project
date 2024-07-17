using UnityEngine;

namespace HierarchyEnhancer
{
	public class ExpandCollapseShortcut : IHierarchyShortcut
    {
        public bool IsShortcutPressed()
        {
            return Event.current.keyCode == KeyCode.C && Event.current.modifiers == EventModifiers.None;
        }

        public void ShortcutAction(GameObject obj)
        {
            int instanceID = obj.GetInstanceID();
            bool isExpanded = SceneHierarchyUtility.GetExpanded(instanceID);
            SceneHierarchyUtility.SetExpanded(instanceID, !isExpanded);
            Event.current.Use();
        }
    }
}