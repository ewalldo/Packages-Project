using UnityEngine;

namespace LootSystem
{
	public static class StyleUtils
	{
		public static GUIStyle GetSmallHeaderStyle()
        {
			return new GUIStyle
			{
				alignment = TextAnchor.MiddleCenter,
				fontSize = 10,
				richText = true
			};
		}

		public static GUIStyle GetBigHeaderStyle()
        {
			return new GUIStyle
			{
				alignment = TextAnchor.MiddleCenter,
				fontSize = 20,
				richText = true
			};
		}
	}
}