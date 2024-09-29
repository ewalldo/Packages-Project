using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
	public class SelectedOnlyRenameTarget : IRenameTarget
	{
        public RenameTargetEnum GetRenameTarget => RenameTargetEnum.SelectedOnly;

        public void RenameSelected(GameObject[] selectedGameObjects, IRenameAffix renameAffix, string baseName, int initialIdx, int minNumberOfDigits, string template)
        {
            if (selectedGameObjects.Length <= 0)
                return;

            Undo.SetCurrentGroupName("Rename selected");

            int index = initialIdx;
            foreach (GameObject gameObject in selectedGameObjects)
            {
                string newName = renameAffix.GetNewName(baseName, template.Replace("x", index.ToString($"D{minNumberOfDigits}")));
                Undo.RegisterCompleteObjectUndo(gameObject, $"Rename object");
                gameObject.name = newName;
                index++;
            }
            Undo.CollapseUndoOperations(Undo.GetCurrentGroup());
        }
    }
}