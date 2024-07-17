using UnityEngine;

namespace HierarchyEnhancer
{
	public interface IHierarchyShortcut
	{
		bool IsShortcutPressed();
		void ShortcutAction(GameObject obj);
	}
}