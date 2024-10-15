using UnityEditor;
using UnityEngine;

namespace SelectionHistory
{
	public static class StyleUtils
	{
		private const string DARK_MODE_ICON = "d_selectionHistoryIcon";
		private const string LIGHT_MODE_ICON = "selectionHistoryIcon";

		public static float SELECTION_BUTTON_HEIGHT => EditorGUIUtility.singleLineHeight + 10f;

		public static Texture LoadIcon()
        {
			return Resources.Load<Texture>(EditorGUIUtility.isProSkin ? DARK_MODE_ICON : LIGHT_MODE_ICON);
		}

		public static GUIStyle GetSelectionButtonStyle()
        {
			return new GUIStyle(GUI.skin.button)
			{
				alignment = TextAnchor.MiddleLeft,
				padding = new RectOffset(5, 0, 5, 5),
				fixedHeight = SELECTION_BUTTON_HEIGHT
			};
		}

		public static GUIStyle GetNullObjectStyle()
        {
			return new GUIStyle(EditorStyles.label)
			{
				alignment = TextAnchor.MiddleLeft,
				padding = new RectOffset(5, 0, 5, 5),
				normal = new GUIStyleState() { textColor = Color.red },
				fixedHeight = SELECTION_BUTTON_HEIGHT
			};
		}
	}
}