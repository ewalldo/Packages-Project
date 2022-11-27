using System;

namespace StatsSystem
{
    public class StatsModifier: IComparable
    {
        public float Value { get; private set; }
        public StatsModifiersType StatsModifiersType { get; private set; }
        public int ModifierOrder { get; private set; }
        public object ModifierSource { get; private set; }

        public StatsModifier(float value, StatsModifiersType statsModifiersType, int modifierOrder, object modifierSource)
        {
            Value = value;
            StatsModifiersType = statsModifiersType;
            ModifierOrder = modifierOrder;
            ModifierSource = modifierSource;
        }

        public StatsModifier(float value, StatsModifiersType statsModifiersType)
            : this(value, statsModifiersType, (int)statsModifiersType, null) { }

        public StatsModifier(float value, StatsModifiersType statsModifiersType, int modifierOrder)
            : this(value, statsModifiersType, modifierOrder, null) { }

        public StatsModifier(float value, StatsModifiersType statsModifiersType, object modifierSource)
            : this(value, statsModifiersType, (int)statsModifiersType, modifierSource) { }

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
        Flat = 100,
        PercentageAdditive = 200,
        PercentageMultiplicative = 300,
    }
}
