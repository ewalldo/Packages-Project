using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Tween
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

        /// <summary>
        /// Create an instance of an EasingFunction based on an EasingType
        /// </summary>
        /// <param name="easingType">The EasingType of the EasingFunction to instantiate</param>
        /// <param name="constructorArgs">Optional arguments for the constructor</param>
        /// <returns>An EasingFunction instance</returns>
        public static EasingFunction GetEasing(EasingType easingType, params object[] constructorArgs)
        {
            if (!easingByName.ContainsKey(easingType))
                return null;

            Type type = easingByName[easingType];

            try
            {
                EasingFunction easing = Activator.CreateInstance(type, constructorArgs) as EasingFunction;
                return easing;
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to create easing function of the type {easingType}: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Create an instance of an EasingFunction based on an EasingType string
        /// </summary>
        /// <param name="easingTypeString">The EasingType of the EasingFunction to instantiate in string format</param>
        /// <param name="constructorArgs">Optional arguments for the constructor</param>
        /// <returns>An EasingFunction instance</returns>
        public static EasingFunction GetEasing(string easingTypeString, params object[] constructorArgs)
        {
            if (Enum.TryParse(easingTypeString, out EasingType easingType))
            {
                return GetEasing(easingType, constructorArgs);
            }

            return null;
        }

        public static IEnumerable<EasingType> GetEasingNames()
        {
            return easingByName.Keys;
        }
    }
}