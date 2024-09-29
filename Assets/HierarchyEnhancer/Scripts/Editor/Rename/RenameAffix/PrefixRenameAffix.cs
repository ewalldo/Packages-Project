using UnityEngine;

namespace HierarchyEnhancer
{
	public class PrefixRenameAffix : IRenameAffix
	{
        public RenameAffixEnum GetRenameAffix => RenameAffixEnum.Prefix;

        public string GetNewName(string baseName, string affix)
        {
            return (affix + baseName);
        }
    }
}