using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FavoritesWindow
{
	public static class SaveLoadUtils
	{
		private const string DATA_KEY = "FavoritesData_";
		private const string SETTINGS_KEY = "FavoritesSettings";

        public static List<FavoritePanel> LoadFavorites(bool displayFullPath)
        {
            string jsonData = EditorPrefs.GetString(DATA_KEY + PlayerSettings.productGUID.ToString(), string.Empty);
            if (string.IsNullOrEmpty(jsonData))
                return new List<FavoritePanel>();

            FavoritesData data = JsonUtility.FromJson<FavoritesData>(jsonData);

            List<FavoritePanel> favoritePanels = new List<FavoritePanel>();

            foreach (FavoritePanel favoritePanel in data.FavoritePanels)
            {
                favoritePanel.LoadData();
                favoritePanels.Add(favoritePanel);
            }

            foreach (FavoritePanel panel in favoritePanels)
                panel.Favorites.RemoveAll(favorite => favorite == null);

            return favoritePanels;
        }

        public static void SaveFavorites(List<FavoritePanel> favoritePanels)
        {
            FavoritesData data = new FavoritesData { FavoritePanels = favoritePanels };
            foreach (FavoritePanel favoritePanel in data.FavoritePanels)
            {
                favoritePanel.SaveData();
            }

            string jsonData = JsonUtility.ToJson(data);
            EditorPrefs.SetString(DATA_KEY + PlayerSettings.productGUID.ToString(), jsonData);
        }

        public static FavoriteSettings LoadSettings()
        {
            string jsonData = EditorPrefs.GetString(SETTINGS_KEY + PlayerSettings.productGUID.ToString(), string.Empty);

            if (!string.IsNullOrEmpty(jsonData))
                return JsonUtility.FromJson<FavoriteSettings>(jsonData);
            else
                return new FavoriteSettings();
        }

        public static void SaveSettings(FavoriteSettings settings)
        {
            string jsonData = JsonUtility.ToJson(settings);
            EditorPrefs.SetString(SETTINGS_KEY + PlayerSettings.productGUID.ToString(), jsonData);
        }
    }
}