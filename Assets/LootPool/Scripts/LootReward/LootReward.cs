using System;

namespace LootSystem
{
    /// <summary>
    /// The payload of a loot pool item to indicate what actually drops.
    /// Extend this class to add your own reward types.
    /// </summary>
	[Serializable]
	public abstract class LootReward
	{
        /// <summary>
        /// A short human-readable name for the specif reward type
        /// </summary>
        public abstract string DisplayName { get; }

        /// <summary>
        /// Whether the reward is fully configured or not (e.g. a prefab has been assigned to a reward that requires a prefab)
        /// </summary>
        public abstract bool IsValid { get; }
	}
}