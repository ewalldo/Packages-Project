using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
	public class SelectedOnlySortTarget : ISortTarget
	{
        private HashSet<int> selectedTransformsIndex;
        private Transform[] selectedTransforms;
        private Transform parent;

        public SortTargetEnum GetSortTarget => SortTargetEnum.SelectedOnly;

        public void SortSelected(GameObject[] selectedGameObjects, ISortMode sortMode, ISortOrder sortOrder)
        {
            if (selectedGameObjects.Length <= 1)
                return;

            Initialize(selectedGameObjects);

            if (!IsTheSameParent())
            {
                Debug.LogError("Unable to sort selected objects: Not all selected objects have the same parent");
                return;
            }

            if (parent == null)
            {
                Debug.LogError("Unable to sort selected objects: Can't sort objects located at the top level of hierarchy");
                return;
            }

            Transform[] sortedTransforms = sortMode.SortObjects(selectedTransforms, sortOrder);

            int sortedIndex = 0;
            for (int i = 0; i < parent.childCount; i++)
            {
                Undo.RegisterCompleteObjectUndo(parent, "Sort selected");
                if (selectedTransformsIndex.Contains(i))
                {
                    sortedTransforms[sortedIndex].SetSiblingIndex(i);
                    sortedIndex++;
                }
            }
            Undo.CollapseUndoOperations(Undo.GetCurrentGroup());
        }

        private void Initialize(GameObject[] selectedGameObjects)
        {
            selectedTransformsIndex = new HashSet<int>();
            selectedTransforms = new Transform[selectedGameObjects.Length];

            for (int i = 0; i < selectedGameObjects.Length; i++)
            {
                selectedTransforms[i] = selectedGameObjects[i].transform;
                selectedTransformsIndex.Add(selectedTransforms[i].GetSiblingIndex());
            }

            parent = selectedTransforms[0].parent;
        }

        private bool IsTheSameParent()
        {
            for (int i = 0; i < selectedTransforms.Length; i++)
            {
                if (parent != selectedTransforms[i].parent)
                {
                    return false;
                }
            }

            return true;
        }
    }
}