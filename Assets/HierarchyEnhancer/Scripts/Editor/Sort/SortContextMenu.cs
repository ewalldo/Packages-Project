using UnityEngine;
using UnityEditor;

namespace HierarchyEnhancer
{
	public class SortContextMenu : Editor
	{
        private const string sortPath = "GameObject/Sort";

        [MenuItem(sortPath, false, 0)]
        private static void SortSelectedByName(MenuCommand menuCommand)
        {
            EditorWindow window = EditorWindow.GetWindow<SortHierarchyWindow>("Hierarchy Sorting");
            window.minSize = new Vector2(300, 100);
            window.ShowUtility();
        }
    }
}