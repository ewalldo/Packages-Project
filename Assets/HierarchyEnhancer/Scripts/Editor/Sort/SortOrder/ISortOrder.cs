using System;
using UnityEngine;

namespace HierarchyEnhancer
{
	public interface ISortOrder
	{
		SortOrderEnum GetSortOrder { get; }
		Transform[] SortObjects<T>(Transform[] transforms, Func<Transform, T> keySelector);
	}
}