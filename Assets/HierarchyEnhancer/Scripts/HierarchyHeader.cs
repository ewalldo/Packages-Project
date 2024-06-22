using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HierarchyEnhancer
{
	public class HierarchyHeader : MonoBehaviour
	{
        [SerializeField] private Color headerColor = Color.red;
        [SerializeField] [Range(3, 12)] private int fontSize = 12;
        [SerializeField] private Color fontColor = Color.white;
        [SerializeField] private TextAnchor textAnchor = TextAnchor.MiddleCenter;
        [SerializeField] private FontStyle fontStyle = FontStyle.Bold;

        public Color GetHeaderColor => headerColor;
        public int GetFontSize => fontSize;
        public Color GetFontColor => fontColor;
        public TextAnchor GetTextAnchor => textAnchor;
        public FontStyle GetFontStyle => fontStyle;

#if UNITY_EDITOR
        private void OnValidate()
        {
            EditorApplication.delayCall -= UpdateHierarchy;
            EditorApplication.delayCall += UpdateHierarchy;
        }

        private void UpdateHierarchy()
        {
            if (!this)
                return;

            EditorApplication.RepaintHierarchyWindow();
        }

        [MenuItem("GameObject/Header", false, 0)]
        static void CreateHeaderGameObject(MenuCommand menuCommand)
        {
            GameObject obj = new GameObject("HEADER");

            GameObjectUtility.SetParentAndAlign(obj, menuCommand.context as GameObject);

            Undo.RegisterCreatedObjectUndo(obj, "Create Header");
            obj.AddComponent<HierarchyHeader>();

            Selection.activeObject = obj;
        }
#endif
    }
}