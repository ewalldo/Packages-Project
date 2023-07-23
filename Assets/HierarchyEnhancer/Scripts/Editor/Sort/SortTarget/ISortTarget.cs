using UnityEngine;

namespace HierarchyEnhancer
{
	public interface ISortTarget
	{
		SortTargetEnum GetSortTarget { get; }
		void SortSelected(GameObject[] selectedGameObjects, ISortMode sortMode, ISortOrder sortOrder);
	}
}