using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TooltipSystem
{
    public static class EasingFactory
    {
        private static Dictionary<EasingType, Type> easingByName;

        static EasingFactory()
        {
            IEnumerable<Type> easingTypes = Assembly.GetAssembly(typeof(EasingFunction)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(EasingFunction)));

            easingByName = new Dictionary<EasingType, Type>();

            foreach (Type type in easingTypes)
            {
                EasingFunction tempEasing = Activator.CreateInstance(type) as EasingFunction;
                easingByName.Add(tempEasing.EasingName, type);
            }
        }

        public static EasingFunction GetEasing(EasingType easingType)
        {
            if (!easingByName.ContainsKey(easingType))
                return null;

            Type type = easingByName[easingType];
            EasingFunction easing = Activator.CreateInstance(type) as EasingFunction;
            return easing;
        }

        public static IEnumerable<EasingType> GetEasingNames()
        {
            return easingByName.Keys;
        }
    }
}