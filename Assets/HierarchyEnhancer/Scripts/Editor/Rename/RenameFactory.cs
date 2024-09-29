using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HierarchyEnhancer
{
	public static class RenameFactory
	{
        private static Dictionary<RenameTargetEnum, Type> renameTargetByName;
        private static Dictionary<RenameAffixEnum, Type> renameAffixByName;

        static RenameFactory()
        {
            IEnumerable<Type> renameTargetTypes = GetRenameTypes(typeof(IRenameTarget));
            IEnumerable<Type> renameAffixTypes = GetRenameTypes(typeof(IRenameAffix));

            renameTargetByName = new Dictionary<RenameTargetEnum, Type>();
            renameAffixByName = new Dictionary<RenameAffixEnum, Type>();

            foreach (Type type in renameTargetTypes)
            {
                IRenameTarget renameTarget = Activator.CreateInstance(type) as IRenameTarget;
                renameTargetByName.Add(renameTarget.GetRenameTarget, type);
            }

            foreach (Type type in renameAffixTypes)
            {
                IRenameAffix renameAffix = Activator.CreateInstance(type) as IRenameAffix;
                renameAffixByName.Add(renameAffix.GetRenameAffix, type);
            }
        }

        public static IRenameTarget GetRenameTarget(RenameTargetEnum renameTargetEnum)
        {
            if (!renameTargetByName.ContainsKey(renameTargetEnum))
                return null;

            Type type = renameTargetByName[renameTargetEnum];
            IRenameTarget renameTarget = Activator.CreateInstance(type) as IRenameTarget;
            return renameTarget;
        }

        public static IRenameAffix GetRenameAffix(RenameAffixEnum renameAffixEnum)
        {
            if (!renameAffixByName.ContainsKey(renameAffixEnum))
                return null;

            Type type = renameAffixByName[renameAffixEnum];
            IRenameAffix renameAffix = Activator.CreateInstance(type) as IRenameAffix;
            return renameAffix;
        }

        private static IEnumerable<Type> GetRenameTypes(Type type)
        {
            IEnumerable<Type> renameTypes = Assembly.GetAssembly(type).GetTypes().Where(myType => myType.IsClass && type.IsAssignableFrom(myType));

            return renameTypes;
        }
    }
}