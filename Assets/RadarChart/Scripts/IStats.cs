using System;
using System.Collections.Generic;

namespace RadarChart
{
    public interface IStats
    {
        public event EventHandler OnStatsChanged;

        public List<float> StatsToList();
    }
}
