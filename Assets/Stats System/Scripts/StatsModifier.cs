using System;
using UnityEngine;

namespace StatsSystem
{
    [Serializable]
    public class StatsModifier: IComparable
    {
        [SerializeField] private float value;
        [SerializeField] private StatsModifiersType statsModifiersType;
        [SerializeField] private int modifierOrder;
        [SerializeField] private UnityEngine.Object modifierSource;
        [SerializeField] private bool canEditModifierOrder;

        public static string GetNameOfValue => nameof(value);
        public static string GetNameOfStatModifierType => nameof(statsModifiersType);
        public static string GetNameOfModifierOrder => nameof(modifierOrder);
        public static string GetNameOfModifierSource => nameof(modifierSource);
        public static string GetNameOfCanEditModifierOrder => nameof(canEditModifierOrder);

        /// <summary>
        /// Modifier value
        /// </summary>
        public float Value => value;

        /// <summary>
        /// The type of this modifier
        /// </summary>
        public StatsModifiersType StatsModifiersType => statsModifiersType;

        /// <summary>
        /// The order of this modifier when applying to the stat
        /// </summary>
        public int ModifierOrder => modifierOrder;

        /// <summary>
        /// The source object of this modifier
        /// </summary>
        public UnityEngine.Object ModifierSource => modifierSource;

        /// <summary>
        /// Initialize a new instance of the <see cref="StatsModifier"/> class
        /// </summary>
        /// <param name="value">The value of this modifier</param>
        /// <param name="statsModifiersType">The type of this modifier</param>
        /// <param name="modifierOrder">The order of this modifier when applying to the stat</param>
        /// <param name="modifierSource">The source object of this modifier</param>
        public StatsModifier(float value, StatsModifiersType statsModifiersType, int modifierOrder, UnityEngine.Object modifierSource)
        {
            this.value = value;
            this.statsModifiersType = statsModifiersType;
            this.modifierOrder = modifierOrder;
            this.modifierSource = modifierSource;
        }

        public StatsModifier(float value, StatsModifiersType statsModifiersType)
            : this(value, statsModifiersType, (int)statsModifiersType, null) { }

        public StatsModifier(float value, StatsModifiersType statsModifiersType, int modifierOrder)
            : this(value, statsModifiersType, modifierOrder, null) { }

        public StatsModifier(float value, StatsModifiersType statsModifiersType, UnityEngine.Object modifierSource)
            : this(value, statsModifiersType, (int)statsModifiersType, modifierSource) { }

        /// <summary>
        /// Sort the StatsModifier class by the ModifierOrder attribute
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            StatsModifier statsModifier = obj as StatsModifier;

            if (this.ModifierOrder < statsModifier.ModifierOrder)
                return -1;
            else if (this.ModifierOrder > statsModifier.ModifierOrder)
                return 1;
            else
                return 0;
        }
    }

    public enum StatsModifiersType
    {
        /// <summary>
        /// Flat value modifier to be added/subtracted to the stat
        /// </summary>
        Flat = 100,
        /// <summary>
        /// Percentage additive value to modify the stat (All percentage additive modifiers are added together before applied to the stat)
        /// </summary>
        PercentageAdditive = 200,
        /// <summary>
        /// Percentage multiplicative value to modify the stat (Percentage multiplicative modifiers are applied right away to the stat)
        /// </summary>
        PercentageMultiplicative = 300,
    }
}
