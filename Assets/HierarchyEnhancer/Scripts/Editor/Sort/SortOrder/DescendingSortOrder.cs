using System;
using System.Linq;
using UnityEngine;

namespace HierarchyEnhancer
{
	public class DescendingSortOrder : ISortOrder
	{
        public SortOrderEnum GetSortOrder => SortOrderEnum.Descending;

        public Transform[] SortObjects<T>(Transform[] transforms, Func<Transform, T> keySelector)
        {
            return transforms.OrderByDescending(keySelector).ToArray();
        }
    }
}