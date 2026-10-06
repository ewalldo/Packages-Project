using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace BehaviorTree.Editor
{
    [CustomEditor(typeof(BehaviorTreeRunner), true)]
    public class BehaviorTreeRunnerEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();
            InspectorElement.FillDefaultInspector(root, serializedObject, this);

            Button openViewerButton = new Button(OpenViewer) { text = "Open Tree Viewer" };
            openViewerButton.style.marginTop = 8;
            root.Add(openViewerButton);

            return root;
        }

        /// <summary>Opens a tree viewer window for the currently inspected agent.</summary>
        private void OpenViewer()
        {
            BehaviorTreeViewerWindow.Open((BehaviorTreeRunner)target);
        }
    }
}