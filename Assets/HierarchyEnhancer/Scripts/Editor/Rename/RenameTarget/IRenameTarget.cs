using UnityEngine;

namespace HierarchyEnhancer
{
	public interface IRenameTarget
	{
		RenameTargetEnum GetRenameTarget { get; }
		void RenameSelected(GameObject[] selectedGameObjects, IRenameAffix renameAffix, string baseName, int initialIdx, int minNumberOfDigits, string template);
	}
}