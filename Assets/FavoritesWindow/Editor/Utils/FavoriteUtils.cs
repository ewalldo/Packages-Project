using UnityEditor;
using UnityEngine;

namespace FavoritesWindow
{
	public static class FavoriteUtils
	{
		public static System.Comparison<PathObjectPair> NameComparison(bool sortByFullPath)
		{
			if (sortByFullPath)
				return (PathObjectPair x, PathObjectPair y) => y.Path.CompareTo(x.Path);
			else
				return (PathObjectPair x, PathObjectPair y) =>
				{
					if (y.Obj == null || x.Obj == null)
						return y.Path.CompareTo(x.Path);

					return y.Obj.name.CompareTo(x.Obj.name);
				};
		}
	}
}