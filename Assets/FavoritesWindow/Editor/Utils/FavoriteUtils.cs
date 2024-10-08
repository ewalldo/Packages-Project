using UnityEditor;
using UnityEngine;

namespace FavoritesWindow
{
	public static class FavoriteUtils
	{
		public static System.Comparison<Object> NameComparison(bool sortByFullPath)
        {
			if (sortByFullPath)
				return (Object x, Object y) => AssetDatabase.GetAssetPath(y).CompareTo(AssetDatabase.GetAssetPath(x));
			else
				return (Object x, Object y) => y.name.CompareTo(x.name);
		}
	}
}