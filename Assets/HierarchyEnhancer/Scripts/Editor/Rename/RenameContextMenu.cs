using UnityEngine;
using UnityEditor;

namespace HierarchyEnhancer
{
	public class RenameContextMenu : Editor
	{
        private const string renamePath = "GameObject/Rename (HierarchyEnhancer)";

        [MenuItem(renamePath, false, 0)]
        private static void RenameSelected(MenuCommand menuCommand)
        {
            EditorWindow window = EditorWindow.GetWindow<RenameHierarchyWindow>("Hierarchy Renaming");
            window.minSize = new Vector2(300, 300);
            window.ShowUtility();
        }
    }
}