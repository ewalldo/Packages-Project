using System;
using UnityEngine;

namespace StatsSystem
{
    [Serializable]
    public class StatsModifier: IComparable<StatsModifier>
    {
        [SerializeField] private float value;
        [SerializeField] private StatType statTypeTarget;
        [SerializeField] private StatsModifiersType statsModifiersType;
        [SerializeField] private int modifierOrder;
        [SerializeField] private UnityEngine.Object modifierSource;
        [SerializeField] private bool canEditModifierOrder;

        public static string GetNameOfValue => nameof(value);
        public static string GetNameOfStaticTypeTarget => nameof(statTypeTarget);
        public static string GetNameOfStatModifierType => nameof(statsModifiersType);
        public static string GetNameOfModifierOrder => nameof(modifierOrder);
        public static string GetNameOfModifierSource => nameof(modifierSource);
        public static string GetNameOfCanEditModifierOrder => nameof(canEditModifierOrder);

        /// <summary>
        /// Modifier value
        /// </summary>
        public float Value => value;

        /// <summary>
        /// The stat type who this modifier is targeting
        /// </summary>
        public StatType StatTypeTarget => statTypeTarget;

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
        /// Instantiate a new instance of the <see cref="StatsModifier"/> class
        /// </summary>
        /// <param name="value">The value of this modifier</param>
        /// <param name="statTypeTarget">The statType that this modifier will modify</param>
        /// <param name="statsModifiersType">The type of this modifier</param>
        /// <param name="modifierOrder">The order of this modifier when applying to the stat, if negative it defaults to the StatsModifiersType value</param>
        /// <param name="modifierSource">The source object of this modifier</param>
        public StatsModifier(float value, StatType statTypeTarget, StatsModifiersType statsModifiersType, int modifierOrder = -1, UnityEngine.Object modifierSource = null)
        {
            this.value = value;
            this.statTypeTarget = statTypeTarget;
            this.statsModifiersType = statsModifiersType;
            this.modifierOrder = modifierOrder < 0 ? (int)statsModifiersType : modifierOrder;
            this.modifierSource = modifierSource;
        }

        /// <summary>
        /// Sort the StatsModifier class by the ModifierOrder attribute
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(StatsModifier other)
        {
            if (other == null)
                return 1;

            return ModifierOrder.CompareTo(other.ModifierOrder);
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
