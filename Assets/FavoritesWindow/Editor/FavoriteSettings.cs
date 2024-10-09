namespace FavoritesWindow
{
    [System.Serializable]
	public class FavoriteSettings
	{
		public bool DisplayFullPath;
		public bool DisplayIcons;
		public int CurrentPanel;

		public FavoriteSettings(bool displayFullPath, bool displayIcons, int currentPanel)
        {
			DisplayFullPath = displayFullPath;
			DisplayIcons = displayIcons;
			CurrentPanel = currentPanel;
		}

        public FavoriteSettings()
        {
			DisplayFullPath = false;
			DisplayIcons = true;
			CurrentPanel = -1;
		}
	}
}