using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace FavoritesWindow
{
	public class FavoritesWindow : EditorWindow
	{
        private List<FavoritePanel> favoritePanels;

        private int currentPanel = -1;
        private bool displayFullPath;
        private bool displayIcons;

        private Vector2 scrollPos;

        [MenuItem("Window/General/Favorites")]
        public static void ShowWindow()
        {
            Texture windowIcon = StyleUtils.LoadIcon();
            FavoritesWindow window = GetWindow<FavoritesWindow>();
            window.titleContent = new GUIContent("Favorites", windowIcon);
        }

        private void OnEnable()
        {
            FavoriteSettings settings = SaveLoadUtils.LoadSettings();
            displayFullPath = settings.DisplayFullPath;
            displayIcons = settings.DisplayIcons;
            currentPanel = settings.CurrentPanel;

            favoritePanels = SaveLoadUtils.LoadFavorites(displayFullPath);
        }

        private void OnDisable()
        {
            FavoriteSettings settings = new FavoriteSettings(displayFullPath, displayIcons, currentPanel);
            SaveLoadUtils.SaveSettings(settings);

            SaveLoadUtils.SaveFavorites(favoritePanels);
        }

        private void OnGUI()
        {
            DrawHeader();
            if (!IsValidIndex)
            {
                EditorGUILayout.LabelField("No favorite panel found, please create a new one.", EditorStyles.boldLabel); ;
                return;
            }
            DrawPanel();
            DrawFooter();
        }

        private void DrawHeader()
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUI.BeginChangeCheck();
            currentPanel = EditorGUILayout.Popup(currentPanel, GetPanelOptions());
            if (EditorGUI.EndChangeCheck())
            {
                if (!IsValidIndex)
                {
                    EditorGUILayout.EndHorizontal();
                    return;
                }

                favoritePanels[currentPanel].SortFavorites(displayFullPath);
            }

            DrawButton("Create New Panel", CreateNewPanel);
            DrawButton("Rename Panel", RenamePanel);
            DrawButton("Delete Panel", DeletePanel);

            EditorGUILayout.EndHorizontal();
        }

        private void DrawPanel()
        {
            GUILayout.Label(favoritePanels[currentPanel].PanelName, EditorStyles.centeredGreyMiniLabel);
            scrollPos = GUILayout.BeginScrollView(scrollPos);
            favoritePanels[currentPanel].DrawPanel(displayFullPath, displayIcons);
            DrawDragArea();
            GUILayout.EndScrollView();
        }

        private void DrawDragArea()
        {
            GUILayout.Space(5);
            GUILayout.Label("Drag & Drop Area", EditorStyles.centeredGreyMiniLabel);

            Event evt = Event.current;
            Rect dropArea = GUILayoutUtility.GetRect(0.0f, 100.0f, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUI.Box(dropArea, "", EditorStyles.helpBox);

            switch (evt.type)
            {
                case EventType.DragUpdated:
                case EventType.DragPerform:
                    if (!dropArea.Contains(evt.mousePosition))
                        break;

                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                    if (evt.type == EventType.DragPerform)
                    {
                        DragAndDrop.AcceptDrag();

                        foreach (Object draggedObject in DragAndDrop.objectReferences)
                        {
                            favoritePanels[currentPanel].AddFavorite(draggedObject, displayFullPath);
                        }
                    }

                    Event.current.Use();
                    break;
                default:
                    break;
            }

            GUILayout.Space(5);
        }

        private void DrawFooter()
        {
            EditorGUILayout.BeginHorizontal();

            string displayFullPathButtonText = displayFullPath ? "Display file only" : "Display full path";
            DrawButton(displayFullPathButtonText, () =>
            {
                displayFullPath = !displayFullPath;
                favoritePanels[currentPanel].SortFavorites(displayFullPath);
            });

            string displayIconButtonText = displayIcons ? "Turn off icons" : "Turn on icons";
            DrawButton(displayIconButtonText, () =>
            {
                displayIcons = !displayIcons;
            });

            DrawButton("Clear all favorites", () =>
            {
                if (EditorUtility.DisplayDialog("Clear panel", "Are you sure you want to clear this panel?", "Yes", "No"))
                    favoritePanels[currentPanel].ClearAll();
            });

            EditorGUILayout.EndHorizontal();
        }

        private void CreateNewPanel()
        {
            TextInputPopup.Show("Create New Panel", "New Panel", newPanelName =>
            {
                if (IsUniquePanelName(newPanelName))
                {
                    FavoritePanel favoritePanel = new FavoritePanel(newPanelName);
                    favoritePanels.Add(favoritePanel);
                    currentPanel = favoritePanels.Count - 1;
                    return true;
                }
                else
                {
                    EditorUtility.DisplayDialog("Error", "A panel with that name already exists!", "OK");
                    return false;
                }
            });
            GUIUtility.ExitGUI();
        }

        private void RenamePanel()
        {
            if (!IsValidIndex)
                return;

            string currentName = favoritePanels[currentPanel].PanelName;
            TextInputPopup.Show("Rename Panel", currentName, newPanelName =>
            {
                if (IsUniquePanelName(newPanelName))
                {
                    favoritePanels[currentPanel].RenamePanel(newPanelName);
                    return true;
                }
                else
                {
                    EditorUtility.DisplayDialog("Error", "A panel with that name already exists!", "OK");
                    return false;
                }
            });
            GUIUtility.ExitGUI();
        }

        private void DeletePanel()
        {
            if (!IsValidIndex)
                return;

            if (EditorUtility.DisplayDialog("Delete panel", "Are you sure you want to delete the panel: " + favoritePanels[currentPanel].PanelName + "?", "Yes", "No"))
            {
                favoritePanels.RemoveAt(currentPanel);
                currentPanel--;

                if (currentPanel < 0 && favoritePanels.Count > 0)
                    currentPanel = favoritePanels.Count - 1;
            }
        }

        private void DrawButton(string text, System.Action onClick)
        {
            if (GUILayout.Button(text))
            {
                onClick?.Invoke();
            }
        }

        private GUIContent[] GetPanelOptions()
        {
            GUIContent[] gUIContents = new GUIContent[favoritePanels.Count];

            for (int i = 0; i < favoritePanels.Count; i++)
            {
                gUIContents[i] = new GUIContent(favoritePanels[i].PanelName);
            }

            return gUIContents;
        }

        private bool IsUniquePanelName(string nameCandidate) => !favoritePanels.Any(panel => panel.PanelName == nameCandidate);

        private bool IsValidIndex => currentPanel >= 0 && currentPanel < favoritePanels.Count;
    }
}