using UnityEngine;

namespace HierarchyEnhancer
{
	public class ByNameSortMode : ISortMode
	{
        public SortModeEnum GetSortMode => SortModeEnum.ByName;

        public Transform[] SortObjects(Transform[] transforms, ISortOrder sortOrder)
        {
            return sortOrder.SortObjects(transforms, t => t.name);
        }
    }
}