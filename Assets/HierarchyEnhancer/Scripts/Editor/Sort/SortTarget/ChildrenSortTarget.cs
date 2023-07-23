using System.Linq;
using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
	public class ChildrenSortTarget : ISortTarget
	{
        public SortTargetEnum GetSortTarget => SortTargetEnum.Children;

        public void SortSelected(GameObject[] selectedGameObjects, ISortMode sortMode, ISortOrder sortOrder)
        {
            for (int i = 0; i < selectedGameObjects.Length; i++)
            {
                Transform[] childObjects = selectedGameObjects[i].transform.Cast<Transform>().ToArray();

                if (childObjects.Length <= 1)
                    continue;

                Transform[] sortedTransforms = sortMode.SortObjects(childObjects, sortOrder);

                int index = 0;
                foreach (Transform transform in sortedTransforms)
                {
                    Undo.RegisterCompleteObjectUndo(transform.root, "Sort children");
                    transform.SetSiblingIndex(index);
                    index++;
                }
                Undo.CollapseUndoOperations(Undo.GetCurrentGroup());
            }
        }
    }
}