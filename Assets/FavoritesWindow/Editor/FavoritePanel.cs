using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace FavoritesWindow
{
	[System.Serializable]
	public class FavoritePanel
	{
        [SerializeField] private List<PathObjectPair> favoritesData;
        [SerializeField] private string panelName;

        public string PanelName => panelName;

        private GUIStyle buttonStyle;

        public FavoritePanel(string panelName)
        {
            this.panelName = panelName;
            favoritesData = new List<PathObjectPair>();
        }

        public void RenamePanel(string newName)
        {
            this.panelName = newName;
        }

        public void AddFavorite(Object newFavorite, bool displayFullPath)
        {
            string path = AssetDatabase.GetAssetPath(newFavorite);
            PathObjectPair pathObjectPair = new PathObjectPair()
            {
                Path = path,
                Obj = newFavorite
            };

            if (AssetDatabase.Contains(newFavorite) && !favoritesData.Any(pathObjPair => pathObjPair.Obj == newFavorite))
            {
                favoritesData.Add(pathObjectPair);
                SortFavorites(displayFullPath);
            }
        }

        public void ClearAll()
        {
            favoritesData.Clear();
        }

        public void SortFavorites(bool displayFullPath)
        {
            favoritesData.Sort(FavoriteUtils.NameComparison(displayFullPath));
        }

        public void DrawPanel(bool displayFullPath, bool displayIcon)
        {
            buttonStyle ??= StyleUtils.GetFavoriteButtonStyle();

            for (int i = favoritesData.Count - 1; i >= 0; i--)
            {
                Object favorite = favoritesData[i].Obj;

                if (favorite == null)
                {
                    favorite = AssetDatabase.LoadAssetAtPath<Object>(favoritesData[i].Path);
                    if (favorite != null)
                    {
                        favoritesData[i].Obj = favorite;
                    }
                    else
                    {
                        favoritesData.RemoveAt(i);
                        continue;
                    }
                }

                EditorGUILayout.BeginHorizontal();

                string assetPath = AssetDatabase.GetAssetPath(favorite);
                GUIContent gUIContent = new GUIContent(displayFullPath ? assetPath : favorite.name);
                if (displayIcon)
                    gUIContent.image = AssetPreview.GetMiniThumbnail(favorite);

                using (var iconSizeScope = new EditorGUIUtility.IconSizeScope(new Vector2(16, 16)))
                {
                    if (GUILayout.Button(gUIContent, buttonStyle))
                    {
                        if (AssetDatabase.IsValidFolder(assetPath))
                            AssetDatabase.OpenAsset(favorite);
                        else
                            EditorGUIUtility.PingObject(favorite);
                    }
                }

                if (GUILayout.Button("X", GUILayout.Width(StyleUtils.FAVORITE_BUTTON_HEIGHT), GUILayout.ExpandWidth(false), GUILayout.Height(StyleUtils.FAVORITE_BUTTON_HEIGHT)))
                {
                    favoritesData.RemoveAt(i);
                }

                EditorGUILayout.EndHorizontal();
            }
        }
    }
}