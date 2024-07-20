using System.Linq;
using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
	public class ChildrenRenameTarget : IRenameTarget
	{
        public RenameTargetEnum GetRenameTarget => RenameTargetEnum.Children;

        public void RenameSelected(GameObject[] selectedGameObjects, IRenameAffix renameAffix, string baseName, int initialIdx, int minNumberOfDigits, string template)
        {
            for (int i = 0; i < selectedGameObjects.Length; i++)
            {
                Transform[] childObjects = selectedGameObjects[i].transform.Cast<Transform>().ToArray();

                if (childObjects.Length <= 0)
                    return;

                Undo.SetCurrentGroupName("Rename children");

                int index = initialIdx;
                foreach (Transform transform in childObjects)
                {
                    string newName = renameAffix.GetNewName(baseName, template.Replace("x", index.ToString($"D{minNumberOfDigits}")));
                    Undo.RegisterCompleteObjectUndo(transform.gameObject, $"Rename object");
                    transform.gameObject.name = newName;
                    index++;
                }
                Undo.CollapseUndoOperations(Undo.GetCurrentGroup());
            }
        }
    }
}