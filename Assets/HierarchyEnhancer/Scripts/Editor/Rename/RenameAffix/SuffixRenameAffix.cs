using UnityEngine;

namespace HierarchyEnhancer
{
	public class SuffixRenameAffix : IRenameAffix
	{
        public RenameAffixEnum GetRenameAffix => RenameAffixEnum.Suffix;

        public string GetNewName(string baseName, string affix)
        {
            return (baseName + affix);
        }
    }
}