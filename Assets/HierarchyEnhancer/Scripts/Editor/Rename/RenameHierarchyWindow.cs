using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

namespace HierarchyEnhancer
{
	public class RenameHierarchyWindow : EditorWindow
	{
        private RenameTargetEnum renameTargetEnum;
        private RenameAffixEnum renameAffixEnum;

        private string baseName = "baseName";
        private int startValue;
        private int minNumberOfDigits = 1;
        private string template = "_(x)";

        private string previewString;

        private void OnEnable()
        {
            GeneratePreviewString();
        }

        private void OnGUI()
        {
            EditorGUI.BeginChangeCheck();

            renameTargetEnum = (RenameTargetEnum)EditorGUILayout.EnumPopup("Rename target", renameTargetEnum);
            renameAffixEnum = (RenameAffixEnum)EditorGUILayout.EnumPopup("Rename affix", renameAffixEnum);

            EditorGUILayout.Space(10);

            baseName = EditorGUILayout.TextField("Base name", baseName);
            startValue = EditorGUILayout.IntField("Start value", startValue);
            minNumberOfDigits = EditorGUILayout.IntField("Minimum number of digits", minNumberOfDigits);
            template = EditorGUILayout.TextField("Affix template", template);

            if (EditorGUI.EndChangeCheck())
            {
                minNumberOfDigits = Math.Max(1, minNumberOfDigits);

                if (IsValidTemplate())
                    GeneratePreviewString();
            }

            EditorGUILayout.Space(20);

            bool isValidTemplate = IsValidTemplate();

            EditorGUILayout.LabelField("Preview: ", isValidTemplate ? previewString : "INVALID TEMPLATE");

            if (!isValidTemplate)
            {
                EditorGUILayout.LabelField("<color=red>Template must contain exactly ONE 'x' character</color>", new GUIStyle
                {
                    alignment = TextAnchor.MiddleCenter,
                    fontSize = 14,
                    richText = true
                });
            }

            EditorGUILayout.Space(20);

            EditorGUILayout.BeginHorizontal();

            EditorGUI.BeginDisabledGroup(!isValidTemplate);

            if (GUILayout.Button("Rename objects"))
            {
                if (Selection.activeGameObject == null)
                {
                    Debug.LogWarning("No object selected in the hierarchy!");
                }
                else
                {
                    Rename();
                    Close();
                }
            }

            EditorGUI.EndDisabledGroup();

            if (GUILayout.Button("Cancel"))
            {
                Close();
            }

            EditorGUILayout.EndHorizontal();
        }

        private void Rename()
        {
            IRenameTarget renameTarget = RenameFactory.GetRenameTarget(renameTargetEnum);
            IRenameAffix renameAffix = RenameFactory.GetRenameAffix(renameAffixEnum);

            renameTarget?.RenameSelected(GetOrderedSelectedGameobjects(), renameAffix, baseName, startValue, minNumberOfDigits, template);
        }

        private void GeneratePreviewString()
        {
            IRenameAffix renameAffix = RenameFactory.GetRenameAffix(renameAffixEnum);

            previewString = renameAffix.GetNewName(baseName, template.Replace("x", startValue.ToString($"D{minNumberOfDigits}")));
        }

        private bool IsValidTemplate()
        {
            return template.Contains('x') && template.Count(c => c == 'x') == 1;
        }

        public static GameObject[] GetOrderedSelectedGameobjects()
        {
            return Selection.objects.OfType<GameObject>().ToArray();
        }
    }
}