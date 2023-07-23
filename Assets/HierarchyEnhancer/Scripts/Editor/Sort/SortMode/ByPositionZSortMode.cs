using UnityEngine;

namespace HierarchyEnhancer
{
	public class ByPositionZSortMode : ISortMode
	{
        public SortModeEnum GetSortMode => SortModeEnum.ByPositionZ;

        public Transform[] SortObjects(Transform[] transforms, ISortOrder sortOrder)
        {
            return sortOrder.SortObjects(transforms, t => t.position.z);
        }
    }
}