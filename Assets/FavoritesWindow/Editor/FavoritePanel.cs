using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FavoritesWindow
{
	[System.Serializable]
	public class FavoritePanel
	{
        [SerializeField] private List<string> favoritesData;
        [SerializeField] private string panelName;

        public List<Object> Favorites { get; private set; }
        public string PanelName => panelName;

        private GUIStyle buttonStyle;

        public FavoritePanel(string panelName)
        {
            this.panelName = panelName;
            Favorites = new List<Object>();
        }

        public void RenamePanel(string newName)
        {
            this.panelName = newName;
        }

        public void AddFavorite(Object newFavorite, bool displayFullPath)
        {
            if (!Favorites.Contains(newFavorite) && AssetDatabase.Contains(newFavorite))
            {
                Favorites.Add(newFavorite);
                SortFavorites(displayFullPath);
            }
        }

        public void ClearAll()
        {
            Favorites.Clear();
        }

        public void SortFavorites(bool displayFullPath)
        {
            Favorites.Sort(FavoriteUtils.NameComparison(displayFullPath));
        }

        public void DrawPanel(bool displayFullPath, bool displayIcon)
        {
            buttonStyle ??= StyleUtils.GetFavoriteButtonStyle();

            for (int i = Favorites.Count - 1; i >= 0; i--)
            {
                Object favorite = Favorites[i];

                if (favorite == null)
                {
                    Favorites.RemoveAt(i);
                    continue;
                }

                EditorGUILayout.BeginHorizontal();

                string assetPath = AssetDatabase.GetAssetPath(favorite);
                GUIContent gUIContent = new GUIContent(displayFullPath ? assetPath : favorite.name);
                if (displayIcon)
                    gUIContent.image = AssetPreview.GetMiniThumbnail(favorite);

                if (GUILayout.Button(gUIContent, buttonStyle))
                {
                    if (AssetDatabase.IsValidFolder(assetPath))
                        AssetDatabase.OpenAsset(favorite);
                    else
                        EditorGUIUtility.PingObject(favorite);
                }

                if (GUILayout.Button("X", GUILayout.Width(StyleUtils.FAVORITE_BUTTON_HEIGHT), GUILayout.ExpandWidth(false), GUILayout.Height(StyleUtils.FAVORITE_BUTTON_HEIGHT)))
                {
                    Favorites.RemoveAt(i);
                }

                EditorGUILayout.EndHorizontal();
            }
        }

        public void SaveData()
        {
            favoritesData = new List<string>();

            foreach (Object obj in Favorites)
            {
                favoritesData.Add(AssetDatabase.GetAssetPath(obj));
            }
        }

        public void LoadData()
        {
            Favorites = new List<Object>();

            foreach (string path in favoritesData)
            {
                Favorites.Add(AssetDatabase.LoadAssetAtPath<Object>(path));
            }
        }
    }
}