using System;
using System.Collections.Generic;
using UnityEngine;

namespace StatsSystem
{
    public class CharacterStat
    {
        /// <summary>
        /// The stat base value
        /// </summary>
        public float StatBaseValue { get; private set; }

        /// <summary>
        /// The modifiers on this stat
        /// </summary>
        public List<StatsModifier> StatsModifiers { get; private set; }

        /// <summary>
        /// The minimum value this stat can reach
        /// </summary>
        private readonly float statMinValue;

        /// <summary>
        /// The maximum value this stat can reach
        /// </summary>
        private readonly float statMaxValue;

        /// <summary>
        /// Initialize a new instance of the <see cref="CharacterStat"/> class
        /// </summary>
        /// <param name="statBaseValue">The stat initial value</param>
        /// <param name="statMinValue">The minimum value this stat can reach</param>
        /// <param name="statMaxValue">The maximum value this stat can reach</param>
        public CharacterStat(float statBaseValue, float statMinValue = float.MinValue, float statMaxValue = float.MaxValue)
        {
            StatBaseValue = statBaseValue;
            this.statMinValue = statMinValue;
            this.statMaxValue = statMaxValue;

            StatsModifiers = new List<StatsModifier>();
        }

        /// <summary>
        /// Get the final stat value after the modifiers were applied
        /// </summary>
        public float GetFinalValueAfterModifiers => CalculateFinalValue();

        /// <summary>
        /// Get the final stat normalized after the modifiers were applied
        /// </summary>
        public float GetFinalValueAfterModifiersNormalized => CalculateFinalValue() / statMaxValue;

        /// <summary>
        /// Get the base stat normalized
        /// </summary>
        public float GetStatBaseValueNormalized => StatBaseValue / statMaxValue;

        /// <summary>
        /// Increase/decrease the stat by the passed amount
        /// </summary>
        /// <param name="amount">The amount to modify the stat</param>
        public void IncreaseDecreaseBaseStat(float amount)
        {
            StatBaseValue += amount;
            StatBaseValue = Mathf.Clamp(StatBaseValue, statMinValue, statMaxValue);
        }

        /// <summary>
        /// Add a modifier to the stat
        /// </summary>
        /// <param name="statsModifier">The modifier to be added</param>
        public void AddModifier(StatsModifier statsModifier)
        {
            StatsModifiers.Add(statsModifier);
            StatsModifiers.Sort();
        }

        /// <summary>
        /// Remove a modifier from the stat
        /// </summary>
        /// <param name="statsModifier">The modifier to be removed</param>
        /// <returns>If the modifier removal was successful or not</returns>
        public bool RemoveModifier(StatsModifier statsModifier)
        {
            return StatsModifiers.Remove(statsModifier);
        }

        /// <summary>
        /// Remove all the modifiers from a specific source
        /// </summary>
        /// <param name="modifierSource">The source indicating which modifiers should be removed</param>
        /// <returns>If the modifier list was modified or not</returns>
        public bool RemoveModifiersBySource(object modifierSource)
        {
            bool somethingWasRemoved = false;

            for (int i = StatsModifiers.Count - 1; i >= 0; i--)
            {
                if (StatsModifiers[i].ModifierSource == modifierSource)
                {
                    somethingWasRemoved = true;
                    StatsModifiers.RemoveAt(i);
                }
            }

            return somethingWasRemoved;
        }

        /// <summary>
        /// Calculate the final value of the stat after all modifiers are applied
        /// </summary>
        /// <param name="precision">How many decimal places the stat should be rounded to</param>
        /// <returns>The value of the stat after the modifiers</returns>
        private float CalculateFinalValue(int precision = 4)
        {
            float finalValue = StatBaseValue;
            float sumPercentageToAdd = 0f;

            for (int i = 0; i < StatsModifiers.Count; i++)
            {
                StatsModifier statsModifier = StatsModifiers[i];

                switch (statsModifier.StatsModifiersType)
                {
                    case StatsModifiersType.Flat:
                        finalValue += statsModifier.Value;
                        break;
                    case StatsModifiersType.PercentageAdditive:
                        sumPercentageToAdd += statsModifier.Value;

                        if (i + 1 >= StatsModifiers.Count || StatsModifiers[i + 1].StatsModifiersType != StatsModifiersType.PercentageAdditive)
                        {
                            finalValue *= 1 + sumPercentageToAdd;
                            sumPercentageToAdd = 0f;
                        }

                        break;
                    case StatsModifiersType.PercentageMultiplicative:
                        finalValue *= 1 + statsModifier.Value; // value = value * (100% + percentModifier)
                        break;
                    default:
                        break;
                }

                finalValue += statsModifier.Value;
            }

            return Mathf.Clamp((float)Math.Round(finalValue, precision), statMinValue, statMaxValue);
        }
    }
}
