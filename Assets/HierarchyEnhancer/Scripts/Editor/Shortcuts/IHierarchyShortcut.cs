using UnityEngine;

namespace HierarchyEnhancer
{
	public interface IHierarchyShortcut
	{
		bool IsShortcutActive { get; }
		bool IsShortcutPressed { get; }
		void ShortcutAction(GameObject obj);
	}
}