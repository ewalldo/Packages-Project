using System;
using System.Collections.Generic;
using UnityEngine;

namespace StatsSystem
{
    public class CharacterStat
    {
        public float StatBaseValue { get; private set; }
        public List<StatsModifier> StatsModifiers { get; private set; }

        private float statMinValue;
        private float statMaxValue;

        public CharacterStat(float statBaseValue, float statMinValue = float.MinValue, float statMaxValue = float.MaxValue)
        {
            StatBaseValue = statBaseValue;
            this.statMinValue = statMinValue;
            this.statMaxValue = statMaxValue;

            StatsModifiers = new List<StatsModifier>();
        }

        public float GetFinalValueAfterModifiers => CalculateFinalValue();
        public float GetFinalValueAfterModifiersNormalized => CalculateFinalValue() / statMaxValue;

        public float GetStatBaseValueNormalized => StatBaseValue / statMaxValue;

        public void IncreaseDecreaseBaseStat(float amount)
        {
            StatBaseValue += amount;
            StatBaseValue = Mathf.Clamp(StatBaseValue, statMinValue, statMaxValue);
        }

        public void AddModifier(StatsModifier statsModifier)
        {
            StatsModifiers.Add(statsModifier);
            StatsModifiers.Sort();
        }

        public bool RemoveModifier(StatsModifier statsModifier)
        {
            return StatsModifiers.Remove(statsModifier);
        }

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
