using UnityEngine;

namespace HierarchyEnhancer
{
	public interface ISortMode
	{
		SortModeEnum GetSortMode { get; }
		Transform[] SortObjects(Transform[] transforms, ISortOrder sortOrder);
	}
}