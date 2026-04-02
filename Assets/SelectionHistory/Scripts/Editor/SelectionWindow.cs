using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace SelectionHistory
{
	public class SelectionWindow : EditorWindow
	{
        private List<Object> selectionHistory = new List<Object>();

        private int historyLength;
        private bool displayIcons;
        private bool registerHierarchyWindow;
        private bool registerProjectWindow;

        private bool displaySettings = false;

        private Vector2 scrollPos;

        private GUIStyle buttonStyle;
        private GUIStyle nullStyle;

        private static readonly string SETTINGS_KEY = "SelectionHistorySettings";
        private static readonly float SETTING_LABEL_WIDTH = 175;

        [MenuItem("Window/General/Selection History")]
        public static void ShowWindow()
        {
            Texture windowIcon = StyleUtils.LoadIcon();
            SelectionWindow window = GetWindow<SelectionWindow>();
            window.titleContent = new GUIContent("Selection History", windowIcon);
        }

        private void OnEnable()
        {
            LoadSettings();
            Selection.selectionChanged -= AddToSelectionHistory;
            Selection.selectionChanged += AddToSelectionHistory;
        }

        private void OnDisable()
        {
            SaveSettings();
            Selection.selectionChanged -= AddToSelectionHistory;
        }

        private void OnGUI()
        {
            GUILayout.Space(5);
            GUILayout.Label("Selection History", EditorStyles.centeredGreyMiniLabel);

            scrollPos = GUILayout.BeginScrollView(scrollPos);
            DrawHistory(displayIcons);
            GUILayout.EndScrollView();

            DrawFooter();

            if (displaySettings)
                DrawSettings();
        }

        private void AddToSelectionHistory()
        {
            Object selectedObject = Selection.activeObject;

            if (selectedObject == null || selectedObject.GetType() == typeof(DefaultAsset))
                return;

            bool isPersistent = EditorUtility.IsPersistent(selectedObject);
            if (isPersistent && !registerProjectWindow)
                return;

            if (!isPersistent && !registerHierarchyWindow)
                return;

            if (selectionHistory.Contains(selectedObject))
                selectionHistory.Remove(selectedObject);

            selectionHistory.Insert(0, selectedObject);

            if (selectionHistory.Count > historyLength)
                selectionHistory.RemoveAt(selectionHistory.Count - 1);

            if (hasFocus)
                this.Repaint();
        }

        public void DrawHistory(bool displayIcon)
        {
            buttonStyle ??= StyleUtils.GetSelectionButtonStyle();
            nullStyle ??= StyleUtils.GetNullObjectStyle();

            foreach (Object selected in selectionHistory)
            {
                if (selected == null)
                {
                    GUILayout.Label("File not found!", nullStyle);
                    continue;
                }

                GUIContent gUIContent = new GUIContent(selected.name);
                if (displayIcon)
                    gUIContent.image = AssetPreview.GetMiniThumbnail(selected);

                using (var iconSizeScope = new EditorGUIUtility.IconSizeScope(new Vector2(16, 16)))
                {
                    if (GUILayout.Button(gUIContent, buttonStyle))
                        EditorGUIUtility.PingObject(selected);
                }
            }
        }

        private void DrawFooter()
        {
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Clear"))
                selectionHistory.Clear();

            if (GUILayout.Button(displaySettings ? "Hide settings" : "Display settings"))
                displaySettings = !displaySettings;

            EditorGUILayout.EndHorizontal();
        }

        private void DrawSettings()
        {
            GUILayout.Space(5);
            GUILayout.Label("Settings", EditorStyles.centeredGreyMiniLabel);

            EditorGUI.BeginChangeCheck();
            historyLength = DrawDelayedIntSetting("Selection History Length:", historyLength);
            if (EditorGUI.EndChangeCheck())
            {
                if (historyLength < 0)
                    historyLength = 0;

                while (selectionHistory.Count > historyLength)
                    selectionHistory.RemoveAt(selectionHistory.Count - 1);
            }

            displayIcons = DrawBooleanSetting("Display Icons?", displayIcons);
            registerHierarchyWindow = DrawBooleanSetting("Register hierarchy selection?", registerHierarchyWindow);
            registerProjectWindow = DrawBooleanSetting("Register project selection?", registerProjectWindow);
        }

        private int DrawDelayedIntSetting(string label, int value)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, GUILayout.Width(SETTING_LABEL_WIDTH));
            value = EditorGUILayout.DelayedIntField(value, GUILayout.MaxWidth(50));
            EditorGUILayout.EndHorizontal();

            return value;
        }

        private bool DrawBooleanSetting(string label, bool value)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, GUILayout.Width(SETTING_LABEL_WIDTH));
            value = EditorGUILayout.Toggle(value);
            EditorGUILayout.EndHorizontal();

            return value;
        }

        private void LoadSettings()
        {
            string jsonData = EditorPrefs.GetString(SETTINGS_KEY + PlayerSettings.productGUID.ToString(), string.Empty);

            SelectionSettings selectionSettings = new SelectionSettings();

            if (!string.IsNullOrEmpty(jsonData))
                selectionSettings = JsonUtility.FromJson<SelectionSettings>(jsonData);

            historyLength = selectionSettings.HistoryLength;
            displayIcons = selectionSettings.DisplayIcons;
            registerHierarchyWindow = selectionSettings.RegisterHierarchyWindow;
            registerProjectWindow = selectionSettings.RegisterProjectWindow;
        }

        private void SaveSettings()
        {
            SelectionSettings selectionSettings = new SelectionSettings(historyLength, displayIcons, registerHierarchyWindow, registerProjectWindow);
            string jsonData = JsonUtility.ToJson(selectionSettings);
            EditorPrefs.SetString(SETTINGS_KEY + PlayerSettings.productGUID.ToString(), jsonData);
        }
    }
}