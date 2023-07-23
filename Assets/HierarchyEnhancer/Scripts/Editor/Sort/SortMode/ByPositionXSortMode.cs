using UnityEngine;

namespace HierarchyEnhancer
{
	public class ByPositionXSortMode : ISortMode
	{
        public SortModeEnum GetSortMode => SortModeEnum.ByPositionX;

        public Transform[] SortObjects(Transform[] transforms, ISortOrder sortOrder)
        {
            return sortOrder.SortObjects(transforms, t => t.position.x);
        }
    }
}