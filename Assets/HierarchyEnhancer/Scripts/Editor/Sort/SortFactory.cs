using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HierarchyEnhancer
{
    public static class SortFactory
	{
        private static Dictionary<SortTargetEnum, Type> sortTargetByName;
        private static Dictionary<SortModeEnum, Type> sortModeByName;
        private static Dictionary<SortOrderEnum, Type> sortOrderByName;

        static SortFactory()
        {
            IEnumerable<Type> sortTargetTypes = GetSortTypes(typeof(ISortTarget));
            IEnumerable<Type> sortModeTypes = GetSortTypes(typeof(ISortMode));
            IEnumerable<Type> sortOrderTypes = GetSortTypes(typeof(ISortOrder));

            sortTargetByName = new Dictionary<SortTargetEnum, Type>();
            sortModeByName = new Dictionary<SortModeEnum, Type>();
            sortOrderByName = new Dictionary<SortOrderEnum, Type>();

            foreach (Type type in sortTargetTypes)
            {
                ISortTarget sortTarget = Activator.CreateInstance(type) as ISortTarget;
                sortTargetByName.Add(sortTarget.GetSortTarget, type);
            }

            foreach (Type type in sortModeTypes)
            {
                ISortMode sortMode = Activator.CreateInstance(type) as ISortMode;
                sortModeByName.Add(sortMode.GetSortMode, type);
            }

            foreach (Type type in sortOrderTypes)
            {
                ISortOrder sortOrder = Activator.CreateInstance(type) as ISortOrder;
                sortOrderByName.Add(sortOrder.GetSortOrder, type);
            }
        }

        public static ISortTarget GetSortTarget(SortTargetEnum sortTargetEnum)
        {
            if (!sortTargetByName.ContainsKey(sortTargetEnum))
                return null;

            Type type = sortTargetByName[sortTargetEnum];
            ISortTarget sortTarget = Activator.CreateInstance(type) as ISortTarget;
            return sortTarget;
        }

        public static ISortMode GetSortMode(SortModeEnum sortModeEnum)
        {
            if (!sortModeByName.ContainsKey(sortModeEnum))
                return null;

            Type type = sortModeByName[sortModeEnum];
            ISortMode sortMode = Activator.CreateInstance(type) as ISortMode;
            return sortMode;
        }

        public static ISortOrder GetSortOrder(SortOrderEnum sortOrderEnum)
        {
            if (!sortOrderByName.ContainsKey(sortOrderEnum))
                return null;

            Type type = sortOrderByName[sortOrderEnum];
            ISortOrder sortOrder = Activator.CreateInstance(type) as ISortOrder;
            return sortOrder;
        }

        private static IEnumerable<Type> GetSortTypes(Type type)
        {
            IEnumerable<Type> sortTypes = Assembly.GetAssembly(type).GetTypes().Where(myType => myType.IsClass && type.IsAssignableFrom(myType));

            return sortTypes;
        }
    }
}