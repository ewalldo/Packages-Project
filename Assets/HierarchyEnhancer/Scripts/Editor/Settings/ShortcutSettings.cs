using UnityEditor;
using UnityEngine;

namespace HierarchyEnhancer
{
	public class ShortcutSettings
	{
        public const string SHORTCUTS_ACTIVE_ALL_PREFS_NAME = "shortcutsAllActive";
        public const string SHORTCUTS_ACTIVE_DELETE_PREFS_NAME = "shortcutsDeleteActive";
        public const string SHORTCUTS_ACTIVE_EXPAND_COLLAPSE_PREFS_NAME = "shortcutsExpandCollapseActive";
        public const string SHORTCUTS_ACTIVE_HIDE_UNHIDE_PREFS_NAME = "shortcutsHideUnhideActive";
        public const string SHORTCUTS_ACTIVE_ISOLATE_PREFS_NAME = "shortcutsIsolateActive";
        public const string SHORTCUTS_ACTIVE_SET_ACTIVE_PREFS_NAME = "shortcutsSetActiveActive";
        public const string SHORTCUTS_ACTIVE_SET_FOCUS_PREFS_NAME = "shortcutsSetFocusActive";

        public void DrawSettings()
        {
            EditorGUILayout.LabelField("<color=white>Shortcuts Settings: </color>", new GUIStyle { fontStyle = FontStyle.Bold });

            EditorGUI.BeginChangeCheck();
            bool isShortcutsActive = EditorPrefs.GetBool(SHORTCUTS_ACTIVE_ALL_PREFS_NAME, true);
            isShortcutsActive = EditorGUILayout.ToggleLeft("Activate shortcuts?", isShortcutsActive);
            EditorPrefs.SetBool(SHORTCUTS_ACTIVE_ALL_PREFS_NAME, isShortcutsActive);
            if (EditorGUI.EndChangeCheck())
            {
                EditorPrefs.SetBool(SHORTCUTS_ACTIVE_DELETE_PREFS_NAME, isShortcutsActive);
                EditorPrefs.SetBool(SHORTCUTS_ACTIVE_EXPAND_COLLAPSE_PREFS_NAME, isShortcutsActive);
                EditorPrefs.SetBool(SHORTCUTS_ACTIVE_SET_ACTIVE_PREFS_NAME, isShortcutsActive);
                EditorPrefs.SetBool(SHORTCUTS_ACTIVE_SET_FOCUS_PREFS_NAME, isShortcutsActive);
            }

            EditorGUI.indentLevel++;
            EditorGUI.BeginDisabledGroup(!isShortcutsActive);

            bool isDeleteShortcutActive = EditorPrefs.GetBool(SHORTCUTS_ACTIVE_DELETE_PREFS_NAME, true);
            isDeleteShortcutActive = EditorGUILayout.ToggleLeft("Delete shortcut (Shift + X)", isDeleteShortcutActive);
            EditorPrefs.SetBool(SHORTCUTS_ACTIVE_DELETE_PREFS_NAME, isDeleteShortcutActive);

            bool isExpandCollapseShortcutActive = EditorPrefs.GetBool(SHORTCUTS_ACTIVE_EXPAND_COLLAPSE_PREFS_NAME, true);
            isExpandCollapseShortcutActive = EditorGUILayout.ToggleLeft("Expand/Collapse shortcut (C)", isExpandCollapseShortcutActive);
            EditorPrefs.SetBool(SHORTCUTS_ACTIVE_EXPAND_COLLAPSE_PREFS_NAME, isExpandCollapseShortcutActive);

            bool isHideUnhideShortcutActive = EditorPrefs.GetBool(SHORTCUTS_ACTIVE_HIDE_UNHIDE_PREFS_NAME, true);
            isHideUnhideShortcutActive = EditorGUILayout.ToggleLeft("Hide/unhide shortcut (H)", isHideUnhideShortcutActive);
            EditorPrefs.SetBool(SHORTCUTS_ACTIVE_HIDE_UNHIDE_PREFS_NAME, isHideUnhideShortcutActive);

            bool isIsolateShortcutActive = EditorPrefs.GetBool(SHORTCUTS_ACTIVE_ISOLATE_PREFS_NAME, true);
            isIsolateShortcutActive = EditorGUILayout.ToggleLeft("Isolate shortcut (I)", isIsolateShortcutActive);
            EditorPrefs.SetBool(SHORTCUTS_ACTIVE_ISOLATE_PREFS_NAME, isIsolateShortcutActive);

            bool isSetActiveShortcutActive = EditorPrefs.GetBool(SHORTCUTS_ACTIVE_SET_ACTIVE_PREFS_NAME, true);
            isSetActiveShortcutActive = EditorGUILayout.ToggleLeft("Set active shortcut (A)", isSetActiveShortcutActive);
            EditorPrefs.SetBool(SHORTCUTS_ACTIVE_SET_ACTIVE_PREFS_NAME, isSetActiveShortcutActive);

            bool isSetFocusShortcutActive = EditorPrefs.GetBool(SHORTCUTS_ACTIVE_SET_FOCUS_PREFS_NAME, true);
            isSetFocusShortcutActive = EditorGUILayout.ToggleLeft("Focus shortcut (F)", isSetFocusShortcutActive);
            EditorPrefs.SetBool(SHORTCUTS_ACTIVE_SET_FOCUS_PREFS_NAME, isSetFocusShortcutActive);

            EditorGUI.EndDisabledGroup();
            EditorGUI.indentLevel--;
        }

        public void Reset()
        {
            EditorPrefs.SetBool(SHORTCUTS_ACTIVE_ALL_PREFS_NAME, true);
            EditorPrefs.SetBool(SHORTCUTS_ACTIVE_DELETE_PREFS_NAME, true);
            EditorPrefs.SetBool(SHORTCUTS_ACTIVE_EXPAND_COLLAPSE_PREFS_NAME, true);
            EditorPrefs.SetBool(SHORTCUTS_ACTIVE_HIDE_UNHIDE_PREFS_NAME, true);
            EditorPrefs.SetBool(SHORTCUTS_ACTIVE_ISOLATE_PREFS_NAME, true);
            EditorPrefs.SetBool(SHORTCUTS_ACTIVE_SET_ACTIVE_PREFS_NAME, true);
            EditorPrefs.SetBool(SHORTCUTS_ACTIVE_SET_FOCUS_PREFS_NAME, true);
        }
    }
}