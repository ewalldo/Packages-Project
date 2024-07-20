namespace HierarchyEnhancer
{
	public interface IRenameAffix
	{
		RenameAffixEnum GetRenameAffix { get; }
		string GetNewName(string baseName, string affix);
	}
}