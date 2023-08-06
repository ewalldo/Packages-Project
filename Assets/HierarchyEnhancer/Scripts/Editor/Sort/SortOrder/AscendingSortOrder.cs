using System;
using System.Linq;
using UnityEngine;

namespace HierarchyEnhancer
{
	public class AscendingSortOrder : ISortOrder
	{
        public SortOrderEnum GetSortOrder => SortOrderEnum.Ascending;

        public Transform[] SortObjects<T>(Transform[] transforms, Func<Transform, T> keySelector)
        {
            return transforms.OrderBy(keySelector).ToArray();
        }
    }
}