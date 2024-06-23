using UnityEngine;

namespace HierarchyEnhancer
{
	public interface IHierarchyShortcut
	{
		KeyCode GetShortcutKeyCode { get; }
		void ShortcutAction(GameObject obj);
	}
}