using UnityEngine;
using UnityEditor;

namespace HierarchyEnhancer
{
	public class SortHierarchyWindow : EditorWindow
	{
        private SortTargetEnum sortTargetEnum;
        private SortModeEnum sortModeEnum;
        private SortOrderEnum sortOrderEnum;

        private void OnGUI()
        {
            sortTargetEnum = (SortTargetEnum)EditorGUILayout.EnumPopup("Sorting target", sortTargetEnum);
            sortModeEnum = (SortModeEnum)EditorGUILayout.EnumPopup("Sorting type", sortModeEnum);
            sortOrderEnum = (SortOrderEnum)EditorGUILayout.EnumPopup("Sorting order", sortOrderEnum);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Sort objects"))
            {
                if (Selection.activeGameObject == null)
                {
                    Debug.LogWarning("No object selected in the hierarchy!");
                }
                else
                {
                    Sort();
                    Close();
                }
            }

            if (GUILayout.Button("Cancel"))
            {
                Close();
            }

            EditorGUILayout.EndHorizontal();
        }

        private void Sort()
        {
            ISortMode sortMode = SortFactory.GetSortMode(sortModeEnum);
            ISortOrder sortOrder = SortFactory.GetSortOrder(sortOrderEnum);
            ISortTarget sortTarget = SortFactory.GetSortTarget(sortTargetEnum);

            sortTarget?.SortSelected(Selection.gameObjects, sortMode, sortOrder);
        }
    }
}