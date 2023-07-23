using UnityEngine;

namespace HierarchyEnhancer
{
	public class ByPositionYSortMode : ISortMode
	{
        public SortModeEnum GetSortMode => SortModeEnum.ByPositionY;

        public Transform[] SortObjects(Transform[] transforms, ISortOrder sortOrder)
        {
            return sortOrder.SortObjects(transforms, t => t.position.y);
        }
    }
}