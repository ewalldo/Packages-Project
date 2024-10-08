using UnityEditor;
using UnityEngine;

namespace FavoritesWindow
{
	public static class StyleUtils
	{
		private const string DARK_MODE_ICON = "d_favoritesWindowStar";
		private const string LIGHT_MODE_ICON = "favoritesWindowStar";

		public static float FAVORITE_BUTTON_HEIGHT => EditorGUIUtility.singleLineHeight + 10f;

		public static Texture LoadIcon()
        {
			return Resources.Load<Texture>(EditorGUIUtility.isProSkin ? DARK_MODE_ICON : LIGHT_MODE_ICON);
		}

		public static GUIStyle GetFavoriteButtonStyle()
        {
			return new GUIStyle(GUI.skin.button)
			{
				alignment = TextAnchor.MiddleLeft,
				padding = new RectOffset(5, 0, 5, 5),
				fixedHeight = FAVORITE_BUTTON_HEIGHT
			};
		}
	}
}