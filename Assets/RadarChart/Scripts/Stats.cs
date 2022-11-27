using StatsSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RadarChart
{
    public class Stats: IStats
    {
        public event EventHandler OnStatsChanged;

        public static int STAT_MIN = 0;
        public static int STAT_MAX = 20;

        private CharacterStat attackStat;
        private CharacterStat defenseStat;
        private CharacterStat speedStat;
        private CharacterStat magicStat;
        private CharacterStat healthStat;

        public enum Type
        {
            Attack,
            Defense,
            Speed,
            Magic,
            Health
        }

        public Stats(int attackStatAmount, int defenseStatAmount, int speedStatAmount, int magicStatAmount, int healthStatAmount)
        {
            attackStat = new CharacterStat(attackStatAmount, STAT_MIN, STAT_MAX);
            defenseStat = new CharacterStat(defenseStatAmount, STAT_MIN, STAT_MAX);
            speedStat = new CharacterStat(speedStatAmount, STAT_MIN, STAT_MAX);
            magicStat = new CharacterStat(magicStatAmount, STAT_MIN, STAT_MAX);
            healthStat = new CharacterStat(healthStatAmount, STAT_MIN, STAT_MAX);
        }

        private CharacterStat GetSingleStat(Type statType)
        {
            switch (statType)
            {
                case Type.Attack:
                    return attackStat;
                case Type.Defense:
                    return defenseStat;
                case Type.Speed:
                    return speedStat;
                case Type.Magic:
                    return magicStat;
                case Type.Health:
                    return healthStat;
                default:
                    return null;
            }
        }

        public void SetStatAmount(Type statType, int statAmount)
        {
            GetSingleStat(statType).IncreaseDecreaseBaseStat(statAmount);

            OnStatsChanged?.Invoke(this, EventArgs.Empty);
        }

        public void IncreaseStatAmount(Type statType)
        {
            SetStatAmount(statType, +1);
        }

        public void DecreaseStatAmount(Type statType)
        {
            SetStatAmount(statType, -1);
        }

        public int GetStatAmount(Type statType)
        {
            return Mathf.RoundToInt(GetSingleStat(statType).StatBaseValue);
        }

        public float GetStatAmountNormalized(Type statType)
        {
            return GetSingleStat(statType).GetFinalValueAfterModifiersNormalized;
        }

        public List<float> StatsToList()
        {
            List<float> statsList = new List<float>();
            statsList.Add(GetStatAmountNormalized(Type.Attack));
            statsList.Add(GetStatAmountNormalized(Type.Defense));
            statsList.Add(GetStatAmountNormalized(Type.Speed));
            statsList.Add(GetStatAmountNormalized(Type.Magic));
            statsList.Add(GetStatAmountNormalized(Type.Health));

            return statsList;
        }
    }
}
