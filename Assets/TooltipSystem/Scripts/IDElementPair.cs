namespace TooltipSystem
{
	[System.Serializable]
	public class IDElementPair<T>
	{
        public string ID;
        public T element;

        public static string GetNameOfID => nameof(ID);
        public static string GetNameOfElement => nameof(element);

        public IDElementPair(string ID, T element)
        {
            this.ID = ID;
            this.element = element;
        }
    }
}