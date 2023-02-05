using UnityEngine;
using System.Collections.Generic;
using System;

namespace StatsSystem
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private StatTypeSet characterStatsTypeSet;

        private Dictionary<StatType, SingleStat> characterStats;

        public static Action<StatType, float> OnStatUpdated;

        private void Start()
        {
            characterStats = new Dictionary<StatType, SingleStat>();

            foreach (StatType type in characterStatsTypeSet.GetStatTypeSet)
            {
                characterStats[type] = new SingleStat(type, UnityEngine.Random.Range(1, 10), 0, 99);
                OnStatUpdated?.Invoke(type, characterStats[type].GetFinalValueAfterModifiers);
            }
        }

        public SingleStat GetStat(StatType type)
        {
            if (characterStats.ContainsKey(type))
            {
                return characterStats[type];
            }
            else
            {
                Debug.LogError("This character does not have the stat of the type " + type.GetStatName);
                return null;
            }
        }

        public void AddModifierToStat(StatType type, StatsModifier statsModifier)
        {
            GetStat(type).AddModifier(statsModifier);

            OnStatUpdated?.Invoke(type, characterStats[type].GetFinalValueAfterModifiers);
        }

        public void RemoveModifierFromStat(StatType type, StatsModifier statsModifier)
        {
            // can also use GetStat(type).RemoveModifiersBySource(statsModifier.ModifierSource);
            GetStat(type).RemoveModifier(statsModifier);

            OnStatUpdated?.Invoke(type, characterStats[type].GetFinalValueAfterModifiers);
        }
    }
}
