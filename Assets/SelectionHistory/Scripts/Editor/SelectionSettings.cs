namespace SelectionHistory
{
    [System.Serializable]
	public class SelectionSettings
	{
		public int HistoryLength;
		public bool DisplayIcons;
		public bool RegisterHierarchyWindow;
		public bool RegisterProjectWindow;

        public SelectionSettings(int historyLength, bool displayIcons, bool registerHierarchyWindow, bool registerProjectWindow)
        {
			HistoryLength = historyLength;
			DisplayIcons = displayIcons;
			RegisterHierarchyWindow = registerHierarchyWindow;
			RegisterProjectWindow = registerProjectWindow;
		}

        public SelectionSettings()
        {
			HistoryLength = 20;
			DisplayIcons = true;
			RegisterHierarchyWindow = true;
			RegisterProjectWindow = true;
		}
	}
}