namespace GridSystem.Pathfinding
{
	public interface ITraversalProvider
	{
        /// <summary>
        /// Whether this position can be traversed
        /// </summary>
        bool IsWalkable { get; }

        /// <summary>
        /// The cost to enter this position (default: 1)
        /// </summary>
        int MovementCost { get; }
    }
}